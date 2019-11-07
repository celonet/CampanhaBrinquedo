using CampanhaBrinquedo.Application.Services.Builders;
using CampanhaBrinquedo.Domain.Entities.Campaign;
using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Entities.User;
using CampanhaBrinquedo.Domain.Repositories;
using CampanhaBrinquedo.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Application.Services
{
    public class CampaignService : ICampaignServiceApp
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IChildRepository _childRepository;
        private readonly IChildImportRepository _childImportRepository;

        public CampaignService(ICampaignRepository campaignRepository, IChildRepository childRepository, IChildImportRepository childImportRepository)
        {
            _campaignRepository = campaignRepository;
            _childRepository = childRepository;
            _childImportRepository = childImportRepository;
        }

        public async Task ChangeCampaign(Campaign entity) => await _campaignRepository.UpdateAsync(entity);

        public async Task ChangeState(CampaignState state, User user)
        {
            var campaign = await GetCurrent();

            switch (state)
            {
                case CampaignState.Closed:
                    campaign.Close(user);
                    break;
                case CampaignState.Open:
                    campaign.Open(user);
                    break;
                case CampaignState.Reopened:
                    campaign.Reopen(user);
                    break;
                case CampaignState.NotStarted:
                default:
                    break;
            }
        }

        public async Task CreateCampaign(Campaign campaign) => await _campaignRepository.CreateAsync(campaign);

        public async Task DeleteCampaign(Guid id) => await _campaignRepository.DeleteAsync(id);

        public async Task<Campaign> GetCurrent() => await _campaignRepository.FindByExpression(_ => _.State == CampaignState.Open);

        public async Task<CampaignInformation> GetInformations()
        {
            var campaign = await GetCurrent();
            var childs = await _childRepository.GetCriancasPorCampanha(campaign.Year);
            var communities = childs.SelectMany(_ => _.Communities).Select(_ => _.Name).Distinct();
            var godFathers = childs.SelectMany(_ => _.GodFathers).Select(_ => _.Name).Distinct();
            return new CampaignInformation(
                campaign.Year,
                new CampaignAnalitics
                {
                    Capacity = campaign.ChildrensQty,
                    ChildrenQty = childs.Count(),
                    CommunityQty = communities.Count(),
                    GodFatherQty = godFathers.Count(),
                },
                new GenderAnalitcs
                {
                    MaleQty = childs.Count(_ => _.Gender == Gender.Male),
                    FemaleQty = childs.Count(_ => _.Gender == Gender.Woman)
                }
            );
        }

        public async Task ImportCampaign(int year, byte[] file)
        {
            var campaign = await _campaignRepository.FindByExpression(_ => _.Year == year);
            if (campaign == null)
            {
                string xmlFile = System.Text.Encoding.ASCII.GetString(file);

                var childImports = _childImportRepository.GetImports(xmlFile);

                _campaignRepository.Create(new Campaign(year, "", childImports.Count()));
                var createdCampaign = await _campaignRepository.FindByExpression(_ => _.Year == year);
                await InsertChilds(childImports, createdCampaign);
            }
        }

        private async Task InsertChilds(IEnumerable<ChildImport> criancas, Campaign campaign)
        {
            var childs = await _childRepository.List();
            foreach (var crianca in criancas)
            {
                var childExists = Exists(crianca.Nome, childs);

                if (childExists != null)
                {
                    if (childExists.Campaigns.FirstOrDefault(_ => _.Year == campaign.Year) != null)
                    {
                        Console.WriteLine($"{crianca.Nome} ja existe para a campanha {campaign.Year}");
                        continue;
                    }

                    Console.WriteLine($"Alterando {crianca.Nome}");

                    childExists.Ages.Add(new Age(campaign.Year, crianca.Idade));

                    childExists.Clothings.Add(new Clothing(campaign.Year, crianca.Roupa));

                    if (crianca.Comunidade != childExists.Communities[0].Name)
                    {
                        childExists.Communities.Add(new Community(campaign.Year, crianca.Comunidade, crianca.Bairro));
                    }

                    if (!string.IsNullOrWhiteSpace(crianca.Padrinho))
                    {
                        childExists.AddGodFathers(
                            new GodFather(
                                campaign.Year,
                                crianca.Padrinho,
                                new Community(campaign.Year, crianca.PadrinhoComunidade, ""),
                                crianca.Telefone,
                                crianca.Telefone2
                            ));
                    }

                    if (!string.IsNullOrWhiteSpace(crianca.Responsavel))
                    {
                        childExists.Responsiblies.Add(
                            new Responsible(campaign.Year, crianca.Responsavel, crianca.RG)
                        );
                    }

                    childExists.Campaigns.Add(campaign);

                    childExists.AddPrinteds(
                        new Printed(campaign.Year, crianca.Impresso)
                    );

                    await _childRepository.UpdateAsync(childExists);
                }
                else
                {
                    var newChild = new ChildBuilder()
                      .SetCampaign(campaign)
                      .AddCampaign(campaign.Year, campaign.ChildrensQty, campaign.Description)
                      .SetName(crianca.Nome)
                      .AddAge(crianca.Idade)
                      .AddClothing(crianca.Roupa)
                      .SetGender(crianca.Sexo)
                      .SetPCD(crianca.Especial)
                      .AddPrinted(crianca.Impresso)
                      .AddCommunty(crianca.Comunidade, crianca.Bairro)
                      .AddGodFathers(crianca.Padrinho, new Community(campaign.Year, crianca.PadrinhoComunidade, ""), crianca.Telefone, crianca.Telefone2, "")
                      .AddResponsible(crianca.Responsavel, crianca.RG)
                      .Build();
                    Console.WriteLine($"Incluindo {crianca.Nome}");
                    await _childRepository.CreateAsync(newChild);
                }
            }
        }

        private Child Exists(string name, IEnumerable<Child> childs)
        {
            foreach (var child in childs)
            {
                try
                {
                    //|| StringUtils.CheckSimilarity(child.Name, name) > 0.7
                    if (child.Name == name)
                    {
                        return child;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
    }
}
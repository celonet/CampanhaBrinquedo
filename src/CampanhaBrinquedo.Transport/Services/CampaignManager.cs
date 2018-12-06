using CampanhaBrinquedo.Transport.Data.Repositories;
using CampanhaBrinquedo.Transport.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampanhaBrinquedo.Transport
{
    internal class CampaignManager : ICampaignManager
    {
        private List<Campaign> _campaigns;
        private readonly ICriancaRepository _criancaRepository;
        private readonly CampaignOptions _options;
        private readonly IChildRepository _childRepository;

        public CampaignManager(
            IOptions<CampaignOptions> options,
            ICriancaRepository criancaRepository,
            IChildRepository childRepository)
        {
            _options = options.Value;
            _childRepository = childRepository;
            _criancaRepository = criancaRepository;
            _campaigns = new List<Campaign>();
        }

        public async Task CreateCampaign()
        {
            foreach(var confCampaign in _options.Campaigns)
            {
                Console.WriteLine($"Criando Campanha {confCampaign.Year}");

                var campaignStorad = await _childRepository.GetCampaign(confCampaign.Year);
                if(campaignStorad == null)
                {
                    campaignStorad = new Campaign(confCampaign.Year, confCampaign.State);
                    await _childRepository.InsertCampaign(campaignStorad);
                }

                _campaigns.Add(campaignStorad);
            }
        }

        public async Task Migrate()
        {
            foreach(var campaign in _campaigns)
            {
                Console.WriteLine($"[Migrando Criancas {campaign.Year}]");

                try
                {
                    var criancas = _criancaRepository.GetCriancas(campaign.Year);
                    campaign.ChildrensQty = criancas.Count();
                    await _childRepository.UpdateCampaign(campaign);
                    await InsertChilds(criancas, campaign);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task InsertChilds(IEnumerable<Crianca> criancas, Campaign campaign)
        {
            var childs = await _childRepository.GetChilds();
            foreach(var crianca in criancas)
            {
                var childExists = Exists(crianca.Nome, childs);

                if(childExists != null)
                {
                    if(childExists.Campaigns.FirstOrDefault(_ => _.Year == campaign.Year) != null)
                    {
                        Console.WriteLine($"{crianca.Nome} ja existe para a campanha {campaign.Year}");
                        continue;
                    }

                    Console.WriteLine($"Alterando {crianca.Nome}");

                    childExists.Ages.Add(new Age(campaign.Year, crianca.Idade));

                    childExists.Clothings.Add(new Clothing(campaign.Year, crianca.Roupa));

                    if(crianca.Comunidade != childExists.Communities[0].Name)
                    {
                        childExists.Communities.Add(new Community(campaign.Year, crianca.Comunidade, crianca.Bairro));
                    }

                    if(!string.IsNullOrWhiteSpace(crianca.Padrinho))
                    {
                        childExists.Godfathers.Add(new GodFather(campaign.Year, crianca.Padrinho, new Community(campaign.Year, crianca.PadrinhoComunidade, ""), crianca.Telefone, crianca.Telefone2, ""));
                    }

                    if(!string.IsNullOrWhiteSpace(crianca.Responsavel))
                    {
                        childExists.Responsiblies.Add(new Responsible(campaign.Year, crianca.Responsavel, crianca.RG));
                    }

                    childExists.Campaigns.Add(campaign);

                    childExists.Printed.Add(new Printed(campaign.Year, crianca.Impresso));

                    await _childRepository.UpdateChild(childExists);
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
                    await _childRepository.InsertChild(newChild);
                }
            }
        }

        private Child Exists(string name, IEnumerable<Child> childs)
        {
            foreach(var child in childs)
            {
                try
                {
                    //|| StringUtils.CheckSimilarity(child.Name, name) > 0.7
                    if(child.Name == name)
                    {
                        return child;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
    }
}
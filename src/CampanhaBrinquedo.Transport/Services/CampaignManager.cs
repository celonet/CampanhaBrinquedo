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
        private Campaign _campaign;
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
        }

        public async Task CreateCampaign()
        {
            var confCampaign = _options.GetCurrentCampaign();
            var campaignStorad = await _childRepository.GetCampaign(confCampaign.Year);
            if(campaignStorad == null)
            {
                _campaign = new Campaign(confCampaign.Year, confCampaign.State);
                await _childRepository.InsertCampaign(_campaign);
            }
            else
            {
                _campaign = campaignStorad;
            }
        }

        public async Task Migrate()
        {
            if(_campaign == null)
            {
                throw new Exception("Campanha nao configurada!");
            }

            try
            {
                var criancas = _criancaRepository.GetCriancas();
                _campaign.ChildrensQty = criancas.Count();
                await _childRepository.UpdateCampaign(_campaign);
                await InsertChilds(criancas);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task InsertChilds(IEnumerable<Crianca> criancas)
        {
            var childs = await _childRepository.GetChilds();
            foreach(var crianca in criancas)
            {
                var childExists = Exists(crianca.Nome, childs);

                if(childExists != null)
                {
                    if(childExists.Campaigns.FirstOrDefault(_ => _.Year == _campaign.Year) != null)
                    {
                        Console.WriteLine($"{crianca.Nome} ja existe para a campanha {_campaign.Year}");
                        continue;
                    }

                    Console.WriteLine($"Alterando {crianca.Nome}");

                    childExists.Age.Add(new Age(_campaign.Year, crianca.Idade));

                    childExists.Clothings.Add(new Clothing(_campaign.Year, crianca.Roupa));

                    if(crianca.Comunidade != childExists.Communities[0].Name)
                    {
                        childExists.Communities.Add(new Community(_campaign.Year, crianca.Comunidade, crianca.Bairro));
                    }

                    if(!string.IsNullOrWhiteSpace(crianca.Padrinho))
                    {
                        childExists.Godfathers.Add(new GodFather(_campaign.Year, crianca.Padrinho, new Community(_campaign.Year, crianca.PadrinhoComunidade, ""), crianca.Telefone, crianca.Telefone2, ""));
                    }

                    if(!string.IsNullOrWhiteSpace(crianca.Responsavel))
                    {
                        childExists.Responsiblies.Add(new Responsible(_campaign.Year, crianca.Responsavel, crianca.Rg));
                    }

                    childExists.Campaigns.Add(_campaign);

                    childExists.Printed.Add(new Printed(_campaign.Year, crianca.Impresso));

                    await _childRepository.UpdateChild(childExists);
                }
                else
                {
                    var newChild = new ChildBuilder()
                      .SetCampaign(_campaign)
                      .AddCampaign(_campaign.Year, _campaign.ChildrensQty, _campaign.Description)
                      .SetName(crianca.Nome)
                      .AddAge(crianca.Idade)
                      .AddClothing(crianca.Roupa)
                      .SetGender(crianca.Sexo)
                      .SetPCD(crianca.Especial)
                      .AddPrinted(crianca.Impresso)
                      .AddCommunty(crianca.Comunidade, crianca.Bairro)
                      .AddGodFathers(crianca.Padrinho, new Community(_campaign.Year, crianca.PadrinhoComunidade, ""), crianca.Telefone, crianca.Telefone2, "")
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
                if(child.Name == name)
                {
                    return child;
                }
            }
            return null;
        }
    }
}
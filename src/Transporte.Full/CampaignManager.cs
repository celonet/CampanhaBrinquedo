using System;
using System.Threading.Tasks;
using Transporte.Full.Data.Repositories;

namespace Transporte.Full
{
    internal class CampaignManager
    {
        private Campaign campaign;
        private readonly CriancaRepository _criancaRepository;
        private readonly ChildRepository _childRepository;

        public CampaignManager(CriancaRepository criancaRepository, ChildRepository childRepository)
        {
            _criancaRepository = criancaRepository;
            _childRepository = childRepository;
        }

        public async void CreateCampaign(Campaign campaign)
        {
            this.campaign = campaign;
            await _childRepository.InsertCampaign(campaign);
        }

        public async Task Migrate()
        {
            if ( campaign == null )
            {
                throw new Exception("Campanha nao configurada!");
            }

            var criancas = _criancaRepository.GetCriancas();

            foreach ( var crianca in criancas )
            {
                Console.WriteLine($"Incluindo {crianca.Nome}");
                var child = new ChildBuilder()
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
                    .Build();
                await _childRepository.InsertChild(child);
            }
        }
    }
}
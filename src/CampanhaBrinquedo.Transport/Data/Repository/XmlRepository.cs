using CampanhaBrinquedo.Transport.Model;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CampanhaBrinquedo.Transport.Data.Repositories
{
    public class XmlRepository : ICriancaRepository
    {
        private readonly CampaignOptions _options;

        public XmlRepository(IOptions<CampaignOptions> options) => _options = options.Value;

        public IEnumerable<Crianca> GetCriancas(int year)
        {
            var campaign = _options.Campaigns.FirstOrDefault(_ => _.Year == year);

            if(campaign != null && string.IsNullOrWhiteSpace(campaign.Url))
                throw new System.Exception("Arquivo faltando");

            XmlSerializer deserializer = new XmlSerializer(typeof(CampanhaMap));
            TextReader textReader = new StreamReader(campaign.Url);
            var criancas = (CampanhaMap)deserializer.Deserialize(textReader);
            textReader.Close();

            return criancas.Crianca;
        }
    }
}

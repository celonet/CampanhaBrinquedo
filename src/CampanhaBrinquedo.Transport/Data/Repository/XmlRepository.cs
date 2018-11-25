using CampanhaBrinquedo.Transport.Model;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CampanhaBrinquedo.Transport.Data.Repositories
{
    public class XmlRepository : ICriancaRepository
    {
        private readonly CampaignConfiguration _options;

        public XmlRepository(IOptions<CampaignOptions> options) => _options = options.Value.GetCurrentCampaign();

        public IEnumerable<Crianca> GetCriancas()
        {
            if(string.IsNullOrWhiteSpace(_options.Url))
                throw new System.Exception("Arquivo faltando");

            XmlSerializer deserializer = new XmlSerializer(typeof(CampanhaMap));
            TextReader textReader = new StreamReader(_options.Url);
            var criancas = (CampanhaMap)deserializer.Deserialize(textReader);
            textReader.Close();

            return criancas.Crianca;
        }
    }
}

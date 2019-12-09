using CampanhaBrinquedo.Domain.Entities.Child;
using CampanhaBrinquedo.Domain.Repositories;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CampanhaBrinquedo.Data.XmlImport.Repositories
{
    public class ChildImportRepository : IChildImportRepository
    {
        public IEnumerable<ChildImport> GetImports(string xmlFile)
        {
            using (TextReader textReader = new StringReader(xmlFile))
            {
                var deserializer = new XmlSerializer(typeof(CampanhaMap));
                var childs = (CampanhaMap)deserializer.Deserialize(textReader);
                return childs.ChildImports;
            }
        }
    }
}

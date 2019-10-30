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
            XmlSerializer deserializer = new XmlSerializer(typeof(CampanhaMap));
            TextReader textReader = new StreamReader(xmlFile);
            var childs = (CampanhaMap)deserializer.Deserialize(textReader);
            textReader.Close();

            return childs.ChildImports;
        }
    }
}

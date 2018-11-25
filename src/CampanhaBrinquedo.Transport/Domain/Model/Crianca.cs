using System;
using System.Xml.Serialization;

namespace CampanhaBrinquedo.Transport.Model
{
    [Serializable]
    public class Crianca
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Idade { get; set; }
        public string Roupa { get; set; }
        public string Sexo { get; set; }
        public bool Impresso { get; set; }
        public bool Especial { get; set; }
        public bool TemPadrinho { get; set; }
        public string Comunidade { get; set; }
        public string Bairro { get; set; }
        public string Padrinho { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string PadrinhoComunidade { get; set; }
        public string Responsavel { get; set; }
        public string Rg { get; set; }
    }

    [Serializable]
    [XmlRoot("Campanha")]
    public class CampanhaMap
    {
        [XmlElement("Crianca")]

        public Crianca[] Crianca { get; set; }
    }
}



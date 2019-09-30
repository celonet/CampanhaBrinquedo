namespace CampanhaBrinquedo.CrossCutting.Options
{
    public class JwtIssuerOptions
    {
        public string SecretKey { get; set; }
        public double Expiration { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
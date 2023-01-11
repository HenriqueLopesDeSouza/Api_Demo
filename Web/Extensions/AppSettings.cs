namespace Web.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int Expiration_Hours { get; set; }
        public string Issuer { get; set; }
        public string ValidOn { get; set; }
    }
}

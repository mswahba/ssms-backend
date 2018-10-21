namespace SSMS
{
    public class AppSettings
    {
        public string ConStr { get; set; }
        public string SecretKey { get; set; }
        public string JWTIssuer { get; set; }
        public string JWTAudience { get; set; }
    }
}
namespace SSMS
{
  public class AppSettings
  {
    public string ConStr { get; set; }
    public string SecretKey { get; set; }
    public string MasterVerificationCode { get; set; }
    public string VerificationCodeLifetime { get; set; }
    public string JWT_Issuer { get; set; }
    public string JWT_Audience { get; set; }
    public string JWT_Lifetime { get; set; }
    public string Email_Host { get; set; }
    public string Email_Port { get; set; }
    public string Email_SSL { get; set; }
    public string Email_UserName { get; set; }
    public string Email_Password { get; set; }
    public string Email_From { get; set; }
  }
}
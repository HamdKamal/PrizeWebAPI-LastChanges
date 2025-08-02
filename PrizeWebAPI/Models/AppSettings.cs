namespace PrizeWebAPI.Models
{
    public class AppSettings
    {
        public string ApiKey { get; set; }
        public string JwtSecret { get; set; }
        public string issuer { get; set; }
        public string FrontUrl { get; set; }
        public string DistinguishedManagementCategoryAttachmentsDirectory { get; set; }
    }
}

namespace SSMS.EntityModels
{
    public class HealthIssue
    {
        public short HealthIssueId { get; set; }
        public string HealthIssueNameAr { get; set; }
        public string HealthIssueNameEn { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
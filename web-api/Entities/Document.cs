namespace ACMS.WebApi.Entities
{
    public class Document
    {
        public int Id { get; set; }  // Auto-incremented ID (int)
        public string Title { get; set; }
        public string CreatorName { get; set; }
        public string ApprovalStatus { get; set; } = "Under Review";  // Initial status
        public string ManagerApprovalStatus { get; set; } = "Pending"; // Default state
        public string FinalApprovalStatus { get; set; } = "Pending"; // Default state
        public string RejectionReason { get; set; } = "";// If applicable
    }
}

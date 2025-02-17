namespace ACMS.WebApi.Models
{
    public class MedicineWorkFlowData
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public bool ApprovalNeeded { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovalUserEmail { get; set; }
    }
}
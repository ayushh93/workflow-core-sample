using System;

namespace ACMS.WebApi.Entities
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ApprovalNeeded { get; set; }
        public string ApprovalUserEmail { get; set; }
        public int InventoryCount { get; set; }
    }
}
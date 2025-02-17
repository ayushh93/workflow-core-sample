using ACMS.WebApi.Entities;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.AddMedicineStock.Steps
{
    public class GetMedicineInfoStep : StepBodyAsync
    {
        public int MedicineId { get; set; } // Input property

        // Output properties
        public bool ApprovalNeeded { get; set; }
        public string ApprovalUserEmail { get; set; }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            // Fetch medicine info from the API
            var medicine = await FetchMedicineInfo(MedicineId);

            Console.WriteLine($"Medicine Info - Approval Needed: {medicine.ApprovalNeeded}, Approval Email: {medicine.ApprovalUserEmail}");

            // Set outputs based on the fetched medicine info
            ApprovalNeeded = medicine.ApprovalNeeded;
            ApprovalUserEmail = medicine.ApprovalUserEmail;

            return ExecutionResult.Next();
        }

        private async Task<Medicine> FetchMedicineInfo(int medicineId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"http://localhost:5283/api/medicines/{medicineId}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Medicine>(json);
            }
        }
    }
}
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Models;
using Newtonsoft.Json;
using WorkflowCore.Interface;

namespace ACMS.WebApi.Workflows.AddMedicineStock.Steps
{
    public class AddToInventoryStep : StepBodyAsync
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await AddToInventory(MedicineId, Quantity);
            Console.WriteLine($"Added {Quantity} units to inventory for Medicine ID: {MedicineId}");
            return ExecutionResult.Next();
        }

        private async Task AddToInventory(int medicineId, int quantity)
        {
            using (var client = new HttpClient())
            {
                var requestBody = new { quantity };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"http://localhost:5283/api/medicines/{medicineId}/addtostock?quantity={quantity}", content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
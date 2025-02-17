using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.AddMedicineStock.Steps
{
    public class GetApprovalStep : StepBodyAsync
    {
        public bool IsApproved { get; set; }
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await GetApproval();
            Console.WriteLine("Approval status: {0}", IsApproved ? "Approved" : "Denied");
            return ExecutionResult.Next();
        }

        private Task<bool> GetApproval()
        {
            // Simulate getting an approval request
            IsApproved = false;
            return Task.FromResult(true);
        }
    }
}

using System;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.AddMedicineStock.Steps
{
    public class ApprovalRequestStep : StepBodyAsync
    {
        public string ApprovalUserEmail { get; set; }

        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            await SendApprovalRequest(ApprovalUserEmail);
            Console.WriteLine($"Email sent to {ApprovalUserEmail}");
            return ExecutionResult.Next();
        }

        private Task SendApprovalRequest(string email)
        {
            // Simulate sending an approval request
            return Task.CompletedTask;
        }
    }
}
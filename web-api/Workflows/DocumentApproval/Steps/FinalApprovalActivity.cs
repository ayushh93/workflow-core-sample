using ACMS.WebApi.Entities;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.DocumentApproval.Steps
{
    public class FinalApprovalActivity : StepBody
    {
        public Document Document { get; set; }
        public string FinalDecision { get; set; } // "Approved" or "Rejected"

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Final Approval.");
            return ExecutionResult.Next();
        }
    }
}

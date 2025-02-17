using ACMS.WebApi.Entities;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.DocumentApproval.Steps
{
    public class ManagerApprovalActivity : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Approved by Manager.");
            return ExecutionResult.Next();
        }
    }
}

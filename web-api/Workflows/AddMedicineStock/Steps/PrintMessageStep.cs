using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.AddMedicineStock.Steps
{
    public class PrintMessageStep : StepBodyAsync
    {
        public override Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            Console.WriteLine("Approval not needed");
            return Task.FromResult(ExecutionResult.Next());
        }
    }
}

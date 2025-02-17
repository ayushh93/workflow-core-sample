using ACMS.WebApi.Workflows.DocumentApproval.Steps;
using WorkflowCore.Interface;

namespace ACMS.WebApi.Workflows.DocumentApproval
{
    public class DocumentApprovalWorkFlow : IWorkflow
    {
        public string Id => "DocumentApprovalWorkFlow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<object> builder)
        {
            builder
            .StartWith<DocumentCreationStep>()
                .Then<ManagerApprovalActivity>()
                    .Then<FinalApprovalActivity>();
        }
    }
}

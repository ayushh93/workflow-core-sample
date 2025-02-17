using ACMS.WebApi.Models;
using ACMS.WebApi.Workflows.AddMedicineStock.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkflowCore.Models.LifeCycleEvents;
using WorkflowCore.Services.ErrorHandlers;

public class AddMedicineStockWorkflow : IWorkflow<MedicineWorkFlowData>
{
    public string Id => "AddMedicineStockWorkflow";
    public int Version => 1;

    public void Build(IWorkflowBuilder<MedicineWorkFlowData> builder)
    {
        builder
            .UseDefaultErrorBehavior(WorkflowErrorHandling.Terminate)
            .StartWith<GetMedicineInfoStep>()
                .Input(step => step.MedicineId, data => data.MedicineId)
                .Output(data => data.ApprovalNeeded, step => step.ApprovalNeeded)
                .Output(data => data.ApprovalUserEmail, step => step.ApprovalUserEmail)
            .If(data => data.ApprovalNeeded)  // If approval is needed, proceed with approval request and check approval
                .Do(x => x.StartWith<ApprovalRequestStep>()
                    .Input(step => step.ApprovalUserEmail, data => data.ApprovalUserEmail)
                    .Then<GetApprovalStep>()
                    .Output(data => data.IsApproved, step => step.IsApproved)
                .If(data => !data.IsApproved)  // Terminate workflow if approval is not granted
                    .Do(s =>
                        s.Then(context => Console.WriteLine("[] Approval not granted."))
                         .EndWorkflow()  // Terminate the workflow
                         .Then(context => Console.WriteLine("[] Workflow Ended due to no approval."))
                    ))
            .Then<AddToInventoryStep>()  // Add to inventory whether approval is needed or not
                .Input(step => step.MedicineId, data => data.MedicineId)
                .Input(step => step.Quantity, data => data.Quantity)
                .EndWorkflow()
                .Then((context) => Console.WriteLine("[] Workflow Ended."));
    }
}
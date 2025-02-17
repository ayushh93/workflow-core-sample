using ACMS.WebApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace ACMS.WebApi.Workflows.DocumentApproval.Steps
{
    public class DocumentCreationStep(HttpClient httpClient) : StepBodyAsync
    {
        // Input properties
        public string Title { get; set; }
        public string CreatorName { get; set; }
        public int DocumentId { get; set; }  // DocumentId will be returned from the API
        public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
        {
            /*            // Create a DocumentDto object
                        var documentDto = new DocumentDto
                        {
                            Title = Title,
                            CreatorName = CreatorName
                        };
                        // Serialize DocumentDto to JSON
                        var jsonContent = JsonConvert.SerializeObject(documentDto);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        // Make an HTTP POST request to the API
                        var response = await httpClient.PostAsync("http://localhost:5283/api/documents/create", content);

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            // Assuming the response contains the DocumentId in the body as JSON
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var responseObject = JsonConvert.DeserializeObject<int>(responseContent);

                            // Set the DocumentId to be used in the next steps
                            DocumentId = responseObject;
                        }
                        else
                        {
                            // Handle error or log it
                            throw new Exception("Error creating document. " + response.ReasonPhrase);
                        }*/
            Console.WriteLine("Document Created and sent for approval!");

            return ExecutionResult.Next();
        }
    }
}

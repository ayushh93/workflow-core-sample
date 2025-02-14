using ACMS.WebApi.Entities;
using ACMS.WebApi.EntityFrameworkCore;
using ACMS.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ACMS.WebApi.Extensions
{
    public static class DocumentEndpointExtension
    {
        public static IEndpointRouteBuilder MapDocumentEndPoints(this IEndpointRouteBuilder endpoints)
        {
            // Get all documents
           endpoints.MapGet("/api/documents", async (EmployeeContext context) =>
            {
                var documents = await context.Documents.ToListAsync();
                return Results.Ok(documents);
            });

            // Create a new document
            endpoints.MapPost("/api/documents/create", async (EmployeeContext context, DocumentDto request) =>
            {
                var document = new Document
                {
                    Title = request.Title,
                    CreatorName = request.CreatorName
                };

                context.Documents.Add(document);
                await context.SaveChangesAsync();

                return Results.Ok(document);
            });

            // Get document by ID
            endpoints.MapGet("/api/documents/{documentId}", async (EmployeeContext context, int documentId) =>
            {
                var document = await context.Documents.FirstOrDefaultAsync(d => d.Id == documentId);
                if (document == null) return Results.NotFound();

                return Results.Ok(document);
            });
            return endpoints;
        }
    }
}

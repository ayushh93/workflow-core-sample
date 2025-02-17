using ACMS.WebApi.Entities;
using ACMS.WebApi.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ACMS.WebApi.Extensions
{
    public static class MedicineEndpointExtension
    {
        public static IEndpointRouteBuilder MapMedicineEndPoints(this IEndpointRouteBuilder endpoints)
        {
            // Get all medicines
            endpoints.MapGet("/api/medicines", async (EmployeeContext context) =>
            {
                var medicines = await context.Medicines.ToListAsync();
                return Results.Ok(medicines);
            });

            // Create a new medicine
            endpoints.MapPost("/api/medicines/create", async (EmployeeContext context, Medicine request) =>
            {
                context.Medicines.Add(request);
                await context.SaveChangesAsync();
                return Results.Created($"/api/medicines/{request.Id}", request);
            });

            // Add stock to an existing medicine
            endpoints.MapPost("/api/medicines/{medicineId}/addtostock", async (EmployeeContext context, int medicineId, int quantity) =>
            {
                var medicine = await context.Medicines.FindAsync(medicineId);
                if (medicine == null) return Results.NotFound();

                medicine.InventoryCount += quantity; // Add the specified quantity to stock
                await context.SaveChangesAsync();
                return Results.Ok(medicine);
            });

            // Get medicine by ID
            endpoints.MapGet("/api/medicines/{medicineId}", async (EmployeeContext context, int medicineId) =>
            {
                var medicine = await context.Medicines.FindAsync(medicineId);
                if (medicine == null) return Results.NotFound();

                return Results.Ok(medicine);
            });

            return endpoints;
        }
    }
} 
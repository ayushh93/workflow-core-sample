using ACMS.WebApi.Entities;
using ACMS.WebApi.EntityFrameworkCore;
using Bogus;
using System.Collections.Generic;

namespace ACMS.WebApi.Utilities;

public static class DataSeeder
{
    public static void Seed(EmployeeContext dbContext)
    {
        // Check if the database is already seeded
        if (!dbContext.Employees.Any())
        {
            // Use Bogus to generate fake data
            var faker = new Faker<Employee>()
                .RuleFor(e => e.Name, f => f.Name.FullName())
                .RuleFor(e => e.Department, f => f.Commerce.Department())
                .RuleFor(e => e.Branch, f => f.PickRandom("Branch A", "Branch B", "Branch C"));

            var employees = faker.Generate(50);  // Generate 50 fake employees

            dbContext.Employees.AddRange(employees);
            dbContext.SaveChanges();  // Save the generated data to the database
        }

        // Check if the database is already seeded for Medicines
        if (!dbContext.Medicines.Any())
        {
            // List of predefined medicine names
            var medicineNames = new List<string>
            {
                "Aspirin",
                "Ibuprofen",
                "Paracetamol",
                "Amoxicillin",
                "Metformin",
                "Lisinopril",
                "Simvastatin",
                "Omeprazole",
                "Atorvastatin",
                "Levothyroxine"
            };

            // Use Bogus to generate fake data for Medicines
            var medicineFaker = new Faker<Medicine>()
                .RuleFor(m => m.Name, f => f.PickRandom(medicineNames)) // Use predefined medicine names
                .RuleFor(m => m.ApprovalNeeded, f => f.Random.Bool())
                .RuleFor(m => m.ApprovalUserEmail, "ayushkarmacharya220@gmail.com")
                .RuleFor(m => m.InventoryCount, f => f.Random.Int(1, 100)); // Random inventory count

            var medicines = medicineFaker.Generate(30);  // Generate 10 fake medicines

            dbContext.Medicines.AddRange(medicines);
            dbContext.SaveChanges();  // Save the generated data to the database
        }
    }
}

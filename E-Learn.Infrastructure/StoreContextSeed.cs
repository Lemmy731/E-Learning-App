using E_Learn.Entity;
using E_Learn.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;





namespace E_Learn.Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task Seed(StoreContext storeContext, ILogger logger)
        {
            try
            {
                if (!storeContext.Category.Any())
                {
                    var categoryData = File.ReadAllText("../E-Learn.Infrastructure/SeedData/Categories.json");
                    var category = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    foreach (var item in category)
                    {
                        storeContext.Category.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
                if (!storeContext.Courses.Any())
                {
                    var courseData = File.ReadAllText("../E-Learn.Infrastructure/SeedData/course.json");
                    var courses = JsonSerializer.Deserialize<List<Course>>(courseData);

                    foreach (var item in courses)
                    {
                        storeContext.Courses.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
                if (!storeContext.Learnings.Any())
                {
                    var learningData = File.ReadAllText("../E-Learn.Infrastructure/SeedData/Learnings.json");
                    var learning = JsonSerializer.Deserialize<List<Learning>>(learningData);

                    foreach (var item in learning)
                    {
                        storeContext.Learnings.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
                if (!storeContext.Requirements.Any())
                {
                    var requirementData = File.ReadAllText("../E-Learn.Infrastructure/SeedData/Requirement.json");
                    var requirement = JsonSerializer.Deserialize<List<Requirement>>(requirementData);

                    foreach (var item in requirement)
                    {
                        storeContext.Requirements.Add(item);
                    }
                    await storeContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }

        }
    }
}

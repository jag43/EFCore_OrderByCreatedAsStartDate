using IncorrectSyntaxNearTheKeywordAS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    class Program
    {
        const string connectionString =
                      @"Server=(localdb)\MSSQLLocalDB;Database=Junk";

        static async Task Main(string[] args)
        {
            var context = CreateContext(connectionString);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            await new TestDataInserter(context).InsertTestDataAsync();

            var queryHandler = new QueryHandler(context);

            var result1 = await queryHandler.ExecuteQueryOrderByCountAsync();
            Console.WriteLine($"result1: {result1.Count} records.");

            var result2 = await queryHandler.ExecuteQueryOrderByCreatedAsync();
            Console.WriteLine($"result2: {result2.Count} records.");

            Console.ReadLine();
        }

        private static DataContext CreateContext(string connectionString)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                       .UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}

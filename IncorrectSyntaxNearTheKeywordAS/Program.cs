using IncorrectSyntaxNearTheKeywordAS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    class Program
    {
        const string connectionString =
                      @"Server=(localdb)\MSSQLLocalDB;Database=Junk";

        static async Task Main(string[] args)
        {
            Log("Creating context...");
            var context = CreateContext(connectionString);
            Log("Context created");
            Log();
            Log("Starting EnsureDeleted call...");
            context.Database.EnsureDeleted();
            Log("EnsureDeleted call done.");
            Log();
            Log("Starting EnsureCreated call...");
            context.Database.EnsureCreated();
            Log("EnsureCreated call done.");

            Log("Inserting test data...");
            await new TestDataInserter(context).InsertTestDataAsync();
            Log("Test data inserted.");
            Log();

            var queryHandler = new QueryHandler(context);

            Log("Starting query1 OrderByCount");
            var result1 = await queryHandler.ExecuteQueryOrderByCountAsync();
            Console.WriteLine($"Query1 done. result: {result1.Count} records.");

            Log("Starting query2 OrderByCreated");
            try
            {
                var result2 = await queryHandler.ExecuteQueryOrderByCreatedAsync();
                Console.WriteLine($"result2: {result2.Count} records.");
            }
            catch(SqlException ex)
            {
                Log($"Error: {ex.Message}");
                Log(ex.StackTrace);
                Log();
            }

            Console.ReadLine();
        }

        private static DataContext CreateContext(string connectionString)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                       .UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }

        private static void Log(string s = null)
        {
            if (s != null)
                Console.WriteLine(s);
            else
                Console.WriteLine();
        }
    }
}

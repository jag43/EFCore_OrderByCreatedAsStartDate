using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    public class Application
    {
        private readonly DataContext _context;

        public Application(
            DataContext context)
        {
            _context = context;
        }

        public async Task StartAsync()
        {
            Console.WriteLine("Creating context...");
            Console.WriteLine("Context created");

            Console.WriteLine("Starting EnsureDeleted call...");
            _context.Database.EnsureDeleted();
            Console.WriteLine("EnsureDeleted call done.");

            Console.WriteLine("Starting EnsureCreated call...");
            _context.Database.EnsureCreated();
            Console.WriteLine("EnsureCreated call done.");

            Console.WriteLine("Inserting test data...");
            await new TestDataInserter(_context).InsertTestDataAsync();
            Console.WriteLine("Test data inserted.");

            var queryHandler = new QueryHandler(_context);

            Console.WriteLine("Starting query1 OrderByCount");
            var result1 = await queryHandler.ExecuteQueryOrderByCountAsync();
            Console.WriteLine($"Query1 done. result: {result1.Count} records.");

            Console.WriteLine("Starting query2 OrderByCreated");
            try
            {
                var result2 = await queryHandler.ExecuteQueryOrderByCreatedAsync();
                Console.WriteLine($"result2: {result2.Count} records.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error occurred when calling ExecuteQueryOrderByCreatedAsync().");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.ReadLine();
        }
    }
}

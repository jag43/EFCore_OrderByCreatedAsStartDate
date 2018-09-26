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

            Console.WriteLine("Hello World!");
        }

        private static DataContext CreateContext(string connectionString)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                       .UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }

        
    }
}

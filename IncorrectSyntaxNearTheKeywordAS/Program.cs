using IncorrectSyntaxNearTheKeywordAS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    class Program
    {
        const string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=Junk";

        static async Task Main(string[] args)
        {
            IServiceProvider services = GetServiceProvider();

            var app = new Application(
                services.GetRequiredService<DataContext>());

            await app.StartAsync();
        }

        private static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddLogging(configure => configure.AddDebug());

            services.AddDbContext<DataContext>(optionsBuilder => 
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            return services.BuildServiceProvider();
        }
    }
}

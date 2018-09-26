using IncorrectSyntaxNearTheKeywordAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    public class TestDataInserter
    {
        private readonly DataContext context;

        public TestDataInserter(DataContext context)
        {
            this.context = context;
        }

        public async Task InsertTestDataAsync()
        {
            await InsertJobsAsync();
            await InsertTeamsAsync();
            await InsertJobTeamsAsync();
            await InsertOperatorsAsync();
            await InsertCallsAsync();
        }

        private async Task InsertJobsAsync()
        {
            Job[] jobs = new[]
            {
                new Job()
                {
                    Name = "Test job 1"
                }
            };

            foreach (var job in jobs)
            {
                context.Jobs.Add(job);
            }

            await context.SaveChangesAsync();
        }

        private async Task InsertTeamsAsync()
        {
            throw new NotImplementedException();
        }

       
        private async Task InsertJobTeamsAsync()
        {
            throw new NotImplementedException();
        }

        private async Task InsertOperatorsAsync()
        {
            throw new NotImplementedException();
        }

        private async Task InsertCallsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

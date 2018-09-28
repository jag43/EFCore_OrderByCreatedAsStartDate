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
        private readonly DataContext _context;

        public TestDataInserter(DataContext context)
        {
            _context = context;
        }

        public async Task InsertTestDataAsync()
        {
            var job = new TelemJob
            {
                Reference = "Test Job",
                Status = Models.Enums.TelemJobStatus.InProgress,
                RecordsRequired = 100,
                ScheduledEndDate = DateTimeOffset.Now.AddDays(14)
            };
            _context.TelemJobs.Add(job);

            var jobSupplier = new TelemJobSupplier
            {
                RecordsRequired = 100,
                Job = job
            };
            _context.TelemJobSuppliers.Add(jobSupplier);

            var stack = new TelemCallStack
            {
                JobSupplier = jobSupplier
            };
            _context.TelemCallStacks.Add(stack);

            var calls = new TelemCall[]
            {
                new TelemCall
                {
                    CallStack = stack,
                    Status = Models.Enums.TelemCallStatus.Completed,
                    CallStart = DateTimeOffset.Now,
                    CallEnd = DateTimeOffset.Now.AddMinutes(20),
                    ScriptDelivered = true,
                    AcceptDisclaimer = true,
                    CallAttempts = 1
                }
            };
            await _context.TelemCalls.AddRangeAsync(calls);

            await _context.SaveChangesAsync();
        }
    }
}

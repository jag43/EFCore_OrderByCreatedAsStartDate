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
            var org = new Organisation
            {
                Id = "ORG"
            };
            _context.Organisations.Add(org);

            var admin = new ApplicationUser
            {
                UserName = "james.gibson@example.com",
                OrganisationId = org.Id,
            };
            _context.ApplicationUsers.Add(admin);

            var agency = new TelemAgency
            {
                Name = "Test Agency",
                Organisation = org
            };
            _context.TelemAgencies.Add(agency);

            var team = new Team()
            {
                Organisation = org
            };
            _context.Teams.Add(team);

            var teamApplicationUser = new TeamApplicationUser
            {
                Team = team,
                User = admin
            };
            _context.TeamApplicationUsers.Add(teamApplicationUser);

            var job = new TelemJob
            {
                Reference = "Test Job",
                Status = Models.Enums.TelemJobStatus.InProgress,
                RecordsRequired = 100,
                ScheduledEndDate = DateTimeOffset.Now.AddDays(14),
                CreatedBy = admin
            };
            _context.TelemJobs.Add(job);

            var jobSupplier = new TelemJobSupplier
            {
                RecordsRequired = 100,
                Agency = agency,
                Job = job,
                CreatedBy = admin
            };
            _context.TelemJobSuppliers.Add(jobSupplier);

            var stack = new TelemCallStack
            {
                Issued = DateTimeOffset.Now.AddDays(1),
                JobSupplier = jobSupplier,
                Team = team,
                IssuedBy = admin,
                CreatedBy = admin
            };
            _context.TelemCallStacks.Add(stack);

            var calls = new TelemCall[]
            {
                new TelemCall
                {
                    CallStack = stack,
                    Operator = admin,
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

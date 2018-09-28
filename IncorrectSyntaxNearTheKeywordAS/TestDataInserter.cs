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
                Id = "ORG",
                Name = "Organisation",
                Description = "Test Organisation",
                WebsiteUrl = "www.example.com"
            };
            _context.Organisations.Add(org);

            var admin = new ApplicationUser
            {
                UserName = "james.gibson@example.com",
                Email = "james.gibson@example.com",
                FirstName = "James",
                LastName = "Gibson",
                OrganisationId = org.Id,
                NormalizedUserName = "james.gibson@example.com",
                NormalizedEmail = "james.gibson@example.com",
                EmailConfirmed = true,
                Password = "",
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                ConcurrencyStamp = "cc0781-a785-4101-bf75-9a4618f96d90",
                LockoutEnd = null,
                Disabled = false
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
                Manager = admin,
                Organisation = org,
                Reference = "Test Team",
                Notes = null
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

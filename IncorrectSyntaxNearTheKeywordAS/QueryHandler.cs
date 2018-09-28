using IncorrectSyntaxNearTheKeywordAS.Models;
using IncorrectSyntaxNearTheKeywordAS.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS
{
    public class QueryHandler
    {
        private readonly DataContext _context;

        public QueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<QueryResultModel>> ExecuteQueryOrderByCountAsync()
        {
            // works
            return await CallsByOperatorQuery().OrderBy(r => r.CallsMade).ToListAsync();
        }

        public async Task<ICollection<QueryResultModel>> ExecuteQueryOrderByCreatedAsync()
        {
            // errors
            return await CallsByOperatorQuery().OrderBy(r => r.StartDate).ToListAsync();
        }

        private IQueryable<QueryResultModel> CallsByOperatorQuery()
        {
            IQueryable<TelemCall> queryStart = _context.TelemCalls;

            var query = queryStart.GroupBy(c => new
            {
                JobId = c.CallStack.JobSupplier.Job.Id,
                JobReference = c.CallStack.JobSupplier.Job.Reference,
                JobStatus = c.CallStack.JobSupplier.Job.Status,
                TeamId = c.CallStack.TeamId,
                TeamReference = c.CallStack.Team.Reference,
                OperatorId = c.OperatorId,
                OperatorUserName = c.Operator.UserName,
                AgencyId = c.CallStack.JobSupplier.AgencyId,
                StartDate = c.CallStack.JobSupplier.Created,
                EndDate = c.CallStack.JobSupplier.Job.ScheduledEndDate,
                RecordsRequired = c.CallStack.JobSupplier.RecordsRequired
            })
            .Select(g => new QueryResultModel()
            {
                JobId = g.Key.JobId,
                JobReference = g.Key.JobReference,
                JobStatus = g.Key.JobStatus,
                TeamId = g.Key.TeamId,
                TeamReference = g.Key.TeamReference,
                OperatorId = g.Key.OperatorId,
                OperatorUserName = g.Key.OperatorUserName,
                AgencyId = g.Key.AgencyId,
                StartDate = g.Key.StartDate,
                EndDate = g.Key.EndDate,
                RecordsRequired = g.Key.RecordsRequired,
                CallsMade = g.Count()
            })
            ;

            return query;
        }
    }
}

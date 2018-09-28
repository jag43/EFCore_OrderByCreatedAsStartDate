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
            return await CallsByOperatorQuery().OrderBy(r => r.JobId).ToListAsync();
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
                StartDate = c.CallStack.JobSupplier.Created
            })
            .Select(g => new QueryResultModel()
            {
                JobId = g.Key.JobId,
                StartDate = g.Key.StartDate,
                CallsMade = g.Count()
            });

            return query;
        }
    }
}

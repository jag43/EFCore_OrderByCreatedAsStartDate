using IncorrectSyntaxNearTheKeywordAS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.ViewModels
{
    public class QueryResultModel
    {
        public Guid OperatorId { get; set; }
        public string OperatorUserName { get; set; }
        public int JobId { get; set; }
        public string JobReference { get; set; }
        public TelemJobStatus JobStatus { get; set; }
        public int AgencyId { get; set; }
        public Guid TeamId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public int RecordsRequired { get; set; }
        public int CallsMade { get; set; }
    }
}

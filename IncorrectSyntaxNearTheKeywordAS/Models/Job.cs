using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Created { get; set; }

        public ICollection<JobTeam> JobTeams { get; set; } 
    }
}

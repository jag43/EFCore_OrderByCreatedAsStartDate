using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class JobTeam
    {
        public int JobId { get; set; }
        public int TeamId { get; set; }

        public Job Job { get; set; }
        public Team Team { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class Call
    {
        public int Id { get; set; }
        public CallStatus Status { get; set; }
        public int JobId { get; set; }
        public int OperatorId { get; set; }

        public Job Job { get; set; }
        public Operator Operator { get; set; }
    }
}

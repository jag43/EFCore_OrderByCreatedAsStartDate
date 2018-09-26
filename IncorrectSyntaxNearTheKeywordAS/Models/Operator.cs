using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class Operator
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string UserName { get; set; }

        public Team Team { get; set; }
    }
}

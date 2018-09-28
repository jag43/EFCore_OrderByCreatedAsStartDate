using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class TelemJobSupplier
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int RecordsRequired { get; set; }
        public bool JobFrozen { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Notes { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public TelemJob Job { get; set; }
        public ICollection<TelemCallStack> CallStacks { get; set; }
    }
}

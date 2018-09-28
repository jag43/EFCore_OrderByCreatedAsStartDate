using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class TelemCallStack
    {
        public int Id { get; set; }
        public int JobSupplierId { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public TelemJobSupplier JobSupplier { get; set; }
        public ICollection<TelemCall> Calls { get; set; }
    }
}

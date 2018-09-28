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
        public Guid TeamId { get; set; }
        public int JobSupplierId { get; set; }
        public DateTimeOffset Created { get; set; }
        public Guid CreatedById { get; set; }
        public DateTimeOffset? Issued { get; set; }
        public Guid? IssuedById { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public Team Team { get; set; }
        public TelemJobSupplier JobSupplier { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public ApplicationUser IssuedBy { get; set; }
        public ICollection<TelemCall> Calls { get; set; }
    }
}

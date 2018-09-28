using IncorrectSyntaxNearTheKeywordAS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class TelemJob
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public TelemJobStatus Status { get; set; }
        public int RecordsRequired { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? ScheduledEndDate { get; set; }
        public DateTimeOffset? Closed { get; set; }
        public string PrivateNotes { get; set; }
        public string PublicNotes { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public ICollection<TelemJobSupplier> Suppliers { get; set; }
    }
}

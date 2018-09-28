using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class TelemAgency
    {
        public int Id { get; set; }
        public string OrganisationId { get; set; }
        public string Name { get; set; }
        public bool Archived { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public Organisation Organisation { get; set; }
        public ICollection<TelemJobSupplier> TelemJobs { get; set; }
    }
}

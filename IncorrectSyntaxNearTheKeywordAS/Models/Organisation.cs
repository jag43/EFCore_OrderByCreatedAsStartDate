using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class Organisation
    {
        public string Id { get; set; }
        public byte[] RowVersion { get; set; }

        // Navigation
        public ICollection<ApplicationUser> Users { get; set; }

        public ICollection<Team> Teams { get; set; }

        public ICollection<TelemAgency> Agencies { get; set; }
    }
}

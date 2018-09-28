using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string OrganisationId { get; set; }
        public string UserName { get; set; }

        // Navigation
        public Organisation Organisation { get; set; }
        public ICollection<TeamApplicationUser> Teams { get; set; }
    }
}

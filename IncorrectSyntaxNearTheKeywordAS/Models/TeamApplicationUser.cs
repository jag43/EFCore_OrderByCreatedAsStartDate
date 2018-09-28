using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class TeamApplicationUser
    {
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }

        // Navigation
        public Team Team { get; set; }

        public ApplicationUser User { get; set; }
    }
}

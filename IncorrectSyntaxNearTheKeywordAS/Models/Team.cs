﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public Guid? ManagerId { get; set; }
        public string OrganisationId { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public Organisation Organisation { get; set; }

        public ApplicationUser Manager { get; set; }
        public ICollection<TeamApplicationUser> Members { get; set; }
    }
}
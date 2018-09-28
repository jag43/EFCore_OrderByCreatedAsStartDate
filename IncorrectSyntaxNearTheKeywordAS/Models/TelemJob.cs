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

        // Navigation
        public ICollection<TelemJobSupplier> Suppliers { get; set; }
    }
}

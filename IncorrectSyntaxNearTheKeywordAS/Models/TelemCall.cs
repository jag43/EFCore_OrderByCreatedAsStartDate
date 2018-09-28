using IncorrectSyntaxNearTheKeywordAS.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectSyntaxNearTheKeywordAS.Models
{
    public class TelemCall
    {
        public int Id { get; set; }
        public int CallStackId { get; set; }

        // Navigation
        public TelemCallStack CallStack { get; set; }
    }
}

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
        public DateTimeOffset CallStart { get; set; }
        public DateTimeOffset? CallEnd { get; set; }
        public int? CallDurationSeconds { get; set; }
        public int CallAttempts { get; set; }
        public TelemCallStatus Status { get; set; }
        public DateTimeOffset? CallbackTime { get; set; }
        public bool ScriptDelivered { get; set; }
        public bool AcceptDisclaimer { get; set; }
        public string SubscriberComments { get; set; }
        public string Notes { get; set; }
        public byte[] Timestamp { get; set; }

        // Navigation
        public TelemCallStack CallStack { get; set; }
    }
}

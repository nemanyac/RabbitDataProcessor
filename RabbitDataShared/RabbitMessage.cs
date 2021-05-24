using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitDataShared
{
    public class RabbitMessage
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp = DateTime.UtcNow;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Recievers
{
    public class POP3EmailMessage
    {
        public long MsgNumber { get; set; }
        public long MsgSize { get; set; }
        public bool MsgRecieved { get; set; }
        public string MsgContent { get; set; }
    }
}

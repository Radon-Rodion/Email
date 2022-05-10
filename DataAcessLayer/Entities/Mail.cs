using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Entities
{
    public class Mail
    {
        public long Id { get; set; }
        public long MsgSize { get; set; }
        public bool MsgRecieved { get; set; }
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Theme { get; set; }
        public string MsgContent { get; set; }
    }
}

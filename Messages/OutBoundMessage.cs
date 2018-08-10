using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class OutBoundMessage : IMessage
    {
        public string OrderNum { get; set; }
        public string PatientName { get; set; }
        public string TestType { get; set; }
        public string MsgType { get; set; }
        public string ErrorDescription { get; set; }
    }
}

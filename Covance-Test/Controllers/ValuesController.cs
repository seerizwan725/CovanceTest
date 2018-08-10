using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Covance_Test.Controllers
{
    public class ValuesController : ApiController
    {
        
        // POST api/values
        public string Post([FromBody]JObject jsonData)
        {
            var inboundmsg = jsonData.ToObject<Messages.InboundMessage>();
            var outboundstring = new Messages.OutBoundMessage
            {
                PatientName = inboundmsg.PatientName,
                OrderNum = inboundmsg.OrderNum.ToString(),
                TestType = inboundmsg.TestType
            };
            var outboundjson = JsonConvert.SerializeObject(outboundstring);
            return outboundjson;
        }

        
    }
}

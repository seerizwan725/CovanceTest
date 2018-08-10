using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class InBoundMessageManager
    {
        public string PushNormalMessage(Messages.IMessage input)
        {
            const string url = "http://localhost:62852/api/values";
            var response = string.Empty;
            try
            {
                using (var client = new WebClient()) //WebClient  
                {
                    client.Headers.Add("Content-Type:application/json"); //Content-Type  
                    client.Headers.Add("Accept:application/json");
                    var serializedData = JsonConvert.SerializeObject(input);
                    response = client.UploadString(url, serializedData);
                }

                return response;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }

        public string PushErrorMessage(Messages.IMessage input)
        {
            try
            {
                SendToDb(input);
                return "The following error description saved in DB : - " + input.ErrorDescription;
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }

        private static void SendToDb(Messages.IMessage input)
        {
            var storagedatatable = new DataTable();
            storagedatatable.Columns.Add("Id", typeof(int));
            storagedatatable.Columns.Add("ErrorDescription", typeof(string));
            if (input.MsgType == "ERR")
            {
                //Save to the table
                var newrow = storagedatatable.NewRow();
                newrow["ErrorDescription"] = input.ErrorDescription;
                storagedatatable.Rows.Add(newrow);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.Helpers
{
    public class ReturnMessage
    {
        public int msgCode { get; set; } = 1;
        public string msg { get; set; } = "Saved Successfully";
      
        public ReturnMessage() { }
        public ReturnMessage(int _msgcode, string _msg)
        {
            msgCode = _msgcode;
            msg = _msg;

        }

        public string returnMessage(object pagedresult)
        {
            var json = JsonConvert.SerializeObject(new
            {

                data = pagedresult,
                message = this
            }); 

            return json;

        }
    }
}

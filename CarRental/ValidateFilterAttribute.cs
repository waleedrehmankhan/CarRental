using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental
{
    public class ValidateFilterAttribute: ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            dynamic message = new JObject();
            if (!context.ModelState.IsValid)
            {
                var totallist = context.ModelState.ToList();
                var entrylist = context.ModelState.Values.ToList();
                foreach (var item in totallist)
                {
                    var errors = item.Value.Errors.ToList();
                    var errorarray = new JArray();
                    for (int i = 0; i < errors.Count; i++)
                    {
                        JValue error = new JValue(errors[i].ErrorMessage);

                        errorarray.Add(error);
                    }

                    message.Add(item.Key, errorarray);
                }
                dynamic returnMessage = new JObject();
                returnMessage.msgCode = -2;
                returnMessage.msg = message;


                context.Result = new OkObjectResult(new
                {

                    data = new { items = new { },message=returnMessage },
                     
                });
            }
        }
    }
}

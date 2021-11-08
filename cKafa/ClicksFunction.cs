using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using cKafa.Data;
using cKafa.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
//using Microsoft.Azure.Functions.Worker;
//using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace cKafa
{
    public static class ClicksFunction
    {
        [FunctionName("AddClicks")]
        public static async Task<IActionResult> AddClicks(
       [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "AddClicks({time1},{time2},{misclicks1},{misclicks2},{window_width})")] HttpRequest req
            , int time1
            , int time2
            , int? misclicks1
            , int? misclicks2
            , int? window_width
      )
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                //Clicks data = JsonConvert.DeserializeObject<Clicks>(requestBody);


                ClicksDataContext db = ClicksDataContext.GetCurrent();

                Clicks c = new Clicks();

                c.uid = Guid.NewGuid();
                c.create_date = DateTime.Now;
                c.time1 = time1;
                c.time2 = time2;
                c.misclicks1 = misclicks1 ?? 0;
                c.misclicks2 = misclicks2 ?? 0;
                c.window_width = window_width ?? 0;
                db.Clicks.Add(c);

                await db.SaveChangesAsync();

                return new OkResult();
            }
            catch (Exception ex)
            {
                throw new Exception("Error add clicks", ex);
            }
        }
    }
}

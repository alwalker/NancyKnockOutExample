using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyKnockOutExample.API
{
    public class MainModule : Nancy.NancyModule
    {
        public MainModule() {
            this.After.AddItemToEndOfPipeline(x => x.Response.WithHeader("Access-Control-Allow-Origin", "*"));

            Get["/people"] = _ =>
            {
                try
                {
                    using (var context = new Context())
                    {
                        return JsonConvert.SerializeObject(context.People.Include("Pets"));
                    }
                }
                catch
                {
                    return HttpStatusCode.InternalServerError;
                }
            };
            Get["/people/{id}"] = _ =>
            {
                return 200;
            };
            Post["/people/{id}"] = _ =>
            {
                return 200;
            };
        }
    }
}

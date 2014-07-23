using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;

namespace NancyKnockOutExample.API
{
    public class MainModule : Nancy.NancyModule
    {
        public MainModule()
        {
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
            Post["/people"] = _ =>
            {
                try
                {
                    using (var context = new Context())
                    {
                        var updated = this.Bind<Person>();
                        context.People.Attach(updated);
                        context.Entry(updated).State = System.Data.Entity.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
                catch
                {
                    return HttpStatusCode.InternalServerError;
                }

                return HttpStatusCode.OK;
            };
            Put["/people"] = _ =>
            {
                try
                {
                    using (var context = new Context())
                    {
                        var newPerson = this.Bind<Person>();
                        context.People.Add(newPerson);
                        context.SaveChanges();
                    }

                    return HttpStatusCode.OK;
                }
                catch
                {
                    return HttpStatusCode.InternalServerError;
                }
            };
        }
    }
}

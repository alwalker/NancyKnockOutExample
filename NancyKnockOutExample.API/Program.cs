using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NancyKnockOutExample.API
{
    class Program
    {
        public static void Main(String[] args)
        {
            var config = new HostConfiguration();
            config.UrlReservations = new UrlReservations() { CreateAutomatically = true };
            using (var host = new NancyHost(config, new Uri("http://localhost:9000")))
            {
                Console.WriteLine("Starting...");
                host.Start();
                Console.WriteLine("Started! Press enter to quit.");
                Console.Read();
            }
        }
    }
}

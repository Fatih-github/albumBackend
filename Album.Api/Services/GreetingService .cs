using System;
using System.Net;

namespace Album.Api
{
    public class GreetingService 
    {
        public string helloFunction(string name) {
            
            if(name != null && name != "" && !string.IsNullOrWhiteSpace(name))
                return "Hello " + name + "from " + Dns.GetHostName();
            return "Hello World" + "from " + Dns.GetHostName();
        }
    }
}

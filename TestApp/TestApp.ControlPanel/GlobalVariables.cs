using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace TestApp.ControlPanel
{
    public static class GlobalVariables
    {
        public static HttpClient WebClient = new HttpClient();

        static GlobalVariables()
        {
            WebClient.BaseAddress = new Uri("http://localhost:33254/api/");
            WebClient.DefaultRequestHeaders.Clear();
            WebClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}

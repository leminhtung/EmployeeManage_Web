using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApplication1
{
    public static class GlobalVariables
    {
        public static HttpClient Webapiclient = new HttpClient();

        static GlobalVariables()  
        {
            Webapiclient.BaseAddress = new Uri("http://localhost:52520/api/");
            Webapiclient.DefaultRequestHeaders.Clear();
            Webapiclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
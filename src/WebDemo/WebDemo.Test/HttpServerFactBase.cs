using System;
using System.Net.Http;
using System.Web.Http;
using WebDemo;

namespace WebDemo.Test
{
    public class HttpServerFactBase
    {
        protected readonly HttpServer server = new HttpServer();
        protected readonly HttpClient client ;
        public HttpServerFactBase()
        {
            InitConfiguration.Init(server.Configuration);
            client = new HttpClient(server)
            {
                BaseAddress = new Uri("https://www.baidu.com")
            };
        }
    }
}

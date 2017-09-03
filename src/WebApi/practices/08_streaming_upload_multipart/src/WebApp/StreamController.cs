using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApp
{
    public class StreamController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> CreateMultipart()
        {
            #region Please implement the method

            /*
             * Please implement the method to retrive all the files data.
             */

            if (!Request.Content.IsMimeMultipartContent()) return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                var responseContent = new List<string>();
                var provider = await Request.Content.ReadAsMultipartAsync();
                foreach (var content in provider.Contents)
                {
                    var fileName = content.Headers.ContentDisposition.FileName;
                    var fileStream = content.ReadAsStringAsync();

                    responseContent.Add($"{fileName}:{fileStream}");
                }

                return Request.CreateResponse(HttpStatusCode.OK, responseContent);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

            #endregion
        }
    }
}
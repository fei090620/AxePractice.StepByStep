using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDemo.Service;

namespace WebDemo.Controllers
{
    public class MessageController : ApiController
    {
        private readonly MessageContentService messageContentService;

        public MessageController(MessageContentService messageContentService)
        {
            this.messageContentService = messageContentService;
        }

        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(messageContentService.GetMessageContent());
            return response;
        }
    }
}

using Xunit;

namespace WebDemo.Test
{
    public class MessageControllerFact : HttpServerFactBase
    {
        [Fact]
        public async void should_get_hello_world_when_call_message_api()
        {
            var response = client.GetAsync("/MessageController");
            var message = await response.Result.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", message);
        }
    }
}

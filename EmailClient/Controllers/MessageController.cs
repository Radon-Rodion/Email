using Microsoft.AspNetCore.Mvc;

namespace EmailClient.Controllers
{
    [Route("/mess")]
    public class MessageController : Controller
    {
        [HttpGet("in")]
        public async Task<object> GetIncomingMessagesAsync()
        {

        }

        [HttpGet("out")]
        public async Task<object> GetOutgoingMessagesAsync()
        {

        }

        [HttpGet("saved")]
        public async Task<object> GetSavedMessagesAsync()
        {

        }

        [HttpGet("in/{id}")]
        public async Task<object> GetIncomingMessageAsync(string id)
        {

        }

        [HttpGet("out/{id}")]
        public async Task<object> GetOutgoingMessageAsync(string id)
        {

        }

        [HttpGet("saved/{id}")]
        public async Task<object> GetSavedMessageAsync(string id)
        {

        }

        [HttpDelete("in/{id}")]
        public async Task<object> DeleteIncomingMessageAsync(string id)
        {

        }

        [HttpDelete("out/{id}")]
        public async Task<object> DeleteOutgoingMessageAsync(string id)
        {

        }

        [HttpDelete("saved/{id}")]
        public async Task<object> DeleteSavedMessageAsync(string id)
        {

        }

        [HttpPost("send")]
        public async Task<object> SendMessageAsync()
        {

        }
    }
}

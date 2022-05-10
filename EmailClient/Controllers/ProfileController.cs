using Microsoft.AspNetCore.Mvc;

namespace EmailClient.Controllers
{
    [Route("/users")]
    public class ProfileController : Controller
    {
        [HttpGet]
        public async Task<object> GetUsersAsync()
        {
            
        }

        [HttpGet("/{id}")]
        public async Task<object> GetUserInfoAsync(string id)
        {

        }

        [HttpPut("/{id}")]
        public async Task<object> PutUserInfoAsync(string id)
        {

        }

        [HttpDelete("/{id}")]
        public async Task<object> DeleteUserInfoAsync(string id)
        {

        }
    }
}

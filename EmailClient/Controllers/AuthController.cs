using Microsoft.AspNetCore.Mvc;

namespace EmailClient.Controllers
{
    [Route("/auth")]
    public class AuthController : Controller
    {

        [HttpPost("sign-in")]
         public async Task<object> SignIn(string email, string password)
        {

        }

        [HttpPost("sign-up")]
        public async Task<object> SignUp(string email, string password)
        {
            
        }

        
    }
}

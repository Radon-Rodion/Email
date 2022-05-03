using Microsoft.AspNetCore.Mvc;

namespace EmailClient.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}

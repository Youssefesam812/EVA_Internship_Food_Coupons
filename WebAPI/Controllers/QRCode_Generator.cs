using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QRCode_Generator : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Index(int EMP_ID)
        //{
        //    return View();
        //}








    }
}

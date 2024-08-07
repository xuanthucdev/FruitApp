using Microsoft.AspNetCore.Mvc;
using ProjectDotNet.Models;
using ProjectDotNet.Services;

namespace ProjectDotNet.Controllers
{
    public class UserController : Controller

    {

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string name, string password)
        {
            var user = _userService.LoginAsync(name, password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.ErrorMassage = "that bai";
                return View("Login");
            }
        }
        [HttpPost]
        [Route("register")]

        public async Task<IActionResult> Register(User user)
        {
            var res = await _userService.RegisterAsync(user);
            if (res) {
               return  RedirectToAction("Login");
            }
            else
            {
                ViewBag.ErrorMessage = "khong dc";
                return View("Register");
            }
        }        

    }
}

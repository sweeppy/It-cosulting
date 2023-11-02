using Final_project.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Final_project.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private readonly HttpClient _httpClient;

        public AccountController(SignInManager<User> SIM, UserManager<User> UM, HttpClient httpClient)
        {
            _signInManager = SIM;
            _userManager = UM;
            _httpClient = httpClient;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new UserLogin
            {
                ReturnUrl = string.IsNullOrEmpty(returnUrl)
                    ? "~/"
                    : returnUrl
            };

            return View(model);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin model)
        {
            if(ModelState.IsValid == false)
            {
                ModelState.AddModelError(string.Empty, "Incorrect input");
                return View(model);
            }
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            string url = @"api/Auth/login";

            var baseAddress = new Uri("https://localhost:7105");
            _httpClient.BaseAddress = baseAddress;

            var response = await _httpClient.PostAsync(url, jsonContent);
            if (response.IsSuccessStatusCode)
            {
                var loginResult = await _signInManager.PasswordSignInAsync(model.LoginProp,
                    model.Password,
                    false,
                    lockoutOnFailure: false);
                if (loginResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError(String.Empty, "User is not found");
                return View(model);
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}

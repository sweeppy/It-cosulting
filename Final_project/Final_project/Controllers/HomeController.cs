using Final_project.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Final_project.Interfaces;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Final_project.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IGetAdminOptionsInfoFromDBAsync _Iadmin;
        HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IGetAdminOptionsInfoFromDBAsync Iadmin, HttpClient httpClient)
        {
            _logger = logger;
            _Iadmin = Iadmin;
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            HomeMainModel model = new HomeMainModel();
            model.BlogSection = await _Iadmin.GetBlogSectionInfo();
            model.ContactSection = await _Iadmin.GetContactSectionInfo();
            model.FooterSection = await _Iadmin.GetFooterSectionInfo();
            model.HeaderSection = await _Iadmin.GetHeaderSectionInfo();
            model.ProjectsSection = await _Iadmin.GetProjectsSectionInfo();
            model.ServicesSection = await _Iadmin.GetServicesSectionInfo();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Application letter)
        {
            string url = @"https://localhost:7105/api/Application/SendMessageAPI";

            var jsonLetter = new StringContent(JsonConvert.SerializeObject(letter), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, jsonLetter);

            if(response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "The letter was sent successfully";
                return RedirectToAction("Index");
            }
            else
            {
                //Handling an error in the API
                var responseContent = await response.Content.ReadAsStringAsync();
                var errorsArray = JsonConvert.DeserializeObject<string[]>(responseContent);//des json errors
                var formattedErrors = string.Join(Environment.NewLine, errorsArray);//add a new line between errors
                TempData["ErrorMessage"] = formattedErrors;


                return RedirectToAction("Index");
            }


        }
    }
}
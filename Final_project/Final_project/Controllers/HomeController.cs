using Final_project.Models;
using Microsoft.AspNetCore.Mvc;
using Final_project.Interfaces;
using System.Diagnostics;

namespace Final_project.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IGetAdminOptionsInfoFromDBAsync _Iadmin;

        public HomeController(ILogger<HomeController> logger, IGetAdminOptionsInfoFromDBAsync Iadmin)
        {
            _logger = logger;
            _Iadmin = Iadmin;
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
    }
}
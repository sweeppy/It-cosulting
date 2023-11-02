using Microsoft.AspNetCore.Mvc;
using Final_project.Interfaces;
using Final_project.Models.AdminOptions;

namespace Final_project.Controllers
{
    public class BlogsInformationController : Controller
    {
        IGetAdminOptionsInfoFromDBAsync _Iadmin;
        public BlogsInformationController(IGetAdminOptionsInfoFromDBAsync Iadmin)
        {
            _Iadmin = Iadmin;
        }
        public async Task<IActionResult> Index(int id)
        {
            BlogSection model = await _Iadmin.GetBlogById(id);

            return View(model);
        }
    }
}

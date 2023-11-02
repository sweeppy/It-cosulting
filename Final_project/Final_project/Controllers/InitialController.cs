using Final_project.Authorization;
using Final_project.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_project.Controllers
{
    public class InitialController : Controller
    {
        UserContext _userContext;
        UserManager<User> _userManager;
        RoleManager<IdentityRole> _roleManager;


        public InitialController(UserContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userContext = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        /// <summary>
        /// Create admin and user roles, add admin account
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> CreateRoles()
        {
            if (!_userContext.Roles.Any(w => w.Name == Roles.Admin.Name))
            {
                await _roleManager.CreateAsync(Roles.Admin);//create roles in DB
                await _roleManager.CreateAsync(Roles.User);

                User user = new User { UserName = "Admin" };
                var ResultOfCreate = await _userManager.CreateAsync(user, "_aA12345");//create admin account login:admin,
                                                                                      //                     password:_aA12345
                if (ResultOfCreate.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Admin.Name);//add account admin role admin
                }

                await _userContext.SaveChangesAsync();//save
            }
            return Redirect("/Home/Index");//switch controller
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace Final_project.Authorization
{
    public static class Roles
    {
        public static IdentityRole Admin = new IdentityRole { Name = "Admin" };

        public static IdentityRole User = new IdentityRole { Name = "User" };
    }
}

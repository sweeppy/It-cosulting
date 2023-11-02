using System.ComponentModel.DataAnnotations;

namespace Final_project.Authorization
{
    public class UserLogin
    {
        [Required(ErrorMessage ="Enter your login"), MaxLength(20, ErrorMessage ="Your login is too long")]
        public string LoginProp { get; set; }

        [Required(ErrorMessage = "Enter your password"), DataType(DataType.Password),
            MaxLength(20, ErrorMessage ="Your password is too long")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

    }
}

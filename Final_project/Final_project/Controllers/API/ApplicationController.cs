using Final_project.Data;
using Final_project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.RegularExpressions;

namespace Final_project.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        ApplicationsDbContext _context;

        public ApplicationController(ApplicationsDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Check input and save it into DB
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost, Route("SendMessageAPI")]
        public async Task<IActionResult> SendMessageAPI(Application form)
        {
            List<string> formErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(form.FullName))//Check name input
            {
                formErrors.Add("Please enter a name.");
            }
            if (string.IsNullOrWhiteSpace(form.Email))//Check email input
            {
                formErrors.Add("Please enter your email address.");
            }
            else if (!IsValidEmail(form.Email))//Check email valid
            {
                formErrors.Add("Please enter a valid email address.");
            }
            if(string.IsNullOrWhiteSpace(form.Message))//Check message input
            {
                formErrors.Add("Please enter a message.");
            }///Chech input
            
            if(formErrors.Count > 0)
            {
                return new BadRequestObjectResult(formErrors);
            }
            else//Add the letter into DB
            {
                await _context.Applications.AddAsync(form);
                await _context.SaveChangesAsync();
                return new OkObjectResult("Your letter was sent successfully!");
            }
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^\s*([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)?\s*$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
    }
}

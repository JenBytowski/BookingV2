using BookinV2.Data.Entities.IdentityEntities;
using BookinV2API.Models;
using BookinV2API.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookinV2API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this._signInManager = signInManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var response = new ApiResponse<object>();

            if (model == null)
            {
                response.Errors.Add("Register model is null");
                response.IsSucceeded = false;
                return this.BadRequest(response);
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                response.Errors.Add("Username not specified");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                response.Errors.Add("Password not specified");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                response.Errors.Add("Email not specified");
            }

            if (response.Errors.Any())
            {
                response.IsSucceeded = false;
                return this.BadRequest(response);
            }

            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await this._userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                response.IsSucceeded = true;
                response.Response = null;
                return this.Ok(response);
            }

            response.IsSucceeded = false;
            foreach (var error in result.Errors)
            {
                response.Errors.Add(error.Description);
            }

            response.IsSucceeded = false;
            return this.BadRequest(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var response = new ApiResponse<object>();

            if (model == null)
            {
                response.Errors.Add("Login model is null");
                response.IsSucceeded = false;
                return this.BadRequest(response);
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                response.Errors.Add("Username not specified");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                response.Errors.Add("Password not specified");
            }

            if (response.Errors.Any())
            {
                response.IsSucceeded = false;
                return this.BadRequest(response);
            }

            var result = await this._signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                response.IsSucceeded = true;
                response.Response = null;
                return this.Ok(response);
            }

            response.IsSucceeded = false;
            response.Errors.Add("Invalid login attempt.");
            return this.Unauthorized(response);
        }
    }
}

using BookinV2.Data.Entities.IdentityEntities;
using BookinV2API.Models;
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
            if (model == null)
            {
                return this.BadRequest("Register model is null");
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                return this.BadRequest("Username not specified");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return this.BadRequest("Password not specified");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                return this.BadRequest("Email not specified");
            }

            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await this._userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return this.BadRequest("Register model is null");
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                return this.BadRequest("Username not specified");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                return this.BadRequest("Password not specified");
            }

            var result = await this._signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.Unauthorized();
        }
    }
}

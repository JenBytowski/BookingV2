using BookinV2.Data.Entities.IdentityEntities;
using BookinV2API.Errors;
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
            var errorResponse = new ErrorResponse();

            if (model == null)
            {
                errorResponse.Errors.Add(ErrorMessages.RegisterModelNull);
                return this.BadRequest(errorResponse);
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                errorResponse.Errors.Add(ErrorMessages.UsernameNotSpecified);
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                errorResponse.Errors.Add(ErrorMessages.PasswordNotSpecified);
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                errorResponse.Errors.Add(ErrorMessages.EmailNotSpecified);
            }

            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await this._userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(errorResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var errorResponse = new ErrorResponse();

            if (model == null)
            {
                errorResponse.Errors.Add(ErrorMessages.LoginModelNull);
                return this.BadRequest(errorResponse);
            }

            if (string.IsNullOrEmpty(model.Username))
            {
                errorResponse.Errors.Add(ErrorMessages.UsernameNotSpecified);
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                errorResponse.Errors.Add(ErrorMessages.PasswordNotSpecified);
            }

            var result = await this._signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            errorResponse.Errors.Add(ErrorMessages.InvalidLoginAttempt);
            return this.Unauthorized(errorResponse);
        }
    }
}

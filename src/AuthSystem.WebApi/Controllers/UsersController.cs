using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using AuthSystem.WebApi.Data.Entities.Identity;
using AuthSystem.WebApi.Models.Identity;
using AuthSystem.WebApi.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace AuthSystem.WebApi.Controllers
{
    /// <summary>
    /// Controller responsible for handling identity operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="identityService">The identity service.</param>
        /// <param name="logger">The logger service.</param>
        public UsersController(IIdentityService identityService, ILogger<UsersController> logger)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Creates a new user account.
        /// </summary>
        /// <param name="form">The data required to create the new user account.</param>
        /// <returns>The result of the account creation operation.</returns>
        [HttpPost("register")]
        public async Task<Results<ValidationProblem, Ok>> CreateAccount([FromBody] CreateAccountForm form)
        {
            return await _identityService.CreateAccountAsync(form);
        }

        /// <summary>
        /// Signs into an existing user account.
        /// </summary>
        /// <param name="form">The data required to sign into the user account.</param>
        /// <returns>The result of the sign-in operation.</returns>
        [HttpPost("login")]
        public async Task<Results<ValidationProblem, Ok<UserSessionModel>>> SignIn([FromBody] SignInForm form)
        {
            return await _identityService.SignInAsync(form);
        }


        /// <summary>
        /// Refreshes the current user's access token.
        /// </summary>
        /// <param name="form">The data required to refresh the access token.</param>
        /// <returns>The result of refreshing the access token.</returns>
        [HttpPost("refresh-token")]
        public async Task<Results<ValidationProblem, Ok<UserSessionModel>>> RefreshToken([FromBody] RefreshTokenForm form)
        {
            return await _identityService.RefreshTokenAsync(form);
        }

        /// <summary>
        /// Signs out the current user.
        /// </summary>
        /// <param name="form">The data required to sign out the user.</param>
        /// <returns>The result of the sign-out operation.</returns>
        [Authorize]
        [HttpPost("logout")]
        public async Task<Results<ValidationProblem, Ok>> SignOut([FromBody] SignOutForm form)
        {
            return await _identityService.SignOutAsync(form);
        }

        /// <summary>
        /// Retrieves the current user's profile.
        /// </summary>
        /// <returns>The result of retrieving the user's profile.</returns>
        [Authorize]
        [HttpGet("me")]
        public async Task<Results<UnauthorizedHttpResult, Ok<UserProfileModel>>> GetUserProfile()
        {
            return await _identityService.GetUserProfileAsync();
        }
    }
}

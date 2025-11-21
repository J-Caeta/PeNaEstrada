using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PeNaEstrada.Infrastructure.Identity;
using PeNaEstrada.Server.DTOs;
using PeNaEstrada.Server.Services;

namespace PeNaEstrada.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            TokenService tokenService)
        {   _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return Ok(new { message = "Usuário registrado com sucesso!" });
            }
                return BadRequest(result.Errors);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
         
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
           
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                var token = _tokenService.GenerateToken(user!);

                return Ok(new
                {
                    token = token,
                    message = "Login bem-sucedido!"
                });
            }
            return Unauthorized(new { message = "Usuário ou senha inválidos" });      
        }
    }
}

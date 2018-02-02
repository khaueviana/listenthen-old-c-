using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListenThen.Infra.CrossCutting.Identity.Models.AccountViewModel;
using ListenThen.Infra.CrossCutting.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using ListenThen.Domain.Interfaces.Mail;

namespace ListenThen.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());

            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(x => x.Description).ToList());

            var adminRole = await _roleManager.FindByNameAsync("Admin");

            if (adminRole == null)
            {
                adminRole = new IdentityRole("Admin");
                await _roleManager.CreateAsync(adminRole);

                await _roleManager.AddClaimAsync(adminRole, new Claim("ListenThen", "Get"));
            }

            if (!await _userManager.IsInRoleAsync(user, adminRole.Name))
                await _userManager.AddToRoleAsync(user, adminRole.Name);

            return Ok();
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] AccountRegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());

            var user = await _userManager.FindByEmailAsync(model.Email);

            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return BadRequest(result.Errors.Select(x => x.Description).ToList());

            return Ok();
        }

        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var config = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json")
                                 .Build();

                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                    if (result.Succeeded)
                    {
                        var userRoles = new List<string>();
                        var userClaims = new List<Claim>();

                        if (_userManager.SupportsUserRole)
                        {
                            var roles = await _userManager.GetRolesAsync(user);
                            foreach (var roleName in roles)
                            {
                                if (_roleManager.SupportsRoleClaims)
                                {
                                    userRoles.Add(roleName);

                                    var role = await _roleManager.FindByNameAsync(roleName);

                                    if (role != null)
                                    {
                                        userClaims.AddRange(await _roleManager.GetClaimsAsync(role));
                                    }
                                }
                            }
                        }

                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(config["Jwt:Iss"],
                          config["Jwt:Aud"],
                          claims.Union(userClaims),
                          expires: DateTime.Now.AddMinutes(30),
                          signingCredentials: creds);

                        token.Payload.Add("roles", userRoles);


                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
            }

            return BadRequest("Could not create token");
        }

        [HttpPost("GeneratePasswordResetToken")]
        public async Task<IActionResult> GeneratePasswordResetToken([FromBody] RequestPasswordResetTokenViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var code = _userManager.GeneratePasswordResetTokenAsync(user);

                await _emailSender.SendEmailAsync("khaueviana@gmail.com", "Reset Token", string.Concat(code.Result, "&", user.Id));

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("PasswordResetToken")]
        public async Task<IActionResult> PasswordResetToken([FromBody] PasswordResetTokenViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values.SelectMany(v => v.Errors).Select(modelError => modelError.ErrorMessage).ToList());

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user != null)
            {
                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

                if (result.Succeeded)
                    return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("Claims")]
        public object Claims()
        {
            return User.Claims.Select(c =>
            new
            {
                c.Type,
                c.Value
            });
        }
    }
}
using BookingApp.Models.Models;
using BookingApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingApp.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<SiteUser> _userManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        public AuthController(UserManager<SiteUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(ClaimTypes.Name, user.Email)
                };
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nagyonhosszutitkoskodhelye"));
                var token = new JwtSecurityToken(
                issuer: "http://www.security.org", audience: "http://www.security.org",
                claims: claim, expires: DateTime.Now.AddMinutes(60),
                signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPut]
        public async Task<IActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            var user = new SiteUser
            {
                Email = model.Email,
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                //PhotoContentType = model.PhotoContentType,
                //PhotoData = model.PhotoData
            };
            await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, "Customer");
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserInfos()
        {
            //var asd=new Claim(ClaimTypes.Name, user.Email)
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            if (user != null)
            {
                return Ok(new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    //PhotoData = user.PhotoData,
                    //PhotoContentType = user.PhotoContentType,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteMyself()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateProfile([FromBody] RegisterViewModel model)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            //user.PhotoContentType = model.PhotoContentType;
            //user.PhotoData = model.PhotoData;
            await _userManager.UpdateAsync(user);
            return Ok();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Facebook([FromBody] SocialToken token)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://graph.facebook.com");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"me?fields=first_name,last_name,picture,email&access_token={token.Token}");
            var result = await response.Content.ReadFromJsonAsync<FbModel>();
            if (result != null)
            {
                SiteUser user = new SiteUser
                {
                    FirstName = result.last_name,
                    LastName = result.first_name,
                    Email = result.email,
                    UserName = result.email,
                };
                return await SocialAuth(user);
            }
            return Unauthorized();
        }


        private async Task<IActionResult> SocialAuth(SiteUser user)
        {
            if (_userManager.Users.FirstOrDefault(t => t.Email == user.Email) == null)
            {
                var res = await _userManager.CreateAsync(user);
                if (res.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");
                }
            }
            var appuser = await _userManager.FindByEmailAsync(user.Email);
            if (appuser != null)
            {
                var claim = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.Sub, appuser.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, appuser.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, appuser.UserName)
                };
                foreach (var role in await _userManager.GetRolesAsync(appuser))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }

                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                ("nagyonhosszutitkoskodhelye"));
                var token = new JwtSecurityToken(
                issuer: "http://www.security.org", audience: "http://www.security.org",
                claims: claim, expires: DateTime.Now.AddMinutes(60),
                signingCredentials: new SigningCredentials
                (signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });

            }
            return Unauthorized();

        }
    }
}

using PerfectPoliciesApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PerfectPoliciesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Setup (Dependency Injection)
            // Access to appsettings.json (Iconfiguration)
            // Access to database (PerfectPoliciesContext)
        public IConfiguration _config;
        public PerfectPoliciesContext _context;

        public AuthController(IConfiguration config, PerfectPoliciesContext context)
        {
            _config = config;
            _context = context;
        }

        /// <summary>
        /// Gets a user from the database
        /// </summary>
        /// <param name="userName">The username for the user</param>
        /// <param name="passWord">The password for the user</param>
        /// <returns>The user if it was found</returns>
        private UserInfo GetUser(string userName, string passWord)
        {
            UserInfo user = _context.Users.FirstOrDefault(u => u.Username == userName);
            //UserInfo user2 = _context.Users.Where(u => u.Username == userName).FirstOrDefault();

            // if a matching user was found
            if(user != null && user.Password.Equals(passWord))
            {
                // Return the user
                return user;
            }
            return null;
        }


        // POST api/<AuthController>
        /// <summary>
        /// Creates a new user. Will fail if a user already exists with the specified username
        /// </summary>
        /// <param name="userInfo">The User to create</param>
        [HttpPost]
        public ActionResult<UserInfo> Post(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }
            //try
            //{
            // UserInfo user = _context.Users.FirstOrDefault(u => u.Username == userInfo.Username);
            if (_context.Users.FirstOrDefault(u => u.Username == userInfo.Username) != null)
            {
                // If this succeeds, that means the username already exists
                return BadRequest("Username already exists");
            }
            
            //}
            //catch (Exception)
            //{ /* Username DOESN'T exist */ }

            _context.Users.Add(userInfo);
            _context.SaveChanges();

            return CreatedAtAction("Post", userInfo);
        }

        // Generate a Token for an existing user
        /// <summary>
        /// Generates a Token for an existing user
        /// </summary>
        /// <param name="_userData">The userdata to create a token with</param>
        /// <returns>The token via JSON</returns>
        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {
            
            if (_userData != null && _userData.Username != null && _userData.Password != null)
            {
                // retrieve the user for these credentials
                var user = GetUser(_userData.Username, _userData.Password);

                // If we have a user that matches the credentials
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    // JWT Subject
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    // JWT ID
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    // JWT Date/Time
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    // JWT User ID
                    new Claim("Id", user.UserInfoID.ToString()),
                    // JWT UserName
                    new Claim("UserName", user.Username)
                   };

                    // Generate a new key based on the Key we created and stored in appsettings.json
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    // use the generated key to generate new Signing Credentials
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Generate a new token based on all of the details generated so far
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        // How long the JWT will be valid for
                        expires: DateTime.UtcNow.AddDays(2),
                        signingCredentials: signIn);

                    // Return the Token via JSON
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

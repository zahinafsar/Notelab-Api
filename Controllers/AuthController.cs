using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using notelab.app.DbContext;
using notelab.app.Model;
using notelab.Helper;
using notelab.Model;

namespace notelab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController:ControllerBase
    {
        public DataContext _db;
        public Authentication _auth;
        public EmailSender _emailSender;
        public AuthController(DataContext dataContext, Authentication authentication, EmailSender emailSender){
            _db = dataContext;
            _auth = authentication;
            _emailSender = emailSender;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult GetToken([FromBody] Users cred)
        {
            var user =_db.users.Where(a=>a.Username == cred.Username).FirstOrDefault();
            if (user == null)
            {
                return NotFound("User not found");
            }
            if (user.Password == cred.Password)
            {
                var token = _auth.GenAuthToken(user.Id.ToString());
                Response.Cookies.Append("session", token, new CookieOptions
                {
                    HttpOnly = true
                });
                var message = new Message(new string[] { "afsarzahin@gmail.com" }, "NotLab", "Succesfully logged in a new device.");
                _emailSender.SendEmail(message);
                return Ok("logged in");
            }
            else
            {
                return BadRequest("Wrong password!");
            }
        }
        [HttpPost("register")]
        public ActionResult<Users> AddUser([FromBody] Users user)
        {
            var exist =_db.users.Where(a=>a.Username == user.Username).FirstOrDefault();
            if (exist == null)
            {
                _db.users.Add(user);
                _db.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest("User Already Exist!");
            }
        }
    }
}
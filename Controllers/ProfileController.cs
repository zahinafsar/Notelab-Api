using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notelab.app.DbContext;
using notelab.app.Model;
using notelab.Helper;

namespace notelab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController:ControllerBase
    {
        public DataContext _db;
        public Authentication _auth;
        public ProfileController(DataContext database, Authentication authentication)
        {
            _db = database;
            _auth = authentication;
        }
        [HttpGet]
        public ActionResult<Users> GetProfile()
        {
            var token = Request.Cookies["session"];
            if (token == null)
            {
                return Unauthorized("Login first!");
            }
            try
            {
                var user = _auth.TokenVerify(token);
                return Ok(_db.users.Where(a => a.Id.ToString() == user.Issuer).Include(u => u.Notes).FirstOrDefault());
            }
            catch (System.Exception)
            {
                return Unauthorized("Sesson Timeout. Please login again!");
            }
        }
    }
}
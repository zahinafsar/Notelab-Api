using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notelab.app.DbContext;
using notelab.app.Model;
using notelab.Helper;

namespace notelab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        public DataContext _db;
        public Authentication _auth;
        public NoteController(DataContext dataContext, Authentication authentication){
            _db = dataContext;
            _auth = authentication;
        }

        [HttpGet]
        public List<Notes> GetAllNote()
        {
            return _db.notes.ToList();
        }
        [HttpGet("{id}")]
        public Notes GetSingleNote(int id)
        {
            return _db.notes.Find(id);
        }
        [HttpPost]
        public ActionResult AddUsersNotes([FromBody] Notes note)
        {
            var jwtToken = Request.Cookies["session"];
            if (jwtToken == null)
            {
                return Unauthorized("login first");
            }
            var res =_auth.TokenVerify(jwtToken);
            var id = res.Issuer;
            var user = _db.users.Where(a=>a.Id.ToString() == id).Include(u => u.Notes).FirstOrDefault();
            if (user == null)
            {
                return NotFound("No User Found!");
            }
            else
            {
                try
                {
                    user.Notes.Add(note);
                    _db.SaveChanges();
                    return Ok($"Note Added to User '{user.Username}'");
                }
                catch (System.Exception e)
                {
                    return BadRequest(e.StackTrace);
                }
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using notelab.app.DbContext;
using notelab.app.Model;

namespace notelab.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController:ControllerBase
    {
        public DataContext _db;
        public UserController(DataContext database)
        {
            _db = database;
        }
        [HttpGet]
        public ActionResult<Users> GetAllUser()
        {
            return Ok(_db.users.Select(f => new {f.Id, f.Username}).ToList());
        }
        [HttpGet("{id}")]
        public ActionResult<Users> GetSingleUser(int id)
        {
            return Ok(_db.users.Where(a => a.Id == id).Include(u => u.Notes).Select(f => new {f.Id, f.Username, f.Notes}).FirstOrDefault());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArticleApis.Models;
using IntakeApp.Repository;
using IntakeApp.Repository.Models;
using IntakeApp.Classes;

namespace ArticleApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Dal dal = new Dal();
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntakeApp.Repository.Models.User>>> GetUsers()
        {
            using (var contextt = new b2d_4_4_intakeapp_dbDbContext())
            {
                return await contextt.Users.ToListAsync();
            }

        }

        // POST
        [HttpPost]
        public void InsertNewUser([FromBody]int userid, string firstname, string lastname, string username, string password, int points)
        {
            IntakeApp.Classes.User user = new IntakeApp.Classes.User(userid, firstname, lastname, username, password, points);
            dal.AddNewUser(user);

        }
    }
}

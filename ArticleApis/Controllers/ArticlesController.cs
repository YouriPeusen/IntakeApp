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

namespace ArticleApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleContext _context;

        public ArticlesController(ArticleContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles()
        {
            using (var contextt = new b2d_4_4_intakeapp_dbDbContext())
            {
                return await contextt.Articles.ToListAsync();
            }
            
        }


       
    }
}

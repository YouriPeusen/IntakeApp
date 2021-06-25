using ArticleApis.Models;
using IntakeApp.Classes;
using IntakeApp.Repository;
using IntakeApp.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleApis.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Dal dal = new Dal();

        private readonly CategoryContext _context;

        public CategoryController(CategoryContext context)
        {
            _context = context;
        }

        // POST
        [HttpPost]
        public void InsertNewCategory(IntakeApp.Classes.Category category)
        {
            dal.AddNewCategory(category);

        }
    }
}

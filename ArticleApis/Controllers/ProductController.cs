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
    public class ProductController : ControllerBase
    {
        Dal dal = new Dal();

        private readonly ProductContext _context;

        public ProductController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntakeApp.Repository.Models.Product>>> GetProducts()
        {
            using (var contextt = new b2d_4_4_intakeapp_dbDbContext())
            {
                return await contextt.Products.ToListAsync();
            }

        }

        // POST
        [HttpPost]
        public void InsertNewProduct(IntakeApp.Classes.Product product)
        {
            SqlConnection con = dal.databaseConnect();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Products values (@productId, @categoryId, @productName, @productDescription)";
            cmd.Parameters.AddWithValue("@productId", product.getId());
            cmd.Parameters.AddWithValue("@categoryId", product.getCategory());
            cmd.Parameters.AddWithValue("@productName", product.getName());
            cmd.Parameters.AddWithValue("@productDescription", product.getDescription());
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
           

        }
    }
}

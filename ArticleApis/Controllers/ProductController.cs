using ArticleApis.Models;
using IntakeApp.Classes;
using IntakeApp.Repository;
using IntakeApp.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

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

        //POST
        [HttpPost]
        public void InsertNewProduct([FromBody] object product)
        {
            String json = product.ToString();
            System.Diagnostics.Debug.WriteLine(json);
            var deserializedProduct = new List<IntakeApp.Classes.Product>();
            deserializedProduct = JsonConvert.DeserializeObject<List<IntakeApp.Classes.Product>>(json);
            

            foreach(IntakeApp.Classes.Product productInList in deserializedProduct)
            {
                dal.AddNewProduct(productInList);
            }
        }

        // Get external products
        [HttpGet]
        [Route("ProductAPI")]
        public async Task<IActionResult> GetAllProductsFromAPI()
        {
            var client = new RestClient($"https://ruilwinkelvaalsproductbeheer.azurewebsites.net/api/Product/GetAllProducts");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                //var content = JsonConvert.DeserializeObject<JToken>(response.Content);
                this.InsertNewProduct(response.Content);

            }

            return Ok();
        }

    }
}

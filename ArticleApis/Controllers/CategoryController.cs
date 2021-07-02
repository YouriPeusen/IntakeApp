using ArticleApis.Models;
using IntakeApp.Classes;
using IntakeApp.Repository;
using IntakeApp.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;
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

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesFromAPI()
        {
            var client = new RestClient($"https://ruilwinkelvaalsproductbeheer.azurewebsites.net/api/Category/GetAllCategoriesWithPoints");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                
                this.InsertNewCategory(response.Content);

            }

            return Ok();
        }

        //POST
        [HttpPost]
        public void InsertNewCategory([FromBody] object category)
        {
            String json = category.ToString();
            System.Diagnostics.Debug.WriteLine(json);
            var deserializedCategory = new List<IntakeApp.Classes.Category>();
            deserializedCategory = JsonConvert.DeserializeObject<List<IntakeApp.Classes.Category>>(json);


            foreach (IntakeApp.Classes.Category categoryInList in deserializedCategory)
            {
                dal.AddNewCategory(categoryInList);
            }

        }
    }
}

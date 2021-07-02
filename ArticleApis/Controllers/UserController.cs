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
using Newtonsoft.Json;
using RestSharp;

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

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesFromAPI()
        {
            var client = new RestClient($"https://testeppie20210607124001.azurewebsites.net/AspNetUser/All");
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {

                this.InsertNewUser(response.Content);

            }

            return Ok();
        }

        //POST
        [HttpPost]
        public void InsertNewUser([FromBody] object user)
        {
            String json = user.ToString();
            var deserializedUser = new List<IntakeApp.Classes.User>();
            deserializedUser = JsonConvert.DeserializeObject<List<IntakeApp.Classes.User>>(json);


            foreach (IntakeApp.Classes.User userInList in deserializedUser)
            {
                dal.AddNewUser(userInList);
            }

        }
    }
}

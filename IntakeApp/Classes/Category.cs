using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntakeApp.Classes
{
	public class Category
    {
        [JsonProperty("categoryID")]
        public int categoryId { get; set; }
        [JsonProperty("categorienaam")]
        public string categoryName { get; set; }
        [JsonProperty("punten")]
        public int categoryPoints { get; set; }

        public Category(int _categoryId, string _categoryName, int _categoryPoints)
        {
            this.categoryId = _categoryId;
            this.categoryName = _categoryName;
            this.categoryPoints = _categoryPoints;
        }

        public int GetCategoryId()
        {
            return categoryId;
        }

        public string GetCategoryName()
        {
            return categoryName;
        }

        public int GetPoints()
        {
            return categoryPoints;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntakeApp.Classes
{
	public class Category
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntakeApp.Classes
{
	public class Product
    {
        public int productId { get; set; }
        public int categoryId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }


        public Product(int _productId, int _categoryId, string _productName, string _productDescription)
        {
            this.productId = _productId;
            this.categoryId = _categoryId;
            this.productName = _productName;
            this.productDescription = _productDescription;
        }

        public int getId()
        {
            return this.productId;
        }
        public int getCategory()
        {
            return this.categoryId;
        }

        public string getName()
        {
            return this.productName;
        }

        public string getDescription()
        {
            return this.productDescription;
        }

        public static implicit operator Product(Article v)
        {
            throw new NotImplementedException();
        }
    }
}

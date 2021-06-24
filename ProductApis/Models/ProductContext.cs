using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntakeApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApis.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {

        }
        public List<Product> GetProducts => Products.ToList();

    }
}

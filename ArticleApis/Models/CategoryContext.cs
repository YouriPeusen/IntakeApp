using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntakeApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApis.Models
{
    public class CategoryContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public CategoryContext(DbContextOptions<CategoryContext> options)
            : base(options)
        {

        }
        public List<Category> GetCategories => Categories.ToList();

    }
}

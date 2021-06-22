using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntakeApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApis.Models
{
    public class ArticleContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public ArticleContext(DbContextOptions<ArticleContext> options)
            : base(options)
        {

        }
        public List<Article> GetArticles => Articles.ToList();
   
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntakeApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleApis.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {

        }
        public List<User> GetUsers => Users.ToList();

    }
}

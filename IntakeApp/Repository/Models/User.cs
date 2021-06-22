using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IntakeApp.Repository.Models
{
    public partial class User
    {
        public User()
        {
            ArticleProviders = new HashSet<Article>();
            ArticleRenters = new HashSet<Article>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public int UserPoints { get; set; }

        [InverseProperty(nameof(Article.Provider))]
        public virtual ICollection<Article> ArticleProviders { get; set; }
        [InverseProperty(nameof(Article.Renter))]
        public virtual ICollection<Article> ArticleRenters { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IntakeApp.Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("CategoryID")]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        [Column(TypeName = "text")]
        public string ProductDescription { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [InverseProperty(nameof(Article.Product))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IntakeApp.Repository.Models
{
    public partial class Statuss
    {
        public Statuss()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        [Column("StatusID")]
        public int StatusId { get; set; }
        [Required]
        [StringLength(50)]
        public string StatusName { get; set; }

        [InverseProperty(nameof(Article.Status))]
        public virtual ICollection<Article> Articles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace IntakeApp.Repository.Models
{
    public partial class Article
    {
        [Key]
        [Column("ArticleID")]
        public int ArticleId { get; set; }
        [Column("ProductID")]
        public int ProductId { get; set; }
        [Column("StatusID")]
        public int StatusId { get; set; }
        [Column("ProviderID")]
        public int ProviderId { get; set; }
        [Column("RenterID")]
        public int RenterId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? LoanDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }
        [StringLength(50)]
        public string Image { get; set; }
        [Column(TypeName = "text")]
        public string Commentary { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Articles")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(ProviderId))]
        [InverseProperty(nameof(User.ArticleProviders))]
        public virtual User Provider { get; set; }
        [ForeignKey(nameof(RenterId))]
        [InverseProperty(nameof(User.ArticleRenters))]
        public virtual User Renter { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(Statuss.Articles))]
        public virtual Statuss Status { get; set; }
    }
}

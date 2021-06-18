using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntakeApp.Models
{
    public class Article
    {

        public int ArticleID { get; set; }
        //public int productId { get; set; }
        //public int statusId { get; set; }
        //public int providerId { get; set; }
        //public int renterId { get; set; }
        //public DateTime loanDate { get; set; }
        //public DateTime expirationDate { get; set; }
        //public string image { get; set; }
        //public string commentary { get; set; }

        // public Article(int _articleId,
        //  int _productId,
        // int _statusId,
        //  int _providerId,
        // int _renterId,
        //  DateTime _loanDate,
        // DateTime _expirationDate,
        // string _image,
        //string _commentary)
        // {
        //     this.articleId = _articleId;
        //     this.productId = _productId;
        //     this.statusId = _statusId;
        //     this.providerId = _providerId;
        //     this.renterId = _renterId;
        //     this.loanDate = _loanDate;
        //     this.expirationDate = _expirationDate;
        //     this.image = _image;
        //     this.commentary = _commentary;
        // }

        public int getId()
        {
            return ArticleID;
        }

        // public int getProductId()
        // {
        //     return productId;
        // }

        // public int getStatusId()
        // {
        //     return statusId;
        // }

        // public int getProviderId()
        // {
        //     return providerId;
        // }

        // public string getImage()
        // {
        //     return image;
        // }

        // public string getCommentary()
        // {
        //     return commentary;
        // }
    }
}

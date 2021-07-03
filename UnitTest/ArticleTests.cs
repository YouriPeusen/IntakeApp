using IntakeApp.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTest
{
	class ArticleTests
	{
		[TestMethod]
		public void TestFailing()
		{
			Assert.IsFalse(true);
		}

		[TestMethod]
		public void TestCreate()
		{
			Article article = new Article(1, 3, 5, 7, 9, new DateTime(2021, 6, 15), new DateTime(2021, 7, 15), "ImageString.jpg", "Comment");
			Assert.AreEqual(1, article.getId());
			Assert.AreEqual(3, article.getProductId());
			Assert.AreEqual(5, article.getStatusId());
			Assert.AreEqual(7, article.getProviderId());
			Assert.AreEqual(9, article.getRenterId());
		}
	}
}

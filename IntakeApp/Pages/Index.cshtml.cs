﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntakeApp.Classes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IntakeApp.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;

		[BindProperty]
		public string Product { get; set; }
		public List<SelectListItem> Ddl_Products { get; } = new List<SelectListItem> { };

		public string Category { get; set; }
		public List<SelectListItem> Ddl_Category { get; } = new List<SelectListItem> { };

		public string Status { get; set; }
		public List<SelectListItem> Ddl_Status { get; } = new List<SelectListItem> { };

		Dal dal = new Dal();

		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}
		public void OnGet()
		{
			//Populatie Productdropdownlist
			List<Product> products = dal.GetProducts();
			foreach(Product product in products)
			{
				Ddl_Products.Add(new SelectListItem { Value = product.getProductId().ToString(), Text = product.getName() });
			}
			List<Category> Categories = dal.GetCategorys();
			foreach (Category Category in Categories)
			{
				Ddl_Category.Add(new SelectListItem { Value = Category.GetCategoryId().ToString(), Text = Category.GetCategoryName() });
			}
			List<Status> Statusses = dal.GetStatus();
			foreach (Status Status in Statusses)
			{
				Ddl_Status.Add(new SelectListItem { Value = Status.GetStatusId().ToString(), Text = Status.GetStatusName() });
			}

		public void OnPostInput()
		{

			// maak object van class op basis van invoerveld, doe vervolgens code uit dal daarmee
			//DateTime dateOne = DateTime.ParseExact("06/04/2021 10:00", "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
			//DateTime dateTwo = DateTime.ParseExact("06/04/2021 10:00", "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);

			//Article newArtcile = new Article(0, Convert.ToInt32(productChooser.SelectedValue), Convert.ToInt32(statusChooser.SelectedValue), Convert.ToInt32(userChooser.SelectedValue), 0, dateOne, dateTwo, articleImage0.Value, commentary.Value);
			//dal.AddNewArticle(newArtcile);

			// Het onderdeel dat bij het aanmaken van een nieuw artikel de punten bijschrijft bij de gebruiker. Via de ingevoerde categorie zoekt hij
			// de bijbehorende punten. Hierna wordt de gebruiker gezocht op basis van de keuze. De punten uit de categorie worden bij deze gebruiker
			// bijgeschreven. 

			//int categoryId = Convert.ToInt32(categoryChooser.SelectedValue);
			//Category fromCategory = dal.GetCategoryDetails(categoryId);
			//int rewardedPoints = fromCategory.GetPoints();

			// Zoekt het userId op en voegt de punten toe bij de functie in de DAL. Het opzoeken van de user doet hij ook automatisch in deze
			// functie.
			//int userId = Convert.ToInt32(userChooser.SelectedValue);
			//dal.AddPointsToUser(userId, rewardedPoints);
		}

		public void OnPostAddProduct()
		{
			// maak object van class op basis van invoerveld, doe vervolgens code uit dal daarmee

			//Product newProduct = new Product(0, Convert.ToInt32(categoryChooser0.SelectedValue), productName.Value, productDescriptionNA.Value);
			//dal.AddNewProduct(newProduct);
		}
	}
}

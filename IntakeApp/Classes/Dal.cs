using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using IntakeApp.Classes;

namespace IntakeApp.Classes
{
	public class Dal
    {
        // Een static variabele van de connectie, zodat hij in de functies niet zeurt dat hij niet bestaat
        static SqlConnection con;


        // Het connecten met de database via de connectiestring. Even aanpassen naar je eigen connectiestring dus ;).
        public SqlConnection databaseConnect()
        {
            string connectionString = @"Data Source=tcp:b2d-4-4-intakeappdbserver.database.windows.net,1433;Initial Catalog=b2d_4_4_intakeapp_db;User Id=AdminYP@b2d-4-4-intakeappdbserver;Password=4Gq7OTUgd44f;"; // <----- Deze aanpassen naar eigen connectionstring

            con = new SqlConnection(connectionString);

            con.Open();

            return con;
        }

        public void AddNewArticle(Article newArticle) // object van class Article als parameter
        {
            SqlConnection con = databaseConnect();

            SqlCommand cmd = new SqlCommand("insert into Articles (ProductId, StatusId, ProviderId, RenterId, Image, Commentary) values (@productid," +
                "@statusid,@providerid,@renterid,@image,@commentary)", con);

            cmd.Parameters.AddWithValue("@productid", newArticle.getProductId());
            cmd.Parameters.AddWithValue("@statusid", newArticle.getStatusId());
            cmd.Parameters.AddWithValue("@providerid", newArticle.getProviderId());
            cmd.Parameters.AddWithValue("@renterid", 2);
            cmd.Parameters.AddWithValue("@image", newArticle.getImage());
            cmd.Parameters.AddWithValue("@commentary", newArticle.getCommentary());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Het toevoegen van een nieuw product
        public void AddNewProduct(Product newProduct)
        {
            SqlConnection con = databaseConnect();

            SqlCommand cmd = new SqlCommand("insert into Products (CategoryId, ProductName, ProductDescription) values (@categoryId," +
                "@productName,@productDescription)", con);

            cmd.Parameters.AddWithValue("@categoryId", newProduct.getCategory());
            cmd.Parameters.AddWithValue("@productName", newProduct.getName());
            cmd.Parameters.AddWithValue("@productDescription", newProduct.getDescription());

            cmd.ExecuteNonQuery();
            con.Close();
        }

        // Het ophalen van Category gegevens op basis van een ID
        public Category GetCategoryDetails(int categoryId)
        {
            SqlConnection con = databaseConnect();

            string cmd = "SELECT * FROM Categories WHERE CategoryID = @categoryId";

            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            ad.SelectCommand.Parameters.AddWithValue("@categoryId", categoryId);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objectList.Add(row[col.ColumnName].ToString());
                }
            }

            Category currentCategory = new Category(Convert.ToInt32(objectList[0]), objectList[1].ToString(), Convert.ToInt32(objectList[2]));

            return currentCategory;
        }

        internal void AddNewArticle(Product newProduct)
        {
            throw new NotImplementedException();
        }

        // Het toevoegen van punten bij een user
        public void updateUser(User user)
        {
            SqlConnection con = databaseConnect();
            SqlCommand cmd = new SqlCommand("UPDATE Users SET FirstName = @firstname, LastName = @lastname, UserName = @username," +
                "Password = @password, UserPoints = @userpoints WHERE UserId = @ID", con);

            cmd.Parameters.AddWithValue("@ID", user.GetId());
            cmd.Parameters.AddWithValue("@firstname", user.GetFirst());
            cmd.Parameters.AddWithValue("@lastname", user.GetLast());
            cmd.Parameters.AddWithValue("@username", user.GetUserName());
            cmd.Parameters.AddWithValue("@password", user.GetPassword());
            cmd.Parameters.AddWithValue("@userpoints", user.GetPoints());


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddPointsToUser(int userId, int rewardedpoints)
        {
            SqlConnection con = databaseConnect();

            string cmd = "SELECT * FROM Users WHERE UserID = @userId";

            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            ad.SelectCommand.Parameters.AddWithValue("@userId", userId);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();

            foreach (DataColumn col in dt.Columns)
            {
                foreach (DataRow row in dt.Rows)
                {
                    objectList.Add(row[col.ColumnName].ToString());
                }
            }

            User currentUser = new User(Convert.ToInt32(objectList[0]), objectList[1].ToString(), objectList[2].ToString(), objectList[3].ToString(), objectList[4].ToString(), Convert.ToInt32(objectList[5]));

            int points = currentUser.GetPoints();
            points = points + rewardedpoints;
            currentUser.SetPoints(points);

            this.updateUser(currentUser);
        }

        public List<Product> GetProducts()
        {
            SqlConnection con = databaseConnect();

            string cmd = "SELECT * FROM Products";

            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();
            List<Product> products = new List<Product>();

            foreach (DataRow row in dt.Rows)
			{
                foreach(DataColumn col in dt.Columns)
				{
                    objectList.Add(row[col.ColumnName].ToString());
				}
                Product product = new Product(Convert.ToInt32(objectList[0]), Convert.ToInt32(objectList[1]), objectList[2], objectList[3]);
                products.Add(product);
                objectList.Clear();
            }

            return products;
        }
        public List<Category> GetCategorys()
        {
            SqlConnection con = databaseConnect();

            string cmd = "SELECT * FROM Categories";

            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();
            List<Category> Categories = new List<Category>();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    objectList.Add(row[col.ColumnName].ToString());
                }
                Category Category = new Category(Convert.ToInt32(objectList[0]), objectList[1], Convert.ToInt32(objectList[2]));
                Categories.Add(Category);
                objectList.Clear();
            }

            return Categories;
        }
        public List<Status> GetStatus()
        {
            SqlConnection con = databaseConnect();

            string cmd = "SELECT * FROM Statusses";

            SqlDataAdapter ad = new SqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            List<string> objectList = new List<string>();
            List<Status> Statusses = new List<Status>();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    objectList.Add(row[col.ColumnName].ToString());
                }
                Status Status = new Status(Convert.ToInt32(objectList[0]), objectList[1]);
                Statusses.Add(Status);
                objectList.Clear();
            }

            return Statusses;
        }
    }
}

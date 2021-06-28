//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//protected void Page_Load(object sender, EventArgs e)
//{
//    if (!IsPostBack)
//    {
//        string ConnectString = "server=localhost;database=b2d_4_4_intakeapp_db;integrated security=SSPI";
//        string QueryString = "select * from Catogories";

//        SqlConnection myConnection = new SqlConnection(ConnectString);
//        SqlDataAdapter myCommand = new SqlDataAdapter(QueryString, myConnection);
//        DataSet ds = new DataSet();
//        myCommand.Fill(ds, "Catogories");

//        Select1.DataSource = ds;
//        Select1.DataTextField = "au_fname";
//        Select1.DataValueField = "au_fname";
//        Select1.DataBind();
//    } 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace CartWebApp
{
    public partial class AddtoInventory : System.Web.UI.Page
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=CartInventoryDB;Persist Security Info=True;User ID=sa;Password=Password123";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "insert into ProdInfo(ProdName,ProdDesc,ProdPrice,ProdCat, ProdQuan) values(@ProdName, @ProdDesc, @ProdPrice, @ProdCat, @ProdQuan)";
                //sda = new SqlDataAdapter


                command.Parameters.AddWithValue("@ProdName", txtProductName.Text);
                command.Parameters.AddWithValue("@ProdDesc", txtProductDescription.Text);
                command.Parameters.AddWithValue("@ProdPrice", txtProductPrice.Text);
                command.Parameters.AddWithValue("@ProdCat", txtProductCategory.Text);
                command.Parameters.AddWithValue("@ProdQuan", txtProductQuantity.Text);

                command.ExecuteNonQuery();
                connection.Close();

                Response.Text = "Product have been successfully added to the inventory";
                txtProductName.Text = "";
                txtProductDescription.Text = "";
                txtProductPrice.Text = "";
                txtProductCategory.Text = "";
                txtProductQuantity.Text = "";

                //showGrid();
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message.ToString();
            }
        }

      
       
    }
}   
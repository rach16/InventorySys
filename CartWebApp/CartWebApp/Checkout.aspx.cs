using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace CartWebApp
{
    public partial class Checkout : System.Web.UI.Page
    {
        string salesid;
        private string connectionString = @"Data Source=localhost;Initial Catalog=CartInventoryDB;Persist Security Info=True;User ID=sa;Password=Password123";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["salesid"] != null)
            {
                salesid = Session["salesid"].ToString();
              
            }
            getData();

        }
        protected void getData()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            //salesid = "24";
            string s = "select username,salesdate from sales where salesid=" + salesid;
            Label5.Text = salesid;
            try
            {
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lblName.Text = rdr[0].ToString();
                }
                rdr.Close();
                s = "select prodname as Product_Name, cartinfo.prodquan as Quantity, cartinfo.prodprice as Price, cartinfo.prodquan* cartinfo.prodprice as Total from cartinfo,prodinfo where cartinfo.prodid = prodinfo.prodid and salesid = " + salesid;
                SqlCommand cmdcart = new SqlCommand(s, con);
                SqlDataReader rdrCart = cmdcart.ExecuteReader();
                checkoutGrid.DataSource = rdrCart;
                checkoutGrid.DataBind();
                rdrCart.Close();
                s = "select sum(prodquan*prodprice) from cartinfo where salesid=" + salesid;
                SqlCommand cmd2 = new SqlCommand(s, con);
                SqlDataReader rdrtot = cmd2.ExecuteReader();
                if (rdrtot.Read())
                {
                    lblTotal.Text = "$"+ rdrtot[0].ToString();
                }
            }catch(Exception ex) { lblTotal.Text = ex.Message; }
        }
        
    }
}
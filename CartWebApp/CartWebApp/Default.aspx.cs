using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CartWebApp
{
    public partial class Default : System.Web.UI.Page
    {

        private string connectionString = @"Data Source=localhost;Initial Catalog=CartInventoryDB;Persist Security Info=True;User ID=sa;Password=Password123";

        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String userid, password, usertype;
            if(TextBox1.Text=="" || TextBox2.Text == "") { return; }
            userid = TextBox1.Text;
            password = TextBox2.Text;
            String sql = "select utype from UserInfo where uname = '" + userid + "' and pwd ='" + password+"'";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                usertype = rdr[0].ToString();
            }
            else
            {
                Label1.Text = "invalid Credentials.";
                return;
            }
            con.Close();
          
            Session["id"] = userid;
            Session["utype"] = usertype;
            if (usertype.Equals("Admin"))
                Response.Redirect("AdminHome.aspx");
            else if (usertype.Equals("usert"))
                Response.Redirect("UserHome.aspx");
        }
    }
}
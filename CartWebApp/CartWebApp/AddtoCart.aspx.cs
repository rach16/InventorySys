using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.SessionState;

namespace CartWebApp
{
    public partial class AddtoCart : System.Web.UI.Page
    {
        String sid;

        private string connectionString = @"Data Source=localhost;Initial Catalog=CartInventoryDB;Persist Security Info=True;User ID=sa;Password=Password123";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { comboLoad();
               
            }
            sid = Session.SessionID;
            Session["cid"] = Session.SessionID;
            //lblCom.Text = sid;
            
        }

        public void comboLoad()
        {
            itemsDropDownList.Items.Clear();
            itemsDropDownList.Items.Add("Please select a product.");
            SqlConnection con;
            SqlCommand cmd;
            string sql = "select ProdId, ProdName from ProdInfo";
            con = new SqlConnection(connectionString);
            SqlDataReader reader;
            try
            {
                con.Open();
                cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    itemsDropDownList.Items.Add(reader.GetValue(1).ToString() + ":" + reader.GetValue(0).ToString());
                }
            }
            catch (Exception e) { lblCom.Text = e.Message.ToString(); }

        }
        protected void prodQuantity0_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void itemsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemsDropDownList.Text.Equals("") || itemsDropDownList.Text.Equals("Please select a product."))
                return;
           // lblCom.Text = "kjsdkladjfcklsdjflkj";
            SqlConnection connection = new SqlConnection(connectionString);
            string[] items = itemsDropDownList.Text.Split(':');
            SqlCommand cmd;
            string sql = "Select ProdQuan, ProdPrice from ProdInfo where ProdId = " + items[1];
            try
            {
                connection.Open();
                cmd = new SqlCommand(sql, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    currentStock.Text = reader.GetValue(0).ToString();
                    priceUnit.Text = reader.GetValue(1).ToString();
                }

                connection.Close();
            }
            catch (Exception ex) { lblCom.Text=(ex.Message.ToString()); }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            userNameTxtBox.Text = "";
            itemsDropDownList.SelectedIndex = -1;
            prodQuantity.Text = "";
            priceUnit.Text = "";
            currentStock.Text = "";
            priceUnit.Text = "";
           
        }
        protected void Button6_Click(object sender, EventArgs e)
        {

            double totalAmt = 0;
            if (prodQuantity.Text == "" || priceUnit.Text == "" || itemsDropDownList.Text == "Please select a product.") return; 
            if(Convert.ToDouble(currentStock.Text)- Convert.ToDouble(prodQuantity.Text)<0 || Convert.ToDouble(prodQuantity.Text)<=0)
            {
                lblCom.Text = "Out of Stock";
                return;
            }
            if (totalAmount.Text.Trim() != string.Empty)
                totalAmt = Convert.ToDouble(totalAmount.Text);
            totalAmt += Convert.ToDouble(prodQuantity.Text) * Convert.ToDouble(priceUnit.Text);
            totalAmount.Text = totalAmt.ToString();
            //DialogResult result = MessageBox.Show("Do you want to proceed with what you have selected?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           // if (result == DialogResult.Yes)
            {
                string[] products = itemsDropDownList.Text.Split(':');
                string cartid = Session["cid"].ToString();
               
                try
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    con.Open();
                    string sq = "select * from TempCart where cartid='" + cartid + "' and prodid='" + products[1].Trim() + "'";
                    SqlCommand prodcmd = new SqlCommand(sq, con);
                    SqlDataReader prodrdr = prodcmd.ExecuteReader();
                    if (prodrdr.HasRows)
                    {
                        lblCom.Text = "Product  already in cart.";
                        con.Close();
                        return;
                    }
                    prodrdr.Close();
                    string sql = "insert into Tempcart(cartid,prodid,prodname,prodprice,prodquan)" +
                        "values(@cartid,@prodid,@prodname,@prodprice,@prodquan)";

                   
                    //command.parameters insert 
                   
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.Add("@cartid", SqlDbType.VarChar).Value = cartid;
                    cmd.Parameters.Add("@prodid", SqlDbType.VarChar).Value = products[1];
                    cmd.Parameters.Add("@prodname", SqlDbType.VarChar).Value = products[0];
                    cmd.Parameters.Add("@prodprice", SqlDbType.VarChar).Value = priceUnit.Text.Trim();
                    cmd.Parameters.Add("@prodquan", SqlDbType.VarChar).Value = prodQuantity.Text.Trim();
                    cmd.ExecuteNonQuery();
                    sql = "select prodid,prodname,prodprice,prodquan from tempcart where cartid='" + cartid + "'";
                    SqlCommand cmdcart = new SqlCommand(sql, con);
                    SqlDataReader rdr= cmdcart.ExecuteReader();
                   // cartGrid.DataSource = rdr;
                  //  cartGrid.DataBind();
                    GridView1.DataBind();
               }
                catch (Exception ex) { lblCom.Text = ex.Message; }
               priceUnit.Text = "";
               prodQuantity.Text = "";
                currentStock.Text = "";
                comboLoad();
              //  it();
            }
           /* else if (result == DialogResult.No)
            {
                textBox1.Focus();
            }*/

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int rowcount = 0;
            rowcount = GridView1.Rows.Count;

            if (rowcount < 1)
            {
                lblCom.Text=("Cart is Empty. ");
                return;
            }
            if (userNameTxtBox.Text == "")
            {
                lblCom.Text = "User Name required.";
                return;
            }
            string sql = "";

            string salesid = "";
            //  MessageBox.Show(sql);
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd;
            try
            {
                string prodid = "", quan, price, cartid = "1";
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                for (int i = 0; i < rowcount; i++)//check all product stock are valid
                {
                    prodid = GridView1.Rows[i].Cells[3].Text;
                    quan = GridView1.Rows[i].Cells[6].Text + "";

                    sql = "select prodquan from prodinfo where prodid=" + prodid;
                    cmd.CommandText = sql;
                    double q = Convert.ToDouble(cmd.ExecuteScalar().ToString()) - Convert.ToDouble(quan);

                    if (q < 0)
                    {
                        lblCom.Text=(" Product ID " + prodid + " is out of stock.");
                        return;
                    }
                }
                sql = "insert into sales (username,salesdate)values('" + userNameTxtBox.Text.Trim() + "','" + System.DateTime.Now.ToString() + "')  select scope_identity()";
                //insert into sales table and get the unique identifier 
                cmd.CommandText = sql;
                salesid = cmd.ExecuteScalar() + "";
               String saleID = salesid;
                // cmd.Parameters.Clear();
                cmd.CommandText = "select count(*) from cartinfo";//get number of items in cart and generate new cart id
                cartid = cmd.ExecuteScalar().ToString();
                // cmd.Parameters.Clear();
                int cid = Convert.ToInt32(cartid) + 1;
                cartid = cid + "";
                for (int i = 0; i < rowcount; i++)
                {
                    prodid = GridView1.Rows[i].Cells[3].Text;
                    quan = GridView1.Rows[i].Cells[6].Text;
                    price = GridView1.Rows[i].Cells[5].Text;
                    sql = "select prodquan from prodinfo where prodid=" + prodid;
                    cmd.CommandText = sql;
                    double q = Convert.ToDouble(cmd.ExecuteScalar().ToString()) - Convert.ToDouble(quan);

                    if (q < 0)//check stock again, in case a product has bC:\Users\Administrator\documents\visual studio 2015\Projects\CartWebApp\CartWebApp\Properties\PublishProfiles\webCart.pubxmleen added twice
                    {
                        lblCom.Text=(" Product ID " + prodid + " is out of stock.");
                        continue;
                    }
                    sql = "insert into cartinfo (cartid,prodid,prodquan,prodprice,salesid) values(" + cartid + ","
    + prodid + "," + quan + "," + price + "," + salesid + ")";// insert new record to cartinfo 
                                                              // MessageBox.Show(sql);
                                                              //cmd.Parameters.Clear();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    sql = "update prodinfo set prodquan=prodquan-" + quan + " where prodid=" + prodid;//update product stock
                                                                                                      // cmd.Parameters.Clear();
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                 
                }
                SqlCommand cmdDeleteTemp;
                String tempCartid = Session.SessionID.ToString();
                sql = "delete from tempcart where cartid='" + tempCartid + "'";
                cmdDeleteTemp = new SqlCommand(sql, con);
                cmdDeleteTemp.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex) { lblCom.Text=(ex.Message.ToString() + sql); return; }
            //Checkout chk = new Checkout();
            //chk.Show();
            Session["salesid"] = salesid;

            Response.Redirect("Checkout.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Session.RemoveAll();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
            }

            if (Request.Cookies["AuthToken"] != null)
            {
                Response.Cookies["AuthToken"].Value = string.Empty;
                Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
            }
        }

   
    }
}
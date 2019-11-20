using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
public partial class CheckCart : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.Cookies["cartcookie"] != null && Request.Cookies["cartcookie"].Value != "")
        {
            if (!Page.IsPostBack)
                displaycart();
        }
        else if (Request.Cookies["cartcookie"] == null || Request.Cookies["cartcookie"].Value == "")
        {
            Literal1.Text = "<tr><td colspan='5'>Nothong Found Please Select Product</tr></td>";
            Response.Write("<script>alert('Nothong Found Please Select Product')</script>");
        }
    }
    private void displaycart()
    {
        string qry = "SELECT * from tbproduct where id in (" + Request.Cookies["cartcookie"].Value + ")";
        //Response.Write("<script>alert('" + qry + "')</script>");
        SqlCommand cmd = new SqlCommand(
         qry,
          con);
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Literal1.Text += "<tr>" +
                    "	<td class='cart_product'>" +
                    "		<a href=''><img src='product/" + reader.GetString(5) + "' alt='' height='110px' width='110px'></a>" +
                    "	</td>" +
                    "	<td class='cart_description'>" +
                    "		<h4>" + reader.GetString(4) + "</h4>" +
                    "		<p>Product ID: " + reader.GetInt32(0) + "</p>" +
                    "	</td>" +
                      "	<td class='cart_description'>" +
                    "		<p>Brand: " + reader.GetString(1) + "</p>" +
                     "		<p>Category: " + reader.GetString(2) + "</p>" +
                      "		<p>Sub Category: " + reader.GetString(3) + "</p>" +
                    "	</td>" +
                    "		<td class='cart_price'>" +
                    "			<p>$<span Class='c_Price'>" + reader.GetString(10) + "</span></p>" +
                    "		</td>" +
                    "		<td class='cart_delete'>" +
                    "			<a class='cart_quantity_delete' href='DeleteCookie.aspx?delete=" + reader.GetInt32(0) + "'><i class='fa fa-times'></i></a>" +
                    "		</td>" +
                    "</tr>";
            }
        }
        reader.Close();
        con.Close();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Literal1.Text == "<tr><td colspan='5'>Nothong Found Please Select Product</tr></td>")
        {
            Response.Redirect("home.aspx");
        }
        Response.Redirect("Checkout.aspx");
    }
}
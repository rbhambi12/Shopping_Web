using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
public partial class Admin_brandlist : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Request.QueryString["id"] != null)
        {
            
            SqlCommand cmd = new SqlCommand(
          "SELECT * from tbproduct where id=@id",
          con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                Literal1.Text += "<div class='product-details'><div class='col-sm-5'><div class='view-product'><img src='../product/" + reader.GetString(5) + "' alt='' /><h3>ZOOM</h3></div></div>" +
                    "<div class='col-sm-7'><div class='product-information'><img src='images/product-details/new.jpg' class='newarrival' alt='' /><h2>" + reader.GetString(4) + "</h2>" +
                    "<p>Brand: " + reader.GetString(1) + "</p><img src='images/product-details/rating.png' alt='' /><span><span>US $" + reader.GetString(10) + "</span><label>" +
                    "Quantity Avalible: " + reader.GetString(9) + " </ label ><a href = 'cartproduct.aspx?Product=" + reader.GetInt32(0) + "'><button type = 'button' class='btn btn-fefault cart'>" +
                    "<i class='fa fa-shopping-cart'></i> Add To Cart </button></a></span><p><b>Color:</b> " + reader.GetString(7) + "</p><p><b>Size:</b> " + reader.GetString(8) + "</p>" +
                    "<p><b>Category:</b> " + reader.GetString(2) + "</p><p><b>Sub Category:</b> " + reader.GetString(3) + "</p><p><b>Care:</b> " + reader.GetString(6) + "</p>" +
                    "<a href=''><img src='images/product-details/share.png' class='share img-responsive'  alt='' /></a></div></div></div>"; 

                }
            }
            reader.Close();
            con.Close();
        }
    }
}
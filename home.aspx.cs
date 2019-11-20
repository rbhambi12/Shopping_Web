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
        if (Request.QueryString["did"] != null)
        {

            SqlCommand cmd = new SqlCommand("delete from tbproduct where id=@id", con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", Request.QueryString["did"]);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }


        string st = "";
        if (Request.QueryString["Category"] != null)
        {
            st = "SELECT * from tbproduct where p_subcat='" + Request.QueryString["Category"] + "'";
        }
        else if (Request.QueryString["Brand"] != null)
        {
            st = "SELECT * from tbproduct where p_brand='" + Request.QueryString["Brand"] + "'";
        }
        else
        {
            st = "SELECT * from tbproduct";
        }
        SqlCommand command = new SqlCommand(st, con);
            con.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Literal1.Text += "<div class='col-sm-4'><div class='product-image-wrapper'><div class='single-products'><div class='productinfo text-center'>" +
                        "<img src = 'product/" + reader.GetString(5) + "' alt = '' /><h2>$" + reader.GetString(10) + " </h2><p> " + reader.GetString(4) + " </p> " +
                        "             <a href = 'productdetail.aspx?id=" + reader.GetInt32(0) + "' class='btn btn-default add-to-cart'><i class='fa fa-info'></i>Detail's</a>" +
                        "             <a href = 'cartproduct.aspx?Product=" + reader.GetInt32(0) + "' class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add To Cart</a>" +
                        "</div></div><div class='choose'></div></div></div>";    

                }
            }
            reader.Close();
            con.Close();
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Guest : System.Web.UI.MasterPage
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            //Response.Write("<script>alert('" + path + "')</script>");
            if (path != "/shop/home.aspx")
            {
                slider.Visible = false;
            }
            if(Request.Cookies["mobile"]!=null)
            {
                //string stm = Request.Cookies["mobile"].Value;
                Logou.Visible = true;
                logi.Visible = false;
            }
            else
            {
                Logou.Visible = false;
                logi.Visible = true;
            }
           
            categorydisplay();
        }
    }
    private void categorydisplay()
    {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        con.Open();
        string[] Category = new string[9] { "Men", "Women", "Children", "Healthy-Living", "Home", "Unique-In-Box", "Treasure-Box", "Shop-By", "New-Arrivals"};
        foreach (string x in Category)
        {

            Literal1.Text += "<div class='panel panel-default'><div class='panel-heading'><h4 class='panel-title'><a data-toggle='collapse'" +
                    "data-parent='#accordian' href='#" + x + "'><span class='badge pull-right'><i class='fa fa-plus'></i></span>" +
                    x +
                    "</a></h4></div>" +
                    "<div id='" + x + "' class='panel-collapse collapse'>";

            cmd.CommandText = "select * from tbcat where cat_name='" +x+ "'";     
            
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Literal1.Text += "<div class='panel-body'><ul>" +
                    "<li><a href='home.aspx?Category=" + reader.GetString(2) + "'>" + reader.GetString(2) + "</a></li>" +
                    "</ul></div>";
                }
            }
            else
            {
                Literal1.Text += "<div class='panel-body'><ul>" +
                    "<li><a href='#'>Not Available</a></li>" +
                    "</ul></div>";
            }
            reader.Close();           

            Literal1.Text += "</div></div>";
        }
        cmd.CommandText = "select * from tbbrand";
        SqlDataReader reader1 = cmd.ExecuteReader();
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {
                Literal2.Text += "<li><a href='home.aspx?Brand=" + reader1.GetString(1) + "'> <span class='pull-right'></span>" + reader1.GetString(1) + "</a></li>";
            }
        }
        reader1.Close();
      
        if (Request.QueryString["Category"] != null)
        {
            cmd.CommandText = "SELECT  * FROM tbproduct where p_subcat='@cat'  ORDER BY NEWID()";
            cmd.Parameters.AddWithValue("@cat", Request.QueryString["Category"]);
           
        }
        else if (Request.QueryString["Brand"] != null)
        {
            cmd.CommandText = "SELECT  * FROM tbproduct where p_brand='@cat'  ORDER BY NEWID()";
            cmd.Parameters.AddWithValue("@cat", Request.QueryString["Brand"]);
        }
        else
        {
            cmd.CommandText = "SELECT TOP 6 * FROM tbproduct ORDER BY NEWID()";
        }

        SqlDataReader reader2 = cmd.ExecuteReader();
        if (reader2.HasRows)
        {
            int ci = 1;
            while (reader2.Read())
            {
                if (ci <= 3)
                {
                    Literal3.Text += "<div class='col-sm-4'><div class='product-image-wrapper'><div class='single-products'><div class='productinfo text-center'>" +
                        "<img src='product/" + reader2.GetString(5) + "' alt='' / height='134px' width='164px'>" +
                        "<h2>$" + reader2.GetString(10) + "</h2><p>" + reader2.GetString(4) + "</p>" +
                        "<a href='cartproduct.aspx?Product=" + reader2.GetInt32(0) + "' class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add to cart</a></div></div></div></div>";
                }
                else
                {
                    Literal4.Text += "<div class='col-sm-4'><div class='product-image-wrapper'><div class='single-products'><div class='productinfo text-center'>" +
                       "<img src='product/" + reader2.GetString(5) + "' alt='' / height='134px' width='164px'>" +
                       "<h2>$" + reader2.GetString(10) + "</h2><p>" + reader2.GetString(4) + "</p>" +
                       "<a href='cartproduct.aspx?Product=" + reader2.GetInt32(0) + "' class='btn btn-default add-to-cart'><i class='fa fa-shopping-cart'></i>Add to cart</a></div></div></div></div>";
                }
                ci++;
            }
        }
        reader2.Close();


        con.Close();
    }
}

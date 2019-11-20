using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Thankyou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["code"]!=null)
        {
            string str = "<h3>Please Note This code for track your</H3><h1> ORDER ID '" + Request.QueryString["code"] +"'</h1>";
            Literal1.Text = str;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
}
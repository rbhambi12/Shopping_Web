using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class destroylogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cookies["mobile"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["code"].Expires = DateTime.Now.AddDays(-1);
        Response.Redirect("home.aspx");
    }
}
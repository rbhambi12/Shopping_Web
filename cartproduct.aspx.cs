using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
public partial class cartproduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["cartcookie"] == null)
        {
            Response.Cookies["cartcookie"].Value = Request.QueryString["Product"].ToString();
            //Response.Write("<script>alert('" + Response.Cookies["cartcookie"].Value + "')</script>");
            //Response.Write("<script>alert('" + Request.UrlReferrer.ToString() + "')</script>");
            //Response.Redirect(Request.UrlReferrer.ToString());
            Response.Redirect("CheckCart.aspx");
        }
        else if (Request.Cookies["cartcookie"] != null)
        {
            string pstr = Request.QueryString["Product"].ToString();
            string cstr = Request.Cookies["cartcookie"].Value;
            cstr += "," + pstr;
           // Response.Write("<script>alert('" + cstr + "')</script>");           
            int[] numbers = cstr.Split(',').Select(Int32.Parse).ToArray();            
            int[] q = numbers.Distinct().ToArray();
            cstr= string.Join(",", q);
            Response.Cookies["cartcookie"].Value = cstr;
            //Response.Write("<script>alert('" + Request.UrlReferrer.ToString() + "')</script>");
           
                //Response.Redirect(Request.UrlReferrer.ToString());
            Response.Redirect("CheckCart.aspx");
        }
    }
}
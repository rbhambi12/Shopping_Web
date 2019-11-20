using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteCookie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["delete"] != null)
        {

            string cstr = Request.Cookies["cartcookie"].Value;
            int[] numbers = cstr.Split(',').Select(Int32.Parse).ToArray();
            int numToRemove = Convert.ToInt32(Request.QueryString["delete"]);
            numbers = numbers.Where(val => val != numToRemove).ToArray();
            //numbers = numbers.Except(new int[] { numToRemove }).ToArray();
            cstr = string.Join(",", numbers);
            Response.Cookies["cartcookie"].Value = cstr;
            if(cstr=="")
            {
                Response.Cookies["cartcookie"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Write("<script>alert('var is =" + cstr + " cookie is= " + Response.Cookies["cartcookie"].Value + "')</script>");
            Response.Redirect("checkcart.aspx");
        }
    }
}
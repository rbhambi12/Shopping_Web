using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
public partial class Admin_Orders : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString); 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            display();
    }
    private void display()
    {
        //SqlCommand cmd = new SqlCommand("SELECT COUNT(id),id FROM tborder GROUP BY mobile",
        //  con);
        //con.Open();
        //string st = "";
        //SqlDataReader reader = cmd.ExecuteReader();

        //if (reader.HasRows)
        //{
        //    while (reader.Read())
        //    {
        //        st += reader.GetInt32(0).ToString()+",";
        //    }
        //}
        //st=st.Substring(0, st.Length-1);
        //con.Close();
        //cmd.Dispose();
        string stm = Request.Cookies["mobile"].Value;
        string stc = Request.Cookies["code"].Value;
        string qry1 = "select id,Address,mobile as Mobile,status as Status from tborder where mobile='"+ stm + "' and code='"+stc+"'";
        SqlDataAdapter adp = new SqlDataAdapter(qry1, con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName== "Detail")
        {
            Response.Redirect("detialorder.aspx?id="+e.CommandArgument.ToString());
        }
    }
}
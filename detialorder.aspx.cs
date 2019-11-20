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
        string stm = Request.Cookies["mobile"].Value;
        string stc = Request.Cookies["code"].Value;
        string qry1 = "select id,Address,mobile as Mobile,status as Status from tborder where mobile='" + stm + "' and code='" + stc + "'";
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
        if(e.CommandName== "Delivered")
        {
            SqlCommand cmd = new SqlCommand();
            string qry = "";
           
                qry = "delete from tborder where id="+Convert.ToInt32(e.CommandArgument);
            cmd.CommandText = qry;
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            display();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string stm = Request.Cookies["mobile"].Value;
        string stc = Request.Cookies["code"].Value;
        SqlDataAdapter adp = new SqlDataAdapter("select tborder.id,tborder.Address,tborder.mobile as Mobile,tborder.status as Status,tbproduct.p_name from tborder inner join tbproduct on  tbproduct.id=tborder.productid and tborder.status='" + DropDownList1.SelectedItem.Text+"'" +
            "and tborder.mobile='"+stm+"' and code='"+stc+"'", con);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        if(DropDownList1.SelectedItem.Text=="Delivered")
        {
            GridView1.Columns[0].Visible = false;
        }
        else
        {
            GridView1.Columns[0].Visible = true;
        }
    }
}
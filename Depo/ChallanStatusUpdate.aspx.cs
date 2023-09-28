using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ChallanStatusUpdate : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            GridView1.DataSource = comm.FillDatasetByProc("call `USP_UpdateC`()");
            GridView1.DataBind();
        
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        TextBox1.Text = GridView1.SelectedRow.Cells[1].Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        comm.FillDatasetByProc("call `UpdateStateus`('"+TextBox1.Text+"','"+TextBox2.Text+"')");
        GridView1.DataSource = comm.FillDatasetByProc("call `USP_UpdateC`()");
        GridView1.DataBind();
        TextBox1.Text = "";
        TextBox2.Text = "";
    }
}
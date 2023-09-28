using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_Problem : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd = comm.FillDatasetByProc("call USPProblem(4,'',''," + Session["UserID"] + ")");
            GridView1.DataSource = dd.Tables[0];
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        comm.FillDatasetByProc("call USPProblem(1,'"+TextBox1.Text+"','',"+Session["UserID"]+")");
        DataSet dd = comm.FillDatasetByProc("call USPProblem(4,'" + TextBox1.Text + "',''," + Session["UserID"] + ")");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind ();
        //USPProblem
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        DataSet dd = comm.FillDatasetByProc("call USPProblem(4,'" + TextBox1.Text + "',''," + Session["UserID"] + ")");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();

    }
}
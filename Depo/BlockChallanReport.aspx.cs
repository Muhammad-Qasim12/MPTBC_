using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_BlockChallanReport : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = comm.FillDatasetByProc("call USP_DPT_GetChallanStatus (" + Session["UserID"] + ")");
            GridView1.DataBind();
        }

    }
    protected void btn_save(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        try {
        comm.FillDatasetByProc("update dpt_distributchallanreceipt set DepoRemark='" + ((TextBox)grdrow.FindControl("TextBox1")).Text + "' where ChallanID='" + ((HiddenField)grdrow.FindControl("HiddenField1")).Value + "'");
        GridView1.DataSource = comm.FillDatasetByProc("call USP_DPT_GetChallanStatus (" + Session["UserID"] + ")");
        GridView1.DataBind();
        }
        catch { }
    }
   // btn_save
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_RPTStockParivartan : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try {
           DataSet ds=comm.FillDatasetByProc("call USP_DPTgetStockParivartanRpta("+ddlMedium.SelectedValue+","+Session["UserID"]+")");
           GridView1.DataSource = ds.Tables[0];
           GridView1.DataBind();

        }
        catch { }
    }
}
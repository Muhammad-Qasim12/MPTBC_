using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_PrinterNameIndexing : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PrinterName("+Session["UserID"]+",'"+ddlSessionYear.SelectedValue+"')");
        GridView1.DataBind();
    }
}
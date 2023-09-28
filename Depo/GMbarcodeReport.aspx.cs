using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_GMbarcodeReport : System.Web.UI.Page
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
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //obCommonFuction.FillDatasetByProc("delete from tbl_Tbl_ChallanBundelNew");
        //obCommonFuction.FillDatasetByProc("CALL USP_ChallanWiseDataNew() ");
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_getBarcodeData('" + ddlSessionYear.SelectedItem.Text + "')");
        GridView1.DataBind();
    }
}
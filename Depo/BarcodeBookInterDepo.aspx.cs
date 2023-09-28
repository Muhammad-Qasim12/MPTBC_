using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_BarcodeBookInterDepo : System.Web.UI.Page
{
    CommonFuction obCommonFuction;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT35GetReceivedInterDepoRequest(" + Session["UserID"] + ")");
            DropDownList1.DataTextField = "challanno";
            DropDownList1.DataValueField = "challanno";
            DropDownList1.DataBind();
        }
    }
    protected void TxtCode_TextChanged(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("call USP_DPTStockUpdate(0,"+DropDownList1.SelectedValue+",'"+TxtCode.Text+"')");
        grdPrinterBundleDetails.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPTStockUpdate(1," + DropDownList1.SelectedValue + ",'" + TxtCode.Text + "')");
        grdPrinterBundleDetails.DataBind();
        TxtCode.Text = "";
        TxtCode.Focus();
    }
}
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

public partial class CenterDepot_ReceiptPrint : System.Web.UI.Page
{
    DataSet Dt;
    DataSet ds;
    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Vendorfill();
            fillParameters();
        }

    }
    protected void ddlVendorName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //select ChallanNo from ppr_paperdispatch_m where acyear='2017-2018' and PaperVendorTrId_I=823;
        ddlChallan.DataSource = obCommonFuction.FillDatasetByProc(@"select ChallanNo from ppr_paperdispatch_m where acyear='" + DdlACYear.SelectedValue + "' and PaperVendorTrId_I=" + ddlVendorName.SelectedValue + "  AND UpdateStatus=2");
        ddlChallan.DataValueField = "ChallanNo";
        ddlChallan.DataTextField = "ChallanNo";
        ddlChallan.DataBind();
        ddlChallan.Items.Insert(0, new ListItem("Select...", "0"));
    }
    private void fillParameters()
    {
        CommonFuction comm = new CommonFuction();
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();

    }
    public void Vendorfill()
    {
        PPR_BillGenerate ObjBillGenerate = null;
        ObjBillGenerate = new PPR_BillGenerate();
        ddlVendorName.DataSource = ObjBillGenerate.VendorFill();
        ddlVendorName.DataValueField = "PaperVendorTrId_I";
        ddlVendorName.DataTextField = "PaperVendorName_V";
        ddlVendorName.DataBind();
        ddlVendorName.Items.Insert(0, new ListItem("Select...", "0"));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      DataSet dt=  obCommonFuction.FillDatasetByProc("call GetReceipt("+ddlChallan.SelectedValue+")");
      try {
          Panel1.Visible = true;
          lblYear.Text = DdlACYear.SelectedItem.Text;

      lblReceiptPrint.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
      lblGSRPagePrint.Text = dt.Tables[0].Rows[0]["GSRPageNo"].ToString();
      lblReceiptReelPrint.Text = dt.Tables[0].Rows[0]["SndrReel"].ToString();
      lblDamajReelPrint.Text = dt.Tables[0].Rows[0]["DefReel"].ToString();
      lblVehicleNoPrint.Text = dt.Tables[0].Rows[0]["TruckNo"].ToString();
      }
      catch { }
    }
}
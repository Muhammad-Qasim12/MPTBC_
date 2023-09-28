using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Printing_ChallanSendByDepo : System.Web.UI.Page
{
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = new CommonFuction();
     Pri_BillDetails objBillDetails = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {  
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            
            PrinterFill();
            FillData();
        }
    }
    public void FillData()
    {
        try
        {
            obPRI_PrinterRegistration = new PRI_PrinterRegistration();

            obPRI_PrinterRegistration.Printer_RedID_I = 0;//Convert.ToInt32(Session["UserID"]);
            GrdChallanDetail.DataSource = obPRI_PrinterRegistration.GetChallanDetailFromDepo();
            GrdChallanDetail.DataBind();
        }
        catch  {    }
    }
    
    protected void GrdWarehouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdChallanDetail.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnk.NamingContainer;
            Label lblPinterID_I = (Label)gv.FindControl("lblPinterID_I");
            obPRI_PrinterRegistration = new PRI_PrinterRegistration();
            int i = obPRI_PrinterRegistration.GetChallanDetailFromDepoStatusChange(int.Parse(lblPinterID_I.Text));
            if (i > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('चालान को बिल में जोड़ दिया गया है |');</script>");
            }
            else
            {
              //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
            }
          FillData();
            
        }
        catch { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();

        if (ddlPrinter.SelectedIndex > 0)
        {
            obPRI_PrinterRegistration.Printer_RedID_I = 0;//Convert.ToInt32(Session["UserID"]);
        }
        else
        {
            if (ddlPrinter.SelectedIndex>0)
            {
            obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(ddlPrinter.SelectedValue);
            //Convert.ToInt32(Session["UserID"]); }

            GrdChallanDetail.DataSource = obPRI_PrinterRegistration.GetChallanDetailFromDepo();
            GrdChallanDetail.DataBind();
                }
        }
    }
    public void PrinterFill()
    {
        objBillDetails = new Pri_BillDetails();
        ddlPrinter.DataSource = objBillDetails.PrinterDetailsFill();
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
      
    }
    protected void GrdChallanDetail_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
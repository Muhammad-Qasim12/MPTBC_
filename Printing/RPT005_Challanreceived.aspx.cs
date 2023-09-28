using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer ;
using System.IO;
public partial class Printing_Reports_RPT003_GroupAllotment : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = new CommonFuction();
    Pri_BillDetails objBillDetails = null;
 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            PrinterFill();
             FillData(); Label1.Visible = true; Label2.Visible = true; 
            btnExport.Visible = false;
           // btnExportPDF.Visible = false;
           
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
        catch { }
    }
    



    public void LoadGroup()
    {
        

        try
        {

            obPRI_PrinterRegistration = new PRI_PrinterRegistration();

            if (ddlPrinter.SelectedIndex>0)
            {
                obPRI_PrinterRegistration.Printer_RedID_I =Convert.ToInt32 ( ddlPrinter.SelectedValue) ;//Convert.ToInt32(Session["UserID"]);
            GrdChallanDetail.DataSource = obPRI_PrinterRegistration.GetChallanDetailFromDepo();
            GrdChallanDetail.DataBind();
            }


        }

        catch (Exception ex)
        {
        }
        finally
        {
            obPRI_PrinterRegistration = null;
        }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
      //  LoadGroup();
        //Label1.Visible = true;
        //Label2.Visible = true; 

    }

    
     public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PrinterChallan.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadGroup();
        btnExport.Visible = true;
      //  btnExportPDF.Visible = true;
        Label1.Visible = true; Label2.Visible = true; 
    }
    protected void GrdWarehouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

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
}
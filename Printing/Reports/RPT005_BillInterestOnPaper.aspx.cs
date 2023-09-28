using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using System.IO;

public partial class Printing_Reports_RPT005_BillInterestOnPaper : System.Web.UI.Page
{
    PRI_PaperBillInterestonPaper obPRI_PaperBillInterestonPaper = null;
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PrinterFill();
            FillData();
        }

    }

    public void PrinterFill()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();

        obPRI_PrinterRegistration.Printer_RedID_I = 0;

        ddlPrinterID_I.DataTextField = "NameofPress_V";
        ddlPrinterID_I.DataValueField = "Printer_RedID_I";
        ddlPrinterID_I.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
        ddlPrinterID_I.DataBind();

        ddlPrinterID_I.Items.Insert(0, new ListItem("Select", "0"));
    }


    public void FillData()
    {
        try
        {
            //obPRI_PaperAllotment = new PRI_PaperAllotment();
            //obPRI_PaperAllotment.PaperAltID_I = 0;

            obPRI_PaperBillInterestonPaper = new PRI_PaperBillInterestonPaper();

            obPRI_PaperBillInterestonPaper.PrinterID_I = Convert.ToInt32(ddlPrinterID_I.SelectedValue);

            GrdPaperBill.DataSource = obPRI_PaperBillInterestonPaper.LoadReportBillInterest();
            //GrdPaperBill.DataSource = obPRI_PaperAllotment.SelectPaperBillIntrestLoad();
            GrdPaperBill.DataBind();

        }
        catch
        {
        }
        finally { obPRI_PaperBillInterestonPaper = null; }
    }


    protected void btnGetReport_Click(object sender, EventArgs e) 
    {
        FillData();
    }

    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BillInterestonPaper.xls"));
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
}
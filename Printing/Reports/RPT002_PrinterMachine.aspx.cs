using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.IO;
public partial class Printing_Reports_RPT002_PrinterMachine : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    public string Printer;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { FillPrinter();   }
    }


    public void FillPrinter()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlPrinter.DataBind();

            ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }


    public void LoadMachineDescription()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            obPRI_PrinterRegistration.PriMacID_I = 0;
            obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(ddlPrinter.SelectedValue);
            grdMachineDetails.DataSource = obPRI_PrinterRegistration.PrinterMachineListLoad();
            grdMachineDetails.DataBind();
            if (ddlPrinter.SelectedIndex > 0)
            {
                lblPrinterName.Text = "प्रिंटर का नाम : " + ddlPrinter.SelectedItem.Text;
            }
            else
            {
                lblPrinterName.Text = "";
            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e) 
    {
       // LoadMachineDescription();
    }

    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PrinterMachine.xls"));
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

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadMachineDescription();
    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        ExportToExcell();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Academic;
using System.Data;
using System.IO;

public partial class Printing_Rpt_PaperCalReport : System.Web.UI.Page
{
    TitleMaster obTitleMaster = null;
    CommonFuction obCommonFunction = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            obTitleMaster = new TitleMaster();
            if (!IsPostBack)
            {
                FillAcademicYr();
            }
        }
        catch { }
        finally { obTitleMaster = null; }

    }

    private void FillGrid()
    {
        try
        {
            var PrinterId = "0";
            if (ddlPrinterName.SelectedIndex == 0)
            {
                PrinterId = "0";
            }
            else
            {
                PrinterId = ddlPrinterName.SelectedValue;
            }
            DataTable dt = obCommonFunction.FillTableByProc("call USP_ACD001_PaperCalReport('" + ddlAcademicYr.SelectedItem.Text + "','" + PrinterId + "')");
            if (dt.Rows.Count > 0)
            {
                lblAcYrInfo.Text = ddlAcademicYr.SelectedItem.Text;
                lblDate.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
                GrdTitle.DataSource = dt;
                GrdTitle.DataBind();
                tdPrintContent.Visible = true;
                tdNORecord.Visible = false;
            }
            else
            {
                tdPrintContent.Visible = false;
                tdNORecord.Visible = true;
            }

        }
        catch
        { }
        finally
        { obTitleMaster = null; }
    }

    protected void GrdTitle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTitle.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FillGrid();
        }
        catch { }
        finally { }
    }
    public void FillAcademicYr()
    {
        try
        {
            obTitleMaster = new TitleMaster();
            obTitleMaster.ID = 4;
            ddlAcademicYr.DataSource = obTitleMaster.FillReport();
            ddlAcademicYr.DataValueField = "Id";
            ddlAcademicYr.DataTextField = "AcYear";
            ddlAcademicYr.DataBind();

            CommonFuction comm = new CommonFuction();

            DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrder(0,'" + ddlAcademicYr.SelectedItem.Text + "')");
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "All");
        }
        catch { }
        finally { obTitleMaster = null; }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ////FillGrid();
        //Class1 cls = new Class1();
        //cls.Export("RSK_FreeBooksSupplyInformation.xls", GrdLetterInfo, "रा०शि०के से नि:शुल्क पुस्तकों की मांग की स्थिति");
        ExportToExcell();
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Rpt_PaperCalReport.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
}
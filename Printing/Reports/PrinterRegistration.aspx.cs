using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
 
using System.IO;

public partial class Printing_Reports_PrinterRegistration : System.Web.UI.Page
{
   
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblAcYearRpt.Text = obCommonFuction.GetFinYear();
            lblDate.Text = System.DateTime.Now.ToString("MMM dd,yyyy");
            load();
        }
    }


    public void load()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();

        try
        {
            obPRI_PrinterRegistration.Printer_RedID_I = 0;

            grdPrinterRegistration.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            grdPrinterRegistration.DataBind();
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }


    

    //public void ExportToExcell()
    //{
    //    Response.ClearContent();
    //    Response.Buffer = true;
    //    Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PrinterDetail.xls"));
    //    Response.ContentType = "application/ms-excel";
    //    StringWriter sw = new StringWriter();
    //    HtmlTextWriter htw = new HtmlTextWriter(sw);
    //    grdPrinterRegistration.AllowPaging = false;
    //    //Change the Header Row back to white color
    //    grdPrinterRegistration.HeaderRow.Style.Add("background-color", "#FFFFFF");
    //    //Applying stlye to gridview header cells

    //    for (int i = 0; i < grdPrinterRegistration.HeaderRow.Cells.Count; i++)
    //    {
    //        grdPrinterRegistration.HeaderRow.Cells[i].Style.Add("background-color", "#F6F6F6");
    //    }
    //    int j = 1;
    //    //This loop is used to apply stlye to cells based on particular row
    //    foreach (GridViewRow gvrow in grdPrinterRegistration.Rows)
    //    {
    //        gvrow.BackColor = System.Drawing.Color.White;
    //        if (j <= grdPrinterRegistration.Rows.Count)
    //        {
    //            if (j % 2 != 0)
    //            {
    //                for (int k = 0; k < gvrow.Cells.Count; k++)
    //                {
    //                    gvrow.Cells[k].Style.Add("background-color", "#CCCCCC");
    //                }
    //            }
    //        }
    //        j++;
    //    }

    //    ExportDiv.RenderControl(htw);
    //    Response.Write(sw.ToString());
    //    Response.End();
    //}


    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PrinterRegistration.xls"));
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
}
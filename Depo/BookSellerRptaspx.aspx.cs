using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;

public partial class Depo_BookSellerRptaspx : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                BookSellerDemand obBookSellerDemand = new BookSellerDemand();
                obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
                obBookSellerDemand.DBookSelleDemandTrNo_I = -2;
                DataSet Demand = obBookSellerDemand.Select();
                grnMain.DataSource = Demand;
                grnMain.DataBind();
                if (grnMain.Rows.Count > 0)
                {
                    btnExport.Visible = true;
                    btnExportPDF.Visible = true;
                }
            }
            catch { }
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
}
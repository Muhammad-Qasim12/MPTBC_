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

public partial class Depo_BookReturnReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DepoReport obDepoReport = new DepoReport();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtTodate.Text, cult) < DateTime.Parse(txtFromdate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('दिनांक तक  दिनांक से से बड़ी चुने .');</script>");
        }
        else
        {
            obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
            obDepoReport.fromdate = Convert.ToDateTime(txtFromdate.Text, cult);
            obDepoReport.Todate = Convert.ToDateTime(txtTodate.Text, cult);
            DataSet ds = obDepoReport.GetBookReturnDetails();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                btnExport.Visible = true;
                btnExportPDF.Visible = true;
            }
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
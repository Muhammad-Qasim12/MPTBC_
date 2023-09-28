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
public partial class Depo_BankDarftReport : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obcm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromdate.Text = "01/03/2019";
            txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtTodate.Text, cult) < DateTime.Parse(txtFromdate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('दिनांक तक  दिनांक से से बड़ी चुने  .');</script>");
        }
        else
        {
            //obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
            //obDepoReport.fromdate = Convert.ToDateTime(txtFromdate.Text, cult);
            //obDepoReport.Todate = Convert.ToDateTime(txtTodate.Text, cult);
            //DataSet ds = obDepoReport.GetBooksellerBankDraft();

            GridView1.DataSource = obcm.FillDatasetByProc("call USP_DPTBookSellerBankDetails(" + Session["UserID"].ToString() + ",'" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "')"); ;
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                btnExport.Visible = true;
                btnExportPDF.Visible = true;
            }
           
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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
    Double TotalSamany,Total;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                   // TextBox txtSamany = (TextBox)e.Row.FindControl("txtSamany");
                    TotalSamany +=Convert.ToDouble (e.Row.Cells[5].Text) ;
                    Total+=Convert.ToDouble (e.Row.Cells[6].Text) ;
                }
                catch { }
               


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[5].Text = TotalSamany.ToString();
            e.Row.Cells[6].Text = Total.ToString();
           // e.Row.Cells[3].Text = TotalSamany.ToString();

        }
    }
}
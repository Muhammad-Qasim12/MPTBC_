using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using Microsoft.Reporting.WebForms;
using System.IO;
public partial class Paper_PaperReport_LOIReport : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CommonFuction obCommonFuction = new CommonFuction();
    float Amt = 0, TotQty = 0, TotPkg = 0;
    string PaperVendorTrId_I = "";
    public string chalanID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    public void LoadReport(string Flag)
    {
        if (ddlChallanNo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select Invoice No.');</script>");
        }
        else
        {

            Dt = objReports.ExciseChallanDetails(ddlChallanNo.SelectedItem.Value);
            if (Dt.Rows.Count > 0)
            {
                tdPrintContent.Visible = true;
                lblChallanDate.Text = Dt.Rows[0]["ChallanDate"].ToString();
                chalanID = Dt.Rows[0]["ChallanDate"].ToString();
                lblChallanNo.Text = Dt.Rows[0]["ChallanNo"].ToString();
                lblGrDate.Text = Dt.Rows[0]["GRDate"].ToString();
                lblGrNo.Text = Dt.Rows[0]["GRNo"].ToString();
                lblInvoiceDate.Text = Dt.Rows[0]["ChallanDate"].ToString();
                lblInvoiceNo.Text = Dt.Rows[0]["ChallanNo"].ToString();
                lblPanNo.Text = Dt.Rows[0]["PaperVendorPanNo_V"].ToString();
                lblPaperMillName.Text = Dt.Rows[0]["PaperVendorName_V"].ToString().ToUpper();
                lblTanNo.Text = Dt.Rows[0]["PaperVendorTanNo_V"].ToString();
                lblTinNo.Text = Dt.Rows[0]["PaperVendorTinNo_V"].ToString();
                lblVehicleNo.Text = Dt.Rows[0]["TruckNo"].ToString();
                Panel1.Visible = true;
                GridView1.DataSource = Dt;
                GridView1.DataBind();
            }
            else
            {
                tdPrintContent.Visible = false;
                Panel1.Visible = false;
                GridView1.DataSource = string.Empty;
                GridView1.DataBind();
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport("LabInspection");
    }
    protected void ddlChallanNo_Init(object sender, EventArgs e)
    {
        
        objReports = new PPR_RDLCData();
        ddlChallanNo.DataSource = objReports.ExciseChallanFill(Session["UserID"].ToString());
        ddlChallanNo.DataTextField = "ChallanNo";
        ddlChallanNo.DataValueField = "DisTranId";
        ddlChallanNo.DataBind();
        ddlChallanNo.Items.Insert(0, "Select");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            Label lblQty = (Label)e.Row.FindControl("lblQty");
            Label lblRate = (Label)e.Row.FindControl("lblRate");
            Label lblSndrReel = (Label)e.Row.FindControl("lblSndrReel");

            try
            {
                TotQty = TotQty + (float.Parse(lblQty.Text));
            }
            catch { TotQty = 0; }
            try
            {
                TotPkg = TotPkg + (float.Parse(lblSndrReel.Text));
            }
            catch { TotPkg = 0; }
            try
            {
                Amt = Amt + (float.Parse(lblQty.Text) * float.Parse(lblRate.Text));
            }
            catch { Amt = 0; }
            lblAmount.Text = (float.Parse(lblQty.Text) * float.Parse(lblRate.Text)).ToString();
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {

            Label lblFQty = (Label)e.Row.FindControl("lblFQty");
            Label lblFSndrReel = (Label)e.Row.FindControl("lblFSndrReel");
            Label lblFAmount = (Label)e.Row.FindControl("lblFAmount");

            lblFSndrReel.Text = TotPkg.ToString();
            lblFQty.Text = TotQty.ToString();
            lblFAmount.Text = Amt.ToString("0.00");
            float Eduty = 0, SubTotalAmt = 0;

            try
            {
                Eduty = (Amt * 6 / 100);
                lblExciesDuty.Text = Eduty.ToString("0.00");
            }
            catch { }
            try
            {
                lblCessOnPaper.Text = (Amt * 0.125 / 100).ToString("0.00");
            }
            catch { }
            try
            {
                lblEduc.Text = (Eduty * 2 / 100).ToString("0.00");
            }
            catch { }
            try
            {
                lblSHEdu.Text = (Eduty * 1 / 100).ToString("0.00");
            }
            catch { }
            try
            {

                lblSubTotal.Text = (Amt + Eduty + float.Parse(lblCessOnPaper.Text) + float.Parse(lblEduc.Text) + float.Parse(lblSHEdu.Text)).ToString("0.00");
                SubTotalAmt = float.Parse(lblSubTotal.Text);
            }
            catch { }
            try
            {
                lblCST.Text = (SubTotalAmt * 2 / 100).ToString("0.00");
            }
            catch { }
            try
            {
                lblInsurance.Text = (SubTotalAmt * .15 / 100).ToString("0.00");
            }
            catch { }
            try
            {
                lblGrandTotal.Text = (SubTotalAmt + float.Parse(lblCST.Text) + float.Parse(lblInsurance.Text)).ToString("0.00");
            }
            catch { }
        }
    }

    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ExciseInvoiceReport.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

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
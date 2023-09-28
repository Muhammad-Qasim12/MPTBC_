using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Paper;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;

public partial class Paper_PaperReport_RPT_VoucherDetails_MilWise : System.Web.UI.Page
{
    DataSet ds;
    ppr_VoucharDetails objPaperVoucharDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    double Amount = 0, Weight = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void GV_RPT_VOUCHER_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    public void Vendorfill()
    {
        PPR_BillGenerate ObjBillGenerate = null;
        ObjBillGenerate = new PPR_BillGenerate();
        ddlVendorName.DataSource = ObjBillGenerate.VendorFill();
        ddlVendorName.DataValueField = "PaperVendorTrId_I";
        ddlVendorName.DataTextField = "PaperVendorName_V";
        ddlVendorName.DataBind();
        ddlVendorName.Items.Insert(0, "ALL");
    }
    protected void ddlVendorName_Init(object sender, EventArgs e)
    {
        Vendorfill();
    }
    public void ddlPaymentTypeFill()
    {
        ddlPaymentType.Items.Insert(0, "Select");
        ddlPaymentType.Items.Insert(1, "90 %");
        ddlPaymentType.Items.Insert(2, "08 %");
        ddlPaymentType.Items.Insert(3, "Thabba");
        ddlPaymentType.Items.Insert(4, "02 %");

    }
    protected void ddlPaymentType_Init(object sender, EventArgs e)
    {
        ddlPaymentTypeFill();
        Panel1.Visible = false;
    }
    protected void ddlPaymentType_SelectedIndexChanged(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    public void ddlYearFill()
    {
        Dis_TentativeDemandHistory objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlAcYear.DataSource = objTentativeDemandHistory.TentativeDemandAcadminYearFill();
        ddlAcYear.DataTextField = "AcYear";
        ddlAcYear.DataValueField = "AcYear";
        ddlAcYear.DataBind();
        ddlAcYear.Items.Insert(0, "Select");
        ddlAcYear.SelectedItem.Text = "2016-2017";
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        ddlYearFill();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "ViewDefectiveReelStsChange.xls"));
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindGridVoucherDetails();
        }
        catch { }
    }
    private void BindGridVoucherDetails()
    {
        Panel1.Visible = true;

        string acYr = ddlAcYear.SelectedItem.Text;
        int PaperVendorId = Convert.ToInt32(ddlVendorName.SelectedValue);
        string PaymentType = ddlPaymentType.SelectedItem.Text;
        objPaperVoucharDetails = new ppr_VoucharDetails();
        lblYr.Text = acYr.ToString();
        lblPercent.Text = PaymentType.ToString();
        lblDate.Text = "Date: " + System.DateTime.Now.Date.ToString("dd/MM/yyyy");
        ds = this.VoucharDetailMillWise(acYr, PaperVendorId, PaymentType);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GV_RPT_VOUCHER.DataSource = ds.Tables[0];
                    GV_RPT_VOUCHER.DataBind();
                }
            }

        }


    }
    public System.Data.DataSet VoucharDetailMillWise(string acYr, int PaperVendorId, string PaymentType)
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_VOUCHER_DETAILS_MILLWISE", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mAcYear", acYr);
        obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorId);
        obDBAccess.addParam("mPaymentType", PaymentType);

        return obDBAccess.records();
    }


    protected void GV_RPT_VOUCHER_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            Label lblWeight = (Label)e.Row.FindControl("lblWeight");

            try
            {
                Amount = Amount + double.Parse(lblAmount.Text);
            }
            catch { Amount = 0; }
            try
            {
                Weight = Weight + double.Parse(lblWeight.Text);
            }
            catch { Weight = 0; }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblF100Amount = (Label)e.Row.FindControl("lblF100Amount");
            Label lblFWeight = (Label)e.Row.FindControl("lblFWeight");

            lblF100Amount.Text = Amount.ToString("0.00");
            lblFWeight.Text = Weight.ToString("0.00");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using System.IO;

public partial class Paper_PaperReport_WorkPlanReports : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    PPR_WorkPlan objWorkPlan = null;
    CommonFuction obCommonFuction = new CommonFuction();
    string PaperVendorTrId_I = "";
    decimal TotAmount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            LOIIDFill();
        }
        DdlACYear.Enabled = false;
    }
    public void venderFill()
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        objWorkPlan = new PPR_WorkPlan();
        ddlVendor.DataSource = objWorkPlan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "All");
        try
        {
            ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
        }
        catch { }
        ddlVendor.Enabled = false;
        //LOIIDFill();
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }

    public void LOIIDFill()
    {
        if (ddlVendor.SelectedItem.Text != "All")
        {
            //objWorkPlan = new PPR_WorkPlan();
            //objWorkPlan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            //ddlLOINo.DataSource = objWorkPlan.LOINoFill();
            //ddlLOINo.DataTextField = "LOINo_V";
            //ddlLOINo.DataValueField = "LOITrId_I";
            //ddlLOINo.DataBind();
            ppr_VoucharDetails objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetLoiByVendorandAcYear(" + objPaperVoucharDetails.PaperVendorTrId_I + ",'" + DdlACYear.SelectedItem.Text + "')");
            //ddlLOINo.DataSource = objPaperVoucharDetails.LOINoFill();
            ddlLOINo.DataSource = ds1.Tables[0];

            ddlLOINo.DataTextField = "LOINo_V";
            ddlLOINo.DataValueField = "LOITrId_I";
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "All");
        }
        else
        {
            ddlLOINo.DataSource = string.Empty;
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "All");

        }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIIDFill();
    }
    public void fillParameter()
    {
        CommonFuction comm = new CommonFuction();
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
        try
        {
            DdlACYear.Items.FindByText(obCommonFuction.GetFinYear ()).Selected = true;
        }
        catch { }
    }
    protected void DdlACYear_Init(object sender, EventArgs e)
    {
        fillParameter();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIIDFill();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlLOINo.SelectedItem.Text == "All")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select LOI Number');</script>");
        }
        else
        {
            Dt = objReports.WorkPlanDetails(ddlLOINo.SelectedItem.Value.ToString(), PaperVendorTrId_I);
            if (Dt.Rows.Count > 0)
            {
                lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");
                lblYear.Text = DdlACYear.SelectedItem.Text;
                lblTitle.Text = "पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " एल.ओ.आई. क्रमांक  : " + ddlLOINo.SelectedItem.Text.Replace("All", "सभी");
    
                tdPrintContent.Visible = true;
                GridView1.DataSource = Dt;
                GridView1.DataBind();
            }
            else
            {
                lblDate.Text = "";
                lblYear.Text = "";
                lblTitle.Text = "";
                tdPrintContent.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
            }
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView GrdLabInspection = (GridView)e.Row.FindControl("GrdLabInspection");
            Label lblVouchar_Tr_Id = (Label)e.Row.FindControl("lblVouchar_Tr_Id");
            dt = objReports.WorkPlanChildDetails(lblVouchar_Tr_Id.Text);
            if (dt.Rows.Count > 0)
            {
                TotAmount = 0;
                GrdLabInspection.DataSource = dt;
                GrdLabInspection.DataBind();
            }
        }
    }
    protected void GrdLabInspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblToAmount = (Label)e.Row.FindControl("lblToAmount");
            try
            {
                TotAmount = TotAmount + decimal.Parse(lblToAmount.Text);
            }
            catch { TotAmount = 0; }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblToAmountF = (Label)e.Row.FindControl("lblToAmountF");

            lblToAmountF.Text = TotAmount.ToString("0.00");
        }
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "VndrWorkPlanReports.xls"));
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

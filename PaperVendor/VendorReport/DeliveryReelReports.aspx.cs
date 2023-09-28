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
    ppr_DeliveryChallan objDeliveryChallan = null;
    CommonFuction obCommonFuction = new CommonFuction();
    string PaperVendorTrId_I = "";
    double TotSheetWt = 0, TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            ChallanFill();
        }
        DdlACYear.Enabled = false;
    }
    public void venderFill()
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        objDeliveryChallan = new ppr_DeliveryChallan();
        ddlVendor.DataSource = objDeliveryChallan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
        ddlVendor.ClearSelection();
        try
        {
            ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
           // ChallanFill();
        }
        catch { }
        ddlVendor.Enabled = false;
    }

    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }

    public void ChallanFill()
    {
        if (ddlVendor.SelectedItem.Text != "Select")
        {
            objDeliveryChallan = new ppr_DeliveryChallan();
            objDeliveryChallan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            ddlChallanNo.DataSource = objDeliveryChallan.ChallanFill();
            ddlChallanNo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_GetChallanListByAcYear(" + objDeliveryChallan.PaperVendorTrId_I + ",'"+DdlACYear.SelectedItem.Text+"')");
            ddlChallanNo.DataTextField = "ChallanNo";
            ddlChallanNo.DataValueField = "DisTranId";
            ddlChallanNo.DataBind();
            ddlChallanNo.Items.Insert(0, "Select");
        }
        else
        {
            ddlChallanNo.DataSource = string.Empty;
            ddlChallanNo.DataBind();
            ddlChallanNo.Items.Insert(0, "Select");
        }
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
        DdlACYear.Enabled = false;
    }
    protected void DdlACYear_Init(object sender, EventArgs e)
    {
        fillParameter();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChallanFill();
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChallanFill();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlChallanNo.SelectedItem.Text == "Select")
        {
            tdPrintContent.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select Challan No');</script>");
        }
        else
        {
            GridFill();
        }
    }
    public void GridFill()
    {
        DataSet dsr = new DataSet();
       // Dt = objReports.DeliveryChallanDetails(ddlChallanNo.SelectedItem.Text.ToString());
        CommonFuction comm = new CommonFuction();
        dsr = obCommonFuction.FillDatasetByProc("CALL USP_PPR0020_LabInspectionReportsRDLCNew('" + ddlChallanNo.SelectedItem.Text.ToString() + "','','" + DdlACYear.SelectedItem.Text + "',13)");
        //USP_PPR0020_LabInspectionReportsRDLC
        Dt = dsr.Tables[0];
        if (Dt.Rows.Count > 0)
        {
            lblYear.Text = DdlACYear.SelectedItem.Text;
            lblTitle.Text = "पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " चालान क्रमांक : " + ddlChallanNo.SelectedItem.Text.Replace("All", "सभी");
            lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");

            GridView1.DataSource = Dt;
            GridView1.DataBind();
            tdPrintContent.Visible = true;
        }
        else
        {
            lblYear.Text = "";
            lblDate.Text = "";
            lblTitle.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
            tdPrintContent.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView GrdLabInspection = (GridView)e.Row.FindControl("GrdLabInspection");
            Label lblVouchar_Tr_Id = (Label)e.Row.FindControl("lblVouchar_Tr_Id");
            dt = objReports.DeliveryChallanChildDetails(lblVouchar_Tr_Id.Text);
            if (dt.Rows.Count > 0)
            {
                TotSheetWt = 0; TotNet = 0; TotGrossWt = 0;
                GrdLabInspection.DataSource = dt;
                GrdLabInspection.DataBind();
            }
        }
    }
    protected void GrdLabInspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");

            try
            {
                TotSheetWt = TotSheetWt + double.Parse(lblTotalSheets.Text);
            }
            catch { }
            try
            {
                TotNet = TotNet + double.Parse(lblNetWt.Text);
            }
            catch { }
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text);
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFTotalSheets = (Label)e.Row.FindControl("lblFTotalSheets");
            Label lblFNetWt = (Label)e.Row.FindControl("lblFNetWt");
            Label lblFGrossWt = (Label)e.Row.FindControl("lblFGrossWt");

            lblFTotalSheets.Text = TotSheetWt.ToString("0.000");
            lblFNetWt.Text = TotNet.ToString("0.000");
            lblFGrossWt.Text = TotGrossWt.ToString("0.000");
        }
    }

    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "DeliveryReelReports.xls"));
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

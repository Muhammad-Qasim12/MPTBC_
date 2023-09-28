using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;
using System.IO;

public partial class ViewDefectiveReelStsChange : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    PPR_PaperMaster ObjPaperMaster = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    double TotPreNet = 0, TotPreGrossWt = 0, TotNet = 0, TotGrossWt = 0, TotSheet = 0;
    string CntrDepot_Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            //GridFillLoad();
            PaperTypeFill();
            Vendorfill();
            ddlYearFill();
        }
    }
    public void PaperTypeFill()
    {
        ObjPaperMaster = new PPR_PaperMaster();
        ddlPaperType.DataSource = ObjPaperMaster.PaperTypeFill();
        ddlPaperType.DataValueField = "PaperType_Id";
        ddlPaperType.DataTextField = "PaperType";
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "ALL");
    }
    public void QualityFill()
    {
        if (ddlPaperType.SelectedItem.Text != "ALL")
        {
            ObjPaperMaster = new PPR_PaperMaster();
            ObjPaperMaster.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
            ddlPaperSize.DataSource = ObjPaperMaster.QualityTypeFill();
            ddlPaperSize.DataValueField = "Qualifyid_I";
            ddlPaperSize.DataTextField = "QualifyType";
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "ALL");
        }
    }

    public void GridFillLoad()
    {
        lblYr.Text = ddlAcYear.SelectedItem.Text;
        Panel1.Visible = true;
        string PaperVendorId = ddlVendorName.SelectedValue;
        string AcYr = ddlAcYear.SelectedItem.Text;
        string PaperType = ddlPaperType.SelectedValue;
        string PaperSize = ddlPaperSize.SelectedValue;
        string ChallanNo = txtChallanNo.Text;
        string RollNo = txtRollNo.Text;
        lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("dd MMM yyyy");
        try
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_CD_RPT_VW_DEFECTIVE_REEL( '" + AcYr + "','" + PaperVendorId + "','" + ChallanNo + "','" + RollNo + "','" + PaperType + "','" + PaperSize + "' )");
            GrdLOI.DataBind();
        }
        catch { }

    }

    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            Label lblPreNetWt = (Label)e.Row.FindControl("lblPreNetWt");
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblPreGrossWt = (Label)e.Row.FindControl("lblPreGrossWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");


            foreach (TableCell cell in e.Row.Cells)
            {
                if (lblPreNetWt.Text != lblNetWt.Text)
                {
                    cell.BackColor = System.Drawing.Color.Green;
                    cell.ForeColor = System.Drawing.Color.Black;
                }
            }
            try { TotSheet = TotSheet + double.Parse(lblTotalSheets.Text); }
            catch { TotSheet = 0; }
            try { TotPreNet = TotPreNet + double.Parse(lblPreNetWt.Text); }
            catch (Exception)  {  TotPreNet = 0; }
            try  {  TotPreGrossWt = TotPreGrossWt + double.Parse(lblPreGrossWt.Text); }
            catch (Exception)  {  TotPreGrossWt = 0;  }
            try {       TotNet = TotNet + double.Parse(lblNetWt.Text);   }
            catch (Exception)   {  TotNet = 0; }
            try  {  TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text); }
            catch (Exception)  { TotGrossWt = 0; }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTtllSheets = (Label)e.Row.FindControl("lblTtllSheets");
            Label lblTtlPreNet = (Label)e.Row.FindControl("lblTtlPreNet");
            Label lblTtlPreGrossWt = (Label)e.Row.FindControl("lblTtlPreGrossWt");
            Label lblTtlNetWt = (Label)e.Row.FindControl("lblTtlNetWt");
            Label lblTtlGrossWt = (Label)e.Row.FindControl("lblTtlGrossWt");

            lblTtllSheets.Text = TotSheet.ToString("0.000");
            lblTtlPreNet.Text = TotPreNet.ToString("0.000");
            lblTtlPreGrossWt.Text = TotPreGrossWt.ToString("0.000");
            lblTtlNetWt.Text = TotNet.ToString("0.000");
            lblTtlGrossWt.Text = TotGrossWt.ToString("0.000");


            //lblTotNetWt.Text = TotNet.ToString("0.000");
            //lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
        }
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
        }
        catch { }
    }



    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        QualityFill();
    }
    protected void ddlPaperSize_Init1(object sender, EventArgs e)
    {
        ddlPaperSize.DataSource = string.Empty;
        ddlPaperSize.DataBind();
        ddlPaperSize.Items.Insert(0, "ALL");
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
    public void ddlYearFill()
    {
        Dis_TentativeDemandHistory objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlAcYear.DataSource = objTentativeDemandHistory.TentativeDemandAcadminYearFill();
        ddlAcYear.DataTextField = "AcYear";
        ddlAcYear.DataValueField = "AcYear";
        ddlAcYear.DataBind();
        ddlAcYear.Items.Insert(0, "Select");
        try
        {
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
        }
        catch { }
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

}
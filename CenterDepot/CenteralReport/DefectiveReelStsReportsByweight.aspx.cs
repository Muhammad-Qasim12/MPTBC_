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
using System.IO;

public partial class DefectiveReelStsReportsByweight : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    double TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        btnSearch.Enabled = false;
        if (!Page.IsPostBack)
        {
            FillACYear();
           // GridFillLoad();
        }
    }

    public void venderFill()
    {

        ddlVendor.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtl(0,0,0,0,0,0,'',4)");
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "All");
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }
    public void LOIIDFill()
    {
        if (ddlVendor.SelectedItem.Text != "All")
        {

            ddlChallanNo.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtl(0,'" + ddlVendor.SelectedItem.Value + "',0,0,0,0,'',5)");
            ddlChallanNo.DataTextField = "ChallanNo"; 
            ddlChallanNo.DataBind();
            ddlChallanNo.Items.Insert(0, "All");
        }
        else
        {
            ddlChallanNo.DataSource = string.Empty;
            ddlChallanNo.DataBind();
            ddlChallanNo.Items.Insert(0, "All");

        }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIIDFill();
    }
    public void GridFillLoad()
    {
        try
        {
            lblYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblTitle.Text = "पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " चालान क्रमांक : " + ddlChallanNo.SelectedItem.Text.Replace("All", "सभी");
            lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");
            //objPaperDispatchDetails = new PPR_PaperDispatchDetails();

           // GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtlNew(0,'" + ddlVendor.SelectedItem.Value + "',0,0,0,'" + ddlChallanNo.SelectedItem.Value + "','',2)");
          //  GrdLOI.DataBind();
        }
        catch { }

    }
    
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      //  GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    protected void GvReelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            Label lblTotStock = (Label)e.Row.FindControl("lblTotStock");


            foreach (TableCell cell in e.Row.Cells)
            {
                if (lblTotStock.Text == "0.000 Sheets" || lblTotStock.Text == "Used")
                {
                    cell.BackColor = System.Drawing.Color.Green;
                    cell.ForeColor = System.Drawing.Color.White;
                }
            }
            
            try
            {
                TotNet =TotNet+ double.Parse(lblNetWt.Text);
            }
            catch { TotNet = 0; }

            try
            { TotGrossWt =TotGrossWt+ double.Parse(lblGrossWt.Text); }
            catch { TotGrossWt = 0; }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");
            Label lblTotGrossWt = (Label)e.Row.FindControl("lblTotGrossWt");
            lblTotNetWt.Text = TotNet.ToString("0.000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
        }
    }
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView GvReelDetails = (GridView)e.Row.FindControl("GvReelDetails");
            Label lblChallanNo = (Label)e.Row.FindControl("lblChallanNo");
            Label lblPaperVendorTrId_I = (Label)e.Row.FindControl("lblPaperVendorTrId_I");
            TotNet = Convert.ToDouble(txtSearchWeight.Text);
            TotGrossWt = 0;
            if (ddlUsed.SelectedIndex > 0)
            {
                if (ddlUsed.SelectedItem.Text == "Used")
                {
                    GvReelDetails.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtlNew(0,'" + lblPaperVendorTrId_I.Text + "',0," + TotNet + ",0,'" + lblChallanNo.Text + "','',33)");
                    GvReelDetails.DataBind();
                }
                else if (ddlUsed.SelectedItem.Text == "Unused")
                {
                    GvReelDetails.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtlNew(0,'" + lblPaperVendorTrId_I.Text + "',0," + TotNet + ",0,'" + lblChallanNo.Text + "','',3)");
                    GvReelDetails.DataBind();
                }
          }
        }
    }
     
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
           // GridFillLoad();
            if (ddlUsed.SelectedIndex > 0)
            {
                lblYear.Text = ddlAcYear.SelectedItem.Text;
                TotNet = Convert.ToDouble(txtSearchWeight.Text);
                if (ddlUsed.SelectedItem.Text == "Used")
                {
                    GvReelDetails.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtlNew(0,'" + ddlVendor.SelectedValue + "','"+ddlAcYear.SelectedItem.Text+"'," + TotNet + ",0,'" + 0 + "','',33)");
                    GvReelDetails.DataBind();
                }
                else if (ddlUsed.SelectedItem.Text == "Unused")
                {
                    GvReelDetails.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtlNew(0,'" + ddlVendor.SelectedValue + "','" + ddlAcYear.SelectedItem.Text + "'," + TotNet + ",0,'" + 0 + "','',3)");
                    GvReelDetails.DataBind();
                }
            }
        }
        catch { }
    }
    protected void FillACYear()
    {
        ds = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
        ddlAcYear.DataSource = ds.Tables[0];
        ddlAcYear.DataTextField = "AcYear";
        ddlAcYear.DataBind();
        //ddlAcYear.Items.Insert(0, "Select");
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BundelReelDetails.xls"));
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
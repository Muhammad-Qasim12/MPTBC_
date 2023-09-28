using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;
using System.IO;

public partial class PaperVendor_VendorReport_VendorDispatch : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    PPR_WorkPlan objWorkPlan = null;
    CommonFuction obCommonFuction = new CommonFuction();
    string PaperVendorTrId_I = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
        }
    }
    public void venderFill()
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        objWorkPlan = new PPR_WorkPlan();
        ddlVendor.DataSource = objWorkPlan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
        try
        {
            ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
        }
        catch { }
        ddlVendor.Enabled = false;
        LOIIDFill();
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }

    public void LOIIDFill()
    {
        if (ddlVendor.SelectedItem.Text != "All")
        {
            objWorkPlan = new PPR_WorkPlan();
            objWorkPlan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            ddlLOINo.DataSource = objWorkPlan.LOINoFill();
            ddlLOINo.DataTextField = "LOINo_V";
            ddlLOINo.DataValueField = "LOITrId_I";
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "Select");
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
    public void SearchFill()
    {
        Dt = objReports.VendorDisptchFill(PaperVendorTrId_I, ddlLOINo.SelectedItem.Value.ToString());
        if (Dt.Rows.Count > 0)
        {
            lblYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblTitle.Text = "पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " एल.ओ.आई. क्रमांक  : " + ddlLOINo.SelectedItem.Text.Replace("All", "सभी");
            lblDate.Text = System.DateTime.Now.ToString("MMM dd, yyyy");

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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchFill();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView GrdLabInspection = (GridView)e.Row.FindControl("GrdLabInspection");
            Label lblVouchar_Tr_Id = (Label)e.Row.FindControl("lblVouchar_Tr_Id");
            dt = objReports.VendorChildDisptchFill(PaperVendorTrId_I, lblVouchar_Tr_Id.Text);
            if (dt.Rows.Count > 0)
            {
                GrdLabInspection.DataSource = dt;
                GrdLabInspection.DataBind();
            }
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        SearchFill();
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "VendorDispatch.xls"));
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

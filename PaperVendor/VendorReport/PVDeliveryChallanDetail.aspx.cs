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

public partial class PaperVendor_VendorReport_Default : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    PPR_WorkPlan objWorkPlan = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlVendor.SelectedValue = Session["UserID"].ToString();
        
        if (!Page.IsPostBack)
        {
            LOIIDFill();
        }
        DdlACYear.Enabled = true;
    }
    public void venderFill()
    {

        objWorkPlan = new PPR_WorkPlan();
        ddlVendor.DataSource = objWorkPlan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");


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
            //objWorkPlan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            //ddlLOINo.DataSource = objWorkPlan.LOINoFill();
            //ddlLOINo.DataTextField = "LOINo_V";
            //ddlLOINo.DataValueField = "LOITrId_I";
            //ddlLOINo.DataBind();
            //ddlLOINo.Items.Insert(0, "Select");
            ppr_VoucharDetails objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetLoiByVendorandAcYear(" + objPaperVoucharDetails.PaperVendorTrId_I + ",'" + DdlACYear.SelectedItem.Text + "')");
            //ddlLOINo.DataSource = objPaperVoucharDetails.LOINoFill();
            ddlLOINo.DataSource = ds1.Tables[0];

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
        if (ddlLOINo.SelectedItem.Text != "Select")
        {
            FillGridLOI();
        }
        else
        {
            Response.Write("<script>alret('Please select LOI No.')</script>");
        }

    }
    private void FillGridLOI()
    {
        if (ddlVendor.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select Paper Mill');</script>");
        }
        else
        {
            Dt = objReports.VendorChildDisptchFillPMill(ddlVendor.SelectedItem.Value, ddlLOINo.SelectedItem.Value.ToString());
            if (Dt.Rows.Count > 0)
            {
                lblYear.Text = DdlACYear.SelectedItem.Text;
                lblTitle.Text = "पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " एल.ओ.आई. क्रमांक : " + ddlLOINo.SelectedItem.Text.Replace("All", "सभी");
                lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");
                tdPrintContent.Visible = true;
                GridView1.DataSource = Dt;
                GridView1.DataBind();
            }
            else
            {
                tdPrintContent.Visible = false;
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
    }

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
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGridLOI();
    }
}
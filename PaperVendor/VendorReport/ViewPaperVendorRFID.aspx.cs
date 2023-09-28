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
using MPTBCBussinessLayer;
using System.Globalization;
using System.IO;

public partial class ViewPaperVendorRFID : System.Web.UI.Page
{
    DataSet ds;
    PPR_WorkPlan objWorkPlan = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string PaperVendorTrId_I = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            PaperVendorTrId_I = Session["UserID"].ToString();
            if (!Page.IsPostBack)
            {
                lblAcYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
                ViewState["WorkPlanTrId_I"] = "";
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
                DdlACYear.Enabled = false;

                GetRFID_No();
            }
        }
    }
    public void venderFill()
    {
        if (Session["UserID"] != null)
        {
            PaperVendorTrId_I = Session["UserID"].ToString();
            objWorkPlan = new PPR_WorkPlan();
            ddlVendor.DataSource = objWorkPlan.VenderFill();
            ddlVendor.DataTextField = "PaperVendorName_V";
            ddlVendor.DataValueField = "PaperVendorTrId_I";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, "Select");
            ddlVendor.ClearSelection();
            try
            {
                ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
            }
            catch { }
            ddlVendor.Enabled = false;
        }
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetRFID_No();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GetRFID_No();
    }
    public void GetRFID_No()
    {
        try
        {
            ds = obCommonFuction.FillDatasetByProc("CALL USP_GetRFID_No('" + ddlVendor.SelectedValue + "','" + DdlACYear.SelectedValue + "')");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                tdPrintContent.Visible = true;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                tdPrintContent.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
            }

        }
        catch (Exception ex)
        {
        }
    }
    // EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PaperVendorRFID.xls"));
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

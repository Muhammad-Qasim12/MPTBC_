using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Academic;

public partial class Distribution_SchemeMappingReport : System.Web.UI.Page
{
    DataTable Dt, dt; 
    CommonFuction obCommonFuction = new CommonFuction();
    TitleWiseSchemeMapping obTitleWise;
    TitleMaster obTitleMaster = new TitleMaster ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SchemeFill();
            obTitleMaster.ID = 4;
            ddlAcademicYr.DataSource = obTitleMaster.FillReport();
            ddlAcademicYr.DataValueField = "AcYear";
            ddlAcademicYr.DataTextField = "AcYear";
            ddlAcademicYr.DataBind();
        }
    }
    public void SchemeFill()
    {
        obTitleWise = new TitleWiseSchemeMapping();
        obTitleWise.Classes = "0";
        ddlScheme.DataSource = obTitleWise.LoadScheme();
        ddlScheme.DataTextField = "SchemeName_Hindi";
        ddlScheme.DataValueField = "SchemeId";
        ddlScheme.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlScheme.SelectedItem.Text == "All")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select Scheme');</script>");
        }
        else
        {
            Dt = obCommonFuction.FillTableByProc("Call Usp_DIS_SchememDetailsNew('" + ddlScheme.SelectedItem.Value.ToString() + "','"+ddlAcademicYr.SelectedItem.Text+"')");
            if (Dt.Rows.Count > 0)
            {
                lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");
                lblYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
                lblTitle.Text = "योजना का नाम   : " + ddlScheme.SelectedItem.Text.Replace("All", "सभी");

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
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "SchemeMappingReport.xls"));
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
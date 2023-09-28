using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_AnupayogiBooks : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFyYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlFyYear.DataValueField = "AcYear";
            ddlFyYear.DataTextField = "AcYear";
            ddlFyYear.DataBind();
            ddlFyYear.SelectedValue = obCommonFuction.GetFinYear();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_depounpyogi('" + ddlFyYear.SelectedValue + "','" + Session["UserID"].ToString() + "')");
GridView1.DataBind ();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
           server control at run time. */
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }

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
}
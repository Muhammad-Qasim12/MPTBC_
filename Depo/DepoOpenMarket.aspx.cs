using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;

public partial class Depo_DepoOpenMarket : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    string classA;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_book2 ('" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + ", " + Convert.ToString(Session["UserID"]) + ",'" + DDLClass.SelectedValue + "') ");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
}
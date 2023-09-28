using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
public partial class Depo_TentyFiveperReport : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public APIProcedure api = new APIProcedure();
    public string mDtfrom, mDtto,myear ;
    public int PrinID;
    CommonFuction obCommanFun = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            PrinID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            
            mDtfrom = Convert.ToDateTime(Request.QueryString["dtfrom"], cult).ToString("yyyy-MM-dd");
            mDtto = Convert.ToDateTime(Request.QueryString["Dtto"], cult).ToString("yyyy-MM-dd");
            myear = Convert.ToString(Request.QueryString["myear"]) ;
            // DataSet ds = obCommanFun.FillDatasetByProc("call USP_DPTTwentyFiveReportPrinting(" + Convert.ToDateTime(Request.QueryString["dtfrom"], cult).ToString("dd/MM/yyyy") + "," + Convert.ToDateTime(Request.QueryString["dtto"], cult).ToString("dd/MM/yyyy") + ", " + Convert.ToInt32(Session["UserID"]) + "," + PrinID + ")");
            DataSet ds = obCommanFun.FillDatasetByProc("call USP_DPTTwentyFiveReportPrinting('" + mDtfrom + "','" + mDtto + "'," + Convert.ToInt32(Session["UserID"]) + "," + PrinID + ",'"+myear+"')");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
     
     
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public void ExportToExcell()
    {
        try {
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
        Response.Clear(); }catch {}
    }
    
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        ExportToExcell();
    }
}
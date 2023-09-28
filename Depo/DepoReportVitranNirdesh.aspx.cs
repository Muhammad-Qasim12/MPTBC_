using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_DepoReportVitranNirdesh : System.Web.UI.Page
{
    PPR_WorkPlan objWorkPlan = null;
    CommonFuction obCommonFuction = new CommonFuction();
    public APIProcedure api = new APIProcedure();
    protected string acdyr = ""; protected string dte = ""; protected string vendorDetail = ""; protected string dte11 = "";
    protected string totDefReel = "0"; protected string totTonDefReel = "0.0"; protected string sSetAcYr = "";
    double dTotReel = 0, dTotGrossWt = 0, dTotDefReel = 0, dTotDefWt = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            // lblPatraHeading.Text = "राज्य शिक्षा केंद्र से प्राप्त पत्र<br> क्रमांक 1340 दिनांक ................ के द्वारा .....................<br> की प्राप्त जिलेवार/ब्लोकवार मांग संख्या का वितरण  ";
            orderFill();
        }
    }


    public void orderFill()
    {

        //ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB_GetRptVitrannirdesh(-3,'',0,'" + DdlACYear.SelectedItem.Text + "')");
        //ddlOrderNo.DataTextField = "OrderNo";
        //ddlOrderNo.DataValueField = "OrderNo";
        //ddlOrderNo.DataBind();
        //ddlOrderNo.Items.Insert(0, "Select");
    }



    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }








    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetVitranDepo('" + DdlACYear.SelectedItem.Text + "',"+Session["UserID"].ToString ()+")");
        GridView1.DataBind();
       
        Session["VYear"] = DdlACYear.SelectedItem.Text;
    }



    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Button1_Click(null, null);
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GroupInformation.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        //ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    
}
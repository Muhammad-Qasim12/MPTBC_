using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_FinalReport : System.Web.UI.Page
{
    CountingDetails obCountingDetails = null;
    DepoReport obDepoReport = new DepoReport();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
      
            //obCountingDetails = new CountingDetails();
            //obCountingDetails.PinterID_I = Convert.ToInt32(Session["UserID"]); ;
        CommonFuction comm = new CommonFuction();
        DataSet ds = comm.FillDatasetByProc("call USP_DPT017_FillHundredPerPrinterDetailsNew(" + Session["UserID"] + ",'"+ddlSessionYear.SelectedValue+"')");
            grnMain.DataSource = ds.Tables[0];
            grnMain.DataBind();


            //obDepoReport.ID = Convert.ToInt32(Session["UserID"]);
            //obDepoReport.fromdate = Convert.ToDateTime(txtFromdate.Text, cult);
            //obDepoReport.Todate = Convert.ToDateTime(txtTodate.Text, cult);
         //  DataSet ds = obDepoReport.GetFinalCounting();
            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
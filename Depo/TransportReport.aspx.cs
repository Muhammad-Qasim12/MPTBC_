using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_TransportReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DepoReport obDepoReport = new DepoReport();
    public APIProcedure api = new APIProcedure();
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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  txtFromdate.Text = "01/04/2015";
           // txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
            DPT_DepotMaster obDPT_DepotMaster = null;
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
          

            lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CommonFuction comm = new CommonFuction();
            lblfyYaer.Text = comm.GetFinYear();
           
            ExportDiv.Visible = true;
            //obDepoReport.fromdate = ddlFyYear.SelectedValue;
            //obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
            //obDepoReport.ID = 0;
        //obCommonFuction 
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTTransproterReport(0,'"+ ddlFyYear.SelectedValue+"','2016-01-01',"+Session["UserID"]+")");

            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
}
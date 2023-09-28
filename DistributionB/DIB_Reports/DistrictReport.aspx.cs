using System;
using System.Data;
using MPTBCBussinessLayer.DistributionB;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer.Store;

public partial class DistributionB_DIB_Reports_DistrictReport : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    RDLC_Data objReports = new RDLC_Data();
    CommonFuction comm = new CommonFuction();
    CommonFuction obCommonFuction = new CommonFuction();
    STR_VendorMaster obSTR_VendorMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFyYr.DataSource = objReports.FillFyYear().Tables[0];
            ddlFyYr.DataTextField = "AcYear";
            ddlFyYr.DataValueField = "Id";
            ddlFyYr.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlFyYr.DataBind();
            FillLetterNo();

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            //DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void FillLetterNo()
    {
        // CommonFuction comm = new CommonFuction();
        //   objReports.FyYearID = int.Parse(ddlFyYr.SelectedValue);
        ddlLetterNo.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand(" + ddlFyYr.SelectedValue + ",'-2')");
        ddlLetterNo.DataTextField = "LetterNo_Va";
        ddlLetterNo.DataValueField = "LetterNo_V";
        ddlLetterNo.DataBind();
        ddlLetterNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
    }
    private void FillDemand()
    {
        objReports.TransID = -11;
        objReports.AcYearID = int.Parse(ddlFyYr.SelectedValue);
        objReports.TitleID = int.Parse(ddlLetterNo.SelectedValue);
       
        ddldemand.DataSource = objReports.GroupwiseReport().Tables[0];
        ddldemand.DataTextField = "Demandtype";
        ddldemand.DataValueField = "Demandtype";
        ddldemand.DataBind();
        ddldemand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
    }
    private void FillReport()
    {
        Dt = new DataTable();
        //  objReports.DemandID = int.Parse(ddlLetterNo.SelectedValue);
        Dt = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemandNew('" + ddlLetterNo.SelectedValue + "','0'," + DDlDepot.SelectedValue + ",'" + ddldemand.SelectedValue + "')").Tables[0];

        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            RVDistrictSupply.LocalReport.ReportPath = Server.MapPath("~/DistributionB/DIB_Reports/Rpt_DepowiseDemandNewRept.rdlc");
            RVDistrictSupply.LocalReport.DataSources.Clear();
            RVDistrictSupply.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[1];
            DataSet dtt = obCommonFuction.FillDatasetByProc(@"SELECT CASE WHEN  `DemandFrom_I`=1 THEN  'राज्य   शिक्षा  केन्द्र '  WHEN DemandFrom_I=2 THEN 'लोक शिक्षण  संचालनालय '  
WHEN DemandFrom_I=3 THEN 'संस्कृत बोर्ड' WHEN DemandFrom_I=4 THEN
 'हैदराबाद टी बी सी '  END DemandFrom_I  FROM`dib_demand`  WHERE `LetterNo_V`='" + ddlLetterNo.SelectedValue + "'");

            string Year ="शिक्षा सत्र -"+ ddlFyYr.SelectedItem.Text + "- " + dtt.Tables[0].Rows[0]["DemandFrom_I"].ToString();
            Param[0] = new ReportParameter("name", Year);

            RVDistrictSupply.LocalReport.SetParameters(Param);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            RVDistrictSupply.ShowPrintButton = true;
            RVDistrictSupply.LocalReport.Refresh();
            RVDistrictSupply.Visible = true;
        }
        else
        {
            RVDistrictSupply.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillReport();
    }
    protected void ddlFyYr_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillLetterNo();
    }
    public class RDLC_Data
    {
        DBAccess obDBAccess;
        public int DemandID { get; set; }
        public int FyYearID { get; set; }
        public int AcYearID { get; set; }
        public int TitleID { get; set; }
        public int TransID { get; set; }
        public DataSet FillLetterNo()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_Rpt001_DepowiseDemand", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID", FyYearID);
            obDBAccess.addParam("mType", -1);
            return obDBAccess.records();
        }
        public DataSet FillFyYear()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB002_DemandfromOthersSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", -1);
            obDBAccess.addParam("mParameterValue", 0);
            obDBAccess.addParam("mParameterValue2", 0);
            obDBAccess.addParam("mStringParameterValue", 0);
            return obDBAccess.records();
        }
        public DataSet DepowiseReport()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_Rpt001_DepowiseDemand", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID", DemandID);
            //obDBAccess.addParam("mQueryParameterValue2", QueryParameterValue2);
            obDBAccess.addParam("mType", 0);
            return obDBAccess.records();
        }

        public DataSet GroupwiseReport()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_Rpt002_GropwiseDemandnew", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mAcYearID", AcYearID);
            obDBAccess.addParam("mTransID", TransID);
            obDBAccess.addParam("mdemandid", DemandID);

            return obDBAccess.records();
        }
    }
    protected void ddlLetterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDemand();
    }
}
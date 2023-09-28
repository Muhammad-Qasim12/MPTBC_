using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.DistributionB;
using Microsoft.Reporting.WebForms;

public partial class DistributionB_DIB_Reports_Rpt_DIB007_GropwiseReport : System.Web.UI.Page
{

    DataSet ds;
    DataTable Dt, dt;
    RDLC_Data objReports = new RDLC_Data();

    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAcYear.DataSource = objReports.FillFyYear().Tables[0];
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataValueField = "Id";
            ddlAcYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlAcYear.DataBind();
            FillTitle();
        }
    }
    private void FillTitle()
    {
        objReports.TransID = -1;
        objReports.AcYearID = int.Parse(ddlAcYear.SelectedValue);
        ddlTitle.DataSource = objReports.GroupwiseReport().Tables[0];
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
    }

    private void FillDemand()
    {
        objReports.TransID = -10;
        objReports.AcYearID = int.Parse(ddlAcYear.SelectedValue);
        objReports.TitleID = int.Parse(ddlTitle.SelectedValue);
        ddldemand.DataSource = objReports.GroupwiseReport().Tables[0];
        ddldemand.DataTextField = "Demandtype";
        ddldemand.DataValueField = "Demandtype";
        ddldemand.DataBind();
        ddldemand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillReport();
    }
    private void FillReport()
    {
        Dt = new DataTable();        
        objReports.AcYearID = int.Parse(ddlAcYear.Text);
        objReports.TitleID = int.Parse(ddlTitle.Text);
        objReports.DemandID = int.Parse(ddldemand.Text);
        objReports.TransID = 0;
        Dt = objReports.GroupwiseReport().Tables[0];

        if (Dt.Rows.Count > 0)
        {

            DataSet dtt = obCommonFuction.FillDatasetByProc("SELECT CASE WHEN  `DemandFrom_I`=1 THEN 'R.S.K.'  WHEN DemandFrom_I=2 THEN 'CPI'  WHEN DemandFrom_I=3 THEN 'संस्कृत बोर्ड' WHEN DemandFrom_I=4 THEN 'हैदराबाद टी बी सी ' WHEN DemandFrom_I=5 then 'राष्ट्रीय माध्यमिक शिक्षा अभियान' WHEN DemandFrom_I=8 then 'समग्र शिक्षा अभियान' WHEN DemandFrom_I=24 then 'समग्र शिक्षा अभियान'  END DemandFrom_I  FROM`dib_demand` WHERE `LetterNo_V`='" + Dt.Rows[0]["LetterNo"].ToString() + "'");
            //DataSet dtt = obCommonFuction.FillDatasetByProc("SELECT CASE WHEN  `DemandFrom_I`=1 THEN 'R.S.K.'  WHEN DemandFrom_I=2 THEN 'CPI'  WHEN DemandFrom_I=3 THEN 'संस्कृत बोर्ड' WHEN DemandFrom_I=4 THEN 'हैदराबाद टी बी सी '  END DemandFrom_I  FROM`dib_demand` WHERE `LetterNo_V`='" + Dt.Rows[0]["LetterNo"].ToString() + "'");
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            RVGroupwiseSupply.LocalReport.ReportPath = Server.MapPath("~/DistributionB/DIB_Reports/Report2.rdlc");
            RVGroupwiseSupply.LocalReport.DataSources.Clear();
            RVGroupwiseSupply.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[1];
            string Year =ddlAcYear.SelectedItem.Text +"- "+ dtt.Tables[0].Rows[0]["DemandFrom_I"].ToString();
            Param[0] = new ReportParameter("Year", Year);

            RVGroupwiseSupply.LocalReport.SetParameters(Param);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            RVGroupwiseSupply.ShowPrintButton = true;
            RVGroupwiseSupply.LocalReport.Refresh();
            RVGroupwiseSupply.Visible = true;
        }
        else
        {
            RVGroupwiseSupply.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTitle();
    }
    protected void ddldemand_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDemand();
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
            obDBAccess.addParam("mTransID", TransID );
            obDBAccess.addParam("mdemandid", DemandID);   
            
            return obDBAccess.records();
        }
    }


}
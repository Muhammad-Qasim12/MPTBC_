using System;
using System.Data;
using MPTBCBussinessLayer.DistributionB;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer.Store;
public partial class DistributionB_DIB_Reports_Rpt_DIB006_DepowiseSupply : System.Web.UI.Page
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
        ddlLetterNo.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand("+ddlFyYr.SelectedValue+",'-2')"); 
        ddlLetterNo.DataTextField = "LetterNo_Va";
        ddlLetterNo.DataValueField = "LetterNo_V";
        ddlLetterNo.DataBind();
        ddlLetterNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));

    }
    private void FillReport()
    {
        Dt = new DataTable();
      //  objReports.DemandID = int.Parse(ddlLetterNo.SelectedValue);
        Dt = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemandNew('" + ddlLetterNo.SelectedValue + "','0'," + DDlDepot.SelectedValue + ",'" + ddldemand.SelectedValue + "')").Tables[0];

        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            RVDistrictSupply.LocalReport.ReportPath = Server.MapPath("~/DistributionB/DIB_Reports/RptDemand.rdlc");
            RVDistrictSupply.LocalReport.DataSources.Clear();
            RVDistrictSupply.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", ddlFyYr.SelectedItem.Text);
            Param[1] = new ReportParameter("DepartmentAddress", Dt.Rows[0]["DepartmentAddress"].ToString());
            

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
    private void FillDemand()
    {
        //obDBAccess = new DBAccess();
        //obDBAccess.execute("USP_DIB_Rpt002_GropwiseDemandnew", DBAccess.SQLType.IS_PROC);
        //obDBAccess.addParam("mTitleID_I", TitleID);
        //obDBAccess.addParam("mAcYearID", AcYearID);
        //obDBAccess.addParam("mTransID", TransID);
        //obDBAccess.addParam("mdemandid", DemandID);

        
        //objReports.TransID = -11;
        //objReports.AcYearID = int.Parse(ddlFyYr.SelectedValue);
        //objReports.TitleID = int.Parse(ddlLetterNo.SelectedValue);

        //ddldemand.DataSource = objReports.GroupwiseReport().Tables[0];
        ddldemand.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt002_GropwiseDemandnew('" + ddlLetterNo.SelectedValue + "','" + ddlFyYr.SelectedValue + "','-11','0')");

        ddldemand.DataTextField = "Demandtype";
        ddldemand.DataValueField = "Demandtype";
        ddldemand.DataBind();
        ddldemand.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
    }
    protected void ddlLetterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDemand();
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using Microsoft.Reporting.WebForms;

public partial class Paper_CompressionLastTwoYearReport : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData_New objReports = new PPR_RDLCData_New();
    PPR_LabInspection objLabInspection = null;
    CommonFuction obCommonFuction = new CommonFuction();
    string LastYear = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int Year1 = 0;
            LastYear = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            Year1 = int.Parse(LastYear.ToString().Substring(0, 4));
            lblLastYear.Text = " ( " + LastYear + " / " + (Year1 - 1).ToString() + "-" + Year1.ToString() + " )";
            Page.Title = "पेपर स्टॉक का पिछले वर्ष की तुलना / Last Year Compression Of Paper Stock " + lblLastYear.Text;
        }
        catch { }
        if (!Page.IsPostBack)
        {
            //DataLoad();
            BindGSMDDL();
        }
    }

    public void BindGSMDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        //DataTable ds = obCommonFuction.FillTableByProc("SELECT CONCAT(CAST(ppm.GSM AS CHAR),' GSM ',CAST(pqm.QualifyType AS CHAR),' (',CAST(ppm.PaperSize_V AS CHAR),') ' ,CAST(ppm.PaperCategory AS CHAR)) AS CoverInformation, ppm.PaperTrId_I FROM  ppr_papermaster_m ppm INNER JOIN  paperqualifytypemaster pqm ON pqm.Qualifyid_I=ppm.PaperQuality_V INNER JOIN  ppr_papertype  pt ON pt.PaperType_Id=ppm.PaperType_I WHERE paperCategory='Reel' OR paperCategory='Sheet' ORDER BY ppm.GSM");
        DataTable ds = obCommonFuction.FillTableByProc("call USP_RPT004_FillGSMDDL()");

        ddlGSM.DataSource = ds;
        ddlGSM.DataTextField = "CoverInformation";
        ddlGSM.DataValueField = "PaperTrId_I";
        ddlGSM.DataBind();
        ddlGSM.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DataLoad();
    }

    public void DataLoad()
    {
       

        Dt = new DataTable();
        objReports.PaperMstrTrId_I = ddlGSM.SelectedValue != "" ? Convert.ToInt32(ddlGSM.SelectedValue) : 0;
        Dt = objReports.YearlyDataShowOfStock();

        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/CompLastTwoYear.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("AcYear",  obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString());
            Param[1] = new ReportParameter("gsm", "पेपर का प्रकार : "+ddlGSM.SelectedItem.Text);
           
            ReportViewer1.LocalReport.SetParameters(Param);


            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
    }

    public class PPR_RDLCData_New
    {
        private int _PaperMstrTrId_I=0;
        public int PaperMstrTrId_I { get { return _PaperMstrTrId_I; } set { _PaperMstrTrId_I = value; } }

        public System.Data.DataTable YearlyDataShowOfStock()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 99);
            return obDBAccess.records1();
        }
       
    }
}

using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_PrintDemand : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        LoadReport();
        }
    }
    public void LoadReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        string Classes = "";


        DS = obCommonFuction.FillDatasetByProc(@"CALL USP_DisRpt_BlockWiseDemand(" + Convert.ToInt32(Request.QueryString["DistrictID"])
                                                                                 + "," + Convert.ToInt32(Request.QueryString["DepoID"])
                                                                                 + ",'" + Request.QueryString["Classes"] + "'"
                                                                                 + "," + Convert.ToInt32(Request.QueryString["SchemeID"])
                                                                                 + ",'" + Convert.ToString(Request.QueryString["Fyyear"])
                                                                                 + "'," + Request.QueryString["DemandType"] + ")");

        rds.Value = DS.Tables[0];
        string Title = "";
        string Rtype = "";
        Title = " ";
        Rtype = " ";
        string classa = "";
        if (Convert.ToString (Request.QueryString["Classes"]) == "1,2,3,4,5,6,7,8,")
        {
            classa = "1-8";
        }
        else
        {
            classa = "9-12";
        }
      //  DataSet dt = obCommonFuction.FillDatasetByProc("call GetID(" + Request.QueryString["DepoID"] + ","+(Request.QueryString["SchemeID"].ToString()+","+Request.QueryString["DemandType"].ToString()+")");
        DataSet dt = obCommonFuction.FillDatasetByProc("call GetID(" + Request.QueryString["DepoID"] + ","+Request.QueryString["SchemeID"].ToString()+","+Request.QueryString["DemandType"].ToString()+")");
        try {
            Title = "डिपो : " + Convert.ToString(dt.Tables[0].Rows[0]["DepoName_V"]) + ", " + " जिला : " + Convert.ToString(DS.Tables[0].Rows[0]["District_Name_Hindi_V"]) + ", " + " कक्षा : " + classa + ", " + " योजना : " + Convert.ToString(dt.Tables[0].Rows[0]["SchemeName_Hindi"]) + " ";
        Rtype="राज्य शिक्षा केंद्र के पत्र क्रमांक "+Convert.ToString( DS.Tables[0].Rows[0]["LetterNo"] )+ " दिनांक : "+Convert.ToString( DS.Tables[0].Rows[0]["LetterDate"] )+" ";
        }
        catch { } //if (Convert.ToString(Request.QueryString["Type"]) == "A")
                  //{
                  //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/ReportAllotment.rdlc");
                  //}
                  //else
                  //{
                  // ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/Report_BlockWiseDmnd.rdlc");
                  // }

        //ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;

        this.ReportViewer1.LocalReport.ReportPath = "Distribution/Report_BlockWiseDmnd.rdlc";

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

      

        ReportParameter[] Param = new ReportParameter[3];
        Param[0] = new ReportParameter("Year", Request.QueryString["Fyyear"]);
        Param[1] = new ReportParameter("Title", Title);
        Param[2] = new ReportParameter("Rtype", Rtype);

        ReportViewer1.LocalReport.SetParameters(Param);
         

        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }
}
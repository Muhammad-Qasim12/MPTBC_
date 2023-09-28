using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_Rpt_DepotWiseDemandMedium : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Convert.ToString(Session["UserName"]).ToUpper() == "DPI" || Convert.ToString(Session["UserName"]).ToUpper() == "RSK")
        {
            LblClass.Visible = DDLClass.Visible = false;
        }
        lblTitleName.Text = "डिपोवार मांग की रिपोर्ट / Depot Wise Demand Report ";
        Page.Title = lblTitleName.Text;

        if (!Page.IsPostBack)
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
            // DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));


            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            //DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));

        }
    }
    public void LoadReport()
    {
        //ReportDataSource rds = new ReportDataSource();
        //rds.Name = "DataSet1";
        DataSet DS;
        string Classes = "";
        if (Convert.ToString(Session["UserName"]).ToUpper() == "RSK")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (Convert.ToString(Session["UserName"]).ToUpper() == "DPI")
        {
            Classes = "9,10,11,12";
        }
        else
        {
            if (DDLClass.SelectedValue.ToString() == "1-8")
            {
                Classes = "1,2,3,4,5,6,7,8";
            }
            else if (DDLClass.SelectedValue.ToString() == "9-12")
            {
                Classes = "9,10,11,12";
            }

        }

        Dt = obCommonFuction.FillTableByProc(@"CALL USP_DisRpt_DepotWiseDemandMedium(" + 0
                                                                                 + "," + 0
                                                                                 + ",'" + Classes + "'"
                                                                                 + "," + Convert.ToInt32(DdlScheme.SelectedValue)
                                                                                 + ",'" + Convert.ToString(DdlACYear.SelectedValue)
                                                                                 + "'," + DDlDemandType.SelectedItem.Value + ")");

        // rds.Value = DS.Tables[0];
        string Title = "";
        Title = " कक्षा : " + DDLClass.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " माध्यम : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " मांग का प्रकार: " + DDlDemandType.SelectedItem.Text;


        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/Report_DepotWiseMediumDmnd.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportParameter[] Param = new ReportParameter[2];
        Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        Param[1] = new ReportParameter("Title", Title);
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void DDlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    DdlDistrict.Enabled = true;
        //    CommonFuction obCommonFuction = new CommonFuction();

        //    DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + DDlDepot.SelectedValue + " ,0,0 )");
        //    DdlDistrict.DataValueField = "DistrictTrno_I";
        //    DdlDistrict.DataTextField = "District_Name_Hindi_V";
        //    DdlDistrict.DataBind();
        //    DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));
        //}
        //catch { }
    }
    protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        //DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
        //DdlScheme.DataTextField = "SchemeName_Hindi";
        //DdlScheme.DataBind();
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
        DdlScheme.DataValueField = "MediumTrno_I";
        DdlScheme.DataTextField = "MediunNameHindi_V";
        DdlScheme.DataBind();
        // DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));
    }
}

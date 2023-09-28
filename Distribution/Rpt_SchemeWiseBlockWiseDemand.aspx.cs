using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distrubution_Rpt_SchemeWiseBlockWiseDemand : System.Web.UI.Page
{
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {


        lblTitleName.Text = "विकासखंड वार मांग की रिपोर्ट (योजना) / Demand Of Block Wise Report (Scheme)";
        Page.Title = lblTitleName.Text;

        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));

            //DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
            //DdlScheme.DataTextField = "SchemeName_Hindi";
            //DdlScheme.DataValueField = "SchemeID";
            //DdlScheme.DataBind();
            //  DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));

            DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));


            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();

        }
    }
    public void LoadReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        string Classes = "";
        //if (Convert.ToString(Session["UserName"]).ToUpper() == "RSK")
        //{
        //    Classes = "1,2,3,4,5,6,7,8";
        //}
        //else if (Convert.ToString(Session["UserName"]).ToUpper() == "DPI")
        //{
        //    Classes = "9,10,11,12";
        //}
        //else
        //{
        //    if (DDLClass.SelectedValue.ToString() == "1-8")
        //    {
        //        Classes = "1,2,3,4,5,6,7,8";
        //    }
        //    else if (DDLClass.SelectedValue.ToString() == "9-12")
        //    {
        //        Classes = "9,10,11,12";
        //    }
        //}

        DS = obCommonFuction.FillDatasetByProc(@"CALL USP_DisRpt_BlockWiseDemandScheme(" + Convert.ToInt32(DdlDistrict.SelectedValue)
                                                                                 + "," + Convert.ToInt32(DDlDepot.SelectedValue) + ",'',0,'" + Convert.ToString(DdlACYear.SelectedValue)
                                                                                 + "'," + DDlDemandType.SelectedItem.Value + ")");

        rds.Value = DS.Tables[0];
        string Title = "";
        Title = "डिपो : " + DDlDepot.SelectedItem.Text + ", " + " जिला : " + DdlDistrict.SelectedItem.Text + ", " + " मांग का प्रकार: " + DDlDemandType.SelectedItem.Text;

        //if (Convert.ToString(Request.QueryString["Type"]) == "A")
        //{
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/ReportAllotment.rdlc");
        //}
        //else
        //{
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/Report_SchemeBlockWiseDmnd.rdlc");
        // }
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameter[] Param = new ReportParameter[2];
        Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        Param[1] = new ReportParameter("Title", Title);
        ReportViewer1.LocalReport.SetParameters(Param);


        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void DDlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlDistrict.Enabled = true;
            CommonFuction obCommonFuction = new CommonFuction();

            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + DDlDepot.SelectedValue + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
    }
    //protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    //DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
    //    //DdlScheme.DataTextField = "SchemeName_Hindi";
    //    //DdlScheme.DataBind();

    //    //DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));
    //}
}

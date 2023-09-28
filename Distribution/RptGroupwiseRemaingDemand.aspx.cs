using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Distribution_RptGroupwiseRemaingDemand : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {


        lblTitleName.Text = " पूर्व में जारी वितरण निर्देश को कम कर शेष पाठ्यपुस्तको की ग्रुपवार रिपोर्ट  ";
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

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();


            ddlGroupName.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookGroupName()");
            ddlGroupName.DataValueField = "GroupId";
            ddlGroupName.DataTextField = "GroupName";
            ddlGroupName.DataBind();
            ddlGroupName.Items.Insert(0, "Select");
            DdlACYear_SelectedIndexChanged( sender,  e);
            //DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));

            //DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            //DDlDemandType.DataValueField = "DemandTypeId";
            //DDlDemandType.DataTextField = "DemandTypeHindi";
            //DDlDemandType.DataBind();
        }
    }
    public void LoadReport()
    {
        //ReportDataSource rds = new ReportDataSource();
        //rds.Name = "DataSet1";
        DataSet DS;

        string strclasses = "";

        CommonFuction obCommonFuction = new CommonFuction();
        foreach (ListItem item in DdlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + "," + item.Value;
            }

        }
        Dt = obCommonFuction.FillTableByProc(@"CALL USP_DisDemandVitranNirdesh('" + DdlACYear.SelectedItem.Value + "'," + ddlGroupName.SelectedItem.Value + ",'" + (DDlDemandType.SelectedValue) + "'," + DdlScheme.SelectedItem.Value + ",'" + strclasses + "')");

        // rds.Value = DS.Tables[0];
        string Title = "";
        Title = " शिक्षा सत्र : " + DdlACYear.SelectedItem.Text + " ग्रुप : " + ddlGroupName.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " माध्यम : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " मांग का प्रकार  :" + DDlDemandType.SelectedItem.Text.ToString().Replace("0", "सभी");


        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/RptNewReportDemand.rdlc");
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
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        DDlDemandType.DataValueField = "OrderNo";
        DDlDemandType.DataTextField = "OrderNo";
        DDlDemandType.DataBind();
        DDlDemandType.Items.Insert(0, new ListItem("-Select-", "0"));
    }
}
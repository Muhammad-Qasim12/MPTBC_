using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distrubution_RptDemand : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblTitleName.Text = "मुख्य एव सॅटॅलाइट डेपोवार मांग की रिपोर्ट / Demand Report Of Main And Satellite Depot";
        Page.Title = lblTitleName.Text;
        if (!IsPostBack)
        {

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            //DdlDepot.Items.Insert(0, "--Select--");
            DdlDepot.Items.Insert(0, new ListItem("-Select-", "0"));

            DdlClasses.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClasses.DataValueField = "ClassTrno_I";
            DdlClasses.DataTextField = "Classdet_V";
            DdlClasses.DataBind();
            //DdlClasses.Items.Insert(0, new ListItem("-Select-", "-1"));
            DdlClasses.Items.Insert(0, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, new ListItem("-All-", "0"));


        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void DdlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void LoadReport()
    {
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";

        CommonFuction obCommonFuction1 = new CommonFuction();

       DataSet  Dset = obCommonFuction1.FillDatasetByProc("Call USP_DIS_RptDemand('" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + "," + Convert.ToInt32(DdlClasses.SelectedValue) + ")");

       string Title = "";
       Title = "डिपो : " + DdlDepot.SelectedItem.Text + ", " + " माध्यम : " + DdlMedium.SelectedItem.Text.ToString().Replace("-All-", "सभी") + ", " + " कक्षा : " + DdlClasses.SelectedItem.Text.ToString().Replace("-All-", "सभी");
      

        rds.Value = Dset.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/ReportDemand.rdlc");
       

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

}
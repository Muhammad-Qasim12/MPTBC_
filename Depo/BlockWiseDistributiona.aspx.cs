using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_BlockWiseDistributiona : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "--Select--");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectDistrict("+Session["UserID"]+",0,0)");
            DDlDepot.DataValueField = "DistrictTrno_I";
            DDlDepot.DataTextField = "District_Name_Hindi_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet DS;
        string Classes = "";

        if (DDLClass.SelectedValue.ToString() == "1-8")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (DDLClass.SelectedValue.ToString() == "9-12")
        {
            Classes = "9,10,11,12";
        }
        string Title = "";
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DS = obCommonFuction.FillDatasetByProc(@"CALL USP_GetBookDistributionINBlockDepo('" + DdlACYear.SelectedItem.Text + "'," + ddlMedium.SelectedValue + ",'" + Classes + "'," + DDlDepot.SelectedValue + ","+DDlDemandType.SelectedValue+")");

        rds.Value = DS.Tables[0];
        Title = " कक्षा : " + Classes + " माध्यम  : " + ddlMedium.SelectedItem.Text.ToString().Replace("-All-", "सभी") + "  जिले का नाम " + DDlDepot.SelectedItem.Text;

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/rptBlockDistribute.rdlc");
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
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddltype.SelectedValue == "1")
        {
            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoadNew('" + DdlACYear.SelectedItem.Text + "',1)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
        }
        else
        {
            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoadNew('" + DdlACYear.SelectedItem.Text + "',0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
        }
    }
}
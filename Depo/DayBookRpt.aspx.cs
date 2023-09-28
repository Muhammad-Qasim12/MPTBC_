using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_DayBookRpt : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        { 
        DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
        DdlClass.DataValueField = "ClassTrno_I";
        DdlClass.DataTextField = "ClassDesc_V";
        DdlClass.DataBind();
        DdlClass.Items.Insert(0, "--Select--");

        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
        DdlScheme.DataValueField = "MediumTrno_I";
        DdlScheme.DataTextField = "MediunNameHindi_V";
        DdlScheme.DataBind();
        DdlScheme.Items.Insert(0, "Select");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        DS = obCommonFuction.FillDatasetByProc(@"CALL GetDayBookReport(" + Convert.ToInt32(DdlScheme.SelectedValue)
                                                                                + "," + Convert.ToInt32(DdlClass.SelectedValue)
                                                                                + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "'"
                                                                                 + "," + Convert.ToInt32(Session["UserID"])
                                                                                + ")");
        rds.Value = DS.Tables[0];
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/DayRPT.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }
}
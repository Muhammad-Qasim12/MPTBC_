using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Depo_Format2 : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    string classA; DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try { 
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";

        //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_GetFormat2 ('" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + ", " + Convert.ToString(Session["UserID"]) + ",'" + DDLClass.SelectedValue + "') ");
        Dt = dd.Tables[0];
        rds.Value = Dt;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Format2.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("Year", DdlACYear.SelectedItem.Text));
        Param.Add(new ReportParameter("DepoManager", dd.Tables[0].Rows[0]["DEpoManager"].ToString()));
        Param.Add(new ReportParameter("StroreKeepr", dd.Tables[0].Rows[0]["StoreKeeper"].ToString()));
        Param.Add(new ReportParameter("PhyOffice", dd.Tables[0].Rows[0]["PhyOfficer"].ToString()));
        Param.Add(new ReportParameter("MClass", DdlScheme.SelectedItem.Text + "-" + DDLClass.SelectedValue));
        Param.Add(new ReportParameter("Depo", Session["UserName"].ToString()));
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;

        ReportViewer1.LocalReport.Refresh();
        }
        catch { }
    }
}
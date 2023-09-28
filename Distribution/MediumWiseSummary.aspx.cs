using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
public partial class MediumWiseSummary : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string Bookstatus;
    protected void Page_Load(object sender, EventArgs e)
    {

        lblTitleName.Text = "खुले बाजार में विक्रय की मांग";
        Page.Title = lblTitleName.Text;


        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    public void LoadReport()
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            Bookstatus = "1";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            Bookstatus = "0,2";
        }
        else
        {

            Bookstatus = "0,1,2";
        }
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataTable Dt;
        Dt = obCommonFuction.FillTableByProc(@"CALL USP_DIS_DemandOpnSchmStkSummary('" + Convert.ToString(DdlACYear.SelectedValue) + "','" + DDlDemandType.SelectedItem.Value + "','" + Bookstatus + "')");
        rds.Value = Dt;

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/MediumWiseSummaryRpt.rdlc");

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameter[] Param = new ReportParameter[1];
        Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        // Param[1] = new ReportParameter("Title", Title);
        ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

}

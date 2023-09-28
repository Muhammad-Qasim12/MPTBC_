using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Distribution_DepoWiseTotal : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string Bookstatus;

    protected void Page_Load(object sender, EventArgs e)
    {

        lblTitleName.Text = "डिपो का स्कीमवर टोटल डिमांड  ";
        Page.Title = lblTitleName.Text;


        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
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
        Dt = obCommonFuction.FillTableByProc(@"CALL USP_DIS_DemandOpneShememDepoWSummary('" + Convert.ToString(DdlACYear.SelectedValue) + "','" + DDlDemandType.SelectedItem.Value + "','" + Bookstatus + "',"+DdlDepot.SelectedValue+")");
        rds.Value = Dt;

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/DepoTotal.rdlc");

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
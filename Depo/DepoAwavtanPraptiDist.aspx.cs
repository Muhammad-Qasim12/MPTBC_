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
public partial class Depo_DepoAwavtanPraptiDist : System.Web.UI.Page
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

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";

            //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
            DataSet dd = obCommonFuction.FillDatasetByProc("call USP_GM_DepowiseavantanpraptiDepo ('" + DdlACYear.SelectedValue + "','" + Convert.ToString(Session["UserID"]) + "') ");
            Dt = dd.Tables[0];
            rds.Value = Dt;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report3.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
        }
        catch { }
    }
}
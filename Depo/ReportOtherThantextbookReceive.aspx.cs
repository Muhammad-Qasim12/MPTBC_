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

public partial class Depo_ReportOtherThantextbookReceive : System.Web.UI.Page
{
    string classA; DataTable Dt;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DataSet dd2 = obCommonFuction.FillDatasetByProc("  SELECT TitleID_I,TitleHindi_V FROM `acb_titledetail`");
            ddlTitleID.DataTextField = "TitleHindi_V";
            ddlTitleID.DataValueField = "TitleID_I";
            ddlTitleID.DataSource = dd2.Tables[0];
            ddlTitleID.DataBind();
            ddlTitleID.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";

        //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_OtherThanTextBookReceived ('" + DdlACYear.SelectedValue + "',"+ddlTitleID.SelectedValue+") ");
        Dt = dd.Tables[0];
        rds.Value = Dt;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Otherthantextbook.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("TitleName", ddlTitleID.SelectedItem.Text));

        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
      
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
}
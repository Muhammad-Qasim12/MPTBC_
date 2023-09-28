
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Printing_Reports_DepowisebookSupplySummaryReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
            TextBox1.Text = "01-12-2016";
            TextBox2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";

        Dt = obCommonFuction.FillTableByProc("call GetPrinterChallanDetailsDepo('" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "',"+ddlMedium.SelectedValue+",'" + Classes + "','"+DdlACYear.SelectedValue+"')");
        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/DepowisebookSupplySummary.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportParameter[] Param = new ReportParameter[1];

        string Title = "";
        Title = "कक्षा : " + DDLClass.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " माध्यम : " + ddlMedium.SelectedItem.Text.ToString().Replace("All", "सभी")  + "," +  "दिनांक: " + TextBox1.Text + " से " + TextBox2.Text +" तक " ;
        Param[0] = new ReportParameter("Class", Title);
        ReportViewer1.LocalReport.SetParameters(Param);

        //Param[1] = new ReportParameter("Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
        //ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
}
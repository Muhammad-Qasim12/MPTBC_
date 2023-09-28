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
public partial class Depo_DayBookReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;
    MDDashboard md = new MDDashboard();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            TextBox1.Text = "01-02-2018";
            TextBox2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            //ddlMedium.Items.Insert(0, "--Select--");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8")   Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        string Title = "दिनांक से : " + TextBox1.Text + " दिनांक तक : " + TextBox2.Text +"माध्यम : " +ddlMedium.SelectedItem.Text;
        string FinancialYear = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";
        DataSet dd=new DataSet ();
        //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
        if (RadioButtonList1.SelectedValue == "1")
        {
            dd = obCommonFuction.FillDatasetByProc("call DPTGetDaybookData (" + Convert.ToString(Session["UserID"]) + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "' ,'" + Classes + "'," + ddlMedium.SelectedValue + ") ");
        }
        else
        {


            dd = obCommonFuction.FillDatasetByProc("call USP_DayBookOtherThanTextbookN (" + Convert.ToString(Session["UserID"]) + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "' ,'" + Classes + "'," + ddlMedium.SelectedValue + ") ");

        }
        Dt = dd.Tables[0];
        rds.Value = Dt;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("DayReportA.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("p_DepoName", DepoName));
        Param.Add(new ReportParameter("Cdate", System.DateTime.Now.ToString("dd/MM/yyyy")));
        Param.Add(new ReportParameter("p_FYear", FinancialYear));
        Param.Add(new ReportParameter("Tital12", Title)); 
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            ddlMedium.Visible = true;
            DDLClass.Visible = true;
        }
        else
        {
            ddlMedium.Visible = false;
            DDLClass.Visible = true;
        }
    }
}
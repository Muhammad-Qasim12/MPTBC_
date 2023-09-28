using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Depo_BookSellerDemandPraday : System.Web.UI.Page
{
    public CommonFuction obCommanFun = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public DataSet ds = new DataSet();
    string Classes;
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFromdate.Text = "01/03/2018";
        txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue.ToString() == "1-8")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (DropDownList1.SelectedValue.ToString() == "9-12")
        {
            Classes = "9,10,11,12";
        }
        else if (DropDownList1.SelectedValue.ToString() == "All")
        {
            Classes = "1,2,3,4,5,6,7,8,9,10,11,12";
        }
        string TitleName = "दिनांक : " + txtFromdate.Text + " से दिनांक : " + txtTodate.Text + " तक , कक्षा  -" +DropDownList1.SelectedValue + "";
        ds = obCommanFun.FillDatasetByProc("call USP_DPT_BookSellerDemandPraday('" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "','" + Classes + "')");
         ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = ds.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/BookSellerDemand.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("Title", TitleName));
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
   
}
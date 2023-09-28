using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_ncrtBook : System.Web.UI.Page
{
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    string Bookstatus;
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
        string classNamea="";
        if (DropDownList1.SelectedValue == "0")
        {
            classNamea = "1,2,3,4,5,6,7,8,9,10,11,12";
        }
        else if (DropDownList1.SelectedValue == "1")
        {
            classNamea = "1,2,3,4,5,6,7,8";
        }
        else
        {
            classNamea = "9,10,11,12";
        }
        LoadReport(Bookstatus, classNamea);
    }
    public void LoadReport( string id,string IDa)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        


        DS = obCommonFuction.FillDatasetByProc(@"CALL USP_GetNRCTBookFivePerAmount('" + DdlACYear.SelectedValue + "','" + id + "','" + IDa + "')");

        rds.Value = DS.Tables[0];
      
        //if (Convert.ToString(Request.QueryString["Type"]) == "A")
        //{
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/ReportAllotment.rdlc");
        //}
        //else
        //{
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/NCRTBookAmount.rdlc");
        // }
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameter[] Param = new ReportParameter[1];
        Param[0] = new ReportParameter("acyear", DdlACYear.SelectedItem.Text);
       ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }
}
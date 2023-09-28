using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Microsoft.Reporting.WebForms;
public partial class test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //// Set the report processing mode to local
        //ReportViewer1.ProcessingMode = ProcessingMode.Local;

        //// Set the path of the RDLC report
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/test/Report.rdlc");

        //// Set the data source for the report
        //var dataSource = new ReportDataSource("DataSet1", GetReportData()); // GetReportData() should be a method that fetches the data from the database
        //ReportViewer1.LocalReport.DataSources.Clear();
        //ReportViewer1.LocalReport.DataSources.Add(dataSource);

        //// Refresh the report
        //ReportViewer1.LocalReport.Refresh();
    }
    private DataTable GetReportData()
    {
        
        var dataTable = new DataTable();
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Age", typeof(int));
        dataTable.Rows.Add("John Doe", 30);
        dataTable.Rows.Add("Jane Smith", 25);
        return dataTable;
    }
}
using System;
using System.Data;
using MPTBCBussinessLayer.DistributionB;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer.Store;

public partial class DistributionB_BeemaKeReport : System.Web.UI.Page
{
    DataTable Dt, dt;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 2017; i <= System.DateTime.Now.Year + 1; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
           
            ddlMonth.DataTextField = "MonthFullName";
            ddlMonth.DataValueField = "MonthId";
            ddlMonth.DataSource = comm.FillDatasetByProc("call hr_get_months()");
            ddlMonth.DataBind();
            ddlMonth.Items.Insert(0, "सलेक्ट करे ..");
        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        Dt = new DataTable();
        //  objReports.DemandID = int.Parse(ddlLetterNo.SelectedValue);
        Dt = comm.FillDatasetByProc("call USP_BeemReport('" +ddlMonth.SelectedValue + "'," + ddlYear.SelectedValue + ")").Tables[0];

        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        RVDistrictSupply.LocalReport.ReportPath = Server.MapPath("Beemareport.rdlc");
            RVDistrictSupply.LocalReport.DataSources.Clear();
            RVDistrictSupply.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
           // string Year = "शिक्षा सत्र -" + ddlFyYr.SelectedItem.Text + "- " + dtt.Tables[0].Rows[0]["DemandFrom_I"].ToString();
            Param[0] = new ReportParameter("Month", ddlMonth.SelectedItem.Text);
            Param[1] = new ReportParameter("Year", ddlYear.SelectedValue);
            RVDistrictSupply.LocalReport.SetParameters(Param);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            RVDistrictSupply.ShowPrintButton = true;
            RVDistrictSupply.LocalReport.Refresh();
            RVDistrictSupply.Visible = true;
    
       
    }
}
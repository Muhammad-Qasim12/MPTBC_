using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;

using System.Web;
using System.Web.UI;


public partial class Distribution_RptVitranNirdeshnumber : System.Web.UI.Page
{
    DataTable Dt;
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
            DdlACYear_SelectedIndexChanged( sender,  e);
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
       
       
       // DS = obCommonFuction.FillDatasetByProc(@"CALL USPVitranBundelNOReport('" + DdlACYear.SelectedValue + "','" + ddlOrderNo.SelectedValue + "'");

        
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/VitranNumber.rdlc");
        Dt = obCommonFuction.FillTableByProc(@"CALL USPVitranBundelNOReport('" + DdlACYear.SelectedValue + "','" + ddlOrderNo.SelectedValue + "')");
        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/VitranNumber.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        //ReportParameter[] Param = new ReportParameter[3];
        //Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        //Param[1] = new ReportParameter("Title", Title);
        //Param[2] = new ReportParameter("Rtype", Rtype);
        //ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        ddlOrderNo.DataValueField = "OrderNo";
        ddlOrderNo.DataTextField = "OrderNo";
        ddlOrderNo.DataBind();
        //ddlOrderNo.Items.Insert(0, new ListItem("-Select-", "0"));
    }
}
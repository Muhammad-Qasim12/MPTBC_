using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_ExtraDemandVitranReport : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory;
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
            DdlACYear_SelectedIndexChanged1( sender,  e);

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void DdlACYear_SelectedIndexChanged1(object sender, EventArgs e)
    {
        //LblFyYear.Text = DdlACYear.SelectedValue;
        DropDownList2.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        DropDownList2.DataValueField = "OrderNo";
        DropDownList2.DataTextField = "OrderNo";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds = obCommonFuction.FillDatasetByProc("call USP_ExtraVitranNirdesh('" + DdlACYear.SelectedItem.Text + "','" + DDlDepot.SelectedValue + "','"+DropDownList2.SelectedValue + "')");
        LoadReport(ds);
        ds.Dispose();
    }
    public void LoadReport(DataSet dsGSR)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = dsGSR.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/rdExtraDemand.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        //ReportParameterCollection Param = new ReportParameterCollection();
        //Param.Add(new ReportParameter("p_DepoName", DepoName));
        //Param.Add(new ReportParameter("p_Title", Title));
        //Param.Add(new ReportParameter("p_FYear", FinancialYear));

        //ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Depo_RptOpenmarketDemand : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt; ClassMaster obClass = null;
    MDDashboard md = new MDDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            obClass.ClassTrno_I = 0;

            DDLClass.DataTextField = "Classdet_V";
            DDLClass.DataValueField = "ClassTrno_I";
            DDLClass.DataSource = dtclass;
            DDLClass.DataBind();
            DDLClass.Items.Insert(0, new ListItem("All", "0"));
            CommonFuction comm = new CommonFuction();
            //DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            //ddlTital.DataSource = asdf.Tables[0];
            //ddlTital.DataTextField = "TitleHindi_V";
            //ddlTital.DataValueField = "TitleID_I";
            //ddlTital.DataBind();
            //ddlTital.Items.Insert(0, new ListItem("All", "0"));

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
        }


    }
    protected void BtnShow_Click(object sender, EventArgs e)
    {
        string Details;
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";
        CommonFuction comm = new CommonFuction();
        Dt = comm.FillTableByProc("call USPRptOpenMarketDemand('" + Convert.ToString(DdlACYear.SelectedItem.Text) + "', " + Convert.ToInt32(Session["UserID"]) + " ," + ddlMedium.SelectedValue + "," + DDLClass.SelectedValue + ")");
      // Dt = md.OpenMarketDemand();

        rds.Value = Dt;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/RptOpenmarketDenamdNew.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;

        ReportParameter[] Param = new ReportParameter[1];
        Details = "शिक्षा सत्र (" + DdlACYear.SelectedItem.Text + ") हेतु खुले बाजार की पुस्तक का आंकलन (" + Session["UserName"] + ")";
        Param[0] = new ReportParameter("Deponame", Details);
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
}
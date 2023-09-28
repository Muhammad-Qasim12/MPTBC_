using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Depo_DepoRateSummaryho : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "Select");
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();

        }
    }
    public void LoadReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        string blockID = "0";
        if (RadioButtonList1.SelectedValue == "1")
        {
            DS = comm.FillDatasetByProc("call GetTransportRateDepoWiseNew(" + DdlDepot.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            DS = comm.FillDatasetByProc("call usp_OtherThanTextbookBill(" + DdlDepot.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
        }
        else
        {

            DS = comm.FillDatasetByProc("call GetTransportRateSum(" + DdlDepot.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
  
        
        }
        rds.Value = DS.Tables[0];
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Report2.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportParameter[] Param = new ReportParameter[2];
        Param[0] = new ReportParameter("DepoName", DdlDepot.SelectedItem.Text);
        Param[1] = new ReportParameter("Year", DdlACYear.SelectedValue);
        ReportViewer1.LocalReport.SetParameters(Param);


        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        //CommonFuction obCommonFuction = new CommonFuction();
        //DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        //ddlBlock.DataSource = ds;
        //ddlBlock.DataTextField = "BlockNameHindi_V";
        //ddlBlock.DataValueField = "BlockTrno_I";
        //ddlBlock.DataBind();
        //ddlBlock.Items.Insert(0, "--Select--");
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DdlDistrict.DataSource = comm.FillDatasetByProc("call USP_DD_SelectDistrict(" + DdlDepot.SelectedValue + " ,0,0 )");
        //DdlDistrict.DataValueField = "DistrictTrno_I";
        //DdlDistrict.DataTextField = "District_Name_Hindi_V";
        //DdlDistrict.DataBind();
        //DdlDistrict.Items.Insert(0, "--Select--");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using Microsoft.Reporting.WebForms;


public partial class Depo_BRCChallan : System.Web.UI.Page
{
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
            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "--Select--");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_BlockChallan(" + ddlMedium.SelectedValue + "," + ddlBlock.SelectedValue + "," + Session["UserID"].ToString() + ",'" + DropDownList1.SelectedValue + "','" + DdlACYear.SelectedItem.Text + "')");

        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = ds.Tables[0]; 
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/BRCChallan.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("p_DepoName", Session["UserName"].ToString ()));
        Param.Add(new ReportParameter("medium", ddlMedium.SelectedItem.Text));
        Param.Add(new ReportParameter("Class", DropDownList1.SelectedItem.Text));

        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        ddlBlock.DataSource = ds;
        ddlBlock.DataTextField = "BlockNameHindi_V";
        ddlBlock.DataValueField = "BlockTrno_I";
        ddlBlock.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer.Paper;
using System.IO;
using MPTBCBussinessLayer;
using System.Data;
using Microsoft.Reporting.WebForms;
public partial class CenterDepot_CenteralReport_VendorChallanReport : System.Web.UI.Page
{
    DataSet ds; DataTable Dt;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Dis_TentativeDemandHistory objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlYear.DataSource = objTentativeDemandHistory.TentativeDemandAcadminYearFill();
            ddlYear.DataTextField = "AcYear";
            ddlYear.DataValueField = "AcYear";
            ddlYear.DataBind();
            ddlYear.Items.Insert(0, "Select");
            try
            {
                ddlYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            }
            catch { }
            ddlVendor.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtl(0,0,0,0,0,0,'',6)");
            ddlVendor.DataTextField = "PaperVendorName_V";
            ddlVendor.DataValueField = "PaperVendorTrId_I";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, "Select..");
            txtFromDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlYear.SelectedItem.Text + "',0,-1)");
            ddlGSM.DataSource = ds;
            ddlGSM.DataTextField = "CoverInformation";
            ddlGSM.DataValueField = "PaperMstrTrID_I";
            ddlGSM.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
         DateTime DteCheck;
        string RptDate = "", GrDate = "";
        if (txtFromDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtFromDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtTodate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtTodate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }


         if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct From Date.');</script>");
        }
         else if (GrDate != "")
         {
             ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct End Date.');</script>");
         }

         else
         {
             Dt = new DataTable();
             Dt = obCommonFuction.FillTableByProc("call GetVendorWiseChallnaDetails1(" + ddlVendor.SelectedValue + ",'" + ddlYear.SelectedItem.Text + "','" + Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "',"+ddlGSM.SelectedValue +")");

             if (Dt.Rows.Count > 0)
             {
                 ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
                 ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/CenterDepot/CenteralReport/VendorWisechallanDetails.rdlc");
                 ReportViewer1.LocalReport.DataSources.Clear();
                 ReportViewer1.LocalReport.DataSources.Add(rds);
                 // ReportViewer1.LocalReport.EnableExternalImages = true;
                 ReportParameter[] Param = new ReportParameter[3];
                 Param[0] = new ReportParameter("VendorName", ddlVendor.SelectedItem.Text);
                 Param[1] = new ReportParameter("FromDate", txtFromDate.Text);
                 Param[2] = new ReportParameter("Todate", txtTodate.Text);
                 ReportViewer1.LocalReport.SetParameters(Param);


                 ReportViewer1.ShowPrintButton = true;
                 ReportViewer1.LocalReport.Refresh();
                 ReportViewer1.Visible = true;
             }
             else
             {
                 ReportViewer1.Visible = false;
                 ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
             }
         }
    }
    protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_OtherthanTextbookRpt : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds = new DataSet();
    DataTable Dt;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                CommonFuction comm = new CommonFuction();
                ddlSessionYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                ddlSessionYear.DataValueField = "AcYear";
                ddlSessionYear.DataTextField = "AcYear";
                ddlSessionYear.DataBind();

              
                DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
                //ddlTital.DataSource = asdf.Tables[0];
                //ddlTital.DataTextField = "TitleHindi_V";
                //ddlTital.DataValueField = "TitleID_I";
                //ddlTital.DataBind();
                //ddlTital.Items.Insert(0, new ListItem("All", "0"));

                ddlTital.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand('43','-2')");
                ddlTital.DataTextField = "TitleHindi_V";
                ddlTital.DataValueField = "TitleID_I";
                ddlTital.DataBind();
                ddlTital.Items.Insert(0, new ListItem("All", "0"));


              
                DataSet asdf1 = comm.FillDatasetByProc("SELECT SubTitleID_I,SubTitleHindi_V FROM `acb_subtitle` WHERE TitleID_I=" + ddlTital.SelectedValue + "");
                ddlSubTital.DataSource = asdf1.Tables[0];
                ddlSubTital.DataTextField = "SubTitleHindi_V";
                ddlSubTital.DataValueField = "SubTitleID_I";
                ddlSubTital.DataBind();
                ddlSubTital.Items.Insert(0, new ListItem("All", "0"));

            }
            catch (Exception ex) { 
            }

        }


       
    }


   
    protected void ddlTital_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf1 = comm.FillDatasetByProc("SELECT SubTitleID_I,SubTitleHindi_V FROM `acb_subtitle` WHERE TitleID_I=" + ddlTital.SelectedValue + "");
        ddlSubTital.DataSource = asdf1.Tables[0];
        ddlSubTital.DataTextField = "SubTitleHindi_V";
        ddlSubTital.DataValueField = "SubTitleID_I";
        ddlSubTital.DataBind();
        ddlSubTital.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void btnviewReport_Click(object sender, EventArgs e)
    {

        try
        {

            DataSet dd = obCommonFuction.FillDatasetByProc("call Usp_OtherthanTextbook_RptDepoWiseAll ('" + ddlSessionYear.SelectedValue + "','" + ddlTital.SelectedValue + "','" + ddlSubTital.SelectedValue + "' ) ");
            if (dd.Tables[0].Rows.Count > 0)
            {


                ReportDataSource rds = new ReportDataSource();

                rds.Name = "DataSet1";

                Dt = dd.Tables[0];
                rds.Value = Dt;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report3.rdlc");
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("OtherthanTextbookRptView.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);
                ReportViewer1.LocalReport.EnableExternalImages = true;

                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();



            }
            else
            {
                ReportViewer1.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
                
            }
        }

        catch
        {

        }
    }
}
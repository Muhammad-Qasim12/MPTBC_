using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using MPTBCBussinessLayer;
using Microsoft.Reporting.WebForms;
public partial class Printing_TechnicalAssement : System.Web.UI.Page
{
    DataTable Dt; WorkOrderDetails obWorkOrderDetails = null;
    DataSet   DS;
    CommonFuction obCommonFuction = new CommonFuction(); 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        

        DS = obCommonFuction.FillDatasetByProc("Call getlunlistbycompanytenderassmtfin(" + ddlTenderID_I.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "' , 'Sheet' )");
        Dt = obCommonFuction.FillTableByProc("select DID, Company, Rates, Rank, GroupNO, Tenderid, round(qty,0)qty, color, PrinterCapecity, statusid, emd from tblgroupchecknew where Tenderid=" + ddlTenderID_I.SelectedValue + " order by Company ");
        //Dt = obCommonFuction.FillTableByProc("call getlunlistbycompanytenderassmtfin("+ddlTenderID_I.SelectedValue+",'"+DdlACYear.SelectedItem.Text+"','test')");
       
            string Title = "";

            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/TecAssement.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
       DataSet dd= obCommonFuction.FillDatasetByProc("call Prin_loadTenderDetails(0,'" + DdlACYear.SelectedItem.Text + "')"); ;
       ddlTenderID_I.DataSource = dd.Tables[0];
       ddlTenderID_I.DataValueField = "TenderId_I";
       ddlTenderID_I.DataTextField = "TenderNo_V";
       ddlTenderID_I.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System.Globalization;
public partial class Depo_PrinternotSUpplybookdepo : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    string classA; DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
            if (Session["RoleId"].ToString() == "3")
            {
                DDlDepot.Enabled = false;
                DDlDepot.SelectedValue = Session["UserID"].ToString();

            }
            else {
                DDlDepot.Enabled = true;
            }
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int MediumIDa ;

            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";

            if (ddlMedium.SelectedIndex == 0)
            {
            MediumIDa=0;
            }
            else
            {
                MediumIDa =Convert.ToInt32 (ddlMedium.SelectedValue);
            }
            //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
            DataSet dd = obCommonFuction.FillDatasetByProc("call DistPrinterAwantPrapti ('" + DdlACYear.SelectedValue + "','" + Convert.ToString(DDlDepot.SelectedValue) + "','" + MediumIDa.ToString () + "','" + DDLClass.SelectedValue + "') ");
            Dt = dd.Tables[0];
            rds.Value = Dt;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("rptAPring.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("DepoName", DDlDepot.SelectedItem.Text);
            Param[1] = new ReportParameter("DateA", System.DateTime.Now.ToString ("dd/MM/yyyy"));
           
            ReportViewer1.LocalReport.SetParameters(Param);
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
        }
        catch { }
    }
}
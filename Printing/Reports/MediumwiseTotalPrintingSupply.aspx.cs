
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Printing_Reports_MediumwiseTotalPrintingSupply : System.Web.UI.Page
{
    DataTable Dt;
    DataSet ds; string ClassID;
    //PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    //PRI_PaperAllotment obPRI_PaperAllotment = null;
    DPT_DepotMaster obDPT_DepotMaster = null;
    string CntrDepot_Id = "";
    double TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            tdRecieptDate.Attributes.Add("style", "display:none;");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            FillDepot();
            FillMedium();

        }
    }

    private void FillDepot()
    {

        DdlDepo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectMainBookDepot1()");
        DdlDepo.DataTextField = "DepoName_V";
        DdlDepo.DataValueField = "DepoTrno_I";
        DdlDepo.DataBind();
        DdlDepo.Items.Insert(0, new ListItem("सभी", "0"));

        //obDPT_DepotMaster = new DPT_DepotMaster();
        //obDPT_DepotMaster.DepoTrno_I = 0;
        //obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["DepoTrno_I"]);
        //DdlDepo.DataSource = obDPT_DepotMaster.Select();
        //DdlDepo.DataTextField = "DepoName_V";
        //DdlDepo.DataValueField = "DepoTrno_I";
        //DdlDepo.DataBind();
        //DdlDepo.Items.Insert(0, new ListItem("सभी", "0"));
    }

    private void fnCheckControls()
    {
        if (rdSumry.Checked == true)
        {
            tdRecieptDate.Attributes.Add("style", "display:inline;");
            tdDepo.Attributes.Add("style", "display:none;");
            tdMedium.Attributes.Add("style", "display:none;");
            //tdClass.Attributes.Add("style", "display:none;");
        }
        else
        {
            tdRecieptDate.Attributes.Add("style", "display:none;");
            tdDepo.Attributes.Add("style", "display:inline;");
            tdMedium.Attributes.Add("style", "display:inline;");
            tdClass.Attributes.Add("style", "display:inline;");
        }
    }

    private void FillMedium()
    {
        DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
        DdlMedium.DataValueField = "MediumTrno_I";
        DdlMedium.DataTextField = "MediunNameHindi_V";
        DdlMedium.DataBind();
        DdlMedium.Items.Insert(0, new ListItem("सभी", "0"));
    }

    protected void BtnShow_Click(object sender, EventArgs e)
    {
       
        if (DropDownList1.SelectedValue == "1" )
        {
            ClassID = "1,2,3,4,5,6,7,8";
        }
        else if (DropDownList1.SelectedValue == "2")
        {
            ClassID = "9,10,11,12";
        }
        else if (DropDownList1.SelectedValue == "0")
        {
            ClassID = "1,2,3,4,5,6,7,8,9,10,11,12";
        }
        string strReportPath = Server.MapPath("~/Printing/Reports/ReportMediumwiseBooksAllotmentMtxRpt.rdlc");
        string finYr = DdlACYear.SelectedItem.Text;
        string strReciptDate = txtFromDate.Text != string.Empty ? Convert.ToDateTime(txtFromDate.Text,cult).ToString("yyyy-MM-dd") : "";
        if (rdSumry.Checked == true)
        {
            strReportPath = Server.MapPath("~/Printing/Reports/ReportMediumwiseBooksAllotmentMtxRpt_NewFormat.rdlc");
            Dt = obCommonFuction.FillTableByProc("Call USP_RPT009_GetMediumwiseAvantanReceiveddetail_ByBookStatus('" + finYr + "','" + DdlMedium.SelectedValue + "','" + DdlDepo.SelectedValue + "','" + ClassID + "','" + strReciptDate + "')");
        }
        else
            Dt = obCommonFuction.FillTableByProc("Call USP_RPT009_GetMediumwiseAvantanReceiveddetail('" + finYr + "','" + DdlMedium.SelectedValue + "','" + DdlDepo.SelectedValue + "','" + ClassID + "')");

        if (Dt.Rows.Count > 0)
        {

            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/ReportMediumwiseBooksAllotment.rdlc");
            ReportViewer1.LocalReport.ReportPath = strReportPath;
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);
            string rptFrom = txtFromDate.Text != "" ? "रिपोर्ट कब तक: " + txtFromDate.Text : "";
            string Title = "";
            Title = "डिपो : " + DdlDepo.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " माध्यम : " + DdlMedium.SelectedItem.Text.ToString().Replace("All", "सभी") + ", कक्षा: " + DropDownList1.SelectedItem.Text.ToString().Replace("All", "सभी") + Environment.NewLine + rptFrom;
            Param[1] = new ReportParameter("Class", Title);            

            ReportViewer1.LocalReport.SetParameters(Param);
            // ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            ReportViewer1.Visible = true;
        }
        else
        {
            ReportViewer1.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
            // GridView1.DataSource = null;
            // GridView1.DataBind();
        }
        fnCheckControls();
    }
}
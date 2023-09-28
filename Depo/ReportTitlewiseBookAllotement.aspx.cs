
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

public partial class Printing_Reports_ReportTitlewiseBookAllotement : System.Web.UI.Page
{
    DataTable Dt;
    DataSet ds;

    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    string CntrDepot_Id = "";
    double TotNet = 0, TotGrossWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillParameters();
        }
    }

    private void LoadReport(string year, int mclass, int mMedium, int mTitle)
    {
        //string finYr = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string finYr = DdlACYear.SelectedItem.Text;
        //Dt = obCommonFuction.FillTableByProc("Call USP_PRI012_PrinterOrderDtlChild('" + "" + "','" + "" + "','" + "" + "',6,'" + finYr + "')");
        if (rdoRptSummary.Checked == true)
        {
            ds = obCommonFuction.FillDatasetByProc ("Call USP_DPT_GetBookwiseReceived('" + finYr + "','" + mclass + "','" + mMedium + "','" + mTitle + "'," + Session["UserID"] + ")");
            Dt = ds.Tables[0];
        }
        else if (rdoRptDetail.Checked == true)
        {
            ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_GetBookwiseReceiveddetail('" + finYr + "','" + mclass + "','" + mMedium + "','" + mTitle + "',"+Session["UserID"]+")");
            Dt = ds.Tables[0];
        }
        if (Dt.Rows.Count > 0)
        {
            ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
            if (rdoRptSummary.Checked == true)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/ReportTitlewiseBookAllotement.rdlc");
            }
            else if (rdoRptDetail.Checked == true)
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/ReportTitlewiseBookAllotementDetails.rdlc");
            }
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportParameter[] Param = new ReportParameter[2];
            Param[0] = new ReportParameter("Year", finYr);

            string Title = "";
            Title = "कक्षा: " + DdlClass.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " माध्यम: " + ddlMedium.SelectedItem.Text.ToString().Replace("All", "सभी") + ", " + " शीर्षक: " + ddlTital.SelectedItem.Text.ToString().Replace("All", "सभी");
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
    }

    private void fillParameters()
    {
        CommonFuction comm = new CommonFuction();
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();

        DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
        DdlClass.DataValueField = "ClassTrno_I";
        DdlClass.DataTextField = "Classdet_V";
        DdlClass.DataBind();
        DdlClass.Items.Insert(0, new ListItem("All", "0"));

        ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
        ddlMedium.DataValueField = "MediumTrno_I";
        ddlMedium.DataTextField = "MediunNameHindi_V";
        ddlMedium.DataBind();
        ddlMedium.Items.Insert(0, new ListItem("All", "0"));

        DataSet asdf = comm.FillDatasetByProc("call USP_FillTitle(0)");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //if (DdlClass.SelectedIndex == 0)
        //{
        //    LoadReport(DdlACYear.SelectedItem.Text, 0);
        //}
        //else
        //{
        //    LoadReport(DdlACYear.SelectedItem.Text, Int32.Parse(DdlClass.SelectedValue));
        //}
        LoadReport(DdlACYear.SelectedItem.Text, Int32.Parse(DdlClass.SelectedValue), Int32.Parse(ddlMedium.SelectedValue), Int32.Parse(ddlTital.SelectedValue));
    }
}
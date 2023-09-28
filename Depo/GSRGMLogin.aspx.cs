using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Depo_GSRGMLogin : System.Web.UI.Page
{
    public CommonFuction obCommanFun = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public DataSet ds = new DataSet(); PRI_PaperAllotment obPRI_PaperAllotment = null;
    public int j;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromdate.Text = "01/09/2017";
            txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            //obPRI_PaperAllotment.Printer_RedID_I = 0;
            DataSet ds = comm.FillDatasetByProc(@"select distinct Printer_RedID_I Printer_regid_i,TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s','')) NameofPress_V from dis_vitrannirdesh
inner join pri_printerregistration_t on pri_printerregistration_t.Printer_RedID_I=PrinterID
where AcYear='" + comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString() + "' order by TRIM( REPLACE( REPLACE(REPLACE( NameofPressHindi_V ,'Ms ',''),'M./s',''),'M/s',''))");
               // obPRI_PaperAllotment.SelectddlPrinterName();
            ddlPrinter.DataSource = ds.Tables[0];
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_regid_i";
            //ddlPrinterName.DataValueField = "NameofPress_V";
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, new ListItem("All", "0"));
            DDlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlAcYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataValueField = "AcYear";
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.SelectedValue = comm.GetFinYear();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            ExportDiv.Visible = true;
            //DPT_DepotMaster obDPT_DepotMaster = null;
            //obDPT_DepotMaster = new DPT_DepotMaster();
            //obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            //DataSet obDataSet = obDPT_DepotMaster.Select();
            //lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            //lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            //lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            //lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();
            //string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
            //lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CommonFuction comm = new CommonFuction();

            //lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            Label1.Text = txtFromdate.Text;
            Label2.Text = txtTodate.Text;

            //GridView1.DataSource = obCommanFun.FillDatasetByProc("call USP_DPTGetGSRRegister(" + Convert.ToInt32(Session["UserID"]) + ",'" + txtFromdate.Text + "','" + txtTodate.Text + "')");
            //GridView1.DataBind();
            string Title = "दिनांक : " + txtFromdate.Text + " से दिनांक : " + txtTodate.Text + " तक , माध्यम -" + ddlMedium.SelectedItem.Text + ", पुस्तक का नाम -" + ddlTital.SelectedItem.Text + "";
            DataSet ds = new DataSet();
            //string fromDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
            //string toDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
            ds = obCommanFun.FillDatasetByProc("call USP_DPTGetGSRRegisterGM(" + ddlPrinter.SelectedValue + ",'" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlMedium.SelectedValue + "," + ddlTital.SelectedValue + ",'"+ddlAcYear.SelectedValue+"','"+DDlDepot.SelectedValue+"')");
            LoadReport(ds, ddlPrinter.SelectedValue, Title, comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString());
            ds.Dispose();
        }
        catch { }
    }

    public void LoadReport(DataSet dsGSR, string DepoName, string Title, string FinancialYear)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = dsGSR.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/GSRGM.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("p_DepoName", ddlPrinter.SelectedItem.Text));
        Param.Add(new ReportParameter("p_Title", Title));
        Param.Add(new ReportParameter("p_FYear", FinancialYear));

        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Depo_RptVitranNirdesh : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;
  MDDashboard md=new MDDashboard ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
        }


    }
    protected void BtnShow_Click(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        //lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
        //lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
        //lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
        //lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();
        string Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        //lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        CommonFuction comm = new CommonFuction();
        //lblfyYaer.Text = comm.GetFinYear();
        //Dt = md.VitranNirdesh(Convert.ToString(DdlACYear.SelectedItem.Text), Convert.ToInt32(Session["UserID"]));
        DataSet ddd = obCommonFuction.FillDatasetByProc("Call DTP_GetDistributionOrder('" + DdlACYear.SelectedValue + "'," + Session["UserID"] + "," + ddlMedium.SelectedValue + ",'" + Classes + "')");
        Dt = ddd.Tables[0];
        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Rptvitrannirdesh.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        // ReportViewer1.LocalReport.EnableExternalImages = true;

        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("Deponame", Convert.ToString(obDataSet.Tables[0].Rows[0]["DepoName_V"])));
        Param.Add(new ReportParameter("FyYear", DdlACYear.SelectedItem.Text)); //comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()));
        ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
}
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Distrubution_RptDistrictWiseDistribution : System.Web.UI.Page
{
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"] != null)
        {
            if (Request.QueryString["Type"] == "A")
            {
                Response.Redirect("RptDistrictWiseDistribution.aspx?Type=" + objdb.Encrypt("A"));
            }
            lblTitleName.Text = "जिला वार पाठ्यपुस्तको का आवंटन / District Wise Textbooks Allotment";
            Page.Title = lblTitleName.Text;
        }
        else
        {
            lblTitleName.Text = "जिला वार पाठ्यपुस्तको का आवंटन एवं प्रदाय / District Wise Textbooks Allotment and Supply";
            Page.Title = lblTitleName.Text;
        }

        if (Convert.ToString(Session["UserName"]).ToUpper() == "RSK" || Convert.ToString(Session["UserName"]).ToUpper() == "RSK")
        {
            DDLClass.Visible = false;
        }


        if (!Page.IsPostBack)
        {

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataValueField = "SchemeID";
            DdlScheme.DataBind();
           // DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));

           

        }
    }
    public void LoadReport()
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        string Classes = "";
        if (Convert.ToString(Session["UserName"]).ToUpper() == "RSK")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (Convert.ToString(Session["UserName"]).ToUpper() == "DPI")
        {
            Classes = "9,10,11,12";
        }
        else
        {
            if (DDLClass.SelectedValue.ToString() == "1-8")
            {
                Classes = "1,2,3,4,5,6,7,8";
            }
            else if (DDLClass.SelectedValue.ToString() == "9-12")
            {
                Classes = "9,10,11,12";
            }

        }

        DS = obCommonFuction.FillDatasetByProc(@"CALL USP_DIS_RPTDistrictWiseDistribution(" + Convert.ToInt32(DDlDepot.SelectedValue)
                                                                                 + ",'" + Classes + "'"
                                                                                 + "," + Convert.ToInt32(DdlScheme.SelectedValue)
                                                                                 + ",'" + Convert.ToString(DdlACYear.SelectedValue)
                                                                                 + "','" + DDlDemandType.SelectedItem.Value + "')");

        rds.Value = DS.Tables[0];
        if (Request.QueryString["Type"] != null)
        {
            if (Convert.ToString(objdb.Decrypt(Request.QueryString["Type"])) == "A")
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/DistWiseAllotment.rdlc");
            }
        }

        else
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/DistWiseDistribution.rdlc");
        }
        string Title = "";
        Title = "डिपो : " + DDlDepot.SelectedItem.Text + ", " + " कक्षा : " + DDLClass.SelectedItem.Text + ", " + " योजना : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "सभी");

        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameter[] Param = new ReportParameter[2];
        Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        Param[1] = new ReportParameter("Title", Title);
        ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }

    protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
        DdlScheme.DataTextField = "SchemeName_Hindi";
        DdlScheme.DataBind();

        //DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));
    }
}

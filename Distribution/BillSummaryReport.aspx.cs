using System;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Distribution_BillSummaryReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            string Class = Convert.ToString(DdlClass.SelectedItem.Text);
            if (Class != "9-12")
            {
                Class = "1-8";
            }
            if (Class == "9-12")
            {
                DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
                DdlScheme.DataValueField = "MediumTrno_I";
                DdlScheme.DataTextField = "MediunNameHindi_V";
                DdlScheme.DataBind();
                DdlScheme.Items.Insert(0, new ListItem("All", "0"));
            }
            else
            {

                DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + Class + "')");
                DdlScheme.DataValueField = "SchemeId";
                DdlScheme.DataTextField = "SchemeName_Hindi";
                DdlScheme.DataBind();
                DdlScheme.Items.Insert(0, new ListItem("-Select-", "0"));
            }
        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Class = Convert.ToString(DdlClass.SelectedItem.Text);
        if (Class != "9-12")
        {
            Class = "1-8";
        }
        if (Class == "9-12")
        {
            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("All", "0"));
        }
        else
        {

            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + Class + "')");
            DdlScheme.DataValueField = "SchemeId";
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";
        DataSet DS;
        DS = obCommonFuction.FillDatasetByProc(@"Call USP_DIS_BillEstimationNew(" + Convert.ToInt32(DdlScheme.SelectedValue)
                                                                                + ",'" + Convert.ToString(DdlClass.SelectedValue)
                                                                                + "','" + Convert.ToString(DdlACYear.SelectedValue)
                                                                                + "','" + Convert.ToString(DDlDemandType.SelectedValue)
                                                                                + "','100')");

        rds.Value = DS.Tables[0];
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/BillDetails.rdlc");
    }
}
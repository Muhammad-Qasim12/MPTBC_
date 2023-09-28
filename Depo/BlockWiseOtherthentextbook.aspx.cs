using System;
using System.Data;
using MPTBCBussinessLayer.DistributionB;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer.Store;

public partial class Depo_BlockWiseOtherthentextbook : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    RDLC_Data objReports = new RDLC_Data();
    CommonFuction comm = new CommonFuction();
    CommonFuction obCommonFuction = new CommonFuction();
    STR_VendorMaster obSTR_VendorMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFyYr.DataSource = objReports.FillFyYear().Tables[0];
            ddlFyYr.DataTextField = "AcYear";
            ddlFyYr.DataValueField = "Id";
            ddlFyYr.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlFyYr.DataBind();
            FillLetterNo();

            //DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            //DDlDepot.DataValueField = "DepoTrno_I";
            //DDlDepot.DataTextField = "DepoName_V";
            //DDlDepot.DataBind();
            //DDlDepot.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            //DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    private void FillLetterNo()
    {
        // CommonFuction comm = new CommonFuction();
        //   objReports.FyYearID = int.Parse(ddlFyYr.SelectedValue);
        ddlLetterNo.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand(" + ddlFyYr.SelectedValue + ",'-2')");
        ddlLetterNo.DataTextField = "LetterNo_Va";
        ddlLetterNo.DataValueField = "LetterNo_V";
        ddlLetterNo.DataBind();
        ddlLetterNo.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
    }
}
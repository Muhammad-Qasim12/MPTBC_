using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_View19 : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    ClassMaster obClass = null;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    protected void Page_Load(object sender, EventArgs e)
    {  int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (!IsPostBack)
        {
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlMedum.DataSource = objTentativeDemandHistory.MedumFill();
            ddlMedum.DataValueField = "MediumTrno_I";
            ddlMedum.DataTextField = "MediunNameHindi_V";
            ddlMedum.DataBind();
            ddlMedum.Items.Insert(0, "All");
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
            if (DateTime.Today.Month > 3)
                finYear = CurrentYear.ToString() + "-" + NextYear;
            else
                finYear = PreviousYear + "-" + CurrentYear.ToString();
           
             obClass = new ClassMaster();
             DataSet dtclass = obClass.Select();
             obClass.ClassTrno_I = 0;

             ddlClass.DataTextField = "Classdet_V";
             ddlClass.DataValueField = "ClassTrno_I";
             ddlClass.DataSource = dtclass;
             ddlClass.DataBind();
             ddlClass.Items.Insert(0, "All");
             GrdBooksMaster.DataSource = obCommonFuction.FillDatasetByProc(@"call USP_DPTGetDemand (" + Session["userID"] + ",'"+ddlSessionYear.SelectedValue+"',0,0)");
            GrdBooksMaster.DataBind();
        }

    }
    protected void Redirect(object sender, EventArgs e)
    {
        Response.Redirect("DPT_019_DemadFromOpenMarket.aspx");
    }

    protected void btnSave0_Click(object sender, EventArgs e)
    {
        string ClassID;
        string mediumID;
        if (ddlClass.SelectedItem.Text == "All")
        {
        ClassID="0";
        }else 
        {
        ClassID=ddlClass.SelectedValue ;
        }
        if (ddlMedum.SelectedItem.Text == "All")
        {
            mediumID = "0";
        }
        else
        { mediumID = ddlMedum.SelectedValue; }
        GrdBooksMaster.DataSource = obCommonFuction.FillDatasetByProc(@"call USP_DPTGetDemandNew (" + Session["userID"] + ",'" + ddlSessionYear.SelectedValue + "'," + ClassID + "," + mediumID + ")");
        GrdBooksMaster.DataBind();
        
    }
}
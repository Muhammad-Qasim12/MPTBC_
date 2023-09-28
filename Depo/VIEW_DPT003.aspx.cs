using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Depo_VIEW_DPT003 : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    //TransportDetails obTransportDetails = null;
    TransportMaster obTransportMaster = null;
    CommonFuction obCommonFuction = null;
    DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
    TransportDetails obTransportDetails = null;
     DataTable dtAttendance;
   public APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obDPT_DepotMaster.DepoTrno_I = 0;
            DataSet depo = obDPT_DepotMaster.Select();

            obTransportMaster = new TransportMaster();
            obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet1 = obTransportMaster.Select();
            ddlTrnasportName.DataTextField = "TransportName_V";
            ddlTrnasportName.DataValueField = "TransportID_I";
            ddlTrnasportName.DataSource = obDataSet1.Tables[0];
            ddlTrnasportName.DataBind();
            ddlTrnasportName.Items.Insert(0, "सेलेक्ट..");
            obCommonFuction = new CommonFuction();
            ddlFyYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlFyYear.DataValueField = "AcYear";
            ddlFyYear.DataTextField = "AcYear";
            ddlFyYear.DataBind();
            ddlFyYear.SelectedValue = obCommonFuction.GetFinYear();
            FillData();
        }
    }
    public string GetFinYear()
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        return finYear;
    }
    public void FillData()
    {
        try
        {
            obTransportDetails = new TransportDetails ();
            obTransportDetails.TransportDetailsID_I = 0;
            obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            GrdTransport.DataSource = obTransportDetails.Select();
            GrdTransport.DataBind();

        }
        catch
        {
        }
        finally { }
    }
    
    protected void GrdTransport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTransport.PageIndex = e.NewPageIndex;
        obTransportDetails = new TransportDetails();
        if (RadioButtonList1.SelectedValue == "1")
        {
            obTransportDetails.TransportDetailsID_I = -3;
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            obTransportDetails.TransportDetailsID_I = -4;
        }
        else { obTransportDetails.TransportDetailsID_I =0; }

        obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
        GrdTransport.DataSource = obTransportDetails.Select();
        GrdTransport.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT003_TransportDetails.aspx");
    }
    protected void GrdTransport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {
            obTransportDetails = new TransportDetails();
            obTransportDetails.Delete(Convert.ToInt32(e.CommandArgument));
            FillData();
            Response.Write("<script>alert('Record has deleted');</script>");
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        obTransportDetails = new TransportDetails();
        if (RadioButtonList1.SelectedValue == "1")
        {
            obTransportDetails.TransportDetailsID_I =-3;
        }
        else { obTransportDetails.TransportDetailsID_I = -4; }
      
        obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
        GrdTransport.DataSource = obTransportDetails.Select();
        GrdTransport.DataBind();
       
    }
    protected void btnSave0_Click(object sender, EventArgs e)
    {
        try {
        obTransportDetails = new TransportDetails();
        obTransportDetails.TransportDetailsID_I = -5;
        obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
        obTransportDetails.FyID = Convert.ToString(ddlFyYear.SelectedValue);
        obTransportDetails.TransportID_I = Convert.ToInt32(ddlTrnasportName.SelectedValue);
        GrdTransport.DataSource = obTransportDetails.Select();
        GrdTransport.DataBind();
        }
        catch
        {
            GrdTransport.DataSource =null;
            GrdTransport.DataBind();
        }
    }
}
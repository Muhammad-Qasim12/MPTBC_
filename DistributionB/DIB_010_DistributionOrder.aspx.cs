using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;

public partial class DistributionB_Default : System.Web.UI.Page
{
    DistributionOrder obDistributionOrder = new DistributionOrder();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction obCommonFuction = new CommonFuction();
            ddlAcYr.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYr.DataValueField = "AcYear";
            ddlAcYr.DataTextField = "AcYear";
            ddlAcYr.DataBind();
            ddlAcYr.SelectedValue = obCommonFuction.GetFinYear();

            obDistributionOrder.QueryType= 0;
            ddlGroup.DataSource= obDistributionOrder.Select();
            ddlGroup.DataTextField = "GroupName";
            ddlGroup.DataValueField = "GroupId";
            ddlGroup.DataBind();


            ddlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ACB001_TitleMasterSelect(0)");
            ddlTitle.DataValueField = "TitleID_I";
            ddlTitle.DataTextField = "TitleHindi_V";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, new ListItem("Select..", "0"));
            FillSubTitle();
        }
    }

    private void FillSubTitle()
    {
        if (ddlTitle.SelectedValue != null && ddlTitle.SelectedValue != "0")
        {
            CommonFuction obCommonFuction = new CommonFuction();
            ddlSubTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ACB001_TitleMasterSelect(0)");
            ddlSubTitle.DataValueField = "TitleID_I";
            ddlSubTitle.DataTextField = "TitleHindi_V";
            ddlSubTitle.DataBind();
            ddlTitle.Items.Insert(0, new ListItem("Select..", "0"));
        }
    }
    private void FillAcYr()
    {

    }
  
    protected void ddlSubTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        obDistributionOrder.QueryType = -1;
        ddlPrinter.DataSource = obDistributionOrder.Select();
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataValueField = "Printer_regid_i";
        ddlPrinter.DataBind();
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubTitle();
    }
}
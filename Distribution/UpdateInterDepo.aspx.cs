using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
public partial class Distribution_UpdateInterDepo : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    Dis_OpenMarketDemand objOpenMarketDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();

            ddlDepo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataBind();
            ddlDepo.Items.Insert(0, "Select");
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlMedium.DataSource = objTentativeDemandHistory.MedumFill();
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "Select");
      
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"
       SELECT `DemandChildTrNo`, `TitleHindi_V`, `NetDemand`,`NoOfBookTransferd` FROM `dpt_interdepobookstransferchild`
       INNER JOIN `acd_titledetail` ON acd_titledetail.`TitleID_I`=dpt_interdepobookstransferchild.`TitleID_I`
       
        WHERE `ChallanNo`=" + ddlOrder.SelectedValue + " and Medium_I="+ddlMedium.SelectedValue+" ");
        GridView1.DataBind();
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlDepo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOrder.DataSource = obCommonFuction.FillDatasetByProc(@" SELECT distinct ChallanNo FROM `dpt_interdepobookstransferchild` WHERE `FyYear`=(SELECT `AcYear` FROM `adm_acadmicyears` WHERE `Isactive`=1) AND `DemandingDepotID`=" + ddlDepo.SelectedValue + " ");
        ddlOrder.DataTextField = "ChallanNo";
        ddlOrder.DataValueField = "ChallanNo";
        ddlOrder.DataBind();
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            obCommonFuction.FillDatasetByProc("update dpt_interdepobookstransferchild set NetDemand="+((TextBox)GridView1.Rows[i].FindControl("txt01")).Text+",NoOfBookTransferd="+((TextBox)GridView1.Rows[i].FindControl("txt02")).Text+" where DemandChildTrNo="+((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value +"");
        }
        GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"
       SELECT `DemandChildTrNo`, `TitleHindi_V`, `NetDemand`,`NoOfBookTransferd` FROM `dpt_interdepobookstransferchild`
       INNER JOIN `acd_titledetail` ON acd_titledetail.`TitleID_I`=dpt_interdepobookstransferchild.`TitleID_I`
       
        WHERE `ChallanNo`=" + ddlOrder.SelectedValue + " and Medium_I=" + ddlMedium.SelectedValue + " ");
        GridView1.DataBind();
    }
}
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ChallanDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlChallano.DataSource = obCommonFuction.FillDatasetByProc(@"select distinct StockDistributionSEntryID_I, ChallanNo_V from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=blockID_I  where dpt_stockdistributionschemeentry_m.UserID  ='" + Convert.ToString(Session["UserID"]) + "' and SendStatus not in(1,2) and YearID=( SELECT AcYear FROM `adm_acadmicyears` WHERE `Isactive`=1 )");
            ddlChallano.DataValueField = "StockDistributionSEntryID_I";
            ddlChallano.DataTextField = "ChallanNo_V";
            ddlChallano.DataBind();
            ddlChallano.Items.Insert(0, "select..");
        }
    }
protected void Button3_Click1(object sender, EventArgs e)
{
    obCommonFuction.FillDatasetByProc("delete from Tbl_ChallanBundel");
    obCommonFuction.FillDatasetByProc("call USP_ChallanWiseData("+ddlChallano.SelectedValue+")");
    GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"SELECT DISTINCT `distributID`, BundleNo_I,BundleNo,BundleNo_I ,`DepoName_V`,ChallanNo_V, `TitleHindi_V` ,
BundleNo, CASE WHEN IFNULL(BundleNo_I,'') ='' OR distributID<>ChallanID  THEN BundleNo ELSE '' END 
 Unmatch,CASE WHEN IFNULL(BundleNo_I,'') <>'' AND distributID=ChallanID THEN BundleNo ELSE '' END matcha,
 CASE WHEN  distributID<>ChallanID THEN (SELECT `ChallanNo_V` FROM dpt_stockdistributionschemeentry_m WHERE distributID=StockDistributionSEntryID_I) ELSE '' END ChallanID
 FROM tbl_challanbundel
INNER JOIN dpt_stockdistributionschemeentry_m 
ON dpt_stockdistributionschemeentry_m.`StockDistributionSEntryID_I`=ChallanID
LEFT JOIN  `dpt_stockdetailschild_t` ON dpt_stockdetailschild_t.`BundleNo_I`=BundleNo
LEFT JOIN `dpt_stockdetails_t` ON dpt_stockdetails_t.`StockDetailsID_I`=dpt_stockdetailschild_t.StockDetailsID_I
LEFT JOIN `acd_titledetail` ON acd_titledetail.`TitleID_I`=`SubJectID_I`
LEFT JOIN `dpt_warehouuse_m` ON dpt_warehouuse_m.`WareHouseID_I`=dpt_stockdetailschild_t.`WareHouseID`
LEFT JOIN adm_depomaster_m ON adm_depomaster_m.`DepoTrno_I`=dpt_warehouuse_m.`UserID_I`
 WHERE IFNULL(BundleNo,'') <>''
");
 GridView1.DataBind();
}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_BookSellerChallanDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BookSellerDemand obBookSellerDemand = null;
  public  DataSet book1 ,book;
  public double totalrate;

  public double tatalbook, totalRate, totalAllAmount,DraftAmount,commissionAmount;
  public int j;
  public double Categorya;
  DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label2.Text = "0";
            CommonFuction comm = new CommonFuction();
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblDepoName.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
            lblFYear.Text = comm.FillDatasetByProc("select GetAcYearDepo()").Tables[0].Rows[0][0].ToString();
            lblCurrentDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            try {
        DataSet Demand = comm.FillDatasetByProc("call USP_DPT_BookSellerbyDepoLoad(0," + Convert.ToInt32(Session["UserID"]) + ",0)");

        ddlBookSllerName.DataSource = Demand;
        ddlBookSllerName.DataValueField = "LoginID_V";
        ddlBookSllerName.DataTextField = "BooksellerName_V";
        ddlBookSllerName.DataBind();
        HiddenField1.Value = Demand.Tables[0].Rows[0]["LoginID_V"].ToString();
        ddlBookSllerName.Items.Insert(0, "Select");
            }
            catch { }
        if (Request.QueryString["BookSellerID"] != null)
            {
                ar.Visible = false;
                ddlBookSllerName.SelectedValue = "";
        book = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + Request.QueryString["BookSellerID"] + "',1,'" + Request.QueryString["ChallanID"] + "')");
        Categorya =Convert.ToDouble( book.Tables[0].Rows[0]["Categorya"].ToString());
        book1 = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + Request.QueryString["BookSellerID"] + "',14,'" + Request.QueryString["ChallanID"] + "')");
        Panel1.Visible = true;
        Button1.Visible = true;
        ddlBookSllerName.SelectedValue = Request.QueryString["BookSellerID"];
        DataSet dd = comm.FillDatasetByProc("call USP_Dpt_BookChallandetails('" + Request.QueryString["BookSellerID"] + "','" + Request.QueryString["ChallanID"] + "')");
     Label1.Visible = true;
     Label2.Visible = true;
     try { 
     Label2.Text = dd.Tables[0].Rows[0]["RemaniAmount"].ToString();
     }
     catch { }
        
        }
           
        
        }

    }
    protected void ddlBookSllerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet ds = comm.FillDatasetByProc("select distinct BlockID_I from dpt_stockdistributionschemeentry_m inner join dpt_bookselledemandmaster on dpt_bookselledemandmaster.orderno=BlockID_I where DistrictID_I=0 and Issumbited_I=2 AND dpt_bookselledemandmaster.`Byear`= (SELECT `AcYear` FROM `adm_acadmicyears` WHERE `DepoYear`=1) and User_ID_I=" + ddlBookSllerName.SelectedValue + "");
        DropDownList1.DataTextField = "BlockID_I";
        DropDownList1.DataValueField = "BlockID_I";
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select..");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        CommonFuction comm = new CommonFuction();
        book = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + ddlBookSllerName.SelectedValue + "',1,'" + DropDownList1.SelectedValue + "')");
        try { 
        Categorya =Convert.ToDouble( book.Tables[0].Rows[0]["Categorya"].ToString());
        }
        catch { }
        book1 = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + ddlBookSllerName.SelectedValue + "',14,'" + DropDownList1.SelectedValue + "')");
        Panel1.Visible = true;
        if (Request.QueryString["BookSellerID"] == null)
        { 
        DataSet bb = comm.FillDatasetByProc("call GetBalanceAmount(" + DropDownList1.SelectedValue + ","+ddlBookSllerName.SelectedValue+")");
        try {
            Label2.Text = bb.Tables[0].Rows[0]["BalanceAmount"].ToString();
        }
        catch {
            Label2.Text = "0";
        }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction comm = new CommonFuction();
                if (Label2.Text == "")
                {
                    Label2.Text = "0";
                }
                comm.FillDatasetByProc("Call DPT_Dpt_BooksellerAccountDetailsSave('" + Request.QueryString["BookSellerID"] + "','" + Request.QueryString["ChallanID"] + "'," + HidDraftAmount.Value + "," + hdNetAmount.Value + "," + ((Convert.ToDouble(HidDraftAmount.Value) + Convert.ToDouble(HdCommisionAmount.Value)+Convert.ToDouble (Label2.Text)) - Convert.ToDouble(hdNetAmount.Value)) + "," + Session["UserID"] + "," + HdCommisionAmount.Value + ")");
                CommonFuction obCommonFuction = new CommonFuction();

                DataSet BookSellerLedger = obCommonFuction.FillDatasetByProc("call USP_Hr_BookSellerLedgerNamebyID(" + Request.QueryString["BookSellerID"] + ")");
                DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('J')");
               // DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('SBI MD Account Depot Bhopal-12345678345')");
                DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Sales (Other)')");
           // USP_HR_GetMDAccount
                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Book Purchase Amount',0,0," + Convert.ToString(Convert.ToDouble(hdNetAmount.Value) - Convert.ToDouble(HdCommisionAmount.Value)) + ",'Cash'," + LedgerID.Tables[0].Rows[0]["AGENCYID"] + ",'','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + BookSellerLedger.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,1)");

                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Book Purchase Amount',0," + Convert.ToString(Convert.ToDouble(hdNetAmount.Value) - Convert.ToDouble(HdCommisionAmount.Value)) + ",0,'Cash'," + LedgerID.Tables[0].Rows[0]["AGENCYID"] + ",'','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,1)");


            Response.Redirect("Booksellerchallandetails.aspx");
            Panel1.Visible = false;
            //book = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + Request.QueryString["BookSellerID"] + "',1,'" + Request.QueryString["ChallanID"] + "')");
            //Categorya = Convert.ToDouble(book.Tables[0].Rows[0]["Categorya"].ToString());
            //book1 = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + Request.QueryString["BookSellerID"] + "',14,'" + Request.QueryString["ChallanID"] + "')");
            
        }
        catch { }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_VIEW_DPT009 : System.Web.UI.Page
{
    DBAccess bd = new DBAccess();
    BookSellerDemand obBookSellerDemand = null;
    BooksellerMaster obBooksellerMaster = null;
    CommonFuction comm = new CommonFuction();
    public DataSet aaa;
    public int PerCentage;
    public double dddd;
  public  DataSet obDataSet;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();

            obDataSet = comm.FillDatasetByProc("call USP_DPTGetBoobsellerDetails(" + Session["UserID"] + ")");
           
           
        }

    }
   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT09_BookSelleDemandformat.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");

        obDataSet = comm.FillDatasetByProc("call USP_DPTGetBoobsellerDetails(" + Session["UserID"] + ")");
    }
    protected void lnkClick(object sender, EventArgs e)
    {
        LinkButton lnkClick = (LinkButton)(sender);
        obBookSellerDemand = new BookSellerDemand();
        obBookSellerDemand.User_ID_I = Convert.ToInt32(lnkClick.CommandArgument);

        obBookSellerDemand.DBookSelleDemandTrNo_I = 001;//001;
        DataSet Demand = obBookSellerDemand.Select();
        obDataSet = comm.FillDatasetByProc("call USP_DPTGetBoobsellerDetails(" + Session["UserID"] + ")");
        GridView2.DataSource = Demand.Tables[0];
        GridView2.DataBind();
        bd.execute("SELECT case when category=0 then 0 when category=1 then 15 when category=2 then 16 when category=3 then 13  when category=4 then 14 end  TotalPer FROM dpt_booksellerregistration_m where Booksellerregistration_I=(select Booksellerregistration_I from dpt_booksellerregistration_m where LoginID_V=" + Session["UserID"] + ")", DBAccess.SQLType.IS_QUERY);
        DataSet ds = bd.records();
        PerCentage = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalPer"]);

        Label1.Text = Convert.ToString(lnkClick.CommandArgument);
        aaa = comm.FillDatasetByProc("call GetBookDetailsOrder(" + Label1.Text + ")");
         lblCheckAmount.Text = aaa.Tables[0].Rows[0]["DDAmount"].ToString();
         lblCheckNo.Text = aaa.Tables[0].Rows[0]["DDNouber"].ToString();
         lblChekDate.Text = aaa.Tables[0].Rows[0]["DDDate"].ToString();
         lblTotalAmount.Text = aaa.Tables[0].Rows[0]["TotalAmounrt"].ToString();
         Label2.Text = Convert.ToString(Convert.ToDecimal(aaa.Tables[0].Rows[0]["TotalAmounrt"]) - ((Convert.ToDecimal(aaa.Tables[0].Rows[0]["TotalAmounrt"]) * PerCentage) / 100));
         lblBankName.Text = aaa.Tables[0].Rows[0]["BankName"].ToString();
         lblDate.Text = aaa.Tables[0].Rows[0]["Bdate_D"].ToString();
       // Label2.Text=
        Messages.Style.Add("display" ,"block");
        fadeDiv.Style.Add("display", "block");
       
     }
    
    
    public void fillgrd()
    {
           obBookSellerDemand = new BookSellerDemand();
        obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
        obBookSellerDemand.DBookSelleDemandTrNo_I = 002;//001;
        DataSet Demand = obBookSellerDemand.Select();
        grnMain.DataSource = Demand.Tables[0];
        grnMain.DataBind();
    }
    public void fillgrd1()
    {
        obBookSellerDemand = new BookSellerDemand();
        obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
        obBookSellerDemand.DBookSelleDemandTrNo_I = 001;//001;
        DataSet Demand = obBookSellerDemand.Select();
        GridView2.DataSource = Demand.Tables[0];
        GridView2.DataBind();

    }
}
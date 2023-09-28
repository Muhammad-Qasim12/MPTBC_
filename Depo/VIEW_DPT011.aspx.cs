using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_VIEW_DPT011 : System.Web.UI.Page
{
    DepoBookDemand obDepoBookDemand = new DepoBookDemand();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack  )
        {
        fillgrd();
        }
    }
    public void fillgrd()
    {
        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.DDemandID_I = 002;
        obDepoBookDemand.UserID_I = Convert.ToInt32(Session["UserID"]);
        DataSet ds= obDepoBookDemand.Select();
        grdbookdata1.DataSource = ds.Tables[0];
        grdbookdata1.DataBind();
    }
    protected void grdbookdata0_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdbookdata1.PageIndex = e.NewPageIndex;
        fillgrd();

    }

    protected void lnkClick(object sender, EventArgs e)
    {
        //   DBAccess obDBAccess = new DBAccess();
        //obDBAccess.execute("USP_DPT015_DemandDetails_Load", DBAccess.SQLType.IS_PROC);
        //obDBAccess.addParam("id", DDemandID_I);
        //obDBAccess.addParam("UserID", UserID_I);
        CommonFuction comm = new CommonFuction();
        LinkButton lnkClick = (LinkButton)(sender);
       // obDepoBookDemand = new DepoBookDemand();
     //   obDepoBookDemand.DDemandID_I = 003;
        //obDepoBookDemand.UserID_I = Convert.ToInt32(lnkClick.CommandArgument);
        DataSet ds1 = comm.FillDatasetByProc("call USP_DPT015_DemandDetails_Load(003,'" + (lnkClick.CommandArgument) + "')");
        grdbookdata0.DataSource = ds1.Tables[0];
        grdbookdata0.DataBind();
        //obBookSellerDemand = new BookSellerDemand();
        //obBookSellerDemand.User_ID_I = Convert.ToInt32(lnkClick.CommandArgument);

        //obBookSellerDemand.DBookSelleDemandTrNo_I = 001;//001;
        //DataSet Demand = obBookSellerDemand.Select();
        //obDataSet = comm.FillDatasetByProc("call USP_DPTGetBoobsellerDetails(" + Session["UserID"] + ")");
        //GridView2.DataSource = Demand.Tables[0];
        //GridView2.DataBind();
        //Label1.Text = Convert.ToString(lnkClick.CommandArgument);
        //aaa = comm.FillDatasetByProc("call GetBookDetailsOrder(" + Label1.Text + ")");
        //lblCheckAmount.Text = aaa.Tables[0].Rows[0]["DDAmount"].ToString();
        //lblCheckNo.Text = aaa.Tables[0].Rows[0]["DDNouber"].ToString();
        //lblChekDate.Text = aaa.Tables[0].Rows[0]["DDDate"].ToString();
        //lblTotalAmount.Text = aaa.Tables[0].Rows[0]["TotalAmounrt"].ToString();
        //lblBankName.Text = aaa.Tables[0].Rows[0]["BankName"].ToString();
        // Label2.Text=
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT011_DemandFormat.aspx");
    }
    protected void btnSave_Click1(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
  //  
}
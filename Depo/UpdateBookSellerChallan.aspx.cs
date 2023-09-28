using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_UpdateBookSellerChallan : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    BookSellerDemand obBookSellerDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    int count12;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            obBookSellerDemand = new BookSellerDemand();
            obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
            obBookSellerDemand.DBookSelleDemandTrNo_I = -33;
            DataSet Demand = obBookSellerDemand.Select();
            ddlBookSllerName.DataSource = Demand;
            ddlBookSllerName.DataValueField = "User_ID_I";
            ddlBookSllerName.DataTextField = "BooksellerOwnerName_V";
            ddlBookSllerName.DataBind();
            ddlBookSllerName.Items.Insert(0, "Select");
            ddlBookSllerName.Enabled = false;
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlMedium.DataSource = objTentativeDemandHistory.MedumFill();
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            ddlClass.DataValueField = "ClassTrno_I";
            ddlClass.DataTextField = "ClassDesc_V";
            ddlClass.DataBind();
            ddlClass.Items.Insert(0, "Select");

            if (Convert.ToString(Request.QueryString["BooKsellerID"]) != null)
            {
                ddlBookSllerName.SelectedValue = Request.QueryString["BooKsellerID"];
                ddlBookSllerName_SelectedIndexChanged(sender, e);
                DropDownList1.SelectedValue = Request.QueryString["CHallanNo"];
                DropDownList1_SelectedIndexChanged(sender, e);
            }

        }
    }
    protected void ddlBookSllerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet ds = comm.FillDatasetByProc("select distinct OrderNo from dpt_bookselledemandmaster where  User_ID_I=" + ddlBookSllerName.SelectedValue + "");
        DropDownList1.DataTextField = "OrderNo";
        DropDownList1.DataValueField = "OrderNo";
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select..");

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        //DataSet ds = obCommonFuction.FillDatasetByProc("call USP_BookSellerChallanGet(" + DropDownList1.SelectedValue + ")");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    txtChalanNo.Text = ds.Tables[0].Rows[0]["ChallanNo_V"].ToString();
        //    HiddenField2.Value = ds.Tables[0].Rows[0]["StockDistributionSEntryID_I"].ToString();
        //    Response.Redirect("BookSellerDistributionaNew.aspx?ID=" + ddlBookSllerName.SelectedValue + "&ChalanNo=" + DropDownList1.SelectedValue + "&Achall=" + HiddenField2.Value + "&Bchall=" + txtChalanNo.Text + "");
        //}
        //else
        //{


            fillgrd();
            //a.Style.Add ("display","block");
            //a2.Style.Add("display", "block");
            a.Visible = true;
            a2.Visible = true;
            a1.Visible = true;
            Button11.Visible = true;
            CommonFuction comm = new CommonFuction();
            DataSet book = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + ddlBookSllerName.SelectedValue + "',-15,'" + DropDownList1.SelectedValue + "')");
            Label1.Text = book.Tables[0].Rows[0]["DDNouber"].ToString();
            Label2.Text = book.Tables[0].Rows[0]["BankName"].ToString();
            Label3.Text = Convert.ToString(Math.Round(Convert.ToDouble(book.Tables[0].Rows[0]["TotalRate"]), 2));
            Label4.Text = Convert.ToString((Convert.ToDouble(book.Tables[0].Rows[0]["TotalAmount"]) * Convert.ToDouble(book.Tables[0].Rows[0]["Categorya"]) / 100));//Convert.ToString( Math.Round( book.Tables[0].Rows[0]["Discount"]),2)));
            Label5.Text = book.Tables[0].Rows[0]["DDDate"].ToString();
            Label6.Text = book.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
            Label10.Text = Convert.ToString(book.Tables[0].Rows[0]["TotalAmount"]);
            //+ Math.Round(Convert.ToDouble(book.Tables[0].Rows[0]["Discount"]), 2));
            Button1.Visible = true;

            Button2.Visible = true;
      //  }
    }
    public void fillgrd()
    {

        //obBookSellerDemand = new BookSellerDemand();
        //obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
        //obBookSellerDemand.DBookSelleDemandTrNo_I = -1;
        //DataSet Demand = obBookSellerDemand.Select();
        //DataTable objrow = Demand.Tables[0];
        //EnumerableRowCollection<DataRow> query = (from objrownew in objrow.AsEnumerable() where objrownew.Field<UInt32>("User_ID_I") == Convert.ToUInt32(ddlBookSllerName.SelectedValue) select objrownew);
        //DataView view = query.AsDataView();
        CommonFuction comm = new CommonFuction();
        // DataSet view = comm.FillDatasetByProc("Call USP_DPT012_BookDemandData_LoadNew(" + ddlBookSllerName.SelectedValue + "," + DropDownList1.SelectedValue + ")");
        DataSet view = comm.FillDatasetByProc("call USP_DPTGetbookSellerDetailsN (" + ddlBookSllerName.SelectedValue + "," + DropDownList1.SelectedValue + "," + Session["UserID"] + ")");
        grnMain.DataSource = view;
        grnMain.DataBind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        Div1.Style.Add("display", "block");
        Div2.Style.Add("display", "block");
        //USP_UpdateBooksellerDemand (ordernoa varchar(100),DDDatea varchar(20),DDNouber varchar(100),BankNamea varchar(200),DDAmounta varchar(10))

        obCommonFuction.FillDatasetByProc("call USP_UpdateBooksellerDemand(" + DropDownList1.SelectedItem.Text + ",'" + Convert.ToDateTime(Label5.Text, cult).ToString("yyyy-MM-dd") + "','" + Label1.Text + "','" + Label2.Text + "','" + Label3.Text + "')");
        txtReceiverName.Text = ddlBookSllerName.SelectedItem.Text;
        Random rand = new Random();

        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_BookSellerChallanGet(" + DropDownList1.SelectedValue + ")");
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtChalanNo.Text = ds.Tables[0].Rows[0]["ChallanNo_V"].ToString();
            txtChalanDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ChallanDate_D"]).ToString("dd/MM/yyyy");
            txtGRNDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["GRNODate_D"]).ToString("dd/MM/yyyy");
            txtGRNO.Text = ds.Tables[0].Rows[0]["GRNO_V"].ToString();
            txtTrucko.Text = ds.Tables[0].Rows[0]["TruckNo_V"].ToString();
            txtDriverMobileNo.Text = ds.Tables[0].Rows[0]["DriverMobileNo_V"].ToString();
            txtRemark.Text = ds.Tables[0].Rows[0]["Remarks_V"].ToString();
            HiddenField2.Value = ds.Tables[0].Rows[0]["StockDistributionSEntryID_I"].ToString(); ;


        }
        else
        {
            // 
            //
            //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('BookSeller','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmount.Text + ",0,'Bank'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "')");
            //
            try
            {
                DataSet BookSellerLedger = obCommonFuction.FillDatasetByProc("call USP_Hr_BookSellerLedgerNamebyID(" + ddlBookSllerName.SelectedValue + ")");
                DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                //  DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('SBI MD Account Depot Bhopal-12345678345')");
                DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_HR_GetMDAccount(" + Session["UserID"] + ")");
                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Book Purchase Amount',0,0," + Label3.Text + ",'Bank'," + LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() + ",'" + Label1.Text + "','" + Convert.ToDateTime(Label5.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,0)");
                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Book Purchase Amount',0," + Label3.Text + ",0,'Bank'," + LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() + ",'" + Label1.Text + "','" + Convert.ToDateTime(Label5.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + BookSellerLedger.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,0)");

            }
            catch { }


            int randnum = rand.Next(100000, 10000000);
            txtChalanNo.Text = DropDownList1.SelectedItem.Text;
            txtChalanDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtGRNDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtChalanNo.Enabled = false;
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       

         CommonFuction obCommonFuction = new CommonFuction();
         obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set IsDistribute=0,distributID=0 where BookSellerChallan=" + Request.QueryString["CHallanNo"] + "");

         obCommonFuction.FillDatasetByProc(" Delete from `dpt_bookselledemandmaster` WHERE `OrderNo`=" + Request.QueryString["CHallanNo"] + "");

         Response.Redirect("BankDarftReport.aspx");
    }
    protected void Button3Save(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("call USP_DPT_bookselledemandStatusUpdateN(" + DropDownList1.SelectedItem.Text + ",'" + Label8.Text + "')");
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        ddlBookSllerName.SelectedIndex = 1;
        DropDownList1.SelectedIndex = 1;
        a.Visible = false;
        a2.Visible = false;
        a1.Visible = false;
        grnMain.DataSource = null;
        grnMain.DataBind();
        Label9.Text = "यह आदेश आर्डर रद्द किया जा चूका है ! ";


    }
    protected void btnSave(object sender, EventArgs e)
    {
        //if (HiddenField2.Value == "")
        //{
        //    CommonFuction obCommonFuction = new CommonFuction();
        //    string ProcString = "call USP_DPT019_DistributeStockSave(0 ,'" + hdnOrderid.Value + "'";
        //    ProcString = ProcString + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'";
        //    ProcString = ProcString + ",'" + txtChalanNo.Text + "'";

        //    ProcString = ProcString + ",'" + Convert.ToDateTime(txtChalanDate.Text, cult).ToString("yyyy-MM-dd") + "'";

        //    ProcString = ProcString + ",'" + 0 + "'";
        //    ProcString = ProcString + ",'" + DropDownList1.SelectedValue + "'";
        //    ProcString = ProcString + "," + "0";
        //    ProcString = ProcString + ",'" + txtReceiverName.Text + "'";
        //    ProcString = ProcString + ",'" + txtGRNO.Text + "'";
        //    ProcString = ProcString + ",'" + Convert.ToDateTime(txtGRNDate.Text, cult).ToString("yyyy-MM-dd") + "'";
        //    ProcString = ProcString + ",'" + txtTrucko.Text + "'";
        //    ProcString = ProcString + ",'" + txtDriverMobileNo.Text + "'";
        //    ProcString = ProcString + ",'" + txtRemark.Text + "'";
        //    ProcString = ProcString + ",'" + Convert.ToString(Session["UserID"]) + "'";
        //    ProcString = ProcString + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'";
        //    ProcString = ProcString + ")";
        //    DataSet ds = obCommonFuction.FillDatasetByProc(ProcString);
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        hdnMasterId1.Value = Convert.ToString(dr[0]);
        //    }
        //}
        //else
        //{
        //    hdnMasterId1.Value = HiddenField2.Value;
        //}
        // Response.Redirect("BookSellerDistribution_old.aspx?ID=" + ddlBookSllerName.SelectedValue + "&ChalanNo=" + DropDownList1.SelectedValue + "&Achall=" + hdnMasterId1.Value + "&Bchall=" + txtChalanNo.Text + "");
        Response.Redirect("BookSellerDistributionaNew.aspx?ID=" + ddlBookSllerName.SelectedValue + "&ChalanNo=" + DropDownList1.SelectedValue + "&Achall=" + hdnMasterId1.Value + "&Bchall=" + txtChalanNo.Text + "");
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
    }
    protected void grnMain_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {



    }
    protected void btnChange(object sender, EventArgs e)
    {
        Div3.Style.Add("display", "block");
        Div4.Style.Add("display", "block");
        Button chkbox = (Button)sender;
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        lblbookName.Text = grd.Cells[1].Text;
        lblNo.Text = grd.Cells[3].Text;
        TextBox1.Text = grd.Cells[3].Text;
        HiddenField3.Value = ((HiddenField)grd.FindControl("BookSelleDemandTrNo_I")).Value;
        //BookSelleDemandTrNo_I
        //CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
    }
    protected void btnClose(object sender, EventArgs e)
    {
        Div3.Style.Add("display", "none");
        Div4.Style.Add("display", "none");
    }
    protected void btnSave1(object sender, EventArgs e)
    {
        CommonFuction obj = new CommonFuction();
        obj.FillDatasetByProc("call DeleteBookSellerDemand(" + HiddenField3.Value + " ," + TextBox1.Text + ")");
        DropDownList1_SelectedIndexChanged(sender, e);
        Div3.Style.Add("display", "none");
        Div4.Style.Add("display", "none");
    }
    //btnChange1
    protected void btnSave2(object sender, EventArgs e)
    {
        CommonFuction obj = new CommonFuction();
        obj.FillDatasetByProc("call USPBookDemandSave(" + HiddenField3.Value + "," + ddlClass.SelectedValue + "," + ddlTitle.SelectedValue + "," + ddlMedium.SelectedValue + " ," + TextBox2.Text + ")");
        //(BookSelleDemandTrNo_Ia int,ClassID_Ia int,TitalID_Ia int,Meidum_ID_Ia int,TotalDemanda int)
        DropDownList1_SelectedIndexChanged(sender, e);
        Div5.Style.Add("display", "none");
        Div6.Style.Add("display", "none");
    }
    protected void btnClose1(object sender, EventArgs e)
    {
        Div5.Style.Add("display", "none");
        Div6.Style.Add("display", "none");
    }
    protected void btnChange1(object sender, EventArgs e)
    {
        Button chkbox = (Button)sender;
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        Div5.Style.Add("display", "block");
        Div6.Style.Add("display", "block");
        HiddenField3.Value = ((HiddenField)grd.FindControl("BookSelleDemandTrNo_I")).Value;
    }
    protected void ddlMediumChange(object sender, EventArgs e)
    {
        CommonFuction obj = new CommonFuction();
        DataSet asdf = obj.FillDatasetByProc("call GetMediumbyTitile(" + ddlMedium.SelectedValue + ",'" + ddlClass.SelectedValue + "')");
        ddlTitle.DataSource = asdf.Tables[0];
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("Select...", "0"));
    }
    protected void btDelete(object sender, EventArgs e)
    {
        CommonFuction obj = new CommonFuction();
        Button chkbox = (Button)sender;
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        HiddenField3.Value = ((HiddenField)grd.FindControl("BookSelleDemandTrNo_I")).Value;
        obj.FillDatasetByProc("call DeleteBookSellerDemand(" + HiddenField3.Value + " ,-1)");
        DropDownList1_SelectedIndexChanged(sender, e);
    }
    // btDelete
    protected void grnMain_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookSellerChallanPrint.aspx?BookSelleLogin=" + ddlBookSllerName.SelectedValue + "&OrderNo=" + DropDownList1.SelectedValue + "&BooksellerName=" + ddlBookSllerName.SelectedItem.Text + "");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Depo_BookSellerDistributionOLd : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BookSellerDemand obBookSellerDemand = null;
    int count12; int count123;
    protected void Page_Load(object sender, EventArgs e)
    {
        //foreach (GridViewRow grdrow in grnMain.Rows)
        //{
        //    Panel pnlData = (Panel)grdrow.FindControl("DivR");
           
            
        //    pnlData.Style.Add("display", "none");
           

        //}
        //pnldiv.Style.Add("display", "none");
        //fadeDiv.Style.Add("display", "none");
        if (!IsPostBack)
        {
            //Random rand = new Random();
            //int randnum = rand.Next(100000, 10000000);
            //txtChalanNo.Text = randnum.ToString();
            //txtChalanNo.Enabled = false;
            
           // WareHouseMaster obWareHouseMaster = new WareHouseMaster();
           // obWareHouseMaster.WareHouseID = 0;
          //  obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
           // DataSet dsWareHouse = obWareHouseMaster.Select();

            obBookSellerDemand = new BookSellerDemand();
            obBookSellerDemand.User_ID_I = Convert.ToInt32(Session["UserID"]);
            obBookSellerDemand.DBookSelleDemandTrNo_I =-3;
            DataSet Demand = obBookSellerDemand.Select();
            ddlBookSllerName.DataSource = Demand;
            ddlBookSllerName.DataValueField = "User_ID_I";
            ddlBookSllerName.DataTextField = "BooksellerOwnerName_V";
            ddlBookSllerName.DataBind();
            ddlBookSllerName.SelectedValue = Request.QueryString["ID"];

            ddlBookSllerName_SelectedIndexChanged(sender, e);
            DropDownList1_SelectedIndexChanged(sender, e);
            txtChalanNo.Text = Request.QueryString["Bchall"];
            hdnMasterId1.Value = Request.QueryString["Achall"];

            fillgrid(); 
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT09_BookSelleDemandformat.aspx");
    }
    //
    protected void lnk_DistrbutBookClick(object sender, EventArgs e)
    {
        LinkButton lnkButton = (LinkButton)sender;
        btnSaveMasterData.CommandArgument = lnkButton.CommandArgument;

        GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
        hdnOrderid.Value = ((HiddenField)(row.FindControl("hdnOrderid"))).Value; 
        pnldiv.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }
    protected void lnk_DistrbutBookClick1(object sender, EventArgs e)
    {
        LinkButton lnkButton = (LinkButton)sender;
       // btnSaveMasterData.CommandArgument = lnkButton.CommandArgument;

        GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
        hdnOrderid.Value = ((HiddenField)(row.FindControl("hdnOrderid"))).Value;
        Panel pnlData = (Panel)row.FindControl("DivR");
       
        ((Label)(row.FindControl("Label9"))).Text = ((HiddenField)(row.FindControl("HdTitleHindi_V"))).Value;
        ((Label)(row.FindControl("Label10"))).Text = ((HiddenField)(row.FindControl("HdTotalDemand"))).Value;
        //Panel fadeDiv = (Panel)row.FindControl("fadeDiv");
        pnlData.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }
   // lnk_DistrbutBookClick2
    
    protected void btnSave(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        string ProcString = "call USP_DPT019_DistributeStockSave(0 ,'" + hdnOrderid.Value + "'";
        ProcString = ProcString + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'";
        ProcString = ProcString + ",'" + txtChalanNo.Text + "'";

        ProcString = ProcString + ",'" + Convert.ToDateTime(txtChalanDate.Text, cult).ToString("yyyy-MM-dd") + "'";

        ProcString = ProcString + ",'" + 0 + "'";
        ProcString = ProcString + ",'" + btnSaveMasterData.CommandArgument + "'";
        ProcString = ProcString + "," + "0";
        ProcString = ProcString + ",'" + txtReceiverName.Text + "'";
        ProcString = ProcString + ",'" + txtGRNO.Text + "'";
        ProcString = ProcString + ",'" + Convert.ToDateTime(txtGRNDate.Text, cult).ToString("yyyy-MM-dd") + "'";
        ProcString = ProcString + ",'" + txtTrucko.Text + "'";
        ProcString = ProcString + ",'" + txtDriverMobileNo.Text + "'";
        ProcString = ProcString + ",'" + txtRemark.Text + "'";
        ProcString = ProcString + ",'" + Convert.ToString(Session["UserID"]) + "'";
        ProcString = ProcString + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'";
        ProcString = ProcString + ")";
        DataSet ds = obCommonFuction.FillDatasetByProc(ProcString);
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            hdnMasterId1.Value = Convert.ToString(dr[0]);
            if ( hdnMasterId1.Value!=""&& Convert.ToInt32(hdnMasterId1.Value) > 0)
            {

                grnMain.Columns[8].Visible = true;
                grnMain.Columns[9].Visible = false;

                

            }
            //Response.Redirect("View_DPT014.aspx?ID=" + btnSaveMasterData.CommandArgument + "&MasterID=" + Convert.ToString(dr[0]));

        }
    
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
       DataSet view=comm.FillDatasetByProc("Call USP_DPT012_BookDemandData_LoadNew("+ddlBookSllerName.SelectedValue+","+DropDownList1.SelectedValue+")");
          grnMain.DataSource = view;
        grnMain.DataBind();
        grnMain.Columns[8].Visible = true;
        grnMain.Columns[9].Visible = false;
    }
    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in grnMain.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");

        }
        fillgrid();


    }

    protected void chkIsLooseChange(object sender, EventArgs e)
    {
        try { 
        CommonFuction obCommonFuction = new CommonFuction();
        HideAllDiv();
        CheckBox chkbox = (CheckBox)sender;
        
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);

        TextBox txtb = (TextBox)grd.FindControl("txtb");
        txtb.Visible = true;
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        //DataSet ds1 = obCommonFuction.FillDatasetByProc(@"select dpt_stockdetailschild_t.* from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where BundleNo_I='" + txtBundle.Text + "'");
        DataSet ds1 = obCommonFuction.FillDatasetByProc("call GetBandalDetailsForBookSeller('" + txtBundle.Text + "',"+Session["UserID"]+")");
            
       if (ds1.Tables[0].Rows.Count>0)
        { 
       // foreach (DataRow dr in ds1.Tables[0].Rows)
       // {
            string[] strRemaingLoose = Convert.ToString(ds1.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');


            foreach (string stritem in strRemaingLoose)
            {
                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
                if (stritem != "")
                {
                    List.Add(obGenarteLoosebundle);
                }

            }
       // }

              obChkLooseBundleList.DataSource = List;
                obChkLooseBundleList.DataTextField = "BookNo";
                obChkLooseBundleList.DataBind();
        }
       
            if (List.Count == 0)
        {
            for (int i = 0; i < Convert.ToInt32(txtPer.Text); i++)
            {
                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                obGenarteLoosebundle.BookNo = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
                List.Add(obGenarteLoosebundle);
                txtTo.Text = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
            }
        
        }
        if (chkbox.Checked)
        {
            obChkLooseBundleList.DataSource = List;
            obChkLooseBundleList.DataTextField = "BookNo";
            obChkLooseBundleList.DataBind();

        }
        else
        {

            obChkLooseBundleList.Items.Clear();
        }

        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");

        }
        catch { }

    }
    protected void gridAttendence_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (DataBinder.Eval(e.Row.DataItem, "Workornot").ToString().ToLower() != "working")
            {
                e.Row.Cells[2].Text = "";
                e.Row.Style.Add("background-color", "#F2F2F2 !important");
            }
        }
    }

    protected void chkUpdateBundle(object sender, EventArgs e)
    {
        HideAllDiv();
        CheckBoxList chkUpdateBundle = (CheckBoxList)sender;
        CommonFuction obCommonFuction = new CommonFuction();
        foreach (ListItem item in chkUpdateBundle.Items)
        {
            if (item.Selected)
            {
                DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT010_StockDetailsCh_Load(" + item.Value + ")");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    GridViewRow grd = (GridViewRow)(chkUpdateBundle.NamingContainer);
                    List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
                    TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
                    txtf.Text = Convert.ToString(dr["FromNo_I"]);
                    TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
                    txtPer.Text = (Convert.ToInt32(dr["ToNo_I"]) - Convert.ToInt32(dr["FromNo_I"])).ToString();
                    TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
                    TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");

                    txtTo.Text = Convert.ToString(dr["ToNo_I"]);

                    TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
                    txtBundle.Text = Convert.ToString(dr["BundleNo_I"]);
                    CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
                    CheckBoxList ChkBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
                    Panel pnlData = (Panel)grd.FindControl("DivR");
                    CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
                    if (Convert.ToString(dr["RemaingLoose_V"]) != "")
                    {
                        string[] strRemaingLoose = Convert.ToString(dr["RemaingLoose_V"]).Split(',');
                        if (txtf.Text != "")
                        {
                            for (int i = 0; i < Convert.ToInt32(txtPer.Text); i++)
                            {
                                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                                obGenarteLoosebundle.BookNo = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
                                List.Add(obGenarteLoosebundle);
                                txtTo.Text = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
                            }
                        }
                        obChkLooseBundleList.DataSource = List;
                        obChkLooseBundleList.DataTextField = "BookNo";
                        obChkLooseBundleList.DataBind();

                        foreach (string stritem in strRemaingLoose)
                        {
                            foreach (ListItem items in obChkLooseBundleList.Items)
                            {
                                if (items.Value == stritem)
                                {
                                    items.Selected = true;
                                }
                                else
                                {
                                    items.Selected = false;
                                }

                            }

                        }
                        chkbox.Checked = true;
                    }

                    Label lblmsg = (Label)grd.FindControl("lblmsg");
                    Panel pnlError = (Panel)grd.FindControl("mainDiv");
                    pnlError.Style.Add("display", "block");
                    lblmsg.Style.Add("display", "block");
                    fadeDiv.Style.Add("display", "block");
                    pnlData.Style.Add("display", "block");

                }

            }

        }


    }
    protected void CheckBunalFromStock(object sender, EventArgs e)
    {
        HideAllDiv();

        TextBox txtbox = (TextBox)sender;
        CommonFuction obCommonFuction = new CommonFuction();
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
        HiddenField hdnDetailsid = (HiddenField)grd.FindControl("hdnDetailsid");
        TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        CheckBoxList ChkBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
        Button btnSaveAll = (Button)grd.FindControl("btnSaveAll");
       
        Label lblmsg = (Label)grd.FindControl("lblmsg");
        Panel pnlError = (Panel)grd.FindControl("mainDiv");
        pnlError.Style.Add("display", "none");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        lblmsg.Text = "";
        //foreach (DataRow dr in ds.Tables[0].Rows)
        //{
        //    txtf.Text = Convert.ToString(dr["FromNo_I"]);
        //    txtTo.Text = Convert.ToString(dr["ToNo_I"]);
        //    txtPer.Text = (Convert.ToInt32(dr["ToNo_I"])+1 - Convert.ToInt32(dr["FromNo_I"])).ToString();
        //    hdnDetailsid.Value = Convert.ToString(dr["StockDetailsChildID_I"]);
        //    string[] strRemaingLoose = Convert.ToString(ds.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');

            
        //        foreach (string stritem in strRemaingLoose)
        //        {
                   
        //            GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
        //            obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
        //            if (stritem != "")
        //            {
        //                List.Add(obGenarteLoosebundle);
        //                obChkLooseBundleList.DataSource = List;
        //                obChkLooseBundleList.DataTextField = "BookNo";
        //                obChkLooseBundleList.DataBind();
        //            }
        //            else
        //            {
        //                obChkLooseBundleList.DataSource = "";
        //                obChkLooseBundleList.DataBind();
        //            }

        //        }




//        DataSet ds = obCommonFuction.FillDatasetByProc(@"select dpt_stockdetailschild_t.* from  dpt_stockdetails_t 
//JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and  IsDistribute=0  and BundleNo_I='" + txtBundle.Text + "' and TitleID_I='" + btnSaveAll.CommandArgument + "' and IsOpenMarket=2");
        DataSet ds = obCommonFuction.FillDatasetByProc(@"call checkBandalDetails (" + Session["UserID"] + ",'" + txtBundle.Text + "','" + btnSaveAll.CommandArgument + "')");
        if (ds.Tables[0].Rows.Count == 0)
        {
             pnlError.Style.Add("display", "block");
            lblmsg.Style.Add("display", "block");
            fadeDiv.Style.Add("display", "block");

            pnlData.Style.Add("display", "block");
            pnlError.Attributes.Add("class", "error");
            lblmsg.Text = "This bundal allready distribute or not available in stock";

        }
        else
        {
            txtf.Text = Convert.ToString(ds.Tables[0].Rows[0]["FromNo_I"]);
               txtTo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ToNo_I"]);
                txtPer.Text = (Convert.ToInt32(ds.Tables[0].Rows[0]["ToNo_I"])+1 - Convert.ToInt32(ds.Tables[0].Rows[0]["FromNo_I"])).ToString();
               hdnDetailsid.Value = Convert.ToString(ds.Tables[0].Rows[0]["StockDetailsChildID_I"]);
             string[] strRemaingLoose = Convert.ToString(ds.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');
            foreach (string stritem in strRemaingLoose)
            {

                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
                if (stritem != "")
                {
                    List.Add(obGenarteLoosebundle);
                    obChkLooseBundleList.DataSource = List;
                    obChkLooseBundleList.DataTextField = "BookNo";
                    obChkLooseBundleList.DataBind();
                }
                else
                {
                    obChkLooseBundleList.DataSource = "";
                    obChkLooseBundleList.DataBind();
                }

              }
        }
         fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        }
       

    


    protected void btnAllSaveClick(object sender, EventArgs e)
    {
    
        HideAllDiv();
        Button bt = (Button)sender;
        // TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(bt.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
        HiddenField hdnHiddenField = (HiddenField)grd.FindControl("hdnHiddenField");
        HiddenField hdnBookSelleDemandTrNo_I = (HiddenField)grd.FindControl("BookSelleDemandTrNo_I");
        

        TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtPerBundleBook = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        CheckBoxList ChkBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
        Label lblmsg = (Label)grd.FindControl("lblmsg");
        Panel pnlError = (Panel)grd.FindControl("mainDiv");
        pnlError.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        Button btnSaveAll = (Button)grd.FindControl("btnSaveAll");
        CommonFuction obCommonFuction = new CommonFuction();
        hd1.Value = "";
        hd2.Value = "";
        string str1 = "'";
        string str2 = "'";
        foreach (ListItem a in obChkLooseBundleList.Items)
        {

            if (a.Selected)
            {
                if (str1 == "")
                {
                    str1 = str1 + a.Text;
                }
                else
                {
                    str1 = str1 + "," + a.Text;
                }
                count123 = count123 + 1;
            }
            else
            {
                if (str2 == "")
                {
                    str2 = str2 + a.Text;
                }
                else
                {
                    str2 = str2 + "," + a.Text;
                }
            }

        }
        str1 = str1 + "'";
        str2 = str2 + "'";
        DataSet ds = obCommonFuction.FillDatasetByProc(@"call USP_DPTBookCountDetaill(1," + Request.QueryString["Achall"] + "," + btnSaveAll.CommandArgument + " )");
        try { 
        hd1.Value = ds.Tables[0].Rows[0]["NOOfBooks"].ToString();
        }
        catch { }
        if (hd1.Value == "")
        {
            if (str1 == "''")
            {
                hd1.Value = txtPerBundleBook.Text;
            }
            else
            {
               hd1.Value = "0";
            }
        }
        else
        {
            if (str1 == "''")
            {
                hd1.Value =Convert.ToString(Convert.ToInt32(hd1.Value)+Convert.ToInt32(txtPerBundleBook.Text));
            }
        }

        DataSet ds2 = obCommonFuction.FillDatasetByProc(@"call USP_DPTBookCountDetaill(2," + DropDownList1.SelectedValue + "," + btnSaveAll.CommandArgument + " )");
        hd2.Value = ds2.Tables[0].Rows[0]["TotalDemand"].ToString();
        hd1.Value =Convert.ToString(count123 + Convert.ToInt32(hd1.Value));
        if (Convert.ToInt32(hd1.Value) > Convert.ToInt32(hd2.Value))
        {
            pnlError.Style.Add("display", "block");
            lblmsg.Style.Add("display", "block");
            fadeDiv.Style.Add("display", "block");

            pnlData.Style.Add("display", "block");
            pnlError.Attributes.Add("class", "error");
            lblmsg.Text = "प्रदाय की जानेवाली संख्या पुस्तक विक्रेता के मांग के बराबर नहीं है ";
            hd1.Value = "";
            hd2.Value = "";
        }
        else
        { 
        HiddenField hdnDetailsid = (HiddenField)grd.FindControl("hdnDetailsid");
        if (str1 == "''")
        {
            obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set BookSellerChallan='" + DropDownList1.SelectedValue + "',IsDistribute =4 ,DistributID =" + Convert.ToString(hdnMasterId1.Value) + " where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");

        }
        else
        {
            if (str2 == "''")
            {
                str2 = ".";
                obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set Issumbited_I=4, RemaingLoose_V=" + str2 + ",RemainingStock=" + str1 + ", BookSellerChallan='" + DropDownList1.SelectedValue + "' ,DistributID =" + Convert.ToString(hdnMasterId1.Value) + " where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");
            }
            else 
            {
                obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set  RemaingLoose_V=" + str2 + ",RemainingStock=" + str1 + ", BookSellerChallan='" + DropDownList1.SelectedValue + "' ,DistributID =" + Convert.ToString(hdnMasterId1.Value) + " where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");
            }
          
            obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('BookSeller'," + ddlBookSllerName.SelectedValue + "," + hdnMasterId1.Value + "," + hdnDetailsid.Value + "," + txtBundle.Text + "," + str1 + "," + DropDownList1.SelectedValue + ")");
        }
        obCommonFuction.FillDatasetByProc(@"update dpt_bookselledemandmaster set Issumbited_I =2  where BookSelleDemandTrNo_I='" + hdnBookSelleDemandTrNo_I.Value + "'");
        ChkBundleList.DataSource = obCommonFuction.FillDatasetByProc(@"select * from dpt_stockdetailschild_t
inner join dpt_stockdetails_t on dpt_stockdetails_t.StockDetailsID_I=dpt_stockdetailschild_t.StockDetailsID_I  where BookSellerChallan='" + DropDownList1.SelectedValue + "' and SubJectID_I=" + btnSaveAll.CommandArgument + "");
  
        ChkBundleList.DataTextField = "BundleNo_I";
        ChkBundleList.DataValueField = "StockDetailsChildID_I";
        ChkBundleList.DataBind();
        pnlError.Attributes.Add("class", "success");
        lblmsg.Text = "Record Save Successfully";
        fillgrid();
       // comm.FillDatasetByProc("Call DPT_Dpt_BooksellerAccountDetailsSave('" +ddlBookSllerName.SelectedValue+ "','" +DropDownList1.SelectedItem.Text + "'," + Label3.Value + "," + hdNetAmount.Value + "," + ((Convert.ToDouble(HidDraftAmount.Value) + Convert.ToDouble(HdCommisionAmount.Value) + Convert.ToDouble(Label2.Text)) - Convert.ToDouble(hdNetAmount.Value)) + "," + Session["UserID"] + "," + HdCommisionAmount.Value + ")");
       // txtNofBooks.Text = "";
        txtTo.Text = "";


        obChkLooseBundleList.DataSource = null;
        obChkLooseBundleList.DataBind();

        Button1.Enabled = true;
        }


    }



    protected void txtFromBookNo_TextChanged(object sender, EventArgs e)
    {
        HideAllDiv();
        TextBox txtbox = (TextBox)sender;



        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        if (txtf.Text != "")
        {
            for (int i = 0; i < Convert.ToInt32(txtPer.Text); i++)
            {
                GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                obGenarteLoosebundle.BookNo = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
                List.Add(obGenarteLoosebundle);
                txtTo.Text = Convert.ToString(Convert.ToInt32(txtf.Text) + i);
            }
        }
        if (chkbox.Checked)
        {
            obChkLooseBundleList.DataSource = List;
            obChkLooseBundleList.DataTextField = "BookNo";
            obChkLooseBundleList.DataBind();
        }
        else
        {
            obChkLooseBundleList.Items.Clear();

        }

        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        //   Messages.Style.Add("display", "block");

    }



    public class GenarteLoosebundle
    {
        public string BookNo { get; set; }

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void fillgrid()
    {
//        foreach (GridViewRow grdrow in grnMain.Rows)
//        {

//            Button btnSaveAll = (Button)grdrow.FindControl("btnSaveAll");
//            Label lblnoofbooks = (Label)grdrow.FindControl("lblnoofbooks");
//            HiddenField hdnOrderNoI = (HiddenField)grdrow.FindControl("hdnOrderNoI");
//               HiddenField hdnUser_ID_I = (HiddenField)grdrow.FindControl("hdnUser_ID_I");
//               Label lblStock = (Label)grdrow.FindControl("lblStock");
//               HiddenField hdnUser_ID_I2 = (HiddenField)grdrow.FindControl("HiddenField1");
//            CommonFuction obCommonFuction = new CommonFuction();
////            DataSet ds = obCommonFuction.FillDatasetByProc(@"select TitleHindi_V as Title, sum(case RemaingLoose_V when '' then ifnull(ToNo_I  ,0)-ifnull(FromNo_I ,0)+1 else (length(RemainingStock) - length(Replace (RemainingStock,',',''))) end) as  'NO Of Books' from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I
////              inner join dpt_stockdistributionschemeentry_m on dpt_stockdetailschild_t.DistributID =dpt_stockdistributionschemeentry_m.StockDistributionSEntryID_I
////              where  DistributID=" +Request.QueryString["Achall"]+"  and TitleID_I=" + btnSaveAll.CommandArgument + "  group by TitleHindi_V ;");
//            DataSet ds = obCommonFuction.FillDatasetByProc(@"call USP_DPTBookCountDetaill(1," + Request.QueryString["Achall"] + "," + btnSaveAll.CommandArgument + " )");
//            if (ds.Tables[0].Rows.Count > 0)
//            {
//                lblnoofbooks.Text = Convert.ToString(ds.Tables[0].Rows[0]["NO Of Books"]);
//            }

//            //DataSet ds1 = obCommonFuction.FillDatasetByProc(@"call USP_dptGetStock(" + Session["UserID"] + "," + hdnUser_ID_I2.Value + " )");
//            //if (ds1.Tables[0].Rows.Count > 0)
//            //{
//            //    lblStock.Text = Convert.ToString(ds1.Tables[0].Rows[0]["NoOfBookSamanya"]);
//            //}

//        }




    }

    protected void ddlBookSllerName_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet ds = comm.FillDatasetByProc("select distinct OrderNo from dpt_bookselledemandmaster where Issumbited_I=1 and User_ID_I=" + ddlBookSllerName.SelectedValue + "");
        DropDownList1.DataTextField = "OrderNo";
        DropDownList1.DataValueField = "OrderNo";
        DropDownList1.DataSource = ds.Tables[0];
        DropDownList1.DataBind();
        DropDownList1.SelectedValue = Request.QueryString["ChalanNo"];
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrd();
        //a.Style.Add ("display","block");
        //a2.Style.Add("display", "block");
        a.Visible = true;
        a2.Visible = true;
        a1.Visible = true;
        a11.Visible = true;
        CommonFuction comm = new CommonFuction();
        DataSet book = comm.FillDatasetByProc("call USP_DptBookSellerDemand('" + ddlBookSllerName.SelectedValue + "',15,'" + DropDownList1.SelectedValue + "')");
        Label1.Text = book.Tables[0].Rows[0]["DDNouber"].ToString ();
        Label2.Text = book.Tables[0].Rows[0]["BankName"].ToString();
        Label3.Text =Convert.ToString( Math.Round(Convert.ToDouble( book.Tables[0].Rows[0]["TotalRate"]),2));
        Label4.Text = Convert.ToString(Math.Round(Convert.ToDouble(book.Tables[0].Rows[0]["Discount"]), 2));//Convert.ToString( Math.Round( book.Tables[0].Rows[0]["Discount"]),2)));
        Label5.Text = book.Tables[0].Rows[0]["DDDate"].ToString();
        Label6.Text = book.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
        Label8.Text = book.Tables[0].Rows[0]["Categorya"].ToString();
        Label7.Text = book.Tables[0].Rows[0]["TotalAmount"].ToString();
    }


    protected void txtonChange(object sender, EventArgs e)
    {
        HideAllDiv();
        TextBox TextBox = (TextBox)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        //for (int i = 0; i < Convert.ToInt32(TextBox.Text); i++)
        //{
        int id = Convert.ToInt32(TextBox.Text);

        foreach (ListItem items in obChkLooseBundleList.Items)
        {
            count12 = count12 + 1;
            if (id >= count12)
            {
                items.Selected = true;
            }
            else
            {
                items.Selected = false;
            }

        }
        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        //}

    }
    ////
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "")
        {
        }
        else
        {

            CommonFuction obCommonFuction = new CommonFuction();
          obCommonFuction.FillDatasetByProc("update dpt_bookselledemandmaster set Issumbited_I=2 where OrderNo= '" + DropDownList1.SelectedItem.Text + "' "); 
            Response.Redirect("BookSellerChallanDetails.aspx?ChallanID="+DropDownList1.SelectedValue+"&BookSellerID="+ddlBookSllerName.SelectedValue+"");
         

        }
    }
    protected void btnButton2Click(object sender, EventArgs e)
    {
        HideAllDiv();
        CommonFuction comm = new CommonFuction();
        Button lnkButton = (Button)sender;
        // btnSaveMasterData.CommandArgument = lnkButton.CommandArgument;

        GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
        Panel pnlData = (Panel)row.FindControl("DivR");
       
        pnlData.Style.Add("display", "Block");
        fadeDiv.Style.Add("display", "Block");
        hdnOrderid.Value = ((HiddenField)(row.FindControl("HiddenField1"))).Value;
        GridView gvR = (GridView)row.FindControl("grd15");
        DataSet dt = comm.FillDatasetByProc(@"call dptStockDetailsReport(" + Session["USerID"] + "," + hdnOrderid.Value + ",0,0)");
        gvR.DataSource = dt.Tables[0];
        gvR.DataBind();
    }
    protected void lnk_DistrbutBookClick2(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        LinkButton lnkButton = (LinkButton)sender;
        // btnSaveMasterData.CommandArgument = lnkButton.CommandArgument;

        GridViewRow row = (GridViewRow)lnkButton.NamingContainer;
        Panel pnlData = (Panel)row.FindControl("DivR");
        Button btnSaveAll = (Button)row.FindControl("btnSaveAll");
        Label lblnoofbooks = (Label)row.FindControl("lblnoofbooks");
        pnlData.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        DataSet ds = obCommonFuction.FillDatasetByProc(@"call USP_DPTBookCountDetaill(1," + Request.QueryString["Achall"] + "," + btnSaveAll.CommandArgument + " )");
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblnoofbooks.Text = Convert.ToString(ds.Tables[0].Rows[0]["NO Of Books"]);
        }
    }
}
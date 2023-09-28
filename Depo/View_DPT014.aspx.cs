using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Depo_View_DPT014 : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DPT_DepotMaster obDPT_DepotMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();
            grBook.Visible = false;
            Panel1.Visible = true;
            GridView2.Visible = false;
            Panel2.Visible = false;

            


            DataSet dd1 = comm.FillDatasetByProc("call USP_DPTChallanDetails(" + Request.QueryString["ChallanNo"] + ",0)");
            if (dd1.Tables[0].Rows.Count > 0)
            {

                Label1.Text = Convert.ToString(dd1.Tables[0].Rows[0]["District_Name_Hindi_V"]);
                Label2.Text = Convert.ToString(dd1.Tables[0].Rows[0]["BlockNameHindi_V"]);
                Label3.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanNo_V"]);
                Label4.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanDate_D"]);
                Label5.Text = Convert.ToString(dd1.Tables[0].Rows[0]["DriverMobileNo_V"]);
                Label6.Text = Convert.ToString(dd1.Tables[0].Rows[0]["TruckNo_V"]);
                Label7.Text = Convert.ToString(dd1.Tables[0].Rows[0]["GRNO_V"]);
                Label8.Text = Convert.ToString(dd1.Tables[0].Rows[0]["GRNODate_D"]);
                Label9.Text = Convert.ToString(dd1.Tables[0].Rows[0]["BlockNameHindi_V"]);

            }
            else
            {
                a.Style.Add("Display", "none");
            }
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(dd1.Tables[0].Rows[0]["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();
            // db.execute(@"select * from dpt_distributchallanreceipt inner join acd_titledetail on acd_titledetail.TitleID_I=dpt_distributchallanreceipt.TitalID where ChallanID=" + Request.QueryString["ChallanNo"] + "", DBAccess.SQLType.IS_QUERY);
        
            DataSet dd = comm.FillDatasetByProc("call USP_DPTChallanDetails(" + Request.QueryString["ChallanNo"] + ",12)");
            GridView1.DataSource = dd.Tables[0];
            GridView1.DataBind();
            BtnPrint.Visible = true;
            BtnSave.Visible = false;

        }
            
        //    fillgrid();

    }

    protected void calculate(object sender, EventArgs e)
    {
        try
        {
            
            TextBox txtPerbundlebook = (TextBox)sender;
            //txtPerbundlebook
            GridViewRow grdrow = (GridViewRow)txtPerbundlebook.NamingContainer;
            TextBox lblnoofbooks = (TextBox)grdrow.FindControl("lblnoofbooks");
            TextBox txtPackbundle = (TextBox)grdrow.FindControl("txtPackbundle");
            TextBox txtloose = (TextBox)grdrow.FindControl("txtloose");
            TextBox txtPerbundlebook1 = (TextBox)grdrow.FindControl("txtPerbundlebook");
            var pack = Convert.ToInt32(lblnoofbooks.Text) / Convert.ToInt32(txtPerbundlebook1.Text);
            var loose = Convert.ToInt32(lblnoofbooks.Text) % Convert.ToInt32(txtPerbundlebook1.Text);
            txtPackbundle.Text = pack.ToString();
            txtloose.Text = loose.ToString();
        }catch{}

        
        
    }
    
    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in grBook.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");

        }
        fillgrid();


    }

    protected void chkIsLooseChange(object sender, EventArgs e)
    {
        HideAllDiv();
        CheckBox chkbox = (CheckBox)sender;

        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
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
        DataSet ds = obCommonFuction.FillDatasetByProc(@"select dpt_stockdetailschild_t.* from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and  IsDistribute=0  and BundleNo_I='" + txtBundle.Text + "' and TitleID_I='" + btnSaveAll .CommandArgument+ "'");
        Label lblmsg = (Label)grd.FindControl("lblmsg");
        Panel pnlError = (Panel)grd.FindControl("mainDiv");
        pnlError.Style.Add("display", "none");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        lblmsg.Text = "";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            txtf.Text = Convert.ToString(dr["FromNo_I"]);
            txtTo.Text = Convert.ToString(dr["ToNo_I"]);
            txtPer.Text = (Convert.ToInt32(dr["ToNo_I"]) - Convert.ToInt32(dr["FromNo_I"])).ToString();
            hdnDetailsid.Value = Convert.ToString(dr["StockDetailsChildID_I"]); 
        }
        if (ds.Tables[0].Rows.Count == 0)
        {
           
           
            pnlError.Style.Add("display", "block");
            lblmsg.Style.Add("display", "block");
            fadeDiv.Style.Add("display", "block");
            
            pnlData.Style.Add("display", "block");
            pnlError.Attributes.Add("class", "error");
            lblmsg.Text = "This bundal allready distribute or not available in stock";
            
        }
        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");

    }


    protected void btnAllSaveClick(object sender, EventArgs e)
    {
        try {
        HideAllDiv();
        Button bt = (Button)sender;
        // TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(bt.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
        HiddenField hdnHiddenField = (HiddenField)grd.FindControl("hdnHiddenField");

        
        TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
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

        string str1 = "'";

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

            }

        }
        str1 = str1 + "'";
        CommonFuction obCommonFuction = new CommonFuction();
        HiddenField hdnDetailsid = (HiddenField)grd.FindControl("hdnDetailsid");
        obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute =3 ,DistributID =" + Convert.ToString(Request.QueryString["MasterID"]) + " where StockDetailsChildID_I='" + hdnDetailsid .Value+ "'");
        ChkBundleList.DataSource = obCommonFuction.FillDatasetByProc(@"select * from dpt_stockdetailschild_t  where StockDetailsChildID_I='" + hdnDetailsid.Value + "'");
        ChkBundleList.DataTextField = "BundleNo_I";
        ChkBundleList.DataValueField = "StockDetailsChildID_I";
        ChkBundleList.DataBind();
        pnlError.Attributes.Add("class", "success");
        lblmsg.Text = "Record Save Successfully";
        fillgrid();
        }
        catch { }
        //USP_DPT030DemadDistributeSave`(mBundalNo int,mIsLooseBundle int,mBooksInLooseBundal varchar(900),mStockDetailsID int)


      
       


        //CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");




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
        foreach (GridViewRow grdrow in grBook.Rows)
        {
            try {

              Button btnSaveAll = (Button)grdrow.FindControl("btnSaveAll");
              Label lblnoofbooks = (Label)grdrow.FindControl("lblnoofbooks");
              HiddenField hdnOrderNoI = (HiddenField)grdrow.FindControl("hdnOrderNoI");

            
              CommonFuction obCommonFuction = new CommonFuction();
              DataSet ds= obCommonFuction.FillDatasetByProc(@"select TitleHindi_V as Title, sum(case RemaingLoose_V when '' then ifnull(ToNo_I  ,0)-ifnull(FromNo_I ,0)+1 else (length(RemaingLoose_V) - length(Replace (RemaingLoose_V,',','')))+1 end) as  'NO Of Books' from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I
              inner join dpt_stockdistributionschemeentry_m on dpt_stockdetailschild_t.DistributID =dpt_stockdistributionschemeentry_m.StockDistributionSEntryID_I
              where  IsDistribute=3  and BlockID_I=" + Request.QueryString["ID"].ToString() + " and TitleID_I=" + btnSaveAll.CommandArgument + " and OrderNo_I ='" + hdnOrderNoI .Value+ "' group by TitleHindi_V ;");
              if(ds.Tables[0].Rows.Count>0)
              {
                lblnoofbooks.Text = Convert.ToString(ds.Tables[0].Rows[0]["NO Of Books"]);
              }

            }
            catch { }

        }




    }
    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        try { 
       
        CommonFuction comm = new CommonFuction();
        DBAccess db = new DBAccess();
        for (int i = 0; i < grBook.Rows.Count; i++)
        {
            if (((CheckBox)grBook.Rows[i].FindControl("CheckBox1")).Checked== true)
            {
                if (((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text == grBook.Rows[i].Cells[5].Text || Convert.ToInt32( ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text) <Convert.ToInt32( ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text))
                {
                
                }
                else { 
                comm.FillDatasetByProc("call USP_DptBlockChallanSave(" + Request.QueryString["MasterID"] + "," + Request.QueryString["ChallanNo"] + "," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + "," + Request.QueryString["schemeid"] + ")");
                }
                //    db.execute("insert into dpt_distributchallanreceipt(MasterID, ChallanID, TitalID, PerBandlbook, ReceivedBook, DestributeBook, PaikBandal, LoojBandal)values (" + Request.QueryString["MasterID"] + "," + Request.QueryString["ChallanNo"] + "," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ")", DBAccess.SQLType.IS_QUERY);
            //db.executeMyQuery();
            }
        }

        grBook.Visible = false;
        Panel1.Visible = true;
        GridView2.Visible = false;
        Panel2.Visible = false;
        DataSet dd1 = comm.FillDatasetByProc("call USP_DPTChallanDetails(" + Request.QueryString["ChallanNo"] + ",0)");
        if (dd1.Tables[0].Rows.Count > 0)
        {

            Label1.Text = Convert.ToString(dd1.Tables[0].Rows[0]["District_Name_Hindi_V"]);
            Label2.Text = Convert.ToString(dd1.Tables[0].Rows[0]["BlockNameHindi_V"]);
            Label3.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanNo_V"]);
            Label4.Text = Convert.ToString(dd1.Tables[0].Rows[0]["ChallanDate_D"]);
            Label5.Text = Convert.ToString(dd1.Tables[0].Rows[0]["DriverMobileNo_V"]);
            Label6.Text = Convert.ToString(dd1.Tables[0].Rows[0]["TruckNo_V"]);

        }
        else
        {
            a.Style.Add("Display","none");
        }
       // db.execute(@"select * from dpt_distributchallanreceipt inner join acd_titledetail on acd_titledetail.TitleID_I=dpt_distributchallanreceipt.TitalID where ChallanID=" + Request.QueryString["ChallanNo"] + "", DBAccess.SQLType.IS_QUERY);
        DataSet dd = comm.FillDatasetByProc("call USP_DPTChallanDetails(" + Request.QueryString["ChallanNo"] + ",12)");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
        BtnPrint.Visible = true;
        BtnSave.Visible = false;
        }
        catch { }
    }





    protected void lblnoofbooks_TextChanged(object sender, EventArgs e)
    {

    }

    decimal tOtalbandal = 0;
    decimal TotalAllotment = 0;
    decimal TotatDistribution = 0;
    decimal LoseBandal = 0;
    decimal Paikbandal = 0;
    decimal loojBan = 0;
    decimal paik = 0;
 
    protected void grdPrinterBundleDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                decimal TotalAllotmenta = Convert.ToDecimal(e.Row.Cells[3].Text);
                TotalAllotment += TotalAllotmenta;
            }
            catch { }
            try
            {
                decimal TotalAllotmenta1 = Convert.ToDecimal(e.Row.Cells[4].Text);
                TotatDistribution += TotalAllotmenta1;
            }
            catch { }
            try
            {
                Label lblTotalBookpaik = (Label)e.Row.Cells[5].FindControl("lblTotal");
              //  decimal TotalAllotmenta112222 = Convert.ToDecimal(e.Row.Cells[5].Text);
                tOtalbandal +=Convert.ToDecimal(lblTotalBookpaik.Text);
            }
            catch { }
            try
            {
                decimal TotalAllotmenta112 = Convert.ToDecimal(e.Row.Cells[6].Text);
                LoseBandal += TotalAllotmenta112;
            }
            catch { }
            try
            {
                decimal TotalAllotmenta1122 = Convert.ToDecimal(e.Row.Cells[9].Text);
                Paikbandal += TotalAllotmenta1122;
            }
            catch { }
            try
            {
                Label test = ((Label)e.Row.FindControl("lblTotalaa"));
                loojBan +=Convert.ToDecimal(test.Text);
            }
            catch { }
            try
            {
                Label test1 = (Label)e.Row.FindControl("lblTotalss");
                paik  +=Convert.ToDecimal( test1.Text);
            }
            catch { }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "कुल योग : ";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[3].Text = TotalAllotment.ToString();
            e.Row.Cells[4].Text = TotatDistribution.ToString();
            e.Row.Cells[5].Text = tOtalbandal.ToString();
            e.Row.Cells[6].Text = LoseBandal.ToString();
            e.Row.Cells[9].Text = Paikbandal.ToString();

            e.Row.Cells[7].Text = loojBan.ToString();
            e.Row.Cells[8].Text = paik.ToString();

            //e.Row.Cells[6].Text = total_TotalBookpaik.ToString();
            ////e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            ////e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            ////e.Row.Cells[9].Text = total_FromNo_I.ToString();
            ////e.Row.Cells[10].Text = total_ToNo_I.ToString();
            //e.Row.Cells[11].Text = total_LoojBook.ToString();
            //e.Row.Cells[12].Text = total_LoojBook.ToString();
        }
    }
   
    protected void BtnSave0_Click(object sender, EventArgs e)
    {
        Response.Redirect("BlockChalanReport.aspx?challanID=" + Request.QueryString["ChallanNo"] + "");
    }
    protected void BtnSave1_Click(object sender, EventArgs e)
    {
        Response.Redirect("DISTRIBUTEYOJNABOOKWITHBARCODE.ASPX?ID=" + Request.QueryString["ChallanNo"] + "");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Depo_DPT017_StockParivartan : System.Web.UI.Page
{//ChkBundleList
    MediumMaster obMediumMaster = null;
    ClassMaster obClass = null; int TotalBandal, count1; int total = 0, total112, count12;
    int grdCount1, grdCount2;
    WareHouseMaster obWareHouseMaster = null;
    StockMaster obStockMaster = new StockMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int id = 0;
      DBAccess db = new DBAccess();
             CommonFuction obCommonFuctionForUpdate = new CommonFuction();        
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "सलेक्ट करे ..");
            //----------------Class Bind

            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            obClass.ClassTrno_I = 0;
            ddlCls.DataTextField = "Classdet_V";
            ddlCls.DataValueField = "ClassTrno_I";
            ddlCls.DataSource = dtclass.Tables[0];
            ddlCls.DataBind();
            ddlCls.Items.Insert(0, "सलेक्ट करे ..");
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //---------------------Warehouse Name
            //obWareHouseMaster = new WareHouseMaster();
            //obWareHouseMaster.WareHouseID = 0;
            //obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserId"]);
           // CommonFuction comm = new CommonFuction();
           //

            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserId"]);
            DataSet ds12 = obWareHouseMaster.Select();
            ddlNewWarehous.DataTextField = "WareHouseName_V";
            ddlNewWarehous.DataValueField = "WareHouseID_I";
            ddlNewWarehous.DataSource = ds12.Tables[0];
            ddlNewWarehous.DataBind();

            ddlNewWarehous.Items.Insert(0, "सलेक्ट करे ..");
            ddlWarehouse.DataTextField = "WareHouseName_V";
            ddlWarehouse.DataValueField = "WareHouseID_I";
            ddlWarehouse.DataSource = ds12.Tables[0];
            ddlWarehouse.DataBind();
            ddlWarehouse.Items.Insert(0, "सलेक्ट करे ..");

        }


    }
    protected void ddlClsChange(object sender, EventArgs e)
    {
        //try { 
        //CommonFuction comm = new CommonFuction();
        //DataSet ds = comm.FillDatasetByProc(" call USP_DPT_WareHouseNameBookby(" + Session["UserId"] + "," + ddlMedium.SelectedValue + "," + ddlCls.SelectedValue + ")");
        //// //= obWareHouseMaster.Select();
        //ddlWarehouse.DataTextField = "WareHouseName_V";
        //ddlWarehouse.DataValueField = "WareHouseID_I";
        //ddlWarehouse.DataSource = ds.Tables[0];
        //ddlWarehouse.DataBind();
        //ddlWarehouse.Items.Insert(0, "सलेक्ट करे ..");
        //}
        //catch { }
    }
    
    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in grBook.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");

        }
    

    }
  //  
    protected void chkCheck(object sender, EventArgs e)
    {
        HideAllDiv();
          CheckBox chkbox = (CheckBox)sender;
          GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
          CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
          Panel pnlData = (Panel)grd.FindControl("DivR");
          foreach (ListItem items in obChkLooseBundleList.Items)
          {
             
                  items.Selected = true;
             

          }
          fadeDiv.Style.Add("display", "block");
          pnlData.Style.Add("display", "block");
    }
    protected void chkIsLooseChange1(object sender, EventArgs e)
    {
        try
        {
            CheckBox chkbox = (CheckBox)sender;

            GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);


            List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
            TextBox txtb = (TextBox)grd.FindControl("txtb");
            txtb.Visible = true;
            Label BandalNo = (Label)grd.FindControl("BundleNo_I");
            Label txtf = (Label)grd.FindControl("FromNo_I");
            Label txtPer = (Label)grd.FindControl("lblPer");
            Label txtTo = (Label)grd.FindControl("ToNo_I");
            CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
            CommonFuction comm = new CommonFuction();
            DataSet ds = comm.FillDatasetByProc("call DPT_BlockwiseBandCheck(" + BandalNo.Text + ",0)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string[] strRemaingLoose = Convert.ToString(ds.Tables[0].Rows[0]["RemaingLoose_V"]).Split(',');


                foreach (string stritem in strRemaingLoose)
                {
                    if (stritem.ToString() != "")
                    {
                        GenarteLoosebundle obGenarteLoosebundle = new GenarteLoosebundle();
                        obGenarteLoosebundle.BookNo = Convert.ToString(stritem);
                        List.Add(obGenarteLoosebundle);
                    }
                }


            }
            else
            {

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

            }
            if (chkbox.Checked)
            {
                obChkLooseBundleList.DataSource = List;
                obChkLooseBundleList.DataTextField = "BookNo";
                obChkLooseBundleList.DataBind();


            }
            else
            {
                txtb.Visible = false;

                obChkLooseBundleList.Items.Clear();
            }
        }
        catch { }
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
                  //  pnlError.Style.Add("display", "block");
                   // lblmsg.Style.Add("display", "block");
                   fadeDiv.Style.Add("display", "block");
                   pnlData.Style.Add("display", "block");

                }

            }

        }


    }

    protected void btnAllSaveClick(object sender, EventArgs e)
    {
        HideAllDiv();
        Button bt = (Button)sender;
        // TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(bt.NamingContainer);
        Panel pnlData = (Panel)grd.FindControl("DivR");
        CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        Label lblmsg = (Label)grd.FindControl("lblmsg");
        Panel pnlError = (Panel)grd.FindControl("mainDiv");
        pnlError.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        

       
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");

        TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
       
        TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        CheckBoxList ChkBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
       
      
        

        StockDetailsChild obStockDetailsChild = new StockDetailsChild();
        bool checkforUpdate = true;
        foreach (ListItem item in ChkBundleList.Items)
        {
            if (item.Selected)
            {
                CommonFuction obCommonFuctionForUpdate = new CommonFuction();
                DataSet ds = obCommonFuctionForUpdate.FillDatasetByProc("Call USP_DPT010_StockDetailsCh_Load(" + item.Value + ")");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HdnTrasactionID.Value = dr["StockDetailsID_I"].ToString ();

                    obStockDetailsChild.BundleNo_I = Convert.ToInt32(dr["BundleNo_I"].ToString());
                    obStockDetailsChild.FromNo_I = Convert.ToInt32(dr["FromNo_I"].ToString());
                    obStockDetailsChild.ToNo_I = Convert.ToInt32(dr["ToNo_I"].ToString());
                    obStockDetailsChild.Trans_I = Convert.ToInt32(item.Value);
                    string str1 = "";
                    obStockDetailsChild.RemaingLoose_V = str1;
                    obStockDetailsChild.StockDetailsChildID_I = Convert.ToInt32(item.Value); ;
                    obStockDetailsChild.StockDetailsID_I = Convert.ToInt32(HdnTrasactionID.Value);
                    obStockDetailsChild.BundleType_I = 1;
                    //obStockDetailsChild.InsertUpdate();
                   
                    //db.execute("insert into Dpt_StockParivartan(StockdetailsID_ID,BundleNo_I,FromNo_I,ToNo_I,RemaingLoose,DateS,MediumID,ClassID,WareHOuseID,NewWarehouseID,RefLeeter,TitalID,DepotID)values()", DBAccess.SQLType.IS_QUERY);
                    //db.executeMyQuery();
                    obCommonFuctionForUpdate.FillDatasetByProc(@"UPDATE  dpt_stockdetailschild_t SET IsOpenMarket=1,BundleType_I=1 WHERE  StockDetailsChildID_I=" + Convert.ToInt32(item.Value) + "");
                    try {
                    obCommonFuctionForUpdate.FillDatasetByProc("call USP_DPT_StockParivartan1(" + HdnTrasactionID.Value + ",'" + Convert.ToInt32(dr["BundleNo_I"].ToString()) + "','" + dr["FromNo_I"].ToString() + "','" + dr["ToNo_I"].ToString() + "','" + str1 + "','" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlMedium.SelectedValue + "," + ddlCls.SelectedValue + "," + ddlWarehouse.SelectedValue + "," + ddlNewWarehous.SelectedValue + ",'" + txtRefrenceNo.Text + "'," + hd.Value + "," + Session["UserID"] + ")");
                    }
                    catch { } txtf.Text = "";
                    txtPer.Text = "";
                    //txtNofBooks.Text = "";
                    txtBundle.Text = "";
                    txtTo.Text = "";
                    
                   
                 //   return;

                }
            }
           
           
                 
        }

        CommonFuction obCommonFuction = new CommonFuction();

   // comment by ajay Nigam 31-05-2016?-//

        //string ProcValue = "";
        //ProcValue = ProcValue + "Call GetBundledataByWareHouseWithDate(" + Convert.ToInt32(bt.CssClass);
        //ProcValue = ProcValue + "," + ddlWarehouse.SelectedValue;
        //ProcValue = ProcValue + "," + 2;
        //ProcValue = ProcValue + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'";
        //ProcValue = ProcValue + ")";
        //obCommonFuction.FillDatasetByProc(ProcValue);
        //// call GetBundledataByWareHouseWithDate(1,2,1,'2015-02-25')
        //ChkBundleList.DataSource = obCommonFuction.FillDatasetByProc(ProcValue);
        //ChkBundleList.DataValueField = "StockDetailsChildID_I";
        //ChkBundleList.DataTextField = "BundleNo_I";
        //ChkBundleList.RepeatColumns = 10;
        //ChkBundleList.DataBind();

        //--
        DataSet dddd = obCommonFuction.FillDatasetByProc("call USP_DPTGetStockParivartan(" + Convert.ToInt32(bt.CssClass) + "," + Session["UserID"] + ",100)");
        obChkLooseBundleList.DataSource = dddd.Tables[0];
        obChkLooseBundleList.DataValueField = "StockDetailsChildID_I";
        obChkLooseBundleList.DataTextField = "BundleNo_I";
        obChkLooseBundleList.RepeatColumns = 10;
        obChkLooseBundleList.DataBind();
        //--
        txtf.Text = "";
        txtPer.Text = "";
        //txtNofBooks.Text = "";
        txtBundle.Text = "";
        txtTo.Text = "";
        obChkLooseBundleList.Items.Clear();

        chkbox.Checked = false;
        pnlError.Attributes.Add("class", "success");
        lblmsg.Text = "Record Save Successfully";


    }
   // btn_Click
    //protected void btn_Click(object sender, EventArgs e)
    //{
    //    Button btn = (Button)sender;
    //    GridViewRow grd = (GridViewRow)(btn.NamingContainer);
    //    HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
    //    TextBox txtbox1 = (TextBox)grd.FindControl("txtNofBooks");
    //    Label lblperbundle = (Label)grd.FindControl("lblPerBundal");
    //    Label lblPaikBulde = (Label)grd.FindControl("lblPaikBulde");
    //    Label lbllooj = (Label)grd.FindControl("lbllooj");

    //    lblPaikBulde.Text = Convert.ToString(Convert.ToInt16(txtbox1.Text) / Convert.ToInt16(lblperbundle.Text));
    //    lbllooj.Text = Convert.ToString(Convert.ToInt16(txtbox1.Text) % Convert.ToInt16(lblperbundle.Text));
    //    CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
    //    // TextBox txtbox = (TextBox)e.Row.FindControl("txtNofBooks");
    //    DataSet dddd = obCommonFuctionForUpdate.FillDatasetByProc("call USP_DPTGetStockParivartan(" + Convert.ToInt32(hd.Value) + "," + Session["UserID"] + "," + (Convert.ToInt32(lblPaikBulde.Text) ) + ")");
    //    obChkLooseBundleList.DataSource = dddd.Tables[0];
    //    obChkLooseBundleList.DataValueField = "StockDetailsChildID_I";
    //    obChkLooseBundleList.DataTextField = "BundleNo_I";
    //    obChkLooseBundleList.RepeatColumns = 10;
    //    obChkLooseBundleList.DataBind();
    //}

   
    protected void txtonChange_TextChanged(object sender, EventArgs e)
    {

        TextBox TextBox = (TextBox)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        //List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        Label txtf = (Label)grd.FindControl("FromNo_I");
        Label txtPer = (Label)grd.FindControl("lblPer");
        Label txtTo = (Label)grd.FindControl("ToNo_I");
        // CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");

        int id = Convert.ToInt32(TextBox.Text);
        TotalBandal = TotalBandal + id;
        foreach (ListItem items in obChkLooseBundleList.Items)
        {
            count12 = count12 + 1;
            if (id >= count12)
            {
                items.Selected = true;
            }
            else
            { items.Selected = false; }

        }

    }
    protected void txtNofBooks_TextChanged(object sender, EventArgs e)
    {
        HideAllDiv();
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
        TextBox txtbox1 = (TextBox)grd.FindControl("txtNofBooks");
        Label lblperbundle = (Label)grd.FindControl("lblPerBundal");
        Label lblPaikBulde = (Label)grd.FindControl("lblPaikBulde");
        Label lbllooj = (Label)grd.FindControl("lbllooj");
        
        lblPaikBulde.Text =Convert.ToString( Convert.ToInt16(txtbox1.Text) / Convert.ToInt16(lblperbundle.Text));
        lbllooj.Text = Convert.ToString(Convert.ToInt16(txtbox1.Text) % Convert.ToInt16(lblperbundle.Text));

        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
       // TextBox txtbox = (TextBox)e.Row.FindControl("txtNofBooks");
        DataSet dddd = obCommonFuctionForUpdate.FillDatasetByProc("call USP_DPTGetStockParivartan(" + Convert.ToInt32(hd.Value) + "," + Session["UserID"] + "," + (Convert.ToInt32(lblPaikBulde.Text)) + ")");
        obChkLooseBundleList.DataSource = dddd.Tables[0];
        obChkLooseBundleList.DataValueField = "StockDetailsChildID_I";
        obChkLooseBundleList.DataTextField = "BundleNo_I";
        obChkLooseBundleList.RepeatColumns = 10;
        obChkLooseBundleList.DataBind();
        //  lblPaikBulde
       // lblPerBundal


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
    
    protected void Button1_Click(object sender, EventArgs e)
    {

        //Session["OfficeTrNo"] = 1;
        //obStockMaster = new StockMaster();
        //obStockMaster.Date_D = Convert.ToDateTime(txtDate.Text, cult);
        //obStockMaster.WareHouseID_I = Convert.ToInt32(ddlWarehouse.SelectedValue);
        //obStockMaster.MediamID_I = Convert.ToInt32(ddlMedium.SelectedValue);
        //obStockMaster.BookType_I = Convert.ToInt32(RadioButtonList1.SelectedValue);
        //obStockMaster.ClassID_I = Convert.ToInt32(ddlCls.SelectedValue);
        //obStockMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
        //obStockMaster.TypeDetails = Convert.ToInt32(ddlBookType.SelectedValue);
        //obStockMaster.Trans_I = 0;
        //obStockMaster.DepoID_I = Convert.ToInt32(Session["UserID"]);
        //obStockMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
        //id = obStockMaster.InsertUpdate();

        //if (id != 0)
        //{
        //    HdnMasterHdnId.Value = id.ToString();
        //obDBAccess.execute("USP_DPT011FatchBookData", DBAccess.SQLType.IS_PROC);
        //obDBAccess.addParam("mClassID", mClassID);
        //obDBAccess.addParam("mMediumID", mMediumID);
        //obDBAccess.addParam("BookTypoe", BookTypoe);
        //obDBAccess.addParam("BookDetail", BookDetail);
        //obDBAccess.addParam("MwarehouseID", MwarehouseID);
        //obDBAccess.addParam("mUser_I", mUser_I);
        //obDBAccess.addParam("mStock_ID_I", Stock_ID_I);

        //obDBAccess.addParam("mDate_V", Date_V);
          GID.Visible = true;
            a.Visible = false;
            string Classes = "";
            if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
            else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
           // DataSet ds12 = obStockMaster.Select1(Convert.ToInt32(ddlCls.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue),Convert.ToInt32(0),Convert.ToInt32(2), Convert.ToInt32(ddlWarehouse.SelectedValue), Convert.ToInt32(ddlWarehouse.SelectedValue), Convert.ToDateTime(txtDate.Text, cult), 0);
            CommonFuction obcomm = new CommonFuction();
            DataSet ds12 = obcomm.FillDatasetByProc("call USP_DPT011FatchBookData('" + Classes + "','" +Convert.ToInt32(ddlMedium.SelectedValue)+"','" +Convert.ToInt32(0)+"','" + Convert.ToInt32(2)+ "','" + Convert.ToInt32(ddlWarehouse.SelectedValue)+"','" + Convert.ToInt32(ddlWarehouse.SelectedValue)+"', 0) ");
        grBook.DataSource = ds12.Tables[0];
            grBook.DataBind();


        //}
    }
    protected void btnClose(object sender, EventArgs e)
    {
        GID.Visible = false;
        a.Visible = true ;
    }
    
    //

    

    protected void grBook_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
          //  string ProcValueForUpdate = "";
          //CheckBoxList obChkLooseBundleList = (CheckBoxList)e.Row.FindControl("ChkBundleList");
          //TextBox txtbox = (TextBox)e.Row.FindControl("txtNofBooks");   
          // DataSet dddd= obCommonFuctionForUpdate.FillDatasetByProc("call USP_DPTGetStockParivartan(" + Convert.ToInt32(((Button)e.Row.FindControl("btnSaveAll")).CssClass) + "," + Session["UserID"] + ",100)");
          //  obChkLooseBundleList.DataSource = dddd.Tables[0];
          //  obChkLooseBundleList.DataValueField = "StockDetailsChildID_I";
          //  obChkLooseBundleList.DataTextField = "BundleNo_I";
          //  obChkLooseBundleList.RepeatColumns = 10;
          //  obChkLooseBundleList.DataBind();

        }
        catch { }
    }
     protected void Button5_Click(object sender, EventArgs e)
     {
         fadeDiv.Style.Add("display", "none");
         Messages.Style.Add("display", "none");
     }
     protected void But1_Click(object sender, EventArgs e)
     {
         try
         {
             CommonFuction obCommonFuction = new CommonFuction();
             HideAllDiv();
             for (int j = 0; j < grdPrinterBundleDetails.Rows.Count; j++)
           
                fadeDiv.Style.Add("display", "block");
             Messages.Style.Add("display", "block");
                 string str1 = "";
                 string str2 = "";
                 for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
                 {
                     str1 = "";
                     str2 = "";
                     str1 = "'";
                     str2 = "'";
                     CheckBoxList obChkLooseBundleList = (CheckBoxList)grdPrinterBundleDetails.Rows[i].FindControl("ChkLooseBundleList");
                     foreach (ListItem a in obChkLooseBundleList.Items)
                     {

                         if (a.Selected)
                         {
                             if (str1 == "")
                             {

                                 str1 = a.Text;
                             }
                             else
                             {
                                 count12 = count12 + 1;
                                 str1 = str1 + "," + a.Text;
                             }

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
                     if (str1.ToString() != "''")
                     {
                         if (str2.ToString() == "''")
                         {
                             str2 = "''";
                             obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set  IsOpenMarket ='1'  where BundleNo_I='" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "' and  StockDetailsChildID_I=" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "");
                           //  obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Block',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "," + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "," + str1 + "," + ddlChallano.SelectedValue + ")");
                             obCommonFuctionForUpdate.FillDatasetByProc("call USP_DPT_StockParivartan(" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ",'" + Convert.ToInt32(((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text) + "','" + Convert.ToInt32(((Label)grdPrinterBundleDetails.Rows[i].FindControl("FromNo_I")).Text) + "','" + Convert.ToInt32(((Label)grdPrinterBundleDetails.Rows[i].FindControl("ToNo_I")).Text) + "'," + str1 + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlMedium.SelectedValue + ",0 ," + ddlWarehouse.SelectedValue + "," + ddlNewWarehous.SelectedValue + ",'" + txtRefrenceNo.Text + "'," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + "," + Session["UserID"] + ")");
                         }
                         else
                         {
                             obCommonFuction.FillDatasetByProc(@"update dpt_stockdetailschild_t set  IsOpenMarket ='1', RemaingLoose_V=" + str2 + ",RemainingStock=" + str1 + " where BundleNo_I='" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "' and  StockDetailsChildID_I=" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "");
                           //  obCommonFuction.FillDatasetByProc("call USP_DPT_dtp_loosebandaldetailsSave ('Block',0,0," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + "," + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + "," + str1 + "," + ddlChallano.SelectedValue + ")");
                             obCommonFuctionForUpdate.FillDatasetByProc("call USP_DPT_StockParivartan(" + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField1")).Value + ",'" + Convert.ToInt32(((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text) + "','" + Convert.ToInt32(((Label)grdPrinterBundleDetails.Rows[i].FindControl("FromNo_I")).Text) + "','" + Convert.ToInt32(((Label)grdPrinterBundleDetails.Rows[i].FindControl("ToNo_I")).Text) + "'," + str1 + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlMedium.SelectedValue + ",0," + ddlWarehouse.SelectedValue + "," + ddlNewWarehous.SelectedValue + ",'" + txtRefrenceNo.Text + "'," + ((HiddenField)grdPrinterBundleDetails.Rows[i].FindControl("HiddenField2")).Value + "," + Session["UserID"] + ")");
                             //(`` INT, `` INT, `` INT, `` INT, `RemaingLoose` text, `DateS` DATETIME, `MediumID` INT, `ClassID` INT, `WareHOuseID` INT, `NewWarehouseID` INT, `RefLeeter` VARCHAR(100), `TitalID` INT, `DepotID` INT)
                         
                         }



                     }

                     str1 = "";
                     str2 = "";

                 }
              

            

         }
         catch { }
         Label1.Text="Data Saved ";
         grdPrinterBundleDetails.DataSource = null;
         grdPrinterBundleDetails.DataBind();
     }

     protected void Button4_Click(object sender, EventArgs e)
     {
         CommonFuction obCommonFuction = new CommonFuction();

             Button bt = (Button)sender;
             GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
             TextBox txtbandle = (TextBox)grdrow.FindControl("txtbandle");

             DataSet ds = obCommonFuction.FillDatasetByProc("Call GetLoojbandle(" + Session["UserID"] + "," + bt.CommandArgument + ",'"+txtbandle.Text+"')");
             grdPrinterBundleDetails.DataSource = ds;
             grdPrinterBundleDetails.DataBind();
         //    Label2.Text = grdrow.Cells[3].Text;
         fadeDiv.Style.Add("display", "block");
         Messages.Style.Add("display", "block");
         HideAllDiv();
     }
     protected void Button6_Click(object sender, EventArgs e)
     {
         CommonFuction obCommonFuction = new CommonFuction();

             Button bt = (Button)sender;
             GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
             TextBox txtbandle = (TextBox)grdrow.FindControl("txtbandle");

             DataSet dt = obCommonFuction.FillDatasetByProc(@"call dptStockDetailsReport(" + Session["USerID"] + "," + bt.CommandArgument + ",0,0)");
             grd15.DataSource = dt.Tables[0];
             grd15.DataBind();
         //    Label2.Text = grdrow.Cells[3].Text;
         Div2.Style.Add("display", "block");
         Div3.Style.Add("display", "block");
         HideAllDiv();
     }
     protected void Button7_Click(object sender, EventArgs e)
     {
         Div2.Style.Add("display", "none");
         Div3.Style.Add("display", "none");
     }
    //Button4_Click
   // Button5_Click
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class Depo_DPT007_StockMaster : System.Web.UI.Page
{
    int TotalBandal, count1; int total = 0, count12 ;

    MediumMaster obMediumMaster = null;
    ClassMaster obClass = null;
    WareHouseMaster obWareHouseMaster = null;
    StockMaster obStockMaster = new StockMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        HideAllDiv();
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

            //---------------------Warehouse Name
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserId"]);
            DataSet ds = obWareHouseMaster.Select();
            ddlWarehouse.DataTextField = "WareHouseName_V";
            ddlWarehouse.DataValueField = "WareHouseID_I";
            ddlWarehouse.DataSource = ds.Tables[0];
            ddlWarehouse.DataBind();
            ddlWarehouse.Items.Insert(0, "सलेक्ट करे ..");

        }


    }
    protected void aa(object sender, EventArgs e)
    {
        Button hp = (Button)sender;
        GridViewRow grd = (GridViewRow)(hp.NamingContainer);

        Panel pnlData = (Panel)grd.FindControl("DivR");
        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");
      //  txtNofBooks
        TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
        Label lbl1 = (Label)grd.FindControl("lbl1");
        HiddenField HiddenField1 = (HiddenField)grd.FindControl("HiddenField1");
        CommonFuction obj = new CommonFuction();
       DataSet dda= obj.FillDatasetByProc("select BookNumber from tbl_bookperbundle where TitleID=" + HiddenField1.Value + "");
       txtPer.Text = dda.Tables[0].Rows[0]["BookNumber"].ToString();
      //  HiddenField1
        lbl1.Text = txtNofBooks.Text;
    }
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
        Panel pnlData = (Panel)grd.FindControl("DivR");
        fadeDiv.Style.Add("display", "block");
     pnlData.Style.Add("display", "block");
    }
    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in grBook.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");
            fadeDiv.Style.Add("display", "none");
        }


    }


    protected void chkIsLooseChange(object sender, EventArgs e)
    {
        HideAllDiv();
        CheckBox chkbox = (CheckBox)sender;

       
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        Label lblbun = (Label)grd.FindControl("lblbun");
        lblbun.Text = "बंडल क्रमांक";
        CheckBox chkgbundle = (CheckBox)grd.FindControl("chkgbundle");
        if (chkgbundle.Checked)
        {
            lblbun.Text = "बंडल क्रमांक से";
        }
        TextBox txtb = (TextBox)grd.FindControl("txtb");
        txtb.Visible = true;
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
                    txtPer.Text = ((Convert.ToInt32(dr["ToNo_I"]) - Convert.ToInt32(dr["FromNo_I"]))+1).ToString();
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

    protected void btnAllSaveClick(object sender, EventArgs e)
    {
        HideAllDiv();
        Button bt = (Button)sender;
        // TextBox txtbox = (TextBox)sender;
        

       
        GridViewRow grd = (GridViewRow)(bt.NamingContainer);
        HiddenField HiddenField1 = (HiddenField)grd.FindControl("HiddenField1");

        Label lblbun = (Label)grd.FindControl("lblbun");
        lblbun.Text = "बंडल क्रमांक";
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtf1 = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");

        TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtTo1 = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        CheckBoxList ChkBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");

        CheckBox chkgbundle = (CheckBox)grd.FindControl("chkgbundle");
        




        Label lblmsg = (Label)grd.FindControl("lblmsg");
        Panel pnlError = (Panel)grd.FindControl("mainDiv");
        pnlError.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        if (txtBundle.Text == "")
        {

            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "Plaese enter bundle no";
            return;

        }
        if (txtf.Text == "")
        {

            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "Plaese enter from book no";
            return;

        }
        if (txtPer.Text == "")
        {

            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "Plaese enter no of books in each bundle";
            return;

        }

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
                    obStockDetailsChild.BundleNo_I = Convert.ToInt32(txtBundle.Text);
                    obStockDetailsChild.FromNo_I = Convert.ToInt32(txtf.Text);
                    obStockDetailsChild.ToNo_I = Convert.ToInt32(txtTo.Text);
                    obStockDetailsChild.Trans_I = Convert.ToInt32(item.Value);
                    string str1 = "";

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
                    obStockDetailsChild.RemaingLoose_V = str1;
                    obStockDetailsChild.StockDetailsChildID_I = Convert.ToInt32(item.Value); ;
                    obStockDetailsChild.StockDetailsID_I = Convert.ToInt32(HdnTrasactionID.Value);
                    obStockDetailsChild.InsertUpdate();
                    txtf.Text = "";
                    txtPer.Text = "";
                    //txtNofBooks.Text = "";
                    txtBundle.Text = "";
                    txtTo.Text = "";
                    string ProcValueForUpdate = "";
                    ProcValueForUpdate = ProcValueForUpdate + "Call GetBundledataByWareHouseWithDate(" + Convert.ToInt32(bt.CssClass);
                    ProcValueForUpdate = ProcValueForUpdate + "," + ddlWarehouse.SelectedValue;
                    ProcValueForUpdate = ProcValueForUpdate + "," + ddlType.SelectedValue;
                    ProcValueForUpdate = ProcValueForUpdate + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'";
                    ProcValueForUpdate = ProcValueForUpdate + ")";
                    //obCommonFuctionForUpdate.FillDatasetByProc(ProcValueForUpdate);
                    // call GetBundledataByWareHouseWithDate(1,2,1,'2015-02-25')
                    ChkBundleList.DataSource = obCommonFuctionForUpdate.FillDatasetByProc(ProcValueForUpdate);
                    ChkBundleList.DataValueField = "StockDetailsChildID_I";
                    ChkBundleList.DataTextField = "BundleNo_I";
                    ChkBundleList.RepeatColumns = 10;
                    ChkBundleList.DataBind();
                    obChkLooseBundleList.Items.Clear();
                    //CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
                    chkbox.Checked = false;
                    pnlError.Attributes.Add("class", "success");
                    lblmsg.Text = "Record Update Successfully";

                    return;

                }
            }
        }

        if (bt.CommandArgument == "0")
        {
            

            StockDetails obStockDetails = new StockDetails();
            if (txtNofBooks.Text != "")
            {
                obStockDetails.NoOfBooks_I = Convert.ToInt32(txtNofBooks.Text);
            }

            obStockDetails.Stock_ID_I = Convert.ToInt32(HdnMasterHdnId.Value);
            obStockDetails.SubJectID_I = Convert.ToInt32(bt.CssClass);
            obStockDetails.Trans_I = 0;
            obStockDetails.BookType_I = Convert.ToInt32(ddlType.SelectedValue);

            HdnTrasactionID.Value = Convert.ToString(obStockDetails.InsertUpdate());
        }
        else
        {
            HdnTrasactionID.Value = bt.CommandArgument;
        }

        if (chkgbundle.Checked)
        {

            lblbun.Text = "बंडल क्रमांक से";
            int toBundle = (Convert.ToInt32(txtTo1.Text) - Convert.ToInt32(txtf1.Text)+1) / Convert.ToInt32(txtPer.Text);
            int reminderBundle = (Convert.ToInt32(txtTo1.Text) - Convert.ToInt32(txtf1.Text)+1) % Convert.ToInt32(txtPer.Text);
            int FrombokkNo = Convert.ToInt32(txtf1.Text);
            for (int i = Convert.ToInt32(txtBundle.Text); i < Convert.ToInt32(txtBundle.Text) + toBundle; i++)
            {
                obStockDetailsChild.BundleNo_I = i;
                obStockDetailsChild.FromNo_I = FrombokkNo;
                obStockDetailsChild.ToNo_I = FrombokkNo + Convert.ToInt32(txtPer.Text) - 1;
                obStockDetailsChild.Trans_I = 0;

                obStockDetailsChild.RemaingLoose_V = "";
                obStockDetailsChild.StockDetailsChildID_I = 0;
                obStockDetailsChild.StockDetailsID_I = Convert.ToInt32(HdnTrasactionID.Value);
                obStockDetailsChild.InsertUpdate();
                FrombokkNo = obStockDetailsChild.ToNo_I + 1;
            }
            if (reminderBundle > 0)
            {
                string losestring = "";
                for (int j = 0; j < reminderBundle; j++)
                {
                    if (losestring == "")
                    {
                        losestring = (FrombokkNo + j).ToString();
                    }
                    else
                    {
                        losestring = losestring + "," + (FrombokkNo + j).ToString();
                    }

                }

                obStockDetailsChild.BundleNo_I = obStockDetailsChild.BundleNo_I+1;
                obStockDetailsChild.FromNo_I = FrombokkNo;
                obStockDetailsChild.ToNo_I = FrombokkNo + reminderBundle - 1;
                obStockDetailsChild.Trans_I = 0;

                obStockDetailsChild.RemaingLoose_V = losestring;
                obStockDetailsChild.StockDetailsChildID_I = 0;
                obStockDetailsChild.StockDetailsID_I = Convert.ToInt32(HdnTrasactionID.Value);
                obStockDetailsChild.InsertUpdate();

            }
        }
        else
        {


            obStockDetailsChild.BundleNo_I = Convert.ToInt32(txtBundle.Text);
            obStockDetailsChild.FromNo_I = Convert.ToInt32(txtf.Text);
            obStockDetailsChild.ToNo_I = Convert.ToInt32(txtTo.Text);
            obStockDetailsChild.Trans_I = 0;
            string str = "";

            foreach (ListItem a in obChkLooseBundleList.Items)
            {

                if (a.Selected)
                {
                    if (str == "")
                    {
                        str = str + a.Text;
                    }
                    else
                    {
                        str = str + "," + a.Text;
                    }

                }

            }
            obStockDetailsChild.RemaingLoose_V = str;
            obStockDetailsChild.StockDetailsChildID_I = 0;
             obStockDetailsChild.StockDetailsID_I = Convert.ToInt32(HdnTrasactionID.Value);
            obStockDetailsChild.InsertUpdate();
        }
        CommonFuction obCommonFuction = new CommonFuction();

        string ProcValue = "";
        ProcValue = ProcValue + "Call GetBundledataByWareHouseWithDate(" + Convert.ToInt32(bt.CssClass);
        ProcValue = ProcValue + "," + ddlWarehouse.SelectedValue;
        ProcValue = ProcValue + "," + ddlType.SelectedValue;
        ProcValue = ProcValue + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'";
        ProcValue = ProcValue + ")";
        obCommonFuction.FillDatasetByProc(ProcValue);
        // call GetBundledataByWareHouseWithDate(1,2,1,'2015-02-25')
        ChkBundleList.DataSource = obCommonFuction.FillDatasetByProc(ProcValue);
        ChkBundleList.DataValueField = "StockDetailsChildID_I";
        ChkBundleList.DataTextField = "BundleNo_I";
        ChkBundleList.RepeatColumns = 10;
        ChkBundleList.DataBind();
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
        if (RadioButtonList1.SelectedValue == "2")
        {
            ddlBookType.Visible = true;
        }
        else
        {
            ddlBookType.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Session["OfficeTrNo"] = 1;
        obStockMaster = new StockMaster();
        obStockMaster.Date_D = Convert.ToDateTime(txtDate.Text, cult);
        obStockMaster.WareHouseID_I = Convert.ToInt32(ddlWarehouse.SelectedValue);
        obStockMaster.MediamID_I = Convert.ToInt32(ddlMedium.SelectedValue);
        obStockMaster.BookType_I = Convert.ToInt32(ddlType.SelectedValue);
        obStockMaster.ClassID_I = Convert.ToInt32(ddlCls.SelectedValue);
        obStockMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
        obStockMaster.TypeDetails = Convert.ToInt32(RadioButtonList1.SelectedValue);
        obStockMaster.Trans_I = 0;
        obStockMaster.DepoID_I = Convert.ToInt32(Session["UserID"]);
        obStockMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
        id = obStockMaster.InsertUpdate();

        if (id != 0)
        {
            HdnMasterHdnId.Value = id.ToString();

            GID.Visible = true;
            a.Visible = false;
            CommonFuction comm=new CommonFuction ();
            string   Classes = "1,2,3,4,5,6,7,8";
          DataSet ds12 = obStockMaster.Select1(Convert.ToInt32(ddlCls.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(RadioButtonList1.SelectedValue), Convert.ToInt32(ddlBookType.SelectedValue), Convert.ToInt32(ddlWarehouse.SelectedValue), Convert.ToInt32(ddlWarehouse.SelectedValue), Convert.ToDateTime(txtDate.Text, cult), Convert.ToInt32(HdnMasterHdnId.Value));
           // DataSet ds12 = comm.FillDatasetByProc("call USP_DPT011FatchBookData('" + Classes + "', Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(RadioButtonList1.SelectedValue), Convert.ToInt32(ddlBookType.SelectedValue), Convert.ToInt32(ddlWarehouse.SelectedValue)");
            grBook.DataSource = ds12.Tables[0];
            grBook.DataBind();


        }
    }
}
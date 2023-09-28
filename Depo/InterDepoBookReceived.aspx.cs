using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer.Paper;

public partial class Depo_InterDepoBookReceived : System.Web.UI.Page
{
    WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = null;
    StockMaster obStockMaster = new StockMaster(); Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    CultureInfo cult = new CultureInfo("gu-IN", true); DataSet fillgrd;
    BookReceivedDetails obBookReceivedDetails = new BookReceivedDetails();
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        if (!IsPostBack)
        {
            
            txtPdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            ListItem oblistitem = new ListItem();
            oblistitem.Text = "सलेक्ट करे ..";
            oblistitem.Value = "0";
            tblDepo.Visible = false;
            obCommonFuction = new CommonFuction();
            string user = Session["UserName"].ToString().ToLower();
            string userName = user.Replace("depo", "");
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('" + userName + "')");
            ddlEmployee.DataSource = ds.Tables[0];
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "EmployeeID_I";

            ddlEmployee.DataBind();
          
            ddldepoEmployee.DataSource = ds.Tables[0];
            ddldepoEmployee.DataTextField = "Name";
            ddldepoEmployee.DataValueField = "EmployeeID_I";

            ddldepoEmployee.DataBind();
            ddldepoEmployee.Items.Insert(0, oblistitem);
            ddlEmployee.Items.Insert(0, oblistitem);

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_load(" + Session["UserID"] + "," + RadioButtonList2.SelectedValue + ")");


            grdDetails.DataSource = ds1.Tables[0];
            grdDetails.DataBind();

            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet dsWareHouse = obWareHouseMaster.Select();
            ddlWarehouse.DataTextField = "WareHouseName_V";
            ddlWarehouse.DataValueField = "WareHouseID_I";
            ddlWarehouse.DataSource = dsWareHouse.Tables[0];
            ddlWarehouse.DataBind();
          
            

            ddlWarehouse.Items.Insert(0, oblistitem);

            ddldepoWarehouse.DataTextField = "WareHouseName_V";
            ddldepoWarehouse.DataValueField = "WareHouseID_I";
            ddldepoWarehouse.DataSource = dsWareHouse.Tables[0];
            ddldepoWarehouse.DataBind();
            ddldepoWarehouse.Items.Insert(0, oblistitem);
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlMedium.DataSource = objTentativeDemandHistory.MedumFill();
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "Select");
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("SELECT TitleID_I, TitleHindi_V FROM acd_titledetail order by TitleID_I");
          ddlTital.DataSource = asdf.Tables[0];
          ddlTital.DataTextField = "TitleHindi_V";
          ddlTital.DataValueField = "TitleID_I";
          ddlTital.DataBind();
          ddlTital.Items.Insert(0, "Select");

           

        }

    }

    protected void viewDatails(object sender, EventArgs e)
    {
        HideAllDiv();
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        //GridView grdPrinterBundleDetails = (GridView)grdrow.FindControl("grdPrinterBundleDetails");
        GridView GrdMismatch = (GridView)grdrow.FindControl("GrdMismatch");
        HiddenField HiddenField1 =(HiddenField)grdrow.FindControl("HiddenField1");
        CommonFuction obCommonFuction = new CommonFuction();
        //obCommonFuction.FillDatasetByProc("call UpdateBundalfromBarcodeDevice()");
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT_ShowPrinterChallanBandalDetails(" + HiddenField1.Value + "," + bt.CommandArgument + ")");
        GrdMismatch.DataSource = ds.Tables[0];
        GrdMismatch.DataBind();

       
        Panel pnlData = (Panel)(grdrow.FindControl("DivR"));
        // Panel pnlData = ((Panel)(Session["pnlCurrentSession"]));
        pnlData.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    
    }
    protected void SerarchDepoOrdere(object sender, EventArgs e)
    {
        if (ddldepoWarehouse.SelectedItem.Text == "सलेक्ट करे ..")
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.Attributes.Add("class", "error");
            lblmsg.Text = "Please select warehouse";
            lblmsg.Style.Add("display", "block");
            return;
        }
        if (ddlOrderNo.SelectedIndex == -1)
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.Attributes.Add("class", "error");
            lblmsg.Text = "No records found ";
            lblmsg.Style.Add("display", "block");
            return;
        }
        try
        {
            obCommonFuction = new CommonFuction();
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT036_GETINETRDEPORecevedDeatails(" + ddlOrderNo.SelectedValue + ")");
            if (ds1.Tables[0].Rows.Count == 0)
            {
                mainDiv.Style.Add("display", "block");
                mainDiv.Attributes.Add("class", "error");
                lblmsg.Text = "No records found ";
                lblmsg.Style.Add("display", "block");
                return;
            }
            grdInterdepoRequest.DataSource = ds1;
            grdInterdepoRequest.DataBind();

            if (grdInterdepoRequest.Rows.Count > 0)
            {
                divDepo.Visible = true;

            }
        }
        catch { 
        
        }
        //DataTable objrow = ds1.Tables[0];


        // EnumerableRowCollection<DataRow> query = (from objrownew in objrow.AsEnumerable() where objrownew.Field<string>("challanno") == ddlOrderNo.SelectedValue select objrownew);
        //   DataView view = query.AsDataView();
        //   grdDepoTransfer.DataSource = view;
        //    grdDepoTransfer.DataBind();


    }
    //DdlACYear_SelectedIndexChanged aaa
protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
        DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_loadNew(" + Session["UserID"] + "," + RadioButtonList2.SelectedValue + ",'"+DdlACYear.SelectedItem.Text +"')");


        grdDetails.DataSource = ds1.Tables[0];
        grdDetails.DataBind();

    }
    protected void RadioButtonList3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void SaveAll(object sender, EventArgs e)
    {
        HideAllDiv();
        CommonFuction obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("call USP_DPT_038UpdatePrinterChallanStatus(" + hPrinterID.Value + "," + Convert.ToInt32(Session["UserID"]) + ")");
        mainDiv.Attributes.Add("class", "success");
        mainDiv.Style.Add("display", "block");
        lblmsg.Text = "Book Received Successfully";
        lblmsg.Style.Add("display", "block");
        grdDetails.DataSource = null;
        grdDetails.DataBind();
    }

    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in grdDetails.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");

        }
        foreach (GridViewRow grdrow in grdDepoTransfer.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");

        }



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



    protected void btnAllSaveClick(object sender, EventArgs e)
    {

        Button bt = (Button)sender;
        // TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(bt.NamingContainer);
        List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
        TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");

        TextBox txtNofBooks = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
        CheckBoxList obChkLooseBundleList = (CheckBoxList)grd.FindControl("ChkLooseBundleList");
        CheckBoxList ChkBundleList = (CheckBoxList)grd.FindControl("ChkBundleList");
        Panel pnlData = (Panel)grd.FindControl("DivR");
        CheckBox chkbox = (CheckBox)grd.FindControl("chkIsLoose");
        DropDownList ddlType = (DropDownList)grd.FindControl("ddlType");

        HiddenField HiddenField1 = (HiddenField)grd.FindControl("HiddenField1");


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
        if (bt.CommandArgument == "")
        {

            StockDetails obStockDetails = new StockDetails();
            if (txtNofBooks.Text != "")
            {
                obStockDetails.NoOfBooks_I = Convert.ToInt32(txtNofBooks.Text);
            }

            obStockDetails.Stock_ID_I = Convert.ToInt32(hdnMasterID.Value);
            obStockDetails.SubJectID_I = Convert.ToInt32(HiddenField1.Value);
            obStockDetails.Trans_I = 0;
            obStockDetails.BookType_I = Convert.ToInt32(ddlType.SelectedValue);

            HdnTrasactionID.Value = Convert.ToString(obStockDetails.InsertUpdate());
        }
        else
        {
            HdnTrasactionID.Value = bt.CommandArgument;
        }




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

        CommonFuction obCommonFuction = new CommonFuction();

        string ProcValue = "";
        ProcValue = ProcValue + "Call GetBundledataByWareHouseWithDate(" + Convert.ToInt32(HiddenField1.Value);
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

        DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT_GetPrinterReceiveStock(" + Convert.ToInt32(Session["UserID"]) + "," + hdnMasterID.Value + ")");
        grdInterdepoRequest.DataSource = ds1;
        grdInterdepoRequest.DataBind();

        b.Visible = false;
        btnSaveAll.Visible = true;
    }


    protected void SubmitAllClick(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "1")
        {
            foreach (GridViewRow grdrow in grdDetails.Rows)
            {



            }
        }
        if (RadioButtonList2.SelectedValue == "2")
        {
            foreach (GridViewRow grdrow in grdDepoTransfer.Rows)
            {



            }
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
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Close(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        ra.Style.Add("display", "none");
        b.Visible = true;
    }
    protected void Close1(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        ra.Style.Add("display", "block");
        b.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Enabled = false;
        Session["OfficeTrNo"] = 1;
        obStockMaster = new StockMaster();
        if (RadioButtonList2.SelectedValue == "2")
        {
            obStockMaster.Date_D = System.DateTime.Now;
            obStockMaster.WareHouseID_I = Convert.ToInt32(ddldepoWarehouse.SelectedValue);
            obStockMaster.MediamID_I = 0;
            obStockMaster.BookType_I = 0;
            obStockMaster.ClassID_I = 0;
            obStockMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            obStockMaster.TypeDetails = Convert.ToInt32(0);
            obStockMaster.Trans_I = 0;
            obStockMaster.DepoID_I = Convert.ToInt32(Session["UserID"]);
            obStockMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            id = obStockMaster.InsertUpdate();
            hdnMasterID.Value = id.ToString();
            BookReceivedDetails obBookReceivedDetails = new BookReceivedDetails();

            obBookReceivedDetails.ChallanDate_D = System.DateTime.Now;
            obBookReceivedDetails.ChallanNo_V = Convert.ToString(ddlOrderNo.SelectedValue);
            obBookReceivedDetails.Ddate_D = System.DateTime.Now;
            obBookReceivedDetails.EmployeeName_I = Convert.ToInt32(ddldepoEmployee.SelectedValue);
            obBookReceivedDetails.GRDate_D = Convert.ToDateTime(txtDepoGrnoDate.Text, cult);
            obBookReceivedDetails.GRNo_V = Convert.ToString(txtDepoGrno.Text);
            obBookReceivedDetails.IsStanderd_I = 0;
            obBookReceivedDetails.LordingCharge_N = Convert.ToInt32(txtdepolOading.Text);
            obBookReceivedDetails.OrderDate_D = System.DateTime.Now;
            obBookReceivedDetails.OrderNo_I = "";
            obBookReceivedDetails.OtherCharges_N = Convert.ToInt32(txtDepoother.Text);

            obBookReceivedDetails.Stock_ID_I = Convert.ToInt32(id);
            obBookReceivedDetails.TransactionDate_N = Convert.ToDateTime(txtPdate.Text, cult);
            obBookReceivedDetails.TransportationCharge_N = Convert.ToInt32(txtDepoTransport.Text);
            obBookReceivedDetails.TruckNo_V = Convert.ToString(txtDepoTruck.Text);
            obBookReceivedDetails.TwentyfivePerStatus_I = 0;
            obBookReceivedDetails.unLordingCharge_N = Convert.ToInt32(txtDepoUnloading.Text);
            obBookReceivedDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            obBookReceivedDetails.ReceivedType_I = 1;

            obBookReceivedDetails.BundleNo = "-1";
            obBookReceivedDetails.LooseBookNo = "";

            obBookReceivedDetails.InsertUpdate();

            obCommonFuction = new CommonFuction();
            obCommonFuction.FillDatasetByProc("call USP_DPTUpdateWAreHousrID('" + ddlOrderNo.SelectedValue + "')");
            ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT35GetReceivedInterDepoRequest(" + Session["UserID"] + ")");
            ddlOrderNo.DataTextField = "challanno";
            ddlOrderNo.DataValueField = "challanno";
            ddlOrderNo.DataBind();

            mainDiv.Attributes.Add("class", "success");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Book Received Successfully";
            lblmsg.Style.Add("display", "block");
            divDepo.Visible = false;

        }
        else
        {

         
           
            obStockMaster.Date_D = Convert.ToDateTime(txtDate.Text, cult);
            obStockMaster.WareHouseID_I = Convert.ToInt32(ddlWarehouse.SelectedValue);
            obStockMaster.MediamID_I = Convert.ToInt32(MediunID.Value);
            obStockMaster.BookType_I = Convert.ToInt32(1);
            obStockMaster.ClassID_I = Convert.ToInt32(ClassID.Value);
            obStockMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            obStockMaster.TypeDetails = Convert.ToInt32(0);
            obStockMaster.Trans_I = 0;
            obStockMaster.DepoID_I = Convert.ToInt32(Session["UserID"]);
            obStockMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            id = obStockMaster.InsertUpdate();
            hdnMasterID.Value = id.ToString();
            CommonFuction comm = new CommonFuction();
            comm.FillDatasetByProc("update dpt_stockdetails_t set Stock_ID_I=" + hdnMasterID.Value + " where SubJectID_I=" + hdnTitleID.Value + "");
            obBookReceivedDetails.ChallanDate_D = Convert.ToDateTime(lblchalandate.Text, cult);
            obBookReceivedDetails.ChallanNo_V = Convert.ToString(lblchalan.Text);
            obBookReceivedDetails.Ddate_D = Convert.ToDateTime(txtDate.Text, cult);
            obBookReceivedDetails.EmployeeName_I = Convert.ToInt32(ddlEmployee.SelectedValue);
            obBookReceivedDetails.GRDate_D = Convert.ToDateTime(txtDate.Text, cult);
            obBookReceivedDetails.GRNo_V = Convert.ToString(txtGrNo.Text);
            obBookReceivedDetails.IsStanderd_I = Convert.ToInt32(RdlManak.SelectedValue);
            obBookReceivedDetails.LordingCharge_N = Convert.ToInt32(txtloding.Text);
            obBookReceivedDetails.OrderDate_D = Convert.ToDateTime(System.DateTime.Now);
            obBookReceivedDetails.OrderNo_I = Convert.ToString(lblorder.Text);
            obBookReceivedDetails.OtherCharges_N = Convert.ToInt32(txtOther.Text);
            obBookReceivedDetails.PinterID_I = Convert.ToInt32(hPrinterID.Value);
            obBookReceivedDetails.ReceivedType_I = Convert.ToInt32(RadioButtonList2.SelectedValue);
            obBookReceivedDetails.Stock_ID_I = Convert.ToInt32(id);
            obBookReceivedDetails.TransactionDate_N = Convert.ToDateTime(txtPdate.Text, cult);
            obBookReceivedDetails.TransportationCharge_N = Convert.ToInt32(txtTransport.Text);
            obBookReceivedDetails.TruckNo_V = Convert.ToString(txtTruckNo.Text);
            obBookReceivedDetails.TwentyfivePerStatus_I = Convert.ToInt32(RdlTwentyFivePer.SelectedValue);
            obBookReceivedDetails.unLordingCharge_N = Convert.ToInt32(txtunloding.Text);
            obBookReceivedDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            obBookReceivedDetails.InsertUpdate();

            CommonFuction  obCommon = new CommonFuction();
            obCommon.FillDatasetByProc("call USP_DPT_042UpdatePrinterStockStatus(" + ddlWarehouse.SelectedValue + "," + hPrinterID.Value + ")");
            if (chkid.Checked)
            {
               
                obCommon.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute =5 , WareHouseID =0  where PriTransID ='" + Convert.ToInt32(hPrinterID.Value) + "'");
            
            }
          
            obCommon.FillDatasetByProc("call USP_DPT_038UpdatePrinterChallanStatus(" + hPrinterID.Value + "," + Convert.ToInt32(Session["UserID"]) + ")");
           
           RadioButtonList2_SelectedIndexChanged(sender, e);
           try
           {
               DataSet ds;
               MailHelper objSendSms = new MailHelper();
               PPR_RDLCData objGetMobile = new PPR_RDLCData();
               string Msg = "", DepotMoblNo = "";
               //Usp_Get_SMS_MobileNo
               ds = new DataSet();
               ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
               Msg = " Received as per  Name of Book: " + lblbookName.Text.Trim() + ", No Of Buldels: " + lblSBundleCount.Text + ",Challan No and Date: " + lblchalan.Text + "-" + lblchalandate.Text + ",Depot Name: " + Session["UserName"];
               //Msg = "Received as per Challan No : " + lblchalan.Text.Trim() + "  and date " + lblchalandate.Text + " On " + txtPdate.Text + " Date";
               foreach (DataRow Dr in ds.Tables[0].Rows)
               {
                   if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Distribution")
                   {
                       try
                       {
                           objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                       }
                       catch { }
                   }
                   if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
                   {
                       try
                       {
                       objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                       }
                       catch { }
                   }
               }
               try
               {
                   // ds2 = new DataSet();
                   //  ds2 = obCommonFuction.FillDatasetByProc("CALL GetMobleNumberDeport(" + Session["UserID"] + ",0,0)");
                   // objSendSms.sendMessage(ds2.Tables[0].Rows[0]["mobno_v"].ToString(), Msg);
                   // Paper Vendor
                   ds = new DataSet();
                   ds = obCommonFuction.FillDatasetByProc("CALL GetMobleNumberDeport(" + Session["UserID"] + ",0,0)");
                   objSendSms.sendMessage(ds.Tables[0].Rows[0]["mobno_v"].ToString(), Msg);
               }
               catch { }
           }
           catch { } 
            //mail.sendMessage("9893140658,9993146080", "Receive as per challan no " + lblchalan.Text + " and date  " + lblchalandate.Text + " on "+System.DateTime.Now.ToString("dd/MM/yyyy")+"");
            Response.Redirect("PrinReport.aspx?challanNo=" + lblchalan.Text + "&date=" + lblchalandate.Text + "&PrinterID=" + hPrinterID.Value + "&titalID=" + hdnTitleID.Value + "&PrinterName=" + lblAddress.Text + "&bookName=" + lblbookName.Text + "&loding=" + txtloding.Text + "&unloading=" + txtunloding.Text + "&trspotration=" + txtTransport.Text + "&TruckNo=" + txtTruckNo.Text + "&Other=" + txtOther.Text + "&BookType="+lblBookType.Text+"");
            HideAllDiv();
            mainDiv.Style.Add("display", "block");
            mainDiv.Attributes.Add("class", "sucess");
            lblmsg.Text = " चालान क्रमांक :" + lblchalan.Text + " में मुद्रक : " + lblAddress.Text + " दे बण्डल " + lblYBundlecnt.Text+ " प्राप्त कर ली गई है कृपया गणना रिपोर्ट तैयार करे !";
            lblmsg.Style.Add("display", "block");
            divDepo.Visible = false;
            tblDepo.Visible = false;
            ra.Style.Add("display", "block");
            b.Visible = false;
            
                            
            if (chkid.Checked)
            {
                Response.Redirect("DepoRecevingwithBarcode.aspx?PrintransID=" + hPrinterID.Value + "&WareHouseID=" + ddlWarehouse.SelectedValue);
            
            }

        }





        if (RadioButtonList2.SelectedValue == "1")
        {
            //foreach (GridViewRow grdrow in grdDetails.Rows)
            //{

            //    if (hdnTitleID.Value == ((HiddenField)grdrow.FindControl("HiddenField1")).Value)
            //    {
            //        Panel pnlData = (Panel)(grdrow.FindControl("DivR"));
            //        // Panel pnlData = ((Panel)(Session["pnlCurrentSession"]));
            //        pnlData.Style.Add("display", "block");
            //        fadeDiv.Style.Add("display", "block");
            //    }


            //}
        }
        if (RadioButtonList2.SelectedValue == "2")
        {
            foreach (GridViewRow grdrow in grdDepoTransfer.Rows)
            {

                if (hdnTitleID.Value == ((HiddenField)grdrow.FindControl("HiddenField1")).Value)
                {
                    Panel pnlData = (Panel)(grdrow.FindControl("DivR"));
                    // Panel pnlData = ((Panel)(Session["pnlCurrentSession"]));
                    pnlData.Style.Add("display", "block");
                    fadeDiv.Style.Add("display", "block");
                }


            }
        }



    }


    public class GenarteLoosebundle
    {
        public string BookNo { get; set; }

    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        obCommonFuction = new CommonFuction();
        if (RadioButtonList2.SelectedValue == "1")
        {

            grdDepoTransfer.DataSource = null;
            grdDepoTransfer.DataBind();
            tblDepo.Visible = false;
            try
            {
                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_load(" + Session["UserID"] + "," + RadioButtonList2.SelectedValue + ")");

                grdDetails.DataSource = ds1.Tables[0];
                grdDetails.DataBind();
            }
            catch
            {
                grdDetails.DataSource = "";
                grdDetails.DataBind();
            }
        }
       

    }



    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        HideAllDiv();
        obCommonFuction = new CommonFuction();
        b.Visible = true;
        //  Session["UserID"] = 7;
        try
        {
            if (RadioButtonList2.SelectedValue == "2")
            {
                hdnTitleID.Value = ((HiddenField)grdDepoTransfer.SelectedRow.FindControl("HiddenField1")).Value;
                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT_GetTransferRequestOfInterDepo(" + Session["UserID"] + ")");
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {


                    divDepo.Visible = true;
                    b.Visible = false;

                }

            }
            else
            {
                try { 
                hdnTitleID.Value = ((HiddenField)grdDetails.SelectedRow.FindControl("HiddenField1")).Value;
                DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT_ShowPrinterChallanBandalDetails(" + hdnTitleID.Value + "," + grdDetails.SelectedDataKey.Value + ")");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds.Tables[0].Rows[0]["Received"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["Toatl"].ToString();
                    lblYBundlecnt.Text = ds.Tables[0].Rows[0]["Received"].ToString();
                    Messages.Style.Add("display", "block");
                    fadeDiv.Style.Add("display", "block");
                }
                }
                catch { }
                DataSet ds2 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_load(" + Session["UserID"] + "," + grdDetails.SelectedDataKey.Value + ")");
                try
                {
                    lblorder.Text = Convert.ToString(ds2.Tables[0].Rows[0]["OrderNo"]);
                }
                catch { }
                //Label3.Text = "";
                lblAddress.Text = Convert.ToString(ds2.Tables[0].Rows[0]["NameofPress_V"]);
                lblBookType.Text = Convert.ToString(ds2.Tables[0].Rows[0]["BookType"]);
                lblbookName.Text = Convert.ToString(ds2.Tables[0].Rows[0]["TitleHindi_V"]);
                lblbookNofrom.Text = Convert.ToString(ds2.Tables[0].Rows[0]["BooksFrom"]);
                lblbookNoto.Text = Convert.ToString(ds2.Tables[0].Rows[0]["Booksto"]);
                //  lblBookType.Text = Convert.ToString(ds2.Tables[0].Rows[0]["BookType"]);
                lblchalan.Text = Convert.ToString(ds2.Tables[0].Rows[0]["ChalanNo"]);
                lblSBundleCount.Text = Convert.ToString(ds2.Tables[0].Rows[0]["PacketsSendAsPerChallan"]);
                //lblYBundlecnt.Text = Convert.ToString(ds2.Tables[0].Rows[0]["PacketsSendAsPerChallanYoj"]);
                lblyfrom.Text = Convert.ToString(ds2.Tables[0].Rows[0]["BooksFromYoj"]);
                lblyto.Text = Convert.ToString(ds2.Tables[0].Rows[0]["BooksToYoj"]);
                lblchalandate.Text = Convert.ToString(ds2.Tables[0].Rows[0]["ChalanDate"]);
                //  lblSBundleCount.Text = Convert.ToString(ds2.Tables[0].Rows[0]["PerBandalBook"]);
                //  lblYBundlecnt.Text = Convert.ToString(ds2.Tables[0].Rows[0]["TotalNoBook"]);
                TiltleID.Value = ((HiddenField)grdDetails.SelectedRow.FindControl("HiddenField1")).Value;
                hdnTitleID.Value = ((HiddenField)grdDetails.SelectedRow.FindControl("HiddenField1")).Value;
                ClassID.Value = ((HiddenField)grdDetails.SelectedRow.FindControl("ClassTrno_I")).Value;
                MediunID.Value = ((HiddenField)grdDetails.SelectedRow.FindControl("Medium_I")).Value;
                try
                {
                    lblorderDate.Text = Convert.ToString(ds2.Tables[0].Rows[0]["Orderdate"]);
                }
                catch { }
                hPrinterID.Value = Convert.ToString(grdDetails.SelectedDataKey.Value);
                txtGrNo.Text = Convert.ToString(ds2.Tables[0].Rows[0]["billtiNo"]);
                txtGrNo.Enabled = false;
                if (ds2.Tables[0].Rows[0]["Billtidate"].ToString() == "0.00")
                {
                    txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                }
                else {
                    txtDate.Text = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Billtidate"]).ToString("dd/MM/yyyy");
                }
                txtDate.Enabled = false;
                txtTruckNo.Text = Convert.ToString(ds2.Tables[0].Rows[0]["TruckNo"]);
                txtTruckNo.Enabled = false;
                //lblbandalFrom.Text = Convert.ToString(ds2.Tables[0].Rows[0]["TotalNoBandal"]);
                Panel pnlData = (Panel)(grdDetails.SelectedRow.FindControl("DivR"));
                HdnTrasactionID.Value = "";
                hdnMasterID.Value = "";
                //  Session["pnlCurrentSession"] = grdDetails.SelectedRow;
                //pnlData.Style.Add("display", "block");
                if (hdnMasterID.Value != "")
                {
                    if (RadioButtonList2.SelectedValue == "1")
                    {
                   // Panel pnlData = ((Panel)(Session["pnlCurrentSession"]));
                        pnlData.Style.Add("display", "block");
                        fadeDiv.Style.Add("display", "block");
                        divDepo.Visible = false;
                        b.Visible = false;
                       


                    }
                }
                else
                {

                    b.Visible = true;
                }
                divDepo.Visible = false;
                
            }
            }
                
        catch { }
    }
    protected void grdDepoTransfer_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            string ProcValue = "";
            DataList dt = (DataList)e.Row.FindControl("datalist");
            HiddenField booktype = (HiddenField)e.Row.FindControl("booktype");

            ProcValue = ProcValue + "Call GetBundledataByWareHouseWithDate(" + Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField1")).Value);
            ProcValue = ProcValue + "," + ddldepoWarehouse.SelectedValue;
            //ProcValue = ProcValue + "," + ddlType.SelectedValue;
            if (booktype.Value == "योजना")
            {
                ProcValue = ProcValue + "," + 1;
            }
            else
            {

                ProcValue = ProcValue + "," + 2;
            }
            ProcValue = ProcValue + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'";
            ProcValue = ProcValue + ")";
            obCommonFuction = new CommonFuction();
            dt.DataSource = obCommonFuction.FillDatasetByProc(ProcValue);
            dt.DataBind();
        }
        catch { }
        finally { }


    }
    protected void ChechedChangeWholeBundle(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow obrow = (GridViewRow)chk.NamingContainer;
        CheckBox chk1 = (CheckBox)obrow.FindControl("chk1");
        chk1.Checked = false;
        HiddenField hdnFromNo_I = (HiddenField)obrow.FindControl("hdnFromNo_I");
        HiddenField hdnToNo_I = (HiddenField)obrow.FindControl("hdnToNo_I");
        HiddenField hdnLooseBundal = (HiddenField)obrow.FindControl("hdnLooseBundal");
        CheckBoxList chklist = (CheckBoxList)obrow.FindControl("chklist");
        if (chk.Checked && hdnLooseBundal.Value == "")
        {
            chklist.Items.Clear();
        }

        if (hdnLooseBundal.Value == "" && !chk1.Checked && chk1.Checked)
        {
            for (int i = Convert.ToInt32(hdnFromNo_I.Value); i <= Convert.ToInt32(hdnToNo_I.Value); i++)
            {
                ListItem item = new ListItem();
                item.Value = i.ToString();
                item.Text = i.ToString();
                chklist.Items.Add(item);
            }


        }


    }

    protected void ChechedChangeLooseBundle(object sender, EventArgs e)
    {

        CheckBox chk = (CheckBox)sender;
        GridViewRow obrow = (GridViewRow)chk.NamingContainer;
        CheckBox chk1 = (CheckBox)obrow.FindControl("chk");
        chk1.Checked = false;
        HiddenField hdnFromNo_I = (HiddenField)obrow.FindControl("hdnFromNo_I");
        HiddenField hdnToNo_I = (HiddenField)obrow.FindControl("hdnToNo_I");
        HiddenField hdnLooseBundal = (HiddenField)obrow.FindControl("hdnLooseBundal");
        CheckBoxList chklist = (CheckBoxList)obrow.FindControl("chklist");
        if (hdnLooseBundal.Value == "" && chk.Checked)
        {
            for (int i = Convert.ToInt32(hdnFromNo_I.Value); i <= Convert.ToInt32(hdnToNo_I.Value); i++)
            {
                ListItem item = new ListItem();
                item.Value = i.ToString();
                item.Text = i.ToString();
                chklist.Items.Add(item);
            }


        }
        else
        { chklist.Items.Clear(); }

    }

    protected void grdDepoTransfer_RowDataBoundNew(object sender, GridViewRowEventArgs e)
    {
        try
        {
            CheckBoxList chklist = (CheckBoxList)e.Row.FindControl("chklist");
            HiddenField hdnLooseBundal = (HiddenField)e.Row.FindControl("hdnLooseBundal");
            if (hdnLooseBundal.Value != "")
            {
                string[] strarr = hdnLooseBundal.Value.Split(',');
                foreach (string s in strarr)
                {
                    ListItem item = new ListItem();
                    item.Value = s;
                    item.Text = s;
                    chklist.Items.Add(item);
                }

            }


        }
        catch { }

    }
    protected void grdDepoTransfer_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        try
        {
            string ProcValue = "";
            GridView dt = (GridView)e.Row.FindControl("datalist");
            HiddenField booktype = (HiddenField)e.Row.FindControl("booktype");

            ProcValue = ProcValue + "Call GetBundledataByWareHouseWithDate(" + Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField1")).Value);
            ProcValue = ProcValue + "," + ddldepoWarehouse.SelectedValue;
            //ProcValue = ProcValue + "," + ddlType.SelectedValue;
            if (booktype.Value == "योजना")
            {
                ProcValue = ProcValue + "," + 1;
            }
            else
            {

                ProcValue = ProcValue + "," + 2;
            }
            ProcValue = ProcValue + ",'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'";
            ProcValue = ProcValue + ")";
            obCommonFuction = new CommonFuction();
            dt.DataSource = obCommonFuction.FillDatasetByProc(ProcValue);
            dt.DataBind();
        }
        catch { }
        finally { }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
     //   DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter(" + Session["UserID"] + "," + DropDownList1.SelectedValue + ",'"+TextBox1.Text+"')");
        string txtVal=ddla.SelectedValue;
        string txtVal1=txta.Text;
        string user = Session["UserID"].ToString();
       
        if (ddla.SelectedValue == "1" || ddla.SelectedValue == "2")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + txtVal1.Trim() + "','"+txtFromdate.Text+"')");
        }
        if (ddla.SelectedValue == "3" )
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + txtFromdate.Text+ "','" + txtTodate.Text + "')");
        }
        if (ddla.SelectedValue == "4")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlTital.SelectedValue+ "','" + txtTodate.Text + "')");
        }
        if (ddla.SelectedValue == "5")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlMedium.SelectedValue + "','" + txtTodate.Text + "')");
        }
        if (ddla.SelectedValue == "6")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlbookType.SelectedValue + "','" + txtTodate.Text + "')");
        }
        grdDetails.DataSource = fillgrd.Tables[0];
        grdDetails.DataBind();
    }
    protected void ddla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddla.SelectedValue == "1" || ddla.SelectedValue == "2")
        { 
        txta.Visible=true ;
        ddlbookType.Visible=false ;
        ddlTital.Visible=false ;
        ddlMedium.Visible=false ;
        txtFromdate.Visible=false ;
        txtTodate.Visible=false ;
           
        }
        else if (ddla.SelectedValue == "3")
        { 
         txta.Visible=false ;
        ddlbookType.Visible=false ;
        ddlTital.Visible=false ;
        ddlMedium.Visible=false ;
        txtFromdate.Visible=true ;
        txtTodate.Visible=true ;
        }
        else if (ddla.SelectedValue=="4")
        {
         txta.Visible=false ;
        ddlbookType.Visible=false ;
        ddlTital.Visible = true;
        ddlMedium.Visible=false ;
        txtFromdate.Visible = false;
        txtTodate.Visible = false;
        }
        else if (ddla.SelectedValue == "5")
        {
            txta.Visible = false;
            ddlbookType.Visible = false;
            ddlTital.Visible = false;
            ddlMedium.Visible = true;
            txtFromdate.Visible = false;
            txtTodate.Visible = false;
        }
        else if (ddla.SelectedValue == "6")
        {
            txta.Visible = false;
            ddlbookType.Visible = true;
            ddlTital.Visible = false;
            ddlMedium.Visible = false;
            txtFromdate.Visible = false;
            txtTodate.Visible = false;
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("call UpdateBundalfromBarcodeDevice()");

    }
}
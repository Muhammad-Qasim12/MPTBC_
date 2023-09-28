using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;

public partial class Printing_CreateChallan : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    PRIN_ChallanDetails obPrinChallan = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration PriReg = null;
    APIProcedure objApi = new APIProcedure();
    int Totalbooks=0;
    int Totalbooky = 0;
  //  int Updprocess = 0;
//    int mcheck  ;
    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in GrdTitle.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");
            pnlData.ScrollBars = ScrollBars.Vertical;  

        }


    }

   // txtChangeA
    protected void txtChangeA(object sender, EventArgs e)
    {
        int mPtransid;
        TextBox bt = (TextBox)sender;
        GridViewRow grd = (GridViewRow)bt.NamingContainer;
        Panel pnlData = (Panel)grd.FindControl("DivR");
        //fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "none");
        HiddenField HDNTitleID_I = (HiddenField)grd.FindControl("HDNTitleID_I");
        TextBox txtBundleNo = (TextBox)grd.FindControl("txtBundleNo");
        TextBox txtToBundle = (TextBox)grd.FindControl("txtToBundle");
        TextBox txtPerBundleBook = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtFromBookNo = (TextBox)grd.FindControl("txtFromBookNo");
        GridView grdData = (GridView)grd.FindControl("grdData");
        TextBox txtPacketsSendAsPerChallan = (TextBox)grd.FindControl("txtPacketsSendAsPerChallan");
        TextBox txtTotalNoOfBooks = (TextBox)grd.FindControl("txtTotalNoOfBooks");
        TextBox txtPacketsSendAsPerChallanYoj = (TextBox)grd.FindControl("txtPacketsSendAsPerChallanYoj");
        TextBox txtTotalNoOfBooksYoj = (TextBox)grd.FindControl("txtTotalNoOfBooksYoj");
        DropDownList ddltype = (DropDownList)grd.FindControl("ddltype");
        TextBox txtBooksFromYoj = (TextBox)grd.FindControl("txtBooksFromYoj");
        TextBox txtBooksToYoj = (TextBox)grd.FindControl("txtBooksToYoj");
        TextBox txtToBookNo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBooksFrom = (TextBox)grd.FindControl("txtBooksFrom");
        TextBox txtBooksTo = (TextBox)grd.FindControl("txtBooksTo");
        // select @mnoofbundal ,@BundleNoFrom,@BundleNoTo,@mBooksPerBundle  ,  @mBookNumberFrom   ,@BookNumberTo  ;

       // DataSet ds = objApi.ByProcedure("GetBandalBook_on_noofBundal", new string[] { "bandalno", "mvitranno" }, new string[] { txtPacketsSendAsPerChallan.Text, DdlScheme1.SelectedValue }, "save");
        mPtransid = 0;
        if (Request.QueryString["Cid"] != null)
        {
            mPtransid = Convert.ToInt32(objApi.Decrypt(Request.QueryString["Cid"]).ToString());
        }
        DataSet ds = obCommonFuction.FillDatasetByProc("CALL GetBandalBook_on_noofBundalNew(" + txtPacketsSendAsPerChallan.Text + "," + DdlScheme1.SelectedValue + "," + mPtransid + ",'" + DdlACYear.SelectedValue 
            + "')");
        txtBooksTo.Text = ds.Tables[0].Rows[0]["@BundleNoFrom"].ToString();
        txtTotalNoOfBooks.Text = ds.Tables[0].Rows[0]["@BundleNoTo"].ToString();
        //txtBooksFrom.Text = ds.Tables[0].Rows[0]["@mBooksPerBundle"].ToString();
        txtPacketsSendAsPerChallanYoj.Text = ds.Tables[0].Rows[0]["@mBooksPerBundle"].ToString();
        txtTotalNoOfBooksYoj.Text = ds.Tables[0].Rows[0]["@mBookNumberFrom"].ToString();
        txtBooksFromYoj.Text = ds.Tables[0].Rows[0]["@BookNumberTo"].ToString();
    }
    protected void SaveData(object sender, EventArgs e)
    {

        //ajay
       
        Button bt = (Button)sender;
        GridViewRow grd = (GridViewRow)bt.NamingContainer;
        Panel pnlData = (Panel)grd.FindControl("DivR");
        //fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        HiddenField HDNTitleID_I = (HiddenField)grd.FindControl("HDNTitleID_I");
        TextBox txtBundleNo = (TextBox)grd.FindControl("txtBundleNo");
        TextBox txtToBundle = (TextBox)grd.FindControl("txtToBundle");
        TextBox txtPerBundleBook = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtFromBookNo = (TextBox)grd.FindControl("txtFromBookNo");
        GridView grdData = (GridView)grd.FindControl("grdData");
        TextBox txtPacketsSendAsPerChallan = (TextBox)grd.FindControl("txtPacketsSendAsPerChallan");
        TextBox txtTotalNoOfBooks = (TextBox)grd.FindControl("txtTotalNoOfBooks");
        TextBox txtPacketsSendAsPerChallanYoj = (TextBox)grd.FindControl("txtPacketsSendAsPerChallanYoj");
        TextBox txtTotalNoOfBooksYoj = (TextBox)grd.FindControl("txtTotalNoOfBooksYoj");
        DropDownList ddltype = (DropDownList)grd.FindControl("ddltype");
        TextBox txtBooksFromYoj = (TextBox)grd.FindControl("txtBooksFromYoj");
        TextBox txtBooksToYoj = (TextBox)grd.FindControl("txtBooksToYoj");
        TextBox txtToBookNo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBooksFrom = (TextBox)grd.FindControl("txtBooksFrom");
        TextBox txtBooksTo = (TextBox)grd.FindControl("txtBooksTo");

       
        IList<Bundlelist> oblist = new List<Bundlelist>();
        if (Session["d"] != null)
        {
            oblist = Session["d"] as List<Bundlelist>;
        }
        if (oblist == null)
        {
            oblist = new List<Bundlelist>();
        
        }
        if (txtBundleNo.Text != "" && txtToBundle.Text != "" && txtPerBundleBook.Text != "")
        {
            int count = 1;
            for (int i = Convert.ToInt32(txtBundleNo.Text); i <= Convert.ToInt32(txtToBundle.Text); i++)
            {
                int sd = 0;
                try
                {
                    var a = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleNo == i);
                    if (a.Count() > 0)
                    {
                        sd++;
                    }
                }
                catch { }
                if (sd > 0)
                {
                    var g = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleNo == i ).SingleOrDefault();

                    g.BundleNo = i;
                    g.BundleType = DdlClass2.SelectedItem.Text; 
                    g.FromBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * (count - 1)) ;
                    g.ToBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * count) - 1;


                }
                else
                {
                    Bundlelist obBundlelist = new Bundlelist();
                    obBundlelist.BundleNo = i;
                    obBundlelist.TitleID = Convert.ToInt32(HDNTitleID_I.Value);
                    obBundlelist.BundleType = DdlClass2.SelectedItem.Text; 
                    obBundlelist.FromBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * (count - 1)) ;
                    obBundlelist.ToBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * count) - 1;
                    oblist.Add(obBundlelist);
                }

                count++;
            }




        }
        var d=(from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value)&& f.BundleType=="सामान्य");
        var C = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleType == "योजना");
        txtPacketsSendAsPerChallan.Text =d.Count().ToString();
        
        foreach (var item in d)
        {
            Totalbooks = Totalbooks + (item.ToBook - item.FromBook+1);
        
        }
        foreach (var item in C)
        {
            Totalbooky = Totalbooky + (item.ToBook - item.FromBook + 1);

        }
       
        
        txtPacketsSendAsPerChallan.Text = C.Count().ToString();
        grdData.DataSource =  (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value));
        grdData.DataBind();
        Session["d"] = oblist;

        //if (ddltype.SelectedValue == "योजना")
        //{
        //    txtBooksFrom.Text = txtFromBookNo.Text;
        //    txtBooksTo.Text = txtToBookNo.Text;
        //}
        //else
        //{
        //    txtBooksFrom.Text = txtFromBookNo.Text;
        //    txtBooksTo.Text = txtToBookNo.Text;
        
        //}
        txtBooksFromYoj.Text = txtBundleNo.Text;
        txtTotalNoOfBooks.Text = txtToBundle.Text;
        txtBooksFrom.Text = txtPerBundleBook.Text;
        txtTotalNoOfBooksYoj.Text= txtFromBookNo.Text;
        txtBooksFromYoj.Text= txtToBookNo.Text;
        txtBooksTo.Text = txtBundleNo.Text;
        if (Totalbooky.ToString() != "0")
        { 
        txtPacketsSendAsPerChallanYoj.Text = Totalbooky.ToString();
        }
        else {
            txtPacketsSendAsPerChallanYoj.Text = Totalbooks.ToString();
        }
        
    }

    public class Bundlelist
    {
        public int TitleID { get; set; }
        public int BundleNo { get; set; }
        public int FromBook { get; set; }
        public int ToBook { get; set; }
        public string BundleType { get; set; }
    }


    protected void ClacluteBook(object sender, EventArgs e)
    {
        TextBox bt = (TextBox)sender;
        GridViewRow grd = (GridViewRow)bt.NamingContainer;
        Panel pnlData = (Panel)grd.FindControl("DivR");
        //fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        HiddenField HDNTitleID_I = (HiddenField)grd.FindControl("HDNTitleID_I");
        TextBox txtBundleNo = (TextBox)grd.FindControl("txtBundleNo");
        TextBox txtToBundle = (TextBox)grd.FindControl("txtToBundle");
        TextBox txtPerBundleBook = (TextBox)grd.FindControl("txtPerBundleBook");
        TextBox txtFromBookNo = (TextBox)grd.FindControl("txtFromBookNo");
        TextBox txtToBookNo = (TextBox)grd.FindControl("txtToBookNo");
        GridView grdData = (GridView)grd.FindControl("grdData");
        TextBox txtPacketsSendAsPerChallan = (TextBox)grd.FindControl("txtPacketsSendAsPerChallan");
        TextBox txtTotalNoOfBooks = (TextBox)grd.FindControl("txtTotalNoOfBooks");
        TextBox txtPacketsSendAsPerChallanYoj = (TextBox)grd.FindControl("txtPacketsSendAsPerChallanYoj");
        TextBox txtTotalNoOfBooksYoj = (TextBox)grd.FindControl("txtTotalNoOfBooksYoj");
        txtToBookNo.Text = Convert.ToString((((Convert.ToInt32(txtToBundle.Text) - Convert.ToInt32(txtBundleNo.Text)) + 1) * Convert.ToInt32(txtPerBundleBook.Text))-1 + Convert.ToInt32(txtFromBookNo.Text));

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        HideAllDiv();
       
        if (!Page.IsPostBack)
        {
            try
            {
                txtChalanDate.Text = System.DateTime.Now.ToShortDateString();
                txtUnloadingCharges.Text = System.DateTime.Now.ToShortDateString();
                Session["mcheck"] = "0"; 
                Session["challandetails"] = "False";
                
                btnsaveChallan.Text ="सेव करे / Save";
                btnsaveChallan.Enabled = true;
                Session["Updprocess"] = "0";
                PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
                PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
                DataSet ds = new DataSet();
                ds = PriReg.GetPrinterDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                }
                                
                DdlDepot.Enabled = true;
                messageDiv.InnerHtml = "  ";
                //DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM004_DistrictMasterSelect(0,0)");
                //DdlDistrict.DataValueField = "DistrictTrno_I";
                //DdlDistrict.DataTextField = "District_Name_Hindi_V";
                //DdlDistrict.DataBind();
                //DdlDistrict.Items.Insert(0, "--Select--");

                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                //DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
               // DdlACYear.Enabled = false;
                //obCommonFuction.GetFinYear();

                LblFyYear.Text = DdlACYear.SelectedItem.Text;
                LblFyYear.Text = "2022-2023";


              //  USP_ADM013_MediumMaster_Load


                ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
                ddlMedium.DataValueField = "MediumTrno_I";
                ddlMedium.DataTextField = "MediunNameHindi_V";
                ddlMedium.DataBind();
                ddlMedium.Items.Insert(0, "--Select--");

                DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
                DdlDepot.DataValueField = "DepoTrno_I";
                DdlDepot.DataTextField = "DepoName_V";
                DdlDepot.DataBind();
                DdlDepot.Items.Insert(0, "--Select--");

                DdlDepot0.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
                DdlDepot0.DataValueField = "DepoTrno_I";
                DdlDepot0.DataTextField = "DepoName_V";
                DdlDepot0.DataBind();
                DdlDepot0.Items.Insert(0, "--Select--");

                //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
                //DdlClass.DataValueField = "ClassTrno_I";
                //DdlClass.DataTextField = "Classdet_V";
                //DdlClass.DataBind();
                //DdlClass.Items.Insert(0, "--Select--");

                Random randam = new Random();
                int Random = randam.Next(100000, 100000000);
                txtChalanNo.Text = Convert.ToString(Random);
                txtChalanNo.Enabled = false;
                if (Request.QueryString["Cid"] != null)
                { LoadChallanDetails();
                loadgrid(6);
               // DdlACYear.SelectedValue = "2016-2017";
            
                   // Printorderanddistorder();
                
                // DdlScheme1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(3,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0);");
                //DdlScheme1.SelectedValue  = "TRNO";
                Session["Updprocess"] = "1";

                 //DdlScheme.SelectedValue  = "Printordertrno_i";
                
                }
            }
            catch { }
            finally { PriReg = null; }
        }
    }

    public void loadGroup()
    {
        obPrinChallan = new PRIN_ChallanDetails();
        DataSet ds = new DataSet();

        //lblDepotName.Text = "";
        //HdnDepo_I.Value ="0";

        try
        {
            obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]);
            if (Request.QueryString["Cid"] != null)
            {
                obPrinChallan.PriTransID = Convert.ToInt32(objApi.Decrypt(Request.QueryString["Cid"]).ToString() );
            }
            else { obPrinChallan.PriTransID = 0; }

            ds = obPrinChallan.PrinLoadGroupDetails();

            GrdTitle.DataSource = ds;
            GrdTitle.DataBind();

        }

        catch (Exception ex) { }
        finally { obPrinChallan = null; }
        //return ds;
    }


    public void loadBundalsend ()
    {
        obPrinChallan = new PRIN_ChallanDetails();
        DataSet ds = new DataSet();

        //lblDepotName.Text = "";
        //HdnDepo_I.Value ="0";

        try
        {
            obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]);
            if (Request.QueryString["Cid"] != null)
            {
                obPrinChallan.PriTransID = Convert.ToInt32(objApi.Decrypt(Request.QueryString["Cid"]).ToString());
            }
            else { obPrinChallan.PriTransID = 0; }

            ds = obPrinChallan.PrinLoadGroupDetails();

            GrdTitle.DataSource = ds;
            GrdTitle.DataBind();

        }

        catch (Exception ex) { }
        finally { obPrinChallan = null; }
        //return ds;
    }



    public void LoadChallanDetails()
    {
        obPrinChallan = new PRIN_ChallanDetails();

        DataSet ds = new DataSet();

        try
        {

            if (Request.QueryString["Cid"] != null)
            {
                obPrinChallan.PriTransID = Convert.ToInt32(objApi.Decrypt(Request.QueryString["Cid"]).ToString() );
            }
            else { obPrinChallan.PriTransID = 0; }
            obPrinChallan.Depo_I = Convert.ToInt32(Session["PrierID_I"]);
            
            ds = obPrinChallan.PrinLoadChallanDetails();


            if (ds.Tables[0].Rows.Count > 0)
            {
                DdlDepot.SelectedValue = ds.Tables[0].Rows[0]["Depo_I"].ToString();

                DdlDepot0.SelectedValue = ds.Tables[0].Rows[0]["Depo_I"].ToString();
                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);


                //loadgrid(2);
                DdlDepot.Enabled = false;
                // DdlClass.SelectedValue = ds.Tables[0].Rows[0]["classtrno_i"].ToString();

                txtChalanNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChalanNo"]);
                txtChalanDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChalanDate"]);
               // txtReceiptDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReceiptDate"]);
                //lblDepotName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Depo_I"]);
                //HdnDepo_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["Depo_I"]);


               // DdlScheme1.SelectedValue  = Convert.ToString(ds.Tables[0].Rows[0]["TitalID"]);
               //booktype 
                DdlClass2.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Booktype"]);
                //txtPacketsSendAsPerChallan.Text = Convert.ToString(ds.Tables[0].Rows[0]["PacketsSendAsPerChallan"]);
                //txtPacketsReceiveByCounting.Text = Convert.ToString(ds.Tables[0].Rows[0]["PacketsReceiveByCounting"]);
                //txtTotalNoBook.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalNoBook"]);
                //txtBookFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookFrom"]);
                //txtBookto.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookto"]);
                 FillTitle();
                 DdlClass1.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TitalID"]);
                 Printorderanddistorder();

                 DdlScheme1.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["VitranTrno"]);



                 DdlScheme.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Orderno"]);

                // DdlScheme.SelectedValue = "001";
                txtTruckCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["TruckCharges"]);
                txtUnloadingCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnloadingCharges"]);
                txtLoadingCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoadingCharges"]);
                txtOtherCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherCharges"]);
                txtRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                txtDriverName.Text = Convert.ToString(ds.Tables[0].Rows[0]["DriverName"]);
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]);
                obPrinChallan.Finyear = Convert.ToString(DdlACYear.SelectedValue);
                ds = obPrinChallan.PrinLoadGroupDetails();
                 
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();
            }


        }

        catch (Exception ex) { }

        finally { obPrinChallan = null; }



    }
   


    public int SaveChallan()
    {

        int i = 0;
        int k = 0;
        int chechstatus = 0;
        //foreach (GridViewRow gv in GrdTitle.Rows)
        //{
        //    CheckBox chk = (CheckBox)gv.FindControl("chkGroup");

        //    // int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
        //    if (chk.Checked == true)
        //    {

        //        chechstatus++;
        //    }
        //}
        //if (chechstatus == 0)
        //{
        //    messageDiv.Style.Add("display", "block");
        //    messageDiv.Attributes.Add("class", "form-message error");
        //    messageDiv.InnerHtml = " चालान में ग्रुप जोड़े ..";
        //}

        if (Session["challandetails"].ToString() == "False" && Session["Updprocess"] != "1" )
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Generate Bundal Nos');</script>");

        }
        else if (DdlDepot.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'डिपो सलेक्ट करे   ..";

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (DdlScheme.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'प्रिंट आर्डर सलेक्ट करे   ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (DdlScheme1.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'वितरण निर्देश सलेक्ट करे   ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (DdlClass1.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'पुस्तक सलेक्ट करे   ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }

        else
        {
            obPrinChallan = new PRIN_ChallanDetails();
            try
            {
                if (Request.QueryString["Cid"] != null)
                {
                    obPrinChallan.PriTransID = Convert.ToInt32(objApi.Decrypt(Request.QueryString["Cid"]).ToString() );
                }
                else { obPrinChallan.PriTransID = 0; }

                obPrinChallan.ChalanNo = Convert.ToString(txtChalanNo.Text);
                obPrinChallan.ChalanDate = Convert.ToDateTime(txtChalanDate.Text, cult);
               // obPrinChallan.ReceiptDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);

                //obPrinChallan.TitalID = Convert.ToInt32(ddlTitalID.SelectedValue);
                //printorder
                //obPrinChallan.TitalID = Convert.ToInt32(DdlScheme.SelectedValue  );
                //distribution order
                obPrinChallan.TitalID = Convert.ToInt32(DdlScheme1.SelectedValue);


                //obPrinChallan.PacketsSendAsPerChallan = Convert.ToInt32(txtPacketsSendAsPerChallan.Text);
                //obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(txtPacketsReceiveByCounting.Text);
                //obPrinChallan.TotalNoBook = Convert.ToInt32(txtTotalNoBook.Text);
                //obPrinChallan.BookFrom = Convert.ToInt32(txtBookFrom.Text);
                //obPrinChallan.Bookto = Convert.ToInt32(txtBookto.Text);


                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); 
                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue   ); 
                // obPrinChallan.Depo_I = Convert.ToInt32(HdnDepo_I.Value);
                obPrinChallan.TruckCharges = Convert.ToString(txtTruckCharges.Text);
                obPrinChallan.LoadingCharges = Convert.ToString(txtLoadingCharges.Text);
                obPrinChallan.ReceiptDate = Convert.ToDateTime( txtUnloadingCharges.Text, cult);
                // bilti date=receipt date
                obPrinChallan.OtherCharges = Convert.ToString(txtOtherCharges.Text);
                obPrinChallan.Remark = Convert.ToString(txtRemark.Text);
                //booktype
                obPrinChallan.Bookto = Convert.ToInt32(DdlClass2.SelectedValue);
                //send order no through grpid
                obPrinChallan.grpID_I = Convert.ToInt32(DdlScheme.SelectedValue); 
               
                i = obPrinChallan.SaveUpdateChallanDetails();
                
                //chalan detail save

                if (i > 0  )
                {


                    for (int Coun = 0; Coun < GrdTitle.Rows.Count; Coun++)
                    {
                        // CheckBox chkGroup = (CheckBox)GrdTitle.Rows[Coun].FindControl("chkGroup");
                        //if (chkGroup.Checked == true)
                        //{
                        obPrinChallan = new PRIN_ChallanDetails();

                        obPrinChallan.grpID_I = Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNGRPID_I")).Value);
                        Label lblTitleID_I = (Label)GrdTitle.Rows[Coun].FindControl("lblTitleID_I");

                        obPrinChallan.TitalID = Convert.ToInt32(lblTitleID_I.Text);//((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNTitleID_I")).Value);


                        obPrinChallan.Depo_I = Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNDepoID_I")).Value);
                        obPrinChallan.PriTransID = i;
                        obPrinChallan.ChallanTrno_I = 0;
                        //0 means delete all detail and reinsert
                        //Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNChallanTrno_I")).Value);

                        obPrinChallan.PacketsSendAsPerChallan = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsSendAsPerChallan")).Text);
                        // obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsReceiveByCounting")).Text);
                        obPrinChallan.TotalNoBook = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsSendAsPerChallanYoj")).Text);

                        obPrinChallan.BookFrom = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtTotalNoOfBooksYoj")).Text);
                        obPrinChallan.Bookto = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksFromYoj")).Text);

                        obPrinChallan.PacketsSendAsPerChallanYoj = Convert.ToString(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksQty")).Text);
                        // obPrinChallan.PacketsSendAsPerChallanYoj = 0;
                        // // obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsReceiveByCounting")).Text);
                        obPrinChallan.TotalNoOfBooksYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksFrom")).Text);
                        //obPrinChallan.TotalNoOfBooksYoj = 0;
                        obPrinChallan.BooksFromYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksTo")).Text);
                        // obPrinChallan.BooksFromYoj = 0;
                        obPrinChallan.BooksToYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtTotalNoOfBooks")).Text);
                        //  obPrinChallan.BooksToYoj = 0;
                        obPrinChallan.SaveChallanTitleDetails();
                      //  K++;
                        //}

                    }

                       }
                
                
                
                
                
                
                
                StockDetails obStockDetails = new StockDetails();
                StockDetailsChild obStockDetailsChild = new StockDetailsChild();
                foreach (GridViewRow grdroo in GrdTitle.Rows)
                {
                    try
                    {
                        GridView grdData = (GridView)grdroo.FindControl("grdData");

                         
                            foreach (GridViewRow grdro in grdData.Rows)
                            {
                                TextBox BundleNo = (TextBox)grdro.FindControl("BundleNo");
                                TextBox FromBook = (TextBox)grdro.FindControl("FromBook");
                                TextBox ToBook = (TextBox)grdro.FindControl("ToBook");
                                Label BundleType = (Label)grdro.FindControl("BundleType");
                                HiddenField hdnTitleid = (HiddenField)grdro.FindControl("hdnTitleid");


                                obStockDetails.Stock_ID_I = Convert.ToInt32(0);
                                obStockDetails.SubJectID_I = Convert.ToInt32(hdnTitleid.Value);
                                obStockDetails.Trans_I = 0;
                                //"योजना" 1
                                if (DdlClass2.SelectedValue.ToString() == "1")
                                //if (BundleType.Text == "योजना")
                                {
                                    obStockDetails.BookType_I = Convert.ToInt32(1);
                                }
                                else
                                {
                                    obStockDetails.BookType_I = Convert.ToInt32(2);
                                }
                                int Mid = obStockDetails.InsertUpdate();
                                obStockDetailsChild.BundleNo_I = Convert.ToInt32(BundleNo.Text);
                                obStockDetailsChild.FromNo_I = Convert.ToInt32(FromBook.Text);
                                obStockDetailsChild.ToNo_I = Convert.ToInt32(ToBook.Text);
                                obStockDetailsChild.BundleType_I = obStockDetails.BookType_I;
                                obStockDetailsChild.Trans_I = i;
                                obStockDetailsChild.RemaingLoose_V = "";
                                obStockDetailsChild.StockDetailsChildID_I = 0;
                                obStockDetailsChild.StockDetailsID_I = Mid;
                                int Stockdetid = obStockDetailsChild.InsertUpdate1();
                                
                                //CommonFuction obCommonFun = new CommonFuction();
                                //obCommonFun.FillDatasetByProc("call USP_PrinterStockUpdate(" + i + "," + Stockdetid + "," +  Session["mcheck"] + ")");
                                Session["mcheck"] = "0";
                            }
                         
                    }
                    catch { }
                }
            }

            catch (Exception ex) { }

            finally { obPrinChallan = null; }


        }
        return i;
    }

    protected void btnsaveChallan_Click(object sender, EventArgs e)
    {

      
        int i = 0;
         
        try
        {



            if ( btnsaveChallan.Text == "सेव करे / Save")
            {

             //   btnsaveChallan.Text = "Challan being saved";

                if (Request.QueryString["Cid"] != null)
                { 
                }
                else
                {
                    btnsaveChallan.Enabled = false;
                }
                
             
                i = SaveChallan();

         

                }
                else {
                    //update process
                    if (Session["challandetails"] != "True" && Session["Updprocess"] != "1")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Generate Bundle No.');</script>"); btnsaveChallan.Text = "बंडल क्रमांक बनाये बटन पर क्लिक करे ";
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check your Data');</script>"); btnsaveChallan.Enabled = true  ;
 
                    }
                }
            



            if ((i>0))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Challan Save Successfully');</script>");  
                Response.Redirect("PrinterChallanDetails.aspx");
                
            }

        }

        catch {  }
        finally { }
    }

    private void loadgrid(int mtype)
    {//mtype=1 all data , 2 calculated demand, 3 - depo wise 4-class wise 5 depo+class wise 


        try
        {
            obPrinChallan = new PRIN_ChallanDetails();
            DataSet ds = new DataSet();
            obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
            
            if (mtype == 1)
            {
               try {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = 0;
                //obj.intdepotrno_I = 0;
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                ds = obPrinChallan.PrinLoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();
               }
               catch { }
               finally { }
            }

            else if (mtype == 2)
            {
                try{

                //obj.dtype = 2;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                // obPrinChallan .intClasstrno_I = 0;
                obPrinChallan.Finyear = Convert.ToString(DdlACYear.SelectedValue);
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                obPrinChallan.Depo_I =  Convert.ToInt32(DdlDepot.SelectedValue);
                obPrinChallan.ClassID = Convert.ToInt32(DdlScheme1.SelectedValue);
                ds = obPrinChallan.PrinLoadGroupDetails();

                if (ds.Tables[0].Rows.Count > 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Your Data ');</script>");
                }
                else
                {
                    GrdTitle.DataSource = ds;
                    GrdTitle.DataBind();
                }
                }
                catch { }
                finally { }

            }

            else if (mtype == 3)
            {
                try
                {

                    //obj.dtype = 1;
                    //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                    //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue); ;
                    //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);
                    obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                    obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);
                    //  obPrinChallan.ClassID = Convert.ToInt32(DdlClass.SelectedValue);
                    ds = obPrinChallan.PrinLoadGroupDetails();
                    GrdTitle.DataSource = ds;
                    GrdTitle.DataBind();
                }
                catch { }
                finally { }

            }
            else if (mtype == 4)
            {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue);
                //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                ds = obPrinChallan.PrinLoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();
            }

            else if (mtype == 5)
            {
               try {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue);
                //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                ds = obPrinChallan.PrinLoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();
                    }
                catch { }
                finally { }

            }

            else if (mtype == 6)
            {
                try
                {


                    ds = obPrinChallan.PrinLoadChallanbundal(Convert.ToInt32(DdlScheme1.SelectedValue));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblSendBundal.Text = "&#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; / Total Bundal Sent :: " + ds.Tables[0].Rows[0]["bundalsend"].ToString()  ;
                    
                    
                     //obj.dtype = 1;
                    //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                    //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue);
                    //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);

                    // obPrinChallan .intClasstrno_I = 0;
                    obPrinChallan.Finyear = Convert.ToString(DdlACYear.SelectedValue);
                    obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                    obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);
                    obPrinChallan.ClassID = Convert.ToInt32(DdlScheme1.SelectedValue);
                    ds = obPrinChallan.PrinLoadGroupDetailssent();

                  
                        GrdTitleBundalSent.DataSource = ds;
                        GrdTitleBundalSent.DataBind();

                    }
                    
                    
              

                }
                catch { }
                finally { }

            }
        }
        catch { }
        finally { }

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["d"] = null;
        try
        {

            LblFyYear.Text = DdlACYear.SelectedItem.Text;
            DdlScheme1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(3,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0);");
            DdlScheme1.DataValueField = "TRNO";
            DdlScheme1.DataTextField = "VitranNo";
            DdlScheme1.DataBind();
            DdlScheme1.Items.Insert(0, "--Select--");
           

            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(4,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0 );");
            DdlScheme.DataValueField = "Printordertrno_i";
            DdlScheme.DataTextField = "printorder";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, "--Select--");
            DdlScheme.Items.Insert(1, "001");
        }
        catch { }
        finally { }
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillTitle();
        DdlDepot0.SelectedValue = DdlDepot.SelectedValue;
        
        //loadgrid(2);
        Session["d"] = null;
       // Printorderanddistorder();
        
        Session["d"] = null;
    }
    protected void DdlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
       // loadgrid(3);
      //  Session["d"] = null;
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        Printorderanddistorder();
        //loadgrid(2);
        Session["d"] = null;
        
      //  loadgrid(3);
       // Session["d"] = null;
    }
    //ajay
    protected void ShowDetail(object sender, EventArgs e)
    { // on click on bandal no generate kare
        Button bt = (Button)sender;
        GridViewRow grd = (GridViewRow)bt.NamingContainer;
         
        Panel pnlData = (Panel)grd.FindControl("DivR");
        //fadeDiv.Style.Add("display", "block");
        pnlData.Style.Add("display", "block");
        
         
        HiddenField HDNTitleID_I = (HiddenField)grd.FindControl("HDNTitleID_I");
        TextBox txtBundleNo = (TextBox)grd.FindControl("txtBooksTo");
        TextBox txtToBundle = (TextBox)grd.FindControl("txtTotalNoOfBooks");
        TextBox txtPerBundleBook = (TextBox)grd.FindControl("txtBooksFrom");
        TextBox txtFromBookNo = (TextBox)grd.FindControl("txtTotalNoOfBooksYoj");
        GridView grdData = (GridView)grd.FindControl("grdData");
        TextBox txtPacketsSendAsPerChallan = (TextBox)grd.FindControl("txtPacketsSendAsPerChallan");
        TextBox txtTotalNoOfBooks = (TextBox)grd.FindControl("txtTotalNoOfBooks");
        TextBox txtPacketsSendAsPerChallanYoj = (TextBox)grd.FindControl("txtPacketsSendAsPerChallanYoj");
        TextBox txtTotalNoOfBooksYoj = (TextBox)grd.FindControl("txtTotalNoOfBooksYoj");
        DropDownList ddltype = (DropDownList)grd.FindControl("ddltype");
        TextBox txtBooksFromYoj = (TextBox)grd.FindControl("txtBooksFromYoj");
        TextBox txtBooksToYoj = (TextBox)grd.FindControl("txtBooksToYoj");
        TextBox txtToBookNo = (TextBox)grd.FindControl("txtToBookNo");
        TextBox txtBooksFrom = (TextBox)grd.FindControl("txtBooksFrom");
        TextBox txtBooksTo = (TextBox)grd.FindControl("txtBooksTo");


        IList<Bundlelist> oblist = new List<Bundlelist>();
        
        //if (Session["d"] != null)
        //{
        //    oblist = Session["d"] as List<Bundlelist>;
        //}
        if (oblist == null)
        {
            oblist = new List<Bundlelist>();

        }
        if (txtBundleNo.Text != "" && txtToBundle.Text != "" && txtPerBundleBook.Text != "")
        {
            int count = 1;
            for (int i = Convert.ToInt32(txtBundleNo.Text); i <= Convert.ToInt32(txtToBundle.Text); i++)
            {
                int sd = 0;
                try
                {
                    var a = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleNo == i);
                    if (a.Count() > 0)
                    {
                        sd++;
                    }
                }
                catch { }
                if (sd > 0)
                {
                    var g = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleNo == i).SingleOrDefault();

                    g.BundleNo = i;
                    g.BundleType = DdlClass2.SelectedItem.Text;
                    g.FromBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * (count - 1));
                    g.ToBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * count) - 1;


                }
                else
                {
                    Bundlelist obBundlelist = new Bundlelist();
                    obBundlelist.BundleNo = i;
                    obBundlelist.TitleID = Convert.ToInt32(HDNTitleID_I.Value);
                    obBundlelist.BundleType = DdlClass2.SelectedItem.Text;
                    obBundlelist.FromBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * (count - 1));
                    obBundlelist.ToBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * count) - 1;
                    oblist.Add(obBundlelist);
                }

                count++;
            }




        }
        var d = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleType == "सामान्य");
        var C = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value) && f.BundleType == "योजना");
       //salah
        // txtPacketsSendAsPerChallan.Text = d.Count().ToString();

        foreach (var item in d)
        {
            Totalbooks = Totalbooks + (item.ToBook - item.FromBook + 1);

        }
        foreach (var item in C)
        {
            Totalbooky = Totalbooky + (item.ToBook - item.FromBook + 1);

        }

        //salah popup bundel no
        // txtPacketsSendAsPerChallan.Text = C.Count().ToString();
        grdData.DataSource = (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value));
        grdData.DataBind();
        if (grdData.Rows.Count > 0)
        {
            Session["challandetails"]="True";
        }
        else
        {
            Session["challandetails"] = "False";
        }


        Session["d"] = oblist;

        //if (ddltype.SelectedValue == "योजना")
        //{
        //    txtBooksFrom.Text = txtFromBookNo.Text;
        //    txtBooksTo.Text = txtToBookNo.Text;
        //}
        //else
        //{
        //    txtBooksFrom.Text = txtFromBookNo.Text;
        //    txtBooksTo.Text = txtToBookNo.Text;

        //}
   
        //salah
        //txtBooksFromYoj.Text = txtBundleNo.Text;
        //txtTotalNoOfBooks.Text = txtToBundle.Text;
        //txtBooksFrom.Text = txtPerBundleBook.Text;
        //txtTotalNoOfBooksYoj.Text = txtFromBookNo.Text;
        //txtBooksFromYoj.Text = txtToBookNo.Text;
        //txtBooksTo.Text = txtBundleNo.Text;
        //if (Totalbooky.ToString() != "0")
        //{
        //    txtPacketsSendAsPerChallanYoj.Text = Totalbooky.ToString();
        //}
        //else
        //{
        //    txtPacketsSendAsPerChallanYoj.Text = Totalbooks.ToString();
        //}

        btnsaveChallan.Enabled = true;
        btnsaveChallan.Text = "सेव करे / Save";
        Session["mcheck"] = "1"; 
       
    }
    protected void GrdTitle_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        try
        {
            //0 means delete all detail and reinsert
            int chkchallan = Convert.ToInt32(((HiddenField)e.Row.FindControl("HDNChallanTrno_I")).Value);
            CheckBox chkGroup = (CheckBox)e.Row.FindControl("chkGroup");
            if (chkchallan == 0)
            {
                chkGroup.Checked = true;
            }
            else
            {
                chkGroup.Checked = true;
            }
        }
        catch { }
        finally { }
    }




    protected void btnsaveChallan0_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterChallanDetails.aspx");
    }
    protected void GrdTitle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DdlScheme1_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadgrid(2);
        loadgrid(6); // send bundal
        DataSet dt = obCommonFuction.FillDatasetByProc("call USP_GetVitranN("+DdlScheme1.SelectedValue+", "+DdlDepot.SelectedValue+")");
        if (dt.Tables[0].Rows[0]["GroupID"].ToString() == "47" || dt.Tables[0].Rows[0]["GroupID"].ToString() == "55")
        {
            DdlDepot0.SelectedValue = dt.Tables[1].Rows[0]["DepoTrno_I"].ToString();
        }
        else
        {
            DdlDepot0.Enabled = false;
        }
        
       
        
    }
    protected void DdlClass2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //yojna/samanay
            FillTitle(); 
        }
        catch { }
        finally { }
    }

    private void FillTitle()
    {
        try
        {
             

            DdlClass1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(2,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0,'" + DdlClass2.SelectedValue + "','0' );");
            DdlClass1.DataValueField = "Titleid";
            DdlClass1.DataTextField = "TitleHindi_V";
            DdlClass1.DataBind();
            DdlClass1.Items.Insert(0, "--Select--");

           
        }
        catch { }
        finally { }
    }

    private void Printorderanddistorder()
    {
        try
        {

            LblFyYear.Text = DdlACYear.SelectedItem.Text;
            //DdlClass1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(2,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0,'" + DdlClass2.SelectedValue + "','0' );");

            DdlScheme1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(3,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0,'" + DdlClass2.SelectedValue + "','" + DdlClass1.SelectedValue + "' );");
            // DdlScheme1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(3,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0);");
            DdlScheme1.DataValueField = "TRNO";
            DdlScheme1.DataTextField = "VitranNo";
            DdlScheme1.DataBind();
            DdlScheme1.Items.Insert(0, "--Select--");


            //DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(4,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0 );");
            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI009_Fillddl_withyear(4,'" + DdlACYear.SelectedValue + "'," + Convert.ToInt32(Session["PrierID_I"]) + "," + DdlDepot.SelectedValue + ",0,'" + DdlClass2.SelectedValue + "','" + DdlClass1.SelectedValue + "' );");
            DdlScheme.DataValueField = "Printordertrno_i";
            DdlScheme.DataTextField = "printorder";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, "--Select--");
            DdlScheme.Items.Insert(1, "1");
            
        }
        catch { }
        finally { }
      
    }

    //chalan class
    //public class PRIN_ChallanDetails  
    //{
    //    // start

    //    int _PriTransID,
    //        _TitalID,
    //        _BookFrom,
    //        _Bookto,
    //        _PerBandalBook,
    //        _TotalNoBook,
    //        _TotalNoBandal,
    //        _User_ID,
    //        _Depo_I,
    //        _PacketsSendAsPerChallan,
    //        _PacketsReceiveByCounting,
    //        _grpID_I,
    //        _ChallanTrno_I, _TotalNoOfBooksYoj, _BooksFromYoj, _BooksToYoj, _ClassID, _WorkorderId;
    //    string _Finyear, _PacketsSendAsPerChallanYoj;


    //    string _Remark, _ChalanNo;

    //    string _TruckCharges, _LoadingCharges, _OtherCharges;
    //    DateTime _ChalanDate, _ReceiptDate, _UnloadingCharges;
    //    public string Finyear { get { return _Finyear; } set { _Finyear = value; } }
    //    public int ClassID { get { return _ClassID; } set { _ClassID = value; } }
    //    public int PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
    //    public int WorkorderId { get { return _WorkorderId; } set { _WorkorderId = value; } }
    //    public string ChalanNo { get { return _ChalanNo; } set { _ChalanNo = value; } }
    //    public DateTime ChalanDate { get { return _ChalanDate; } set { _ChalanDate = value; } }
    //    public int TitalID { get { return _TitalID; } set { _TitalID = value; } }
    //    public int BookFrom { get { return _BookFrom; } set { _BookFrom = value; } }
    //    public int Bookto { get { return _Bookto; } set { _Bookto = value; } }
    //    public int PerBandalBook { get { return _PerBandalBook; } set { _PerBandalBook = value; } }
    //    public int TotalNoBook { get { return _TotalNoBook; } set { _TotalNoBook = value; } }
    //    public int TotalNoBandal { get { return _TotalNoBandal; } set { _TotalNoBandal = value; } }

    //    public int User_ID { get { return _User_ID; } set { _User_ID = value; } }

    //    public int Depo_I { get { return _Depo_I; } set { _Depo_I = value; } }

    //    public int PacketsSendAsPerChallan { get { return _PacketsSendAsPerChallan; } set { _PacketsSendAsPerChallan = value; } }
    //    public int PacketsReceiveByCounting { get { return _PacketsReceiveByCounting; } set { _PacketsReceiveByCounting = value; } }
    //    public int grpID_I { get { return _grpID_I; } set { _grpID_I = value; } }
    //    public int ChallanTrno_I { get { return _ChallanTrno_I; } set { _ChallanTrno_I = value; } }


    //    public DateTime ReceiptDate { get { return _ReceiptDate; } set { _ReceiptDate = value; } }
    //    public string TruckCharges { get { return _TruckCharges; } set { _TruckCharges = value; } }
    //    public DateTime UnloadingCharges { get { return _UnloadingCharges; } set { _UnloadingCharges = value; } }
    //    public string LoadingCharges { get { return _LoadingCharges; } set { _LoadingCharges = value; } }
    //    public string OtherCharges { get { return _OtherCharges; } set { _OtherCharges = value; } }
    //    public string Remark { get { return _Remark; } set { _Remark = value; } }

    //    public string PacketsSendAsPerChallanYoj { get { return _PacketsSendAsPerChallanYoj; } set { _PacketsSendAsPerChallanYoj = value; } }
    //    public int TotalNoOfBooksYoj { get { return _TotalNoOfBooksYoj; } set { _TotalNoOfBooksYoj = value; } }
    //    public int BooksFromYoj { get { return _BooksFromYoj; } set { _BooksFromYoj = value; } }
    //    public int BooksToYoj { get { return _BooksToYoj; } set { _BooksToYoj = value; } }


    //    public DataSet LoadChallanDetails()
    //    {
    //        DBAccess obDbAccess = new DBAccess();
    //        DataSet ds = new DataSet();

    //        try
    //        {
    //            obDbAccess.execute("USP_PRIN001_ChallanDetailsLoad", DBAccess.SQLType.IS_PROC);
    //            obDbAccess.addParam("mPriTransID", PriTransID);
    //            obDbAccess.addParam("mprinterid", Depo_I);
    //            ds = obDbAccess.records();
    //        }

    //        catch (Exception ex) { }
    //        finally { obDbAccess = null; }
    //        return ds;
    //    }
    //    public DataSet PrinLoadChallanDetails()
    //    {
    //        DBAccess obDbAccess = new DBAccess();
    //        DataSet ds = new DataSet();

    //        try
    //        {
    //            obDbAccess.execute("USP_PRIN0011_ChallanDetailsLoad", DBAccess.SQLType.IS_PROC);
    //            obDbAccess.addParam("mPriTransID", PriTransID);
    //            obDbAccess.addParam("mprinterid", Depo_I);
    //            ds = obDbAccess.records();
    //        }

    //        catch (Exception ex) { }
    //        finally { obDbAccess = null; }
    //        return ds;
    //    }

    //    public int SaveUpdateChallanDetails()
    //    {
    //        DBAccess obDbAccess = new DBAccess();
    //        int i = 0;

    //        try
    //        {
    //            obDbAccess.execute("USP_PRIN001_ChallanDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
    //            obDbAccess.addParam("mPriTransID", PriTransID);

    //            obDbAccess.addParam("mChalanNo", ChalanNo);
    //            obDbAccess.addParam("mChalanDate", ChalanDate);
    //            obDbAccess.addParam("mReceiptDate", ReceiptDate);
    //            obDbAccess.addParam("mTitalID", TitalID);
    //            //obDbAccess.addParam("mPacketsSendAsPerChallan", PacketsSendAsPerChallan);
    //            //obDbAccess.addParam("mPacketsReceiveByCounting", PacketsReceiveByCounting);
    //            //obDbAccess.addParam("mTotalNoBook", TotalNoBook);


    //            //obDbAccess.addParam("mBookFrom", BookFrom);
    //            //obDbAccess.addParam("mBookto", Bookto);
    //            // obDbAccess.addParam("mPerBandalBook", PerBandalBook);

    //            //obDbAccess.addParam("mTotalNoBandal", TotalNoBandal);



    //            obDbAccess.addParam("mUser_ID", User_ID);

    //            obDbAccess.addParam("mDepo_I", Depo_I);

    //            obDbAccess.addParam("mTruckCharges", TruckCharges);
    //            obDbAccess.addParam("mUnloadingCharges", ReceiptDate);
    //            obDbAccess.addParam("mLoadingCharges", LoadingCharges);
    //            obDbAccess.addParam("mOtherCharges", OtherCharges);
    //            obDbAccess.addParam("mRemark", Remark);
    //            obDbAccess.addParam("mBooktype", Bookto);
    //            obDbAccess.addParam("mOrderno", grpID_I);
    //            i = Convert.ToInt32(obDbAccess.executeMyScalar());
    //        }

    //        catch (Exception ex) { }
    //        finally { obDbAccess = null; }



    //        return i;
    //    }


    //    // function lo load Groups ,depot, title
    //    public DataSet LoadGroupDetails()
    //    {
    //        DBAccess obDbAccess = new DBAccess();
    //        DataSet ds = new DataSet();

    //        try
    //        {
    //            obDbAccess.execute("USP_PRI001_GroupDetailsForChallan", DBAccess.SQLType.IS_PROC);
    //            obDbAccess.addParam("mPrinterid_I", User_ID);
    //            obDbAccess.addParam("mpritransid", PriTransID);
    //            obDbAccess.addParam("mdepottrno", Depo_I);
    //            obDbAccess.addParam("mclassID", ClassID);
    //            obDbAccess.addParam("mAcyear", Finyear);

    //            ds = obDbAccess.records();
    //        }

    //        catch (Exception ex) { }
    //        finally { obDbAccess = null; }
    //        return ds;
    //    }

    //    public DataSet PrinLoadGroupDetails()
    //    {
    //        DBAccess obDbAccess = new DBAccess();
    //        DataSet ds = new DataSet();

    //        try
    //        {

    //            obDbAccess.execute("USP_PRI001_GroupDetailsForChallan", DBAccess.SQLType.IS_PROC);
    //            obDbAccess.addParam("mPrinterid_I", User_ID);
    //            obDbAccess.addParam("mpritransid", PriTransID);
    //            obDbAccess.addParam("mdepottrno", Depo_I);
    //            obDbAccess.addParam("mclassID", ClassID);
    //            obDbAccess.addParam("mAcyear", Finyear);

    //            ds = obDbAccess.records();
    //        }

    //        catch (Exception ex) { }
    //        finally { obDbAccess = null; }
    //        return ds;
    //    }

    //    public int SaveChallanTitleDetails()
    //    {
    //        DBAccess obDbAccess = new DBAccess();

    //        int i = 0;
    //        try
    //        {
    //            obDbAccess.execute("USP_Prin001_ChallanTitleDetailsSave", DBAccess.SQLType.IS_PROC);
    //            obDbAccess.addParam("mGRPID_I", grpID_I);
    //            obDbAccess.addParam("mTitleID_I", TitalID);
    //            obDbAccess.addParam("mDepoID_I", Depo_I);
    //            obDbAccess.addParam("mPriTransID", PriTransID);
    //            obDbAccess.addParam("mChallanTrno_I", ChallanTrno_I);

    //            obDbAccess.addParam("mPacketsSendAsPerChallan", PacketsSendAsPerChallan);
    //            obDbAccess.addParam("mPacketsReceiveByCounting", PacketsReceiveByCounting);
    //            obDbAccess.addParam("mTotalNoOfBooks", TotalNoBook);


    //            obDbAccess.addParam("mBooksFrom", BookFrom);
    //            obDbAccess.addParam("mBooksTo", Bookto);

    //            obDbAccess.addParam("mPacketsSendAsPerChallanYoj", PacketsSendAsPerChallanYoj);

    //            obDbAccess.addParam("mTotalNoOfBooksYoj", TotalNoOfBooksYoj);


    //            obDbAccess.addParam("mBooksFromYoj", BooksFromYoj);
    //            obDbAccess.addParam("mBooksToYoj", BooksToYoj);

    //            obDbAccess.addParam("mWorkoderid", WorkorderId);

    //            i = obDbAccess.executeMyQuery();
    //        }

    //        catch (Exception ex) { }
    //        finally { obDbAccess = null; }


    //        return i;

    //    }


        

    //    // End 
    //}



    protected void Button2_Click(object sender, EventArgs e)
    {
        int i = 0;
        int k = 0;
        int chechstatus = 0;
        string NoofBundle = "NA";

        //if (Session["challandetails"].ToString() == "False" && Session["Updprocess"] != "1")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Generate Bundal Nos');</script>");

        //}
        //else


        if (DdlDepot.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'डिपो सलेक्ट करे   ..";

            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (DdlScheme.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'प्रिंट आर्डर सलेक्ट करे   ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (DdlScheme1.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'वितरण निर्देश सलेक्ट करे   ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (DdlClass1.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'पुस्तक सलेक्ट करे   ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (txtChalanDate.Text == "")
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'चालान दिनांक डाले  ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (txtTruckCharges.Text == "")
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "बिल्टी नंबर डाले  ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (txtUnloadingCharges.Text == "")
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "बिल्टी दिनांक डाले  ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (txtLoadingCharges.Text == "")
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "ट्रक नंबर डाले  ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (txtOtherCharges.Text == "")
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "ड्राईवर मोबाइल नंबर डाले  ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        else if (txtDriverName.Text == "")
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "ड्राईवर का नाम  डाले  ..";
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>");
        }
        //
       
        else
        {
            obPrinChallan = new PRIN_ChallanDetails();
            try
            {
                if (Request.QueryString["Cid"] != null)
                {
                    obPrinChallan.PriTransID = Convert.ToInt32(objApi.Decrypt(Request.QueryString["Cid"]).ToString());
                }
                else { obPrinChallan.PriTransID = 0; }

                obPrinChallan.ChalanNo = Convert.ToString(txtChalanNo.Text);
                obPrinChallan.ChalanDate = Convert.ToDateTime(txtChalanDate.Text, cult);
                // obPrinChallan.ReceiptDate = Convert.ToDateTime(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);

                //obPrinChallan.TitalID = Convert.ToInt32(ddlTitalID.SelectedValue);
                //printorder
                //obPrinChallan.TitalID = Convert.ToInt32(DdlScheme.SelectedValue  );
                //distribution order
                obPrinChallan.TitalID = Convert.ToInt32(DdlScheme1.SelectedValue);


                //obPrinChallan.PacketsSendAsPerChallan = Convert.ToInt32(txtPacketsSendAsPerChallan.Text);
                //obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(txtPacketsReceiveByCounting.Text);
                //obPrinChallan.TotalNoBook = Convert.ToInt32(txtTotalNoBook.Text);
                //obPrinChallan.BookFrom = Convert.ToInt32(txtBookFrom.Text);
                //obPrinChallan.Bookto = Convert.ToInt32(txtBookto.Text);


                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]);
                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot0.SelectedValue);
                // obPrinChallan.Depo_I = Convert.ToInt32(HdnDepo_I.Value);
                obPrinChallan.TruckCharges = Convert.ToString(txtTruckCharges.Text);
                obPrinChallan.LoadingCharges = Convert.ToString(txtLoadingCharges.Text);
                obPrinChallan.ReceiptDate = Convert.ToDateTime(txtUnloadingCharges.Text, cult);
                // bilti date=receipt date
                obPrinChallan.OtherCharges = Convert.ToString(txtOtherCharges.Text);
                obPrinChallan.Remark = Convert.ToString(txtRemark.Text);
                //booktype
                obPrinChallan.Bookto = Convert.ToInt32(DdlClass2.SelectedValue);
                //send order no through grpid
                obPrinChallan.grpID_I = Convert.ToInt32(DdlScheme.SelectedValue);

                if (Convert.ToInt32(((TextBox)GrdTitle.Rows[0].FindControl("txtTotalNoOfBooksYoj")).Text) > 0)
                {

                i = obPrinChallan.SaveUpdateChallanDetails();

                }
                else
                {
                i=0;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check your data');</script>");
                }

                //chalan detail save

                if (i > 0)
                {
                    try
                    {
                        CommonFuction comm = new CommonFuction();
                        comm.FillDatasetByProc("call UpdatePrinterChallanDriverName(" + i + ",'" + txtDriverName.Text + "','" + DdlACYear.SelectedItem.Text + "',"+DdlDepot.SelectedValue+")");

                    }
                    catch { }
                    for (int Coun = 0; Coun < GrdTitle.Rows.Count; Coun++)
                    {
                        // CheckBox chkGroup = (CheckBox)GrdTitle.Rows[Coun].FindControl("chkGroup");
                        //if (chkGroup.Checked == true)
                        //{
                        obPrinChallan = new PRIN_ChallanDetails();

                        obPrinChallan.grpID_I = Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNGRPID_I")).Value);
                        Label lblTitleID_I = (Label)GrdTitle.Rows[Coun].FindControl("lblTitleID_I");

                        obPrinChallan.TitalID = Convert.ToInt32(lblTitleID_I.Text);//((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNTitleID_I")).Value);


                        obPrinChallan.Depo_I =Convert.ToInt32( DdlDepot0.SelectedValue);// Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNDepoID_I")).Value);
                        obPrinChallan.PriTransID = i;
                        obPrinChallan.ChallanTrno_I = 0;
                        //0 means delete all detail and reinsert
                        //Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNChallanTrno_I")).Value);

                        obPrinChallan.PacketsSendAsPerChallan = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsSendAsPerChallan")).Text);
                        // obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsReceiveByCounting")).Text);
                        obPrinChallan.TotalNoBook = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsSendAsPerChallanYoj")).Text);

                        obPrinChallan.BookFrom = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtTotalNoOfBooksYoj")).Text);
                        obPrinChallan.Bookto = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksFromYoj")).Text);

                        obPrinChallan.PacketsSendAsPerChallanYoj = Convert.ToString(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksQty")).Text);
                        // obPrinChallan.PacketsSendAsPerChallanYoj = 0;
                        // // obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsReceiveByCounting")).Text);
                        obPrinChallan.TotalNoOfBooksYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksFrom")).Text);
                        //obPrinChallan.TotalNoOfBooksYoj = 0;cnet
                        obPrinChallan.BooksFromYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksTo")).Text);
                        // obPrinChallan.BooksFromYoj = 0;
                        obPrinChallan.BooksToYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtTotalNoOfBooks")).Text);
                        //  obPrinChallan.BooksToYoj = 0;
                        obPrinChallan.SaveChallanTitleDetails();
                        //  K++;
                        //}

                    }
                    CommonFuction obCommonFun = new CommonFuction();
                    obCommonFun.FillDatasetByProc("call Fn_CursorStockinsert(1," + obPrinChallan.TitalID + "," + Convert.ToInt32(DdlClass2.SelectedValue) + "," + obPrinChallan.PacketsSendAsPerChallan + "," + obPrinChallan.BooksFromYoj + "," + obPrinChallan.TotalNoOfBooksYoj + "," + obPrinChallan.BookFrom + "," + i + ")");

                    try
                    {
                        MailHelper objSendSms = new MailHelper();
                        string Msg = "", DepotMgrMMobile = "";
                        //Usp_Get_SMS_MobileNo
                        DataSet ds = new DataSet();
                        ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
                        Msg = "Name of Book: " + DdlClass1.SelectedItem.Text.Trim() + ", No. Of Buldals: " + obPrinChallan.PacketsSendAsPerChallan + ", Date of Dispatching: " + txtChalanDate.Text + " " + ", Vehicle No.: " + txtLoadingCharges.Text.Trim() + ", Driver Contact No.: " + txtOtherCharges.Text.Trim() + ", Depot Name: " + DdlDepot.SelectedItem.Text.Trim();
                        foreach (DataRow Dr in ds.Tables[0].Rows)
                        {
                            //if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Distribution")
                            //{
                            //    objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                            //}
                            if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
                            {
                                objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                            }

                            if (Dr["Flag"].ToString() == "User" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Depot Manager")
                            {
                                try
                                {
                                    //USP_Dispatch_GetMobileNo
                                    ds = new DataSet();
                                    ds = obCommonFuction.FillDatasetByProc("Call USP_Dispatch_GetMobileNo(0,'" + DdlDepot.SelectedValue + "')");
                                    DepotMgrMMobile = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                                }
                                catch { }
                                objSendSms.sendMessage(DepotMgrMMobile, Msg);
                            }
                        }
                    }
                    catch { }

                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Challan Save Successfully');</script>");
                    Response.Redirect("PrinterChallanDetails.aspx");
                }
                else
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Challan No Duplicate ');</script>");
                }

            


               


                
            }

            catch (Exception ex) { }

            finally { obPrinChallan = null; }


        }
       
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
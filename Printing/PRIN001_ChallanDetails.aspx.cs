using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;

public partial class Printing_PRIN001_ChallanDetails : System.Web.UI.Page
{
    PRIN_ChallanDetails obPrinChallan = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration PriReg = null;


    public void HideAllDiv()
    {
        foreach (GridViewRow grdrow in GrdTitle.Rows)
        {
            Panel pnlData = (Panel)grdrow.FindControl("DivR");
            pnlData.Style.Add("display", "none");

        }


    }
    protected void SaveData(object sender, EventArgs e)
    {
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
                    g.BundleType = ddltype.SelectedValue;
                    g.FromBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * (count - 1)) ;
                    g.ToBook = (Convert.ToInt32(txtFromBookNo.Text) + Convert.ToInt32(txtPerBundleBook.Text) * count) - 1;


                }
                else
                {
                    Bundlelist obBundlelist = new Bundlelist();
                    obBundlelist.BundleNo = i;
                    obBundlelist.TitleID = Convert.ToInt32(HDNTitleID_I.Value);
                    obBundlelist.BundleType = ddltype.SelectedValue;
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
        int Totalbooks =0;
        int Totalbooky = 0;
        foreach (var item in d)
        {
            Totalbooks = Totalbooks + (item.ToBook - item.FromBook+1);
        
        }
        foreach (var item in C)
        {
            Totalbooky = Totalbooky + (item.ToBook - item.FromBook + 1);

        }
        txtTotalNoOfBooksYoj.Text = Totalbooky.ToString();
        txtTotalNoOfBooks.Text = Totalbooks.ToString();
        txtPacketsSendAsPerChallanYoj.Text = C.Count().ToString();
        grdData.DataSource =  (from s in oblist select s).Where(f => f.TitleID == Convert.ToInt32(HDNTitleID_I.Value));
        grdData.DataBind();
        Session["d"] = oblist;
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
                Session["d"] = null;
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
                CommonFuction obCommonFuction = new CommonFuction();
                //DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM004_DistrictMasterSelect(0,0)");
                //DdlDistrict.DataValueField = "DistrictTrno_I";
                //DdlDistrict.DataTextField = "District_Name_Hindi_V";
                //DdlDistrict.DataBind();
                //DdlDistrict.Items.Insert(0, "--Select--");

                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

                LblFyYear.Text = DdlACYear.SelectedItem.Text;


                DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM010_DepomasterLoad(0)");
                DdlDepot.DataValueField = "DepoTrno_I";
                DdlDepot.DataTextField = "DepoName_V";
                DdlDepot.DataBind();
                DdlDepot.Items.Insert(0, "--All--");

                DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
                DdlClass.DataValueField = "ClassTrno_I";
                DdlClass.DataTextField = "Classdet_V";
                DdlClass.DataBind();
                DdlClass.Items.Insert(0, "--Select--");

                DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM017_SchemeMasterLoad()");
                DdlScheme.DataValueField = "SchemeId";
                DdlScheme.DataTextField = "SchemeName_Hindi";
                DdlScheme.DataBind();
                DdlScheme.Items.Insert(0, "--All--");





                if (Request.QueryString["Cid"] != null)
                { LoadChallanDetails(); }
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
                obPrinChallan.PriTransID = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else { obPrinChallan.PriTransID = 0; }

            ds = obPrinChallan.LoadGroupDetails();

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
                obPrinChallan.PriTransID = Convert.ToInt32(Request.QueryString["Cid"]);


            }
            else { obPrinChallan.PriTransID = 0; }

            ds = obPrinChallan.LoadChallanDetails();

            if (ds.Tables[0].Rows.Count > 0)
            {
                DdlDepot.SelectedValue = ds.Tables[0].Rows[0]["Depo_I"].ToString();

                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);


                //loadgrid(2);
                DdlDepot.Enabled = false;
                // DdlClass.SelectedValue = ds.Tables[0].Rows[0]["classtrno_i"].ToString();

                txtChalanNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChalanNo"]);
                txtChalanDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChalanDate"]);
                txtReceiptDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReceiptDate"]);
                //lblDepotName.Text = Convert.ToString(ds.Tables[0].Rows[0]["Depo_I"]);
                //HdnDepo_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["Depo_I"]);


                //ddlTitalID.SelectedValue  = Convert.ToString(ds.Tables[0].Rows[0]["TitalID"]);

                //txtPacketsSendAsPerChallan.Text = Convert.ToString(ds.Tables[0].Rows[0]["PacketsSendAsPerChallan"]);
                //txtPacketsReceiveByCounting.Text = Convert.ToString(ds.Tables[0].Rows[0]["PacketsReceiveByCounting"]);
                //txtTotalNoBook.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalNoBook"]);
                //txtBookFrom.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookFrom"]);
                //txtBookto.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookto"]);

                txtTruckCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["TruckCharges"]);
                txtUnloadingCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["UnloadingCharges"]);
                txtLoadingCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["LoadingCharges"]);
                txtOtherCharges.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherCharges"]);
                txtRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);

                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]);
                obPrinChallan.Finyear = Convert.ToString(DdlACYear.SelectedValue);
                ds = obPrinChallan.LoadGroupDetails();
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
        int chechstatus = 0;
        foreach (GridViewRow gv in GrdTitle.Rows)
        {
            CheckBox chk = (CheckBox)gv.FindControl("chkGroup");

            // int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
            if (chk.Checked == true)
            {

                chechstatus++;
            }
        }



        if (chechstatus == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = " चालान में ग्रुप जोड़े ..";
        }


        else if (DdlDepot.SelectedIndex == 0)
        {
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'डिपो सलेक्ट करे   ..";
        }


        else
        {

            obPrinChallan = new PRIN_ChallanDetails();



            try
            {
                if (Request.QueryString["Cid"] != null)
                {
                    obPrinChallan.PriTransID = Convert.ToInt32(Request.QueryString["Cid"]);
                }
                else { obPrinChallan.PriTransID = 0; }

                obPrinChallan.ChalanNo = Convert.ToString(txtChalanNo.Text);
                obPrinChallan.ChalanDate = Convert.ToDateTime(txtChalanDate.Text, cult);
                obPrinChallan.ReceiptDate = Convert.ToDateTime(txtReceiptDate.Text, cult);

                //obPrinChallan.TitalID = Convert.ToInt32(ddlTitalID.SelectedValue);
                obPrinChallan.TitalID = 00;

                //obPrinChallan.PacketsSendAsPerChallan = Convert.ToInt32(txtPacketsSendAsPerChallan.Text);
                //obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(txtPacketsReceiveByCounting.Text);
                //obPrinChallan.TotalNoBook = Convert.ToInt32(txtTotalNoBook.Text);
                //obPrinChallan.BookFrom = Convert.ToInt32(txtBookFrom.Text);
                //obPrinChallan.Bookto = Convert.ToInt32(txtBookto.Text);


                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;

                // obPrinChallan.Depo_I = Convert.ToInt32(HdnDepo_I.Value);
                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);
                obPrinChallan.TruckCharges = Convert.ToString(txtTruckCharges.Text);
                obPrinChallan.UnloadingCharges = Convert.ToDateTime(txtUnloadingCharges.Text);
                obPrinChallan.LoadingCharges = Convert.ToString(txtLoadingCharges.Text);
                obPrinChallan.OtherCharges = Convert.ToString(txtOtherCharges.Text);
                obPrinChallan.Remark = Convert.ToString(txtRemark.Text);

                i = obPrinChallan.SaveUpdateChallanDetails();




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
                            if (BundleType.Text == "योजना")
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
                            obStockDetailsChild.Trans_I = 0;

                            obStockDetailsChild.RemaingLoose_V = "";
                            obStockDetailsChild.StockDetailsChildID_I = 0;
                            obStockDetailsChild.StockDetailsID_I = Mid;
                            int Stockdetid = obStockDetailsChild.InsertUpdate();

                            CommonFuction obCommonFun = new CommonFuction();
                            obCommonFun.FillDatasetByProc("call USP_PrinterStockUpdate(" + i + "," + Stockdetid + ")");
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

        i = SaveChallan();

        if (i > 0)
        {


            for (int Coun = 0; Coun < GrdTitle.Rows.Count; Coun++)
            {
                obPrinChallan = new PRIN_ChallanDetails();

                obPrinChallan.grpID_I = Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNGRPID_I")).Value);
                obPrinChallan.TitalID = Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNTitleID_I")).Value);
                obPrinChallan.Depo_I = Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNDepoID_I")).Value);
                obPrinChallan.PriTransID = i;
                obPrinChallan.ChallanTrno_I = 0;
                //0 means delete all detail and reinsert
                //Convert.ToInt32(((HiddenField)GrdTitle.Rows[Coun].FindControl("HDNChallanTrno_I")).Value);

                obPrinChallan.PacketsSendAsPerChallan = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsSendAsPerChallan")).Text);
                // obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsReceiveByCounting")).Text);
                obPrinChallan.TotalNoBook = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtTotalNoOfBooks")).Text);

                obPrinChallan.BookFrom = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksFrom")).Text);
                obPrinChallan.Bookto = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksTo")).Text);

                obPrinChallan.PacketsSendAsPerChallanYoj = Convert.ToString(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsSendAsPerChallanYoj")).Text);
                // obPrinChallan.PacketsReceiveByCounting = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtPacketsReceiveByCounting")).Text);
                obPrinChallan.TotalNoOfBooksYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtTotalNoOfBooksYoj")).Text);

                obPrinChallan.BooksFromYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksFromYoj")).Text);
                obPrinChallan.BooksToYoj = Convert.ToInt32(((TextBox)GrdTitle.Rows[Coun].FindControl("txtBooksToYoj")).Text);

                obPrinChallan.SaveChallanTitleDetails();
            }




            Response.Redirect("VIEW002_PrinChallanDetails.aspx");
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Check Data.');</script>"); }

    }

    private void loadgrid(int mtype)
    {//mtype=1 all data , 2 calculated demand, 3 - depo wise 4-class wise 5 depo+class wise 


        try
        {
            obPrinChallan = new PRIN_ChallanDetails();
            DataSet ds = new DataSet();

            if (mtype == 1)
            {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = 0;
                //obj.intdepotrno_I = 0;
                ds = obPrinChallan.LoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();
            }

            else if (mtype == 2)
            {
                //obj.dtype = 2;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                // obPrinChallan .intClasstrno_I = 0;
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);
                ds = obPrinChallan.LoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();

            }

            else if (mtype == 3)
            {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue); ;
                //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);
                obPrinChallan.User_ID = Convert.ToInt32(Session["PrierID_I"]); ;
                obPrinChallan.Depo_I = Convert.ToInt32(DdlDepot.SelectedValue);
                obPrinChallan.ClassID = Convert.ToInt32(DdlClass.SelectedValue);
                ds = obPrinChallan.LoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();

            }
            else if (mtype == 4)
            {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue);
                //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);
                ds = obPrinChallan.LoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();
            }

            else if (mtype == 5)
            {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = Convert.ToInt32(DdlClass.SelectedValue);
                //obj.intdepotrno_I = Convert.ToInt32(DdlDepot.SelectedValue);
                ds = obPrinChallan.LoadGroupDetails();
                GrdTitle.DataSource = ds;
                GrdTitle.DataBind();

            }
        }
        catch { }
        finally { }

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["d"] = null;
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadgrid(2);
        Session["d"] = null;
    }
    protected void DdlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadgrid(3);
        Session["d"] = null;
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadgrid(3);
        Session["d"] = null;
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

                chkGroup.Checked = false;

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
        Response.Redirect("VIEW002_PrinChallanDetails.aspx");
    }
}
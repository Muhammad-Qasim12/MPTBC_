using System;
using System.Data;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using MPTBCBussinessLayer.Paper;

public partial class Distribution_DistributionOrderReport : System.Web.UI.Page
{
    DIS_VitranNirdesh obVitranNirdesh = new DIS_VitranNirdesh();
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Random rdm = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            LblFyYear.Text = DdlACYear.SelectedItem.Text;
            DdlACYear_SelectedIndexChanged( sender,  e);
            DdlGroup.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS002_GroupCreationLoad(0)");
            DdlGroup.DataValueField = "GroupId";
            DdlGroup.DataTextField = "GroupName";
            DdlGroup.DataBind();

            //DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            //DdlTitle.DataValueField = "GroupId";
            //DdlTitle.DataTextField = "GroupName";
            //DdlTitle.DataBind();

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "ClassDesc_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, "--Select--");

            TxtOrderNO.Text = System.DateTime.Now.ToString("ddMMssmm") + RandomNumber();

        }
    }
    private string RandomNumber()
    {
        return (rdm.Next(2, 100)).ToString();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LblFyYear.Text = DdlACYear.SelectedValue;
        //DropDownList2.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        //DropDownList2.DataValueField = "OrderNo";
        //DropDownList2.DataTextField = "OrderNo";
        //DropDownList2.DataBind();
        //DropDownList2.Items.Insert(0, new ListItem("-Select-", "0"));
    }


    public int SaveVitran
        (
        int depotId,
        int NoOfBooks,
        string BookNumberFrom,
        string BookNumberTo,
        int TotalBundels,
        string BundleNoFrom,
        string BundleNoTo,
        int BooksPerBundle,
        int BooksPerGaddi,
         string DemandType,
        string Remark,
        string orderNO,
        DateTime OrderDate
        )
    {
        int i = 0;
        obVitranNirdesh = new DIS_VitranNirdesh();


        try
        {
            obVitranNirdesh.AcYear = Convert.ToString(DdlACYear.SelectedValue);
            obVitranNirdesh.PrinterID = Convert.ToInt32(DdlPrinter.SelectedValue);
            obVitranNirdesh.DepotID = depotId;
            obVitranNirdesh.TitleID = Convert.ToInt32(DdlTitle.SelectedValue);
            obVitranNirdesh.BookType = Convert.ToInt32(DdlBookType.SelectedValue);
            obVitranNirdesh.GroupID = Convert.ToInt32(DdlGroup.SelectedValue);
            obVitranNirdesh.NoOfBooks = NoOfBooks;
            obVitranNirdesh.BooksPerBundle = BooksPerBundle;
            obVitranNirdesh.BooksPerGaddi = BooksPerGaddi;
            obVitranNirdesh.BookNumberFrom = BookNumberFrom;
            obVitranNirdesh.BookNumberTo = BookNumberTo;
            obVitranNirdesh.TotalBundels = TotalBundels;
            obVitranNirdesh.BundleNoFrom = BundleNoFrom;
            obVitranNirdesh.BundleNoTo = BundleNoTo;
            obVitranNirdesh.Remark = Remark;
            obVitranNirdesh.OrderNo = orderNO;
            obVitranNirdesh.OrderDate = OrderDate;
            obVitranNirdesh.DemandType = DemandType;
            i = obVitranNirdesh.InsertUpdate();

        }

        catch (Exception ex) { }
        finally { obVitranNirdesh = null; }
        return i;
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();

            //DataSet obDataset = obCommonFuction.FillDatasetByProc(@"Call USP_DIS_VitranNirdesh('" + (DdlACYear.SelectedValue).ToString()
            //                                                                                  + "'," + Convert.ToInt32(DdlGroup.SelectedValue)
            //                                                                                  + "," + Convert.ToInt32(DdlTitle.SelectedValue)
            //                                                                                  + "," + Convert.ToInt16(TextBooksPerBundle.Text)
            //                                                                                  + "," + Convert.ToInt16(DdlBookType.SelectedValue) + ",'"+DropDownList2.SelectedValue+"',"+DdlPrinter.SelectedValue+")");
           // GrdVitranNirdesh.DataSource = obDataset;
            GrdVitranNirdesh.DataBind();
            mainDiv.Style.Add("display", "none");
            lblmsg.Style.Add("display", "none");
            Button1.Visible = true;
        }
        catch
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");

            if (DdlTitle.SelectedIndex < 0)
                lblmsg.Text = "कृपया पुस्तक का नाम चुने";
            else if (DdlClass.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया कक्षा चुने";

        }
    }


    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        CommonFuction obCommonFuction = new CommonFuction();


        DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_TitleLoadClassWiseNew(" + Convert.ToInt32(DdlClass.SelectedValue) + ",'"+DdlACYear.SelectedValue +"')");
        DdlTitle.DataValueField = "TitleID_I";
        DdlTitle.DataTextField = "TitleHindi_V";
        DdlTitle.DataBind();
        //DdlTitle.Items.Insert(0, "--Select--");
        DdlTitle.Items.Insert(0, new ListItem("-Select-", "0"));


        DdlPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS_GetPrintersByTitleNDepot('" + Convert.ToInt32(DdlTitle.SelectedValue) + "','" + Convert.ToInt32(DdlGroup.SelectedValue) + "','"+DdlACYear.SelectedItem.Text+"')");
        DdlPrinter.DataValueField = "Printer_RegID_I";
        DdlPrinter.DataTextField = "NameOfPress_V";
        DdlPrinter.DataBind();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int count=0;

        String CheckSms = "", PrintingMoblNo = "", PrintingCheckSms = "";
        for (int i = 0; i < GrdVitranNirdesh.Rows.Count; i++)
        {
           // chk1
            if (((CheckBox)GrdVitranNirdesh.Rows[i].FindControl("chk1")).Checked == true)
            {
                count = count + 1;
            //if ( che NoOfBooks = (Label)GrdVitranNirdesh.Rows[i].FindControl("lblNoOfBooks");)
            Label NoOfBooks = (Label)GrdVitranNirdesh.Rows[i].FindControl("lblNoOfBooks");
            TextBox BookNoFrom = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("TxtBookNoFrom");
            TextBox BookNoTo = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("lblBookNoTo");
            Label TotalBundles = (Label)GrdVitranNirdesh.Rows[i].FindControl("lblTotalBundles");
            TextBox BundleNoFrom = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("TxtBundleNoFrom");
            TextBox BundleNoTo = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("lblBundleNoTo");
            TextBox Remark = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("TxtRemark");

            DropDownList ddl = (DropDownList)GrdVitranNirdesh.Rows[i].FindControl("DropDownList1");
            //TextBox OrderNO = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("TxtOrderNO");
            //TextBox OrderDate = (TextBox)GrdVitranNirdesh.Rows[i].FindControl("TxtOrderDate");

            HiddenField depot = (HiddenField)GrdVitranNirdesh.Rows[i].FindControl("HDNdepotId");

            SaveVitran(
               Convert.ToInt32(depot.Value),
               Convert.ToInt32(NoOfBooks.Text),
               Convert.ToString(BookNoFrom.Text),
               Convert.ToString(BookNoTo.Text),
               Convert.ToInt32(TotalBundles.Text),
               Convert.ToString(BundleNoFrom.Text),
               Convert.ToString(BundleNoTo.Text),
               Convert.ToInt32(TextBooksPerBundle.Text),
               Convert.ToInt32(TxtBooksPerGaddi.Text),
               Convert.ToString(ddl.SelectedItem.Text),
               Convert.ToString(Remark.Text),
               
               Convert.ToString(TxtOrderNO.Text),
               DateTime.Parse(TxtOrderDate.Text, cult)
               );

            try
            {
                MailHelper objSendSms = new MailHelper();
                PPR_RDLCData objGetMobile = new PPR_RDLCData();
                string Msg = "", DepotMoblNo = "";
                //Usp_Get_SMS_MobileNo
                DataSet ds = new DataSet();
                ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
                Msg = "Distribution order for " + DdlPrinter.SelectedItem.Text + ". Title has been submitted.";
                foreach (DataRow Dr in ds.Tables[0].Rows)
                {
                    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
                    {
                        if (CheckSms == "")
                        {
                            objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                        }
                        CheckSms = "Done";
                    }
                    if (Dr["Flag"].ToString() == "User" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
                    {
                        try
                        {
                            //Printing One Time Only
                            ds = new DataSet();
                            if (PrintingCheckSms == "")
                            {
                                PrintingMoblNo = objGetMobile.GetMobileNoForSms("4", DdlPrinter.SelectedItem.Value.ToString()).Tables[0].Rows[0]["MobileNo"].ToString();
                            }
                            PrintingCheckSms = "Done";
                        }
                        catch { }
                        objSendSms.sendMessage(PrintingMoblNo, Msg);
                    }
                    if (Dr["Flag"].ToString() == "User" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Depot Manager")
                    {
                        try
                        {
                            //Depo
                            ds = new DataSet();
                            DepotMoblNo = objGetMobile.GetMobileNoForSms("6", depot.Value.ToString()).Tables[0].Rows[0]["MobileNo"].ToString();
                        }
                        catch { }
                        objSendSms.sendMessage(DepotMoblNo, Msg);
                    }
                }
            }
            catch { }
            }
        }
        if (count == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "कृपया चेकबॉक्स पर चयन करें";
        }
        else { 
        mainDiv.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        lblmsg.Text = "डिपोवार आवंटन रिपोट सम्बंधित डिपो एवं मुद्रक को प्रेषित किया गया ";
        TxtOrderNO.Text = System.DateTime.Now.ToString("ddMMssmm") + RandomNumber();
        }
    }


    protected void DdlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {


        DdlPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS_GetPrintersByTitleNDepot('" + Convert.ToInt32(DdlTitle.SelectedValue) + "','" + Convert.ToInt32(DdlGroup.SelectedValue) + "','" + DdlACYear.SelectedItem.Text + "')");
        DdlPrinter.DataValueField = "Printer_RegID_I";
        DdlPrinter.DataTextField = "NameOfPress_V";
        DdlPrinter.DataBind();
        DdlPrinter.Items.Insert(0, new ListItem("--Select--", "0"));
        DataSet dd = obCommonFuction.FillDatasetByProc("call GettotleBookinBandle(" + DdlTitle.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
        //DataSet dd = obCommonFuction.FillDatasetByProc("call GettotleBookinBandle(" + DdlTitle.SelectedValue + ")");
        TextBooksPerBundle.Text = dd.Tables[0].Rows[0]["BookNumber"].ToString();
        TxtBooksPerGaddi.Text = Convert.ToString(Convert.ToInt32(TextBooksPerBundle.Text) / 4);

    }
    protected void DdlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
        DdlClass.DataValueField = "ClassTrno_I";
        DdlClass.DataTextField = "Classdet_V";
        DdlClass.DataBind();
        // DdlClass.Items.Insert(0, "--Select--");
        DdlClass.Items.Insert(0, new ListItem("--Select--", "0"));
        DdlClass_SelectedIndexChanged(sender, e);
    }

}

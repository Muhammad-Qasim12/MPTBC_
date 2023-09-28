using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Depo_DPT09_BookSelleDemandformat : System.Web.UI.Page
{
    MediumMaster obMediumMaster = null; CommonFuction comm = new CommonFuction();
    ClassMaster obClass = null; string ClassID;
    DPT_DepotMaster obDepoMaster = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BookSellerDemand obBookSellerDemand = null;
    CommonFuction obCommonFuction = null;
    double GrassAmount, TotalAmount;
    DBAccess bd = new DBAccess();
    int PerCentage;
    double TotalGrass, TotalPayamt;
    double TotalGR;
    double ToalGS;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            ddlBookSeller.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetbooksellerLogin(" + Session["UserID"] + ")");
            ddlBookSeller.DataTextField = "BooksellerName_V";
            ddlBookSeller.DataValueField = "LoginID_V";
            ddlBookSeller.DataBind();


            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "All..");
            //----------------Class Bind
            Random randam = new Random();
            int Random = randam.Next(100000, 100000000);
            TextBox1.Text = Convert.ToString(Random);
            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            //obClass.ClassTrno_I = 0;
            //ddlCls.DataTextField = "Classdet_V";
            //ddlCls.DataValueField = "ClassTrno_I";
            //ddlCls.DataSource = dtclass.Tables[0];
            //ddlCls.DataBind();
            //ddlCls.Items.Insert(0, "सलेक्ट करे ..");
            //-----DEPo
            //obDepoMaster = new DPT_DepotMaster();
            //DataSet dtDepo = obDepoMaster.Select();
            // dtDepo.Tables[0].DefaultView.RowFilter = "DepoTrno_I ='" + ddlCategory.SelectedItem.Text + "'";

            CommonFuction comm = new CommonFuction();
            DataSet dtDepo = comm.FillDatasetByProc("Call USP_DPT_DepoNamebyBookseller(" + ddlBookSeller.SelectedValue + ")");
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataSource = dtDepo.Tables[0];
            ddlDepo.DataBind();
            //ddlDepo.DataTextField = "DepoName_V";
            //ddlDepo.DataValueField = "DepoTrno_I";
            //ddlDepo.DataSource = dtDepo.Tables[0];
            //ddlDepo.DataBind();
            //ddlDepo.Items.Insert(0, "सलेक्ट करे ..");
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //  DataSet dd = comm.FillDatasetByProc("call USP_Dpt_BookChallandetails(" + ddlBookSeller.SelectedValue+ ",0)");
            DataSet dd = comm.FillDatasetByProc("call GetBookSellerAmountByUserID(" + ddlBookSeller.SelectedValue + ",'2023-2024')");
            try
            {
                Label11.Text = dd.Tables[0].Rows[0]["TotalAmount"].ToString();
            }
            catch { Label11.Text = "0"; }
            fillgrd();
            if (grnMain.Rows.Count > 0)
            {
                btn_add0.Visible = true;
            }
            BindDDLBank();
            Page.MaintainScrollPositionOnPostBack = true;
        }

    }
    public void BindDDLBank()
    {
        DataSet dd = comm.FillDatasetByProc("CALL USP_bankmasterList()");
        DDLBank.DataSource = dd;
        DDLBank.DataValueField = "BankId";
        DDLBank.DataTextField = "BankName";
        DDLBank.DataBind();
    }
    protected void ddlCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        Label12.Text = "";


        if (ddlCls.SelectedIndex == 0)
        {
            GrdBookDemand.DataSource = null;
            GrdBookDemand.DataBind();
        }
        else
        {

            //obBookSellerDemand = new BookSellerDemand();

            //DataSet LoadDemand = obBookSellerDemand.loadBook(Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(ddlCls.SelectedValue));
            //GrdBookDemand.DataSource = LoadDemand.Tables[0];
            //GrdBookDemand.DataBind();
            if (ddlCls.SelectedValue == "1")
            {
                ClassID = "1,2,3,4,5,6,7,8";
            }
            else if (ddlCls.SelectedValue == "2")
            {
                ClassID = "9,10,11,12";
            }
            else if (ddlCls.SelectedValue == "3")
            {
                ClassID = "1,2,3,4,5,6,7,8,9,10,11,12";
            }
            string MediumIDa;
            if (ddlMedium.SelectedIndex == 0)
            {
                MediumIDa = "0";
            }
            else
            {
                MediumIDa = ddlMedium.SelectedValue;
            }
            DataSet LoadDemand = comm.FillDatasetByProc("call USP_DPT012_LoadTitalMediumwise(" + MediumIDa + ",'" + ClassID + "'," + ddlDepo.SelectedValue + ")");
            GrdBookDemand.DataSource = LoadDemand.Tables[0];
            GrdBookDemand.DataBind();
        }

    }
    public Boolean CheckForValifdation(int tiltleid)
    {
        BookSellerDemand obBookSellerDemand1 = new BookSellerDemand();
        obBookSellerDemand1.User_ID_I = Convert.ToInt32(ddlBookSeller.SelectedValue);
        obBookSellerDemand1.DBookSelleDemandTrNo_I = 0;
        DataSet Demand = obBookSellerDemand1.Select();

        for (int i = 0; i < GrdBookDemand.Rows.Count; i++)
        {


            foreach (DataRow dr in Demand.Tables[0].Rows)
            {
                if (Convert.ToInt32(((tiltleid))) == Convert.ToInt32(dr["TitleID_I"]))
                {
                    return true;
                }
            }


        }
        return false;

    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {

            obBookSellerDemand = new BookSellerDemand();


            //obCommonFuction = new CommonFuction();
            //DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_BookSellerOrder('" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlBookSeller.SelectedValue + ")");
            //if (dd1.Tables[0].Rows.Count > 0)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('एक दिनांक में एक बार ही डिमांड भेज सकते है  |');</script>");  
            //    Label12.Text = "एक दिनांक में एक बार ही डिमांड भेज सकते है ";
            //}
            //else { 
            for (int i = 0; i < GrdBookDemand.Rows.Count; i++)
            {
                try
                {
                    int mediumID = 0;
                    if (ddlMedium.SelectedIndex == 0)
                    {
                        mediumID = 0;
                    }
                    else
                    {
                        mediumID = Convert.ToInt32(ddlMedium.SelectedValue);
                    }
                    obBookSellerDemand.ClassID_I = Convert.ToInt32(ddlCls.SelectedValue);
                    obBookSellerDemand.BDate_D = Convert.ToDateTime(txtDate.Text, cult);
                    obBookSellerDemand.Depo_ID_I = Convert.ToInt32(ddlDepo.SelectedValue);
                    obBookSellerDemand.Meidum_ID_I = Convert.ToInt32(mediumID);
                    obBookSellerDemand.Issumbited_I = 0;
                    obBookSellerDemand.TitalID_I = Convert.ToInt32(((HiddenField)GrdBookDemand.Rows[i].FindControl("hTitlID")).Value);
                    obBookSellerDemand.TotalDemand = Convert.ToInt32(((TextBox)GrdBookDemand.Rows[i].FindControl("txtdemand")).Text);
                    obBookSellerDemand.User_ID_I = Convert.ToInt32(ddlBookSeller.SelectedValue);
                    obBookSellerDemand.TransIDI_I = 0;

                    bool check = true;
                    if (CheckForValifdation(obBookSellerDemand.TitalID_I))
                    {
                        check = false;





                    }
                    if (HiddenField1.Value != "")
                    {
                        obBookSellerDemand.TransIDI_I = 1;
                        obBookSellerDemand.DBookSelleDemandTrNo_I = Convert.ToInt32(HiddenField1.Value);
                    }
                    if (check || HiddenField1.Value != "")
                    {
                        if (Convert.ToInt32(((TextBox)GrdBookDemand.Rows[i].FindControl("txtdemand")).Text) != 0)
                        {
                            obBookSellerDemand.InsertUpdate();
                        }
                    }
                }
                catch { }
                finally { HiddenField1.Value = ""; }
            }

            //}

            a.Style.Add("display", "block");
            qq.Style.Add("display", "block");
            TotalGR = Convert.ToDouble(Label4.Text);
            ToalGS = Convert.ToDouble(Label5.Text);
            if (Label6.Text == "")
            {
                Label6.Text = Convert.ToString(Math.Round(Convert.ToDouble(TotalGR), 0));
            }
            else
            {
                Label6.Text = Convert.ToString(Math.Round(Convert.ToDouble(Label6.Text) + TotalGR, 0));
            }
            if (Label7.Text == "")
            {
                Label7.Text = Convert.ToString(Math.Round(Convert.ToDecimal(ToalGS), 0));
            }
            else
            {
                Label7.Text = Convert.ToString(Math.Round(Convert.ToDouble(Label7.Text) + ToalGS, 0));
            }

            DataSet dd = comm.FillDatasetByProc("call GetBookAmount(" + ddlBookSeller.SelectedValue + "," + ddlDepo.SelectedValue + ")");
            Label6.Text = dd.Tables[0].Rows[0]["TotalDemand"].ToString();
            Label7.Text = dd.Tables[0].Rows[0]["Amount"].ToString();
            // if (Label10.Text == "")
            // {
            //  Label10.Text = Label5.Text;
            //  }else 
            // {
            //   Label10.Text = Convert.ToString(Convert.ToDecimal(Label10.Text) + Convert.ToDecimal(Label5.Text));
            //  }

            Label4.Text = "";
            Label5.Text = "";
            ddlCls.SelectedIndex = 0;
            ddlMedium.SelectedIndex = 0;
            GrdBookDemand.DataSource = null;
            GrdBookDemand.DataBind();
            // obCommonFuction.EmptyTextBoxes(this);
            ddlCls.Enabled = true;
            btn_add0.Visible = true;

            fillgrd();

        }
        catch { }

    }
    public void fillgrd()
    {
        obBookSellerDemand = new BookSellerDemand();
        obBookSellerDemand.User_ID_I = Convert.ToInt32(ddlBookSeller.SelectedValue);
        obBookSellerDemand.DBookSelleDemandTrNo_I = 0;
        DataSet Demand = obBookSellerDemand.Select();
        grnMain.DataSource = Demand.Tables[0];
        grnMain.DataBind();
    }

    protected void grnMain_SelectedIndexChanged(object sender, EventArgs e)
    {

        obBookSellerDemand = new BookSellerDemand();
        obBookSellerDemand.User_ID_I = Convert.ToInt32(ddlBookSeller.SelectedValue);
        obBookSellerDemand.DBookSelleDemandTrNo_I = Convert.ToInt32(grnMain.SelectedDataKey.Value.ToString());
        DataSet Demand = obBookSellerDemand.Select();

        try
        {
            txtDate.Text = Convert.ToDateTime(Demand.Tables[0].Rows[0]["BDate_D"]).ToString("dd/MM/yyyy");
        }
        catch { }
        try
        {
            ddlMedium.SelectedValue = Convert.ToString(Demand.Tables[0].Rows[0]["Meidum_ID_I"]);
        }
        catch { }
        try
        {
            ddlCls.SelectedValue = Convert.ToString(Demand.Tables[0].Rows[0]["ClassID_I"]);
            ddlCls.Enabled = false;
        }
        catch { }
        try
        {
            ddlDepo.SelectedValue = Convert.ToString(Demand.Tables[0].Rows[0]["Depo_ID_I"]);
        }
        catch { }
        GrdBookDemand.DataSource = Demand.Tables[0];
        GrdBookDemand.DataBind();
        HiddenField1.Value = grnMain.SelectedDataKey.Value.ToString();
    }
    //Button1
    //Button11_Click
    protected void Button11_Click(object sender, EventArgs e)
    {
        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["RoleId"]) == "3")
        {
            Div1.Style.Add("display", "none");
            Div2.Style.Add("display", "none");
        }
        else
        {
            Response.Redirect("VIEW_DPT009.aspx");
        }
    }
    protected void btn_add0_Click(object sender, EventArgs e)
    {
        // Decimal Amount = Convert.ToDecimal(txtAmount.Text) + Convert.ToDecimal(Label11.Text);
        //  Decimal Amount1 = Convert.ToDecimal(Label7.Text);
        // if (Amount >= Amount1)
        //  { 
        obBookSellerDemand = new BookSellerDemand();
        for (int j = 0; j < grnMain.Rows.Count; j++)
        {
            try
            {
                //obBookSellerDemand.DBookSelleDemandTrNo_I = ;
                //obBookSellerDemand.DOrderNo = ;
                //obBookSellerDemand.TranDate_D = ;
                //obBookSellerDemand.DDDate = ;
                //obBookSellerDemand.DDNouber = ;
                //obBookSellerDemand.BankName = ;  
                //obBookSellerDemand.BookUDemandpdate();
                if (txtAmount.Text == "")
                {
                    txtAmount.Text = "0";
                }
                if (txtChekDate.Text == "")
                {
                    txtChekDate.Text = "01/01/1900";
                }
                comm.FillDatasetByProc("call USP_DPT012_BookDemandSend(" + Convert.ToInt32(((HiddenField)grnMain.Rows[j].FindControl("BookSelleDemandTrNo_I")).Value) + ",'" + Convert.ToString(TextBox1.Text) + "','" + Convert.ToDateTime(txtChekDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToString(txtDdno.Text) + "','" + Convert.ToString(DDLBank.SelectedItem.Text) + "','" + txtAmount.Text + "')");
            }
            catch { }
            finally { }

        }
        try
        {
            DataSet ds;
            MailHelper objSendSms = new MailHelper();
            // PPR_RDLCData objGetMobile = new PPR_RDLCData();
            string Msg = "", DepotMoblNo = "";
            //Usp_Get_SMS_MobileNo
            ds = new DataSet();
            // ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
            Msg = "Demand as per Order No : " + TextBox1.Text.Trim() + "  and date " + txtDate.Text + " ,Bookseller Name =" + Session["UserName"].ToString() + "";
            //Msg = "Received as per Challan No : " + lblchalan.Text.Trim() + "  and date " + lblchalandate.Text + " On " + txtPdate.Text + " Date";
            //foreach (DataRow Dr in ds.Tables[0].Rows)
            //{
            //    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Distribution")
            //    {
            //        try
            //        {
            //            objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
            //        }
            //        catch { }
            //    }
            //    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
            //    {
            //        try
            //        {
            //            objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
            //        }
            //        catch { }
            //    }

            try
            {
                // Paper Vendor
                ds = new DataSet();
                DepotMoblNo = obCommonFuction.FillDatasetByProc("CALL GetMobleNumberDeport(" + ddlDepo.SelectedValue + ",0,0)").ToString();
                objSendSms.sendMessage(DepotMoblNo, Msg);
            }
            catch { }


            //}
        }
        catch { }
        Label8.Text = Label7.Text;
        Label6.Text = "";
        Label7.Text = "";
        fillgrd();
        Label9.Text = TextBox1.Text;
        //  Messages.Style.Add("display", "block");
        //fadeDiv.Style.Add("display", "block");
        if (Convert.ToString(Session["RoleId"]) == "3")
        {
            Response.Redirect("booksellerdistribution.aspx?BooKsellerID=" + ddlBookSeller.SelectedValue + "&CHallanNo=" + TextBox1.Text + "");
        }
        else { Response.Redirect("VIEW_DPT009.aspx"); }


    }
    protected void GrdBookDemand_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtdemand_TextChanged(object sender, EventArgs e)
    {
        try
        {
            bd.execute("SELECT case when category=0 then 0 when category=1 then 20 when category=2 then 20 when category=3 then 20  when category=4 then 20 end  TotalPer FROM dpt_booksellerregistration_m where Booksellerregistration_I=(select Booksellerregistration_I from dpt_booksellerregistration_m where LoginID_V=" + ddlBookSeller.SelectedValue + ")", DBAccess.SQLType.IS_QUERY);
            DataSet ds = bd.records();
            PerCentage = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalPer"]);
        }
        catch { }

        for (int i = 0; i < GrdBookDemand.Rows.Count; i++)
        {
            string Test = ((TextBox)GrdBookDemand.Rows[i].FindControl("txtdemand")).Text;
            string Test2 = GrdBookDemand.Rows[i].Cells[4].Text;
            if (Test == "")
            {
                Test = "0";
            }
            if (Test2 == "&nbsp;" || Test2 == "")
            {
                Test2 = "0";
            }
            //if (Convert.ToInt32(Test) > Convert.ToInt32(Test2) )
            //  {
            //      ((TextBox)GrdBookDemand.Rows[i].FindControl("txtdemand")).Text = "0";
            //      Label12.Text = "स्टॉक से अधिक मांग आप नहीं कर सकते है ";
            //     // ((TextBox)GrdBookDemand.Rows[i].FindControl("txtdemand")).BackColor =;
            //  }
            //  else
            //  {
            Label12.Text = "";
            try
            {
                GrassAmount = Convert.ToDouble(((Label)GrdBookDemand.Rows[i].FindControl("Label3")).Text);

                ((Label)GrdBookDemand.Rows[i].FindControl("Label1")).Text = Convert.ToString(Convert.ToDouble(((TextBox)GrdBookDemand.Rows[i].FindControl("txtdemand")).Text) * GrassAmount);//* Convert.ToDouble (((Label)GrdBookDemand.Rows[i].FindControl("Label1")).Text)) ;
                TotalAmount = Convert.ToDouble((Convert.ToDouble(((Label)GrdBookDemand.Rows[i].FindControl("Label1")).Text) * Convert.ToDouble(PerCentage)) / 100);

                ((Label)GrdBookDemand.Rows[i].FindControl("Label2")).Text = Convert.ToString(Convert.ToDouble(((Label)GrdBookDemand.Rows[i].FindControl("Label1")).Text) - TotalAmount);
                TotalGrass = TotalGrass + Convert.ToDouble(((Label)GrdBookDemand.Rows[i].FindControl("Label1")).Text);
                TotalPayamt = TotalPayamt + Convert.ToDouble(((Label)GrdBookDemand.Rows[i].FindControl("Label2")).Text);
                Label4.Text = Convert.ToString(Math.Round(Convert.ToDecimal(TotalGrass), 0));
                Label5.Text = Convert.ToString(Math.Round(Convert.ToDecimal(TotalPayamt), 0));
            }
            catch { }
            //int index = ((TextBox)sender).TabIndex;
            //TextBox txtindex = (TextBox)GrdBookDemand.Rows[index + 1].FindControl("txtdemand");
            //txtindex.Focus();
            // }

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            string folderPath = ConfigurationManager.AppSettings["FolderPath"];

            string filePath = Server.MapPath(folderPath + filename);
            FileUpload1.SaveAs(filePath);


            ImportTogrid(filePath, Extension, "Yes");
            //  GrdEval.DataSource = dtEx;
            //  GrdEval.DataBind();


        }


    }
    public void ImportTogrid(string FilePath, string Extension, string IsHDR)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": // Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;

                break;

            case ".xlsx": // Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;

        }

        string SubQuery = "";
        conStr = string.Format(conStr, FilePath, IsHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();

        DataSet dt = new DataSet();
        cmdExcel.Connection = connExcel;
        // get first Sheet

        connExcel.Open();

        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        // read data from first sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";

        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();

        string Noofbooks = "0";

        //INSERT INTO  dpt_bookselledemandmaster(BDate_D,Depo_ID_I,Meidum_ID_I, TitalID_I,TotalDemand,Issumbited_I,User_ID_I,TranDate_D,ClassID_I)
        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {
            try
            {
                Noofbooks = dt.Tables[0].Rows[i]["NoofBooks"].ToString();
            }
            catch
            {
                Noofbooks = "0";
            }
            if (Convert.ToString(Noofbooks) == "")
            {
                Noofbooks = "0";
            }
            if (Convert.ToInt32(Noofbooks) != 0)
            {
                if (SubQuery == "")
                {
                    SubQuery = SubQuery + "('" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + ddlDepo.SelectedValue + "','" + dt.Tables[0].Rows[i]["Medium"].ToString() + "','" + dt.Tables[0].Rows[i]["SRNO"].ToString() + "','" + dt.Tables[0].Rows[i]["NoofBooks"].ToString() + "',0," + ddlBookSeller.SelectedValue + " ,'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + dt.Tables[0].Rows[i]["Class"].ToString() + ")";
                }
                else
                {
                    SubQuery = SubQuery + ",('" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + ddlDepo.SelectedValue + "','" + dt.Tables[0].Rows[i]["Medium"].ToString() + "','" + dt.Tables[0].Rows[i]["SRNO"].ToString() + "','" + dt.Tables[0].Rows[i]["NoofBooks"].ToString() + "',0," + ddlBookSeller.SelectedValue + " ,'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + dt.Tables[0].Rows[i]["Class"].ToString() + ")";
                }

            }
        }
        if (!string.IsNullOrEmpty(SubQuery))
        {
            comm.FillDatasetByProc(@"INSERT INTO  dpt_bookselledemandmaster(BDate_D,Depo_ID_I,Meidum_ID_I,TitalID_I,TotalDemand,Issumbited_I,User_ID_I,TranDate_D,ClassID_I)values " + SubQuery + "");
        }
        fillgrd();
        DataSet dd = comm.FillDatasetByProc("call GetBookAmount(" + ddlBookSeller.SelectedValue + "," + ddlDepo.SelectedValue + ")");
        Label6.Text = dd.Tables[0].Rows[0]["TotalDemand"].ToString();
        Label7.Text = dd.Tables[0].Rows[0]["Amount"].ToString();
        btn_add0.Visible = true;
    }


    protected void ddlBookSeller_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = comm.FillDatasetByProc("call GetBookSellerAmountByUserID(" + ddlBookSeller.SelectedValue + ",'2023-2024')");
        try
        {
            Label11.Text = dd.Tables[0].Rows[0]["TotalAmount"].ToString();
        }
        catch { Label11.Text = "0"; }
    }
}
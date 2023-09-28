using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;


public partial class Depo_DepoRecevingwithBarcode : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DBAccess db = new DBAccess();
    DataSet fillgrd; Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        // ViewState["data"]  = null;
        if (!IsPostBack)
        {
            try
            {
                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT018_PrinterDelivery_load(" + Session["UserID"] + "," + 1 + ")");
                DropDownList1.DataTextField = "ChalanNo";
                DropDownList1.DataValueField = "ChallanTrno_I";
                DropDownList1.DataSource = ds1;
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Select");
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
                //CommonFuction comm = new CommonFuction();
                DataSet aasdf = comm.FillDatasetByProc("call GetPrinterName()");
                ddlPrinter.DataSource = aasdf.Tables[0];
                ddlPrinter.DataTextField = "NameofPress_V";
                ddlPrinter.DataValueField = "Printer_RedID_I";
                ddlPrinter.DataBind();
                ddlPrinter.Items.Insert(0, "Select");
            }
            catch { }
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
        try {
        //   DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter(" + Session["UserID"] + "," + DropDownList1.SelectedValue + ",'"+TextBox1.Text+"')");
        string txtVal = ddla.SelectedValue;
        string txtVal1 = txta.Text;
        string user = Session["UserID"].ToString();

        if (ddla.SelectedValue == "1" || ddla.SelectedValue == "2")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlPrinter.SelectedValue + "','" + txtFromdate.Text + "')");
        }
        if (ddla.SelectedValue == "3")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + txtFromdate.Text + "','" + txtTodate.Text + "')");
        }
        if (ddla.SelectedValue == "4")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlTital.SelectedValue + "','" + txtTodate.Text + "')");
        }
        if (ddla.SelectedValue == "5")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlMedium.SelectedValue + "','" + txtTodate.Text + "')");
        }
        if (ddla.SelectedValue == "6")
        {
            fillgrd = obCommonFuction.FillDatasetByProc("call USP_DPTPrinterChallanFileter (" + user + "," + txtVal + ",'" + ddlbookType.SelectedValue + "','" + txtTodate.Text + "')");
        }
        DropDownList1.DataTextField = "ChalanNo";
        DropDownList1.DataValueField = "ChallanTrno_I";
        DropDownList1.DataSource = fillgrd.Tables[0];
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void ddla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddla.SelectedValue == "1" || ddla.SelectedValue == "2")
        {
            txta.Visible = false;
            ddlPrinter.Visible = true;
            ddlbookType.Visible = false;
            ddlTital.Visible = false;
            ddlMedium.Visible = false;
            txtFromdate.Visible = false;
            txtTodate.Visible = false;

        }
        else if (ddla.SelectedValue == "3")
        {
            ddlPrinter.Visible = false;
            txta.Visible = false;
            ddlbookType.Visible = false;
            ddlTital.Visible = false;
            ddlMedium.Visible = false;
            txtFromdate.Visible = true;
            txtTodate.Visible = true;
        }
        else if (ddla.SelectedValue == "4")
        {
            ddlPrinter.Visible = false;
            txta.Visible = false;
            ddlbookType.Visible = false;
            ddlTital.Visible = true;
            ddlMedium.Visible = false;
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
            txtTodate.Visible = false; ddlPrinter.Visible = false;
        }
        else if (ddla.SelectedValue == "6")
        {
            txta.Visible = false;
            ddlbookType.Visible = true;
            ddlTital.Visible = false;
            ddlMedium.Visible = false;
            txtFromdate.Visible = false;
            txtTodate.Visible = false; ddlPrinter.Visible = false;
        }
    }
    List<Baecode> obBaecodeList = new List<Baecode>();
    protected void TxtCode_TextChanged(object sender, EventArgs e)
    {
        try{
           
        LblCode.Text = "बंडल नंबर : " + TxtCode.Text;

//        db.execute(@"select * from  dpt_stockdetails_t
//        inner join dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I
//        inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I
//        inner join prin001_challantitledetails on dpt_stockdetailschild_t.PriTransID=prin001_challantitledetails.PriTransID
//        inner join prin_deleverydetails on prin_deleverydetails.PriTransID=prin001_challantitledetails.PriTransID
//        inner join pri_printerregistration_t on pri_printerregistration_t.Printer_RedID_I=prin_deleverydetails.User_ID
//        where ISDepotstatus=0  and BundleNo_I ='" + TxtCode.Text + "' and (IsDistribute =9 or IsDistribute=7)and ChalanNo='" + DropDownList1.SelectedItem.Text + "' ", DBAccess.SQLType.IS_QUERY);
        DataSet dd = obCommonFuction.FillDatasetByProc("Call USP_DPT_BookDistribut('" + TxtCode.Text + "','" + DropDownList1.SelectedItem.Text + "',0)");
            
          
        if (dd.Tables[0].Rows.Count > 0)
        {
            Label1.Text = " ";
        }
        else
        {
            Label1.Text = "ये बण्डल इस चालान में नहीं है ";
        }

            //TxtCode.Text = "1090010516";

        obCommonFuction.FillDatasetByProc("call  USP_DPT_BookDistribut('" + TxtCode.Text + "','" + DropDownList1.SelectedItem.Text + "',002)");
//        DataSet ds = obCommonFuction.FillDatasetByProc(@"SELECT distinct prin001_challantitledetails.PriTransID,  dpt_stockdetailschild_t.StockDetailsID_I, ChalanNo,ChalanDate,NameofPress_V, acd_titledetail.TitleID_I, TitleHindi_V, case IsOpenMarket when 2 then 'सामान्य' else 'योज़ना' end as booktype , dpt_stockdetailschild_t.*
//        FROM         dpt_stockdetails_t
//        inner join dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I
//        inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I
//        inner join prin001_challantitledetails on dpt_stockdetailschild_t.PriTransID=prin001_challantitledetails.PriTransID
//        inner join prin_deleverydetails on prin_deleverydetails.PriTransID=prin001_challantitledetails.PriTransID
//        inner join pri_printerregistration_t on pri_printerregistration_t.Printer_RedID_I=prin_deleverydetails.User_ID
//        where ISDepotstatus=0  and BundleNo_I ='" + TxtCode.Text + "' and (IsDistribute =9 or IsDistribute=7);");

        DataSet ds = obCommonFuction.FillDatasetByProc("call  USP_DPT_BookDistribut('" + TxtCode.Text + "','" + DropDownList1.SelectedItem.Text + "',001)");

            foreach (GridViewRow grow in grdPrinterBundleDetails.Rows)
            {
                Baecode obBaecode = new Baecode();
               // obBaecode.booktype = ((Label)grow.FindControl("booktype")).Text;

                obBaecode.StockDetailsID_I = Convert.ToInt32(((HiddenField)(grow.FindControl("TitleID_I"))).Value);
                obBaecode.BundleNo_I = ((Label)grow.FindControl("BundleNo_I")).Text;
                obBaecode.ChalanNo = ((Label)grow.FindControl("ChalanNo")).Text;
                obBaecode.FromNo_I = ((Label)grow.FindControl("FromNo_I")).Text;
                obBaecode.ToNo_I = ((Label)grow.FindControl("ToNo_I")).Text;
                obBaecode.NameofPress_V = ((Label)grow.FindControl("NameofPress_V")).Text;
                obBaecode.TitleHindi_V = ((Label)grow.FindControl("TitleHindi_V")).Text;

                obBaecodeList.Add(obBaecode);
            }
            int count = 0;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                count++;
                Baecode obBaecode = new Baecode();
                obBaecode.StockDetailsID_I = Convert.ToInt32(item["TitleID_I"]);
                obBaecode.booktype = Convert.ToString(item["booktype"]);
                obBaecode.BundleNo_I = Convert.ToString(item["BundleNo_I"]);
                obBaecode.ChalanNo = Convert.ToString(item["ChalanNo"]);
                obBaecode.FromNo_I = Convert.ToString(item["FromNo_I"]);
                obBaecode.NameofPress_V = Convert.ToString(item["NameofPress_V"]);
                obBaecode.ToNo_I = Convert.ToString(item["ToNo_I"]);
                obBaecode.TitleHindi_V = Convert.ToString(item["TitleHindi_V"]);
                hdnId.Value = Convert.ToString(item["PriTransID"]);
                if (obBaecodeList.Where(r => r.BundleNo_I == obBaecode.BundleNo_I).Count() == 0)
                {
                    obBaecodeList.Add(obBaecode);
                }
            }

            DataSet DS = obCommonFuction.FillDatasetByProc("CALL USP_DISGetBundleInfo(  " + Convert.ToInt64(TxtCode.Text) + ")");
            if (DS.Tables[0].Rows.Count > 0 && count == 0)
            {
                var D = obBaecodeList.Where(b => b.NameofPress_V == DS.Tables[0].Rows[0]["NameofPress_V"].ToString());
                Baecode obBaecode = new Baecode();
                int check = 0;
                foreach (var item in D)
                {
                    if (check == 0)
                    {
                        obBaecode.NameofPress_V = DS.Tables[0].Rows[0]["NameofPress_V"].ToString();
                        if (DS.Tables[0].Rows[0]["BookType"].ToString() == "2")
                        {
                            obBaecode.booktype = "योज़ना";
                        }
                        else
                        {

                            obBaecode.booktype = "सामान्य";
                        }
                        Int32 frombook = 0;
                        Int32 tobook = 0;
                        Int32 perbunlbook = Convert.ToInt32(DS.Tables[0].Rows[0]["BooksPerBundle"].ToString());
                        Int32 frombunleNo = Convert.ToInt32(DS.Tables[0].Rows[0]["BundleNoFrom"].ToString());
                        Int32 bundleToSkip = Convert.ToInt32(TxtCode.Text) - frombunleNo + 1;


                        obBaecode.FromNo_I = (bundleToSkip * perbunlbook + Convert.ToInt32(DS.Tables[0].Rows[0]["BookNumberFrom"].ToString())).ToString();

                        obBaecode.BundleNo_I = TxtCode.Text;
                        obBaecode.ChalanNo = item.ChalanNo;
                        obBaecode.StockDetailsID_I = Convert.ToInt32(DS.Tables[0].Rows[0]["TitleID_I"].ToString());
                        obBaecode.NameofPress_V = DS.Tables[0].Rows[0]["NameofPress_V"].ToString();
                        obBaecode.ToNo_I = (Convert.ToInt32(obBaecode.FromNo_I) + perbunlbook - 1).ToString();
                        obBaecode.TitleHindi_V = DS.Tables[0].Rows[0]["TitleHindi_V"].ToString();
                    }
                    check++;

                }
                if (obBaecode.NameofPress_V != "")
                {
                    if (obBaecodeList.Where(r => r.BundleNo_I == obBaecode.BundleNo_I).Count() == 0)
                    {
                        obBaecodeList.Add(obBaecode);
                        StockDetails obStockDetails = new StockDetails();
                        obStockDetails.NoOfBooks_I = Convert.ToInt32(obBaecode.ToNo_I) - Convert.ToInt32(obBaecode.FromNo_I) + 1;


                        obStockDetails.Stock_ID_I = 0;
                        obStockDetails.SubJectID_I = obBaecode.StockDetailsID_I;
                        obStockDetails.Trans_I = 0;
                        if (obBaecode.booktype == "योज़ना")
                        {
                            obStockDetails.BookType_I = 2;

                        }
                        else
                        {
                            obStockDetails.BookType_I = 1;
                        }

                        int B = (int)obStockDetails.InsertUpdate();
                        StockDetailsChild obStockDetailsChild = new StockDetailsChild();
                        obStockDetailsChild.BundleNo_I = Convert.ToInt32(obBaecode.BundleNo_I);
                        obStockDetailsChild.FromNo_I = Convert.ToInt32(obBaecode.FromNo_I);
                        obStockDetailsChild.ToNo_I = Convert.ToInt32(obBaecode.ToNo_I);
                        obStockDetailsChild.StockDetailsID_I = B;
                        obStockDetailsChild.RemaingLoose_V = "";


                        int A = (int)obStockDetailsChild.InsertUpdate();
                        obCommonFuction.FillDatasetByProc("update dpt_stockdetailschild_t set IsDistribute=7 ,PriTransID='" + hdnId.Value + "' where StockDetailsChildID_I ='" + A + "'");
                    }

                }

            }
          
            grdPrinterBundleDetails.DataSource = obBaecodeList;
            grdPrinterBundleDetails.DataBind();
     
        }catch{}
        TxtCode.Text = "";
        TxtCode.Focus();

    }

    
    public class Baecode
    {
        public string ChalanNo { get; set; }
        public string Title_I { get; set; }
        public string NameofPress_V { get; set; }
        public string TitleHindi_V { get; set; }
        public string booktype { get; set; }
      
        public string BundleNo_I { get; set; }
        public string FromNo_I { get; set; }
        public string ToNo_I { get; set; }
        public int StockDetailsID_I { get; set;}
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InterDepoBookReceived.aspx");
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call PrinterDetails(" + Session["UserID"] + "," + DropDownList1.SelectedValue + ")");
            Label2.Text = "<b> प्रिंटर का नाम :</b> " + ds1.Tables[0].Rows[0]["NameofPress_V"].ToString();
            Label3.Text = "<b>पुस्तक का नाम :</b> " + ds1.Tables[0].Rows[0]["TitleHindi_V"].ToString();
            Label4.Text = "<b>पुस्तक का प्रकार :</b> " + ds1.Tables[0].Rows[0]["BookType"].ToString();
        }
        catch { }
    }
}
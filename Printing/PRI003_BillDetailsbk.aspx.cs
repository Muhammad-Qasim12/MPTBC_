using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;

public partial class Printing_PRI003_BillDetails : System.Web.UI.Page
{
    DataSet ds;
    Pri_BillDetails objBillDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    float TotalAmt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

           
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            
            PrinterFill();
            ViewState["BillID_I"] = "";
            if (Request.QueryString["ID"] != null)
            {   
                GridFillLoad();
            }
        }
    }

    public void GridFillLoad()
    {
        try
        {
            objBillDetails = new Pri_BillDetails();
            objBillDetails.BillID_I = int.Parse(Request.QueryString["ID"].ToString());
            ds = objBillDetails.FieldFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["BillDate_D"].ToString());
                txtBillDate.Text = dat.ToString("dd/MM/yyyy");
                txtBillNo.Text = ds.Tables[0].Rows[0]["Billno_V"].ToString();
                ViewState["BillID_I"] = Request.QueryString["ID"].ToString();
                ddlPrinter.ClearSelection();
                PrinterFill();
                ddlPrinter.Items.FindByValue(ds.Tables[0].Rows[0]["Printer_RedID_I"].ToString()).Selected = true;

                

                if (ddlPrinter.SelectedItem.Text != "Select")
                {
                    objBillDetails = new Pri_BillDetails();
                    objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
                    ds = objBillDetails.BillChildDetailsFill();
                    GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
                    GrdPaperCoverAndPrintingChares.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
                        txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
                    }
                    else
                    {
                        txtPaperSecurityDeposit.Text = "";
                        txtDepotExpenditure.Text = "";
                    }
                    PrinterpaperSupplyFill();
                    OnLoad();

                }                           
                txtTotalPaperSupply.Text = ds.Tables[0].Rows[0]["TotalPaperSup_N"].ToString();
                txtTotalCoverPaperSupply.Text = ds.Tables[0].Rows[0]["TotCovPaperSup_N"].ToString();
                txtPaperSecurityReimbursed.Text = ds.Tables[0].Rows[0]["PapSecReimburse_N"].ToString();
                txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["PaperSecurityDeposit"].ToString();
                txtBalancePaperSecurityReimbursed.Text = ds.Tables[0].Rows[0]["BalSecurity_N"].ToString();
                txtPrintingCharge.Text = ds.Tables[0].Rows[0]["PrnChrg100per_N"].ToString();
                txtPrintingCharge25Per.Text = ds.Tables[0].Rows[0]["PrnChrg25per_N"].ToString();
                txtPrintingCharge75Per.Text = ds.Tables[0].Rows[0]["PrnChrg75per_N"].ToString();
                txtPaperSecurityFor.Text = ds.Tables[0].Rows[0]["PaperSecforton_N"].ToString();
                txtReemPaperRs.Text = ds.Tables[0].Rows[0]["PaperReemRs_N"].ToString();
                txtTonsPerReem.Text = ds.Tables[0].Rows[0]["TonsPerReem_N"].ToString();
                txtReimburseAmount.Text = ds.Tables[0].Rows[0]["Reimburseamt_N"].ToString();
                txtPayBlePrintingCharg.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
                txtTotalPaybleAmount.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
                txtBFPay.Text = ds.Tables[0].Rows[0]["BFPay"].ToString();
                txt2PerInComeTAX.Text = ds.Tables[0].Rows[0]["DedIncometax_N"].ToString();
                txtDeductionPaperSecurity.Text = ds.Tables[0].Rows[0]["DedpapSec_N"].ToString();
                txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["DedDepoExp_N"].ToString();
                txtPaperInterest.Text = ds.Tables[0].Rows[0]["DedInterestonpaper_N"].ToString();
                txtDelaySupplyPenalty.Text = ds.Tables[0].Rows[0]["PenDelaySup_N"].ToString();
                txtShortSizeBookDeduction.Text = ds.Tables[0].Rows[0]["DedShotSizePaper1_N"].ToString();
                txtRs2.Text = ds.Tables[0].Rows[0]["DedShotSizePaper2_N"].ToString();
                txtRs3.Text = ds.Tables[0].Rows[0]["DedShotSizePaper3_N"].ToString();
                txtTotalDeduction.Text = ds.Tables[0].Rows[0]["TotalDed_N"].ToString();
                txtNetPayable.Text = ds.Tables[0].Rows[0]["NetPayable_N"].ToString();
                //txtBillAmount.Text = ds.Tables[0].Rows[0]["BillAmount"].ToString();
                //txtBillAmountofDeduction.Text = ds.Tables[0].Rows[0]["BillAmountofDeduction"].ToString();
                //txtBillNetPayablePrinting.Text = ds.Tables[0].Rows[0]["BillNetPayablePrinting"].ToString();
                GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
                GrdPaperCoverAndPrintingChares.DataBind();
                btnSendToFinance.Visible = true;
                pnlFinance.Visible = true;
                lblFinanceMsg.Visible = true;
                ddlPrinter.Enabled = false;
                lblFinanceMsg.Text = "Do You Want To Send Finance Department.";
                OnLoad();

            }
        }
        catch { }

    }


    public void PrinterFill()
    {
        objBillDetails = new Pri_BillDetails();
        ddlPrinter.DataSource = objBillDetails.PrinterDetailsFill();
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
      
    }


    public void PrinterpaperSupplyFill()
    {
        PRI_PaperAllotment obj = new PRI_PaperAllotment();
        try{
       
        DataSet ds1 = new DataSet();
        obj.Printer_RedID_I = Convert.ToInt32 ( ddlPrinter.SelectedValue);
        obj.AcadmicYR_V =Convert.ToString ( DdlACYear.SelectedValue);
        ds1 = obj.GetPrinterPaperSupply(); 
       if (ds1.Tables[0].Rows.Count>0) 
       {
           txtTotalPaperSupply.Text = ds1.Tables[0].Rows[0]["PriPaperQty_N"].ToString();

           txtTotalCoverPaperSupply.Text = ds1.Tables[0].Rows[0]["CovPaperQty_N"].ToString();
        }
       }
            catch {}

        finally { obj = null; }
    }

    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
       
    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrinter.SelectedItem.Text != "Select")
        {
            objBillDetails = new Pri_BillDetails();
            objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
            ds = objBillDetails.BillChildDetailsFill();
            GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
            GrdPaperCoverAndPrintingChares.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
                txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
            }
            else
            {
                txtPaperSecurityDeposit.Text = "";
                txtDepotExpenditure.Text = "";
            }
            PrinterpaperSupplyFill();
            OnLoad();

        }
        else
        {
            GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
            GrdPaperCoverAndPrintingChares.DataBind();
            txtPrintingCharge.Text = "0";
            txtPrintingCharge25Per.Text = "0";
            txtPrintingCharge75Per.Text = "0";
        }
    }

    protected void txtBlankPages_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        Label lblRate_N = (Label)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");



        float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0;
        try
        {
            Page = float.Parse(lblPages_N.Text);
        }
        catch { }
        try
        {
            BlankPage = float.Parse(txt.Text);
        }
        catch { }
        TotalPage = Page - BlankPage;

        

        try
        { Qty = float.Parse(lblTotalNoBook.Text); }
        catch { Qty = 0; }
        try
        { Rate = float.Parse(lblRate_N.Text); }
        catch { Rate = 0; }
        lblTotalBlankPages_N.Text =  (Qty * BlankPage).ToString();

        Amt = (Qty * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round (  Amt,0).ToString("0.00");
        try
        {

            CalAmt();
        }
        catch { }

    }
    protected void GrdPaperCoverAndPrintingChares_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    public void CalAmt()
    {
        try
        {
            double Amount = 0;
            foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
            {
                Label lblAmount = (Label)gv.FindControl("lblAmount");
                try
                {
                    if (lblAmount.Text == "")
                    {
                        lblAmount.Text = "0";
                    }
                    Amount = Amount + float.Parse(lblAmount.Text);
                }
                catch { }

            }
            Amount = Math.Round(Amount,0);
            txtPrintingCharge.Text = Amount.ToString("0.00");
            txtPrintingCharge25Per.Text = Math.Round(((Amount * 25) / 100),0).ToString("0.00");
            txtPrintingCharge75Per.Text =Math.Round( ((Amount * 75) / 100),0).ToString("0.00");
            OnLoad();
        }
        catch { }
    }
    public void isEmpty()
    {
        if (txt2PerInComeTAX.Text == "")
        { txt2PerInComeTAX.Text = "0"; }

        if (txtBalancePaperSecurityReimbursed.Text == "")
        { txtBalancePaperSecurityReimbursed.Text = "0"; }
        if (txtBFPay.Text == "")
        { txtBFPay.Text = "0"; }
        if (txtBillAmount.Text == "")
        { txtBillAmount.Text = "0"; }

        if (txtBillAmountofDeduction.Text == "")
        { txtBillAmountofDeduction.Text = "0"; }
        if (txtBillNetPayablePrinting.Text == "")
        { txtBillNetPayablePrinting.Text = "0"; }
        if (txtDeductionPaperSecurity.Text == "")
        { txtDeductionPaperSecurity.Text = "0"; }
        if (txtDelaySupplyPenalty.Text == "")
        { txtDelaySupplyPenalty.Text = "0"; }
        if (txtDepotExpenditure.Text == "")
        { txtDepotExpenditure.Text = "0"; }
        if (txtNetPayable.Text == "")
        { txtNetPayable.Text = "0"; }


        if (txtPaperInterest.Text == "")
        { txtPaperInterest.Text = "0"; }
        if (txtPaperSecurityDeposit.Text == "")
        { txtPaperSecurityDeposit.Text = "0"; }
        if (txtPaperSecurityFor.Text == "")
        { txtPaperSecurityFor.Text = "0"; }
        if (txtPaperSecurityReimbursed.Text == "")
        { txtPaperSecurityReimbursed.Text = "0"; }
        if (txtPayBlePrintingCharg.Text == "")
        { txtPayBlePrintingCharg.Text = "0"; }
        if (txtPrintingCharge.Text == "")
        { txtPrintingCharge.Text = "0"; }


        if (txtPrintingCharge25Per.Text == "")
        { txtPrintingCharge25Per.Text = "0"; }
        if (txtPrintingCharge75Per.Text == "")
        { txtPrintingCharge75Per.Text = "0"; }
        if (txtReemPaperRs.Text == "")
        { txtReemPaperRs.Text = "0"; }
        if (txtReimburseAmount.Text == "")
        { txtReimburseAmount.Text = "0"; }
        if (txtRs2.Text == "")
        { txtRs2.Text = "0"; }
        if (txtRs3.Text == "")
        { txtRs3.Text = "0"; }

        if (txtShortSizeBookDeduction.Text == "")
        { txtShortSizeBookDeduction.Text = "0"; }
        if (txtTonsPerReem.Text == "")
        { txtTonsPerReem.Text = "0"; }
        if (txtTotalCoverPaperSupply.Text == "")
        { txtTotalCoverPaperSupply.Text = "0"; }
        if (txtTotalDeduction.Text == "")
        { txtTotalDeduction.Text = "0"; }


        if (txtTotalPaperSupply.Text == "")
        { txtTotalPaperSupply.Text = "0"; }
        if (txtTotalPaybleAmount.Text == "")
        { txtTotalPaybleAmount.Text = "0"; }

    }
    protected void btnForward_Click(object sender, EventArgs e)
    {
        objBillDetails = new Pri_BillDetails();

        objBillDetails.Billno_V = txtBillNo.Text;
        objBillDetails.BillDate_D = DateTime.Parse(txtBillDate.Text, cult);
        objBillDetails.PrinterID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
        objBillDetails.TotalPaperSup_N = float.Parse(txtTotalPaperSupply.Text);
        objBillDetails.TotCovPaperSup_N = float.Parse(txtTotalCoverPaperSupply.Text);
        objBillDetails.PapSecReimburse_N = float.Parse(txtPaperSecurityReimbursed.Text);
        objBillDetails.PaperSecurityDeposit = float.Parse(txtPaperSecurityDeposit.Text);
        objBillDetails.BalSecurity_N = float.Parse(txtBalancePaperSecurityReimbursed.Text);
        objBillDetails.PrnChrg100per_N = float.Parse(txtPrintingCharge.Text);
        objBillDetails.PrnChrg25per_N = float.Parse(txtPrintingCharge25Per.Text);
        objBillDetails.PrnChrg75per_N = float.Parse(txtPrintingCharge75Per.Text);
        objBillDetails.PaperSecforton_N = float.Parse(txtPaperSecurityFor.Text);
        objBillDetails.PaperReemRs_N = float.Parse(txtReemPaperRs.Text);
        objBillDetails.TonsPerReem_N = float.Parse(txtTonsPerReem.Text);
        objBillDetails.Reimburseamt_N = float.Parse(txtReimburseAmount.Text);
        objBillDetails.PayablePrnchrg_N = float.Parse(txtTotalPaybleAmount.Text);
        objBillDetails.Totalpayable_N = float.Parse(txtTotalPaybleAmount.Text);
        objBillDetails.BFPay = float.Parse(txtBFPay.Text);
        objBillDetails.DedIncometax_N = float.Parse(txt2PerInComeTAX.Text);
        objBillDetails.DedpapSec_N = float.Parse(txtDeductionPaperSecurity.Text);
        objBillDetails.DedDepoExp_N = float.Parse(txtDepotExpenditure.Text);
        objBillDetails.DedInterestonpaper_N = float.Parse(txtPaperInterest.Text);
        objBillDetails.PenDelaySup_N = float.Parse(txtDelaySupplyPenalty.Text);
        objBillDetails.DedShotSizePaper1_N = float.Parse(txtShortSizeBookDeduction.Text);
        objBillDetails.DedShotSizePaper2_N = float.Parse(txtRs2.Text);
        objBillDetails.DedShotSizePaper3_N = float.Parse(txtRs3.Text);
        objBillDetails.TotalDed_N = float.Parse(txtTotalDeduction.Text);
        objBillDetails.NetPayable_N = float.Parse(txtNetPayable.Text);
        objBillDetails.BillAmount = 0;
        objBillDetails.BillAmountofDeduction = 0;
        objBillDetails.BillNetPayablePrinting = 0;
        objBillDetails.JobCode_V = "";
        if (Request.QueryString["ID"] != null)
        {
            objBillDetails.BillID_I = int.Parse(Request.QueryString["ID"].ToString());
        }
        else
        {
            objBillDetails.BillID_I = 0;
        }

        if (Request.QueryString["ID"] != null)
        {
            int i = objBillDetails.MasterUpdate();
            if (i > 0)
            {
                string CheckSts = "No";
                foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
                {
                    Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                    Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
                    Label lblRate_N = (Label)gv.FindControl("lblRate_N");
                    Label lblBillDetID_I = (Label)gv.FindControl("lblBillDetID_I");
                    Label lblPages_N = (Label)gv.FindControl("lblPages_N");
                    Label lblAmount = (Label)gv.FindControl("lblAmount");
                    Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
                    TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");
                    TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
                    TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");


                    if (txtPaperConsum_Wastage_N.Text == "")
                    { txtPaperConsum_Wastage_N.Text = "0"; }

                    if (txtCoverPaperConsum_Wastage_N.Text == "")
                    { txtCoverPaperConsum_Wastage_N.Text = "0"; }

                    if (txtBlankPages.Text == "")
                    { txtBlankPages.Text = "0"; }

                    if (lblTotalBlankPages_N.Text == "")
                    { lblTotalBlankPages_N.Text = "0"; }
                    if (lblAmount.Text == "")
                    { lblAmount.Text = "0"; }
                    objBillDetails.Depotid_I = 0;
                    objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
                    objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
                    objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
                    objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
                    objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
                    objBillDetails.Amount_N = float.Parse(lblAmount.Text);
                    objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
                    objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
                    objBillDetails.BillID_I = 0;
                    objBillDetails.BillDetID_I = int.Parse(lblBillDetID_I.Text);
                    objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);

                    objBillDetails.ChildInsertUpdate();
                    CheckSts = "Ok";
                }
                if (CheckSts == "Ok")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    Response.Redirect("ViewBillDetails.aspx");
                    obCommonFuction.EmptyTextBoxes(this);
                    isEmpty();
                    GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
                    GrdPaperCoverAndPrintingChares.DataBind();
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Not Changed.');</script>");
            }
        }
        else
        {
            int i = objBillDetails.InsertUpdate();
            if (i > 0)
            {
                ViewState["BillID_I"] = i.ToString();
                string CheckSts = "No";
                foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
                {
                    Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                    Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
                    Label lblRate_N = (Label)gv.FindControl("lblRate_N");

                    Label lblPages_N = (Label)gv.FindControl("lblPages_N");
                    Label lblAmount = (Label)gv.FindControl("lblAmount");
                    TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
                    TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");
                    Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
                    TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");

                    if (txtPaperConsum_Wastage_N.Text == "")
                    { txtPaperConsum_Wastage_N.Text = "0"; }

                    if (txtCoverPaperConsum_Wastage_N.Text == "")
                    { txtCoverPaperConsum_Wastage_N.Text = "0"; }
                    if (lblAmount.Text == "")
                    { lblAmount.Text = "0"; }

                    if (txtBlankPages.Text == "")
                    { txtBlankPages.Text = "0"; }

                    if (lblTotalBlankPages_N.Text == "")
                    { lblTotalBlankPages_N.Text = "0"; }

                    objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
                    objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
                    objBillDetails.Depotid_I = 0;
                    objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
                    objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
                    objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
                    objBillDetails.Amount_N = float.Parse(lblAmount.Text);
                    objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
                    objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
                    objBillDetails.BillID_I = i;
                    objBillDetails.BillDetID_I = 0;
                    objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);

                    objBillDetails.ChildInsertUpdate();
                    CheckSts = "Ok";
                }
                if (CheckSts == "Ok")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    obCommonFuction.EmptyTextBoxes(this);
                    isEmpty();
                    GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
                    GrdPaperCoverAndPrintingChares.DataBind();
                    lblFinanceMsg.Text = "Record saved successfully! Do You Want To Send Finance Department.";
                    btnSendToFinance.Visible = true;
                    lblFinanceMsg.Visible = true;
                    btnForward.Visible = false;
                    pnlFinance.Visible = true;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Check Your Entry');</script>");
                   
                }
            }
        }

    }
    protected void btnSendToFinance_Click(object sender, EventArgs e)
    {
        objBillDetails = new Pri_BillDetails();
        objBillDetails.BillID_I = int.Parse(ViewState["BillID_I"].ToString());
        int i = objBillDetails.SendToFinance();
        if (i > 0)
        {
            Response.Redirect("ViewBillDetails.aspx");
        }
    }



    public void AmtCalPaper()
    {
        float perSecAmt = 0, perSecRemin = 0;
        try
        {
            perSecAmt = float.Parse(txtPaperSecurityDeposit.Text);
        }
        catch { }
        try
        {
            perSecRemin = float.Parse(txtPaperSecurityReimbursed.Text);
        }
        catch { }

        txtBalancePaperSecurityReimbursed.Text = (perSecAmt - perSecRemin).ToString("0.00");
    }
    public void OnLoad()
    {
        BillDesctionSection();
        TotDeduction();
        AbCal();
        NetPayDeduction();
        BillAmountCal();
        AmtCalPaper();
    }
    public void BillDesctionSection()
    {
        float PrintingCharge75Per = 0, ReimburseAmount = 0, PayBlePrintingCharg = 0, Totamt = 0;
        try
        {
            PrintingCharge75Per = float.Parse(txtPrintingCharge75Per.Text);
        }
        catch { }

        try
        {
            ReimburseAmount = float.Parse(txtReimburseAmount.Text);
        }
        catch { }

        try
        {
            PayBlePrintingCharg = float.Parse(txtPayBlePrintingCharg.Text);
        }
        catch { }
        try
        {
            Totamt = PrintingCharge75Per + ReimburseAmount + PayBlePrintingCharg;
        }
        catch { }

        txtTotalPaybleAmount.Text = Totamt.ToString("0.00");
        TotDeduction();
    }

    public void TotDeduction()
    {
        float PerInComeTAX = 0, DeductionPaperSecurity = 0, DepotExpenditure = 0, PaperInterest = 0, DelaySupplyPenalty = 0, ShortSizeBookDeduction = 0, Totamt = 0;
        try
        {
            PerInComeTAX = float.Parse(txt2PerInComeTAX.Text);
        }
        catch { PerInComeTAX = 0; }
        try
        {
            DeductionPaperSecurity = float.Parse(txtDeductionPaperSecurity.Text);
        }
        catch { DeductionPaperSecurity = 0; }

        try
        {
            DepotExpenditure = float.Parse(txtDepotExpenditure.Text);
        }
        catch { DepotExpenditure = 0; }
        try
        {
            PaperInterest = float.Parse(txtPaperInterest.Text);
        }
        catch { PaperInterest = 0; }

        try
        {
            DelaySupplyPenalty = float.Parse(txtDelaySupplyPenalty.Text);
        }
        catch { DelaySupplyPenalty = 0; }

        try
        {
            ShortSizeBookDeduction = float.Parse(txtShortSizeBookDeduction.Text);
        }
        catch { ShortSizeBookDeduction = 0; }

        Totamt = (PerInComeTAX + DeductionPaperSecurity + DepotExpenditure + PaperInterest + DelaySupplyPenalty + ShortSizeBookDeduction);
        txtTotalDeduction.Text = Totamt.ToString("0.00");
        AbCal();

    }

    public void AbCal()
    {
        float amt = 0, TotalPayAmt = 0, TotalDeduc = 0;
        try
        {
            TotalPayAmt = float.Parse(txtTotalPaybleAmount.Text);
        }
        catch { }
        try
        {
            TotalDeduc = float.Parse(txtTotalDeduction.Text);
        }
        catch { }
        amt = TotalPayAmt - TotalDeduc;
        txtNetPayable.Text = amt.ToString("0.00");
        NetPayDeduction();

    }

    public void NetPayDeduction()
    {

        txtBillAmountofDeduction.Text = txtNetPayable.Text;
        BillAmountCal();
    }
    public void BillAmountCal()
    {

        txtBillAmount.Text = txtTotalPaybleAmount.Text;
        txtBillAmountofDeduction.Text = txtTotalDeduction.Text;
        txtBillNetPayablePrinting.Text = txtNetPayable.Text;
    }
    protected void txtReimburseAmount_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPrintingCharge75Per_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPayBlePrintingCharg_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txt2PerInComeTAX_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDeductionPaperSecurity_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDepotExpenditure_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPaperInterest_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDelaySupplyPenalty_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtShortSizeBookDeduction_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtTotalDeduction_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
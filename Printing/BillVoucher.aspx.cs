using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Printing_BillVoucher : System.Web.UI.Page
{
    DataSet ds;
    Pri_BillDetails objBillDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    float TotalAmt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    ViewState["BillID_I"] = "";
        //    if (Request.QueryString["ID"] != null)
        //    {
        //        GridFillLoad();
        //    }
        //}
    }

    //public void GridFillLoad()
    //{
    //    try
    //    {
    //        objBillDetails = new Pri_BillDetails();
    //        objBillDetails.BillID_I = int.Parse(Request.QueryString["ID"].ToString());
    //        ds = objBillDetails.FieldFill();
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            DateTime dat = new DateTime();
    //            dat = DateTime.Parse(ds.Tables[0].Rows[0]["BillDate_D"].ToString());
    //            txtBillDate.Text = dat.ToString("dd/MM/yyyy");
    //            txtBillNo.Text = ds.Tables[0].Rows[0]["Billno_V"].ToString();
    //            ViewState["BillID_I"] = Request.QueryString["ID"].ToString();

    //            PrinterFill();
    //            ddlPrinter.ClearSelection();
    //            ddlPrinter.Items.FindByValue(ds.Tables[0].Rows[0]["Printer_RedID_I"].ToString()).Selected = true;
    //            txtTotalPaperSupply.Text = ds.Tables[0].Rows[0]["TotalPaperSup_N"].ToString();
    //            txtTotalCoverPaperSupply.Text = ds.Tables[0].Rows[0]["TotCovPaperSup_N"].ToString();
    //            txtPaperSecurityReimbursed.Text = ds.Tables[0].Rows[0]["PapSecReimburse_N"].ToString();
    //            txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["PaperSecurityDeposit"].ToString();
    //            txtBalancePaperSecurityReimbursed.Text = ds.Tables[0].Rows[0]["BalSecurity_N"].ToString();
    //            txtPrintingCharge.Text = ds.Tables[0].Rows[0]["PrnChrg100per_N"].ToString();
    //            txtPrintingCharge25Per.Text = ds.Tables[0].Rows[0]["PrnChrg25per_N"].ToString();
    //            txtPrintingCharge75Per.Text = ds.Tables[0].Rows[0]["PrnChrg75per_N"].ToString();
    //            txtPaperSecurityFor.Text = ds.Tables[0].Rows[0]["PaperSecforton_N"].ToString();
    //            txtReemPaperRs.Text = ds.Tables[0].Rows[0]["PaperReemRs_N"].ToString();
    //            txtTonsPerReem.Text = ds.Tables[0].Rows[0]["TonsPerReem_N"].ToString();
    //            txtReimburseAmount.Text = ds.Tables[0].Rows[0]["Reimburseamt_N"].ToString();
    //            txtPayBlePrintingCharg.Text = ds.Tables[0].Rows[0]["PayablePrnchrg_N"].ToString();
    //            txtTotalPaybleAmount.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
    //            txtBFPay.Text = ds.Tables[0].Rows[0]["BFPay"].ToString();
    //            txt2PerInComeTAX.Text = ds.Tables[0].Rows[0]["DedIncometax_N"].ToString();
    //            txtDeductionPaperSecurity.Text = ds.Tables[0].Rows[0]["DedpapSec_N"].ToString();
    //            txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["DedDepoExp_N"].ToString();
    //            txtPaperInterest.Text = ds.Tables[0].Rows[0]["DedInterestonpaper_N"].ToString();
    //            txtDelaySupplyPenalty.Text = ds.Tables[0].Rows[0]["PenDelaySup_N"].ToString();
    //            txtShortSizeBookDeduction.Text = ds.Tables[0].Rows[0]["DedShotSizePaper1_N"].ToString();
    //            txtRs2.Text = ds.Tables[0].Rows[0]["DedShotSizePaper2_N"].ToString();
    //            txtRs3.Text = ds.Tables[0].Rows[0]["DedShotSizePaper3_N"].ToString();
    //            txtTotalDeduction.Text = ds.Tables[0].Rows[0]["TotalDed_N"].ToString();
    //            txtNetPayable.Text = ds.Tables[0].Rows[0]["NetPayable_N"].ToString();
    //            //txtBillAmount.Text = ds.Tables[0].Rows[0]["BillAmount"].ToString();
    //            //txtBillAmountofDeduction.Text = ds.Tables[0].Rows[0]["BillAmountofDeduction"].ToString();
    //            //txtBillNetPayablePrinting.Text = ds.Tables[0].Rows[0]["BillNetPayablePrinting"].ToString();

    //            GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
    //            GrdPaperCoverAndPrintingChares.DataBind();
    //            btnSendToFinance.Visible = true;
    //            pnlFinance.Visible = true;
    //            lblFinanceMsg.Visible = true;
    //            ddlPrinter.Enabled = false;
    //            lblFinanceMsg.Text = "Do You Want To Send Finance Department.";
    //            OnLoad();

    //        }
    //    }
    //    catch { }

    //}


    public void PrinterFill()
    {
        objBillDetails = new Pri_BillDetails();
        ddlPrinter.DataSource = objBillDetails.PrinterDetailsFill();
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
    }


    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
        PrinterFill();
    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlPrinter.SelectedItem.Text != "Select")
        //{
        //    objBillDetails = new Pri_BillDetails();
        //    objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
        //    ds = objBillDetails.BillChildDetailsFill();
        //    GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
        //    GrdPaperCoverAndPrintingChares.DataBind();
        //    txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
        //    txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
        //    OnLoad();

        //}
        //else
        //{
        //    GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
        //    GrdPaperCoverAndPrintingChares.DataBind();
        //    txtPrintingCharge.Text = "0";
        //    txtPrintingCharge25Per.Text = "0";
        //    txtPrintingCharge75Per.Text = "0";
        //}
    }

    //protected void txtBlankPages_TextChanged(object sender, EventArgs e)
    //{
    //    TextBox txt = (TextBox)sender;
    //    GridViewRow gv = (GridViewRow)txt.NamingContainer;
    //    Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
    //    Label lblRate_N = (Label)gv.FindControl("lblRate_N");
    //    Label lblAmount = (Label)gv.FindControl("lblAmount");
    //    Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
    //    Label lblPages_N = (Label)gv.FindControl("lblPages_N");



    //    float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0;
    //    try
    //    {
    //        Page = float.Parse(lblPages_N.Text);
    //    }
    //    catch { }
    //    try
    //    {
    //        BlankPage = float.Parse(txt.Text);
    //    }
    //    catch { }
    //    TotalPage = Page - BlankPage;

    //    lblTotalBlankPages_N.Text = TotalPage.ToString();


    //    try
    //    { Qty = float.Parse(lblTotalNoBook.Text); }
    //    catch { Qty = 0; }
    //    try
    //    { Rate = float.Parse(lblRate_N.Text); }
    //    catch { Rate = 0; }

    //    Amt = (Qty * Rate * TotalPage) / 8000;

    //    lblAmount.Text = Amt.ToString("0.00");
    //    try
    //    {

    //        CalAmt();
    //    }
    //    catch { }

    //}
    //protected void GrdPaperCoverAndPrintingChares_RowDataBound(object sender, GridViewRowEventArgs e)
    //{

    //}
    //public void CalAmt()
    //{
    //    try
    //    {
    //        float Amount = 0;
    //        foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
    //        {
    //            Label lblAmount = (Label)gv.FindControl("lblAmount");
    //            try
    //            {
    //                if (lblAmount.Text == "")
    //                {
    //                    lblAmount.Text = "0";
    //                }
    //                Amount = Amount + float.Parse(lblAmount.Text);
    //            }
    //            catch { }

    //        }

    //        txtPrintingCharge.Text = Amount.ToString("0.00");
    //        txtPrintingCharge25Per.Text = ((Amount * 25) / 100).ToString("0.00");
    //        txtPrintingCharge75Per.Text = ((Amount * 75) / 100).ToString("0.00");
    //        OnLoad();
    //    }
    //    catch { }
    //}
    //public void isEmpty()
    //{
    //    if (txt2PerInComeTAX.Text == "")
    //    { txt2PerInComeTAX.Text = "0"; }

    //    if (txtBalancePaperSecurityReimbursed.Text == "")
    //    { txtBalancePaperSecurityReimbursed.Text = "0"; }
    //    if (txtBFPay.Text == "")
    //    { txtBFPay.Text = "0"; }
    //    if (txtBillAmount.Text == "")
    //    { txtBillAmount.Text = "0"; }

    //    if (txtBillAmountofDeduction.Text == "")
    //    { txtBillAmountofDeduction.Text = "0"; }
    //    if (txtBillNetPayablePrinting.Text == "")
    //    { txtBillNetPayablePrinting.Text = "0"; }
    //    if (txtDeductionPaperSecurity.Text == "")
    //    { txtDeductionPaperSecurity.Text = "0"; }
    //    if (txtDelaySupplyPenalty.Text == "")
    //    { txtDelaySupplyPenalty.Text = "0"; }
    //    if (txtDepotExpenditure.Text == "")
    //    { txtDepotExpenditure.Text = "0"; }
    //    if (txtNetPayable.Text == "")
    //    { txtNetPayable.Text = "0"; }


    //    if (txtPaperInterest.Text == "")
    //    { txtPaperInterest.Text = "0"; }
    //    if (txtPaperSecurityDeposit.Text == "")
    //    { txtPaperSecurityDeposit.Text = "0"; }
    //    if (txtPaperSecurityFor.Text == "")
    //    { txtPaperSecurityFor.Text = "0"; }
    //    if (txtPaperSecurityReimbursed.Text == "")
    //    { txtPaperSecurityReimbursed.Text = "0"; }
    //    if (txtPayBlePrintingCharg.Text == "")
    //    { txtPayBlePrintingCharg.Text = "0"; }
    //    if (txtPrintingCharge.Text == "")
    //    { txtPrintingCharge.Text = "0"; }


    //    if (txtPrintingCharge25Per.Text == "")
    //    { txtPrintingCharge25Per.Text = "0"; }
    //    if (txtPrintingCharge75Per.Text == "")
    //    { txtPrintingCharge75Per.Text = "0"; }
    //    if (txtReemPaperRs.Text == "")
    //    { txtReemPaperRs.Text = "0"; }
    //    if (txtReimburseAmount.Text == "")
    //    { txtReimburseAmount.Text = "0"; }
    //    if (txtRs2.Text == "")
    //    { txtRs2.Text = "0"; }
    //    if (txtRs3.Text == "")
    //    { txtRs3.Text = "0"; }

    //    if (txtShortSizeBookDeduction.Text == "")
    //    { txtShortSizeBookDeduction.Text = "0"; }
    //    if (txtTonsPerReem.Text == "")
    //    { txtTonsPerReem.Text = "0"; }
    //    if (txtTotalCoverPaperSupply.Text == "")
    //    { txtTotalCoverPaperSupply.Text = "0"; }
    //    if (txtTotalDeduction.Text == "")
    //    { txtTotalDeduction.Text = "0"; }


    //    if (txtTotalPaperSupply.Text == "")
    //    { txtTotalPaperSupply.Text = "0"; }
    //    if (txtTotalPaybleAmount.Text == "")
    //    { txtTotalPaybleAmount.Text = "0"; }

    //}
    protected void btnForward_Click(object sender, EventArgs e)
    {
        //    objBillDetails = new Pri_BillDetails();

        //    objBillDetails.Billno_V = txtBillNo.Text;
        //    objBillDetails.BillDate_D = DateTime.Parse(txtBillDate.Text, cult);
        //    objBillDetails.PrinterID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
        //    objBillDetails.TotalPaperSup_N = float.Parse(txtTotalPaperSupply.Text);
        //    objBillDetails.TotCovPaperSup_N = float.Parse(txtTotalCoverPaperSupply.Text);
        //    objBillDetails.PapSecReimburse_N = float.Parse(txtPaperSecurityReimbursed.Text);
        //    objBillDetails.PaperSecurityDeposit = float.Parse(txtPaperSecurityDeposit.Text);
        //    objBillDetails.BalSecurity_N = float.Parse(txtBalancePaperSecurityReimbursed.Text);
        //    objBillDetails.PrnChrg100per_N = float.Parse(txtPrintingCharge.Text);
        //    objBillDetails.PrnChrg25per_N = float.Parse(txtPrintingCharge25Per.Text);
        //    objBillDetails.PrnChrg75per_N = float.Parse(txtPrintingCharge75Per.Text);
        //    objBillDetails.PaperSecforton_N = float.Parse(txtPaperSecurityFor.Text);
        //    objBillDetails.PaperReemRs_N = float.Parse(txtReemPaperRs.Text);
        //    objBillDetails.TonsPerReem_N = float.Parse(txtTonsPerReem.Text);
        //    objBillDetails.Reimburseamt_N = float.Parse(txtReimburseAmount.Text);
        //    objBillDetails.PayablePrnchrg_N = float.Parse(txtPayBlePrintingCharg.Text);
        //    objBillDetails.Totalpayable_N = float.Parse(txtTotalPaybleAmount.Text);
        //    objBillDetails.BFPay = float.Parse(txtBFPay.Text);
        //    objBillDetails.DedIncometax_N = float.Parse(txt2PerInComeTAX.Text);
        //    objBillDetails.DedpapSec_N = float.Parse(txtDeductionPaperSecurity.Text);
        //    objBillDetails.DedDepoExp_N = float.Parse(txtDepotExpenditure.Text);
        //    objBillDetails.DedInterestonpaper_N = float.Parse(txtPaperInterest.Text);
        //    objBillDetails.PenDelaySup_N = float.Parse(txtDelaySupplyPenalty.Text);
        //    objBillDetails.DedShotSizePaper1_N = float.Parse(txtShortSizeBookDeduction.Text);
        //    objBillDetails.DedShotSizePaper2_N = float.Parse(txtRs2.Text);
        //    objBillDetails.DedShotSizePaper3_N = float.Parse(txtRs3.Text);
        //    objBillDetails.TotalDed_N = float.Parse(txtTotalDeduction.Text);
        //    objBillDetails.NetPayable_N = float.Parse(txtNetPayable.Text);
        //    objBillDetails.BillAmount = 0;
        //    objBillDetails.BillAmountofDeduction = 0;
        //    objBillDetails.BillNetPayablePrinting = 0;
        //    objBillDetails.JobCode_V = "";
        //    if (Request.QueryString["ID"] != null)
        //    {
        //        objBillDetails.BillID_I = int.Parse(Request.QueryString["ID"].ToString());
        //    }
        //    else
        //    {
        //        objBillDetails.BillID_I = 0;
        //    }

        //    if (Request.QueryString["ID"] != null)
        //    {
        //        int i = objBillDetails.MasterUpdate();
        //        if (i > 0)
        //        {
        //            string CheckSts = "No";
        //            foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
        //            {
        //                Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
        //                Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        //                Label lblRate_N = (Label)gv.FindControl("lblRate_N");
        //                Label lblBillDetID_I = (Label)gv.FindControl("lblBillDetID_I");
        //                Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        //                Label lblAmount = (Label)gv.FindControl("lblAmount");
        //                Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        //                TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");
        //                TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
        //                TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");


        //                if (txtPaperConsum_Wastage_N.Text == "")
        //                { txtPaperConsum_Wastage_N.Text = "0"; }

        //                if (txtCoverPaperConsum_Wastage_N.Text == "")
        //                { txtCoverPaperConsum_Wastage_N.Text = "0"; }

        //                if (txtBlankPages.Text == "")
        //                { txtBlankPages.Text = "0"; }

        //                if (lblTotalBlankPages_N.Text == "")
        //                { lblTotalBlankPages_N.Text = "0"; }
        //                if (lblAmount.Text == "")
        //                { lblAmount.Text = "0"; }
        //                objBillDetails.Depotid_I = 0;
        //                objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
        //                objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
        //                objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
        //                objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
        //                objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
        //                objBillDetails.Amount_N = float.Parse(lblAmount.Text);
        //                objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
        //                objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
        //                objBillDetails.BillID_I = 0;
        //                objBillDetails.BillDetID_I = int.Parse(lblBillDetID_I.Text);
        //                objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);

        //                objBillDetails.ChildInsertUpdate();
        //                CheckSts = "Ok";
        //            }
        //            if (CheckSts == "Ok")
        //            {
        //                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
        //                Response.Redirect("ViewBillDetails.aspx");
        //                obCommonFuction.EmptyTextBoxes(this);
        //                isEmpty();
        //                GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
        //                GrdPaperCoverAndPrintingChares.DataBind();
        //            }

        //        }
        //        else
        //        {
        //            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Not Changed.');</script>");
        //        }
        //    }
        //    else
        //    {
        //        int i = objBillDetails.InsertUpdate();
        //        if (i > 0)
        //        {
        //            ViewState["BillID_I"] = i.ToString();
        //            string CheckSts = "No";
        //            foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
        //            {
        //                Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
        //                Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        //                Label lblRate_N = (Label)gv.FindControl("lblRate_N");

        //                Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        //                Label lblAmount = (Label)gv.FindControl("lblAmount");
        //                TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
        //                TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        //                Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        //                TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");

        //                if (txtPaperConsum_Wastage_N.Text == "")
        //                { txtPaperConsum_Wastage_N.Text = "0"; }

        //                if (txtCoverPaperConsum_Wastage_N.Text == "")
        //                { txtCoverPaperConsum_Wastage_N.Text = "0"; }
        //                if (lblAmount.Text == "")
        //                { lblAmount.Text = "0"; }

        //                if (txtBlankPages.Text == "")
        //                { txtBlankPages.Text = "0"; }

        //                if (lblTotalBlankPages_N.Text == "")
        //                { lblTotalBlankPages_N.Text = "0"; }

        //                objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
        //                objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
        //                objBillDetails.Depotid_I = 0;
        //                objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
        //                objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
        //                objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
        //                objBillDetails.Amount_N = float.Parse(lblAmount.Text);
        //                objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
        //                objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
        //                objBillDetails.BillID_I = i;
        //                objBillDetails.BillDetID_I = 0;
        //                objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);

        //                objBillDetails.ChildInsertUpdate();
        //                CheckSts = "Ok";
        //            }
        //            if (CheckSts == "Ok")
        //            {
        //                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
        //                obCommonFuction.EmptyTextBoxes(this);
        //                isEmpty();
        //                GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
        //                GrdPaperCoverAndPrintingChares.DataBind();
        //                lblFinanceMsg.Text = "Record saved successfully! Do You Want To Send Finance Department.";
        //                btnSendToFinance.Visible = true;
        //                lblFinanceMsg.Visible = true;
        //                btnForward.Visible = false;
        //                pnlFinance.Visible = true;
        //            }
        //        }
        //    }

    }
    //protected void btnSendToFinance_Click(object sender, EventArgs e)
    //{
    //    objBillDetails = new Pri_BillDetails();
    //    objBillDetails.BillID_I = int.Parse(ViewState["BillID_I"].ToString());
    //    int i = objBillDetails.SendToFinance();
    //    if (i > 0)
    //    {
    //        Response.Redirect("ViewBillDetails.aspx");
    //    }
    //}



    //public void AmtCalPaper()
    //{
    //    float perSecAmt = 0, perSecRemin = 0;
    //    try
    //    {
    //        perSecAmt = float.Parse(txtPaperSecurityDeposit.Text);
    //    }
    //    catch { }
    //    try
    //    {
    //        perSecRemin = float.Parse(txtPaperSecurityReimbursed.Text);
    //    }
    //    catch { }

    //    txtBalancePaperSecurityReimbursed.Text = (perSecAmt - perSecRemin).ToString("0.00");
    //}
    public void OnLoad()
    {
        BillDesctionSection();
        TotDeduction();
        AbCal();      
    }
    public void BillDesctionSection()
    {
        float BalPrintingCharges = 0, BalPrintingSec = 0, PayBlePrintingCharg = 0, BalPrintingSec2 = 0, BalPrintingSec1 = 0, BalPrintingSec3=0,Totamt = 0;
        try
        {
            BalPrintingCharges = float.Parse(txtBalPrintingCharges.Text);
        }
        catch { BalPrintingCharges = 0; }

        try
        {
            BalPrintingSec = float.Parse(txtBalPrintingSec.Text);
        }
        catch { BalPrintingSec = 0; }

        try
        {
            BalPrintingSec1 = float.Parse(txtBalPrintingSec1.Text);
        }
        catch { }
        try
        {
            BalPrintingSec2 = float.Parse(txtBalPrintingSec2.Text);
        }
        catch { BalPrintingSec2 = 0; }

        try
        {
            BalPrintingSec3 = float.Parse(txtBalPrintingSec3.Text);
        }
        catch { BalPrintingSec3 = 0; }

        try
        {
            Totamt = BalPrintingCharges + BalPrintingSec + PayBlePrintingCharg + BalPrintingSec2 + BalPrintingSec1 + BalPrintingSec3;
        }
        catch { }

        txtTotalA.Text = Totamt.ToString("0.00");
        TotDeduction();
    }

    public void TotDeduction()
    {
        float PntySubPnting = 0, PntyMistacks = 0, PntyDlySubPof = 0, PntyDlySuplyBook = 0, DepotExpenditure = 0, CostSalableBook = 0, DeduAgainstBal = 0, IncomeTax = 0, TransportationCharges = 0, InterestPprCstSec = 0, OtherDedu = 0, WitheldReg = 0, Totamt = 0;
        try
        {
            PntySubPnting = float.Parse(txtPntySubPnting.Text);
        }
        catch { PntySubPnting = 0; }
        try
        {
            PntyMistacks = float.Parse(txtPntyMistacks.Text);
        }
        catch { PntyMistacks = 0; }

        try
        {
            PntyDlySubPof = float.Parse(txtPntyDlySubPof.Text);
        }
        catch { PntyDlySubPof = 0; }
        try
        {
            PntyDlySuplyBook = float.Parse(txtPntyDlySuplyBook.Text);
        }
        catch { PntyDlySuplyBook = 0; }

        try
        {
            DepotExpenditure = float.Parse(txtDepotExpenditure.Text);
        }
        catch { DepotExpenditure = 0; }

        try
        {
            CostSalableBook = float.Parse(txtCostSalableBook.Text);
        }
        catch { CostSalableBook = 0; }
        try
        {
            DeduAgainstBal = float.Parse(txtDeduAgainstBal.Text);
        }
        catch { DeduAgainstBal = 0; }

        try
        {
            IncomeTax = float.Parse(txt2IncomeTax.Text);
        }
        catch { IncomeTax = 0; }
        try
        {
            TransportationCharges = float.Parse(txtTransportationCharges.Text);
        }
        catch { TransportationCharges = 0; }
        try
        {
            InterestPprCstSec = float.Parse(txtInterestPprCstSec.Text);
        }
        catch { InterestPprCstSec = 0; }
        try
        {
            OtherDedu = float.Parse(txtOtherDedu.Text);
        }
        catch { OtherDedu = 0; }
        try
        {
            WitheldReg = float.Parse(txt2WitheldReg.Text);
        }
        catch { WitheldReg = 0; }

        Totamt = (PntySubPnting + PntyMistacks + PntyDlySubPof + PntyDlySuplyBook + DepotExpenditure + CostSalableBook + DeduAgainstBal + IncomeTax + TransportationCharges + InterestPprCstSec + OtherDedu + WitheldReg);
        txtTotalB.Text = Totamt.ToString("0.00");


    }

    public void AbCal()
    {
        float amt = 0, TotalPayAmt = 0, TotalDeduc = 0;
        try
        {
            TotalPayAmt = float.Parse(txtTotalA.Text);
        }
        catch { }
        try
        {
            TotalDeduc = float.Parse(txtTotalB.Text);
        }
        catch { }
        amt = TotalPayAmt - TotalDeduc;
        txtNetPay.Text = amt.ToString("0.00");
    }

    protected void txtPntySubPnting_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPntyMistacks_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPntyDlySubPof_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPntyDlySuplyBook_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDepotExpenditure_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtCostSalableBook_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDeduAgainstBal_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txt2IncomeTax_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtTransportationCharges_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtInterestPprCstSec_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtOtherDedu_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txt2WitheldReg_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtTotalB_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtBalPrintingCharges_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtBalPrintingSec_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtBalPrintingSec1_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtBalPrintingSec2_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtBalPrintingSec3_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtTotalA_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
}
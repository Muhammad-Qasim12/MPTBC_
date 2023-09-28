using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PrintVoucher : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds1;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["ID"] != null)
            {
                string vid = new APIProcedure().Decrypt(Request.QueryString["ID"].ToString());
                LoadVoucher(vid);
            }
        }
        catch { }
    }

    protected string txtDepartmentName_V; protected string txtDeyakNo_V; protected string txtLekhaSheersh_V; protected string txtMad_V;
    protected string txtTotalBudjut_N; protected string txtPreviousBillAmount_N; protected string txtSamayojanAmount_N; protected string txtPartyName_V;
    protected string txtSanctionedAmount_N; protected string txtPayAmount_N; protected string txtPartyBillNo_V;
    protected string txtPartyBillDate_D; protected string txtNigamOrderNo_V; protected string txtNigamOrderDate_D; protected string txtNoteSheetNo;

    protected string txtNoteSheetDate; protected string txtSanctionedAmountByBranchOfficer_N; protected string txtPayAmount_N_Account; protected string txtSamayojanAmount_N_Account;
    protected string lblTotalAccountSectionAmt; protected string lblTotalAccountSectionAmt_Words; protected string lblOfficerName; protected string lblBankIFSCCode;

    public void LoadVoucher(string VoucherTrno_I)
    {
        DataSet ds = new DataSet();

        try
        {
            obCommonFuction = new CommonFuction();
            ds = obCommonFuction.FillDatasetByProc("call USP_Voucher_Print('" + VoucherTrno_I + "')");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtDepartmentName_V = Convert.ToString(ds.Tables[0].Rows[0]["DepartmentName_V"]);
                txtDeyakNo_V = Convert.ToString(ds.Tables[0].Rows[0]["DeyakNo_V"]);
                txtLekhaSheersh_V = Convert.ToString(ds.Tables[0].Rows[0]["LekhaSheersh_V"]);
                txtMad_V = Convert.ToString(ds.Tables[0].Rows[0]["Mad_V"]);
                txtTotalBudjut_N = Convert.ToString(ds.Tables[0].Rows[0]["TotalBudjut_N"]);
                txtPreviousBillAmount_N = Convert.ToString(ds.Tables[0].Rows[0]["PreviousBillAmount_N"]);    
                txtPartyName_V = Convert.ToString(ds.Tables[0].Rows[0]["PartyName_V"]);

                txtSanctionedAmount_N = Convert.ToString(ds.Tables[0].Rows[0]["SanctionedAmount_N"]);
                txtSamayojanAmount_N = Convert.ToString(ds.Tables[0].Rows[0]["SamayojanAmount_N"]);
                txtPayAmount_N = Convert.ToString(ds.Tables[0].Rows[0]["PayAmount_N"]);
                txtPartyBillNo_V = Convert.ToString(ds.Tables[0].Rows[0]["PartyBillNo_V"]);
                txtPartyBillDate_D = Convert.ToString(ds.Tables[0].Rows[0]["PartyBillDate_D"]);

                txtNigamOrderNo_V = Convert.ToString(ds.Tables[0].Rows[0]["NigamOrderNo_V"]);
                txtNigamOrderDate_D = Convert.ToString(ds.Tables[0].Rows[0]["NigamOrderDate_D"]);

                txtNoteSheetNo = Convert.ToString(ds.Tables[0].Rows[0]["NotsheetFile_V"]);
                txtNoteSheetDate = Convert.ToString(ds.Tables[0].Rows[0]["NoteSheetDate"]);
                             
                //txtSanctionedAmountByBranchOfficer_N = Convert.ToString(ds.Tables[0].Rows[0]["SanctionedAmountByBranchOfficer_N"]);
                txtSanctionedAmountByBranchOfficer_N = txtSanctionedAmount_N;

                txtPayAmount_N_Account = ds.Tables[0].Rows[0]["PayAmount_N_Account"].ToString();
                txtSamayojanAmount_N_Account = ds.Tables[0].Rows[0]["SamayojanAmount_N_Account"].ToString();
                //lblHeading.Text = ds.Tables[0].Rows[0]["VchrHeading"].ToString();

                //lblTotalAccountSectionAmt = "240000";
                lblTotalAccountSectionAmt = (decimal.Parse(txtSamayojanAmount_N_Account != "" ? txtSamayojanAmount_N_Account : "0") + decimal.Parse(txtPayAmount_N_Account != "" ? txtPayAmount_N_Account : "0")).ToString();

                lblTotalAccountSectionAmt_Words = lblTotalAccountSectionAmt != "0" ? ConvertNumbertoWords(long.Parse(lblTotalAccountSectionAmt)) : "................................................";
                lblOfficerName = ds.Tables[0].Rows[0]["OfficerName_V"].ToString();
                //if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                //    lblBankIFSCCode = ds.Tables[0].Rows[0]["BankName"].ToString() + "," + ds.Tables[0].Rows[0]["IFSCCode"].ToString();

                GetPartyDetails(ds.Tables[0].Rows[0]["PartyTrno_I"].ToString());

                if (lblTotalAccountSectionAmt == "0") { lblTotalAccountSectionAmt = "........................"; }
                if (txtPayAmount_N_Account == "0") { txtPayAmount_N_Account = "........................"; }
                if (txtSamayojanAmount_N_Account == "0") { txtSamayojanAmount_N_Account = "........................"; }

            }
        }



        catch (Exception ex) { }
    }

    private void GetPartyDetails(string PartyId)
    {
        lblBankIFSCCode = "";
        try
        {
            obCommonFuction = new CommonFuction();
            DataTable dt = obCommonFuction.FillDatasetByProc("call USP_LIST_PartyRegistrationDetails('" + PartyId + "',0);").Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblBankIFSCCode = dt.Rows[0]["BankDetails11"].ToString();
            }
            else
                lblBankIFSCCode = ""; ;
        }
        catch { }
    }

    //public void LoadVoucher(string VoucherTrno_I)
    //{
    //    DataSet ds = new DataSet();

    //    try
    //    {
    //        obCommonFuction = new CommonFuction();
    //        ds = obCommonFuction.FillDatasetByProc("call USP_Voucher_Print('" + VoucherTrno_I + "')");

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            txtDepartmentName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["DepartmentName_V"]);
    //            txtDeyakNo_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["DeyakNo_V"]);
    //            txtLekhaSheersh_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["LekhaSheersh_V"]);
    //            txtMad_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mad_V"]);
    //            txtTotalBudjut_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["TotalBudjut_N"]);
    //            txtPreviousBillAmount_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["PreviousBillAmount_N"]);
    //            txtPreviousBillAmount_N.Enabled = false;
    //            txtSamayojanAmount_N.Enabled = true;
    //            txtPartyName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyName_V"]);

    //            //ddlPayMode_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["PayMode_V"]);
    //            txtSanctionedAmount_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["SanctionedAmount_N"]);
    //            txtSamayojanAmount_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["SamayojanAmount_N"]);
    //            txtPayAmount_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["PayAmount_N"]);
    //            txtPartyBillNo_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyBillNo_V"]);
    //            txtPartyBillDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["PartyBillDate_D"]);

    //            txtNigamOrderNo_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["NigamOrderNo_V"]);
    //            txtNigamOrderDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["NigamOrderDate_D"]);

    //            txtNoteSheetNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["NotsheetFile_V"]);
    //            txtNoteSheetDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoteSheetDate"]);

    //            // lblNotsheetFile_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["NotsheetFile_V"]);

    //            //txtOfficerName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OfficerName_V"]);
    //            //txtDesignationTrno_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Designation_V"]);
    //            txtSanctionedAmountByBranchOfficer_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["SanctionedAmountByBranchOfficer_N"]);

    //            txtPayAmount_N_Account.Text = ds.Tables[0].Rows[0]["PayAmount_N_Account"].ToString();
    //            txtSamayojanAmount_N_Account.Text = ds.Tables[0].Rows[0]["SamayojanAmount_N_Account"].ToString();
    //            //lblHeading.Text = ds.Tables[0].Rows[0]["VchrHeading"].ToString();

    //            //lblTotalAccountSectionAmt.Text = "240000";
    //            lblTotalAccountSectionAmt.Text = (decimal.Parse(txtSamayojanAmount_N_Account.Text != "" ? txtSamayojanAmount_N_Account.Text : "0") + decimal.Parse(txtPayAmount_N_Account.Text != "" ? txtPayAmount_N_Account.Text : "0")).ToString();

    //            lblTotalAccountSectionAmt_Words.Text = lblTotalAccountSectionAmt.Text != "0" ? ConvertNumbertoWords(long.Parse(lblTotalAccountSectionAmt.Text)) : "";
    //            lblOfficerName.Text = ds.Tables[0].Rows[0]["OfficerName_V"].ToString();
    //            if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
    //                lblBankIFSCCode.Text = ds.Tables[0].Rows[0]["BankName"].ToString() + "," + ds.Tables[0].Rows[0]["IFSCCode"].ToString();

    //        }
    //    }



    //    catch (Exception ex) { }
    //}

    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 10000000) > 0)
        {
            words += ConvertNumbertoWords(number / 10000000) + " CRORE ";
            number %= 10000000;
        }
        if ((number / 100000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LACS ";
            number %= 100000;
        }
        if ((number / 1000) > 0)
        {
            words += ConvertNumbertoWords(number / 1000) + " THOUSAND ";
            number %= 1000;
        }
        if ((number / 100) > 0)
        {
            words += ConvertNumbertoWords(number / 100) + " HUNDRED ";
            number %= 100;
        }
        //if ((number / 10) > 0)  
        //{  
        // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
        // number %= 10;  
        //}  
        if (number > 0)
        {
            if (words != "") words += "AND ";
            var unitsMap = new[]   
        {  
            "ZERO", "ONE", "TWO", "THREE", "FOUR", "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN"  
        };
            var tensMap = new[]   
        {  
            "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY"  
        };
            if (number < 20) words += unitsMap[number];
            else
            {
                words += tensMap[number / 10];
                if ((number % 10) > 0) words += " " + unitsMap[number % 10];
            }
        }
        return words;
    }  
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PrintChequeIsueFormat : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds1;
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //ds1 = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport( + Request.QueryString["ID"].ToString() + ")");
            //ds1 = obCommonFuction.FillDatasetByProc("CALL USP_PartyRTGSDetails(54)");
            if (Request.QueryString["ID"] != null)
            {                
                string vid = Request.QueryString["ID"].ToString();                
                ds1 = obCommonFuction.FillDatasetByProc("call USP_Voucher_PrepareAccountLoad('" + vid + "','')");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lblPrinter.Text = ds1.Tables[0].Rows[0]["PartyName_V"].ToString();
                    lblCheqAmt.Text = ds1.Tables[0].Rows[0]["PayAmount_N"].ToString();
                    lblCheqDate.Text = ds1.Tables[0].Rows[0]["CqDate"].ToString();
                    lblRupHindi.Text = ConvertNumbertoWords(long.Parse(lblCheqAmt.Text));
                }
                
            }            
        }
        catch { }
        finally { }

        if (!IsPostBack)
        {
           
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //ds1 = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport(0," + Request.QueryString["ID"].ToString() + ")");

    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
       // ds1 = obCommonFuction.FillDatasetByProc("call USP_Prin_ChallanReport(0," + Request.QueryString["ID"].ToString() + ")");
    }

    public string ConvertNumbertoWords(long number)
    {
        if (number == 0) return "ZERO";
        if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
        string words = "";
        if ((number / 1000000) > 0)
        {
            words += ConvertNumbertoWords(number / 100000) + " LAKES ";
            number %= 1000000;
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
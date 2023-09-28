using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Printing_PrinterChallanRpt : System.Web.UI.Page
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
                string mtype = new APIProcedure().Decrypt(Request.QueryString["mType"].ToString());
                ds1 = obCommonFuction.FillDatasetByProc("CALL USP_PartyRTGSDetails('" + vid + "','" + mtype + "')");
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    string isChqeIssue = ds1.Tables[0].Rows[0]["mchqissue"].ToString();
                    string billid = ds1.Tables[0].Rows[0]["mbillid"].ToString();
                    string deptname = ds1.Tables[0].Rows[0]["mdeptname"].ToString();
                    
                    int i = 1;
                    if (isChqeIssue == "1")
                    {
                        // update ischequeissue = 2, billstatus - approved, mtype=0 for running pri bill, mtype=1 for final pri bill
                      //DataTable dt = obCommonFuction.FillDatasetByProc("call USP_UPDATE_VchrBillStatus(0, '" + vid + "', '" + billid + "')").Tables[0];  //change 2682017 for final pri bill
                        DataTable dt = obCommonFuction.FillDatasetByProc("call USP_UPDATE_VchrBillStatus('" + mtype + "', '" + vid + "', '" + billid + "')").Tables[0]; 
                      i = int.Parse(dt.Rows[0][0].ToString());
                      if (i > 0)
                      {
                          //ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Voucher status updated successfully.');");
                          ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('RTGS Generated successfully.');", true);
                      }
                    }
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
}
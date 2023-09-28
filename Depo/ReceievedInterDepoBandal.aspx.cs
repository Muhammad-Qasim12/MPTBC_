using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_ReceievedInterDepoBandal : System.Web.UI.Page
{
    CommonFuction obCommonFuction;
    string SubQuery = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT35GetReceivedInterDepoRequest(" + Session["UserID"] + ")");
            DropDownList1.DataTextField = "challanno";
            DropDownList1.DataValueField = "challanno";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select..");
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        try
        {

            for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
            {
                if (((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked == true)
                {
                    if (SubQuery == "")
                    {
                        SubQuery = SubQuery + "" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("lblBundleNo_I")).Text + "";
                    }
                    else
                    {
                        SubQuery = SubQuery + "," + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("lblBundleNo_I")).Text + "";
                    }
                    //obCommonFuction.FillDatasetByProc("call DPTUpdateBundleDetails('" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("lblBundleNo_I")).Text + "')");
                }
               
            }
        }
        catch { }
        obCommonFuction.FillDatasetByProc("call USP_DPTStockUpdate(0," + DropDownList1.SelectedValue + ",'" + SubQuery + "')");


        DataSet ds = obCommonFuction.FillDatasetByProc("call USPgetBandalInterdepo(" + DropDownList1.SelectedValue + ")");
        grdPrinterBundleDetails.DataSource = ds.Tables[0];
        grdPrinterBundleDetails.DataBind();
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Data Save Successfully');</script>");
        Response.Redirect("inertdepobookReceived.aspx?ID=" + DropDownList1.SelectedValue + "");
   
      
       }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
        {
            if (((CheckBox)grdPrinterBundleDetails.HeaderRow.FindControl("CheckBox2")).Checked == true)
            {
                ((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked = true;
            }
            else
            {
                ((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked = false;
            }
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet dd = obCommonFuction.FillDatasetByProc("call USPgetBandalInterdepo("+DropDownList1.SelectedValue+")");
        grdPrinterBundleDetails.DataSource = dd.Tables[0];
        grdPrinterBundleDetails.DataBind();

        GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"SELECT FromNo_I,ToNo_I,CASE RemaingLoose_V WHEN '' THEN IFNULL(ToNo_I  ,0)-IFNULL(FromNo_I ,0)+1 ELSE (LENGTH(RemainingStock) - LENGTH(REPLACE (RemainingStock,',',''))) END TotalBook,TitleHindi_V,  BundleNo_I,CASE WHEN IsOpenMarket=1 THEN 'योजना  'ELSE 'सामान्य ' END bookType , RemainingStock, WareHouseID, DistributID, PriTransID, BookSellerChallan, iflooj FROM dpt_stockdetailschild_t
INNER JOIN dpt_stockdetails_t ON dpt_stockdetails_t.StockDetailsID_I=dpt_stockdetailschild_t.StockDetailsID_I
INNER JOIN acd_titledetail ON acd_titledetail.TitleID_I=SubJectID_I 
WHERE DistributID= " + DropDownList1.SelectedValue + " AND IsDistribute=10");
        GridView1.DataBind();
       // 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using System.Data;
public partial class Depo_WareHouseRenualFrom : System.Web.UI.Page
{
    WareHouseMaster obWareHouseMaster = null;
    BooksellerMaster obBooksellerMaster = null;
    DepoReport dpt = new DepoReport();
    CommonFuction cf = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure api = new APIProcedure();

    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objapi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        a.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        //HVBookSeller.Value = "";
        //HVWareHouse.Value ="";
        if (RadioButtonList1.SelectedValue == "1")
        {
            FillData();
            GrdBookSeleer.Visible = false;
            GrdWarehouse.Visible = true;
            GrdBookSeleer.DataSource = null;
            GrdBookSeleer.DataBind();
        }
        else
        {
            GrdBookSeleer.Visible = true;
            GrdWarehouse.Visible = false;
            GrdWarehouse.DataSource = null;
            GrdWarehouse.DataBind();
            FillBookData();
        }
    }
    public void FillData()
    {
        try
        {
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            GrdWarehouse.DataSource = obWareHouseMaster.Select();
            GrdWarehouse.DataBind();

        }
        catch
        {
        }

    }
    public void FillBookData()
    {
        try
        {

            obBooksellerMaster = new BooksellerMaster();
            obBooksellerMaster.DBooksellerregistration_I = 0;
            obBooksellerMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            GrdBookSeleer.DataSource = obBooksellerMaster.Select();
            GrdBookSeleer.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        a.Style.Add("display", "block");
        aj.Style.Add("display", "none");
       Label1.Text =GrdWarehouse.SelectedRow.Cells[1].Text ;
        Label2.Text =GrdWarehouse.SelectedRow.Cells[2].Text ;
        HVWareHouse.Value = GrdWarehouse.SelectedDataKey.Value.ToString();

    }
    protected void GrdBookSeleer_SelectedIndexChanged(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        aj.Style.Add("display", "block");
        Label1.Text = GrdBookSeleer.SelectedRow.Cells[1].Text;
        Label2.Text = GrdBookSeleer.SelectedRow.Cells[2].Text;
        HVBookSeller.Value = GrdBookSeleer.SelectedDataKey.Value.ToString();
        a.Style.Add("display", "block");
    }
    
    
    protected void GrdWarehouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdWarehouse.PageIndex = e.NewPageIndex;
        FillData();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void GrdBookSeleer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdBookSeleer.PageIndex = e.NewPageIndex;
        FillBookData();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            if (HVWareHouse.Value != "")
            {
                dpt.WareID = Convert.ToInt32(HVWareHouse.Value);
                dpt.Type = "W";
                dpt.Remark = Convert.ToString(txtremark.Text);
                dpt.RenewalNO = Convert.ToString(txtRenweNo.Text);
                dpt.fromdate = Convert.ToDateTime(txtRenewalDate.Text,cult );
                dpt.RenewalAmount = Convert.ToDouble(0);
                dpt.InsertUpdate();
             
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                Response.Redirect("DepoLetter.aspx?ID="+ api.Encrypt(HVWareHouse.Value) +"");
                   cf.EmptyTextBoxes(this);
                
            }
        }
        else
        {
            dpt.WareID = Convert.ToInt32(HVBookSeller.Value);
            dpt.Type = "B";
            dpt.Remark = Convert.ToString(txtremark.Text);
            dpt.RenewalNO = Convert.ToString(txtRenweNo.Text);
            dpt.fromdate = Convert.ToDateTime(txtRenewalDate.Text,cult );
            dpt.RenewalAmount = Convert.ToDouble(txtAmount.Text);
            int i = dpt.InsertUpdate();

            if (i > 0)
            {
                string PrathamUId = "", BranchId = "", CreatedByEmpId = "", newGuid = "";
                CommonFuction obCommonFuction = new CommonFuction();
                if (dpt.WareID != 0)
                {
                    ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 3, dpt.WareID.ToString());
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        newGuid = ds.Tables[1].Rows[0][0].ToString();
                        if (newGuid == "")
                        {
                            newGuid = Guid.NewGuid().ToString();
                        }
                    }
                }
                else
                {
                    ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, "");
                }
                PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
                BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
                CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();
                byte PaymentType = 0;

                DateTime DateRec = new DateTime();
                DateTime CheqDate = new DateTime();
                DateRec = DateTime.Parse(txtRenewalDate.Text, cult);
                string Instrumentxml = "", ReceiptDetailxml = "", deduction_detailsxml = "", InstGuid = Guid.NewGuid().ToString(); ;

                if ("Cash" == "Cash")
                {
                    PaymentType = 1;

                    Instrumentxml = @"<DocumentElement><INSTRUMENTXML>
        <ROWNO>1</ROWNO>  <CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE><CHEQUEAMOUNT>" + txtAmount.Text.ToString() + "</CHEQUEAMOUNT><INSTRUMENTID>" + InstGuid + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";

                }

                ReceiptDetailxml = @"<DocumentElement><RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00026</COLUMNID>
<COLUMNVALUE>" + obCommonFuction.GetFinYear() + "</COLUMNVALUE> <INSTRUMENTID>" + InstGuid +
             "</INSTRUMENTID><RECEIPTTYPEID>404c5380-4312-435c-bda4-a187723b724f</RECEIPTTYPEID></RECEIPTDETAILXML>" +
      "<RECEIPTDETAILXML> <ROWNO>1</ROWNO> <COLUMNID>00035</COLUMNID> <COLUMNVALUE>Book Seller Renewal No :" + txtRenweNo.Text + "</COLUMNVALUE> <INSTRUMENTID>" + InstGuid + "</INSTRUMENTID> " +
      "<RECEIPTTYPEID>404c5380-4312-435c-bda4-a187723b724f</RECEIPTTYPEID> </RECEIPTDETAILXML>" +
      "<RECEIPTDETAILXML> <ROWNO>1</ROWNO> <COLUMNID>00004</COLUMNID>  <COLUMNVALUE>" + txtAmount.Text + "</COLUMNVALUE>  <INSTRUMENTID>" + InstGuid + "</INSTRUMENTID>" +
       "<RECEIPTTYPEID>404c5380-4312-435c-bda4-a187723b724f</RECEIPTTYPEID> </RECEIPTDETAILXML> </DocumentElement>";



                if (Request.QueryString["id"] == null)
                {
                    //ds = objWebService.Printers_Registration_Or_Renewal_Fees(DateRec.ToString("yyyy/MM/dd"), newGuid.ToString(), PaymentType, PrathamUId.ToString(), BranchId,
                    //     ReceiptDetailxml, Instrumentxml, txtAmount.Text, CreatedByEmpId, objapi.DepoHeadIDSendToID(BranchId), "From Book Seller Renewal Type :" + RadioButtonList1.SelectedItem.Text + " Book Seller ID " + dpt.WareID.ToString(), null);

                    //obPriEval.UpdateWarHusRenewAccHRN(ds.Tables[0].Rows[0][1].ToString(), i.ToString(), i);
                }
                cf.EmptyTextBoxes(this);
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
            }
        }
    }
}
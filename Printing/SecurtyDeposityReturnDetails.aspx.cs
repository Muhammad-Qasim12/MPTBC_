using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using System.Data;
using System.Globalization;
using System.IO;
using Yojnaservice;
public partial class Depo_SecurtyDeposityReturnDetails : System.Web.UI.Page
{
    WareHouseMaster obWareHouseMaster = null; BooksellerMaster obBooksellerMaster = null;
    TransportMaster obTransportMaster = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure api = new APIProcedure();
    string ImgStatus, mapFile;

    CommonFuction obCommonFuction = null;
    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objapi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
    YF_WebService objWebService = new YF_WebService();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillDataPrinter();
        }

    }

    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (DropDownList1.SelectedValue == "1")
    //    {
    //        FillDataTrans();

    //        GrdWarehouse.DataSource = null;
    //        GrdWarehouse.DataBind();

    //        GrdBookSeleer.DataSource = null;
    //        GrdBookSeleer.DataBind();
    //    }
    //    else if (DropDownList1.SelectedValue == "2")
    //    {
    //        obWareHouseMaster = new WareHouseMaster();
    //        obWareHouseMaster.WareHouseID = 0;
    //        obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
    //        GrdWarehouse.DataSource = obWareHouseMaster.Select();

    //        GrdWarehouse.DataBind();

    //        GrdTransport.DataSource = null;
    //        GrdTransport.DataBind();

    //        GrdBookSeleer.DataSource = null;
    //        GrdBookSeleer.DataBind();
    //    }
    //    else if (DropDownList1.SelectedValue == "3")
    //    {
    //        FillDataBook();
    //    }
    //    else if (DropDownList1.SelectedValue == "5")
    //    {
    //        FillDataPrinter();
    //    }

    //    else
    //    {
    //        GrdTransport.DataSource = null;
    //        GrdTransport.DataBind();

    //        GrdBookSeleer.DataSource = null;
    //        GrdBookSeleer.DataBind();
    //        GrdWarehouse.DataSource = null;
    //        GrdWarehouse.DataBind();
    //    }
    //}
    //public void FillDataTrans()
    //{
    //    try
    //    {
    //        obTransportMaster = new TransportMaster();
    //        obTransportMaster.TransportID_I = 0;
    //        obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
    //        GrdTransport.DataSource = obTransportMaster.Select();
    //        GrdTransport.DataBind();

    //    }
    //    catch
    //    {
    //    }
    //    finally { }
    //}
    //protected void GrdWarehouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GrdWarehouse.PageIndex = e.NewPageIndex;
    //    obWareHouseMaster = new WareHouseMaster();
    //    obWareHouseMaster.WareHouseID = 0;
    //    obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
    //    GrdWarehouse.DataSource = obWareHouseMaster.Select();
    //    GrdWarehouse.DataBind();
    //}
    //protected void GrdBookSeleer_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HiddenField1.Value = GrdBookSeleer.SelectedDataKey.Value.ToString();
    //    lblOwnerName.Text = GrdBookSeleer.SelectedRow.Cells[3].Text;
    //    lblPartyName.Text = GrdBookSeleer.SelectedRow.Cells[3].Text;
    //    lblSecurityAmount.Text = GrdBookSeleer.SelectedRow.Cells[5].Text;
    //    lblContractNo.Text = GrdBookSeleer.SelectedRow.Cells[6].Text;
    //    lblagrement.Text = GrdBookSeleer.SelectedRow.Cells[4].Text;

    //    aa.Style.Add("display", "Block");

    //}
    //protected void GrdBookSeleer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GrdBookSeleer.PageIndex = e.NewPageIndex;
    //    FillDataBook();
    //}
    //public void FillDataBook()
    //{
    //    try
    //    {

    //        obBooksellerMaster = new BooksellerMaster();
    //        obBooksellerMaster.DBooksellerregistration_I = 0;
    //        obBooksellerMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
    //        GrdBookSeleer.DataSource = obBooksellerMaster.Select();
    //        GrdBookSeleer.DataBind();

    //        GrdTransport.DataSource = null;
    //        GrdTransport.DataBind();

    //        GrdWarehouse.DataSource = null;
    //        GrdWarehouse.DataBind();


    //    }
    //    catch
    //    {
    //    }

    //}


    public void FillDataPrinter()
    {

        try
        {
            CommonFuction comm = new CommonFuction();
            DataSet dd = comm.FillDatasetByProc("call USP_SecurityPrinter(1,'')");

            GrdPrinterId.DataSource = dd.Tables[0];
            GrdPrinterId.DataBind();



        }
        catch
        {
        }

    }
    //protected void GrdTransport_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HiddenField1.Value = GrdTransport.SelectedDataKey.Value.ToString();
    //    lblOwnerName.Text = GrdTransport.SelectedRow.Cells[1].Text;
    //    lblPartyName.Text = GrdTransport.SelectedRow.Cells[0].Text;
    //    lblSecurityAmount.Text = GrdTransport.SelectedRow.Cells[4].Text;
    //    lblContractNo.Text = GrdTransport.SelectedRow.Cells[5].Text;
    //    lblagrement.Text = GrdTransport.SelectedRow.Cells[2].Text;
    //    aa.Style.Add("display", "Block");
    //}
    //protected void GrdTransport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GrdTransport.PageIndex = e.NewPageIndex;
    //    FillDataTrans();
    //}
    //protected void GrdWarehouse_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    HiddenField1.Value = GrdWarehouse.SelectedDataKey.Value.ToString();
    //    lblOwnerName.Text = GrdWarehouse.SelectedRow.Cells[1].Text;
    //    lblPartyName.Text = GrdWarehouse.SelectedRow.Cells[1].Text;
    //    lblSecurityAmount.Text = GrdWarehouse.SelectedRow.Cells[3].Text;
    //    lblContractNo.Text = GrdWarehouse.SelectedRow.Cells[7].Text;
    //    lblagrement.Text = GrdWarehouse.SelectedRow.Cells[6].Text;

    //    aa.Style.Add("display", "Block");
    //}
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string CoreFilePath = "";
    //    obCommonFuction = new CommonFuction();
    //    CommonFuction comm = new CommonFuction();
    //    if (FileUpload1.FileName == "")
    //    {
    //        ImgStatus = "Ok";
    //    }
    //    else
    //    {
    //        ImgStatus = api.SingleuploadFile(FileUpload1, "mapFile", 1024);
    //        mapFile = api.FullFileName;
    //       // string fileExt = Path.GetExtension("~/Building/BuildingFile/" + mapFile).ToLower();
    //       // CoreFilePath = "TDS_Upload/GENERAL_BILL-" + Guid.NewGuid().ToString() + "-welcome_img" + fileExt;
    //        //FileUpload1.SaveAs(Server.MapPath("~/" + CoreFilePath));
    //    }
    //    ds = comm.FillDatasetByProc("call USP_DPTSecurityAmountSave('" + DropDownList1.SelectedValue + "','" + HiddenField1.Value + "','" + txtNoc.Text + "','" + Convert.ToDateTime(txtNocDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtLetterNo.Text + "','" + Convert.ToDateTime(txtLetterDate.Text, cult).ToString("yyyy-MM-dd") + "','" + mapFile + "','" + txtRamount.Text + "','" + txtBankNaem.Text + "','" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "')");
    //    int i = int.Parse(ds.Tables[0].Rows[0][0].ToString());

    //    aa.Style.Add("display", "none");
    //    DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_HR_GetOtherAccount(" + Session["UserID"] + ")");
    //    DataSet ddd;
    //    if (HiddenField1.Value != "")
    //    {
    //        if (DropDownList1.SelectedItem.Text == "Transporter")
    //        {
    //            ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgerNameFindBYID(" + HiddenField1.Value + ",'Transport')");
    //            DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('P')");

    //            obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('PAYMENT','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit return ',0,0," + txtRamount.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,0)");

    //            obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('PAYMENT','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit return ',0," + txtRamount.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,0)");
    //        }
    //        else if (DropDownList1.SelectedItem.Text == "WareHouse")
    //        {
    //            ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgerNameFindBYID(" + HiddenField1.Value + ",'WareHouse')");
    //            DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('P')");
    //           // DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + txtBankName.SelectedValue + ")");
    //            obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('PAYMENT','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit return ',0,0," + txtRamount.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,0)");

    //            obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('PAYMENT','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit return ',0," + txtRamount.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,0)");
    //        }
    //        else if (DropDownList1.SelectedItem.Text == "BookSelller Name")
    //        {
    //            ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgerNameFindBYID(" + HiddenField1.Value + ",'Bookseller')");
    //            DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('P')");
    //            //DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + txtBankName.SelectedValue + ")");
    //            obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('PAYMENT','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit return ',0,0," + txtRamount.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,0)");

    //            obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('PAYMENT','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit return ',0," + txtRamount.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDDNo.Text + "','" + Convert.ToDateTime(txtDDdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,0)");
    //        }

    //    }


    //    //string PrathamUId = "", BranchId = "", CreatedByEmpId = "", newGuid = "";
    //    //obCommonFuction = new CommonFuction();
    //    //if (HiddenField1.Value != "")
    //    //{
    //    //    if (DropDownList1.SelectedItem.Text == "Transporter")
    //    //    {
    //    //        ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 4, HiddenField1.Value.ToString());
    //    //    }
    //    //    else if (DropDownList1.SelectedItem.Text == "WareHouse")
    //    //    {
    //    //        ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 5, HiddenField1.Value.ToString());
    //    //    }
    //    //    else if (DropDownList1.SelectedItem.Text == "BookSelller Name")
    //    //    {
    //    //        ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 3, HiddenField1.Value.ToString());
    //    //    }

    //    //    if (ds.Tables[1].Rows.Count > 0)
    //    //    {
    //    //        newGuid = ds.Tables[1].Rows[0][0].ToString();
    //    //        //if (newGuid == "")
    //    //        //{
    //    //        //    newGuid = Guid.NewGuid().ToString();
    //    //        //}
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, "");
    //    //}
    //    //PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
    //    //BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
    //    //CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();
    //    //byte PaymentType = 0;

    //    //DateTime DateRec = new DateTime();

    //    //DateRec = DateTime.Parse(txtLetterDate.Text, cult);
    //    ////string Instrumentxml = "", ReceiptDetailxml = "", deduction_detailsxml = "";
    //    //string BillXml = "";

    //    //// obCommonFuction.FillDatasetByProc("call HR_PrinterRegistration('" + newGuid + "'," + i + ")");
    //    //if (Request.QueryString["id"] == null)
    //    //{
    //    //    BillXml =
    //    //    @"<DocumentElement>" +
    //    //   "<TGBPDDETAIL><TGBPD_COLUMNID>00036</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + txtNocDate.Text + "</TGBPD_COLUMNVALUE></TGBPDDETAIL><TGBPDDETAIL>" +
    //    //   "<TGBPD_COLUMNID>00090</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + txtLetterDate.Text + "</TGBPD_COLUMNVALUE></TGBPDDETAIL><TGBPDDETAIL>" +
    //    //   "<TGBPD_COLUMNID>00089</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + txtNoc.Text + "</TGBPD_COLUMNVALUE></TGBPDDETAIL><TGBPDDETAIL>" +
    //    //   "<TGBPD_COLUMNID>00030</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + txtLetterNo.Text + "</TGBPD_COLUMNVALUE></TGBPDDETAIL><TGBPDDETAIL>" +
    //    //    "<TGBPD_COLUMNID>00041</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + CreatedByEmpId.ToString() + "</TGBPD_COLUMNVALUE></TGBPDDETAIL><TGBPDDETAIL>" +
    //    //    " <TGBPD_COLUMNID>00004</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>" + txtRamount.Text + "</TGBPD_COLUMNVALUE></TGBPDDETAIL><TGBPDDETAIL>" +
    //    //    " <TGBPD_COLUMNID>00035</TGBPD_COLUMNID><TGBPD_COLUMNVALUE>Security Deposit Return Details</TGBPD_COLUMNVALUE></TGBPDDETAIL></DocumentElement>";


    //    //    if (newGuid != "")
    //    //    {
    //    //        ds = objWebService.Save_Security_Deposit_Return(DateRec.ToString("yyyy/MM/dd"), CreatedByEmpId, CreatedByEmpId.ToString(), "Security Deposit Return Details", CoreFilePath, "0", "0", txtRamount.Text, "0", "0", "0", "0",
    //    //            newGuid.ToString(), txtRamount.Text, txtRamount.Text, BillXml, objapi.DepoHeadIDSendToID(BranchId), "Security Deposit Return Details " + DropDownList1.SelectedItem.Text + " Latter No :" + txtLetterNo.Text + " Party Name :" + lblPartyName.Text, System.DateTime.Now.ToString("yyyy/MM/dd"), BranchId, PrathamUId.ToString(), null);

    //    //       // obPriEval.UpdateSqriydpstRtnAccHRN(ds.Tables[0].Rows[0][1].ToString(), i.ToString(), i);
    //    //    }
    //    //}
    //    ////  obCommonFuction.FillDatasetByProc("call HR_PrinterRegistration('" + newGuid + "'," + i + ")");
    //    // }



    //    aa.Style.Add("display", "none");
    //    lblmsg.Text = "Record Save Successfully";

    //}
}
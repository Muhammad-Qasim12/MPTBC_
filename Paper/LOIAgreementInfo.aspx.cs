using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using System.Globalization;
using System.IO;

public partial class Paper_LOIAgreementInfo : System.Web.UI.Page
{
    APIProcedure objApi = new APIProcedure();
    DataSet ds;
    PPR_LOIDetails objLOIDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string path, FileName;


    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objdb = new APIProcedure();
  //  YF_WebService objWebService = new YF_WebService();
    UserMaster objUMaster = new UserMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        lblCurrentDt.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
          //  DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            lblAcYear.Text = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(2)").Tables[0].Rows[0][0].ToString();
            if (Request.QueryString["ID"] != null)
            {
                //TndId

            }
        }
    }
    public void TenderAllFill()
    {  int papvenid=0;
        objLOIDetails = new PPR_LOIDetails();
        ddlTenderNo.DataSource = objLOIDetails.TenderFill();
        ddlTenderNo.DataTextField = "TenderNo_V";
        ddlTenderNo.DataValueField = "TenderTrId_I";
        ddlTenderNo.DataBind();
        ddlTenderNo.Items.Insert(0, "Select");
        if (Request.QueryString["TndId"] != null)
        {
            ddlTenderNo.Enabled = false;
            ddlVendorLOITo.Enabled = false;
            ddlTenderNo.Items.FindByValue(objApi.Decrypt(Request.QueryString["TndId"].ToString())).Selected = true;
            TenderFieldFill();
            objLOIDetails.LOITrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));

            ds = objLOIDetails.LOIDtlFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
               
                txtLOINo.Text = ds.Tables[0].Rows[0]["LOINo_V"].ToString();
                lblCurrentDt.Text = ds.Tables[0].Rows[0]["LOIDate_D"].ToString();
                txtPBGAmt.Text = ds.Tables[0].Rows[0]["PBGAmount_N"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
                hdnFile.Value = ds.Tables[0].Rows[0]["LOIFile_V"].ToString();
                lblAcYear.Text = ds.Tables[0].Rows[0]["AcYear"].ToString();
                DdlACYear.SelectedValue = ds.Tables[0].Rows[0]["AcYear"].ToString().Trim ();
                txtalloted.Text = ds.Tables[0].Rows[0]["AllotedQuantity"].ToString();
                papvenid = Convert.ToInt32 (  ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()) ;
                    //DdlACYear.ClearSelection();
                    //DdlACYear.Items.FindByText(lblAcYear.Text).Selected = true;
                //DdlACYear.SelectedItem.Text = ds.Tables[0].Rows[0]["AcYear"].ToString();
              
              
            }

            ddlVendorLOITo.Enabled = true;
            objLOIDetails.PaperVendorTrId_I = papvenid;
            ddlVendorLOITo.ClearSelection();
            ddlVendorLOITo.SelectedValue  = objLOIDetails.PaperVendorTrId_I.ToString() ;
            ddlVendorLOITo.Enabled = false;
           // objLOIDetails.PaperVendorTrId_I = int.Parse(ddlVendorLOITo.SelectedItem.Value.ToString());
       
            ds = objLOIDetails.VenderDtlFill();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();
                txtContactNo.Text = ds.Tables[0].Rows[0]["PaperVendorContactNo_V"].ToString();
                txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson_V"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["PaperVendorEmail_V"].ToString();
                txtVatTaxNo.Text = ds.Tables[0].Rows[0]["PaperVendorTinNo_V"].ToString();
                //PaperVendorTanNo_V, p.PaperVendorPanNo_V
            }
            

        }
    }
    protected void ddlTenderNo_Init(object sender, EventArgs e)
    {
        TenderAllFill();
    }
    public void TenderFieldFill()
    {
        CommonFuction comm = new CommonFuction();
       DataSet dd=comm.FillDatasetByProc("call USPGetQuantitybyTender (" + ddlTenderNo.SelectedValue + ")");
       lblQty.Text = dd.Tables[0].Rows[0]["RqcQuantity"].ToString();
        objLOIDetails = new PPR_LOIDetails();
        objLOIDetails.TenderTrId_I = int.Parse(ddlTenderNo.SelectedItem.Value.ToString());
         
        ddlVendorLOITo.DataSource = objLOIDetails.VenderFill();
        ddlVendorLOITo.DataTextField = "PaperVendorName_V";
        ddlVendorLOITo.DataValueField = "Venderid_I";
        ddlVendorLOITo.DataBind();

        objLOIDetails.PaperVendorTrId_I = int.Parse(ddlVendorLOITo.SelectedValue.ToString());
        ds = objLOIDetails.VenderDtlFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();
            txtContactNo.Text = ds.Tables[0].Rows[0]["PaperVendorContactNo_V"].ToString();
            txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson_V"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["PaperVendorEmail_V"].ToString();
            txtVatTaxNo.Text = ds.Tables[0].Rows[0]["PaperVendorTinNo_V"].ToString();
            //PaperVendorTanNo_V, p.PaperVendorPanNo_V
        }
    }
    protected void ddlTenderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTenderNo.SelectedItem.Text != "Select")
        {
            TenderFieldFill();
        }
        else
        {
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtContactPerson.Text = "";
            txtEmail.Text = "";
            txtVatTaxNo.Text = "";
            ddlVendorLOITo.SelectedIndex = 0;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string CheckData = "";
        if (txtRemark.Text.ToString().Length > 99)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 100 charecter in remark text box.');</script>");

        }
        else
        {
            if (ddlTenderNo.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
            }
            else if (ddlVendorLOITo.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select company Name.');</script>");
            }
            else
            {
                objLOIDetails = new PPR_LOIDetails();
                objLOIDetails.LOINo_V = txtLOINo.Text;
                ds = objLOIDetails.LOINoCheck();
                if (ds.Tables[0].Rows[0][0].ToString() == "1" && Request.QueryString["ID"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('LOI No already exist.');</script>");
                }
                else
                {
                    string ImgStatus = "";
                    if (fileUp1.FileName == "")
                    {
                        ImgStatus = "Ok";
                        FileName = hdnFile.Value.ToString();
                    }
                    else
                    {
                           
                        ImgStatus = objApi.uploadFile(fileUp1, "PaperUploadedFile", 10000);
                        if (ImgStatus == "Ok")
                        {
                            FileName = objApi.FullFileName;
                        }
                    }

                    if (ImgStatus == "Ok")
                    {
                        objLOIDetails = new PPR_LOIDetails();
                        objLOIDetails.TenderTrId_I = int.Parse(ddlTenderNo.SelectedItem.Value.ToString());
                        objLOIDetails.PaperVendorTrId_I = int.Parse(ddlVendorLOITo.SelectedItem.Value.ToString());
                        objLOIDetails.LOINo_V = txtLOINo.Text;
                        objLOIDetails.PBGAmount_N = decimal.Parse(txtPBGAmt.Text);
                        objLOIDetails.LOIFile_V = FileName;
                        objLOIDetails.UserId_I = int.Parse(Session["UserID"].ToString());
                        objLOIDetails.Remark_V = txtRemark.Text.Trim();

                        if (Request.QueryString["ID"] != null)
                        {
                            objLOIDetails.LOITrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                            CheckData = "0";
                        }
                        else
                        {
                            objLOIDetails.LOITrId_I = 0;

                            //ds= objLOIDetails.AlredyEntryCheck(ddlTenderNo.SelectedItem.Value.ToString());
                            //if (ds.Tables[0].Rows.Count > 0)
                            //{
                            //    CheckData = ds.Tables[0].Rows[0][0].ToString();
                            //}
                            //else
                            //{
                                CheckData = "0";
                            //}
                            
                        }
                        try
                        {
                            if (CheckData != "0")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender No Already Saved.');</script>"); 
                            }
                            else
                            {
                                string PrathamUId = "", BranchId = "", CreatedByEmpId = "", newGuid = "";
                              //  int i = objLOIDetails.InsertUpdate();
                                int i = InsertUpdate(objLOIDetails);
                                CommonFuction comm = new CommonFuction();
                                comm.FillDatasetByProc("call USP_PPRUpdatefyloi('"+DdlACYear.SelectedItem.Text+"',"+i+")");

                                if (i > 0)
                                {
                                    ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 6, ddlVendorLOITo.SelectedItem.Value);
                                    if (ds.Tables[1].Rows.Count > 0)
                                    {
                                        newGuid = ds.Tables[1].Rows[0][0].ToString();
                                    }

                                    if (newGuid != "")
                                    {
                                        PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
                                        BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
                                        CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();

                                        byte PaymentType = 0;
                                        //ds = obCommonFuction.FillDatasetByProc("call GetPrinterRegStatus(" + i + ")");


                                        DateTime DateRec = new DateTime();

                                        DateRec = DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);
                                        string Instrumentxml = "", ReceiptDetailxml = "", deduction_detailsxml = "", InstrumentGuid = "";
                                        InstrumentGuid = Guid.NewGuid().ToString();
                                        if ("Cash" == "Cash")
                                        {
                                            PaymentType = 1;
                                            //    Instrumentxml = @"<DocumentElement><INSTRUMENTXML><ROWNO>1</ROWNO><CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE><CHEQUEAMOUNT>" + lblEMDAmount_N.Text + "</CHEQUEAMOUNT><INSTRUMENTID>" + newGuid + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";
                                            Instrumentxml = @"<DocumentElement><INSTRUMENTXML><ROWNO>1</ROWNO><CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE><CHEQUEAMOUNT>" + txtPBGAmt.Text + "</CHEQUEAMOUNT><INSTRUMENTID>" + InstrumentGuid + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";
                                        }


                                        ReceiptDetailxml = @"<DocumentElement><RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00034</COLUMNID><COLUMNVALUE>" + obCommonFuction.GetFinYear() + "</COLUMNVALUE><INSTRUMENTID>" + InstrumentGuid + "</INSTRUMENTID><RECEIPTTYPEID>aab5e2e9-b37d-4795-888c-713a0b7dc9ed</RECEIPTTYPEID></RECEIPTDETAILXML>" +
                                        "<RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00030</COLUMNID><COLUMNVALUE>" + txtLOINo.Text + "</COLUMNVALUE><INSTRUMENTID>" + InstrumentGuid + "</INSTRUMENTID><RECEIPTTYPEID>aab5e2e9-b37d-4795-888c-713a0b7dc9ed</RECEIPTTYPEID></RECEIPTDETAILXML>" +
                         "<RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00035</COLUMNID><COLUMNVALUE>" + txtRemark.Text + "</COLUMNVALUE><INSTRUMENTID>" + InstrumentGuid + "</INSTRUMENTID><RECEIPTTYPEID>aab5e2e9-b37d-4795-888c-713a0b7dc9ed</RECEIPTTYPEID></RECEIPTDETAILXML>" +
                        "<RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00004</COLUMNID><COLUMNVALUE>" + txtPBGAmt.Text + "</COLUMNVALUE><INSTRUMENTID>" + InstrumentGuid + "</INSTRUMENTID><RECEIPTTYPEID>aab5e2e9-b37d-4795-888c-713a0b7dc9ed</RECEIPTTYPEID></RECEIPTDETAILXML></DocumentElement>";

                                        deduction_detailsxml = @"<DocumentElement><DEDUCTION><TRRD_TRT_ID>aab5e2e9-b37d-4795-888c-713a0b7dc9ed</TRRD_TRT_ID><TRRD_ROW_NO>1</TRRD_ROW_NO><TRRD_TDS_AMT>0</TRRD_TDS_AMT><TRRD_COMM_AMT>0</TRRD_COMM_AMT><TRRD_OTHER_AMT>0</TRRD_OTHER_AMT></DEDUCTION></DocumentElement>";
                                        if (newGuid != "" && PrathamUId != "")
                                        {
                                            ds = obCommonFuction.FillDatasetByProc("SELECT ifnull(AccHRID,'')AccHRID   FROM ppr_loidetail_t WHERE LOITrID_I='" + i.ToString() + "'");
                                            if (ds.Tables[0].Rows[0]["AccHRID"].ToString() == "")
                                            {
                                               // ds = objWebService.SAVE_Printers_EMD(DateRec.ToString("yyyy/MM/dd"), newGuid.ToString(), PaymentType, PrathamUId.ToString(), BranchId,
                                                     //  ReceiptDetailxml, Instrumentxml, txtPBGAmt.Text, CreatedByEmpId, objUMaster.SendToEmpId(), "From Paper EMD Amount Of LOI : " + txtLOINo.Text + " / " + ddlTenderNo.SelectedItem.Text, deduction_detailsxml);
                                              //  obPriEval.UpdateBILLPPRLoiAccHRN(ds.Tables[0].Rows[0][1].ToString(), i.ToString(), i);
                                            }
                                        }
                                    }

                                    if (Request.QueryString["ID"] != null)
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                                        Response.Redirect("ViewLOIAgreementInfo.aspx");
                                    }
                                    else
                                    {
                                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                                        Response.Redirect("ViewLOIAgreementInfo.aspx");
                                    }
                                    obCommonFuction.EmptyTextBoxes(this);
                                    //   Clear();
                                    
                                    lblMsg.Text = "";
                                    ddlVendorLOITo.SelectedIndex = 0;
                                    ddlVendorLOITo.DataSource = string.Empty;
                                    ddlVendorLOITo.DataBind();
                                    ddlVendorLOITo.Items.Insert(0, "Select");
                                }
                            }
                        }
                        catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('LOI No Already Exist.');</script>"); }
                    }
                    else
                    {
                        lblMsg.Text = ImgStatus.ToString();
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }
    }
    protected void ddlVendorLOITo_SelectedIndexChanged(object sender, EventArgs e)
    {
        objLOIDetails.PaperVendorTrId_I = int.Parse(ddlVendorLOITo.SelectedItem.Value.ToString());
        ds = objLOIDetails.VenderDtlFill();

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();
            txtContactNo.Text = ds.Tables[0].Rows[0]["PaperVendorContactNo_V"].ToString();
            txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson_V"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["PaperVendorEmail_V"].ToString();
            txtVatTaxNo.Text = ds.Tables[0].Rows[0]["PaperVendorTinNo_V"].ToString();
            //PaperVendorTanNo_V, p.PaperVendorPanNo_V
        }
    }

    public int InsertUpdate(PPR_LOIDetails obj)
    {

        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR006_LOISaveUpdateDataNew", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mLOITrId_I", obj.LOITrId_I);
        obDBAccess.addParam("mTenderTrId_I", obj.TenderTrId_I);
        obDBAccess.addParam("mLOINo_V", obj.LOINo_V);
        obDBAccess.addParam("mPaperVendorTrId_I", obj.PaperVendorTrId_I);
        obDBAccess.addParam("mPBGAmount_N", obj.PBGAmount_N);
        obDBAccess.addParam("mLOIFile_V", obj.LOIFile_V);
        obDBAccess.addParam("mRemark_V", obj.Remark_V);
        obDBAccess.addParam("mUserId_I", obj.UserId_I);
        obDBAccess.addParam("mAllotedQuantity", txtalloted.Text);
        int result = Convert.ToInt32(obDBAccess.executeMyScalar());
        return result;
    }
}

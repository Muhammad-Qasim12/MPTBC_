using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using Yojnaservice;

public partial class DistributionB_InsuranceClaimInfo : System.Web.UI.Page
{
    InsuranceClaimSettlement obInsuranceClaimSettlement = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = null;
    DataSet ds;
    

    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objApi = new APIProcedure();
    YF_WebService objWebService = new YF_WebService();
    UserMaster objUMaster = new UserMaster();

    string PrathamUId = "", BranchId = "", CreatedByEmpId = "", SenderEmpGuid = "", BillXml = "", UploadedFilePath = "", fileExt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                //ddlClaim();
                if (Request.QueryString["ID"] != null)
                {
                    showdata(new APIProcedure().Decrypt(Request.QueryString["ID"]));
                }

            }
            catch { }
            finally { obInsuranceClaimSettlement = null; }
        }
        if (Session["UserID"] == null)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }

    //public void ddlClaim()
    //{
    //    ListItem List = new ListItem();
    //    List.Value = "0";
    //    List.Text = "Select..";
    //    ddlClaimType.Items.Insert(0, List);
    //}
    private bool CheckDate(string DateValue)
    {
        try
        {
            Convert.ToDateTime(DateValue, cult);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void ddlClaimType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillDDL();
        }
        catch { }
        finally { }
    }

    private void fillDepo()
    {
        obCommonFuction = new CommonFuction();
        DataSet dsDepo = obCommonFuction.FillDatasetByProc("Call USP_ADM010_DepomasterLoad(0)");
        ddlDepoName.DataSource = dsDepo.Tables[0];
        ddlDepoName.DataValueField = "DepoTrno_I";
        ddlDepoName.DataTextField = "DepoName_V";
        ddlDepoName.DataBind();
    }
    protected void FillDDL()
    {
        fillDepo();
        List<ListItem> List = new List<ListItem>();
        for (int i = 0; i < ddlDepoName.Items.Count; i++)
        {
            if (ddlClaimType.SelectedValue == "TextBook")
            {
                if (ddlDepoName.Items[i].Text == "केंद्रीय पेपर डिपो")
                {
                    ddlDepoName.Items.RemoveAt(i);
                }
            }
            else if (ddlClaimType.SelectedValue == "Paper")
            {
                if (ddlDepoName.Items[i].Text != "केंद्रीय पेपर डिपो")
                {
                    //ddlDepo.Items.RemoveAt(i);
                    List.Add(ddlDepoName.Items[i]);
                }
            }
        }
        if (ddlClaimType.SelectedValue == "Paper")
        {
            for (int i = 0; i < List.Count; i++)
            {
                ddlDepoName.Items.Remove(List[i]);
            }
        }
    }
    protected void txtClaimDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            obInsuranceClaimSettlement = new InsuranceClaimSettlement();
            obInsuranceClaimSettlement.ClaimDate_D = Convert.ToDateTime(txtClaimDate.Text, cult);
            DataSet ds = obInsuranceClaimSettlement.FillCompany();

            ddlInsuranceCompany.DataSource = ds;
            ddlInsuranceCompany.DataValueField = "CompanyID_I";
            ddlInsuranceCompany.DataTextField = "Company_V";
            ddlInsuranceCompany.DataBind();
        }
        catch { }
        finally { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int? ReimbursedAmount = null;
            DateTime? ReimbursedDate = null;
            if (!CheckDate(txtClaimDate.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('क्लेम दिनांक सही नहीं है');</script>");
            }
            else if (txtReimbursedDate.Text != "" && !CheckDate(txtReimbursedDate.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('स्वीकृति दिनांक सही नहीं है');</script>");
            }
            else if ((CheckDate(txtReimbursedDate.Text) == true && Convert.ToDateTime(txtReimbursedDate.Text, cult) > DateTime.Now.Date) ||
                     Convert.ToDateTime(txtClaimDate.Text, cult) > DateTime.Now.Date)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('प्रविष्ट दिनांक वर्तमान दिनांक से आगे की है');</script>");
            }
            else
            {
                if (txtReimbursedAmount.Text != "")
                {
                    ReimbursedAmount = Convert.ToInt32(txtReimbursedAmount.Text);
                }
                if (txtReimbursedDate.Text != "")
                {
                    ReimbursedDate = Convert.ToDateTime(txtReimbursedDate.Text, cult);
                }

                obInsuranceClaimSettlement = new InsuranceClaimSettlement();
                obInsuranceClaimSettlement.ClaimId_I = 0;
                if (HiddenField1.Value != "")
                {
                    obInsuranceClaimSettlement.ClaimId_I = Convert.ToInt32(HiddenField1.Value);
                }
                obInsuranceClaimSettlement.LetterNo_V = txtLetterNo.Text;
                obInsuranceClaimSettlement.ClaimDate_D = Convert.ToDateTime(txtClaimDate.Text, cult);
                obInsuranceClaimSettlement.InsuranceCompany_I = Convert.ToInt32(ddlInsuranceCompany.SelectedValue);
                obInsuranceClaimSettlement.ClaimType_V = ddlClaimType.SelectedValue;
                obInsuranceClaimSettlement.DepoName_I = Convert.ToInt32(ddlDepoName.SelectedValue);
                obInsuranceClaimSettlement.ClaimAmount_I = Convert.ToInt32(txtClaimAmount.Text);
                obInsuranceClaimSettlement.ClaimReason_V = txtClaimReason.Text;
                obInsuranceClaimSettlement.ReimbursedAmount_I = Convert.ToInt32(ReimbursedAmount);
                if (ReimbursedDate != null)
                    obInsuranceClaimSettlement.ReimbursedDate_D = Convert.ToDateTime(ReimbursedDate, cult);

                obInsuranceClaimSettlement.ReimbursedRemark_V = txtReimbursedRemark.Text;
                obInsuranceClaimSettlement.TrDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
                obInsuranceClaimSettlement.UserTrNo_I = Convert.ToInt32(Session["UserID"]);

                
                var result = obInsuranceClaimSettlement.InsertUpdate();

                if (result > 0)
                {
                    try
                    {
                        obCommonFuction = new CommonFuction();
                        ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, Session["UserID"].ToString());
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            SenderEmpGuid = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();// ds.Tables[1].Rows[0][0].ToString();
                        }
                        if (SenderEmpGuid != "")
                        {
                            PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
                            BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
                            CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();

                            byte PaymentType = 1;
                            //ds = obCommonFuction.FillDatasetByProc("call GetPrinterRegStatus(" + i + ")");
                            string ReceiptDetailxml = "", INSTRUMENTXML = "";
                            string NewInsnNo = Guid.NewGuid().ToString();
                            DateTime DateRec = new DateTime();

                            DateRec = DateTime.Parse(txtClaimDate.Text, cult);

                            INSTRUMENTXML = @"<DocumentElement><INSTRUMENTXML><ROWNO>1</ROWNO>  <CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE>" +
       "<CHEQUEAMOUNT>" + txtClaimAmount.Text + "</CHEQUEAMOUNT><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";

                            ReceiptDetailxml = @"<DocumentElement><RECEIPTDETAILXML><ROWNO>1</ROWNO>" +
        "<COLUMNID>00030</COLUMNID><COLUMNVALUE>" + txtLetterNo.Text + "</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID>" +
        "<RECEIPTTYPEID>21363b10-57d0-4613-86d3-26fbae58fddf</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML><ROWNO>1</ROWNO>" +
        "<COLUMNID>00035</COLUMNID><COLUMNVALUE>" + txtclaimRemark.Text + "</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID>" +
        "<RECEIPTTYPEID>21363b10-57d0-4613-86d3-26fbae58fddf</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML><ROWNO>1</ROWNO>" +
        "<COLUMNID>00004</COLUMNID><COLUMNVALUE>" + txtClaimAmount.Text + "</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID>" +
        "<RECEIPTTYPEID>21363b10-57d0-4613-86d3-26fbae58fddf</RECEIPTTYPEID></RECEIPTDETAILXML></DocumentElement>";


                            ds = objWebService.Save_Insurance_Claim_Info(DateRec.ToString("yyyy/MM/dd"), CreatedByEmpId, PaymentType, PrathamUId.ToString(), BranchId, ReceiptDetailxml, INSTRUMENTXML, txtClaimAmount.Text, CreatedByEmpId, objUMaster.SendToEmpId(),
                                "From Insurance Claim No.: " + txtLetterNo.Text + " Claim Type:" + ddlClaimType.SelectedItem.Text + " / " + ddlInsuranceCompany.SelectedItem.Text + " / " + ddlDepoName.SelectedItem.Text, null);

                            //obPriEval.UpdateDisBClamAccHRN(ds.Tables[0].Rows[0][1].ToString(), result.ToString(), result);


                        }
                    }
                    catch { }


                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('जानकारी दर्ज हो गई है...');</script>");
                    obCommonFuction = new CommonFuction();
                    HiddenField1.Value = result.ToString();
                    //obCommonFuction.EmptyTextBoxes(this);
                    //HiddenField1.Value = "";

                    //Response.Redirect("VIEW_DIB_016.aspx");
                } 
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कृपया जानकारी सही से दर्ज करें...');</script>");
        }
        finally
        {
            obInsuranceClaimSettlement = null;
        }


    }

    public void showdata(string ID)
    {
        try
        {
            obInsuranceClaimSettlement = new InsuranceClaimSettlement();
            obInsuranceClaimSettlement.ClaimId_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"]));
            DataSet ds = obInsuranceClaimSettlement.Select();

            txtLetterNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["LetterNo_V"]);
            txtClaimDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ClaimDate_D"]).ToString("dd/MM/yyyy");
            ddlClaimType.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ClaimType_V"]);
            FillddlClaimType(Convert.ToString(ddlClaimType.SelectedValue));
            ddlDepoName.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["DepoName_I"]);
            FillddlCompany(Convert.ToDateTime(txtClaimDate.Text, cult));
            ddlInsuranceCompany.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["InsuranceCompany_I"]);
            txtClaimAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClaimAmount_I"]);
            txtClaimReason.Text = Convert.ToString(ds.Tables[0].Rows[0]["ClaimReason_V"]);
            if (Convert.ToString(ds.Tables[0].Rows[0]["ReimbursedAmount_I"]) != "")
            {
                txtReimbursedAmount.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReimbursedAmount_I"]);
            }
            if (Convert.ToString(ds.Tables[0].Rows[0]["ReimbursedDate_D"]) != "")
            {
                txtReimbursedDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReimbursedDate_D"]).ToString("dd/MM/yyyy");
            }
            if (Convert.ToString(ds.Tables[0].Rows[0]["ReimbursedRemark_V"]) != "")
            {
                txtReimbursedRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["ReimbursedRemark_V"]);
            }
            HiddenField1.Value = (new APIProcedure().Decrypt(Request.QueryString["ID"]));
        }
        catch
        { }
        finally { }

    }

    protected void FillddlCompany(DateTime ClaimDate)
    {
        obInsuranceClaimSettlement = new InsuranceClaimSettlement();
        obInsuranceClaimSettlement.ClaimDate_D = Convert.ToDateTime(ClaimDate, cult);
        DataSet ds = obInsuranceClaimSettlement.FillCompany();

        ddlInsuranceCompany.DataSource = ds;
        ddlInsuranceCompany.DataValueField = "CompanyID_I";
        ddlInsuranceCompany.DataTextField = "Company_V";
        ddlInsuranceCompany.DataBind();
    }

    public void FillddlClaimType(string ClaimType)
    {
        try
        {
            FillDDL();
        }
        catch { }
        finally { }
    }
    protected void btnOtherDetails_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "0" || HiddenField1.Value == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कृपया पहले बीमा क्लेम की जानकारी सुरक्षित करें...');</script>");
        }
        else
        {
            fadeDiv.Style.Add("display", "block");
            Messages.Style.Add("display", "block");
            FillOtherInfoGrid();
        }

    }
    protected void btnClosePopup_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }
    protected void btnSaveClaimOtherInfo_Click(object sender, EventArgs e)
    {
        if (CheckDate(txtPayLetterDate.Text) && CheckDate(txtClaimDate.Text) &&
            (Convert.ToDateTime(txtClaimDate.Text, cult) > Convert.ToDateTime(txtPayLetterDate.Text, cult)))
        {

            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('अन्य जानकारी की दिनांक बीमा क्लेम की दिनांक से पूर्व की है | कृपया उचित दिनांक का चयन करें |');</script>");
        }
        else if (CheckDate(txtPayLetterDate.Text))
        {
            obInsuranceClaimSettlement = new InsuranceClaimSettlement();
            obInsuranceClaimSettlement.ClaimId_I = int.Parse(HiddenField1.Value);
            obInsuranceClaimSettlement.LetterNo_V = txtPayLetterNo.Text;
            obInsuranceClaimSettlement.ClaimDate_D = Convert.ToDateTime(txtPayLetterDate.Text, cult);
            obInsuranceClaimSettlement.ClaimType_V = txtclaimRemark.Text;
            obInsuranceClaimSettlement.UserTrNo_I = int.Parse(Session["UserID"].ToString());
            try
            {
                obInsuranceClaimSettlement.SaveOtherInfo();
                FillOtherInfoGrid();
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कृपया जानकारी की जाँच करें !! जानकारी सुरक्षित नहीं की गई है |...');</script>");
            }

        }
    }

    private void FillOtherInfoGrid()
    {
        obInsuranceClaimSettlement = new InsuranceClaimSettlement();
        obInsuranceClaimSettlement.ClaimId_I = int.Parse(HiddenField1.Value);

        GrdOtherPaymentInfo.DataSource = obInsuranceClaimSettlement.SelectOther();
        GrdOtherPaymentInfo.DataBind();
    }
    protected void GrdOtherPaymentInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obInsuranceClaimSettlement = new InsuranceClaimSettlement();
        obInsuranceClaimSettlement.ClaimId_I = int.Parse(GrdOtherPaymentInfo.DataKeys[e.RowIndex].Value.ToString());
        try
        {
            obInsuranceClaimSettlement.DeleteOther();
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('जानकारी सफलतापूर्वक हटा दी गई है |');</script>");
            FillOtherInfoGrid();
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('जानकारी हटाने में असमर्थ है');</script>");

        }

    }
    
}
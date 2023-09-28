using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer;

public partial class Printing_ViewPRI008FinalBillDetails : System.Web.UI.Page
{
    DataSet ds;
    Pri_BillDetails_New objBillDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obcomm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hfIsFinalBill.Value = "1";
            txtDepartmentName_V.Text = "Printing";
            GetDesignationId();
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.BillID_I = 0;
            objBillDetails.User_ID = int.Parse(Session["UserID"].ToString());
            GrdLabMaster.DataSource = objBillDetails.Select();
            GrdLabMaster.DataBind();

            if (GrdLabMaster.Rows.Count > 0)
            {
                if (hfApprovedFlag.Value == "सहायक ग्रेड-2" && hfLoggedInDeptName.Value == "Printing")
                {
                    GrdLabMaster.Columns[5].Visible = true;
                }
                else
                    GrdLabMaster.Columns[5].Visible = false;
            }
        }
        catch { }

    }

    public void GetDesignationId()
    {
        try
        {
            
            string UserID = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_LIST_HR_Employee_Basic_Fiters(18,0,0," + UserID + ",'')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                hfDesignationId.Value = dt.Rows[0]["CEDesignationId"].ToString();
                hfDepartmentId.Value = dt.Rows[0]["DepartmentId"].ToString();
                hfLoggedInDeptName.Value = dt.Rows[0]["DepartmentName"].ToString();
                hfApprovedFlag.Value = dt.Rows[0]["DesignationName"].ToString();
            }
            else
            {
                hfDesignationId.Value = "0";
                hfDepartmentId.Value = "0";
            }

        }
        catch { }
    }

    private string fnChekRemark()
    {
        string strRemark = "";

        if (txtRemark.Text != "")
            strRemark = txtRemark.Text;

        return strRemark;
    }

    public int SaveVoucher(string DesignationId, string DepartmentId)
    {

        int i = 0;
        MPTBCBussinessLayer.Building008_Voucher obVoucher = new Building008_Voucher();

        if (txtDepartmentName_V.Text == "")
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Section name.');");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Section name.');", true);
        }
        else if (txtLekhaSheersh_V.Text == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Account Statement');", true);
        }
        //else if (txtMad_V.Text == "")
        //{           
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Head');", true);
        //}
        //else if (txtTotalBudjut_N.Text == "")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Total Budget PRovisioned.');");
        //}       
        else if (txtPreviousBillAmount_N.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Expenditure till last date.');");
        }
        else if (txtPartyName_V.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Payment to be made to.');");
        }
        else if (txtSanctionedAmount_N.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Sanctionable Amount.');");
        }
        else if (txtSamayojanAmount_N.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Adjustment Amount.');");
        }

        //else if (txtPayAmount_N.Text == "")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Payment Amount.');");           
        //}
        else if (txtPartyBillNo_V.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Party Bill No.');");

        }
        else if (txtPartyBillDate_D.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Party Bill date.');");
        }
        else if (txtOfficerName_V.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Officer name.');");
        }
        else if (txtDesignationTrno_I.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Designation name.');");
        }
        else if (ddlForwardTo.SelectedIndex == 0)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please select Forward To.');", true);
        }
        else if (fnChekRemark() == "")
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter remark.');", true);
        }
        //else if (txtNigamOrderNo_V.Text == "")
        //{            
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Nigam Order No.');", true);
        //}
        //else if (txtNigamOrderDate_D.Text == "")
        //{            
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Nigam Order Date');", true);
        //}
        //else if (txtNoteSheetNo.Text == "")
        //{            
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Page No..');", true);
        //}
        //else if (txtNoteSheetDate.Text == "")
        //{            
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Notesheet Date..');", true);
        //}

        else
        {
            try
            {
                if (int.Parse(HDNVchrID.Value) > 0)
                {
                    obVoucher.VoucherTrno_I = Convert.ToInt32(HDNVchrID.Value);
                }
                else { obVoucher.VoucherTrno_I = Convert.ToInt32(HDNVchrID.Value); }

                obVoucher.DepartmentName_V = Convert.ToString(txtDepartmentName_V.Text);
                obVoucher.DeyakNo_V = "";
                obVoucher.LekhaSheersh_V = Convert.ToString(txtLekhaSheersh_V.Text);
                obVoucher.Mad_V = "";

                obVoucher.TotalBudjut_N = Convert.ToDouble(-1);
                obVoucher.PreviousBillAmount_N = Convert.ToDouble(txtPreviousBillAmount_N.Text);
                obVoucher.PartyName_V = Convert.ToString(txtPartyName_V.Text);
                //obVoucher.PartyTrno_I = Convert.ToInt32(1);
                obVoucher.PartyTrno_I = Convert.ToInt32(txtPartyTrno_I.Text);
                obVoucher.PayMode_V = "";
                obVoucher.SanctionedAmount_N = Convert.ToDouble(txtSanctionedAmount_N.Text);
                obVoucher.SamayojanAmount_N = Convert.ToDouble(txtSamayojanAmount_N.Text);
                obVoucher.PayAmount_N = Convert.ToDouble(txtPayAmount_N.Text);
                obVoucher.PartyBillNo_V = Convert.ToString(txtPartyBillNo_V.Text);
                obVoucher.PartyBillDate_D = Convert.ToDateTime(txtPartyBillDate_D.Text, cult);

                obVoucher.NigamOrderNo_V = "";
                //obVoucher.NigamOrderDate_D = Convert.ToDateTime(txtNigamOrderDate_D.Text, cult);
                obVoucher.NigamOrderDate_D = Convert.ToDateTime("1900/01/01", cult);
                obVoucher.NotsheetFile_V = "";
                //DateTime dtNoteSheetDate = Convert.ToDateTime(txtNoteSheetDate.Text, cult);
                DateTime dtNoteSheetDate = Convert.ToDateTime("1900/01/01", cult);

                obVoucher.OfficerName_V = Convert.ToString(txtOfficerName_V.Text);
                obVoucher.OfficerTrno_I = Convert.ToInt32(hfDepartmentId.Value);
                obVoucher.DesignationTrno_I = Convert.ToInt32(hfDesignationId.Value);
                obVoucher.Designation_V = Convert.ToString(txtDesignationTrno_I.Text);
                obVoucher.SanctionedAmountByBranchOfficer_N = Convert.ToDouble("0");
                double dblSamayojanAmount_N_Account = Convert.ToDouble("0");
                double dblPayAmount_N_Account = Convert.ToDouble("0");
                obVoucher.UserTrno_I = Convert.ToInt32(Session["UserID"]);

                obVoucher.BillPayTrno_I = Convert.ToInt32(HDNBillPayTrno_I.Value);

                int mType = 0;
                if (hfRevert.Value == "1")
                {
                    mType = 2;
                }
                else if (hfRevert.Value == "3") //dont update remark of main emp who created voucher
                {
                    mType = 2;
                }

                // DataSet dt = obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountSaveUpdate('" + obVoucher.VoucherTrno_I + "'," +
                // "'" + obVoucher.DepartmentName_V + "','" + obVoucher.DeyakNo_V + "','" + obVoucher.LekhaSheersh_V + "'," +
                // "'" + obVoucher.Mad_V + "','" + obVoucher.TotalBudjut_N + "','" + obVoucher.PreviousBillAmount_N + "'," +
                // "'" + obVoucher.PartyName_V + "','" + obVoucher.PartyTrno_I + "','" + obVoucher.PayMode_V + "'," +
                //" '" + obVoucher.SanctionedAmount_N + "', '" + obVoucher.SamayojanAmount_N + "','" + obVoucher.PayAmount_N + "', '" + obVoucher.PartyBillNo_V + "', '" + obVoucher.PartyBillDate_D.ToString("yyyy-MM-dd") + "'," +
                //" '" + obVoucher.NigamOrderNo_V + "', '" + obVoucher.NigamOrderDate_D.ToString("yyyy-MM-dd") + "','" + obVoucher.NotsheetFile_V + "', '" + obVoucher.OfficerName_V + "', '" + obVoucher.OfficerTrno_I + "', '" + obVoucher.DesignationTrno_I + "'," +
                //" '" + obVoucher.Designation_V + "', '" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + obVoucher.UserTrno_I + "', '" + obVoucher.BillPayTrno_I + "', '" + ddlForwardTo.SelectedValue + "'," +
                //" '" + hfDepartmentId.Value + "', '0','" + fnChekRemark() + "','" + mType + "','" + dtNoteSheetDate.ToString("yyyy-MM-dd") + "','" + hfIsFinalBill.Value + "')");

                DataSet dt = obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountSaveUpdate('" + obVoucher.VoucherTrno_I + "'," +
              "'" + obVoucher.DepartmentName_V + "','" + obVoucher.DeyakNo_V + "','" + obVoucher.LekhaSheersh_V + "'," +
              "'" + obVoucher.Mad_V + "','" + obVoucher.TotalBudjut_N + "','" + obVoucher.PreviousBillAmount_N + "'," +
              "'" + obVoucher.PartyName_V + "','" + obVoucher.PartyTrno_I + "','" + obVoucher.PayMode_V + "'," +
             " '" + obVoucher.SanctionedAmount_N + "', '" + obVoucher.SamayojanAmount_N + "','" + obVoucher.PayAmount_N + "', '" + obVoucher.PartyBillNo_V + "', '" + obVoucher.PartyBillDate_D.ToString("yyyy-MM-dd") + "'," +
             " '" + obVoucher.NigamOrderNo_V + "', '" + obVoucher.NigamOrderDate_D.ToString("yyyy-MM-dd") + "','" + obVoucher.NotsheetFile_V + "', '" + obVoucher.OfficerName_V + "', '" + obVoucher.OfficerTrno_I + "', '" + obVoucher.DesignationTrno_I + "'," +
             " '" + obVoucher.Designation_V + "', '" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + obVoucher.UserTrno_I + "', '" + obVoucher.BillPayTrno_I + "', '" + ddlForwardTo.SelectedValue + "'," +
             " '" + hfDepartmentId.Value + "', '0','" + fnChekRemark() + "','" + mType + "','" + dtNoteSheetDate.ToString("yyyy-MM-dd") + "','" + hfIsFinalBill.Value + "')");

                i = int.Parse(dt.Tables[0].Rows[0]["LastID"].ToString());

                if (obVoucher.VoucherTrno_I > 0)
                {
                    //dont update child table when voucher is reverted back to employee which he had created
                    if (hdnMode.Value == "e")
                    {
                    }
                    else
                    {
                        obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountDetails(4," + dt.Tables[0].Rows[0]["LastID"].ToString() + ",0," + ddlForwardTo.SelectedValue + ",'" + fnChekRemark() + "',0,0," + hfDepartmentId.Value + ",'" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + DesignationId + "',12)");
                        obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountDetails(0," + dt.Tables[0].Rows[0]["LastID"].ToString() + ",0," + DesignationId + ",'',0,0," + DepartmentId + ",'" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + DesignationId + "',12)");
                    }
                }
                else
                {
                    obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountDetails(0," + dt.Tables[0].Rows[0]["LastID"].ToString() + ",0," + DesignationId + ",'',0,0," + DepartmentId + ",'" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + DesignationId + "',12)");
                }

                if (hfSaveSend.Value == "1")
                {
                    if (hfLoggedInDeptName.Value == "Building & Vehicle")
                    {
                        obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountDetails(5," + dt.Tables[0].Rows[0]["LastID"].ToString() + ",0," + DesignationId + ",'',3,0," + DepartmentId + ",'" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + DesignationId + "',12)");
                    }
                    else
                        obcomm.FillDatasetByProc("call USP_Voucher_PreparationAccountDetails(3," + dt.Tables[0].Rows[0]["LastID"].ToString() + ",0," + DesignationId + ",'',0,0," + DepartmentId + ",'" + obVoucher.SanctionedAmountByBranchOfficer_N + "','" + DesignationId + "',12)");
                }

            }
            catch { }
        }

        return i;
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }

    
    public void SearchData()
    {
        try
        {
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.BillID_I = 0;
            objBillDetails.JobCode_V = Convert.ToString(txtSearch.Text);
            GrdLabMaster.DataSource = objBillDetails.SelectSearch();
            GrdLabMaster.DataBind();
        }
        catch { }

    }
   
    protected void GrdLabMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLabMaster.PageIndex = e.NewPageIndex;
        SearchData();
    }
    protected void GrdLabMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblBilldate = (Label)e.Row.FindControl("lblBilldate");
            //DateTime Dte = new DateTime();
            //Dte = DateTime.Parse(lblBilldate.Text);
            //lblBilldate.Text = Dte.ToString("dd/MM/yyyy");

            LinkButton lnk = (LinkButton)e.Row.FindControl("lnBtnViewGroup");
            HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
            Label ltrStatus = (Label)e.Row.FindControl("ltrStatus");
            HiddenField hdnIsChequeIssue = (HiddenField)e.Row.FindControl("hdnIsChequeIssue");
            Panel pnl2 = (Panel)e.Row.FindControl("Panel33");
            HiddenField hdnVchrStatus = (HiddenField)e.Row.FindControl("hdnVchrStatus");
            Panel Panel1 = (Panel)e.Row.FindControl("Panel1");
            HiddenField hdnVoucherID = (HiddenField)e.Row.FindControl("hdnVoucherID");
            Label ltrView = (Label)e.Row.FindControl("ltrView");
            ltrView.Visible = false;

            Literal ltrText = (Literal)e.Row.FindControl("ltrText");
            ltrText.Visible = false;

            Panel pnlCreateV = (Panel)e.Row.FindControl("pnlCreateV");
            Panel pnlEditV = (Panel)e.Row.FindControl("pnlEditV");
            Panel pnlViewV = (Panel)e.Row.FindControl("pnlViewV");

            if (hdnIsChequeIssue.Value == "1")
            {
                lnk.Visible = false;
                pnl2.Visible = true;

                pnlCreateV.Visible = false;
                pnlEditV.Visible = false;
                pnlViewV.Visible = true;
            }
            else if (int.Parse(hdnVchrStatus.Value)>=1)
            {
                lnk.Visible = false;
                pnl2.Visible = true;

                pnlCreateV.Visible = false;
                pnlEditV.Visible = false;
                //pnlViewV.Visible = true;
                if (hdnIsChequeIssue.Value == "2")
                {
                    pnlViewV.Visible = true;
                    pnlEditV.Visible = false;
                    ltrView.Visible = false;
                    ltrText.Visible = false;
                }
                else
                {
                    pnlViewV.Visible = false;
                    pnlEditV.Visible = true;
                    ltrView.Visible = true;
                    ltrText.Visible = true;
                }
            }
            else if (hdnIsChequeIssue.Value == "2" || hdnIsChequeIssue.Value == "3" || hdnIsChequeIssue.Value == "4")
            {
                lnk.Visible = false;
                pnl2.Visible = true;
            }

            if (hdnVchrStatus.Value == "0")
            {
                Panel1.Visible = true;
            }
            else
            {
                string Id = hdnVoucherID.Value;
                DataTable dt = obcomm.FillDatasetByProc("call USP_GET_Application_Request_Detail(10, " + Id + ")").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string CreatedByDesgId = dt.Rows[0]["DesignationTrno_I"].ToString();
                    string PendingDesgId = dt.Rows[0]["Approvedby"].ToString();
                    if ((CreatedByDesgId == PendingDesgId))
                    {
                        Panel1.Visible = true;
                        //pnlCreateV.Visible = false;
                        //pnlEditV.Visible = true;
                        //pnlViewV.Visible = false;
                    }
                    else Panel1.Visible = false;
                }
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        hfSaveSend.Value = "1";
        DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlForwardTo.SelectedValue + "',0,0)").Tables[0];
        string DesignationId = "0", DepartmentId = "0";
        if (dt.Rows.Count > 0)
        {
            try
            { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
            catch { DesignationId = "0"; }
            try
            { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
            catch { DepartmentId = "0"; }

            try
            {
                if (SaveVoucher(DesignationId, DepartmentId) > 0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record saved successfully.');", true);
                    fadeDiv.Style.Add("display", "none");
                    Messages.Style.Add("display", "none");
                    GridFillLoad();
                    //Response.Redirect("ViewBillDetails.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Error!');", true);
                }
            }
            catch { }
        }
    }

    public void GetEmployeeInfo(string DepartmentName, string mType, int mainDesgId)
    {
        try
        {
            string DeptName1 = "";

            string UserID = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_LIST_HR_Employee_Basic_Fiters(18,0,0," + UserID + ",'')").Tables[0];
            if (dt.Rows.Count > 0)
            {

                hfClassId.Value = dt.Rows[0]["ClassId"].ToString();
                hfDepartmentId.Value = dt.Rows[0]["DepartmentId"].ToString();

                hfEmployeeId.Value = dt.Rows[0]["EmployeeId"].ToString();
                hfDesignationId.Value = dt.Rows[0]["CEDesignationID"].ToString();
                hfUserId.Value = dt.Rows[0]["userId"].ToString();
                hfDesignationName.Value = dt.Rows[0]["DesignationName"].ToString();
                hfEmpFullName.Value = dt.Rows[0]["EmployeeFullName"].ToString();
                hfLoggedInDeptName.Value = dt.Rows[0]["DepartmentName"].ToString();

                //if (DepartmentName == "Building" || DepartmentName == "Vehicle")                
                //{
                //    FillEmployeesFowardMapping();
                //}else
                //    FillEmployees(dt.Rows[0]["EmployeeId"].ToString());

                string dAccount = "Account"; string dAudit = "Audit"; string dHO = "HO"; string dCash = "Cashier";

                if (mType == "0")
                {
                    if (DepartmentName == "Building" || DepartmentName == "Vehicle")
                    {
                        //dt = obCommonFuction.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(6,'" + hfClassId.Value + "'," + hfDepartmentId.Value + ",0)").Tables[0];

                        if (hfLoggedInDeptName.Value == "Building & Vehicle")
                        {
                            DeptName1 = dAccount + ",";

                            dt = obcomm.FillDatasetByProc("call  USP_NewVchr_DesignationMappingToDepartment(7,'" + hfClassId.Value + "'," +
                         "" + hfDepartmentId.Value + ",0,'" + DeptName1 + "','" + hfDesignationId.Value + "')").Tables[0];
                        }

                    }
                    else
                        dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(2,'" + hfClassId.Value + "'," + hfDepartmentId.Value + ",0)").Tables[0];
                }
                else
                {
                    if (hfLoggedInDeptName.Value == "Printing" || hfLoggedInDeptName.Value == "Paper")
                    {
                        DeptName1 = hfLoggedInDeptName.Value + ",";
                        if (mainDesgId == 11 || mainDesgId == 14 || mainDesgId == 8)
                        {
                        }
                        else
                            DeptName1 += dAccount;
                    }
                    else if (hfLoggedInDeptName.Value == "Account")
                    {
                        //DeptName1 = hfLoggedInDeptName.Value + "," + dHO + "," + dAudit + ",";
                        DeptName1 = hfLoggedInDeptName.Value + "," + dHO + "," + dAudit + "," + dCash + ",";
                        if (hfIsChequeIssue.Value != "")
                        {
                            if (int.Parse(hfIsChequeIssue.Value) >= 1)
                            {
                                //DeptName1 = hfLoggedInDeptName.Value + "," + dHO + "," + dAudit + ",";
                                DeptName1 = hfLoggedInDeptName.Value + "," + dHO + "," + dAudit + "," + dCash + ",";

                            }
                        }
                        else
                        {
                            if (DepartmentName == "Printing" || DepartmentName == "Paper")
                            {
                                DeptName1 += DepartmentName;
                            }

                            if (DepartmentName == "Account")  //HR Payroll Voucher
                            {
                                if (mainDesgId == 11 || mainDesgId == 14 || mainDesgId == 8)
                                {
                                    DeptName1 = dAccount;
                                }
                            }
                        }
                    }
                    else if (hfLoggedInDeptName.Value == "Audit")
                    {
                        DeptName1 = dAccount + "," + dCash + ",";
                    }
                    else if (hfLoggedInDeptName.Value == "HO")
                    {
                        DeptName1 = hfLoggedInDeptName.Value + "," + dAccount + ",";

                    }
                    else if (hfLoggedInDeptName.Value == "Cashier")
                    {
                        //DeptName1 = hfLoggedInDeptName.Value + "," + dAccount + ",";
                        DeptName1 = dAccount + "," + dAudit + ",";
                    }
                    else if (hfLoggedInDeptName.Value == "Building & Vehicle")
                    {
                        DeptName1 = dAccount + ",";
                    }

                    dt = obcomm.FillDatasetByProc("call  USP_NewVchr_DesignationMappingToDepartment(7,'" + hfClassId.Value + "'," +
                          "" + hfDepartmentId.Value + ",0,'" + DeptName1 + "','" + hfDesignationId.Value + "')").Tables[0];
                }

                if (dt.Rows.Count > 0)
                {
                    ddlForwardTo.DataSource = dt;
                    //ddlForwardTo.DataValueField = "DesignationId";
                    ddlForwardTo.DataValueField = "Id";
                    ddlForwardTo.DataTextField = "DesignationName";
                    ddlForwardTo.DataBind();
                    ddlForwardTo.Items.Insert(0, "Select");
                }
                else
                {
                    ddlForwardTo.DataSource = string.Empty;
                    ddlForwardTo.DataBind();
                    ddlForwardTo.Items.Insert(0, "Select");
                }
            }
            else
            {
                if (hfLoggedInDeptName.Value == "Cashier")
                {
                    DeptName1 = "Account,Audit";
                    dt = obcomm.FillDatasetByProc("call  USP_NewVchr_DesignationMappingToDepartment(7,'1'," +
                               "" + 2 + ",0,'" + DeptName1 + "','0')").Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ddlForwardTo.DataSource = dt;
                        //ddlForwardTo.DataValueField = "DesignationId";
                        ddlForwardTo.DataValueField = "Id";
                        ddlForwardTo.DataTextField = "DesignationName";
                        ddlForwardTo.DataBind();
                        ddlForwardTo.Items.Insert(0, "Select");
                    }
                    else
                    {
                        ddlForwardTo.DataSource = string.Empty;
                        ddlForwardTo.DataBind();
                        ddlForwardTo.Items.Insert(0, "Select");
                    }
                }
            }

        }
        catch { }
    }

    protected void lnkForwardBill_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");

        try
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)btn.NamingContainer;
            HDNVchrID.Value = ((HiddenField)gv.FindControl("hdnVoucherID")).Value;
            GetEmployeeInfo(btn.CommandName.ToString(), "0", 0);

            hdnMode.Value = HDNVchrID.Value != "0" ? "e" : "";

            if (hdnMode.Value == "e" && hdnStatus_M.Value == "0")
            {
                hfRevert.Value = "3";
            }

            if (btn.CommandName.ToString() == "Printing")
            {
                if (hfIsFinalBill.Value == "1")
                {
                    LoadAllBillDetails_Final(btn.CommandArgument.ToString());
                }
                else
                {
                    //LoadAllBillDetails(btn.CommandArgument.ToString());
                }
                    

            }
        }
        catch { }
    }

    public void LoadAllBillDetails_Final(string BillID)
    {
        try
        {
            Pri_BillDetails_New objBillDetails = new Pri_BillDetails_New();
            objBillDetails.BillID_I = int.Parse(BillID);
            //objBillDetails.BillID_I = int.Parse(objdb.Decrypt(Request.QueryString["BillID11"]).ToString());  //change 2682017 during voucher edit

            objBillDetails.BillDate_D = DateTime.Parse(System.DateTime.Now.ToString("yyyy-MM-dd"));
            ds = objBillDetails.FieldFill_FinalPRIBill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //DateTime dat = new DateTime();
                //DateTime datch = new DateTime();
                //dat = DateTime.Parse(ds.Tables[0].Rows[0]["BillDate_D"].ToString());

                //ViewState["BillID_I"] = objdb.Decrypt(Request.QueryString["BillID"]).ToString();
                ViewState["BillID_I"] = BillID;
                txtDepartmentName_V.Enabled = false;
                txtLekhaSheersh_V.Text = "Final Printing Charges Payable";
                //txtLekhaSheersh_V.Enabled = false;

                txtSanctionedAmount_N.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
                txtSanctionedAmount_N.Enabled = false;
                txtSamayojanAmount_N.Text = ds.Tables[0].Rows[0]["TotalDed_N"].ToString();
                txtSamayojanAmount_N.Enabled = false;
                txtPayAmount_N.Text = ds.Tables[0].Rows[0]["NetPayable_N"].ToString();
                txtPayAmount_N.Enabled = false;


                //txtPartyBillDate_D.Text = dat.ToString("dd/MM/yyyy");
                txtPartyBillDate_D.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtPartyBillDate_D.Enabled = false;

                txtPartyName_V.Text = ds.Tables[0].Rows[0]["NameofPress_V"].ToString();
                txtPartyTrno_I.Text = ds.Tables[0].Rows[0]["Printer_RedID_I"].ToString();

                //txtPartyBillNo_V.Text = ds.Tables[0].Rows[0]["Billno_V"].ToString();
                //get autogenerate bill no
                string acyear = ds.Tables[0].Rows[0]["AcYear"].ToString();
                string strBillNo = obcomm.FillScalarByProc("SELECT FN_GetAllBillNos_FinalBill('Printer','" + txtPartyTrno_I.Text + "','" + acyear + "')");
                txtPartyBillNo_V.Text = strBillNo;

                //txtPartyName_V.Text = ds.Tables[0].Rows[0]["NameofPress_V"].ToString();
                
                txtPartyName_V.Enabled = true;
                txtPartyBillNo_V.Enabled = false;

                txtOfficerName_V.Text = hfEmpFullName.Value;
                txtOfficerName_V.Enabled = false;
                txtDesignationTrno_I.Text = hfDesignationName.Value;
                txtDesignationTrno_I.Enabled = false;
                

                txtSamayojanAmount_N_Account.Text = "0";
                txtPayAmount_N_Account.Text = "0";

                txtPreviousBillAmount_N.Text = ds.Tables[0].Rows[0]["LastBillAmt"].ToString();
                txtPreviousBillAmount_N.Enabled = false;
                HDNBillPayTrno_I.Value = BillID;
            }
        }
        catch { }

    }

    protected void GrdLabMaster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchData();

    }

     public class Pri_BillDetails_New
    {   private int _Printer_RedID_I;
        private int _ChallanTrno_I;
        private int _PriTransID;
        private int _User_ID;
        private int _BillID_I;
        private string _Billno_V;
        private DateTime _BillDate_D;
        private int _PrinterID_I;
        private int _BookTitleID_I;
        private float _TotalPaperSup_N;
        private float _TotCovPaperSup_N;
        private float _PapSecReimburse_N;
        private float _BalSecurity_N;
        private float _PrnChrg100per_N;
        private float _PrnChrg25per_N;
        private float _PrnChrg75per_N;
        private float _PaperSecforton_N;
        private float _PaperReemRs_N;
        private float _TonsPerReem_N;
        private float _Reimburseamt_N;
        private float _PayablePrnchrg_N;
        private float _Totalpayable_N;
        private float _DedIncometax_N;
        private float _DedpapSec_N;
        private float _DedDepoExp_N;
        private float _DedInterestonpaper_N;
        private float _PenDelaySup_N;
        private float _DedShotSizePaper1_N;
        private float _DedShotSizePaper2_N;
        private float _DedShotSizePaper3_N;
        private float _TotalDed_N;
        private float _NetPayable_N;
        private float _PaperSecurityDeposit;
        private float _BFPay;
        private string _JobCode_V;
        private float _BillAmountofDeduction;
        private float _BillAmount;
        private float _BillNetPayablePrinting;

         private int _BlankPages ;
         private int _TotBlankPage;

        //Details
        private int _BillDetID_I;
        private int _Depotid_I;
        private float _Qty_N;
        private float _Rate_N;
        private float _Pages_N;
        private float _Amount_N;
        private float _PaperConsum_Wastage_N;
        private float _CoverPaperConsum_Wastage_N;
        private DateTime _ChallanRecDate_D;


        public int BlankPages { get { return _BlankPages; } set { _BlankPages = value; } }
        public int TotBlankPage { get { return _TotBlankPage; } set { _TotBlankPage = value; } }

        public float BillNetPayablePrinting { get { return _BillNetPayablePrinting; } set { _BillNetPayablePrinting = value; } }
        public float BillAmountofDeduction { get { return _BillAmountofDeduction; } set { _BillAmountofDeduction = value; } }
        public float BillAmount { get { return _BillAmount; } set { _BillAmount = value; } }
        public float BFPay { get { return _BFPay; } set { _BFPay = value; } }
        public float PaperSecurityDeposit { get { return _PaperSecurityDeposit; } set { _PaperSecurityDeposit = value; } }
        public int BillDetID_I { get { return _BillDetID_I; } set { _BillDetID_I = value; } }
        public int Depotid_I { get { return _Depotid_I; } set { _Depotid_I = value; } }
        public float Qty_N { get { return _Qty_N; } set { _Qty_N = value; } }
        public float Rate_N { get { return _Rate_N; } set { _Rate_N = value; } }
        public float Pages_N { get { return _Pages_N; } set { _Pages_N = value; } }
        public float Amount_N { get { return _Amount_N; } set { _Amount_N = value; } }
        public float PaperConsum_Wastage_N { get { return _PaperConsum_Wastage_N; } set { _PaperConsum_Wastage_N = value; } }
        public float CoverPaperConsum_Wastage_N { get { return _CoverPaperConsum_Wastage_N; } set { _CoverPaperConsum_Wastage_N = value; } }
        public DateTime ChallanRecDate_D { get { return _ChallanRecDate_D; } set { _ChallanRecDate_D = value; } }

        // end


        public int BillID_I { get { return _BillID_I; } set { _BillID_I = value; } }
        public string Billno_V { get { return _Billno_V; } set { _Billno_V = value; } }
        public DateTime BillDate_D { get { return _BillDate_D; } set { _BillDate_D = value; } }
        public int PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public int BookTitleID_I { get { return _BookTitleID_I; } set { _BookTitleID_I = value; } }
        public float TotalPaperSup_N { get { return _TotalPaperSup_N; } set { _TotalPaperSup_N = value; } }
        public float TotCovPaperSup_N { get { return _TotCovPaperSup_N; } set { _TotCovPaperSup_N = value; } }
        public float PapSecReimburse_N { get { return _PapSecReimburse_N; } set { _PapSecReimburse_N = value; } }
        public float BalSecurity_N { get { return _BalSecurity_N; } set { _BalSecurity_N = value; } }
        public float PrnChrg100per_N { get { return _PrnChrg100per_N; } set { _PrnChrg100per_N = value; } }
        public float PrnChrg25per_N { get { return _PrnChrg25per_N; } set { _PrnChrg25per_N = value; } }
        public float PrnChrg75per_N { get { return _PrnChrg75per_N; } set { _PrnChrg75per_N = value; } }
        public float PaperSecforton_N { get { return _PaperSecforton_N; } set { _PaperSecforton_N = value; } }
        public float PaperReemRs_N { get { return _PaperReemRs_N; } set { _PaperReemRs_N = value; } }
        public float TonsPerReem_N { get { return _TonsPerReem_N; } set { _TonsPerReem_N = value; } }
        public float Reimburseamt_N { get { return _Reimburseamt_N; } set { _Reimburseamt_N = value; } }
        public float PayablePrnchrg_N { get { return _PayablePrnchrg_N; } set { _PayablePrnchrg_N = value; } }
        public float Totalpayable_N { get { return _Totalpayable_N; } set { _Totalpayable_N = value; } }
        public float DedIncometax_N { get { return _DedIncometax_N; } set { _DedIncometax_N = value; } }
        public float DedpapSec_N { get { return _DedpapSec_N; } set { _DedpapSec_N = value; } }
        public float DedDepoExp_N { get { return _DedDepoExp_N; } set { _DedDepoExp_N = value; } }
        public float DedInterestonpaper_N { get { return _DedInterestonpaper_N; } set { _DedInterestonpaper_N = value; } }
        public float PenDelaySup_N { get { return _PenDelaySup_N; } set { _PenDelaySup_N = value; } }
        public float DedShotSizePaper1_N { get { return _DedShotSizePaper1_N; } set { _DedShotSizePaper1_N = value; } }
        public float DedShotSizePaper2_N { get { return _DedShotSizePaper2_N; } set { _DedShotSizePaper2_N = value; } }
        public float DedShotSizePaper3_N { get { return _DedShotSizePaper3_N; } set { _DedShotSizePaper3_N = value; } }
        public float TotalDed_N { get { return _TotalDed_N; } set { _TotalDed_N = value; } }
        public float NetPayable_N { get { return _NetPayable_N; } set { _NetPayable_N = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }



        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public int ChallanTrno_I { get { return _ChallanTrno_I; } set { _ChallanTrno_I = value; } }
        public int PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int User_ID { get { return _User_ID; } set { _User_ID = value; } }

        public int MasterUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mBillno_V", Billno_V);
            obDBAccess.addParam("mBillDate_D", BillDate_D);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mBookTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mTotalPaperSup_N", TotalPaperSup_N);
            obDBAccess.addParam("mTotCovPaperSup_N", TotCovPaperSup_N);
            obDBAccess.addParam("mPapSecReimburse_N", PapSecReimburse_N);
            obDBAccess.addParam("mBalSecurity_N", BalSecurity_N);
            obDBAccess.addParam("mPrnChrg100per_N", PrnChrg100per_N);
            obDBAccess.addParam("mPrnChrg25per_N", PrnChrg25per_N);
            obDBAccess.addParam("mPrnChrg75per_N", PrnChrg75per_N);
            obDBAccess.addParam("mPaperSecforton_N", PaperSecforton_N);
            obDBAccess.addParam("mPaperReemRs_N", PaperReemRs_N);
            obDBAccess.addParam("mTonsPerReem_N", TonsPerReem_N);
            obDBAccess.addParam("mReimburseamt_N", Reimburseamt_N);
            obDBAccess.addParam("mPayablePrnchrg_N", PayablePrnchrg_N);
            obDBAccess.addParam("mTotalpayable_N", Totalpayable_N);
            obDBAccess.addParam("mDedIncometax_N", DedIncometax_N);
            obDBAccess.addParam("mDedpapSec_N", DedpapSec_N);
            obDBAccess.addParam("mDedDepoExp_N", DedDepoExp_N);
            obDBAccess.addParam("mDedInterestonpaper_N", DedInterestonpaper_N);
            obDBAccess.addParam("mPenDelaySup_N", PenDelaySup_N);
            obDBAccess.addParam("mDedShotSizePaper1_N", DedShotSizePaper1_N);
            obDBAccess.addParam("mDedShotSizePaper2_N", DedShotSizePaper2_N);
            obDBAccess.addParam("mDedShotSizePaper3_N", DedShotSizePaper3_N);
            obDBAccess.addParam("mTotalDed_N", TotalDed_N);
            obDBAccess.addParam("mNetPayable_N", NetPayable_N);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mPaperSecurityDeposit", PaperSecurityDeposit);
            obDBAccess.addParam("mBFPay", BFPay);
      
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mBillno_V", Billno_V);
            obDBAccess.addParam("mBillDate_D", BillDate_D);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mBookTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mTotalPaperSup_N", TotalPaperSup_N);
            obDBAccess.addParam("mTotCovPaperSup_N", TotCovPaperSup_N);
            obDBAccess.addParam("mPapSecReimburse_N", PapSecReimburse_N);
            obDBAccess.addParam("mBalSecurity_N", BalSecurity_N);
            obDBAccess.addParam("mPrnChrg100per_N", PrnChrg100per_N);
            obDBAccess.addParam("mPrnChrg25per_N", PrnChrg25per_N);
            obDBAccess.addParam("mPrnChrg75per_N", PrnChrg75per_N);
            obDBAccess.addParam("mPaperSecforton_N", PaperSecforton_N);
            obDBAccess.addParam("mPaperReemRs_N", PaperReemRs_N);
            obDBAccess.addParam("mTonsPerReem_N", TonsPerReem_N);
            obDBAccess.addParam("mReimburseamt_N", Reimburseamt_N);
            obDBAccess.addParam("mPayablePrnchrg_N", PayablePrnchrg_N);
            obDBAccess.addParam("mTotalpayable_N", Totalpayable_N);
            obDBAccess.addParam("mDedIncometax_N", DedIncometax_N);
            obDBAccess.addParam("mDedpapSec_N", DedpapSec_N);
            obDBAccess.addParam("mDedDepoExp_N", DedDepoExp_N);
            obDBAccess.addParam("mDedInterestonpaper_N", DedInterestonpaper_N);
            obDBAccess.addParam("mPenDelaySup_N", PenDelaySup_N);
            obDBAccess.addParam("mDedShotSizePaper1_N", DedShotSizePaper1_N);
            obDBAccess.addParam("mDedShotSizePaper2_N", DedShotSizePaper2_N);
            obDBAccess.addParam("mDedShotSizePaper3_N", DedShotSizePaper3_N);
            obDBAccess.addParam("mTotalDed_N", TotalDed_N);
            obDBAccess.addParam("mNetPayable_N", NetPayable_N);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mPaperSecurityDeposit", PaperSecurityDeposit);
            obDBAccess.addParam("mBFPay", BFPay);
            
            int i = Convert.ToInt32(obDBAccess.executeMyScalar());
            return i;
        }
        public int ChildInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveChildUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", BillDetID_I);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mDepotid_I", Depotid_I);
            obDBAccess.addParam("mQty_N", Qty_N);
            obDBAccess.addParam("mRate_N", Rate_N);
            obDBAccess.addParam("mPages_N", Pages_N);
            obDBAccess.addParam("mAmount_N", Amount_N);
            obDBAccess.addParam("mPaperConsum_Wastage_N", PaperConsum_Wastage_N);
            obDBAccess.addParam("mCoverPaperConsum_Wastage_N", CoverPaperConsum_Wastage_N);
            obDBAccess.addParam("mTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mBlankPages", BlankPages);
            obDBAccess.addParam("mTotBlankPage", TotBlankPage);             
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet PrinterDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet BillChildDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);        
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin008_FinalBillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", User_ID);
            obDBAccess.addParam("mtype", 2);
            obDBAccess.addParam("mReceiptDate", "2017-04-11");
            obDBAccess.addParam("mBillDate", "2017-04-17"); 
            return obDBAccess.records();
           
        }

        public System.Data.DataSet SelectSearch()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin008_FinalBillDetailsFillSearch", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinter",JobCode_V );
            return obDBAccess.records();          
         }
        public System.Data.DataSet FieldFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I",BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 3);
            obDBAccess.addParam("mReceiptDate", "2017-04-11");
            obDBAccess.addParam("mBillDate", "2017-04-17"); 
            return obDBAccess.records();

        }
        public int SendToFinance()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 4);
            obDBAccess.addParam("mReceiptDate", "2017-04-11");
            obDBAccess.addParam("mBillDate", "2017-04-17"); 
            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet FieldFill_FinalPRIBill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin008_FinalBillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 3);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);
            return obDBAccess.records();

        }

        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterDelete", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", id);

        //    int result = obDBAccess.executeMyQuery();
        //    return result;
        //}
    }


     protected void lnBtnViewGroup_Click(object sender, EventArgs e)
     {
         LinkButton lnkSender = (LinkButton)sender;
         GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;

         HiddenField HBill = (HiddenField)gv.FindControl("HidBill");

         objBillDetails = new Pri_BillDetails_New();
         objBillDetails.BillID_I = int.Parse(HBill.Value);
         int i = objBillDetails.SendToFinance();         
         GridFillLoad();
         ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Status updated successfully.');</script>");
     }
}
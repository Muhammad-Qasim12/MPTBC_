using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EmployeeHome : System.Web.UI.Page
{
    CommonFuction obcomm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string uid = Session["UserID"].ToString();
            GetDesignationId();
            FillLeaveRequests();
            FillForwardedLeaves();
            FillTravelingStatus();
            FillForwardedTraveling();
            FillGrainAdvance();
            FillGrainAdvanceApproval();
            FillMedicalAdvApplication();
            FillMedicalAdvApproval();
            FillFestivalAdvanceStatus();
            FillFestivalAdvanceApproval();
            FillTransferApplicationApproval();
            FillTransferApplicationStatus();
            FillPFApplicationStatus();
            FillPFApproval();
            fillGrid();
            ddlTravelApprovedBy.DataSource = ddlMedicalApprovedBy.DataSource = ddlPFApprovedBy.DataSource = ddlGrainApprovedBy.DataSource = ddlFestivalApprovedBy.DataSource = ddlTForwardTo.DataSource = ddlForwardTo.DataSource = obcomm.FillDatasetByProc("call USP_HR_EmployeeListDDL(0,'" + Session["UserID"] + "')").Tables[4];
            ddlTravelApprovedBy.DataTextField = ddlMedicalApprovedBy.DataTextField = ddlPFApprovedBy.DataTextField = ddlGrainApprovedBy.DataTextField = ddlFestivalApprovedBy.DataTextField = ddlTForwardTo.DataTextField = ddlForwardTo.DataTextField = "DesignationName";
            ddlTravelApprovedBy.DataValueField = ddlMedicalApprovedBy.DataValueField = ddlPFApprovedBy.DataValueField = ddlGrainApprovedBy.DataValueField = ddlFestivalApprovedBy.DataValueField = ddlTForwardTo.DataValueField = ddlForwardTo.DataValueField = "DesignationId";
            ddlForwardTo.DataBind();
            ddlForwardTo.Items.Insert(0, "सलेक्ट करे ..");
            ddlTForwardTo.DataBind();
            ddlTForwardTo.Items.Insert(0, "सलेक्ट करे ..");

            ddlMedicalApprovedBy.DataBind();
            ddlMedicalApprovedBy.Items.Insert(0, "सलेक्ट करे ..");

            ddlPFApprovedBy.DataBind();
            ddlPFApprovedBy.Items.Insert(0, "सलेक्ट करे ..");

            ddlGrainApprovedBy.DataBind();
            ddlGrainApprovedBy.Items.Insert(0, "सलेक्ट करे ..");

            ddlFestivalApprovedBy.DataBind();
            ddlFestivalApprovedBy.Items.Insert(0, "सलेक्ट करे ..");

            ddlTravelApprovedBy.DataBind();
            ddlTravelApprovedBy.Items.Insert(0, "सलेक्ट करे ..");
            GetApprovedLeave();
            ddlComplaintForWord.DataSource = obcomm.FillDatasetByProc("call USP_HR_EmployeeListDDL(0,'" + Session["UserID"] + "')");
            ddlComplaintForWord.DataTextField = "EmployeeName";
            ddlComplaintForWord.DataValueField = "EmployeeId";
            ddlComplaintForWord.DataBind();
            ddlComplaintForWord.Items.Insert(0, "सलेक्ट करे ..");
            FillComplaint();

            //printing voucher detail
            FillVoucherBillForwarded();
            //FillVoucherBillBankDetails();
        }
    }

    public void FillComplaint()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_hr_employeecomplain(2,0,0,0," + Session["UserID"] + ")").Tables[0];
            DataTable dt1 =  obcomm.FillDatasetByProc("call USP_hr_employeecomplain(4,0,0,0," + Session["UserID"] + ")").Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdComplaintStatus.DataSource = dt1;
                grdComplaintStatus.DataBind();
                pnComplaintStatus.Visible = true;
            }
            else
            {
                grdComplaintStatus.DataSource = null;
                grdComplaintStatus.DataBind();
                pnComplaintStatus.Visible = false;
            }
            
           
            if (dt.Rows.Count > 0)
            {
                GrdComplaint.DataSource = dt;
                GrdComplaint.DataBind();
                pnaComplatin.Visible = true;

            }
            else
            {
                GrdComplaint.DataSource = null;
                GrdComplaint.DataBind();
                pnaComplatin.Visible = false;
            }
        }
        catch { }
    }
    protected void btnComp_Click(object sender, EventArgs e)
    {
        try
        {
            HiddenField2.Value = "";
            HiddenField3.Value = "";

            CommonFuction obCommonFuction = new CommonFuction();

            Button bt = (Button)sender;
            GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
            Label lblLeaveId = grdrow.FindControl("lblLeaveId") as Label;
            DataTable dt = obcomm.FillDatasetByProc("call USP_hr_employeecomplain(3,0,0,0," + bt.CommandArgument + ")").Tables[0];
            HiddenField2.Value = ((HiddenField)grdrow.FindControl("HiddenField1")).Value;
            HiddenField3.Value = lblLeaveId.Text;
            if (dt.Rows.Count > 0)
            {
                lblApplicantName.Text = dt.Rows[0]["EmployeeName"].ToString();
                lblComplaint.Text = dt.Rows[0]["ComplaintDetails "].ToString();
                lblReason.Text = dt.Rows[0]["Resoan"].ToString();
                Div1.Style.Add("display", "block");
                Div4.Style.Add("display", "block");
            }
            FillComplaint();
        }
        catch { }

    }
    protected void btn_Complaint01_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();

            //Button bt = (Button)sender;
            //GridViewRow grdrow = (GridViewRow)bt.NamingContainer;

            if (RadioButtonList2.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_ComplaintDetails(1," + HiddenField3.Value + "," + Session["UserID"].ToString() + ",0,'',0," + HiddenField2.Value + ")");
                obcomm.FillDatasetByProc("call USP_ComplaintDetails(1,0,'" + HiddenField3.Value + "',0,'" + TextBox1.Text + "',0," + HiddenField2.Value + ")");

                ddlComplaintForWord.Enabled = false;
            }
            else
            {

                obcomm.FillDatasetByProc("call USP_ComplaintDetails(1," + HiddenField3.Value + "," + Session["UserID"].ToString() + "," + ddlComplaintForWord.SelectedValue + ",'',0," + HiddenField2.Value + ")");
            }
            //
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('complaint remark updated');</script>");

            Div1.Style.Add("display", "none");
            Div4.Style.Add("display", "none");
            FillComplaint();
        }
        catch { }

    }
    protected void btn_Complaint02_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();

            Button bt = (Button)sender;
            GridViewRow grdrow = (GridViewRow)bt.NamingContainer;

            //DataTable dt = obCommonFuction.FillDatasetByProc(@"call USP_HR_LIST_HRLoanDetails(" + bt.CommandArgument + ", 0);").Tables[0];
            //gvLoansInstallment.DataSource = dt;
            //gvLoansInstallment.DataBind();
            //    Label2.Text = grdrow.Cells[3].Text;
            Div1.Style.Add("display", "block");
            Div4.Style.Add("display", "block");
        }
        catch { }

    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "2")
        {
            ddlComplaintForWord.Enabled = false;
        }
        else
        {
            ddlComplaintForWord.Enabled = true;
        }

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
                if (dt.Rows[0]["DepartmentName"] != null)
                {
                    if (dt.Rows[0]["DepartmentName"].ToString() == "Printing")
                    {
                        hfLoggedInDepartment.Value = dt.Rows[0]["DepartmentName"].ToString();
                    }
                    else if (dt.Rows[0]["DepartmentName"].ToString() == "Paper")
                    {
                       // hfLoggedInDepartment.Value = dt.Rows[0]["DepartmentName"].ToString();
                        hfLoggedInDepartment.Value ="";
                    }
                    else if (dt.Rows[0]["DepartmentName"].ToString() == "Building & Vehicle")
                    {
                        //hfLoggedInDepartment.Value = "Building";
                        hfLoggedInDepartment.Value = "";
                    }
                    else
                        hfLoggedInDepartment.Value = "";
                }
                
            }
            else
            {
                hfDesignationId.Value = "0";
                hfDepartmentId.Value = "0";
                hfLoggedInDepartment.Value = "";
            }

        }
        catch { }
    }

    public void FillLeaveRequests()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_LeaveRequestFill(0,'" + Session["UserID"] + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdLeaveStatus.DataSource = dt;
                GrdLeaveStatus.DataBind();
                pnlLeaveStatus.Visible = true;
            }
            else
            {
                GrdLeaveStatus.DataSource = null;
                GrdLeaveStatus.DataBind();
                pnlLeaveStatus.Visible = false;
            }
        }
        catch { }
    }

    public void FillForwardedLeaves()
    {
        try
        {
            string id = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(4,'" + hfDesignationId.Value + "', 0,"+hfDepartmentId.Value+"," + System.DateTime.Now.Year + ",0,0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdLeaveApproval.DataSource = dt;
                GrdLeaveApproval.DataBind();
                pnlLeaveApproval.Visible = true;
            }
            else
            {
                GrdLeaveApproval.DataSource = null;
                GrdLeaveApproval.DataBind();
                pnlLeaveApproval.Visible = false;
            }
        }
        catch { }
    }

    protected void GrdPriBillVoucherFill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    System.Web.UI.HtmlControls.HtmlAnchor hreflnk = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("hreflnk");
                    LinkButton lnkBill = (LinkButton)e.Row.FindControl("lnkBill");
                    HiddenField hfIsFinalBill = (HiddenField)e.Row.FindControl("hfIsFinalBill");
                    string DepartmentName_V = DataBinder.Eval(e.Row.DataItem, "DepartmentName_V").ToString();                   
                    string BillID_I = DataBinder.Eval(e.Row.DataItem, "BillID_I").ToString();
                    
                   //<a href="Printing/PRI003_BillDetails.aspx?ID=<%#new APIProcedure().Encrypt(Eval("BillID_I").ToString()) %>&vw=1" 
                    //target="_blank"><%#Eval("PartyBillNo_V")%></a>

                    //hreflnk.Target = "_blank";

                    if (DepartmentName_V == "Building")
                    {
                        hreflnk.HRef = "Building/Building006_Payments.aspx?Cid=" + new APIProcedure().Encrypt(BillID_I) + "&vw=1";
                    }
                    else if (DepartmentName_V == "Printing")
                    {
                        if (hfIsFinalBill.Value == "1")
                        {
                            hreflnk.HRef = "Printing/PRI008_FinalBillDetails.aspx?ID=" + new APIProcedure().Encrypt(BillID_I) + "&vw="+ new APIProcedure().Encrypt("home");   
                        }
                        else
                            hreflnk.HRef = "Printing/PRI003_BillDetails.aspx?ID="+new APIProcedure().Encrypt(BillID_I)+"&vw=home";                        
                    }
                    else if (DepartmentName_V == "Vehicle")
                    {
                        string VoucherID = DataBinder.Eval(e.Row.DataItem, "VoucherTrno_I").ToString();
                        hreflnk.HRef = "PRI003_CreateVoucherNew.aspx?Cid="+new APIProcedure().Encrypt(VoucherID)+"&vw="+new APIProcedure().Encrypt(DepartmentName_V)+"&id="+new APIProcedure().Encrypt("0")+"&b=home";
                    }
                    else if (DepartmentName_V == "Paper")
                    {
                        hreflnk.HRef = "paper/CreateVouchar.aspx?ID="+ new APIProcedure().Encrypt(BillID_I) + "&vw=1";
                    }
                    else if (DepartmentName_V == "Account")
                    {
                        hreflnk.Visible = false;
                        lnkBill.Visible = true;
                    }
                    else if (DepartmentName_V == "Store")
                    {
                        string PurchaseOrderID_I = obcomm.FillDatasetByProc("call USP_PPR0018_VoucharDataShow(0,0,0,0,'" + BillID_I + "',17)").Tables[0].Rows[0][0].ToString();
                        hreflnk.HRef = "Store/VIEW_STR007_AcceptPurchaseItems.aspx?ID=" + new APIProcedure().Encrypt(PurchaseOrderID_I) + "&vw=" + new APIProcedure().Encrypt(BillID_I) + "&mod=" + new APIProcedure().Encrypt("home");
                    }
                }
                catch { }
            }
       
        
    }

    protected void lnBtnViewIndent_Click(object sender, EventArgs e)
    {
        Messages11.Style.Add("display", "block");
        fadeDiv11.Style.Add("display", "block");

        try
        {
            LinkButton lnkSender = (LinkButton)sender;
            string id = lnkSender.CommandArgument.ToString();
            CommonFuction obCommonFuction = new CommonFuction();
            DataTable dt = obCommonFuction.FillDatasetByProc("call USP_GetPayrolBill(0,0,'"+id+"',1)").Tables[0];
            GrdViewIndentDetails.DataSource = dt;
            GrdViewIndentDetails.DataBind();
        }
        catch { }
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");

        Messages11.Style.Add("display", "none");
        fadeDiv11.Style.Add("display", "none");
    }

    

    public void FillVoucherBillForwarded()
    {
       
        try
        {
            string id = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_Voucher_PrepareAccountForwardedFill(4,'" + hfDesignationId.Value + "', 0," + hfDepartmentId.Value + "," + System.DateTime.Now.Year + ",0,0,'" + id + "','" + hfLoggedInDepartment.Value + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdPriBillVoucherFill.DataSource = dt;
                GrdPriBillVoucherFill.DataBind();
                pnlPrintingVoucherBill.Visible = true;
            }
            else
            {
                GrdPriBillVoucherFill.DataSource = null;
                GrdPriBillVoucherFill.DataBind();
                pnlPrintingVoucherBill.Visible = false;
            }
        }
        catch { }
    }

    public void FillVoucherBillBankDetails()
    {
        try
        {
            string id = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_Voucher_PrepareAccountForwardedFill(5,'" + hfDesignationId.Value + "', 0," + hfDepartmentId.Value + "," + System.DateTime.Now.Year + ",0,0,'" + id + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdBankDetailsBill.DataSource = dt;
                GrdBankDetailsBill.DataBind();
                pnlBankDetailsBill.Visible = true;
                
            }
            else
            {
                GrdBankDetailsBill.DataSource = null;
                GrdBankDetailsBill.DataBind();
                pnlBankDetailsBill.Visible = false;
            }
        }
        catch { }
    }

    public void FillGrainAdvance()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_GrainAdvanceApplicationList(0,'" + Session["UserID"] + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdGrainAdvance.DataSource = dt;
                GrdGrainAdvance.DataBind();
                pnlGrainAdvance.Visible = true;
            }
            else
            {
                GrdGrainAdvance.DataSource = null;
                GrdGrainAdvance.DataBind();
                pnlGrainAdvance.Visible = false;
            }
        }
        catch { }
    }

    public void FillGrainAdvanceApproval()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_GrainAdvanceApplicationForwarded(0,'" + hfDepartmentId.Value + "','" + hfDesignationId.Value + "',0,0,0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdGrainAdvApproval.DataSource = dt;
                GrdGrainAdvApproval.DataBind();
                pnlGrainAdvApproval.Visible = true;
            }
            else
            {
                GrdGrainAdvApproval.DataSource = null;
                GrdGrainAdvApproval.DataBind();
                pnlGrainAdvApproval.Visible = false;
            }
        }
        catch { }
    }

    protected void GrdLeaveStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLeaveStatus.PageIndex = e.NewPageIndex;
        FillLeaveRequests();
    }
   
    protected void GrdLeaveApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLeaveApproval.PageIndex = e.NewPageIndex;
        FillForwardedLeaves();
    }
    protected void lnkApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblLeaveId = grdrow.FindControl("lblLeaveId") as Label;
            Label lblAssignedEmp = grdrow.FindControl("lblAssignedEmp") as Label;
            Label lblApplicantDeptId = grdrow.FindControl("lblApplicantDeptId") as Label;
            Label lblApplicantId = grdrow.FindControl("lblApplicantId") as Label;
            lblApplicant.Text=grdrow.Cells[2].Text ;
            lblFrom.Text = grdrow.Cells[3].Text;
            lblTo.Text = grdrow.Cells[4].Text;
            lblLeaveType.Text = grdrow.Cells[6].Text;
            lblAssignedEmployee.Text = lblAssignedEmp.Text;
            ddlAssignedEmployee.SelectedIndex = -1;
            fadeDiv.Style.Add("display", "block");
            Messages.Style.Add("display", "block");
            HiddenField2.Value = ((HiddenField)grdrow.FindControl("HiddenField1")).Value;
            HiddenField3.Value = lblLeaveId.Text;
            DataSet dt123= obcomm.FillDatasetByProc("call USP_HR_GetClass(" + lblLeaveId.Text+ ")");
            HiddenField4.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString();
            if (Convert.ToString(HiddenField4.Value) == Convert.ToString(hfDesignationId.Value))
            {
                lblFarwardTo.Visible = false;
                ddlForwardTo.Visible = false;
                lblLeaveStatus.Visible = true;
                RadioButtonList1.Visible = true;
                RadioButtonList1.SelectedValue = "1";
                hfApprovedFlag.Value = "1";
            }
            else
            {
                lblFarwardTo.Visible = true;
                ddlForwardTo.Visible = true;
                lblLeaveStatus.Visible = false;
                RadioButtonList1.Visible = false;
                RadioButtonList1.SelectedValue = "3";
                hfApprovedFlag.Value = "0";
            }
            
            DataTable dt2 = obcomm.FillDatasetByProc("call USP_GET_Application_Request_Detail(2,'" + lblLeaveId.Text + "')").Tables[0];
            if (dt2.Rows.Count == 1)
            {
                ddlAssignedEmployee.Visible = true;
                lblAssignedEmployee.Visible = false;
                DataTable dt1 = obcomm.FillDatasetByProc("call USP_UI_hr_DesignationMappingToDepartment(4,0,'" + lblApplicantDeptId.Text + "', '" + lblApplicantId.Text + "')").Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    ddlAssignedEmployee.DataSource = dt1;
                    ddlAssignedEmployee.DataValueField = "EmployeeId";
                    ddlAssignedEmployee.DataTextField = "EmployeeName";
                    ddlAssignedEmployee.DataBind();
                }
            }
            else
            {
                ddlAssignedEmployee.Visible = false;
                lblAssignedEmployee.Visible = true;
            }
           
            //obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(1,0,'" + lblLeaveId.Text + "',0,0,0,0)");
          //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Leave Approved');</script>");
            FillForwardedLeaves();
        }
        catch { }
       
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        try
        {
            //GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            //Label lblLeaveId = grdrow.FindControl("lblLeaveId") as Label;
            //obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(2,0,'" + lblLeaveId.Text + "',0,0,0,0)");
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Leave Cancelled');</script>");
            //FillForwardedLeaves();
        }
        catch { }
        
    }
    public void FillTravelingStatus()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_hr_travellingapplicationList(2,'" + Session["UserID"] + "',0,0,0,0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdTravelingStatus.DataSource = dt;
                GrdTravelingStatus.DataBind();
                pnlTravelingStatus.Visible = true;
            }
            else
            {
                GrdTravelingStatus.DataSource = null;
                GrdTravelingStatus.DataBind();
                pnlTravelingStatus.Visible = false;
            }
        }
        catch { }
    }
    protected void GrdTravelingStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTravelingStatus.PageIndex = e.NewPageIndex;
        FillTravelingStatus();
    }

    public void FillForwardedTraveling()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_hr_travellingapplicationList(19,'" + hfDesignationId.Value + "', 0,0,'"+hfDepartmentId.Value+"',0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdTravelingApproval.DataSource = dt;
                GrdTravelingApproval.DataBind();
                pnlTravelingApproval.Visible = true;
            }
            else
            {
                GrdTravelingApproval.DataSource = null;
                GrdTravelingApproval.DataBind();
                pnlTravelingApproval.Visible = false;
            }
        }
        catch { }
    }
    protected void GrdTravelingApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTravelingApproval.PageIndex = e.NewPageIndex;
        FillForwardedTraveling();
    }

    protected void lnkTravelingApprove_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        //    Label lblAppID = grdrow.FindControl("lblAppID") as Label;
        //    obcomm.FillDatasetByProc("call USP_hr_travellingapplicationList(4,'" + lblAppID.Text + "', 1,0,0,0)");
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Traveling bill Approved');</script>");
        //    FillForwardedTraveling();
        //}
        //catch { }

        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblApplicationId = grdrow.FindControl("lblAppID") as Label;
            Label lblClassName = grdrow.FindControl("lblClassName") as Label;
            Label lblPeriodOfTravel = grdrow.FindControl("lblPeriodOfTravel") as Label;
            lblTravelApplicantName.Text = grdrow.Cells[2].Text;
            lblTravelClass.Text = lblClassName.Text;
            lblTravelStatingDate.Text = grdrow.Cells[3].Text;
            lblTravelEndDate.Text = grdrow.Cells[4].Text;
            lblTravelPeriod.Text = lblPeriodOfTravel.Text;
            lblTravelPlace.Text = grdrow.Cells[5].Text;
            lblTravelAdvanceAmount.Text = grdrow.Cells[6].Text;
            hfTravelDetailId.Value = ((HiddenField)grdrow.FindControl("hfGTravelDetailId")).Value;
            hfTravelAppId.Value = lblApplicationId.Text;
            fadeDiv6.Style.Add("display", "block");
            Messages6.Style.Add("display", "block");
            DataSet dt123 = obcomm.FillDatasetByProc("call USP_HR_Travel_GetClass(" + lblApplicationId.Text + ")");
            hfTravelApprovedId.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString();
            if (Convert.ToString(hfTravelApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
            {
                ddlTravelApprovedBy.Visible = false;
                lblTravelApprovedBy.Visible = false;
                rbTravelStatus.Visible = true;
                lblTravelStatus.Visible = true;
                hfApprovedFlag.Value = "1";
            }
            else
            {
                ddlTravelApprovedBy.Visible = true;
                lblTravelApprovedBy.Visible = true;
                rbTravelStatus.Visible = false;
                lblTravelStatus.Visible = false;
                hfApprovedFlag.Value = "0";
            }
            FillForwardedTraveling();
        }
        catch { }
           
       
    }

    protected void lnkTravelingCancel_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblAppID = grdrow.FindControl("lblAppID") as Label;
            obcomm.FillDatasetByProc("call USP_hr_travellingapplicationList(4,'" + lblAppID.Text + "', 2,0,0,0)");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Traveling bill Cancelled');</script>");
            FillForwardedTraveling();
        }
        catch { }
       
    }

    protected void GrdGrainAdvance_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdGrainAdvance.PageIndex = e.NewPageIndex;
        FillGrainAdvance();
    }

    protected void GrdGrainAdvApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdGrainAdvApproval.PageIndex = e.NewPageIndex;
        FillGrainAdvanceApproval();
    }

    protected void lnkGrainAdvApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblApplicationId = grdrow.FindControl("lblGrainID") as Label;
            lblGrainApplicantName.Text = grdrow.Cells[2].Text;
            lblGrainDesignation.Text = grdrow.Cells[3].Text;
            lblGrainPostedAt.Text = grdrow.Cells[4].Text;
            lblAdvenceAmtRequest.Text = grdrow.Cells[5].Text;
            lblGrainAdvanceBalance.Text = grdrow.Cells[6].Text;
            txtGrainApprovedAmount.Text = grdrow.Cells[7].Text;
            hfGrainDetailId.Value = ((HiddenField)grdrow.FindControl("hfGGrainDetailId")).Value;
            hfGrainAppId.Value = lblApplicationId.Text;
            fadeDiv2.Style.Add("display", "block");
            Messages2.Style.Add("display", "block");
            DataSet dt123 = obcomm.FillDatasetByProc("call USP_HR_Grain_GetClass(" + lblApplicationId.Text + ")");
            try { hfGrainApporvedId.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString(); }
            catch { hfGrainApporvedId.Value = "0"; }
            
            if (Convert.ToString(hfGrainApporvedId.Value) == Convert.ToString(hfDesignationId.Value))
            {
                ddlGrainApprovedBy.Visible = false;
                lblGrainApprovedBy.Visible = false;
                lblGrainStatus.Visible = true;
                rbGrainStatus.Visible = true;
                hfApprovedFlag.Value = "1";
            }
            else
            {
                ddlGrainApprovedBy.Visible = true;
                lblGrainApprovedBy.Visible = true;
                lblGrainStatus.Visible = false;
                rbGrainStatus.Visible = false;
                hfApprovedFlag.Value = "0";
            }
            FillGrainAdvanceApproval();
        }
        catch { }
        //try
        //{
        //    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        //    Label lblGrainID = grdrow.FindControl("lblGrainID") as Label;
        //    obcomm.FillDatasetByProc("call USP_HR_GrainAdvanceApplicationForwarded(1,'" + lblGrainID.Text + "',0,0,0,1)");
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Grain Advance Approved');</script>");
        //    FillGrainAdvanceApproval();
        //}
        //catch { }

    }

    //protected void lnkGrainAdvCancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //        Label lblGrainID = grdrow.FindControl("lblGrainID") as Label;
    //        obcomm.FillDatasetByProc("call USP_HR_GrainAdvanceApplicationForwarded(1,'" + lblGrainID.Text + "',0,0,0,2)");
    //        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Grain Advance Cancelled');</script>");
    //        FillGrainAdvanceApproval();
    //    }
    //    catch { }
        
    //}
    protected void GrdMedicalAdvApp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdMedicalAdvApp.PageIndex = e.NewPageIndex;
        FillMedicalAdvApplication();
    }

    public void FillMedicalAdvApplication()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_MedicalAdvanceApplicationList(0,'" + Session["UserID"] + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdMedicalAdvApp.DataSource = dt;
                GrdMedicalAdvApp.DataBind();
                pnlMedicalAdvApp.Visible = true;
            }
            else
            {
                GrdMedicalAdvApp.DataSource = null;
                GrdMedicalAdvApp.DataBind();
                pnlMedicalAdvApp.Visible = false;
            }
        }
        catch { }
    }
    protected void GrdMedicalAdvApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdMedicalAdvApproval.PageIndex = e.NewPageIndex;
        FillMedicalAdvApproval();
    }

    public void FillMedicalAdvApproval()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_ForwardedMedicalAdvanceApplication(0,'" + hfDesignationId.Value + "','" + hfDepartmentId.Value + "',0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdMedicalAdvApproval.DataSource = dt;
                GrdMedicalAdvApproval.DataBind();
                pnlMedicalAdvApproval.Visible = true;
            }
            else
            {
                GrdMedicalAdvApproval.DataSource = null;
                GrdMedicalAdvApproval.DataBind();
                pnlMedicalAdvApproval.Visible = false;
            }
        }
        catch { }
    }

    protected void lnkMedicalAdvApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblApplicationId = grdrow.FindControl("lblMedicalID") as Label;
            lblMedicalApplicant.Text = grdrow.Cells[2].Text;
            lblMedicalDesignation.Text = grdrow.Cells[3].Text;
            lblMedicalPostedAt.Text = grdrow.Cells[4].Text;
            lblMedicalRequestAmount.Text = grdrow.Cells[5].Text;
            txtMedicalApprovedAmount.Text = grdrow.Cells[6].Text;
            lblMedicalIllness.Text = grdrow.Cells[7].Text;
            hfMedicalDetailId.Value = ((HiddenField)grdrow.FindControl("hfGMedicalDetailId")).Value;
            hfMedicalAppId.Value = lblApplicationId.Text;
            fadeDiv4.Style.Add("display", "block");
            Messages4.Style.Add("display", "block");
            DataSet dt123 = obcomm.FillDatasetByProc("call USP_HR_Medical_GetClass(" + lblApplicationId.Text + ")");
            try { hfMedicalApprovedId.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString(); }
            catch { hfMedicalApprovedId.Value = "0"; }
           
            if (Convert.ToString(hfMedicalApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
            {
                ddlMedicalApprovedBy.Visible = false;
                lblMedicalApprovedBy.Visible = false;
                lblMedicalStatus.Visible = true;
                rbMedicalStatus.Visible = true;
                hfApprovedFlag.Value = "1";
            }
            else
            {
                ddlMedicalApprovedBy.Visible = true;
                lblMedicalApprovedBy.Visible = true;
                lblMedicalStatus.Visible = false;
                rbMedicalStatus.Visible = false;
                hfApprovedFlag.Value = "0";
            }
            FillMedicalAdvApproval();
        }
        catch { }
        //GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        //Label lblMedicalID = grdrow.FindControl("lblMedicalID") as Label;
        //obcomm.FillDatasetByProc("call USP_HR_ForwardedMedicalAdvanceApplication(1,0,'" + lblMedicalID.Text + "',1)");
        //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Medical Advance Approved');</script>");
        //FillMedicalAdvApproval();
    }

    //protected void lnkMedicalAdvCancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //        Label lblMedicalID = grdrow.FindControl("lblMedicalID") as Label;
    //        obcomm.FillDatasetByProc("call USP_HR_ForwardedMedicalAdvanceApplication(1,0,'" + lblMedicalID.Text + "',2)");
    //        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Medical Advance Cancelled');</script>");
    //        FillMedicalAdvApproval();
    //    }
    //    catch { }
      
    //}


    protected void gvDepartmentMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvLoans.PageIndex = e.NewPageIndex;
        fillGrid();
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();

            Button bt = (Button)sender;
            GridViewRow grdrow = (GridViewRow)bt.NamingContainer;

            DataTable dt = obCommonFuction.FillDatasetByProc(@"call USP_HR_LIST_HRLoanDetails(" + bt.CommandArgument + ", 0);").Tables[0];
            gvLoansInstallment.DataSource = dt;
            gvLoansInstallment.DataBind();
            //    Label2.Text = grdrow.Cells[3].Text;
            Div2.Style.Add("display", "block");
            Div3.Style.Add("display", "block");
        }
        catch { }
        
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Div2.Style.Add("display", "none");
        Div3.Style.Add("display", "none");
    }

    private void fillGrid()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc(@"call USP_HR_EmployeeLoansAndAdvanceList(0," + Session["UserID"] + ");").Tables[2];
            if (dt.Rows.Count > 0)
            {
                gvLoans.DataSource = dt;
                gvLoans.DataBind();
                pnlLoanStatus.Visible = true;
            }
            else
            {
                gvLoans.DataSource = null;
                gvLoans.DataBind();
                pnlLoanStatus.Visible = false;
            }
        }
        catch { }
       
    }

    public void FillFestivalAdvanceStatus()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_View_HR_festival_advance_application_form(0," + Session["UserID"] + ")").Tables[1];
            if (dt.Rows.Count > 0)
            {
                GrdFestivalAdvanceStatus.DataSource = dt;
                GrdFestivalAdvanceStatus.DataBind();
                pnlFestivalAdvanceStatus.Visible = true;
            }
            else
            {
                GrdFestivalAdvanceStatus.DataSource = null;
                GrdFestivalAdvanceStatus.DataBind();
                pnlFestivalAdvanceStatus.Visible = false;
            }
        }
        catch { }

    }

    public void FillFestivalAdvanceApproval()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_View_HR_festival_advance_application_Forwarded(0," + hfDesignationId.Value + ",'"+hfDepartmentId.Value+"')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdFestivalAdvanceApproval.DataSource = dt;
                GrdFestivalAdvanceApproval.DataBind();
                pnlFestivalApproval.Visible = true;
            }
            else
            {
                GrdFestivalAdvanceApproval.DataSource = null;
                GrdFestivalAdvanceApproval.DataBind();
                pnlFestivalApproval.Visible = false;
            }
        }
        catch { }

    }

    protected void GrdFestivalAdvanceStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdFestivalAdvanceStatus.PageIndex = e.NewPageIndex;
        FillFestivalAdvanceStatus();
    }

    protected void GrdFestivalAdvanceApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdFestivalAdvanceStatus.PageIndex = e.NewPageIndex;
        FillFestivalAdvanceApproval();
    }

    protected void lnkFestivalAdvApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblApplicationId = grdrow.FindControl("lblFestivalID") as Label;
            lblFestivalApplicant.Text = grdrow.Cells[2].Text;
            lblFestivalDesignation.Text = grdrow.Cells[3].Text;
            lblFestivalPostedAt.Text = grdrow.Cells[4].Text;
            lblFestivalName.Text = grdrow.Cells[6].Text;
            lblFestivalDate.Text = grdrow.Cells[7].Text;
            lblFestivalRequestAmount.Text = grdrow.Cells[5].Text;
            lblFestivalAdvanceBalance.Text = grdrow.Cells[8].Text;
            hfFestivalDetailId.Value = ((HiddenField)grdrow.FindControl("hfGFestivalDetailId")).Value;
            hfFestivalAppId.Value = lblApplicationId.Text;
            fadeDiv3.Style.Add("display", "block");
            Messages3.Style.Add("display", "block");
            DataSet dt123 = obcomm.FillDatasetByProc("call USP_HR_Festival_GetClass(" + lblApplicationId.Text + ")");
            hfFestivalApprovedId.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString();
            if (Convert.ToString(hfFestivalApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
            {
                ddlFestivalApprovedBy.Visible = false;
                lblFestivalApprovedBy.Visible = false;
                lblFestivalStatus.Visible = true;
                rbFestivalStatus.Visible = true;
                hfApprovedFlag.Value = "1";
            }
            else
            {
                ddlFestivalApprovedBy.Visible = true;
                lblFestivalApprovedBy.Visible = true;
                lblFestivalStatus.Visible = false;
                rbFestivalStatus.Visible = false;
                hfApprovedFlag.Value = "0";
            }
            FillFestivalAdvanceApproval();
        }
        catch { }
        //try
        //{
        //    GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        //    Label lblFestivalID = grdrow.FindControl("lblFestivalID") as Label;
        //    obcomm.FillDatasetByProc("call USP_View_HR_festival_advance_application_Forwarded(1,'" + lblFestivalID.Text + "',1)");
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Festival Advance Approved');</script>");
        //    FillFestivalAdvanceApproval();
        //}
        //catch { }
       
    }

    //protected void lnkFestivalAdvCancel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
    //        Label lblFestivalID = grdrow.FindControl("lblFestivalID") as Label;
    //        obcomm.FillDatasetByProc("call USP_View_HR_festival_advance_application_Forwarded(1,'" + lblFestivalID.Text + "',2)");
    //        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Festival Advance Cancelled');</script>");
    //        FillFestivalAdvanceApproval();
    //    }
    //    catch { }

    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt2 = obcomm.FillDatasetByProc("call USP_GET_Application_Request_Detail(2,'" + HiddenField3.Value + "')").Tables[0];
        if (dt2.Rows.Count == 1)
            obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(12,0,'" + HiddenField3.Value + "','" + ddlAssignedEmployee.SelectedValue + "',0,0,0)");

        if (Convert.ToString(HiddenField4.Value) == Convert.ToString(hfDesignationId.Value) && RadioButtonList1.SelectedValue != "3")
        {
            obcomm.FillDatasetByProc("call USP_HR_LeaveRequestDetails(2," + HiddenField3.Value + "," + Session["UserID"].ToString() + ",0,'" + txtRemark.Text + "'," + RadioButtonList1.SelectedValue + "," + HiddenField2.Value + ", 0)");
            if (RadioButtonList1.SelectedValue == "2")
            { obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(2,0,'" + HiddenField3.Value + "',0,0,0,0)"); ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Leave application cancelled');</script>"); }
            else
            { obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(1,0,'" + HiddenField3.Value + "',0,0,0,0)"); ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Leave application approved');</script>"); }
            Messages.Style.Add("display", "none");
            fadeDiv.Style.Add("display", "none");
            ddlForwardTo.SelectedIndex = -1;
            lblFarwardTo.Visible = true;
            ddlForwardTo.Visible = true;
            FillForwardedLeaves();
        }
        else
        {
            if (ddlForwardTo.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select officer.');</script>");
                Messages.Style.Add("display", "block");
                fadeDiv.Style.Add("display", "block");
            }
            else if (txtRemark.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter remark.');</script>");
                Messages.Style.Add("display", "block");
                fadeDiv.Style.Add("display", "block");
            }
            else
            {
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
                }
                obcomm.FillDatasetByProc("call USP_HR_LeaveRequestDetails(1," + HiddenField3.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtRemark.Text + "',3," + HiddenField2.Value + "," + DepartmentId + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Leave application has been forwarded');</script>");
                Messages.Style.Add("display", "none");
                fadeDiv.Style.Add("display", "none");
                ddlForwardTo.SelectedIndex = -1;
                lblFarwardTo.Visible = true;
                ddlForwardTo.Visible = true;
                FillForwardedLeaves();
            }
        }
     }
    protected void Button2_Click(object sender, EventArgs e)
    {
        lblFarwardTo.Visible = true;
        ddlForwardTo.Visible = true;
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
  
    public void FillTransferApplicationStatus()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_VIEW_hr_employee_Transfer_Application(1,0," + Session["UserID"] + ", 0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdTransferApplicationStatus.DataSource = dt;
                grdTransferApplicationStatus.DataBind();
                pnlTransferApplicationStatus.Visible = true;
            }
            else
            {
                grdTransferApplicationStatus.DataSource = null;
                grdTransferApplicationStatus.DataBind();
                pnlTransferApplicationStatus.Visible = false;
            }
        }
        catch { }

    }

    public void FillTransferApplicationApproval()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_VIEW_hr_employee_Transfer_Application(2,0," + hfDesignationId.Value + ", '"+hfDepartmentId.Value+"')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdTransferApplicationApproval.DataSource = dt;
                grdTransferApplicationApproval.DataBind();
                pnlTransferApplicationApproval.Visible = true;
            }
            else
            {
                grdTransferApplicationApproval.DataSource = null;
                grdTransferApplicationApproval.DataBind();
                pnlTransferApplicationApproval.Visible = false;
            }
        }
        catch { }

    }

    protected void grdTransferApplicationStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTransferApplicationStatus.PageIndex = e.NewPageIndex;
        FillTransferApplicationStatus();
    }

    protected void grdTransferApplicationApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTransferApplicationApproval.PageIndex = e.NewPageIndex;
        FillTransferApplicationApproval();
    }

    protected void lnkTransferApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblApplicationId = grdrow.FindControl("lblTransferID") as Label;
            lblTApplicantName.Text = grdrow.Cells[2].Text;
            lblDesignationName.Text = grdrow.Cells[3].Text;
            lblCurrentLocation.Text = grdrow.Cells[4].Text;
            lblNewLocation.Text = grdrow.Cells[5].Text;
            HiddenField7.Value = ((HiddenField)grdrow.FindControl("hfApprovedId")).Value;
            HiddenField6.Value = lblApplicationId.Text;
            fadeDiv1.Style.Add("display", "block");
            Messages1.Style.Add("display", "block");
            DataSet dt123 = obcomm.FillDatasetByProc("call USP_HR_Transfer_GetClass(" + lblApplicationId.Text + ")");
            HiddenField5.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString();
            if (Convert.ToString(HiddenField5.Value) == Convert.ToString(hfDesignationId.Value))
            {
                ddlTForwardTo.Visible = false;
                lblTForwardTo.Visible = false;
                RadioButtonList2.Visible = true;
                lblTranferStatus.Visible = true;
                hfApprovedFlag.Value = "1";
            }
            else
            {
                ddlTForwardTo.Visible = true;
                lblTForwardTo.Visible = true;
                RadioButtonList2.Visible = false;
                lblTranferStatus.Visible = false;
                hfApprovedFlag.Value = "0";
            }
            //obcomm.FillDatasetByProc("call USP_HR_LeaveForwardedFill(1,0,'" + lblLeaveId.Text + "',0,0,0,0)");
            //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Leave Approved');</script>");
            FillTransferApplicationApproval();
        }
        catch { }

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(HiddenField5.Value) == Convert.ToString(hfDesignationId.Value))
        {
            obcomm.FillDatasetByProc("call USP_HR_TransferRequestDetails(2," + HiddenField6.Value + "," + Session["UserID"].ToString() + ",0,'"+txtTRemark.Text+"'," + RadioButtonList2.SelectedValue + "," + HiddenField7.Value + ", '"+hfDepartmentId.Value+"')");
            if (RadioButtonList2.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_VIEW_hr_employee_Transfer_Application(4,'" + HiddenField6.Value + "',0," + RadioButtonList2.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Transfer application cancelled');</script>");
            }
            else
            {
                obcomm.FillDatasetByProc("call USP_VIEW_hr_employee_Transfer_Application(4,'" + HiddenField6.Value + "',0," + RadioButtonList2.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Transfer application approved');</script>");
            }

            Messages1.Style.Add("display", "none");
            fadeDiv1.Style.Add("display", "none");
            ddlTForwardTo.Visible = false;
            lblTForwardTo.Visible = false;
            RadioButtonList2.Visible = false;
            lblTranferStatus.Visible = false;
            FillTransferApplicationApproval();
        }
        else
        {
            if (ddlTForwardTo.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select approved officer.');</script>");
                Messages1.Style.Add("display", "block");
                fadeDiv1.Style.Add("display", "block");
            }
            else if (txtTRemark.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter remark.');</script>");
                Messages1.Style.Add("display", "block");
                fadeDiv1.Style.Add("display", "block");
            }
            else
            {
                DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlTForwardTo.SelectedValue + "',0,0)").Tables[0];
                string DesignationId = "0", DepartmentId = "0";
                if (dt.Rows.Count > 0)
                {
                    try
                    { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
                    catch { DesignationId = "0"; }
                    try
                    { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
                    catch { DepartmentId = "0"; }
                }
                obcomm.FillDatasetByProc("call USP_HR_TransferRequestDetails(1," + HiddenField6.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtTRemark.Text + "',3," + HiddenField7.Value + ", '" + DepartmentId + "')");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Transfer application has been forwarded.');</script>");
                Messages1.Style.Add("display", "none");
                fadeDiv1.Style.Add("display", "none");
                ddlTForwardTo.Visible = false;
                lblTForwardTo.Visible = false;
                RadioButtonList2.Visible = false;
                lblTranferStatus.Visible = false;
                FillTransferApplicationApproval();
            }
        }
       
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Messages1.Style.Add("display", "none");
        fadeDiv1.Style.Add("display", "none");
        ddlTForwardTo.Visible = false;
        lblTForwardTo.Visible = false;
        RadioButtonList2.Visible = false;
        lblTranferStatus.Visible = false;
    }


    protected void btnGrainSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(hfGrainApporvedId.Value) == Convert.ToString(hfDesignationId.Value))
        {
            obcomm.FillDatasetByProc("call USP_HR_grainrequestdetails(2," + hfGrainAppId.Value + "," + Session["UserID"].ToString() + ",0,'" + txtGrainRemarks.Text + "'," + rbGrainStatus.SelectedValue + "," + hfGrainDetailId.Value + ", " + txtGrainApprovedAmount.Text + ", " + hfDepartmentId.Value + ")");
            if (rbGrainStatus.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_HR_GrainAdvanceApplicationForwarded(1,'" + hfGrainAppId.Value + "',0,0,0," + rbGrainStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Grain application cancelled');</script>");
            }
            else
            {
                obcomm.FillDatasetByProc("call USP_HR_GrainAdvanceApplicationForwarded(1,'" + hfGrainAppId.Value + "',0,0,0," + rbGrainStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Grain application approved');</script>");
            }
            ddlGrainApprovedBy.Visible = false;
            lblGrainApprovedBy.Visible = false;
            Messages2.Style.Add("display", "none");
            fadeDiv2.Style.Add("display", "none");
            txtGrainApprovedAmount.Text = "";
            txtGrainRemarks.Text = "";
            FillGrainAdvanceApproval();
        }
        else
        {
            if (ddlGrainApprovedBy.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select approved officer.');</script>");
                Messages2.Style.Add("display", "block");
                fadeDiv2.Style.Add("display", "block");
            }
            else if (txtGrainRemarks.Text == "" && txtGrainApprovedAmount.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter approved amount and remark.');</script>");
                Messages2.Style.Add("display", "block");
                fadeDiv2.Style.Add("display", "block");
            }
            else
            {
                DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlGrainApprovedBy.SelectedValue + "',0,0)").Tables[0];
                string DesignationId = "0", DepartmentId = "0";
                if (dt.Rows.Count > 0)
                {
                    try
                    { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
                    catch { DesignationId = "0"; }
                    try
                    { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
                    catch { DepartmentId = "0"; }
                }
                obcomm.FillDatasetByProc("call USP_HR_grainrequestdetails(1," + hfGrainAppId.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtGrainRemarks.Text + "',3," + hfGrainDetailId.Value + ", " + txtGrainApprovedAmount.Text + ", '" + DepartmentId + "')");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Grain application has been forwarded.');</script>");
                ddlGrainApprovedBy.Visible = false;
                lblGrainApprovedBy.Visible = false;
                Messages2.Style.Add("display", "none");
                fadeDiv2.Style.Add("display", "none");
                txtGrainApprovedAmount.Text = "";
                txtGrainRemarks.Text = "";
                ddlGrainApprovedBy.SelectedIndex = -1;
                FillGrainAdvanceApproval();
            }
        }
    }
    protected void btnGrainCancel_Click(object sender, EventArgs e)
    {
        ddlGrainApprovedBy.Visible = true;
        lblGrainApprovedBy.Visible = true;
        Messages2.Style.Add("display", "none");
        fadeDiv2.Style.Add("display", "none");
        txtGrainApprovedAmount.Text = "";
        txtGrainRemarks.Text = "";
        ddlGrainApprovedBy.SelectedIndex = -1;
    }

    protected void btnFestivalSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(hfFestivalApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
        {
            obcomm.FillDatasetByProc("call USP_HR_festivalrequestdetails(2," + hfFestivalAppId.Value + "," + Session["UserID"].ToString() + ",0,'" + txtFestivalRemark.Text + "'," + rbFestivalStatus.SelectedValue + "," + hfFestivalDetailId.Value + ", " + txtFestivalApprovedAmount.Text + ", '" + hfDepartmentId.Value + "')");
            if (rbGrainStatus.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_View_HR_festival_advance_application_Forwarded(1,'" + hfFestivalAppId.Value + "'," + rbFestivalStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Festival application cancelled');</script>");
            }
            else
            {
                obcomm.FillDatasetByProc("call USP_View_HR_festival_advance_application_Forwarded(1,'" + hfFestivalAppId.Value + "'," + rbFestivalStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Festival application approved');</script>");
            }

            ddlFestivalApprovedBy.Visible = false;
            lblFestivalApprovedBy.Visible = false;
            lblFestivalStatus.Visible = false;
            rbFestivalStatus.Visible = false;
            txtFestivalApprovedAmount.Text = "";
            txtFestivalRemark.Text = "";
            Messages3.Style.Add("display", "none");
            fadeDiv3.Style.Add("display", "none");
            FillFestivalAdvanceApproval();
        }
        else
        {
            if (ddlFestivalApprovedBy.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select approved officer.');</script>");
                Messages3.Style.Add("display", "block");
                fadeDiv3.Style.Add("display", "block");
            }
            else if (txtFestivalRemark.Text == "" && txtFestivalApprovedAmount.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter approved amount and remark.');</script>");
                Messages3.Style.Add("display", "block");
                fadeDiv3.Style.Add("display", "block");
            }
            else
            {
                DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlFestivalApprovedBy.SelectedValue + "',0,0)").Tables[0];
                string DesignationId = "0", DepartmentId = "0";
                if (dt.Rows.Count > 0)
                {
                    try
                    { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
                    catch { DesignationId = "0"; }
                    try
                    { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
                    catch { DepartmentId = "0"; }
                }
                obcomm.FillDatasetByProc("call USP_HR_festivalrequestdetails(1," + hfFestivalAppId.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtFestivalRemark.Text + "',3," + hfFestivalDetailId.Value + ", " + txtFestivalApprovedAmount.Text + ", '" + DepartmentId + "')");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Festival application has been forwarded.');</script>");
                ddlFestivalApprovedBy.Visible = false;
                lblFestivalApprovedBy.Visible = false;
                lblFestivalStatus.Visible = false;
                rbFestivalStatus.Visible = false;
                txtFestivalApprovedAmount.Text = "";
                txtFestivalRemark.Text = "";
                Messages3.Style.Add("display", "none");
                fadeDiv3.Style.Add("display", "none");
                FillFestivalAdvanceApproval();
            }
        }
    }
    protected void btnFestivalCancel_Click(object sender, EventArgs e)
    {
        ddlFestivalApprovedBy.Visible = false;
        lblFestivalApprovedBy.Visible = false;
        lblFestivalStatus.Visible = false;
        rbFestivalStatus.Visible = false;
        txtFestivalApprovedAmount.Text = "";
        txtFestivalRemark.Text = "";
        Messages3.Style.Add("display", "none");
        fadeDiv3.Style.Add("display", "none");
    }


    protected void btnMedicalSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(hfMedicalApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
        {
            obcomm.FillDatasetByProc("call USP_HR_Medicalrequestdetails(2," + hfMedicalAppId.Value + "," + Session["UserID"].ToString() + ",0,'" + txtMedicalRemark.Text + "'," + rbMedicalStatus.SelectedValue + "," + hfMedicalDetailId.Value + "," + txtMedicalApprovedAmount.Text + ", '" + hfDepartmentId.Value + "')");

            if (rbMedicalStatus.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_HR_ForwardedMedicalAdvanceApplication(1,0,'" + hfMedicalAppId.Value + "'," + rbMedicalStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Medical application cancelled');</script>");
            }
            else
            {
                obcomm.FillDatasetByProc("call USP_HR_ForwardedMedicalAdvanceApplication(1,0,'" + hfMedicalAppId.Value + "'," + rbMedicalStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Medical application approved');</script>");
            }
            ddlMedicalApprovedBy.Visible = false;
            lblMedicalApprovedBy.Visible = false;
            rbMedicalStatus.Visible = false;
            lblMedicalStatus.Visible = false;
            txtMedicalApprovedAmount.Text = "";
            txtMedicalRemark.Text = "";
            Messages4.Style.Add("display", "none");
            fadeDiv4.Style.Add("display", "none");
            FillMedicalAdvApproval();
        }
        else
        {
             if (ddlMedicalApprovedBy.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select approved officer.');</script>");
                Messages4.Style.Add("display", "block");
                fadeDiv4.Style.Add("display", "block");
            }
             else if (txtMedicalRemark.Text == "" && txtMedicalApprovedAmount.Text == "")
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter approved amount and remark.');</script>");
                 Messages4.Style.Add("display", "block");
                 fadeDiv4.Style.Add("display", "block");
             }
             else
             {
                 DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlMedicalApprovedBy.SelectedValue + "',0,0)").Tables[0];
                 string DesignationId = "0", DepartmentId = "0";
                 if (dt.Rows.Count > 0)
                 {
                     try
                     { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
                     catch { DesignationId = "0"; }
                     try
                     { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
                     catch { DepartmentId = "0"; }
                 }
                 obcomm.FillDatasetByProc("call USP_HR_Medicalrequestdetails(1," + hfMedicalAppId.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtMedicalRemark.Text + "',3," + hfMedicalDetailId.Value + ", " + txtMedicalApprovedAmount.Text + ", '" + DepartmentId + "')");
                 ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Medical application has been forwarded.');</script>");
                 ddlMedicalApprovedBy.Visible = false;
                 lblMedicalApprovedBy.Visible = false;
                 rbMedicalStatus.Visible = false;
                 lblMedicalStatus.Visible = false;
                 txtMedicalApprovedAmount.Text = "";
                 txtMedicalRemark.Text = "";
                 Messages4.Style.Add("display", "none");
                 fadeDiv4.Style.Add("display", "none");
                 FillMedicalAdvApproval();
             }
        }
    }
    protected void btnMedicalCancel_Click(object sender, EventArgs e)
    {
        ddlMedicalApprovedBy.Visible = false;
        lblMedicalApprovedBy.Visible = false;
        rbMedicalStatus.Visible = false;
        lblMedicalStatus.Visible = false;
        txtMedicalApprovedAmount.Text = "";
        txtMedicalRemark.Text = "";
        Messages4.Style.Add("display", "none");
        fadeDiv4.Style.Add("display", "none");
    }


    // PF Section

    protected void grdPFStatus_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdPFStatus.PageIndex = e.NewPageIndex;
        FillPFApplicationStatus();
    }

    public void FillPFApplicationStatus()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_EmployeeProvidentFundapplicationList(0,'" + Session["UserID"] + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdPFStatus.DataSource = dt;
                grdPFStatus.DataBind();
                pnlProvidentFundStaus.Visible = true;
            }
            else
            {
                grdPFStatus.DataSource = null;
                grdPFStatus.DataBind();
                pnlProvidentFundStaus.Visible = false;
            }
        }
        catch { }
    }
    protected void GrdPFApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPFApproval.PageIndex = e.NewPageIndex;
        FillPFApproval();
    }
 
    public void FillPFApproval()
    {
        try
        {
            DataTable dt = obcomm.FillDatasetByProc("call USP_HR_ForwardedPFApplication(0,'" + hfDesignationId.Value + "','"+hfDepartmentId.Value+"',0)").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdPFApproval.DataSource = dt;
                GrdPFApproval.DataBind();
                pnlProvidentFundApproval.Visible = true;
            }
            else
            {
                GrdPFApproval.DataSource = null;
                GrdPFApproval.DataBind();
                pnlProvidentFundApproval.Visible = false;
            }
        }
        catch { }
    }

    protected void lnkPFApprove_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblApplicationId = grdrow.FindControl("lblFundID") as Label;
            lblPFApplicant.Text = grdrow.Cells[2].Text;
            lblPFDesignation.Text = grdrow.Cells[3].Text;
            lblPFPostedAt.Text = grdrow.Cells[4].Text;
            lblPFRequestedAmount.Text = grdrow.Cells[5].Text;
            txtPFApprovedAmount.Text = grdrow.Cells[6].Text;
            lblPFReason.Text = grdrow.Cells[7].Text;
            hfPFDetailId.Value = ((HiddenField)grdrow.FindControl("hfGPFDetailId")).Value;
            hfPFAppId.Value = lblApplicationId.Text;
            fadeDiv5.Style.Add("display", "block");
            Messages5.Style.Add("display", "block");
            DataSet dt123 = obcomm.FillDatasetByProc("call USP_HR_PF_GetClass(" + lblApplicationId.Text + ")");
            hfPFApprovedId.Value = dt123.Tables[0].Rows[0]["ApprovalUserID"].ToString();
            if (Convert.ToString(hfPFApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
            {
                ddlPFApprovedBy.Visible = false;
                lblPFApprovedBy.Visible = false;
                hfApprovedFlag.Value = "1";
            }
            else
            {
                ddlPFApprovedBy.Visible = true;
                lblPFApprovedBy.Visible = true;
                hfApprovedFlag.Value = "0";
            }
            FillPFApproval();
        }
        catch { }
    }

    protected void btnPFSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(hfPFApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
        {
            obcomm.FillDatasetByProc("call USP_HR_ProvidentFundrequestdetails(2," + hfPFAppId.Value + "," + Session["UserID"].ToString() + ",0,'" + txtPFRemaks.Text + "'," + rbPFStatus.SelectedValue + "," + hfPFDetailId.Value + ", " + txtPFApprovedAmount.Text + ", '" + hfDepartmentId.Value + "')");
            if (rbPFStatus.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_HR_ForwardedPFApplication(1,0,'" + hfPFAppId.Value + "'," + rbPFStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('PF application cancelled');</script>");
            }
            else
            {
                obcomm.FillDatasetByProc("call USP_HR_ForwardedPFApplication(1,0,'" + hfPFAppId.Value + "'," + rbPFStatus.SelectedValue + ")");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('PF application approved');</script>");
            }

            ddlPFApprovedBy.Visible = false;
            lblPFApprovedBy.Visible = false;
            rbPFStatus.Visible = false;
            lblPFStatus.Visible = false;
            txtPFApprovedAmount.Text = "";
            txtRemark.Text = "";
            Messages5.Style.Add("display", "none");
            fadeDiv5.Style.Add("display", "none");
            FillPFApproval();
        }
        else
        {
            if (ddlPFApprovedBy.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select approved officer.');</script>");
                Messages5.Style.Add("display", "block");
                fadeDiv5.Style.Add("display", "block");
            }
            else if (txtPFRemaks.Text == "" && txtPFApprovedAmount.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter approved amount and remark.');</script>");
                Messages5.Style.Add("display", "block");
                fadeDiv5.Style.Add("display", "block");
            }
            else
            {
                DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlPFApprovedBy.SelectedValue + "',0,0)").Tables[0];
                string DesignationId = "0", DepartmentId = "0";
                if (dt.Rows.Count > 0)
                {
                    try
                    { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
                    catch { DesignationId = "0"; }
                    try
                    { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
                    catch { DepartmentId = "0"; }
                }
                obcomm.FillDatasetByProc("call USP_HR_ProvidentFundrequestdetails(1," + hfPFAppId.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtPFRemaks.Text + "',3," + hfPFDetailId.Value + ", " + txtPFApprovedAmount.Text + ", '" + DepartmentId + "')");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('PF application forwarded.');</script>");
                ddlPFApprovedBy.Visible = false;
                lblPFApprovedBy.Visible = false;
                rbPFStatus.Visible = false;
                lblPFStatus.Visible = false;
                txtPFApprovedAmount.Text = "";
                txtRemark.Text = "";
                Messages5.Style.Add("display", "none");
                fadeDiv5.Style.Add("display", "none");
                FillPFApproval();
            }
        }
    }
    protected void lblPFCancel_Click(object sender, EventArgs e)
    {
        ddlPFApprovedBy.Visible = true;
        lblPFApprovedBy.Visible = true;
        Messages5.Style.Add("display", "none");
        fadeDiv5.Style.Add("display", "none");
    }

    protected void btnTravelSave_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(hfTravelApprovedId.Value) == Convert.ToString(hfDesignationId.Value))
        {
            obcomm.FillDatasetByProc("call USP_HR_travellingrequestdetails(1," + hfTravelAppId.Value + "," + Session["UserID"].ToString() + ",0,'" + txtTravelRemark.Text + "'," + rbTravelStatus.SelectedValue + "," + hfTravelDetailId.Value + ", " + txtTravelApprovedAmount.Text + ", '" + hfDepartmentId.Value + "')");
            if (rbPFStatus.SelectedValue == "2")
            {
                obcomm.FillDatasetByProc("call USP_hr_travellingapplicationList(4,'" + hfTravelAppId.Value + "', " + rbTravelStatus.SelectedValue + ",0,0,0)");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Travel application cancelled');</script>");
            }
            else
            {
                obcomm.FillDatasetByProc("call USP_hr_travellingapplicationList(4,'" + hfTravelAppId.Value + "', " + rbTravelStatus.SelectedValue + ",0,0,0)");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Travel application approved');</script>");
            }
            ddlTravelApprovedBy.Visible = false;
            lblTravelApprovedBy.Visible = false;
            lblMedicalStatus.Visible = false;
            rbTravelStatus.Visible = false;
            txtTravelRemark.Text = "";
            txtTravelApprovedAmount.Text = "";
            Messages6.Style.Add("display", "none");
            fadeDiv6.Style.Add("display", "none");
            FillForwardedTraveling();
        }
        else
        {
            if (ddlTravelApprovedBy.SelectedIndex == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select approved officer.');</script>");
                Messages6.Style.Add("display", "block");
                fadeDiv6.Style.Add("display", "block");
            }
            else if (txtTravelRemark.Text == "" && txtTravelApprovedAmount.Text == "")
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter approved amount and remark.');</script>");
                 Messages6.Style.Add("display", "block");
                 fadeDiv6.Style.Add("display", "block");
             }
             else
             {
                 DataTable dt = obcomm.FillDatasetByProc("call  USP_UI_hr_DesignationMappingToDepartment(3,'" + ddlTravelApprovedBy.SelectedValue + "',0,0)").Tables[0];
                 string DesignationId = "0", DepartmentId = "0";
                 if (dt.Rows.Count > 0)
                 {
                     try
                     { DesignationId = dt.Rows[0]["DesignationId"].ToString(); }
                     catch { DesignationId = "0"; }
                     try
                     { DepartmentId = dt.Rows[0]["DepartmentId"].ToString(); }
                     catch { DepartmentId = "0"; }
                 }
                 obcomm.FillDatasetByProc("call USP_HR_travellingrequestdetails(1," + hfTravelAppId.Value + "," + Session["UserID"].ToString() + "," + DesignationId + ",'" + txtTravelRemark.Text + "',3," + hfTravelDetailId.Value + ", " + txtTravelApprovedAmount.Text + ", '" + DepartmentId + "')");
                 ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Travel application forwarded.');</script>");
                 ddlTravelApprovedBy.Visible = false;
                 lblTravelApprovedBy.Visible = false;
                 lblMedicalStatus.Visible = false;
                 rbTravelStatus.Visible = false;
                 txtTravelRemark.Text = "";
                 txtTravelApprovedAmount.Text = "";
                 Messages6.Style.Add("display", "none");
                 fadeDiv6.Style.Add("display", "none");
                 FillForwardedTraveling();
            }
        }

        
    }
    protected void btnTravelCancel_Click(object sender, EventArgs e)
    {
        ddlTravelApprovedBy.Visible = true;
        lblTravelApprovedBy.Visible = true;
        Messages6.Style.Add("display", "none");
        fadeDiv6.Style.Add("display", "none");
    }

    protected void lnkViewDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblLeaveId = grdrow.FindControl("lblLeaveId") as Label;
            lblHeading.Text = "Leave Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblLeaveId.Text, 0);
        }
        catch { }
    }

    protected void lnkViewDetail_VoucherBill_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblLeaveId = grdrow.FindControl("lblLeaveId") as Label;
            lblHeading.Text = "Voucher Bill Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetVoucherBillForwardDetail(lblLeaveId.Text, 9);
        }
        catch { }
    }

    protected void lnklnkViewGrainDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblGrainID = grdrow.FindControl("lblGrainID") as Label;
            lblHeading.Text = "Grain Advance Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblGrainID.Text, 3);
        }
        catch { }
    }

    protected void lnkViewMedicalDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblMedicalID = grdrow.FindControl("lblMedicalID") as Label;
            lblHeading.Text = "Medical Advance Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblMedicalID.Text, 4);
        }
        catch { }
    }

    protected void lnkViewTravellingDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblAppID = grdrow.FindControl("lblAppID") as Label;
            lblHeading.Text = "Travelling Advance Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblAppID.Text, 5);
        }
        catch { }
    }

    protected void lnkViewFestivalDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblFestivalID = grdrow.FindControl("lblFestivalID") as Label;
            lblHeading.Text = "Festival Advance Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblFestivalID.Text, 6);
        }
        catch { }
    }

    protected void lnkViewTransferDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblTransferID = grdrow.FindControl("lblTransferID") as Label;
            lblHeading.Text = "Transfer Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblTransferID.Text, 7);
        }
        catch { }
    }

    protected void lnkViewPFDetail_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblFundID = grdrow.FindControl("lblFundID") as Label;
            lblHeading.Text = "PF Forwarding Detail";
            //lblApplicant.Text = grdrow.Cells[2].Text;
            //lblFrom.Text = grdrow.Cells[3].Text;
            //lblTo.Text = grdrow.Cells[4].Text;
            //lblLeaveType.Text = grdrow.Cells[6].Text;
            GetForwardDetail(lblFundID.Text, 8);
        }
        catch { }
    }

    public void GetForwardDetail(string Id, int Type)
    {
        DataTable dt = obcomm.FillDatasetByProc("call USP_GET_Application_Request_Detail(" + Type + ", " + Id + ")").Tables[0];
        if (dt.Rows.Count > 0)
        {
            GrdViewForwardDetail.DataSource = dt;
            GrdViewForwardDetail.DataBind();
        }
        ViewForwardDetail.Style.Add("display", "block");
        ViewForwardDetail1.Style.Add("display", "block");
    }

    public void GetVoucherBillForwardDetail(string Id, int Type)
    {
        DataTable dt = obcomm.FillDatasetByProc("call USP_GET_Application_Request_Detail(" + Type + ", " + Id + ")").Tables[0];
        if (dt.Rows.Count > 0)
        {
            GrdViewForwardDetail.DataSource = dt;
            GrdViewForwardDetail.DataBind();
        }
        ViewForwardDetail.Style.Add("display", "block");
        ViewForwardDetail1.Style.Add("display", "block");
    }


    protected void Button5_Click(object sender, EventArgs e)
    {
        ViewForwardDetail.Style.Add("display", "none");
        ViewForwardDetail1.Style.Add("display", "none");
    }

    public void GetApprovedLeave()
    {
        DataTable dt = obcomm.FillDatasetByProc("call USP_GET_Application_Request_Detail(1, " + Session["UserID"].ToString() + ")").Tables[0];
        if (dt.Rows.Count > 0)
        {
            grdApprovedLeave.DataSource = dt;
            grdApprovedLeave.DataBind();
            ApprovedLeave.Style.Add("display", "block");
            ApprovedLeave1.Style.Add("display", "block");
        }
        else
        {
            ApprovedLeave.Style.Add("display", "none");
            ApprovedLeave1.Style.Add("display", "none");
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        ApprovedLeave.Style.Add("display", "none");
        ApprovedLeave1.Style.Add("display", "none");
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "3")
            ddlForwardTo.Visible = lblFarwardTo.Visible = true;
        else
            ddlForwardTo.Visible = lblFarwardTo.Visible = false;
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }

    protected void GrdViewForwardDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Status1").ToString() == "3")
                {
                    e.Row.Attributes.Add("style", "background-color:green;color:white");
                }
                else if (DataBinder.Eval(e.Row.DataItem, "Status1").ToString() == "4")
                {
                    e.Row.Attributes.Add("style", "background-color:blue;color:white");
                }
                else if (DataBinder.Eval(e.Row.DataItem, "Status1").ToString() == "0")
                {
                    e.Row.Attributes.Add("style", "background-color:yellow;color:black");
                }
                //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='orange'");
                //e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#E56E94'");
                //e.Row.BackColor = Color.FromName("#E56E94");
            }   
        }
        catch { }
    }
    protected void GrdPriBillVoucherFill01(object sender, GridViewPageEventArgs e)
    {
        GrdPriBillVoucherFill.PageIndex = e.NewPageIndex;
        FillVoucherBillForwarded();
    }
}
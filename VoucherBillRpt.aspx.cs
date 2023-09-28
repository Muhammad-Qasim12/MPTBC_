using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class VoucherBillRpt : System.Web.UI.Page
{
    CommonFuction obcomm = new CommonFuction();
    string leaderName = string.Empty;
    string ChallanNo = string.Empty;    
    int ltSno = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string uid = Session["UserID"].ToString();
            GetDesignationId();           
           

            //FillVoucherBillBankDetails();
            FillVoucherBill();
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
                        hfLoggedInDepartment.Value = dt.Rows[0]["DepartmentName"].ToString();
                    }
                    else
                        hfLoggedInDepartment.Value = "";
                }
            }
            else
            {
                hfDesignationId.Value = "0";
                hfDepartmentId.Value = "0";
            }

        }
        catch { }
    }

    public void FillVoucherBillBankDetails()
    {
        try
        {
            string id = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_Voucher_PrepareAccountForwardedFill(6,'" + hfDesignationId.Value + "', 0," + hfDepartmentId.Value + "," + System.DateTime.Now.Year + ",0,0,'" + id + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdBankDetailsBill.DataSource = dt;
                GrdBankDetailsBill.DataBind();
                pnlBankDetailsBill.Visible = true;
                //fnFormatGrid();

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

    public void FillVoucherBill()
    {
        try
        {
            string id = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_Voucher_PrepareAccountForwardedFill(7,'" + hfDesignationId.Value + "', 0," + hfDepartmentId.Value + "," + System.DateTime.Now.Year + ",0,0,'" + id + "','" + hfLoggedInDepartment.Value + "')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                GrdLast.DataSource = dt;
                GrdLast.DataBind();
                pnlBankDetailsBill.Visible = true;
                //fnFormatGrid();

            }
            else
            {
                GrdLast.DataSource = null;
                GrdLast.DataBind();
                pnlBankDetailsBill.Visible = false;
            }
        }
        catch { }
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        ViewForwardDetail.Style.Add("display", "none");
        ViewForwardDetail1.Style.Add("display", "none");
    }

    protected void GrdLeaveApproval_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdBankDetailsBill.PageIndex = e.NewPageIndex;
        FillVoucherBillBankDetails();
    }

    protected void GrdLast_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLast.PageIndex = e.NewPageIndex;
        //FillVoucherBillBankDetails();
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

                HiddenField hdnIsChequeIssue = (HiddenField)e.Row.FindControl("hdnIsChequeIssue");
                HiddenField hdnLastID = (HiddenField)e.Row.FindControl("hdnLastID");
                HiddenField hdnID = (HiddenField)e.Row.FindControl("hdnID");

                if (hdnIsChequeIssue.Value == "2")
                {
                    if (hdnLastID.Value == hdnID.Value)
                    {
                        Label lblBillPendingApprove = (Label)e.Row.FindControl("lblBillPendingApprove");
                        lblBillPendingApprove.Text = "RTGS Generated";

                        //lblActionDate  lblApprovedOfficer lblRemark
                        Label lblActionDate = (Label)e.Row.FindControl("lblActionDate");
                        lblActionDate.Text = DataBinder.Eval(e.Row.DataItem, "CqDate").ToString();
                        e.Row.Attributes.Add("style", "background-color:red;color:white");
                    }
                }
            }
        }
        catch { }
    }

    protected void GridLab_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                Label lblBillPendingApprove = (Label)e.Row.FindControl("lblBillPendingApprove");
                HiddenField hdnIsChequeIssue = (HiddenField)e.Row.FindControl("hdnIsChequeIssue");

                if (hdnIsChequeIssue.Value == "2")
                {
                    lblBillPendingApprove.Text = "RTGS Generated";

                }

                System.Web.UI.HtmlControls.HtmlAnchor hreflnk = (System.Web.UI.HtmlControls.HtmlAnchor)e.Row.FindControl("hreflnk");
                string DepartmentName_V = DataBinder.Eval(e.Row.DataItem, "DepartmentName_V").ToString();
                string BillID_I = DataBinder.Eval(e.Row.DataItem, "BillID_I").ToString();

                if (DepartmentName_V == "Building")
                {
                    hreflnk.HRef = "Building/Building006_Payments.aspx?Cid=" + new APIProcedure().Encrypt(BillID_I) + "&vw=rpt";
                }
                else if (DepartmentName_V == "Printing")
                {
                    hreflnk.HRef = "Printing/PRI003_BillDetails.aspx?ID=" + new APIProcedure().Encrypt(BillID_I) + "&vw=1";
                }
                else if (DepartmentName_V == "Vehicle")
                {
                    string VoucherID = DataBinder.Eval(e.Row.DataItem, "VoucherTrno_I").ToString();
                    hreflnk.HRef = "PRI003_CreateVoucher.aspx?Cid=" + new APIProcedure().Encrypt(VoucherID) + "&vw=" + new APIProcedure().Encrypt(DepartmentName_V) + "&id=" + new APIProcedure().Encrypt("0") + "&b=rpt";
                }
                else if (DepartmentName_V == "Paper")
                {
                    hreflnk.HRef = "paper/CreateVouchar.aspx?ID=" + new APIProcedure().Encrypt(BillID_I) + "&vw=rpt";
                }
            }
            catch { }
        }
    }

    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("DeyakNo_V").ToString();
        Literal ltrSno = (Literal)lt.FindControl("ltrSNo");
        Literal ltrdt = (Literal)lt.FindControl("ltrBRDate");
        LinkButton lnk = (LinkButton)lt.FindControl("lnkViewDetail");
        Literal ltrPartyBillNo_V = (Literal)lt.FindControl("ltrPartyBillNo_V");
        ltrPartyBillNo_V.Text = Eval("PartyBillNo_V").ToString();
        

        if (!string.Equals(lt.Text, leaderName))
        {
            leaderName = lt.Text;
            ltrSno.Text = ltSno.ToString();
            ltrdt.Text = Eval("ApplicationDate").ToString();
            lnk.Text = "View Details";
            ltSno++;
        }
        else
        {
            lt.Text = string.Empty;
            ltrdt.Text = "";
            lnk.Text = "";
            ltrPartyBillNo_V.Text = "";
        }
    }

    private void fnFormatGrid()
    {
        for (int rowIndex = GrdBankDetailsBill.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GrdBankDetailsBill.Rows[rowIndex];
            GridViewRow gvPreviousRow = GrdBankDetailsBill.Rows[rowIndex + 1];

            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {
                if (cellCount == 0)
                {
                    //  i = i + 1;
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                    {
                        // aj = aj + 1;
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }


                }
               
                else if (cellCount == 1)
                {
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                    {

                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }
                }


                else
                {
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text) && (gvRow.Cells[2].Text == gvPreviousRow.Cells[2].Text))
                    {

                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }
                }
            }
        }
    }
       
}
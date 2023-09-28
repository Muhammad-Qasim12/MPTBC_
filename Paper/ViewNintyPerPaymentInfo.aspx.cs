using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class Paper_ViewNintyPerPaymentInfo : System.Web.UI.Page
{
    DataSet ds;
    ppr_VoucharDetails objPaperVoucharDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    double Amount = 0, Weight = 0, NoOfReel = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       CntrDepot_Id = Session["UserID"].ToString(); 
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            GetDesignationId();
            GridFillLoad();
        }
    }

    public void GetDesignationId()
    {
        try
        {

            string UserID = Session["UserID"].ToString();
            DataTable dt = obCommonFuction.FillDatasetByProc("call USP_LIST_HR_Employee_Basic_Fiters(18,0,0," + UserID + ",'')").Tables[0];
            if (dt.Rows.Count > 0)
            {                
                hfLoggedInDeptName.Value = dt.Rows[0]["DepartmentName"].ToString();
                hfApprovedFlag.Value = dt.Rows[0]["DesignationName"].ToString();
            }
            else
            {
                
            }

        }
        catch { }
    }

    public void GridFillLoad()
    {
        try
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            GrdLOI.DataSource = objPaperVoucharDetails.ShowAllData();
            GrdLOI.DataBind();

            //ppr_VoucharDetails_New objPaperVoucharDetails11 = new ppr_VoucharDetails_New();
            //GrdLOI.DataSource = objPaperVoucharDetails11.ShowAllData();

            if (GrdLOI.Rows.Count > 0)
            {
                if (hfApprovedFlag.Value == "सहायक ग्रेड-2" && hfLoggedInDeptName.Value == "Paper")
                {
                    GrdLOI.Columns[9].Visible = true;
                }
                else if (hfApprovedFlag.Value == "सहायक ग्रेड-3" && hfLoggedInDeptName.Value == "Paper")
                {
                    GrdLOI.Columns[9].Visible = true;
                }
                else
                    GrdLOI.Columns[9].Visible = false;
            }
        }
        catch { }

    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperVoucharDetails = new ppr_VoucharDetails();
        //objPaperVoucharDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVoucharDate = (Label)e.Row.FindControl("lblVoucharDate");
            LinkButton lnk = (LinkButton)e.Row.FindControl("lnBtnViewGroup");
            HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
            Label ltrStatus = (Label)e.Row.FindControl("ltrStatus");

                       
            HiddenField hdnIsChequeIssue = (HiddenField)e.Row.FindControl("hdnIsChequeIssue");
            //Panel pnl2 = (Panel)e.Row.FindControl("Panel33");
            HiddenField hdnVchrStatus = (HiddenField)e.Row.FindControl("hdnVchrStatus");

            //panel for view bill only
            Panel Panel1 = (Panel)e.Row.FindControl("Panel1");

            //panel for edit bill only
            Panel pnupdate = (Panel)e.Row.FindControl("pnupdate");

            HiddenField hdnVoucherID = (HiddenField)e.Row.FindControl("hdnVoucherID");

            Panel pnlCreateV = (Panel)e.Row.FindControl("pnlCreateV");
            Panel pnlEditV = (Panel)e.Row.FindControl("pnlEditV");
            Panel pnlViewV = (Panel)e.Row.FindControl("pnlViewV");

            if (hdnIsChequeIssue.Value == "1")
            {
                lnk.Visible = false;
                pnupdate.Visible = false;
                Panel1.Visible = true;

                pnlCreateV.Visible = false;
                pnlEditV.Visible = false;
                pnlViewV.Visible = true;
            }
            else if (int.Parse(hdnVchrStatus.Value) >= 1)
            {
                lnk.Visible = false;
                pnupdate.Visible = false;
                Panel1.Visible = true;

                pnlCreateV.Visible = false;
                pnlEditV.Visible = false;
                pnlViewV.Visible = true;
            }
            else if (hdnIsChequeIssue.Value == "1" || hdnIsChequeIssue.Value == "2")
            {
                lnk.Visible = false;
                pnupdate.Visible = false;
                Panel1.Visible = true;
            }            
            
            DateTime dat = new DateTime();
            try
            {
                dat = DateTime.Parse(lblVoucharDate.Text);
                lblVoucharDate.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }

            if (hdnVchrStatus.Value == "0")
            {
                pnupdate.Visible = true;
            }
            else
            {
                obCommonFuction = new CommonFuction();
                string Id = hdnVoucherID.Value;
                DataTable dt = obCommonFuction.FillDatasetByProc("call USP_GET_Application_Request_Detail(11, " + Id + ")").Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string CreatedByDesgId = dt.Rows[0]["DesignationTrno_I"].ToString();
                    string PendingDesgId = dt.Rows[0]["Approvedby"].ToString();
                    if ((CreatedByDesgId == PendingDesgId))
                    {
                        pnupdate.Visible = true;
                        pnlCreateV.Visible = false;
                        pnlEditV.Visible = true;
                        pnlViewV.Visible = false;
                    }
                    else pnupdate.Visible = false;
                }
            }
        }
    }

    protected void lnkShowData_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblVouchar_Tr_Id = (Label)gv.FindControl("lblVouchar_Tr_Id");
        objPaperVoucharDetails = new ppr_VoucharDetails();
        objPaperVoucharDetails.Vouchar_Tr_Id = int.Parse(lblVouchar_Tr_Id.Text);
        ds = objPaperVoucharDetails.FiledFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdShowVouchar.DataSource = ds.Tables[0];
            GrdShowVouchar.DataBind();
        }
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }
    protected void GrdShowVouchar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblChallanDate = (Label)e.Row.FindControl("lblChallanDate");
            Label lblGrDate = (Label)e.Row.FindControl("lblGrDate");
            Label lblReceivedDate = (Label)e.Row.FindControl("lblReceivedDate");

            Label lblNoOfReel = (Label)e.Row.FindControl("lblNoOfReel");
            Label lblWeight = (Label)e.Row.FindControl("lblWeight");
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");

            try
            {
                Amount = Amount + double.Parse(lblAmount.Text);
            }
            catch { Amount = 0; }
            try
            {
                Weight = Weight + double.Parse(lblWeight.Text);
            }
            catch { Weight = 0; }
            try
            {
                NoOfReel = NoOfReel + double.Parse(lblNoOfReel.Text);
            }
            catch { NoOfReel = 0; }

            DateTime Dte = new DateTime();
            Dte = DateTime.Parse(lblChallanDate.Text);
            lblChallanDate.Text = Dte.ToString("dd/MM/yyyy");
            try
            {
                Dte = DateTime.Parse(lblGrDate.Text);
                lblGrDate.Text = Dte.ToString("dd/MM/yyyy");
            }
            catch { }
            Dte = DateTime.Parse(lblReceivedDate.Text);
            lblReceivedDate.Text = Dte.ToString("dd/MM/yyyy");
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFNoOfReel = (Label)e.Row.FindControl("lblFNoOfReel");
            Label lblFWeight = (Label)e.Row.FindControl("lblFWeight");
            Label lblFAmount = (Label)e.Row.FindControl("lblFAmount");
            lblFNoOfReel.Text = NoOfReel.ToString();
            lblFWeight.Text = Weight.ToString("0.00");
            lblFAmount.Text = Amount.ToString("0.00");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.VoucharNo = txtSearch.Text;
            GrdLOI.DataSource = objPaperVoucharDetails.VoucherSearchName();
            GrdLOI.DataBind();
        }
        catch { }

    }

    protected void lnBtnViewGroup_Click(object sender, EventArgs e)
    {
        //status = 2 : send to finance, status=1 : approved, status =0 : not approved
        LinkButton lnkSender = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;

        Label HBill = (Label)gv.FindControl("lblVouchar_Tr_Id");

        ppr_VoucharDetails_New1 objBillDetails = new ppr_VoucharDetails_New1();
        objBillDetails.Vouchar_Tr_Id = int.Parse(HBill.Text);
        objBillDetails.Status = 2;
        int i = objBillDetails.SendToFinance();
        if(i>0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Status updated successfully.');</script>");
            GridFillLoad();
        }
    }
}

public class ppr_VoucharDetails_New1
{
    private int _Vouchar_Tr_Id;
    private int _Status;

    public int Vouchar_Tr_Id { get { return _Vouchar_Tr_Id; } set { _Vouchar_Tr_Id = value; } }   
    public int Status { get { return _Status; } set { _Status = value; } }

    public int SendToFinance()
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0018_VoucharDataShow_ppr_new", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mPaperVendorTrId_I", 0);
        obDBAccess.addParam("mDisTranId", 0);
        obDBAccess.addParam("mDisDtl_Id", 0);
        obDBAccess.addParam("mLOITrId_I", 0);
        obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
        obDBAccess.addParam("mtype", 8);
        obDBAccess.addParam("mBankName", "");
        obDBAccess.addParam("mCqDate", "2017-04-17");
        obDBAccess.addParam("mChequeNo", "");
        int result = obDBAccess.executeMyQuery();
        return result;
    }  
   

    // public System.Data.DataSet ShowAllDataCashierDashobard()
    //{
    //    DBAccess obDBAccess = new DBAccess();
    //    obDBAccess.execute("USP_PPR0018_VoucharDataShow_ppr_new", DBAccess.SQLType.IS_PROC);
    //    obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
    //    obDBAccess.addParam("mDisTranId", 0);
    //    obDBAccess.addParam("mDisDtl_Id", 0);
    //    obDBAccess.addParam("mLOITrId_I", 0);
    //    obDBAccess.addParam("mVouchar_Tr_Id", 0);
    //    obDBAccess.addParam("mtype", 9);
    //    return obDBAccess.records();
    //}
}
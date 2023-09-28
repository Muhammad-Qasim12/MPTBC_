using MPTBCBussinessLayer.Paper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_ViewDefectivePayment : System.Web.UI.Page
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
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.VoucharNo = "";
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0019_ThabbaVoucharSearchNameYear('','"+ddlAcYear.SelectedItem.Text+"')");
            //GrdLOI.DataSource = objPaperVoucharDetails.VoucherThabbaSearchName();
            GrdLOI.DataSource = ds1.Tables[0];
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

        ppr_VoucharDetails_New objBillDetails = new ppr_VoucharDetails_New();
        objBillDetails.Vouchar_Tr_Id = int.Parse(HBill.Text);
        objBillDetails.Status = 2;
        int i = objBillDetails.SendToFinance();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Status updated successfully.');</script>");
            GridFillLoad();
        }
    }

    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
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

            if (hdnStatus.Value == "3")
            {
                lnk.Visible = false;
                ltrStatus.Visible = true;
                ltrStatus.Text = "Cheque Issued";
            }
            else if (hdnStatus.Value == "2")
            {
                lnk.Visible = false;
                ltrStatus.Visible = true;
                lnk.Text = "";
                ltrStatus.Text = "फ़ाइनेंस को भेजा गया";
            }
            else if (hdnStatus.Value == "0" || hdnStatus.Value == "1")
            {
                lnk.Visible = true;
                ltrStatus.Visible = false;
                lnk.Text = "Send To Finance";
                ltrStatus.Text = "";
            }

            DateTime dat = new DateTime();
            try
            {
                dat = DateTime.Parse(lblVoucharDate.Text);
                lblVoucharDate.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }
        }
    }

    protected void GrdShowVouchar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblVoucharDate = (Label)e.Row.FindControl("lblVoucharDate");
            // Label lblGrDate = (Label)e.Row.FindControl("lblGrDate");
            // Label lblReceivedDate = (Label)e.Row.FindControl("lblReceivedDate");

            //Label lblNoOfReel = (Label)e.Row.FindControl("lblNoOfReel");
            //Label lblWeight = (Label)e.Row.FindControl("lblWeight");
            //Label lblAmount = (Label)e.Row.FindControl("lblAmount");

            //try
            //{
            //    Amount = Amount + double.Parse(lblAmount.Text);
            //}
            //catch { Amount = 0; }
            //try
            //{
            //    Weight = Weight + double.Parse(lblWeight.Text);
            //}
            //catch { Weight = 0; }
            //try
            //{
            //    NoOfReel = NoOfReel + double.Parse(lblNoOfReel.Text);
            //}
            //catch { NoOfReel = 0; }

            DateTime Dte = new DateTime();
            Dte = DateTime.Parse(lblVoucharDate.Text);
            lblVoucharDate.Text = Dte.ToString("dd/MM/yyyy");
            //try
            //{
            //    Dte = DateTime.Parse(lblGrDate.Text);
            //    lblGrDate.Text = Dte.ToString("dd/MM/yyyy");
            //}
            //catch { }
            //Dte = DateTime.Parse(lblReceivedDate.Text);
            //lblReceivedDate.Text = Dte.ToString("dd/MM/yyyy");
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Label lblFNoOfReel = (Label)e.Row.FindControl("lblFNoOfReel");
            //Label lblFWeight = (Label)e.Row.FindControl("lblFWeight");
            //Label lblFAmount = (Label)e.Row.FindControl("lblFAmount");
            //lblFNoOfReel.Text = NoOfReel.ToString();
            //lblFWeight.Text = Weight.ToString("0.00");
            //lblFAmount.Text = Amount.ToString("0.00");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.VoucharNo = txtSearch.Text;
            //GrdLOI.DataSource = objPaperVoucharDetails.VoucherThabbaSearchName();
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0019_ThabbaVoucharSearchNameYear('"+txtSearch.Text+"','" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataSource = ds1.Tables[0];
            GrdLOI.DataBind();
        }
        catch { }

    }
}

public class ppr_VoucharDetails_New
{
    private int _Vouchar_Tr_Id;
    private int _Status;

    public int Vouchar_Tr_Id { get { return _Vouchar_Tr_Id; } set { _Vouchar_Tr_Id = value; } }
    public int Status { get { return _Status; } set { _Status = value; } }

    public int SendToFinance()
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow_ppr_new", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mPaperVendorTrId_I", 0);
        obDBAccess.addParam("mDisTranId", 0);
        obDBAccess.addParam("mDisDtl_Id", 0);
        obDBAccess.addParam("mLOITrId_I", 0);
        obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
        obDBAccess.addParam("mtype", 12);
        obDBAccess.addParam("mBankName", "");
        obDBAccess.addParam("mCqDate", "2017-04-17");
        obDBAccess.addParam("mChequeNo", "");
        obDBAccess.addParam("mRemark", "");
        int result = obDBAccess.executeMyQuery();
        return result;
    }


   
}
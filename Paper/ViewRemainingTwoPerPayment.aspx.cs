using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class Paper_ViewRemainingTwoPerPayment : System.Web.UI.Page
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
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.VoucharNo = "";
            GrdLOI.DataSource = objPaperVoucharDetails.Voucher2SearchName();
            GrdLOI.DataBind();
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
            GrdLOI.DataSource = objPaperVoucharDetails.Voucher2SearchName();
            GrdLOI.DataBind();
        }
        catch { }

    }
}
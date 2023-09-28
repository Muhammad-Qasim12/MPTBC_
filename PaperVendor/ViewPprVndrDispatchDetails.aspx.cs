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
using System.Globalization;
using MPTBCBussinessLayer.Paper;

public partial class Paper_DispatchDetails : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdd = new APIProcedure();
    string PaperVendorTrId_I = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
           // GridFillLoad();
            if (Request.QueryString["e"] != null && Request.QueryString["e"].ToString() != "")
            {
                txtSearch.Text = objdd.Decrypt(Request.QueryString["e"].ToString());
                GridFillLoad();
                txtSearch.Text = "";
            }
        }
    }

    public void GridFillLoad()
    {
        try
        {
            //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            //objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I); 
            //GrdLOI.DataSource = objPaperDispatchDetails.ShowAllData();
            //GrdLOI.DataBind();
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
            GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchSearchNameNew('" + txtSearch.Text + "'," + PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataBind();
        }
        catch { }

    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(2)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
           // ddlAcYear.SelectedValue = obCommonFuction.GetFinYearNew();
            //ddlAcYear.Enabled = false;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
        GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchSearchNameNew('" + txtSearch.Text + "'," + PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "')");
        GrdLOI.DataBind();
    }
    protected void lnkChangeSts_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv=(GridViewRow)lnk.NamingContainer;
        Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
        obCommonFuction.FillDatasetByProc("call Usp_pprLOISearchDetails('" + lblDisTranId.Text + "','',7)");
         GridFillLoad();
    }
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblChallanDate = (Label)e.Row.FindControl("lblChallanDate");
            Label lblSupplyTillDate_D = (Label)e.Row.FindControl("lblSupplyTillDate_D");
            Label lblPaperQty = (Label)e.Row.FindControl("lblPaperQty");
            Label lblLOITrId_I = (Label)e.Row.FindControl("lblLOITrId_I");
            Label lblPaperVendorTrId_I = (Label)e.Row.FindControl("lblPaperVendorTrId_I");
            Label lblPaperMstrTrId_I = (Label)e.Row.FindControl("lblPaperMstrTrId_I");
            Label lblReceivedDate = (Label)e.Row.FindControl("lblReceivedDate");
            Label lblSupplyDate_D = (Label)e.Row.FindControl("lblSupplyDate_D");
            DateTime dat = new DateTime();
            try
            {
                dat = DateTime.Parse(lblReceivedDate.Text);
                lblReceivedDate.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }

           
            dat = DateTime.Parse(lblChallanDate.Text);
            lblChallanDate.Text = dat.ToString("dd/MM/yyyy");
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(lblPaperVendorTrId_I.Text);
            objPaperDispatchDetails.LOITrId_I = int.Parse(lblLOITrId_I.Text);
            objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
            ds = objPaperDispatchDetails.WorkQtyData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    dat = DateTime.Parse(ds.Tables[0].Rows[0]["SupplyTillDate_D"].ToString());
                    lblSupplyTillDate_D.Text = dat.ToString("dd/MM/yyyy");
                }
                catch { }
                try
                {
                    dat = DateTime.Parse(ds.Tables[0].Rows[0]["SupplyDate_D"].ToString());
                    lblSupplyDate_D.Text = dat.ToString("dd/MM/yyyy");
                }
                catch { }
                lblPaperQty.Text = ds.Tables[0].Rows[0]["PaperQuantity_N"].ToString();
            }
            else
            {
                lblPaperQty.Text = "0";
            }

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Acyyear"] = ddlAcYear.SelectedItem.Text;
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
            GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchSearchNameNew('" + txtSearch.Text + "'," + PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataBind();
 
        }
        catch { }
    }
    protected void GrdLOI_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
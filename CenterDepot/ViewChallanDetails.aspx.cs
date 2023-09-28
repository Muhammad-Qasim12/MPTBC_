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
    PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails ();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            VendorFill();
            GridFillLoad();
            
        }
    }
    public void GridFillLoad()
    {
        int VenderID = 0;
        //try
        //{
        if (ddlVendor.SelectedItem.Text == "All")
        {
            VenderID = 0;
        }
        else
        {
            VenderID = Convert.ToInt32(ddlVendor.SelectedValue);
        }
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr=new DataSet();
          //  objPaperDispatchDetails = new PPR_PaperDispatchDetails();
           // GrdLOI.DataSource = objPaperDispatchDetails.CentralDepoShowAllData();

            if (ChkPen.Checked == true)
            {
                dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchShowDataByAcYear(" + VenderID + ",0,0,0,0,0,'" + ddlAcYear.SelectedItem.Text + "',12)");
            }
            else
            {
                dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchShowDataByAcYear(" + VenderID + ",0,0,0,0,0,'" + ddlAcYear.SelectedItem.Text + "',10)");
            }
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();
        //}
        //catch { }

    }
    public void VendorFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "All");
    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
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

                if (lblReceivedDate.Text == "0001-01-01 00:00:00")
                {
                    lblReceivedDate.Text = "";
                }
                else
                {
                    dat = DateTime.Parse(lblReceivedDate.Text);
                    lblReceivedDate.Text = dat.ToString("dd/MM/yyyy");
                }
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
        //try
        //{
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //GrdLOI.DataSource = objPaperDispatchDetails.CenterDpotSearchName(txtSearch.Text);
        //GrdLOI.DataBind();
          int VenderID = 0;
            if (ddlVendor.SelectedItem.Text == "All")
            {
                VenderID = 0;
            }
            else
            {
                VenderID = Convert.ToInt32(ddlVendor.SelectedValue);
            }
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();
            if (ChkPen.Checked == true)
            {
                dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewpending('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            }
            else
            {
                dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNew('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            }
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();
        //}
        //catch { }
    }
    protected void lnkChangeSts_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
        obCommonFuction.FillDatasetByProc("call Usp_pprLOISearchDetails('" + lblDisTranId.Text + "','',8)");
        GridFillLoad();
    }
}
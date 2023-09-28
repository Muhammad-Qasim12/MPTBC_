using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Paper_ViewPaperMillAgreement : System.Web.UI.Page
{
    CommonFuction objComm = new CommonFuction();
    DataSet ds;
    PPR_WorkPlan objWorkPlan = null;
    public string AgreementDate, AgreementNo, Validity, PBGAMT, PBGNo, LOITo, LOIDate, LOINo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            //objWorkPlan = new PPR_WorkPlan();
            if (ddlAcYear.SelectedValue != "")
            {
                GrdAgreement.DataSource = objComm.FillDatasetByProc("Call Usp_pprLOISearchDetails('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Text + "',5)");// objWorkPlan.Select();
                GrdAgreement.DataBind();
            }
        }
        catch { }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

        try
        {
            GridFillLoad();
            //objWorkPlan = new PPR_WorkPlan();
            // GrdAgreement.DataSource = objWorkPlan.SearchWorkName(txtSearch.Text);
            //GrdAgreement.DataBind();
        }
        catch { }

    }

    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblStartDate = (Label)e.Row.FindControl("lblStartDate");
            Label lblSupplyDate_D = (Label)e.Row.FindControl("lblSupplyDate_D");
            Label lblEndDate_D = (Label)e.Row.FindControl("lblEndDate_D");
            DateTime dat = new DateTime();
            try
            {
                dat = DateTime.Parse(lblSupplyDate_D.Text);
                lblSupplyDate_D.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }
            try
            {
                dat = DateTime.Parse(lblStartDate.Text);
                lblStartDate.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }
            try
            {
                dat = DateTime.Parse(lblEndDate_D.Text);
                lblEndDate_D.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }


        }
    }

    protected void lnkView_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblAgreementTrId_I = (Label)gv.FindControl("lblAgreementTrId_I");
        objWorkPlan = new PPR_WorkPlan();
        try
        {
            objWorkPlan.WorkPlanTrId_I = int.Parse(lblAgreementTrId_I.Text);
        }
        catch { }

        ds = objWorkPlan.AgreeMentPBGDetails();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdPBGInfo.DataSource = ds.Tables[0];
            GrdPBGInfo.DataBind();

            DateTime dtL = new DateTime();
            try
            {
                dtL = DateTime.Parse(ds.Tables[0].Rows[0]["AgreementDate_D"].ToString());
                AgreementDate = dtL.ToString("dd/MM/yyyy");
            }
            catch { }
            try
            {
                dtL = DateTime.Parse(ds.Tables[0].Rows[0]["LOIDate_D"].ToString());
                LOIDate = dtL.ToString("dd/MM/yyyy");
            }
            catch { }

            AgreementNo = ds.Tables[0].Rows[0]["AgreementNo_V"].ToString();
            Validity = ds.Tables[0].Rows[0]["ValidityTime_I"].ToString();
            PBGAMT = ds.Tables[0].Rows[0]["PBGAmount"].ToString();
            PBGNo = ds.Tables[0].Rows[0]["PBGNo_V"].ToString();
            LOITo = ds.Tables[0].Rows[0]["PaperVendorName_V"].ToString();
            //  LOIDate = ds.Tables[0].Rows[0]["LOIDate_D"].ToString();
            LOINo = ds.Tables[0].Rows[0]["LOINo_V"].ToString();
        }
        else
        {
            AgreementDate = ""; AgreementNo = ""; Validity = ""; PBGAMT = ""; PBGNo = ""; LOITo = ""; LOIDate = ""; LOINo = "";
        }
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }

    protected void lnkViewOrder_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        HiddenField hdnLOIId = (HiddenField)gv.FindControl("hdnLOIId");
        try
        {
            if (hdnLOIId.Value != "")
            {
                objWorkPlan = new PPR_WorkPlan();
                objWorkPlan.LOITrId_I = int.Parse(hdnLOIId.Value);
                GrdWorkPlan.DataSource = objWorkPlan.GrWorkPlanFill();
                GrdWorkPlan.DataBind();
            }
        }
        catch { }

        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill11();</script>");
    }

    protected void GrdAgreement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objWorkPlan = new PPR_WorkPlan();
        objWorkPlan.Delete(Convert.ToInt32(GrdAgreement.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdAgreement_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdAgreement.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdAgreement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dtL = new DateTime();
            Label lblAgreementTrId_I = (Label)e.Row.FindControl("lblAgreementTrId_I");
            Label lblPprVendorAgrSts = (Label)e.Row.FindControl("lblPprVendorAgrSts");
            Panel pnlAgrUpdt = (Panel)e.Row.FindControl("pnlAgrUpdt");

            Label lblTenderSubmissionDate_D = (Label)e.Row.FindControl("lblPBGDate_D");
            Panel pnlAgr = (Panel)e.Row.FindControl("pnlAgr");
            Panel pnlAgrDwnd = (Panel)e.Row.FindControl("pnlAgrDwnd");
            Panel pnlAgrDwndNo = (Panel)e.Row.FindControl("pnlAgrDwndNo");

            Panel pnlAgrUpdate = (Panel)e.Row.FindControl("pnlAgrUpdate");
            Panel pnlAgrUpdateNo = (Panel)e.Row.FindControl("pnlAgrUpdateNo");


            Panel Panel1StsYes = (Panel)e.Row.FindControl("Panel1StsYes");
            Panel Panel1StsNo = (Panel)e.Row.FindControl("Panel1StsNo");
            Panel PnlStsDate = (Panel)e.Row.FindControl("PnlStsDate");

            LinkButton lnkView11 = (LinkButton)e.Row.FindControl("lnkView11");

            if (lblAgreementTrId_I.Text == "0" && lblPprVendorAgrSts.Text == "Yes")
            {
                Panel1StsYes.Visible = true;
                PnlStsDate.Visible = true;
            }
            else if (lblAgreementTrId_I.Text == "0" && lblPprVendorAgrSts.Text == "No")
            {
                Panel1StsNo.Visible = true;
                PnlStsDate.Visible = true;
                pnlAgrDwndNo.Visible = true;
                pnlAgrUpdateNo.Visible = true;
            }
            else if (lblAgreementTrId_I.Text != "0")
            {
                pnlAgr.Visible = true;
                pnlAgrUpdt.Visible = true;
                pnlAgrDwnd.Visible = true;
                pnlAgrUpdate.Visible = true;
            }
            try
            {
                dtL = DateTime.Parse(lblTenderSubmissionDate_D.Text);
                lblTenderSubmissionDate_D.Text = dtL.ToString("dd/MM/yyyy");
                lnkView11.Text = lblTenderSubmissionDate_D.Text;
            }
            catch { }


        }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = objComm.FillDatasetByProc("call ppr_GetAcYearAllTbl(5)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Enabled = false;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
}
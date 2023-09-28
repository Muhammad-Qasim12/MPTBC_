using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Paper_ViewVendorAgreement : System.Web.UI.Page
{
    DataSet ds;
    DPT_AgreementDtl objAgreementDtl = null;
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
            objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));

            GrdAgreement.DataSource = objAgreementDtl.Select();
            GrdAgreement.DataBind();
        }
        catch { }

    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblAgreementTrId_I = (Label)gv.FindControl("lblAgreementTrId_I");
        objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));
        objAgreementDtl .AgreementTrId_I=int.Parse(lblAgreementTrId_I.Text);
        ds = objAgreementDtl.AgreeMentPBGDetails();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DateTime dtL = new DateTime();

            dtL = DateTime.Parse(ds.Tables[0].Rows[0]["AgreementDate_D"].ToString());
            AgreementDate = dtL.ToString("dd/MM/yyyy");

            dtL = DateTime.Parse(ds.Tables[0].Rows[0]["LOIDate_D"].ToString());
            LOIDate = dtL.ToString("dd/MM/yyyy");
           
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
    protected void GrdAgreement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));
        objAgreementDtl.Delete(Convert.ToInt32(GrdAgreement.DataKeys[e.RowIndex].Value.ToString()));
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
            Label lblTenderSubmissionDate_D = (Label)e.Row.FindControl("lblPBGDate_D");
            dtL = DateTime.Parse(lblTenderSubmissionDate_D.Text);
            lblTenderSubmissionDate_D.Text = dtL.ToString("dd/MM/yyyy");
        }
    }
}
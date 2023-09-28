using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;

public partial class DistributionB_ViewTenderInsuranceInfo : System.Web.UI.Page
{
    InsuranceTenderInfo ObjTenderInfo = null;
    DataSet ds;
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
            ObjTenderInfo = new InsuranceTenderInfo();
            ObjTenderInfo.TenderTrId_I = 0;
            GrdTenderInfo.DataSource = ObjTenderInfo.Select();
            GrdTenderInfo.DataBind();
        }
        catch { }

    }
    protected void GrdTenderInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjTenderInfo = new InsuranceTenderInfo();
        ObjTenderInfo.Delete(Convert.ToInt32(GrdTenderInfo.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdTenderInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTenderInfo.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdTenderInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DateTime dtL = new DateTime();
        //    Label lblTenderSubmissionDate_D = (Label)e.Row.FindControl("lblTenderSubmissionDate_D");
        //    dtL = DateTime.Parse(lblTenderSubmissionDate_D.Text);
        //    lblTenderSubmissionDate_D.Text = dtL.ToString("dd/MM/yyyy");
        //}
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ObjTenderInfo = new InsuranceTenderInfo();
            ObjTenderInfo.WorkName_V = txtSearch.Text;
            GrdTenderInfo.DataSource = ObjTenderInfo.TenderNameSearch();
            GrdTenderInfo.DataBind();
        }
        catch { }
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }

    protected void lnkTenderNo_V_Click(object sender, EventArgs e)
    {
        try
        {
            Messages.Style.Add("display", "block");
            fadeDiv.Style.Add("display", "block");
            LinkButton lnk = (LinkButton)sender;
            GridViewRow GV = (GridViewRow)lnk.NamingContainer;
            int lblTenderTrId_I = Convert.ToInt32(((Label)GV.FindControl("lblTenderTrId_I")).Text);

            ObjTenderInfo = new InsuranceTenderInfo();
            ObjTenderInfo.TenderTrId_I = Convert.ToInt32(lblTenderTrId_I);
            ds = ObjTenderInfo.Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataSet ds1 = new DataSet();
                ObjTenderInfo.TenderTrId_I = -1;
                ObjTenderInfo.StringParameter = ds.Tables[0].Rows[0]["DepoIDs"].ToString();
                ds1=ObjTenderInfo.Select();

                DateTime dat = new DateTime();
                DateTime SubDt = new DateTime();

                //
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
                lblTenderDate_D.Text = dat.ToString("dd/MM/yyyy");
                lblTenderSubmissionDate_D.Text = SubDt.ToString("dd/MM/yyyy");
                lblTenderSubmissionTime.Text = ds.Tables[0].Rows[0]["TenderSubmissionTime"].ToString();
                lblTenderDescription_V.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
                lblEMDAmount_N.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
                lblNameOfWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
                lblRemark_V.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
                lblTenderNo_V.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
                lblTenderFees_N.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();


                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
                lblCommDate.Text = SubDt.ToString("dd/MM/yyyy");
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TechDate"].ToString());
                lblTechDate.Text = SubDt.ToString("dd/MM/yyyy");

                lblInsuranceDateFrom_D.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateFrom_D"]).ToString("dd/MM/yyyy");
                lblInsuranceDateTo_D.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateTo_D"]).ToString("dd/MM/yyyy");
                lblTechTime.Text = ds.Tables[0].Rows[0]["TechTime"].ToString();
                lblCommTime.Text = ds.Tables[0].Rows[0]["CommTime"].ToString();

                lblTenderAmount.Text = ds.Tables[0].Rows[0]["TenderAmount"].ToString();


                //lblTenderFile_V.Text = (ds.Tables[0].Rows[0]["TenderFile_V"].ToString());

                //lblDepoIDs.Text = ds.Tables[0].Rows[0]["DepoIDs"].ToString();
                lblDepoIDs.Text = ds1.Tables[0].Rows[0]["Depo"].ToString();

                lblTenderType_V.Text = ds.Tables[0].Rows[0]["TenderType_V"].ToString();
            }
        }
        catch
        {
        }
        finally { ObjTenderInfo = null; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer.DistributionB;

public partial class DistributionB_TechnicalTermCondition : System.Web.UI.Page
{
    DataSet ds;

    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    TechnicalBidCondition objTechnicalBidCondition = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridFill();
            ViewState["Tender_Cond_Id"] = "";
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        objTechnicalBidCondition = new TechnicalBidCondition();
        objTechnicalBidCondition.DisplaySts = ddlDisplayStatus.SelectedItem.Text;
        objTechnicalBidCondition.TndrCondition = txtCondition.Text.ToString();
        objTechnicalBidCondition.UserId_I = int.Parse(Session["UserID"].ToString()); ;
        if (txtCondition.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter all feilds.');</script>");
        }
        else
        {
            if (ViewState["Tender_Cond_Id"] != "")
            {
                objTechnicalBidCondition.Tender_Cond_Id = int.Parse(ViewState["Tender_Cond_Id"].ToString());
                //try
                //{
                int j = objTechnicalBidCondition.InsertUpdate();
                if (j > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    ddlDisplayStatus.SelectedIndex = 0;
                    txtCondition.Text = "";
                    GridFill();
                }
                //}
                //catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Paper Quality Already Exist.');</script>"); }
            }
            else
            {
                objTechnicalBidCondition.Tender_Cond_Id = 0;

                int i = objTechnicalBidCondition.InsertUpdate();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    ddlDisplayStatus.SelectedIndex = 0;
                    txtCondition.Text = "";
                    GridFill();
                }

            }
        }
    }

    public void GridFill()
    {
        try
        {
            objTechnicalBidCondition = new TechnicalBidCondition();
            GrdWorkPlan.DataSource = objTechnicalBidCondition.Select();
            GrdWorkPlan.DataBind();
            ViewState["Tender_Cond_Id"] = "";
        }
        catch { }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblTndrCondition = (Label)gv.FindControl("lblTndrCondition");
        Label lblTender_Cond_Id = (Label)gv.FindControl("lblTender_Cond_Id");
        Label lblDisplaySts = (Label)gv.FindControl("lblDisplaySts");
        txtCondition.Text = lblTndrCondition.Text;

        ddlDisplayStatus.ClearSelection();
        try
        {
            ddlDisplayStatus.Items.FindByValue(lblDisplaySts.Text).Selected = true;
        }
        catch { }
        btnSave.Visible = true;
    
        ViewState["Tender_Cond_Id"] = lblTender_Cond_Id.Text;

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblTender_Cond_Id = (Label)gv.FindControl("lblTender_Cond_Id");
        objTechnicalBidCondition = new TechnicalBidCondition();
        objTechnicalBidCondition.Delete(int.Parse(lblTender_Cond_Id.Text));
        GridFill();
    }


}

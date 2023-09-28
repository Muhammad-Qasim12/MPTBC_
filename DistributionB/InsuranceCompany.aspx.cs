using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer.DistributionB;

public partial class DistributionB_InsuranceCompany : System.Web.UI.Page
{
    DataSet ds;

    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    InsuranceCompany objInsuranceCompany = null;
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
        objInsuranceCompany = new InsuranceCompany();
        //objInsuranceCompany.DisplaySts = ddlDisplayStatus.SelectedItem.Text;
        objInsuranceCompany.Company = txtCompany.Text.ToString();
        objInsuranceCompany.UserId_I = int.Parse(Session["UserID"].ToString()); ;
        if (txtCompany.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter all feilds.');</script>");
        }
        else
        {
            if (ViewState["Tender_Cond_Id"] != "")
            {
                objInsuranceCompany.CompanyID = int.Parse(ViewState["Tender_Cond_Id"].ToString());
                //try
                //{
                int j = objInsuranceCompany.InsertUpdate();
                if (j > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    //ddlDisplayStatus.SelectedIndex = 0;
                    txtCompany.Text = "";
                    GridFill();
                }
                //}
                //catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Paper Quality Already Exist.');</script>"); }
            }
            else
            {
                objInsuranceCompany.CompanyID = 0;

                int i = objInsuranceCompany.InsertUpdate();
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    //ddlDisplayStatus.SelectedIndex = 0;
                    txtCompany.Text = "";
                    GridFill();
                }

            }
        }
    }

    public void GridFill()
    {
        try
        {
            objInsuranceCompany = new InsuranceCompany();
            GrdWorkPlan.DataSource = objInsuranceCompany.Select();
            GrdWorkPlan.DataBind();
            ViewState["Tender_Cond_Id"] = "";
        }
        catch { }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblCompany = (Label)gv.FindControl("lblCompany");
        Label lblCompanyID = (Label)gv.FindControl("lblCompanyID");
        //Label lblDisplaySts = (Label)gv.FindControl("lblDisplaySts");
        txtCompany.Text = lblCompany.Text;

        //ddlDisplayStatus.ClearSelection();
        //try
        //{
        //    ddlDisplayStatus.Items.FindByValue(lblDisplaySts.Text).Selected = true;
        //}
        //catch { }
        btnSave.Visible = true;

        ViewState["Tender_Cond_Id"] = lblCompanyID.Text;

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblTender_Cond_Id = (Label)gv.FindControl("lblTender_Cond_Id");
        objInsuranceCompany = new InsuranceCompany();
        objInsuranceCompany.Delete(int.Parse(lblTender_Cond_Id.Text));
        GridFill();
    }


}

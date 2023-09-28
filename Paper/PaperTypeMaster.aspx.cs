using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Globalization;
using MPTBCBussinessLayer.Paper;

public partial class Paper_PaperTypeMaster : System.Web.UI.Page
{
    DataSet ds;

    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PPR_PaperTypeMaster objPaperTypeMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridFill();
            ViewState["Qualifyid_I"] = "";
        }
    }

    public void PaperTypeFill()
    {
        objPaperTypeMaster = new PPR_PaperTypeMaster();
        ddlPaperType.DataSource = objPaperTypeMaster.PaperTypeFill();
        ddlPaperType.DataTextField = "PaperType";
        ddlPaperType.DataValueField = "PaperType_Id";
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "Select");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objPaperTypeMaster = new PPR_PaperTypeMaster();
        objPaperTypeMaster.PaperType_Id = int.Parse(ddlPaperType.SelectedValue.ToString());
        objPaperTypeMaster.QualifyType = txtPaperQlty.Text.ToString();
        if (ddlPaperType.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
        }
        else
        {
            if (ddlPaperType.Enabled == false)
            {
                objPaperTypeMaster.Qualifyid_I = int.Parse(ViewState["Qualifyid_I"].ToString());
                try
                {
                    int j = objPaperTypeMaster.Update();
                    if (j > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        ddlPaperType.SelectedIndex = 0;
                        txtPaperQlty.Text = "";
                        GridFill();
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Paper Quality Already Exist.');</script>"); }
            }
            else
            {
                objPaperTypeMaster.Qualifyid_I = 0;
                try
                {
                    int i = objPaperTypeMaster.InsertUpdate();
                    if (i > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                        ddlPaperType.SelectedIndex = 0;
                        txtPaperQlty.Text = "";
                        GridFill();
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Paper Quality Already Exist.');</script>"); }
            }
        }
    }

    public void GridFill()
    {
        try
        {
            objPaperTypeMaster = new PPR_PaperTypeMaster();
            GrdWorkPlan.DataSource = objPaperTypeMaster.Select();
            GrdWorkPlan.DataBind();
            ddlPaperType.Enabled = true;
            ViewState["Qualifyid_I"] = "";
        }
        catch { }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
        Label lblQualifyid_I = (Label)gv.FindControl("lblQualifyid_I");
        Label lblQualifyType = (Label)gv.FindControl("lblQualifyType");
        txtPaperQlty.Text = lblQualifyType.Text;
        PaperTypeFill();
        ddlPaperType.ClearSelection();
        ddlPaperType.Items.FindByValue(lblPaperType_I.Text).Selected = true;
        btnSave.Visible = true;
        ddlPaperType.Enabled = false;
        ViewState["Qualifyid_I"] = lblQualifyid_I.Text;

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblQualifyid_I = (Label)gv.FindControl("lblQualifyid_I");
        objPaperTypeMaster = new PPR_PaperTypeMaster();
        objPaperTypeMaster.Delete(int.Parse(lblQualifyid_I.Text));
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GridFill();
    }

    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperTypeFill();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaperTypeMasternew.aspx");
    }
}

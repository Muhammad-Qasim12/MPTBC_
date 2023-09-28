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
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Paper_PBGInfo : System.Web.UI.Page
{
    Depo_VGINFO objPBGInfo = null;
    DataSet ds;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
            }
        }

    }

    public void LOIAllFill()
    {
        objPBGInfo = new Depo_VGINFO(Convert.ToInt32(Session["UserID"]));
        ddlLOINo.DataSource = objPBGInfo.LOIFill();
          ddlLOINo.DataTextField = "LOINo_V";
        ddlLOINo.DataValueField = "LOITrId_I";
        ddlLOINo.DataBind();
        ddlLOINo.Items.Insert(0, "Select");
        if (Request.QueryString["LOITrId"] != null)
        {
            ddlLOINo.Enabled = false;
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(Request.QueryString["LOITrId"].ToString()).Selected = true;
            LOIDetailFill();
            objPBGInfo.PBGTrId_I = int.Parse(Request.QueryString["ID"].ToString());

            ds = objPBGInfo.PBGDtlFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                BankDtl();
                ddlBankDetails.ClearSelection();
                ddlBankDetails.Items.FindByValue(ds.Tables[0].Rows[0]["BankName_I"].ToString()).Selected = true;

                DateTime dat = new DateTime();
                DateTime dat1 = new DateTime();
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["PBGDate_D"].ToString());
                dat1 = DateTime.Parse(ds.Tables[0].Rows[0]["ValidityDate_D"].ToString());
                txtPBGDate.Text = dat.ToString("dd/MM/yyyy");

                txtTillDate.Text = dat1.ToString("dd/MM/yyyy");
                txtPBGAmt.Text = ds.Tables[0].Rows[0]["PBGAmount"].ToString();
                txtPBGNO.Text = ds.Tables[0].Rows[0]["PBGNo_V"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();

                txtValidityMonth.Text = ds.Tables[0].Rows[0]["ValidityTime_I"].ToString();
                rbGAgreement.SelectedValue = ds.Tables[0].Rows[0]["AgreementStatus_V"].ToString();

                
                ddlPBGMode.ClearSelection();
                ddlPBGMode.Items.FindByValue(ds.Tables[0].Rows[0]["PBGType_V"].ToString()).Selected = true;
                ddlBankDetails.Items.FindByValue(ds.Tables[0].Rows[0]["BankName_I"].ToString()).Selected = true;

            }

        }
    }


    protected void ddlLOINo_Init(object sender, EventArgs e)
    {
        LOIAllFill();
    }
    public void LOIDetailFill()
    {
        objPBGInfo = new Depo_VGINFO(Convert.ToInt32(Session["UserID"]));
        objPBGInfo.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
        ds = objPBGInfo.LOIDtlFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblLOIAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();
            lblVendorName.Text = ds.Tables[0].Rows[0]["PaperVendorName_V"].ToString();
            DateTime dat = new DateTime();
            dat = DateTime.Parse(ds.Tables[0].Rows[0]["LOIDate_D"].ToString());

            lblLOIDt.Text = dat.ToString("dd/MM/yyyy");

        }
    }
    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIDetailFill();
    }
    public void BankDtl()
    {
        objPBGInfo = new Depo_VGINFO(Convert.ToInt32(Session["UserID"]));
        ddlBankDetails.DataSource = objPBGInfo.BankDetails();
        ddlBankDetails.DataValueField = "BankId";
        ddlBankDetails.DataTextField = "BankName";
        ddlBankDetails.DataBind();
        ddlBankDetails.Items.Insert(0, "Select");
    }
    protected void ddlBankDetails_Init(object sender, EventArgs e)
    {
        BankDtl();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlLOINo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select LOI No.');</script>");
        }
        else
        {

            objPBGInfo = new Depo_VGINFO(Convert.ToInt32(Session["UserID"]));

            objPBGInfo.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
            objPBGInfo.PBGNo_V = txtPBGNO.Text.Trim();
            objPBGInfo.PBGType_V = ddlPBGMode.SelectedItem.Text;
            objPBGInfo.PBGDate_D = DateTime.Parse(txtPBGDate.Text, cult);
            objPBGInfo.BankName_I = int.Parse(ddlBankDetails.SelectedItem.Value.ToString());
            objPBGInfo.PBGAmount = float.Parse(txtPBGAmt.Text);
            objPBGInfo.ValidityTime_I = int.Parse(txtValidityMonth.Text);
            objPBGInfo.ValidityDate_D = DateTime.Parse(txtTillDate.Text, cult);
            objPBGInfo.AgreementStatus_V = rbGAgreement.SelectedItem.Value.ToString();
            objPBGInfo.Remark_V = txtRemark.Text;
            objPBGInfo.UserId_I =Convert.ToInt32(Session["UserID"]);

            if (Request.QueryString["ID"] != null)
            {
                objPBGInfo.PBGTrId_I = int.Parse(Request.QueryString["ID"].ToString());
            }
            else
            {
                objPBGInfo.PBGTrId_I = 0;
            }
            int i = objPBGInfo.InsertUpdate();

            if (i > 0)
            {
                if (Request.QueryString["ID"] != null)
                {
                    Response.Redirect("ViewPBGInfo.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    obCommonFuction.EmptyTextBoxes(this);
                    lblLOIAddress.Text = "";
                    lblLOIDt.Text = "";
                    lblVendorName.Text = "";
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sorry Record Not Updated.');</script>");
            }

        }
    }
}

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
using MPTBCBussinessLayer;
using System.IO;

public partial class Paper_VendorAgreement : System.Web.UI.Page
{
    string path, FileName;
    DPT_AgreementDtl objAgreementDtl = null;
    DataSet ds;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCurrentDt.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                AgreementDetailFill();// 49117 ,49179,49227,49217-49225
            }
        }

    }

    public void AgreementDetailFill()
    {
        objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));
        ddlLOIDetails.DataSource = objAgreementDtl.LOIDtlFill();
        ddlLOIDetails.DataTextField = "LOINo_V";
        ddlLOIDetails.DataValueField = "LOITrId_I";
        ddlLOIDetails.DataBind();
        ddlLOIDetails.Items.Insert(0, "Select");
        if (Request.QueryString["LOITrId"] != null)
        {
            ddlLOIDetails.Enabled = false;
            ddlLOIDetails.ClearSelection();
            ddlLOIDetails.Items.FindByValue(Request.QueryString["LOITrId"].ToString()).Selected = true;
            LOIDetailsFill();

            objAgreementDtl.AgreementTrId_I = int.Parse(Request.QueryString["ID"].ToString());

            ds = objAgreementDtl.AgreeMentPBGDetailsForUpdate();
            if (ds.Tables[0].Rows.Count > 0)
            {

                DateTime dat = new DateTime();
               
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["AgreementDate_D"].ToString());
         
                txtAgreementDate.Text = dat.ToString("dd/MM/yyyy");

                txtAgreementNo.Text = ds.Tables[0].Rows[0]["AgreementNo_V"].ToString();
                hdnFile.Value = ds.Tables[0].Rows[0]["AgreementFile_V"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
            }

        }
    }

    protected void ddlLOIDetails_Init(object sender, EventArgs e)
    {
        objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));
        ddlLOIDetails.DataSource = objAgreementDtl.LOIDtlFill();
        ddlLOIDetails.DataTextField = "LOINo_V";
        ddlLOIDetails.DataValueField = "LOITrId_I";
        ddlLOIDetails.DataBind();
        ddlLOIDetails.Items.Insert(0, "Select");
    }
    public void LOIDetailsFill()
    {
        if (ddlLOIDetails.SelectedItem.Text != "Select")
        {

            objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));
            objAgreementDtl.LOITrId_I = int.Parse(ddlLOIDetails.SelectedValue.ToString());
            ds = objAgreementDtl.PBGDtlFill();
            if (ds.Tables[0].Rows.Count > 0)
            {

                lblLOIAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();

                lblLOITO.Text = ds.Tables[0].Rows[0]["PaperVendorName_V"].ToString();
                lblPBGAmt.Text = ds.Tables[0].Rows[0]["PBGAmount"].ToString();
                lblPBGMode.Text = ds.Tables[0].Rows[0]["PBGType_V"].ToString();
                lblPBGNo.Text = ds.Tables[0].Rows[0]["PBGNo_V"].ToString();
                lblValidityDays.Text = ds.Tables[0].Rows[0]["ValidityTime_I"].ToString();
                DateTime dat = new DateTime();

                dat = DateTime.Parse(ds.Tables[0].Rows[0]["LOIDate_D"].ToString());

                lblLOIDate.Text = dat.ToString("dd/MM/yyyy");

            }
        }
    }
    protected void ddlLOIDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIDetailsFill();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlLOIDetails.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select LOI No.');</script>");
        }
        else
        {
            path = Server.MapPath("~/PaperUploadedFile/");
            if (FileUpload1.HasFile)
            {
                string Ext = Path.GetExtension(FileUpload1.FileName);
                FileName = "Agr" + txtAgreementNo.Text + System.DateTime.Now.ToString("ddMMyyyymmhhss") + Ext;
                FileUpload1.PostedFile.SaveAs(path + FileName);
            }
            else
            {
                FileName = hdnFile.Value.ToString();
            }
            objAgreementDtl = new DPT_AgreementDtl(Convert.ToInt32(Session["UserID"]));
            objAgreementDtl.LOITrId_I = int.Parse(ddlLOIDetails.SelectedItem.Value.ToString());
            objAgreementDtl.AgreementNo_V = txtAgreementNo.Text.Trim();
            objAgreementDtl.AgreementDate_D = DateTime.Parse(txtAgreementDate.Text, cult);
            objAgreementDtl.AgreementFile_V = FileName.ToString();
            objAgreementDtl.Remark_V = txtRemark.Text;
            objAgreementDtl.UserId_I = Convert.ToInt32(Session["UserID"]);;

            if (Request.QueryString["ID"] != null)
            {
                objAgreementDtl.AgreementTrId_I = int.Parse(Request.QueryString["ID"].ToString());
            }
            else
            {
                objAgreementDtl.AgreementTrId_I = 0;
            }
            int i = objAgreementDtl.InsertUpdate();

            if (i > 0)
            {
                if (Request.QueryString["ID"] != null)
                {
                    Response.Redirect("ViewVendorAgreement.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    obCommonFuction.EmptyTextBoxes(this); Response.Redirect("ViewVendorAgreement.aspx");
                    lblLOIAddress.Text = "";
                    lblLOIDate.Text = "";
                    lblLOITO.Text = "";
                    lblPBGAmt.Text = "";
                    lblPBGMode.Text = "";
                    lblPBGNo.Text = "";
                    lblValidityDays.Text = "";

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sorry Record Not Updated.');</script>");
            }

        }
    }
}
 
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
using System.IO;

public partial class Paper_VendorLOI : System.Web.UI.Page
{
    DataSet ds;
    DPT_LOIDetails objLOIDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string path, FileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblCurrentDt.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        if (!Page.IsPostBack)
        {
           // Session["UserID"] = 1;
            if (Request.QueryString["ID"] != null)
            { 
            //TndId
            
            }
        }
    }
    public void TenderAllFill()
    {
        objLOIDetails = new DPT_LOIDetails(Convert.ToInt32(Session["UserID"]));
        ddlTenderNo.DataSource = objLOIDetails.TenderFill();
        ddlTenderNo.DataTextField = "TenderNo_V";
        ddlTenderNo.DataValueField = "TenderTrId_I";
        ddlTenderNo.DataBind();
        ddlTenderNo.Items.Insert(0, "Select");
        if (Request.QueryString["TndId"] != null)
        {
            ddlTenderNo.Enabled = false;
            ddlVendorLOITo.Enabled = false;
            ddlTenderNo.Items.FindByValue(Request.QueryString["TndId"].ToString()).Selected = true;
            TenderFieldFill();
           objLOIDetails.LOITrId_I=int.Parse(Request.QueryString["ID"].ToString());

           ds = objLOIDetails.LOIDtlFill();
           if (ds.Tables[0].Rows.Count > 0)
           {
               txtLOINo.Text = ds.Tables[0].Rows[0]["LOINo_V"].ToString();
               lblCurrentDt.Text = ds.Tables[0].Rows[0]["LOIDate_D"].ToString();
               txtPBGAmt.Text = ds.Tables[0].Rows[0]["PBGAmount_N"].ToString();
               txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
               hdnFile.Value = ds.Tables[0].Rows[0]["LOIFile_V"].ToString();
           }

        }
    }
    protected void ddlTenderNo_Init(object sender, EventArgs e)
    {
        TenderAllFill();
    }
    public void TenderFieldFill()
    {
        objLOIDetails = new DPT_LOIDetails(Convert.ToInt32(Session["UserID"]));
        objLOIDetails.TenderTrId_I = int.Parse(ddlTenderNo.SelectedItem.Value.ToString());
        ddlVendorLOITo.DataSource = objLOIDetails.VenderFill();
        ddlVendorLOITo.DataTextField = "PaperVendorName_V";
        ddlVendorLOITo.DataValueField = "Venderid_I";
        ddlVendorLOITo.DataBind();
        objLOIDetails.PaperVendorTrId_I = int.Parse(ddlVendorLOITo.SelectedItem.Value.ToString());
        ds = objLOIDetails.VenderDtlFill();

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();
            txtContactNo.Text = ds.Tables[0].Rows[0]["PaperVendorContactNo_V"].ToString();
            txtContactPerson.Text = ds.Tables[0].Rows[0]["ContactPerson_V"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["PaperVendorEmail_V"].ToString();
            txtVatTaxNo.Text = ds.Tables[0].Rows[0]["PaperVendorVATTaxNo_V"].ToString();
        }
    }
    protected void ddlTenderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        TenderFieldFill();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlTenderNo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
        }
        else if (ddlVendorLOITo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select company Name.');</script>");
        }
        else
        {
            path = Server.MapPath("~/PaperUploadedFile/");
            if (fileUp1.HasFile)
            {
                string Ext = Path.GetExtension(fileUp1.FileName);
                FileName = "LOI" + ddlTenderNo.SelectedItem.Text + System.DateTime.Now.ToString("ddMMyyyymmhhss") + Ext;
                fileUp1.PostedFile.SaveAs(path + FileName);
            }
            else
            {
                FileName = hdnFile.Value.ToString();
            }


            objLOIDetails = new DPT_LOIDetails(Convert.ToInt32(Session["UserID"]));
            objLOIDetails.TenderTrId_I = int.Parse(ddlTenderNo.SelectedItem.Value.ToString());
            objLOIDetails.PaperVendorTrId_I = int.Parse(ddlVendorLOITo.SelectedItem.Value.ToString());
            objLOIDetails.LOINo_V = txtLOINo.Text;
            objLOIDetails.PBGAmount_N = float.Parse(txtPBGAmt.Text);
            objLOIDetails.LOIFile_V = FileName;
            objLOIDetails.UserId_I = Convert.ToInt32(Session["UserID"]);;
            objLOIDetails.Remark_V = txtRemark.Text.Trim();


            if (Request.QueryString["ID"] != null)
            {
                objLOIDetails.LOITrId_I = int.Parse(Request.QueryString["ID"].ToString());
            }
            else
            {
                objLOIDetails.LOITrId_I = 0;
            }
            int i = objLOIDetails.InsertUpdate();
            if (i > 0)
            {
                if (Request.QueryString["ID"] != null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    Response.Redirect("ViewVendorLOI.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                }
                obCommonFuction.EmptyTextBoxes(this);
                //   Clear();
            }
        }

    }
}

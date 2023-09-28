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

public partial class Paper_TenderRelatedInformation : System.Web.UI.Page
{
    DataSet ds;
    DepoTenderInfo objTenderInfo = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string path, FileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                GridFillLoad();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        path = Server.MapPath("~/DepoUploadedFile/");
        if (fileUp1.HasFile)
        {
            string Ext = Path.GetExtension(fileUp1.FileName);
            FileName = "DPT" + txtRFPNo.Text + System.DateTime.Now.ToString("ddMMyyyymmhhss") + Ext;
            fileUp1.PostedFile.SaveAs(path + FileName);
        }
        else
        {
            FileName = hdnFile.Value.ToString();
        }

        objTenderInfo = new DepoTenderInfo(Convert.ToInt32(Session["UserID"]));
        objTenderInfo.EMDAmount_N = float.Parse(txtEMD.Text.Trim());
        objTenderInfo.WorkName_V = txtNameOfWork.Text.Trim();
        objTenderInfo.TenderDate_D = Convert.ToDateTime(txtDate.Text.Trim(), cult);
        objTenderInfo.TenderDescription_V = txtDetails.Text;
        objTenderInfo.TenderFees_N = float.Parse(txtTenderFee.Text);
        objTenderInfo.TenderFile_V = FileName;
        objTenderInfo.TenderNo_V = txtRFPNo.Text.Trim();
        objTenderInfo.TenderSubmissionDate_D = Convert.ToDateTime(txtTenderSubDt.Text.Trim(), cult);
        objTenderInfo.TenderType_V = ddlTenderType.SelectedItem.Text;
        objTenderInfo.UserId_I = Convert.ToInt32(Session["UserID"]);;
        objTenderInfo.Remark_V = txtRemark.Text.Trim();


        if (Request.QueryString["ID"] != null)
        {
            objTenderInfo.TenderTrId_I = int.Parse(Request.QueryString["ID"].ToString());
        }
        else
        {
            objTenderInfo.TenderTrId_I = 0;
        }
        int i = objTenderInfo.InsertUpdate();
        if (i > 0)
        {
            if (Request.QueryString["ID"] != null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
            }
            obCommonFuction.EmptyTextBoxes(this);
            //   Clear();
            Response.Redirect("ViewTenderInfo.aspx");
        }


    }
    public void GridFillLoad()
    {
        try
        {
            objTenderInfo = new DepoTenderInfo(Convert.ToInt32(Session["UserID"]));
            objTenderInfo.TenderTrId_I = int.Parse(Request.QueryString["ID"].ToString());
            ds = objTenderInfo.Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime SubDt = new DateTime();

                //
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
                txtDate.Text = dat.ToString("dd/MM/yyyy");
                txtTenderSubDt.Text = SubDt.ToString("dd/MM/yyyy");

                txtDetails.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
                txtEMD.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
                txtNameOfWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
                txtRFPNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
                txtTenderFee.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();
                
                hdnFile.Value = ds.Tables[0].Rows[0]["TenderFile_V"].ToString();

                ddlTenderType.ClearSelection();
                ddlTenderType.Items.FindByText(ds.Tables[0].Rows[0]["TenderType_V"].ToString()).Selected = true;
            }
        }
        catch { }

    }

  
}

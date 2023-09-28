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
using MPTBCBussinessLayer.DistributionB;
using System.Globalization;
using System.IO;

public partial class Paper_TenderRelatedInformation : System.Web.UI.Page
{
    APIProcedure objApi = new APIProcedure();
    DataSet ds;
    InsuranceTenderInfo objInsuranceTender = null;
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
        DateTime DteCheck ;
        string Date = "", FeeDate = "";
        if (txtDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtDate.Text, cult);            
            }
            catch { Date = "NoDate"; }
        }
        if (txtTenderSubDt.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtTenderSubDt.Text, cult);
            }
            catch { FeeDate = "NoFeeDate"; }
        }

        if (Date != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct tender Date.');</script>");
        }
        else if (FeeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct tender submission Date.');</script>");
        }
          else if (txtDetails.Text.ToString().Length > 240)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 240 charecter in detail text box.');</script>");

        }
        else if (txtRemark.Text.ToString().Length > 149)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 150 charecter in remark text box.');</script>");

        }
        else
        {

            string ImgStatus = "";


            if (fileUp1.FileName == "")
            {
                ImgStatus = "Ok";
                FileName = hdnFile.Value.ToString();
            }
            else
            {
                ImgStatus = objApi.uploadFile(fileUp1, "PaperUploadedFile", 1000);
                if (ImgStatus == "Ok")
                {
                    FileName = objApi.FullFileName;
                }
            }

            if (ImgStatus == "Ok")
            {
                objInsuranceTender = new InsuranceTenderInfo();
                objInsuranceTender.EMDAmount_N = float.Parse(txtEMD.Text.Trim());
                objInsuranceTender.WorkName_V = txtNameOfWork.Text.Trim();
                objInsuranceTender.TenderDate_D = Convert.ToDateTime(txtDate.Text.Trim(), cult);
                objInsuranceTender.TenderDescription_V = txtDetails.Text;
                objInsuranceTender.TenderFees_N = float.Parse(txtTenderFee.Text);
                objInsuranceTender.TenderFile_V = FileName;
                objInsuranceTender.TenderNo_V = txtRFPNo.Text.Trim();
                objInsuranceTender.TenderSubmissionDate_D = Convert.ToDateTime(txtTenderSubDt.Text.Trim(), cult);
                objInsuranceTender.TenderType_V = ddlTenderType.SelectedItem.Text;
                objInsuranceTender.UserId_I = int.Parse(Session["UserID"].ToString());
                objInsuranceTender.Remark_V = txtRemark.Text.Trim();


                if (Request.QueryString["ID"] != null)
                {
                    objInsuranceTender.TenderTrId_I = int.Parse(Request.QueryString["ID"].ToString());
                }
                else
                {
                    objInsuranceTender.TenderTrId_I = 0;
                }
                try
                {
                    int i = objInsuranceTender.InsertUpdate();
                    if (i > 0)
                    {
                        if (Request.QueryString["ID"] != null)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                            Response.Redirect("ViewPPR_005_TInfo.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                        }
                        obCommonFuction.EmptyTextBoxes(this);
                        lblMsg.Text = "";
                        //   Clear();
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender No Already Exist.');</script>"); }
            }
            else
            {
                lblMsg.Text = ImgStatus.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objInsuranceTender = new InsuranceTenderInfo();
            objInsuranceTender.TenderTrId_I = int.Parse(Request.QueryString["ID"].ToString());
            ds = objInsuranceTender.Select();
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

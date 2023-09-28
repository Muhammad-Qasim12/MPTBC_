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
public partial class Paper_PaperMaster : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    PPR_PaperMaster ObjPaperMaster = null;
    DataSet ds;
    APIProcedure objdb = new APIProcedure();
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

    public void GridFillLoad()
    {
        try
        {
            
            ObjPaperMaster = new PPR_PaperMaster();
            ObjPaperMaster.PaperTrId_I = int.Parse(objdb.Decrypt( Request.QueryString["ID"]));
            ds = ObjPaperMaster.Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtQuality.Text = ds.Tables[0].Rows[0]["PaperSize_V"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();

                txtSize.Text = ds.Tables[0].Rows[0]["GSM"].ToString();
                txtSheetWt.Text = ds.Tables[0].Rows[0]["PerSheetWt"].ToString();

                PaperTypeFill();                
                ddlPaperType.ClearSelection();
                ddlPaperType.Items.FindByValue(ds.Tables[0].Rows[0]["PaperType_I"].ToString()).Selected = true;
                
                QualityFill();
                ddlPaperSize.ClearSelection();
                ddlPaperSize.Items.FindByValue(ds.Tables[0].Rows[0]["PaperQuality_V"].ToString()).Selected = true;
                
                ddlPaperCategory.ClearSelection();
                ddlPaperCategory.Items.FindByText(ds.Tables[0].Rows[0]["PaperCategory"].ToString()).Selected = true;

                ClientScript.RegisterStartupScript(this.GetType(), "Post", "<script type='text/javascript'>OnchangeName();</script>");
               //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>ss();</script>");


            }
        }
        catch { }
    }
  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtRemark.Text.ToString().Length > 99)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 100 charecter in remark text box.');</script>");

            }
            else
            {

                ObjPaperMaster = new PPR_PaperMaster();
                if (Request.QueryString["ID"] != null)
                {
                    ObjPaperMaster.PaperTrId_I = int.Parse(objdb.Decrypt( Request.QueryString["ID"].ToString()));
                }
                else
                {
                    ObjPaperMaster.PaperTrId_I = 0;
                }
                ObjPaperMaster.PaperQuality_V = ddlPaperSize.SelectedItem.Value.Trim();
                ObjPaperMaster.PaperSize_V = txtQuality.Text.Trim();
                ObjPaperMaster.GSM = int.Parse(txtSize.Text.Trim());

                ObjPaperMaster.PaperType_I = int.Parse(ddlPaperType.SelectedValue.ToString());
                ObjPaperMaster.UserId_I = int.Parse(Session["UserID"].ToString());
                ObjPaperMaster.Remark_V = txtRemark.Text.Trim();
                ObjPaperMaster.PaperCategory = ddlPaperCategory.SelectedItem.Text.Trim();
                try
                {
                    ObjPaperMaster.PerSheetWt = float.Parse(txtSheetWt.Text);
                }
                catch { ObjPaperMaster.PerSheetWt = 0; }
                int i = ObjPaperMaster.InsertUpdate();
                if (i > 0)
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        Response.Redirect("ViewPaperMaster.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    }

                    obCommonFuction.EmptyTextBoxes(this);

                }
            }

        }
        catch { }
    }

    protected void ddlPaperSize_Init(object sender, EventArgs e)
    {
        ddlPaperSize.DataSource = string.Empty;        
        ddlPaperSize.DataBind();
        ddlPaperSize.Items.Insert(0, "Select");
    }
    public void PaperTypeFill()
    {
        ObjPaperMaster = new PPR_PaperMaster();
        ddlPaperType.DataSource = ObjPaperMaster.PaperTypeFill();
        ddlPaperType.DataValueField = "PaperType_Id";
        ddlPaperType.DataTextField = "PaperType";
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "Select");
    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperTypeFill();        
    }
    public void QualityFill()
    {
        if (ddlPaperType.SelectedItem.Text != "Select")
        {
            ObjPaperMaster = new PPR_PaperMaster();
            ObjPaperMaster.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
            ddlPaperSize.DataSource = ObjPaperMaster.QualityTypeFill();
            ddlPaperSize.DataValueField = "Qualifyid_I";
            ddlPaperSize.DataTextField = "QualifyType";
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "Select");
        }
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        QualityFill();
    }
}

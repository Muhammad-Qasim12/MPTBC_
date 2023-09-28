using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_DPT008_OtherStockDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = null;
    otherStockOpeningDetails obotherStockOpeningDetails = null;
    WareHouseMaster obWareHouseMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                obWareHouseMaster = new WareHouseMaster();
                obWareHouseMaster.WareHouseID = 0;
                obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserId"]);
                DataSet ds = obWareHouseMaster.Select();
                ddlWarehouse.DataTextField = "WareHouseName_V";
                ddlWarehouse.DataValueField = "WareHouseID_I";
                ddlWarehouse.DataSource = ds.Tables[0];
                ddlWarehouse.DataBind();
                ddlWarehouse.Items.Insert(0, "सलेक्ट करे ");
                obCommonFuction = new CommonFuction();
                txtOtherBookName.DataSource = obCommonFuction.FillDatasetByProc("call USP_GENGetOtherStockTitleList()");
                txtOtherBookName.DataTextField = "SubTitles";
                txtOtherBookName.DataValueField = "SubTitleID_I";
                txtOtherBookName.DataBind();
                txtOtherBookName.Items.Insert(0, "सलेक्ट करे ");
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }
                
                

            }
            catch { }
            finally { obCommonFuction = null; }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        try
        {

            obotherStockOpeningDetails = new otherStockOpeningDetails ();
            obotherStockOpeningDetails.OtherBookName_V = Convert.ToString(txtOtherBookName.SelectedValue);
            obotherStockOpeningDetails.PerBandalNo_I = Convert.ToInt32(txtPerBandal.Text);
            obotherStockOpeningDetails.TotalBandal_I = Convert.ToInt32(txttotalBandal.Text );
            obotherStockOpeningDetails.TotalNo_I = Convert.ToInt32(txtopen.Text);
            obotherStockOpeningDetails.WareHouseID_I1 = Convert.ToInt32(ddlWarehouse.SelectedValue);
            obotherStockOpeningDetails.TransID_I = 0;
            if (HiddenField1.Value != "")
            {
                obotherStockOpeningDetails.TransID_I = 1;
                obotherStockOpeningDetails.DOtherStockID_I = Convert.ToInt32(HiddenField1.Value);
            }
            obotherStockOpeningDetails.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            obotherStockOpeningDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            obotherStockOpeningDetails.DepoID_I = Convert.ToInt32(Session["UserID"]);
            obotherStockOpeningDetails.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);
        }
        catch { }
        finally
        {
            obotherStockOpeningDetails = null;
        }
        Response.Redirect("VIEW_DPT008.aspx");
        
    }
    public void showdata(string ID)
    {
        APIProcedure api = new APIProcedure();
        obotherStockOpeningDetails = new otherStockOpeningDetails();
        obotherStockOpeningDetails.DOtherStockID_I = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"]));
        DataSet obDataSet = obotherStockOpeningDetails.Select();
        HiddenField1.Value = (api.Decrypt(Request.QueryString["ID"]));
        ddlWarehouse.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["WareHouseID_I"]);
        txtOtherBookName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["OtherBookName_V"]);
        txtPerBandal.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PerBandalNo_I"]);
        txttotalBandal.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TotalBandal_I"]);
        txtopen.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TotalNo_I"]);
        
    }
}
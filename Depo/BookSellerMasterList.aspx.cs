using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
public partial class Depo_BookSellerMasterList : System.Web.UI.Page
{
    BooksellerMaster obBooksellerMaster = null;
    CommonFuction obCommonFuction = null;
    DistrictMaster obDistrictMaster = new DistrictMaster();
    public APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
            DataSet dsdist = obDistrictMaster.Select();
            ddlDistrict.DataTextField = "District_Name_Hindi_V";
            ddlDistrict.DataValueField = "DistrictTrno_I";
            ddlDistrict.DataSource = dsdist.Tables[0];
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, "Select..");
        }
    }
    public void FillData()
    {
        try
        {
            
            obBooksellerMaster = new BooksellerMaster();
            obBooksellerMaster.DBooksellerregistration_I = 0;
            obBooksellerMaster.UserID_I =Convert.ToInt32(Session["UserID"]);
            GrdBookSeleer.DataSource = obBooksellerMaster.Select();
            GrdBookSeleer.DataBind();


        }
        catch
        {
        }

    }
    protected void GrdBookSeleer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obBooksellerMaster = new BooksellerMaster();
        obBooksellerMaster.Delete(Convert.ToInt32(GrdBookSeleer.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }
    protected void GrdBookSeleer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdBookSeleer.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookSellerMaster.aspx");
    }
    protected void GrdBookSeleer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {
            obBooksellerMaster = new BooksellerMaster();
            obBooksellerMaster.Delete(Convert.ToInt32(e.CommandArgument));
            FillData();
            Response.Write("<script>alert('Record has deleted');</script>");
        }
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        obBooksellerMaster = new BooksellerMaster();
        obBooksellerMaster.DBooksellerregistration_I = 0;
        obBooksellerMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
        DataSet aa = obBooksellerMaster.Select();
        aa.Tables[0].DefaultView.RowFilter = "DistrictID_I ='" + ddlDistrict.SelectedItem.Value + "'";
        GrdBookSeleer.DataSource = aa;
        GrdBookSeleer.DataBind();
    }
    //
    protected void btClick(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //txtPerbundlebook
        GridViewRow grdrow = (GridViewRow)btn.NamingContainer;
        string btID = btn.CommandArgument;
        Response.Redirect("RenewalFrom.aspx?ID=" + btID + "&Name=" + ((HiddenField)grdrow.FindControl("HiddenField1")).Value + "");
    }
    protected void btClick1(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //txtPerbundlebook
        GridViewRow grdrow = (GridViewRow)btn.NamingContainer;
        string btID = btn.CommandArgument;
        Response.Redirect("RenualFromPrint.aspx?ID=" + btID + "");
    }
    protected void btClick12(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        //txtPerbundlebook
        GridViewRow grdrow = (GridViewRow)btn.NamingContainer;
        string btID = btn.CommandArgument;
        Response.Redirect("PrinReg.aspx?ID=" + btID + "");
    }
   // 
}
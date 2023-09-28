using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_VIEW_DPT006 : System.Web.UI.Page
{
    AdvanceDetails obAdvanceDetails = null;
   public  APIProcedure api = new APIProcedure();
    //  CommonFuction obCommonFuction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
            
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void lnkClick(object sender, EventArgs e)
    {
        LinkButton lnkClick = (LinkButton)(sender);
        CommonFuction objC = new CommonFuction();
        GrdAdvanceDetails.DataSource = objC.FillDatasetByProc("call USPDetails(" + lnkClick.CommandArgument + ","+Session["UserID"]+")");
        GrdAdvanceDetails.DataBind();
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        //obBookSellerDemand.User_ID_I = Convert.ToInt32(lnkClick.CommandArgument);

    }
    public void FillData()
    {
        try
        {
              CommonFuction objC = new CommonFuction();
              GridView1.DataSource = objC.FillDatasetByProc("call USP_DptAdvance("+Session["userID"].ToString ()+")");
              GridView1.DataBind();
            
            //obAdvanceDetails = new AdvanceDetails ();
            //obAdvanceDetails.AdvanceDetailsID  = 0;
            //obAdvanceDetails.UserID = Convert.ToInt32(Session["UserID"]);
            //GrdAdvanceDetails.DataSource = obAdvanceDetails.Select();
            //GrdAdvanceDetails.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdAdvanceDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obAdvanceDetails = new AdvanceDetails();
        obAdvanceDetails.Delete(Convert.ToInt32(GrdAdvanceDetails.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }
    protected void GrdAdvanceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdAdvanceDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT006_AdvanceDetails.aspx");
    }
    protected void GrdAdvanceDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {
            obAdvanceDetails = new AdvanceDetails();
            obAdvanceDetails.Delete(Convert.ToInt32(e.CommandArgument));
            FillData();
            Response.Write("<script>alert('Record has deleted');</script>");
        }
    }
    protected void btnClick(object sender, EventArgs e)
    {
        LinkButton btns = (LinkButton)sender;

        GridViewRow grd = (GridViewRow)(btns.NamingContainer);

        HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
        Response.Redirect("DPT006_AdvanceDetails.aspx?ID=" + api.Encrypt(hd.Value) + "");
        //Response.Redirect("CreateChallan.aspx?Cid=" + new APIProcedure().Encrypt(hd.Value) + "");

    }
    // <a href="DPT006_AdvanceDetails.aspx?ID=<%#api.Encrypt(Eval("AdvanceDetailsID").ToString ()) %>">डाटा में सुधार करे / Edit</a>
}
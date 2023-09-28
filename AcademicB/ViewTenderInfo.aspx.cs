using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Globalization;
using MPTBCBussinessLayer.AcademicB;

public partial class AcademicB_ViewTenderInfo : System.Web.UI.Page
{
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = null;
    TenderDetails obTenderDetails = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //FillData();
            }
        }

        catch { }
        finally { }
    }
    public void FillData()
    {
        try
        {
            obTenderDetails = new TenderDetails();
            obTenderDetails.TenderId_I = 0;
            //obTenderDetails.TenderId_I = Convert.ToInt32(Session["TenderId_I"]);
            GrdTenderDetails.DataSource = obTenderDetails.Select();
            GrdTenderDetails.DataBind();

        }
        catch
        {
        }
        finally
        {
            obTenderDetails = null;
        }
    }
    protected void GrdTenderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obTenderDetails = new TenderDetails();
        string str = GrdTenderDetails.DataKeys[e.RowIndex].Value.ToString();
        obTenderDetails.Delete(Convert.ToInt32(str));
        FillData();
    }
    protected void GrdTenderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTenderDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenderDetailsB.aspx");
    }
    protected void GrdTenderDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdTenderDetails_RowDataBound(object sender, GridViewRowEventArgs e) 
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            int TenEval = 0;
            TenEval = Convert.ToInt32(((HiddenField)e.Row.FindControl("HdnTenEval")).Value);

            if (TenEval > 0)
            {
                //((HyperLink)e.Row.FindControl("HypTenderid")).Enabled = false;
                //((HyperLink)e.Row.FindControl("HypTenderid")).ForeColor = System.Drawing.Color.Red;

                ((LinkButton)e.Row.FindControl("pnlTenderid")).Enabled = false;
               // ((Panel)e.Row.FindControl("pnlTenderid")).Style.Add("z-index", "1200");

            }

            

        }
    
    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_VIEW_DPT013 : System.Web.UI.Page
{
    CountingDetails obCountingDetails = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    public void fillgrd()
    {
        obCountingDetails = new CountingDetails();
        obCountingDetails.PinterID_I = Convert.ToInt32(Session["UserID"]); ;
      DataSet ds= obCountingDetails.FillHundredPerPriterDetails();
      grnMain.DataSource = ds.Tables[0];
      grnMain.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT013_HundredPer.aspx");
    }
    protected void grnMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grnMain.PageIndex = e.NewPageIndex;
        fillgrd();
    }
    protected void btnSave1_Click(object sender, EventArgs e)
    {
        Button TextBox = (Button)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
        Response.Redirect("DPT013_HundredPer.aspx?ID="+hd.Value+"");
        
    }
    protected void btnSave2_Click(object sender, EventArgs e)
    {
        //Button TextBox = (Button)sender;

        //GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        //HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");

        CommonFuction obj = new CommonFuction();

        DataSet st = obj.FillDatasetByProc("call USP_GetPrinterCount(" + Session["UserID"] + ",'" + DdlACYear.SelectedValue + "')");
        //if (Convert.ToInt32 (st.Tables[0].Rows[0]["TotalPrinert"])==Convert.ToInt32 (st.Tables[1].Rows[0]["sd"]))
        //{ 
        obj.FillDatasetByProc("call USP_UPDateTwentyPercentage("+Session["UserID"]+")");
        fillgrd();
            Label1.Text ="100% गणना रसीद जारी हो चुकी हैं |";
        //}
        //else 
        //{
        //    Label1.Text ="अभी  सभी मुद्रको की १००% गणना रसीद जारी नही हुई हैं, सभी मुद्रको की १००% गणना रसीद एक साथ ही भेजी जा सकेगी";

        //}
    }
}
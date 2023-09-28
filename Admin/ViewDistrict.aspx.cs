using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Admin_ViewDistrict : System.Web.UI.Page
{
    DistrictMaster obDistrictMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            FillData();
        }
    }
    public void FillData()
    {
        try
        {
            obDistrictMaster = new DistrictMaster ();
            obDistrictMaster.DistrictTrno_I = 0;
          
            GrdDItrict.DataSource = obDistrictMaster.Select();
            GrdDItrict.DataBind();

        }
        catch
        {
        }
        finally { }
    }
    protected void GrdDItrict_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obDistrictMaster = new DistrictMaster();
            obDistrictMaster.Delete(Convert.ToInt32(GrdDItrict.DataKeys[e.RowIndex].Value.ToString()));
            FillData();
        }
        catch
        {

            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Can not delete record";
        }
    }
    protected void GrdDItrict_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDItrict.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DistrictMaster.aspx");
    }
}
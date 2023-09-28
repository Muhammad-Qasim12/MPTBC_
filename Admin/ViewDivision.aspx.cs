using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Admin_ViewDivision : System.Web.UI.Page
{
    
    DivisionMaster obDivisionMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }

    public void FillData()
    {
        try
        {
            obDivisionMaster = new DivisionMaster();
            obDivisionMaster.DivisionTrno_I = 0;

            GrdDivision.DataSource = obDivisionMaster.Select();
            GrdDivision.DataBind();

        }
        catch
        {
        }
        finally { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DivisionMaster.aspx");
    }
   
    protected void GrdDivision_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDivision.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void GrdDivision_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obDivisionMaster = new DivisionMaster();
        obDivisionMaster.Delete(Convert.ToInt32(GrdDivision.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }
}
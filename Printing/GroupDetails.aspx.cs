using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;


public partial class Printing_GroupDetails : System.Web.UI.Page
{

    PRI_GroupCreation objGrp = null;
    CommonFuction obCommonFunction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFunction.GetFinYear();
            loadGRoupGrd();
        }
    }


    public void loadGRoupGrd()
    {
        objGrp = new PRI_GroupCreation();
        try
        {
            objGrp.GrpID_I = 0;
            grdGroupDetails.DataSource = objGrp.GroupMasterLoad();
            grdGroupDetails.DataBind();

        }


        catch (Exception ex) { }
        finally { objGrp = null; }
    }
    public void loadGRoupGrdFY()
    {
        objGrp = new PRI_GroupCreation();
        try
        {
            objGrp.AcdYear = Convert.ToString ( DdlACYear.SelectedValue  );
            grdGroupDetails.DataSource = objGrp.GroupMasterLoadFYYear();
            grdGroupDetails.DataBind();

        }


        catch (Exception ex) { }
        finally { objGrp = null; }
    }

    protected void btnAdd_Click(object sender, EventArgs e) 
    {
        Response.Redirect("GROUPCREATIONTEST.aspx");
    }
    
    protected void grdGroupDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdGroupDetails.PageIndex = e.NewPageIndex;
        loadGRoupGrdFY();
    
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadGRoupGrdFY();
    }
    protected void grdGroupDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdGroupDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            objGrp = new PRI_GroupCreation();
            string str = grdGroupDetails.DataKeys[e.RowIndex].Value.ToString();
            string str1=  Convert.ToString ( objGrp.GroupDetailsdELETE(Convert.ToInt32(str)));
            lblmsg.Text = str1;
            loadGRoupGrdFY();
        }
        catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Check Your Data.');</script>"); }
        finally { }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {

        objGrp = new PRI_GroupCreation();

        try
        {
            objGrp.GroupNO_V = Convert.ToString(txtSearch.Text);
            objGrp.AcdYear = Convert.ToString(DdlACYear.SelectedValue);
            grdGroupDetails.DataSource = objGrp.GroupMasterLoadFYYearSearch();
            grdGroupDetails.DataBind();
        }

        catch (Exception ex) { }
        finally { objGrp = null; }

    
    }


    
}
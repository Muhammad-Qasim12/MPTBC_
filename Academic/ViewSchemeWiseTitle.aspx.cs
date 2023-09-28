using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Academic_ViewSchemeWiseTitle : System.Web.UI.Page
{
    TitleWiseSchemeMapping obTitleWise = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadGrd();
            LoadClass();
        }
    }

    public void LoadGrd()
    {
        obTitleWise = new TitleWiseSchemeMapping();
        try
        {
            obTitleWise.TitleID_I = 0;
            grdTitleWiseSchemeMapping.DataSource = obTitleWise.Select();
            grdTitleWiseSchemeMapping.DataBind();
        }

        catch (Exception ex) { }
        finally { obTitleWise = null; }


    }



    public void LoadClass()
    {
        obTitleWise = new TitleWiseSchemeMapping();
        try
        {
            obTitleWise.ClassTrno_I = 0;
            ddlClass.DataTextField = "Classdet_V";
            ddlClass.DataValueField = "ClassTrno_I";
            
            ddlClass.DataSource = obTitleWise.LoadClass();
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, new ListItem("All", "0"));

        }

        catch (Exception ex) { }
        finally { obTitleWise = null; }


    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("SchemeWiseTitle.aspx");
    }


    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e) 
    {

        LoadGrdClassWise();
    
    }


    public void LoadGrdClassWise() 
    {
       
            obTitleWise = new TitleWiseSchemeMapping();

            try
            {
                obTitleWise.ClassTrno_I = Convert.ToInt32(ddlClass.SelectedValue);
                grdTitleWiseSchemeMapping.DataSource = obTitleWise.LoadTitlesClassWise();
                grdTitleWiseSchemeMapping.DataBind();

            }
            catch (Exception ex) { }
            finally { obTitleWise = null; }


        
    
    }


    protected void grdTitleWiseSchemeMapping_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdTitleWiseSchemeMapping.PageIndex = e.NewPageIndex;

        if (ddlClass.SelectedValue != "0")
        {
            LoadGrdClassWise();
        }

        else 
        {
            LoadGrd();
        }

    }
}
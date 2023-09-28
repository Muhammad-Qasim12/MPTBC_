using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

using System.Data;


public partial class Printing_PRI002_GroupCreation : System.Web.UI.Page
{
    PRI_GroupCreation obGroupCreation = null;
    CommonFuction obCommonFunction = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { Load(); }
    }
    // Function to Load All Controls on Load..
    public void Load()
    {
        LoadCategoryDropdown();
        LoadTitleDropdown();
        LoadClassDropdown();
        LoadBookDescriptionGrd(0);

        LoadGrd();

        btnSaveGroup.Visible = false;

        if (Request.QueryString["Cid"]!=null) 
        {
            loadGRoupGrd();
            btnSaveGroup.Visible = true;
        }

    }


    // function to load Category dropdown
    public void LoadCategoryDropdown()
    {
        obGroupCreation = new PRI_GroupCreation();

        try
        {
            obGroupCreation.CatID_I = 0;

            ddlCategory.DataTextField = "CategoryNo_V";
            ddlCategory.DataValueField = "CatID_I";
            ddlCategory.DataSource = obGroupCreation.LoadCategory();
            ddlCategory.DataBind();

            ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }


    }

    // function to load Title dropdown
    public void LoadTitleDropdown()
    {
        obGroupCreation = new PRI_GroupCreation();

        try
        {
            obGroupCreation.CatID_I = 0;

            ddlTitle.DataTextField = "TitleHindi_V";
            ddlTitle.DataValueField = "TitleID_I";
            ddlTitle.DataSource = obGroupCreation.LoadTitle();
            ddlTitle.DataBind();

            ddlTitle.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }


    }

    // function to load Class dropdown
    public void LoadClassDropdown()
    {
        obGroupCreation = new PRI_GroupCreation();

        try
        {
            obGroupCreation.CatID_I = 0;

            ddlClass.DataTextField = "Classdet_V";
            ddlClass.DataValueField = "ClassTrno_I";
            ddlClass.DataSource = obGroupCreation.LoadClass();
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }


    }

    // function to Load Description Grid
    public void LoadBookDescriptionGrd(int status)
    {
        obGroupCreation = new PRI_GroupCreation();

        try
        { 
     
        
       

            obGroupCreation.AcdYear = obCommonFunction.GetFinYear();

            if (Request.QueryString["Cid"] != null)
            {
                obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else { obGroupCreation.GrpID_I = 0; }


            if (status == 0)
            {
                grdBooksDes.DataSource = obGroupCreation.LoadBooksDetails(0);
                grdBooksDes.DataBind();
            }
            else 
            {
                if (Request.QueryString["Cid"] == null)
                {
                    obGroupCreation.GrpID_I = 1;
                }
                grdGroup.DataSource = obGroupCreation.LoadBooksDetails(1);
                grdGroup.DataBind();
            
            }
            

        }

        catch (Exception ex) { }

        finally { obGroupCreation = null; }

    }

   // function to Load Group Master Details
    public void loadGRoupGrd()
    {
        obGroupCreation = new PRI_GroupCreation();
        DataSet ds = new DataSet();

        try
        {

            obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]); 

           ds = obGroupCreation.GroupMasterLoad();

           if (ds.Tables[0].Rows.Count > 0) 
           {

               ddlCategory.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PrintingCategory_V"]);
               txtGroupNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["groupno_v"]);

               obGroupCreation.IsFinal = 1;
               obGroupCreation.AcdYear = obCommonFunction.GetFinYear(); 
               obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]); 
               grdGroup.DataSource = obGroupCreation.LoadGroupDetails();
               grdGroup.DataBind();
               
           }
           

        }


        catch (Exception ex) { }
        finally { obGroupCreation = null; }
    }

    // function to Save Update the Group Master Information

    public int GroupMasterSaveUpdate()
    {
        obGroupCreation = new PRI_GroupCreation();
        int i = 0;
        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else { obGroupCreation.GrpID_I = 0; }

            obGroupCreation.GroupNO_V = Convert.ToString(txtGroupNo.Text);
            obGroupCreation.PrintingCategory_V = Convert.ToString(ddlCategory.SelectedValue);

            obGroupCreation.DepoID_I = Convert.ToInt32(HdnDepoID_I.Value);

            i = obGroupCreation.GroupMasterSaveUpdate();

        }
        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return i;
    }

    // function to save Update the Group Details

    public int GroupDetailSaveUpdate()
    {
        obGroupCreation = new PRI_GroupCreation();
        int i = 0;
        try
        {

            for (int grdRow = 0; grdRow < grdGroup.Rows.Count; grdRow++)
            {

                obGroupCreation.TitleID_I = Convert.ToInt32(((HiddenField)grdGroup.Rows[grdRow].FindControl("HdnTitleId")).Value);
                obGroupCreation.DelStatus = grdRow;

                if (Request.QueryString["Cid"] != null)
                {
                    obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
                }
                else { obGroupCreation.GrpID_I = Convert.ToInt32(HdnGrpId_I.Value); }



                obGroupCreation.PriDemandId = Convert.ToInt32(((HiddenField)grdGroup.Rows[grdRow].FindControl("HdnPriDemandId")).Value);

                i = obGroupCreation.GroupDetailsSaveUpdate(Convert.ToString(obGroupCreation.GrpID_I));
            }


        }


        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return i;

    }




    // to Change status
    protected void grdBooksDes_RowUpdating(object sender, GridViewUpdateEventArgs e) 
    { 
     obGroupCreation = new PRI_GroupCreation();
        int i = 0;
        try
        {
            obGroupCreation.IsFinal = 1;
            obGroupCreation.PriDemandId = Convert.ToInt32(((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnPriDemandId")).Value);
            obGroupCreation.GrpID_I = 1;
            if (obGroupCreation.PriDemandId != 0)
            {
                i = obGroupCreation.GroupAllotmentStatusChang();
            }

            HdnDepoID_I.Value = ((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnDepoId")).Value;
        }

        catch (Exception Ex) { }

        finally
        {

            obGroupCreation = null;
            LoadBookDescriptionGrd(0);
            LoadBookDescriptionGrd(1);
            if (i > 0)
            {
                btnSaveGroup.Visible = true;
                
            }

        }
    
    
    }

    // to change status of lower grid
    protected void grdGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        obGroupCreation = new PRI_GroupCreation();
        int i = 0;
        try
        {
            obGroupCreation.IsFinal = 0;
            obGroupCreation.PriDemandId = Convert.ToInt32(((HiddenField)grdGroup .Rows[e.RowIndex].FindControl("HdnPriDemandId")).Value);
            obGroupCreation.GrpID_I = 0;
            if (obGroupCreation.PriDemandId != 0)
            {
                i = obGroupCreation.GroupAllotmentStatusChang();
            }


        }

        catch (Exception Ex) { }

        finally
        {

            obGroupCreation = null;
            LoadBookDescriptionGrd(0);
           
                LoadBookDescriptionGrd(1);
            

        }
    
    
    }
  
    // Save Group Information

    protected void btnSaveGroup_Click(object sender, EventArgs e) 
    {
        int i = 0;

        if (grdGroup.Rows.Count > 0)
        {

            i = GroupMasterSaveUpdate();
            if (i > 0)
            {
                HdnGrpId_I.Value = i.ToString();
                GroupDetailSaveUpdate();
            }

        }
        else 
        {
        
        
        }
    }

    PRIN_GroupCreation obGroup = null;


    public void LoadGrd()
    {
        obGroup = new PRIN_GroupCreation();
        try
        {
            obGroup.GroupId = 0;

            ddlGroupId.DataTextField = "GroupName";
            ddlGroupId.DataValueField = "GroupId";

            ddlGroupId.DataSource = obGroup.Select();
            ddlGroupId.DataBind();

            ddlGroupId.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obGroup = null; }

    }


    public void LoadDepots(int GRPiD)
    {
        obGroup = new PRIN_GroupCreation();
        try
        {
            obGroup.GroupId = GRPiD;

            ddlDepoTrno_I.DataTextField = "DepoName_V";
            ddlDepoTrno_I.DataValueField = "DepoTrno_I";

            ddlDepoTrno_I.DataSource = obGroup.DepotListLoadGroup();
            ddlDepoTrno_I.DataBind();

            ddlDepoTrno_I.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obGroup = null; }

    }


    protected void ddlGroupId_SelectedIndexChanged(object sender, EventArgs e) 
    {

        if (ddlGroupId.SelectedValue != "0")
        {
            LoadDepots(Convert.ToInt32(ddlGroupId.SelectedValue));
        }
        else 
        {
        
        }
    }



}
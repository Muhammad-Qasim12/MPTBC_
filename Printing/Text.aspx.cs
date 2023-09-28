using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;


public partial class Printing_Text : System.Web.UI.Page
{
    PRI_GroupCreation obGroupCreation = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { load(); }

    }

    public void load() 
    {
        LoadCategoryDropdown();
        LoadTitleDropdown();
        LoadClassDropdown();

        LoadGrid(0);
        if (Request.QueryString["Cid"] != null)
        {
            LoadGrid(1);

            loadGRoupGrd();

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
            }


        }


        catch (Exception ex) { }
        finally { obGroupCreation = null; }
    }



    public void LoadGrid(int status) 
    {
        obGroupCreation = new PRI_GroupCreation();

        try
        {
            obGroupCreation.AcdYear = "2015-2016";
            obGroupCreation.IsFinal = status;

            if (Request.QueryString["Cid"] != null)
            {
                obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
             
            if (status == 0) 
            {
                obGroupCreation.GrpID_I = 0; 

                grdBooksDes.DataSource = obGroupCreation.LoadGridView();
                grdBooksDes.DataBind();
            
            }
            else
                if (status == 1)
                {
                    DataSet ds = new DataSet();
                    ds = obGroupCreation.LoadGridView();
                    grdGroup.DataSource = ds;
                    grdGroup.DataBind();

                    
                }

        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }
    
    }


    public int GroupDetailsInsert(int GrpID, int TitleID, int PriDemand, int status, int DepoID)
    {
        obGroupCreation = new PRI_GroupCreation();
        int i = 0;
        try
        {
            obGroupCreation.GrpID_I = GrpID;
            obGroupCreation.TitleID_I = TitleID;
            obGroupCreation.PriDemandId = PriDemand;
            obGroupCreation.IsFinal = status;
            obGroupCreation.DepoID_I = DepoID;

            i = obGroupCreation.GroupDetailsInsert();
        
        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return i;
    }
   

    protected void grdBooksDes_RowUpdating(object sender, GridViewUpdateEventArgs e) 
    {
     obGroupCreation = new PRI_GroupCreation();

     try
     {
         obGroupCreation.IsFinal = 1;

         if (Request.QueryString["Cid"] != null)
         {
             obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);
         }
         else
         {
             obGroupCreation.GrpID_I = 0;
         }

         obGroupCreation.PriDemandId = Convert.ToInt32(((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnPriDemandId")).Value);
         if (obGroupCreation.PriDemandId != 0)
         {
             int i = obGroupCreation.GroupAllotmentStatusChang();
         }

         if (Request.QueryString["Cid"] != null) 
         {
             GroupDetailsInsert(Convert.ToInt32(Request.QueryString["Cid"]), Convert.ToInt32(((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnTitleId")).Value), Convert.ToInt32(((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnPriDemandId")).Value), 1, Convert.ToInt32(((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnDepoId")).Value));
         
         }


        

         LoadGrid(0);
         LoadGrid(1);

         HdnDepoID_I.Value = ((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnDepoId")).Value;

         //Response.Write(HdnDepoID_I.Value);
     }

     catch (Exception ex) { }
        finally { obGroupCreation = null; }
    }

    protected void grdGroup_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        obGroupCreation = new PRI_GroupCreation();

        try
        {
            obGroupCreation.IsFinal = 0;

            if (Request.QueryString["Cid"] != null)
            {
                obGroupCreation.GrpID_I = Convert.ToInt32(Request.QueryString["Cid"]);


            }
            else
            {
                obGroupCreation.GrpID_I = 0;
            }

            obGroupCreation.PriDemandId = Convert.ToInt32(((HiddenField)grdGroup.Rows[e.RowIndex].FindControl("HdnPriDemandId")).Value);
            if (obGroupCreation.PriDemandId != 0)
            {
                int i = obGroupCreation.GroupAllotmentStatusChang();
            }

          

            LoadGrid(0);
            LoadGrid(1);

            HdnDepoID_I.Value = ((HiddenField)grdBooksDes.Rows[e.RowIndex].FindControl("HdnDepoId")).Value;
            Response.Write(HdnDepoID_I.Value);
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

            //for (int grdCount = 0; grdCount < grdGroup.Rows.Count; grdCount++) 
            //{
                HdnDepoID_I.Value = ((HiddenField)grdGroup.Rows[0].FindControl("HdnDepoId")).Value;
            
            //}

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


                obGroupCreation.DepoID_I = Convert.ToInt32(((HiddenField)grdGroup.Rows[grdRow].FindControl("HdnDepoId")).Value);
                obGroupCreation.PriDemandId = Convert.ToInt32(((HiddenField)grdGroup.Rows[grdRow].FindControl("HdnPriDemandId")).Value);

                i = obGroupCreation.GroupDetailsSaveUpdate(Convert.ToString(obGroupCreation.GrpID_I));
            }


        }


        catch (Exception ex) { }
        finally { obGroupCreation = null; }
        return i;

    }


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

                Response.Redirect("VIEW002_GroupCreation.aspx");

            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Select at least one Title..');</script>");
        }



    }


    /////////// End   //////////////////////////////
}
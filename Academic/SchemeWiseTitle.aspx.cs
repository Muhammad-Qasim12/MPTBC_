using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

public partial class Academic_SchemeWiseTitle : System.Web.UI.Page
{
    TitleWiseSchemeMapping obTitleWise = null;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { LoadDetails(); }
    }

    public void LoadDetails() 
    {
        FillClass();
        FillTitle();
        FillScheme();


        if (Request.QueryString["Cid"] != null) 
        {
            LoadAllDetail(Convert.ToInt32(objdb.Decrypt(Request.QueryString["Cid"].ToString())));
        }
    }

    // function to load All Controls.
    public void LoadAllDetail(int TitleId) 
    {
        obTitleWise = new TitleWiseSchemeMapping();
        DataSet ds = new DataSet();

        try
        {
            obTitleWise.TitleID_I = TitleId;
            ds = obTitleWise.Select();

            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlClass.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ClassTrno_I"]);
                ddlTitle.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TitleID_I"]);
                string Schems = Convert.ToString(ds.Tables[0].Rows[0]["Schemes"]);
                FillSchemesChkList(Schems);
                txtRemark.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remark_V"]);
            }
        }
        catch (Exception ex) { }
        finally { obTitleWise = null; }
    }

    // function to load Checklist Details.
    public void FillSchemesChkList(string sch) 
    {
        string y = sch;
        string[] s = y.Split(',');

        FillScheme();

        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < ChkScheme.Items.Count; j++)
            {

                if (ChkScheme.Items[j].Text == s[i])
                {
                    ChkScheme.Items[j].Selected = true;
                }

            }
        }
    
    }

    // function to load class 
    public void FillClass() 
    {
        obTitleWise = new TitleWiseSchemeMapping();

        try
        {
            obTitleWise.ClassTrno_I = 0;
            ddlClass.DataTextField = "Classdet_V";
            ddlClass.DataValueField = "ClassTrno_I";

            ddlClass.DataSource = obTitleWise.LoadClass();
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, new ListItem("Select", "0"));

        }

        catch (Exception ex) { }

        finally { obTitleWise = null; }
    
    
    }

    // function to load title.
    public void FillTitle()
    {
        obTitleWise = new TitleWiseSchemeMapping();

        try 
        {
            obTitleWise.ClassTrno_I = Convert.ToInt32(ddlClass.SelectedValue);
            ddlTitle.DataTextField = "TitleHindi_V";
            ddlTitle.DataValueField = "TitleId_I";

            ddlTitle.DataSource = obTitleWise.LoadTitle();
            ddlTitle.DataBind();

            ddlTitle.Items.Insert(0, new ListItem("Select", "0"));

        }

        catch (Exception ex) { }

        finally { obTitleWise = null; }


    }

    // function to load Schemes.
    public void FillScheme()
    {
        obTitleWise = new TitleWiseSchemeMapping();

        try
        {
           
            ChkScheme.DataTextField = "SchemeName_Hindi";
            ChkScheme.DataValueField = "SchemeId";
            if (ddlClass.SelectedValue != "0")
            {
                if (ddlClass.SelectedItem.Text == "9" || ddlClass.SelectedItem.Text == "10" || ddlClass.SelectedItem.Text == "11" || ddlClass.SelectedItem.Text == "12")
                {
                    obTitleWise.Classes = "9-12";
                }
                else
                {
                    obTitleWise.Classes = "1-8";
                }
            }
            else { obTitleWise.Classes = "0"; }

            ChkScheme.DataSource = obTitleWise.LoadScheme();
            ChkScheme.DataBind();

           
        }

        catch (Exception ex) { }

        finally { obTitleWise = null; }


    }

    public string GetScheme() 
    {
        string scheme = "";

        for (int i = 0; i < ChkScheme.Items.Count; i++) 
        {
            if (ChkScheme.Items[i].Selected == true) 
            {
                scheme = scheme + ChkScheme.Items[i].Value + ",";
            
            }
        
        }

        return scheme;
    
    }

    // function to save mapping.
    public int SaveMapping()
    {
        obTitleWise = new TitleWiseSchemeMapping();

        int i = 0;
        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obTitleWise.TitleID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["Cid"].ToString()));
            }
            else 
            {
                obTitleWise.TitleID_I = Convert.ToInt32(ddlTitle.SelectedValue);
            }


            obTitleWise.ClassTrno_I = Convert.ToInt32(ddlClass.SelectedValue);
            
            obTitleWise.SchemeId_V = Convert.ToString(GetScheme());
            obTitleWise.UserID_I = Convert.ToInt32(Session["UserID_I"]);

            obTitleWise.Remark_V = Convert.ToString(txtRemark.Text);

            i = obTitleWise.InsertUpdate();

        }
        catch (Exception ex) { }
        finally { obTitleWise = null; }
        return i;
    }

    // function to check count selected Checkbox count
    public int GetCheckedStatus()
    {
        int count = 0;

        for (int i = 0; i < ChkScheme.Items.Count; i++)
        {

            if (ChkScheme.Items[i].Selected == true)
            {
                count++;
            }
        }

        return count;

    }


    // 
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClass.SelectedValue != "0")
        {
            FillTitle();
            FillScheme();
        }
        else 
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Select Class..');");
        }
    }

    // validation.
    public int Validation() 
    {
        int i = 0;

        if (ddlClass.SelectedValue == "0") 
        {
            i++;
            lblClass.Text = "Select Class..";
        }
        else
            if (ddlTitle.SelectedValue == "0")
            {
                i++;
                lblTitle.Text = "Select Book Title..";
            }

            else if (GetCheckedStatus() == 0) 
            {
                i++;
                lblChk.Text = "Please Select Scheme Name";
            }
        return i;
    
    }

  

    protected void btnSave_Click(object sender, EventArgs e) 
    {
        if (Validation() == 0)
        {

            if (SaveMapping() > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved.');");
              
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');");

            }
            Response.Redirect("VIEW_AMD015.aspx");
        }
    }


    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["Cid"] == null) 
        {
            LoadAllDetail(Convert.ToInt32(ddlTitle.SelectedValue));


        }

    }
}
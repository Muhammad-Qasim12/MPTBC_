using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_CategoryMas : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_CategoryMaster obPRI_CategoryMaster = null;
    CommonFuction obCommonFuction = null;
    APIProcedure objApi = new APIProcedure();
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClasses();
            LoadPrintingPaper();
            LoadCoverPaper();

            if (Request.QueryString["ID"] != null)
            {
                showdata();
            }
        }
    }
    public void LoadCoverPaper()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        try
        {
            ddlCoverPaperinformation_V.DataSource = obPRI_CategoryMaster.Fillddl(2);
            ddlCoverPaperinformation_V.DataTextField = "CoverInformation";
            ddlCoverPaperinformation_V.DataValueField = "PaperTrId_I";
            ddlCoverPaperinformation_V.DataBind();
            ddlCoverPaperinformation_V.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }
    }
    public void LoadPrintingPaper()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        try
        {
            ddlPrintingPaperInformation_V.DataSource = obPRI_CategoryMaster.Fillddl(1);
            ddlPrintingPaperInformation_V.DataTextField = "PrintingInformation";
            ddlPrintingPaperInformation_V.DataValueField = "PaperTrId_I";
            ddlPrintingPaperInformation_V.DataBind();
            ddlPrintingPaperInformation_V.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }
    }
    public void LoadClasses()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();

        try
        {
            obPRI_CategoryMaster.ClassTrno_I = 0;
            ddlClass.DataTextField = "Classdet_V";
            ddlClass.DataValueField = "ClassTrno_I";

            ddlClass.DataSource = obPRI_CategoryMaster.FillClass();
            ddlClass.DataBind();

            ddlClass.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }

    }
    public int SaveUpdateCategory()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        int i = 0;

        try
        {
            obPRI_CategoryMaster.CategoryNo_V = Convert.ToString(txtCategoryNo_V.Text.Trim());
            obPRI_CategoryMaster.ColorSchText_V = Convert.ToString(txtColorSchText_V.Text.Trim());
            obPRI_CategoryMaster.ColorSchCoverPaper_V = Convert.ToString(txtColorSchCoverPaper_V.Text.Trim());
            obPRI_CategoryMaster.PrintingPaperInformation_V = Convert.ToString(ddlPrintingPaperInformation_V.SelectedValue);
            obPRI_CategoryMaster.CoverPaperinformation_V = Convert.ToString(ddlCoverPaperinformation_V.SelectedValue);
            obPRI_CategoryMaster.Bindingdetail_V = Convert.ToString(txtBindingdetail_V.Text.Trim());
            obPRI_CategoryMaster.ClassTrno_I = Convert.ToInt32(ddlClass.SelectedValue);

            if (Request.QueryString["ID"] != null)
            {
                obPRI_CategoryMaster.CatID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString());
            }
            else
            {
                obPRI_CategoryMaster.CatID_I = 0;
            }

            i = obPRI_CategoryMaster.InsertUpdate();
        }
        catch { }
        finally
        {
            obPRI_CategoryMaster = null;
        }

        return i;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (SaveUpdateCategory() > 0)
        {
            //m.ShowMessage("s");
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);           
            Response.Redirect("CategoryMasterView.aspx");
        }

        else
        {
            m.ShowMessage("e");
        }
    }

    public void showdata()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();

        try
        {
            obPRI_CategoryMaster.CatID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString());
            DataSet obDataSet = obPRI_CategoryMaster.Select();
            txtCategoryNo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["CategoryNo_V"]);
            txtColorSchText_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["ColorSchText_V"]);
            txtColorSchCoverPaper_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["ColorSchCoverPaper_V"]);
            ddlPrintingPaperInformation_V.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrintingPaperInformation_V"]);
            ddlCoverPaperinformation_V.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["CoverPaperinformation_V"]);
            txtBindingdetail_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Bindingdetail_V"]);
            obPRI_CategoryMaster.CatID_I = 1;
            ddlClass.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["ClassTrno_I"]);

        }

        catch (Exception ex) { }

        finally { obPRI_CategoryMaster = null; }

    }
}


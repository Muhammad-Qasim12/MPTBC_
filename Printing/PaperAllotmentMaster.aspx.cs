using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using System.IO;
public partial class Printing_PaperAllotmentMaster : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            // Dropdown list of Acadmic Year 
             
             

            obCommonFuction = new CommonFuction();
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYear_Active(0)");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = ds1.Tables[0].Rows[0][0].ToString();
           // DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
            FillData();
            loadPrinters();
            DdlACYear_SelectedIndexChanged( sender,  e);
        }
    }

    public void FillData()
    {
        try
        {
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.PaperAltID_I = 0;            
            GrdPaperAllotment.DataSource = obPRI_PaperAllotment.Select();
            GrdPaperAllotment.DataBind();
          
        }
        catch
        {
        }
        finally { }
    }


    public void SearchData()
    {
        try
        {
            ////obPRI_PaperAllotment = new PRI_PaperAllotment();
            ////obPRI_PaperAllotment.PaperAltID_I = 0;
            ////here JobCode_V used for Printer Name
            //if (txtSearch.SelectedIndex > 0)
            //{
            //   // obPRI_PaperAllotment.JobCode_V = Convert.ToString(txtSearch.SelectedItem.Text);
            //    GrdPaperAllotment.DataSource = obPRI_PaperAllotment.SelectSearch();
            //    GrdPaperAllotment.DataBind();
            //}
            //else
            //{
            //    obPRI_PaperAllotment.JobCode_V = "";
            //    GrdPaperAllotment.DataSource = obPRI_PaperAllotment.SelectSearch();
            //    GrdPaperAllotment.DataBind();
            //}
            obCommonFuction = new CommonFuction();
            GrdPaperAllotment.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadSearchNew(" + txtSearch.SelectedValue + ",'"+DdlACYear.SelectedItem.Text+"')");
            GrdPaperAllotment.DataBind();
        }
        catch
        {
        }
        finally { }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("PaperAllotment.aspx");
    }
    protected void GrdPaperAllotment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperAllotment.PageIndex = e.NewPageIndex;
        SearchData();
        //FillData();
    }
    protected void GrdPaperAllotment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Delete(Convert.ToInt32(GrdPaperAllotment.DataKeys[e.RowIndex].Value.ToString()));
        obCommonFuction = new CommonFuction();
        GrdPaperAllotment.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadSearchNew(" + txtSearch.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "')");
        GrdPaperAllotment.DataBind();
       // FillData();
        //SearchData();
    }

 
    protected void GrdPaperAllotment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdSend")
        {
            try
            {
                obPRI_PaperAllotment = new PRI_PaperAllotment();
                obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(e.CommandArgument);
                obPRI_PaperAllotment.Status = 1;
                obPRI_PaperAllotment.UpdateStatus(obPRI_PaperAllotment.PaperAltID_I, obPRI_PaperAllotment.Status);

                obCommonFuction = new CommonFuction();
                obCommonFuction.EmptyTextBoxes(this);

                obPRI_PaperAllotment.PaperAltID_I = 0;

                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Request has been sent to Printer and Central Depo.');");
                Response.Write("</script>");
                FillData();
            }
            catch { }
            finally
            {
                obPRI_PaperAllotment = null;
            }
        }
        else if (e.CommandName == "btnDelete")
        {
            try
            {
                obPRI_PaperAllotment = new PRI_PaperAllotment();
                obPRI_PaperAllotment.Delete(Convert.ToInt32(Convert.ToInt32(e.CommandArgument)));
                obCommonFuction = new CommonFuction();
                GrdPaperAllotment.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadSearchNew(" + txtSearch.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "')");
                GrdPaperAllotment.DataBind();




            }
            catch { }
            finally
            {
                obPRI_PaperAllotment = null;
            }

        }
        else
        {
            obPRI_PaperAllotment = null;
        }



        /*
        if (e.CommandName == "cmdSend")
        {
            try
            {
                obPRI_PaperAllotment = new PRI_PaperAllotment();
                obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(e.CommandArgument); 
                obPRI_PaperAllotment.Status = 1;
                obPRI_PaperAllotment.UpdateStatus(obPRI_PaperAllotment.PaperAltID_I, obPRI_PaperAllotment.Status);

                obCommonFuction = new CommonFuction();
                obCommonFuction.EmptyTextBoxes(this);

                obPRI_PaperAllotment.PaperAltID_I = 0;

                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Request has been sent to Printer and Central Depo.');");
                Response.Write("</script>");
                FillData();
            }
            catch { }
            finally
            {
                obPRI_PaperAllotment = null;
            }
        }
        else
        {
            obPRI_PaperAllotment = null;
        }
        */
      
    }
    protected void GrdPaperAllotment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        
        
        SearchData();
    }

    public void loadPrinters()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {

            obPRI_PrinterRegistration.Printer_RedID_I = 0;

            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();

            txtSearch.DataTextField = "NameofPress_V";
            txtSearch.DataValueField = "Printer_RedID_I";

            txtSearch.DataSource = ds;

            txtSearch.DataBind();

            txtSearch.Items.Insert(0, new ListItem("All", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GrdPaperAllotment.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadSearchNew(0,'" + DdlACYear.SelectedItem.Text + "')");
            GrdPaperAllotment.DataBind();
        }
        catch { }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            obCommonFuction = new CommonFuction();
            GridView1.Visible = true;
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadSearchNew(0,'" + DdlACYear.SelectedItem.Text + "')");
            GridView1.DataBind();
            ExportToExcell();
            GridView1.Visible = false;

        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
}
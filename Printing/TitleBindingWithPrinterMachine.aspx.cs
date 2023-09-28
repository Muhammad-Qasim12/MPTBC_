using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class TitleBindingWithPrinterMachine : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
     
    CommonFuction obCommonFuction = new CommonFuction();
    DataSet dsGrid = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            FillPrinter();
            FillToPrinter();
        }
    }

    public void FillPrinter()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    public void FillToPrinter()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }



    //public void FillTitle()
    //{
    //    ddlTital.Items.Clear();
    //    DataSet asdf = obCommonFuction.FillDatasetByProc("call USP_Titleallottoprint('" + DdlACYear.SelectedItem.Text + "','" + ddlPrinter.SelectedValue + "')");
    //    ddlTital.DataSource = asdf.Tables[0];
    //    ddlTital.DataTextField = "TitleHindi_V";
    //    ddlTital.DataValueField = "TitleID_I";
    //    ddlTital.DataBind();
    //    ddlTital.Items.Insert(0, new ListItem("Select", "0"));
    //    btnSave.Visible = false;
    //}

    //public void FillMachine()
    //{
    //    ddlYojna.Items.Clear();
    //    DataSet asdf = obCommonFuction.FillDatasetByProc("call USP_PrinterMachine_TitleBind('" + ddlPrinter.SelectedValue + "')");
    //    ddlYojna.DataSource = asdf.Tables[0];
    //    ddlYojna.DataTextField = "Machine";
    //    ddlYojna.DataValueField = "MachineID_I";
    //    ddlYojna.DataBind();
    //    ddlYojna.Items.Insert(0, new ListItem("Select", "0"));
    //    btnSave.Visible = false;
    //}


    public void FillGrid()
    {
        GrdEval.DataSource = null;

        dsGrid = obCommonFuction.FillDatasetByProc("call USP_Titleallottoprint('" + DdlACYear.SelectedItem.Text + "','" + ddlPrinter.SelectedValue + "')");
        if (dsGrid.Tables[0].Rows.Count > 0)
        {
            GrdEval.DataSource = dsGrid;
            GrdEval.DataBind();
            fillGridDataForUpdate();
            btnSave.Visible = true;
        }
        else
        {
            GrdEval.DataSource = null;
            GrdEval.DataBind();
            btnSave.Visible = false;
        }
        //}
    }

    public void fillGridDataForUpdate()
    {
        try
        {
            for (int i = 0; i <= GrdEval.Rows.Count - 1; i++)
            {
                // DropDownList ddlPrinter = (DropDownList)GrdEval.Rows[i].FindControl("ddlPrinter");
                // ddlPrinter.SelectedValue = dsGrid.Tables[0].Rows[i]["printerid_i"].ToString();

                DropDownList ddlYojna = (DropDownList)GrdEval.Rows[i].FindControl("ddlYojna");
                ddlYojna.SelectedValue = dsGrid.Tables[0].Rows[i]["MachineID_I"].ToString();
            }
        }
        catch { }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrdEval.DataSource = null;
        GrdEval.DataBind();
        btnSave.Visible = false;
        // FillTitle();
        if (DdlACYear.SelectedIndex >= 0 && ddlPrinter.SelectedIndex > 0)
        {
            FillGrid();
        }
        else
        {
            message("ईयर, प्रिंटर, टाइटल सेलेक्ट करें  |", "");
        }
        lblMess.Text = "";
    }

    protected void ddlTital_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlACYear.SelectedIndex >= 0 && ddlPrinter.SelectedIndex > 0)
        {
            FillGrid();

        }
        else
        {
            message("ईयर, प्रिंटर, टाइटल सेलेक्ट करें  |", "");
        }
    }

    

    protected void btnClose_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("..\\Default.aspx");
            



        }

        catch { message("जानकारी चेक करे  |", "ERROR+"); }
        finally
        {
             message("जानकारी सेव हो गई  |", "");
            //Response.Redirect("PRI001_Group_ReAllocation.aspx");
        }

    }


    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }

    class TenderEval
    {
        public string GroupId { get; set; }
        public string CompanyName { get; set; }
        public string Rates { get; set; }
        public string Rank { get; set; }
        public string TenderEvalID { get; set; }
        public string IsRegistered { get; set; }
        public string PrinterId { get; set; }
        public string GrpId { get; set; }


    }

    protected void GrdEval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        // ddlPrinters = (DropDownList)e.Row.FindControl("ddlPrinter");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlYojna = (DropDownList)e.Row.FindControl("ddlYojna");

            try
            {



                DataSet asdf = obCommonFuction.FillDatasetByProc("call USP_PrinterMachine_TitleBind('" + ddlPrinter.SelectedValue + "')");
                ddlYojna.DataSource = asdf.Tables[0];
                ddlYojna.DataTextField = "Machine";
                ddlYojna.DataValueField = "MachineID_I";
                ddlYojna.DataBind();
                ddlYojna.Items.Insert(0, new ListItem("Select", "0"));



            }
            catch (Exception ex) { }
            finally { obPRI_PrinterRegistration = null; }
        }
    }




    protected void ddlToPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
        btnSave.Visible = true;
        // FillTitle();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            int printerID = Convert.ToInt32(ddlPrinter.SelectedValue);
            int ch;
            ch = 1;
            foreach (GridViewRow grdrow in GrdEval.Rows)
            {

                int Titleid = 0, Machinid = 0;
                if (printerID > 0 && DdlACYear.SelectedItem.Text.Length > 0)
                {


                    Titleid = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("HndTitleid")).Value);
                    Machinid = Convert.ToInt32(((DropDownList)grdrow.Cells[0].FindControl("ddlYojna")).SelectedValue);
                    if (ch == 1)
                    {
                        obCommonFuction.FillDatasetByProc("Call USP_TitleMachinebindprinter (0,0," + printerID + ",'" + DdlACYear.SelectedValue + "',0)");
                        ch++;
                    }

                    obCommonFuction.FillDatasetByProc("Call USP_TitleMachinebindprinter (" + Titleid + "," + Machinid + "," + printerID + ",'" + DdlACYear.SelectedValue + "',1)");
                }
                else
                {
                    message("ईयर, प्रिंटर, टाइटल,   |", "");
                    return;
                }
            }



        }

        catch { message("जानकारी चेक करे  |", "ERROR+"); }
        finally
        {
            message("जानकारी सेव हो गई  |", "");
            //Response.Redirect("PRI001_Group_ReAllocation.aspx");
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Printing_PrinterCapacityFinYearWise : System.Web.UI.Page
{
    PRI_MachineCapacity obMachineCap = null;
    CommonFuction obCommonFuction = null;
    DataSet Ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { LoadACyear(); LoadPrinterCapacity(); }
    }

    public void LoadACyear()
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();
            ddlACYear_I.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlACYear_I.DataValueField = "AcYear";
            ddlACYear_I.DataTextField = "AcYear";
            ddlACYear_I.DataBind();
            //ddlACYear_I.SelectedValue = obCommonFuction.GetFinYear();

            ddlACYear_I.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex) { }
        finally { obCommonFuction = null; }
    }


    public void LoadPrinterCapacity() 
    {
        obMachineCap = new PRI_MachineCapacity();
        try
        {
            obMachineCap.ACYear_V = Convert.ToString(ddlACYear_I.SelectedValue);
            grdPrinterCapacity.DataSource = obMachineCap.Select();
            grdPrinterCapacity.DataBind();
        }
        catch (Exception ex) { }
        finally { obCommonFuction = null; }
    }


    protected void ddlACYear_I_SelectedIndexChanged(object sender, EventArgs e) 
    {
        
            LoadPrinterCapacity();
        
    }


    public void SaveMachineCapacity() 
    {
        obMachineCap = new PRI_MachineCapacity();
       
        for (int i = 0; i < grdPrinterCapacity.Rows.Count; i++) 
        {
            if (grdPrinterCapacity.Rows[i].RowType == DataControlRowType.DataRow)
            {

                HiddenField PriId = (HiddenField)grdPrinterCapacity.Rows[i].FindControl("HDNPrinter_RedID_I");
                HiddenField MacCapId = (HiddenField)grdPrinterCapacity.Rows[i].FindControl("HDNMachineCapID_I");
                HiddenField MacId = (HiddenField)grdPrinterCapacity.Rows[i].FindControl("HDNMachineID_I");

                TextBox txtOne = (TextBox)grdPrinterCapacity.Rows[i].FindControl("txtOneColor");
                TextBox txtTwo = (TextBox)grdPrinterCapacity.Rows[i].FindControl("txtTwoColor");
                TextBox txtFour = (TextBox)grdPrinterCapacity.Rows[i].FindControl("txtFourColor");


                obMachineCap.ACYear_V = Convert.ToString(ddlACYear_I.SelectedValue);
                obMachineCap.OneColor_N = Convert.ToDouble(txtOne.Text);
                obMachineCap.TwoColor_N = Convert.ToDouble(txtTwo.Text);
                obMachineCap.FourColor_N = Convert.ToDouble(txtFour.Text);

                obMachineCap.Printer_RedID_I = Convert.ToInt32(PriId.Value);
                obMachineCap.MachineID_I = Convert.ToInt32(MacId.Value);
                obMachineCap.MachineCapID_I = Convert.ToInt32(MacCapId.Value);

                obMachineCap.InsertUpdate();



            }


        
        }



    }

    protected void BtnSave_Click(object sender, EventArgs e) 
    {
        if (ddlACYear_I.SelectedValue != "0")
        {
            CommonFuction comm = new CommonFuction();
            Ds = new DataSet(); 
            SaveMachineCapacity();
           comm.FillDatasetByProc("Call USP_Printercapasityupdation('" + ddlACYear_I.SelectedItem.Text + "',1 )");
           comm.FillDatasetByProc("Call USP_Printercapasityupdation('" + ddlACYear_I.SelectedItem.Text + "',0 )");
            message("Detail Saved.", "SUCCESS");

        }

        else 
        {
            message("शैक्षणिक सत्र का चयन करे ", "ERROR");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e) { }


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

}
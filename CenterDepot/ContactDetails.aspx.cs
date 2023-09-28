using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CenterDepot_ContactDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            DdlACYear_SelectedIndexChanged(sender, e);
            fillgrd();
            fillTransporter();
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLPrinter.DataSource = obCommonFuction.FillDatasetByProc("call GetPrinterList('"+DdlACYear.SelectedValue +"')");
        DDLPrinter.DataValueField = "Printer_RegID_I";
        DDLPrinter.DataTextField = "NameOfPress_V";
        DDLPrinter.DataBind();
        DDLPrinter.Items.Insert(0, new ListItem("-Select-", "0"));
    
    }

    private void fillTransporter()
    {
        ddlTransporter.DataSource = obCommonFuction.FillDatasetByProc("SELECT * FROM cpd_transportermaster order by Transportername");
        ddlTransporter.DataValueField = "Trid";
        ddlTransporter.DataTextField = "Transportername";
        ddlTransporter.DataBind();
        //ddlTransporter.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            HiddenField1.Value = "0";
        }
        obCommonFuction.FillDatasetByProc("call USP_CPD_ContactDetails(" + HiddenField1.Value + ",'" + DdlACYear.SelectedValue + "'," + DDLPrinter.SelectedValue + ",'" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "','','"+ddlTransporter.SelectedValue+"')");
        obCommonFuction.EmptyTextBoxes(this);
        fillgrd();
        HiddenField1.Value = "";

    }
    public void fillgrd()
    {
    GridView1.DataSource= obCommonFuction.FillDatasetByProc("call USP_CPD_ContactDetails(-1,0,0,0,0,0,0,0)");
    GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlACYear.ClearSelection();
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
        DdlACYear.Items.FindByText(GridView1.SelectedRow.Cells[1].Text).Selected = true;
        DdlACYear_SelectedIndexChanged(sender, e);
        DDLPrinter.ClearSelection();

        DDLPrinter.Items.FindByText(GridView1.SelectedRow.Cells[2].Text).Selected = true;
        txt1.Text = GridView1.SelectedRow.Cells[3].Text;
        txt2.Text = GridView1.SelectedRow.Cells[4].Text;
        txt3.Text = GridView1.SelectedRow.Cells[5].Text;
       // txt4.Text = GridView1.SelectedRow.Cells[6].Text;
        
    }
}
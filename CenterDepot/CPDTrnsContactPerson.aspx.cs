using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CenterDepot_CPDTrnsContactPerson : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            //DdlACYear.DataValueField = "AcYear";
            //DdlACYear.DataTextField = "AcYear";
            //DdlACYear.DataBind();
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            //DdlACYear_SelectedIndexChanged(sender, e);
            fillgrd();
            fillTransporter();
        }
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
            obCommonFuction.FillDatasetByProc("insert into cpd_transportcontactperson(Contactperson,ContactNO,Transporterid) values('" + txtContactPerson.Text + "','" + txtContactNo.Text + "','" + ddlTransporter.SelectedValue + "')");

        }
        else
        {
            obCommonFuction.FillDatasetByProc("update cpd_transportcontactperson set Contactperson='" + txtContactPerson.Text + "',ContactNO='" + txtContactNo.Text + "',Transporterid='" + ddlTransporter.SelectedValue + "' where id='" + HiddenField1.Value + "'");
        }
        
        //obCommonFuction.EmptyTextBoxes(this);
        txtContactNo.Text = "";
        txtContactPerson.Text = "";
       fillgrd();
        HiddenField1.Value = "";

    }
    public void fillgrd()
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("SELECT * FROM `cpd_transportcontactperson` cp INNER JOIN cpd_transportermaster ct ON cp.Transporterid=ct.Trid");
    GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // DdlACYear.ClearSelection();
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
        //DdlACYear.Items.FindByText(GridView1.SelectedRow.Cells[1].Text).Selected = true;
       // DdlACYear_SelectedIndexChanged(sender, e);
        //DDLPrinter.ClearSelection();

        //DDLPrinter.Items.FindByText(GridView1.SelectedRow.Cells[2].Text).Selected = true;
        txtContactNo.Text = GridView1.SelectedRow.Cells[3].Text;
        txtContactPerson.Text = GridView1.SelectedRow.Cells[2].Text;
       // txt3.Text = GridView1.SelectedRow.Cells[5].Text;
       // txt4.Text = GridView1.SelectedRow.Cells[6].Text;
        
    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {
       
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        HiddenField1.Value = GridView1.DataKeys[e.RowIndex].Value.ToString();   
        obCommonFuction.FillDatasetByProc("delete from cpd_transportcontactperson where id ='" + HiddenField1.Value.ToString() + "'");
    }
}
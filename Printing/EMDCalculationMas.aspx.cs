using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Printing_EMDCalculationMas : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        messageDiv.Style.Add("display", "none");
        if (!IsPostBack)
        {
            LoadACyear();
            fillgrd(0);
        }
    }
    public void fillgrd(int id)
    {
        try
        {
            DataSet dd = obCommonFuction.FillDatasetByProc("call Gettbl_TonnageDetails(" + id + ")");
            GridView1.DataSource = dd.Tables[0];
            GridView1.DataBind();
        }
        catch (Exception)
        {
        }
    }
    public void LoadACyear()
    {
        try
        {
            ddlACYear_I.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlACYear_I.DataValueField = "AcYear";
            ddlACYear_I.DataTextField = "AcYear";
            ddlACYear_I.DataBind();
            ddlACYear_I.SelectedValue = obCommonFuction.GetFinYear();

            ddlACYear_I.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            if (HiddenField1.Value == "")
            {
                obCommonFuction.FillDatasetByProc("call PrintSavetbl_TonnageDetails(0," + txtfrom.Text + "," + txtto.Text + "," + txtAmount.Text + ",'" + ddlACYear_I.SelectedItem.Text + "')");
                m.ShowMessage("s");
            }
            else
            {
                obCommonFuction.FillDatasetByProc("call PrintSavetbl_TonnageDetails(" + HiddenField1.Value + "," + txtfrom.Text + "," + txtto.Text + "," + txtAmount.Text + ",'" + ddlACYear_I.SelectedItem.Text + "')");
                m.ShowMessage("u");
            }
            fillgrd(0);
            obCommonFuction.EmptyTextBoxes(this);
            HiddenField1.Value = "";
        }
        catch (Exception)
        {
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlACYear_I.ClearSelection();
            ddlACYear_I.Items.FindByText(GridView1.SelectedRow.Cells[0].Text).Selected = true;
            txtfrom.Text = GridView1.SelectedRow.Cells[1].Text;
            txtto.Text = GridView1.SelectedRow.Cells[2].Text;
            txtAmount.Text = GridView1.SelectedRow.Cells[3].Text;
            HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
        }
        catch (Exception)
        {
        }
    }
}
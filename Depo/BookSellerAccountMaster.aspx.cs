using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_BookSellerAccountMaster : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDLBank();
            fillgrd();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            obCommonFuction.FillDatasetByProc ("call USP_dpt_booksellerAccount(0,"+DDLBank.SelectedValue+",'"+txtAcNo.Text+"','"+txtBranch.Text+"',"+Session["UserID"]+")");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Saved Successfully";
        }
        else
        {
            obCommonFuction.FillDatasetByProc("call USP_dpt_booksellerAccount(" + HiddenField1.Value + "," + DDLBank.SelectedValue + ",'" + txtAcNo.Text + "','" + txtBranch.Text + "'," + Session["UserID"] + ")");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record uPDATED Successfully";
        }
        obCommonFuction.EmptyTextBoxes(this);
        HiddenField1.Value="";
        fillgrd();
    }
    public void fillgrd()
    {
       GridView1.DataSource= obCommonFuction.FillDatasetByProc("call USP_dpt_booksellerAccount(-1,0,0,0," + Session["UserID"] + ")");
       GridView1.DataBind();
    
    }
    public void BindDDLBank()
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("CALL USP_bankmasterList()");
        DDLBank.DataSource = dd;
        DDLBank.DataValueField = "BankId";
        DDLBank.DataTextField = "BankName";
        DDLBank.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDLBank.ClearSelection();
        DDLBank.Items.FindByText(GridView1.SelectedRow.Cells[1].Text).Selected = true;
        txtAcNo.Text = GridView1.SelectedRow.Cells[3].Text;
        txtBranch.Text = GridView1.SelectedRow.Cells[2].Text;
        HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
    }
}
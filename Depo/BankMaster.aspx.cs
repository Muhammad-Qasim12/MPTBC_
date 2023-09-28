using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_BankMaster : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (HiddenField1.Value == "")
        {
            obj.FillDatasetByProc("insert into bankmaster(BankName)values ('" + txtHeadname.Text + "')");
        }
        else
        {
            obj.FillDatasetByProc("update bankmaster set BankName='" + txtHeadname.Text + "' where BankId="+HiddenField1.Value+"");
        }
        txtHeadname.Text = "";
        HiddenField1.Value = "";
        fillgrd();

    }
    public void fillgrd()
    {
        GridView1.DataSource = obj.FillDatasetByProc("select * from bankmaster order by BankId desc");
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       HiddenField1.Value = GridView1.SelectedDataKey.Value.ToString();
       txtHeadname.Text = GridView1.SelectedRow.Cells[1].Text;

    }
}
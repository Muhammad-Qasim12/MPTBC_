using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DistributionB_InsuranceDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            for (int i = 2017; i <= System.DateTime.Now.Year + 1; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");
            ddlMonth.DataTextField = "MonthFullName";
            ddlMonth.DataValueField = "MonthId";
            ddlMonth.DataSource = obCommonFuction.FillDatasetByProc("call hr_get_months()");
            ddlMonth.DataBind();
            ddlMonth.Items.Insert(0, "सलेक्ट करे ..");
            fillgrd();
        }
    }

    public void fillgrd()
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_tbl_BimakiJankari(-1,0,0,0,0,0,0)");
        GridView1.DataBind();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_tbl_BimakiJankari(0,"+ddlMonth.SelectedValue+" ,"+DdlDepot.SelectedValue+",'"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+ddlYear.SelectedValue+"')");
        obCommonFuction.EmptyTextBoxes(this);
        Label1.Text = "Data Saved";
        fillgrd();
    
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrd();
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_tbl_BimakiJankari("+GridView1.DataKeys[e.RowIndex].Value.ToString ()+",0,0,0,0,0,0)");
    
        fillgrd();
    }
}
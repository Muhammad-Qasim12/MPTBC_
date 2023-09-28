using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_BookNumbering : System.Web.UI.Page
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
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DisBookNumbering(3,0,0,0,'"+DdlACYear.SelectedValue+"')");
        GridView1.DataBind();
        Button2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_DisBookNumbering(0,0,0,0,'" + DdlACYear.SelectedValue + "')");
        for (int i=0;i<GridView1.Rows.Count;i++)
        {
            obCommonFuction.FillDatasetByProc("call USP_DisBookNumbering(-1," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)GridView1.Rows[i].FindControl("txt1")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txt2")).Text + ",'" + DdlACYear.SelectedValue + "')");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
    }
}
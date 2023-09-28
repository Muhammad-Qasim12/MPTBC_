using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_TitleWiseSummary : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    int TotalSamany, TotalScheme;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select//", "0"));
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_TitleWiseStockSmry('" + DdlACYear.SelectedValue + "'," + ddlMedium.SelectedValue + ")");
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    int TotalYojna, TotalSamanya, Total;
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {


    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    // TextBox lblPerBundle = (TextBox)e.Row.FindControl("txtYojna");
                    TotalYojna += e.Row.Cells[2].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[2].Text);
                }
                catch { }
                try
                {
                    TotalSamanya += e.Row.Cells[3].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[3].Text);
                }
                catch { }
                try
                {
                    Total += e.Row.Cells[4].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[4].Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = TotalYojna.ToString();
            e.Row.Cells[3].Text = TotalSamanya.ToString();
            e.Row.Cells[4].Text = Total.ToString();

        }
    }
}
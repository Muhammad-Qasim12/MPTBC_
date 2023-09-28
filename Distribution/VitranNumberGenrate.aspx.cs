using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Distribution_VitranNumberGenrate : System.Web.UI.Page
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
            DdlACYear_SelectedIndexChanged( sender,  e);
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DDlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("select distinct OrderNo from dis_demandtoprintingnew where AcYear='" + DdlACYear.SelectedItem.Text + "'");
        DDlOrderNo.DataValueField = "OrderNo";
        DDlOrderNo.DataTextField = "OrderNo";
        DDlOrderNo.DataBind();
        DDlOrderNo.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("delete from tbl_VitranbandleNumber where OrderNo='"+DDlOrderNo.SelectedValue+"'");
        obCommonFuction.FillDatasetByProc("call Fn_GenrateVitranBundleNoold('" + DdlACYear.SelectedValue + "','" + DDlOrderNo.SelectedValue + "','" + txtFirstNo.Text + "','"+txtFirstNo0.Text+"')");

        mainDiv.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        mainDiv.Visible = true;
        lblmsg.Visible = true;
        lblmsg.Text = "डाटा सुरक्षित हो गया है | ";

    }
}
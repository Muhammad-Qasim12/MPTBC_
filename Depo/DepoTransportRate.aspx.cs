using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_DepoTransportRate : System.Web.UI.Page
{
    string blockName;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDepo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot1()");
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataBind();
            ddlDepo.Items.Insert(0, "Select");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //GetTransportRate
        asa.Visible = true;
        Label1.Text = DdlACYear.SelectedValue;
        Label2.Text = ddlDepo.SelectedItem.Text;
        Label3.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        Label4.Text = ddlDepo.SelectedItem.Text;
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call GetTransportRate('"+DdlACYear.SelectedValue+"',"+ddlDepo.SelectedValue+")");
        GridView1.DataBind();
    }
    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("District_Name_Hindi_V").ToString();
        if (!string.Equals(lt.Text, blockName))
        {
            blockName = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
}
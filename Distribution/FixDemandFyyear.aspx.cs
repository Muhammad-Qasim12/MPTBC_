using System;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;


public partial class Distribution_FixDemandFyyear : System.Web.UI.Page
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

            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            DDlDemandType.Items.Insert(0, "--Select--");
            fillgrd();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_DIS_BlockDemand(0,'"+DdlACYear.SelectedItem.Text +"',"+DDlDemandType.SelectedValue+")");
        fillgrd();
        mainDiv.Visible = true;
        lblmsg.Visible = true;
        lblmsg.Text = "डाटा सुरक्षित हो चुका है ! ";
    }
    public void fillgrd()
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DIS_BlockDemand(1,0,0)");
        GridView1.DataBind();
    }
}
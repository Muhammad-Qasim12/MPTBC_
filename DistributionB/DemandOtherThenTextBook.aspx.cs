using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class DistributionB_DemandOtherThenTextBook : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.DemandfromOthers obDemandfromOthers = new MPTBCBussinessLayer.DistributionB.DemandfromOthers();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obDemandfromOthers.QueryType = -1;
            ddlAcYr.DataSource = obDemandfromOthers.Select().Tables[0];
            ddlAcYr.DataTextField = "AcYear";
            ddlAcYr.DataValueField = "id";
            ddlAcYr.DataBind();
            ddlAcYr.Items.Insert(0, new ListItem("All", "0"));
            ddlAcYr_SelectedIndexChanged(sender, e);
            FillLetterInfoGrid();
        }
    }

    private void FillLetterInfoGrid()
    {
        DemandfromOthersNew obj = new DemandfromOthersNew();
        obj.QueryType = -11;
        obj.ParameterValue = int.Parse(ddlAcYr.SelectedValue);
        obj.ParameterValue2 = int.Parse(ddlTitle.SelectedValue);
        obj.StringParameterValue = ddlDepartment.SelectedValue;
        GrdLetterInfo.DataSource = obj.SelectNew();
        GrdLetterInfo.DataBind();
    }
    public class DemandfromOthersNew
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public string StringParameterValue { get; set; }
        DBAccess obDBAccess = new DBAccess();
        public System.Data.DataSet SelectNew()
        {
            obDBAccess.execute("USP_DIB002_DemandfromOthersSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            obDBAccess.addParam("mStringParameterValue", StringParameterValue);

            return obDBAccess.records();
        }
    }
    protected void btnNewFreeDistribution_Click(object sender, EventArgs e)
    {
        Response.Redirect("DemandfromOthers.aspx");
    }
    protected void GrdLetterInfo_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {

    }
    protected void GrdLetterInfo_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //obClassMaster = new ClassMaster();
        //obClassMaster.Delete(Convert.ToInt32(GrdClassMaster.DataKeys[e.RowIndex].Value.ToString()));
        //FillData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //obDemandfromOthers.TransID = -11;
        //obDemandfromOthers.ParameterValue = int.Parse(ddlAcYr.SelectedValue);
        //obDemandfromOthers.ParameterValue2 = int.Parse(ddlTitle.SelectedValue);
        //GrdLetterInfo.DataSource = obDemandfromOthers.Select();
        //GrdLetterInfo.DataBind();
        FillLetterInfoGrid();
    }
    protected void ddlAcYr_SelectedIndexChanged(object sender, EventArgs e)
    {
        obDemandfromOthers.QueryType = -16;
        obDemandfromOthers.ParameterValue = int.Parse(ddlAcYr.SelectedValue);
        ddlTitle.DataSource = obDemandfromOthers.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("All", "0"));
        ddlTitle_SelectedIndexChanged(sender, e);
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        obDemandfromOthers.QueryType = 0;
        ddlDepartment.DataSource = obDemandfromOthers.Select();
        ddlDepartment.DataTextField = "DepartmentName_V";
        ddlDepartment.DataValueField = "DepartmentID_I";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("All", "0"));
    }
}

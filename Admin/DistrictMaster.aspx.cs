using System;
using MPTBCBussinessLayer;
using System.Data;

public partial class Admin_DistrictMaster : System.Web.UI.Page
{
    DistrictMaster obDistrictMaster = new DistrictMaster();
    CommonFuction obCommonFuction = null;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillDivision();
                FillDepo();
                if (Request.QueryString["ID"] != null)
                {
                    showdata(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                    
                }

            }
            catch { }
            finally { obDistrictMaster = null; }
        }
    }
    private void FillDivision()
    {
        obDistrictMaster = new DistrictMaster();
        obDistrictMaster.DistrictTrno_I = -1;
        ddlDivision.DataSource = obDistrictMaster.Select();
        ddlDivision.DataTextField = "Division_Name_Eng_V";
        ddlDivision.DataValueField = "DivisionTrno_I";
        ddlDivision.DataBind();

    }

    private void FillDepo()
    {
        obDistrictMaster = new DistrictMaster();
        obDistrictMaster.DistrictTrno_I = -2;
        ddlDepo.DataSource = obDistrictMaster.Select();
        ddlDepo.DataTextField = "DepoName_V";
        ddlDepo.DataValueField = "DepoTrno_I";
        ddlDepo.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        try
        {

            obDistrictMaster = new DistrictMaster();
            obDistrictMaster.District_Name_V =Convert.ToString( txtDistrictNameinHindi.Text);
            obDistrictMaster.District_Name_Eng_V = Convert.ToString(txtDistrictNameng.Text);
            obDistrictMaster.DepotID_I = Convert.ToInt32(ddlDepo.SelectedValue);
            obDistrictMaster.DivisionTrno_N = Convert.ToInt32(ddlDivision.SelectedValue);
            obDistrictMaster.Trans_I = 0;
           
            obDistrictMaster.DistrictTrno_I = 0;
            if (HiddenField1.Value != "")
            {
                obDistrictMaster.Trans_I = 1;
                obDistrictMaster.DistrictTrno_I = Convert.ToInt32(HiddenField1.Value);
            }
            obDistrictMaster.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);
            HiddenField1.Value = "";
        }
        catch { }
        finally
        {
            obDistrictMaster = null;
        }
        Response.Redirect("VIEW_AMD009.aspx");

    }

    public void showdata(string ID)
    {
        obDistrictMaster = new DistrictMaster();
        obDistrictMaster.DistrictTrno_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        DataSet obDataSet = obDistrictMaster.Select();

        ddlDepo.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DepotID_I"]);
        ddlDivision.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DivisionTrno_I"]);
        txtDistrictNameinHindi.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["District_Name_Hindi_V"]);
        txtDistrictNameng.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["District_Name_Eng_V"]);
        obDistrictMaster.Trans_I = 1;
        HiddenField1.Value = (objdb.Decrypt(Request.QueryString["ID"].ToString()));

    }
}
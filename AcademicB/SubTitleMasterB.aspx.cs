using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class AcademicB_SubTitleMasterB : System.Web.UI.Page
{
    SubTitle obSubTitleMaster = new SubTitle();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        
            FillTitle();
            btnSave.Enabled = false;
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    int id = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]));
                    ddlTitle.SelectedValue = id.ToString();
                    btnSave.Enabled = true;
                    //FillData(id);
                    FillGrid();
                }
                catch
                {
                    ResetFields();
                }

            }
        }
    }

    private void FillTitle()
    {
        obSubTitleMaster.TranID = -1;
        ddlTitle.DataSource = obSubTitleMaster.Select();
        ddlTitle.DataTextField = "TitleEnglish_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("Select", "0"));
    }

    private void ResetFields()
    {
        txtSubTitleEnglish.Text = string.Empty;

        txtSubTitleHindi.Text = string.Empty;
        hdnSubTitleID.Value = "";
    }
    private void FillData(int titleID)
    {
        obSubTitleMaster.TitleID = titleID;
        obSubTitleMaster.TranID = -2;
        DataSet dsTitle = obSubTitleMaster.Select();
        if (dsTitle.Tables[0].Rows.Count > 0 && titleID != 0)
        {
            ddlTitle.SelectedValue = dsTitle.Tables[0].Rows[0]["TitleID_I"].ToString();
            ddlTitle.Enabled = false;


            //txtSubTitleHindi.Text = dsTitle.Tables[0].Rows[0]["SubTitleHindi_V"].ToString();
            //txtSubTitleEnglish.Text = dsTitle.Tables[0].Rows[0]["SubTitleEnglish_V"].ToString(); 
        }
        else
        {
            ResetFields();
        }
    }

    private void FillGrid()
    {
        obSubTitleMaster.SubTitleID = int.Parse(ddlTitle.SelectedValue);
        obSubTitleMaster.TranID = -2;
        DataSet dsTitle = obSubTitleMaster.Select();
        GrdTitle.DataSource = dsTitle.Tables[0];
        GrdTitle.DataBind();
    }
    protected void GrdTitle_RowEditing(object sender, GridViewEditEventArgs e)
    {
        txtSubTitleHindi.Text = GrdTitle.Rows[e.NewEditIndex].Cells[1].Text;
        hdnSubTitleID.Value = GrdTitle.DataKeys[e.NewEditIndex].Value.ToString();
        obSubTitleMaster.SubTitleID = int.Parse(hdnSubTitleID.Value);
        obSubTitleMaster.SubTitleHindi = txtSubTitleHindi.Text;
        obSubTitleMaster.SubTitleEnglish = txtSubTitleEnglish.Text;
        btnCancel.Visible = true;
        //obSubTitleMaster.TranID = int.Parse(hdnSubTitleID.Value);
        //try
        //{
        //    obSubTitleMaster.InsertUpdate();
        //}
        //catch
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Can not update this record');</script>");
        //}
    }
    protected void GrdTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obSubTitleMaster.Delete(Convert.ToInt32(GrdTitle.DataKeys[e.RowIndex].Value.ToString()));
            FillGrid();
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Can not delete this record');</script>");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {


        obSubTitleMaster.SubTitleHindi = txtSubTitleHindi.Text;
        obSubTitleMaster.SubTitleEnglish = txtSubTitleHindi.Text;
        obSubTitleMaster.TitleID = int.Parse(ddlTitle.SelectedValue);
        obSubTitleMaster.Rate = double.Parse(txtRate.Text);
        obSubTitleMaster.AcYear = DdlACYear.SelectedItem.Text.ToString();
        int id = 0;
        if (hdnSubTitleID.Value != "")
        {
            int.TryParse(hdnSubTitleID.Value, out id);
        }
        obSubTitleMaster.SubTitleID = id;
        obSubTitleMaster.TranID = id;
        try
        {
            obSubTitleMaster.InsertUpdate();
            btnCancel.Visible = false;
            //Response.Redirect("View_ACB_002.aspx");
            FillGrid();
            ResetFields();
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Duplicate record');</script>");
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewTitleMasterB.aspx");
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ResetFields();
        FillGrid();
        btnCancel.Visible = false;
    }

    public class SubTitle
    {
        public string SubTitleHindi { get; set; }
        public string SubTitleEnglish { get; set; }
        public int TitleID { get; set; }
        public int SubTitleID { get; set; }
        public int TranID { get; set; }
        public double Rate { get; set; }
        public string AcYear { get; set; }
       
        
        
        DBAccess obDBAccess;

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB002_SubTitleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubTitleHindi_V", SubTitleHindi);
            obDBAccess.addParam("mSubTitleEnglish_V", SubTitleEnglish);
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID);
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mRate_N", Rate);
            obDBAccess.addParam("mYEAR", AcYear);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB002_SubTitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID);
            obDBAccess.addParam("mTranID", TranID);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB002_SubTitleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubTitleID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
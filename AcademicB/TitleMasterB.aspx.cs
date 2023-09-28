using System;
using System.Data;
using MPTBCBussinessLayer.AcademicB;

public partial class AcademicB_TitleMaster : System.Web.UI.Page
{
    ACB_TitleMaster obTitleMaster = new ACB_TitleMaster();
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
        


            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    int id = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]));

                    FillData(id);
                }
                catch
                {
                    ResetFields();
                }

            }
        }
    }

    private void ResetFields()
    {
        txtTitleHindi.Text = string.Empty;
        txtTitleEnglish.Text = string.Empty;
    }
    private void FillData(int titleID)
    {
        obTitleMaster.TitleID = titleID;
        DataSet dsTitle = obTitleMaster.Select();
        if (dsTitle.Tables[0].Rows.Count > 0 && titleID != 0)
        {

            txtTitleHindi.Text = dsTitle.Tables[0].Rows[0]["TitleHindi_V"].ToString();

            txtTitleEnglish.Text = dsTitle.Tables[0].Rows[0]["TitleEnglish_V"].ToString();
            txtRate.Text = dsTitle.Tables[0].Rows[0]["Rate_p"].ToString();
            DdlACYear.SelectedValue = dsTitle.Tables[0].Rows[0]["AcYear"].ToString();

            DBAccess obDbAccess = new DBAccess();
            //obDbAccess.execute("SELECT * FROM acb_subtitle where TitleID_I =" + titleID.ToString(), DBAccess.SQLType.IS_QUERY);
            obDbAccess.execute("USP_ACB002_SubTitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mSubTitleID_I", titleID);
            obDbAccess.addParam("mTranID", -2);

            DataSet dsSubTitleInfo = obDbAccess.records();

            chkNoSubTitle.Checked = false;

            if (dsSubTitleInfo.Tables[0].Rows.Count == 1)
            {
                if (dsSubTitleInfo.Tables[0].Rows[0]["SubTitleHindi_V"].ToString() == "--")
                {
                    chkNoSubTitle.Checked = true;
                }

            }
        }
        else
        {
            ResetFields();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        obTitleMaster.TitleHindi = txtTitleHindi.Text;
        //obTitleMaster.TitleEnglish = txtTitleEnglish.Text;
        obTitleMaster.TitleEnglish = txtTitleHindi.Text;
        obTitleMaster.Rate = double.Parse(txtRate.Text);
        obTitleMaster.AcYear = DdlACYear.SelectedItem.Text.ToString();
        obTitleMaster.UserID = int.Parse(Session["UserID"].ToString());
        int id = 0;
        if (Request.QueryString["ID"] != null)
        {
            int.TryParse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()), out id);
        }
        obTitleMaster.TranID = id;
        try
        {
            int TitleID = obTitleMaster.InsertUpdate();
            if (chkNoSubTitle.Checked)
            {
                SubTitle obSubTitle = new SubTitle();
                obSubTitle.TitleID = TitleID;
                obSubTitle.TranID = 0;
                obSubTitle.SubTitleEnglish = "--";
                obSubTitle.SubTitleHindi = "--";
                obSubTitle.InsertUpdate();
            }

        }
        catch (Exception ex)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Duplicate entry');</script>");
        }

        Response.Redirect("ViewTitleMasterB.aspx");
    }
    public class ACB_TitleMaster
    {
        public int ClassTrno { get; set; }
        public string ColorText { get; set; }
        public string ColourCover1n4 { get; set; }
        public string ColourCover2n3 { get; set; }
        public int DepartmentTrno { get; set; }
        public int Medium { get; set; }
        public int Pages { get; set; }
        public double Rate { get; set; }
        public string AcYear { get; set; }
        public string Size { get; set; }
        public string TitleEnglish { get; set; }
        public string TitleHindi { get; set; }
        public int TitleID { get; set; }
        public int TranID { get; set; }
        public int UserID { get; set; }

        DBAccess obDBAccess;

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB001_TitleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleHindi_V", TitleHindi);
            obDBAccess.addParam("mTitleEnglish_V", TitleEnglish);
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mUserId", UserID);
            obDBAccess.addParam("mRate_N", Rate);
            obDBAccess.addParam("mAcYear", AcYear);
            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB001_TitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", TitleID);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB001_TitleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
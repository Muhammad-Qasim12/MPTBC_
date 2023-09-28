using System;
using System.Web.UI.WebControls;
using System.Data;

public partial class AcademicB_ViewGroupInfo : System.Web.UI.Page
{
    GroupCreation obGroupCreation = new GroupCreation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillTitle();
            FillGrid();
        }

    }

    private void FillGrid()
    {
       //obGroupCreation.QueryType = -10;
        obGroupCreation.QueryType = -13;
        obGroupCreation.GroupName_V = "";
        obGroupCreation._FYear = "";
        GrdTitle.DataSource = obGroupCreation.Select();
        GrdTitle.DataBind();
    }

    private void FillTitle()
    {
        obGroupCreation.QueryType = 202;
        DropDownList1.DataSource = obGroupCreation.Select();
        DropDownList1.DataTextField = "TitleHindi_V";
        DropDownList1.DataValueField = "TitleID_I";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        obGroupCreation.QueryType = -13;
        obGroupCreation.PrameterValue = Convert.ToInt32(DropDownList1.SelectedValue != "" ? DropDownList1.SelectedValue : "0");
        obGroupCreation.PrameterValue2 = Convert.ToInt32(0);
        DataTable dtSelectedTitle = obGroupCreation.Select().Tables[0];
        GrdTitle.DataSource = dtSelectedTitle;
        GrdTitle.DataBind();
       
    }

    protected void GrdTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        //obGroupCreation.Delete(Convert.ToInt32(GrdTitle.DataKeys[e.RowIndex].Value.ToString()));
        //FillGrid();
    }
    protected void GrdTitle_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GrdTitle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("GroupCreation.aspx");
    }

    public class GroupCreation
    {
        public int QueryType { get; set; }
        public int PrameterValue { get; set; }
        public int PrameterValue2 { get; set; }

        public int DemandGroupTrno_I { get; set; }
        public int DemandID_I { get; set; }
        public int SubTitleID_I { get; set; }
        public int DepoTrno_I { get; set; }
        public int TotalSupply_I { get; set; }

        public string GroupName_V { get; set; }
        public string GroupDate_D { get; set; }
        public int TypeID { get; set; }
        public int GrpDetailID_I { get; set; }


        public string PrintingCategory_V { get; set; }

        public double _EMDAmount_N { get; set; }
        public string _FYear { get; set; }


        //   DemandGroupTrno_I, 
        //DemandID_I, 
        //SubTitleID_I, 
        //DepoTrno_I, 
        //TotalSupply_I, 
        //GroupName_V, 
        //GroupDate_D

        DBAccess obDBAccess = new DBAccess();

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess.execute("USP_ACB003_GroupCreationSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandGroupTrno_I", DemandGroupTrno_I);
            obDBAccess.addParam("mDemandID_I", DemandID_I);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            obDBAccess.addParam("mTotalSupply_I", TotalSupply_I);
            obDBAccess.addParam("mGroupName_V", GroupName_V);
            obDBAccess.addParam("mGroupDate_D", GroupDate_D);
            obDBAccess.addParam("mTypeID", TypeID);


            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_ACB003_GroupCreationSelect_New", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrameterValue", PrameterValue);
            obDBAccess.addParam("mPrameterValue2", PrameterValue2);
            obDBAccess.addParam("mGroupNameIds", GroupName_V);
            obDBAccess.addParam("mAcYr", _FYear);

            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet LoadCategory()
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_ACB003_CategoryMasterLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mQueryType", QueryType);
            obj.addParam("mCatID_I", PrameterValue);
            ds = obj.records();

            return ds;


        }
        public int GroupMasterSaveUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            int i = 0;
            try
            {
                obDBAccess.execute("USP_ACB003_GroupCreationMasterSave", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mGrpID_I", DemandGroupTrno_I);
                obDBAccess.addParam("mGroupNO_V", GroupName_V);
                obDBAccess.addParam("mPrintingCategory_V", PrintingCategory_V);
                obDBAccess.addParam("mDepoID_I", DepoTrno_I);
                obDBAccess.addParam("mEmdAmount", _EMDAmount_N);
                obDBAccess.addParam("mFYear", _FYear);

                i = Convert.ToInt32(obDBAccess.executeMyScalar());

            }

            catch (Exception ex) { }
            finally { obDBAccess = null; }

            return i;

        }
        public int GroupDetailsSaveUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_ACB003_GroupDetailSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpDetId_I", GrpDetailID_I);
                obDbAccess.addParam("mGRPID_I", DemandGroupTrno_I);
                obDbAccess.addParam("mSubTitleID_I", SubTitleID_I);
                obDbAccess.addParam("mDepoID_I", DepoTrno_I);
                obDbAccess.addParam("mDemandID_I", DemandID_I);
                i = obDbAccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;

        }

        #endregion
    }
}
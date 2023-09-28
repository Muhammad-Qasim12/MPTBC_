using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using MPTBCBussinessLayer;

public partial class Printing_PaperAssessment : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;

    static int count = 0;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            //DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM004_DistrictMasterSelect(0,0)");
            //DdlDistrict.DataValueField = "DistrictTrno_I";
            //DdlDistrict.DataTextField = "District_Name_Hindi_V";
            //DdlDistrict.DataBind();
            //DdlDistrict.Items.Insert(0, "--Select--");

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            //DdlACYear.SelectedValue = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            LblFyYear.Text = DdlACYear.SelectedItem.Text;
            DdlACYear_SelectedIndexChanged(sender, e);

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM010_DepomasterLoad(0)");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--All--");

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, "Select");

            //DdlClass.Items.Insert(0, "--Select--");
            //DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM017_SchemeMasterLoad()");
            //DdlScheme.DataValueField = "SchemeId";
            //DdlScheme.DataTextField = "SchemeName_Hindi";
            //DdlScheme.DataBind();
            //DdlScheme.Items.Insert(0, "--All--");
            //loadgrid(1); 


            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlMedum.DataSource = objTentativeDemandHistory.MedumFill();
            ddlMedum.DataValueField = "MediumTrno_I";
            ddlMedum.DataTextField = "MediunNameHindi_V";
            ddlMedum.DataBind();
            ddlMedum.Items.Insert(0, "Select");


        }

    }


    public void FillGrid()
    {
        loadgrid(1);


    }

    private void loadgrid(int mtype)
    {//mtype=1 all data , 2 calculated demand, 3 - depo wise 4-class wise 5 depo+class wise 
        PRI009n obj = new PRI009n();
        CommonFuction comm = new CommonFuction();
        try
        {

            if (mtype == 1)
            {
                obj.dtype = 1;
                obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                obj.intClasstrno_I = 0;
                obj.intdepotrno_I = 0;
                DataSet ds = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(1,'" + Convert.ToString(DdlACYear.SelectedValue) + "',0,0,0)");
                gvProjectMaster.DataSource = ds.Tables[0];
                gvProjectMaster.DataBind();

            }

            else if (mtype == 2)
            {
                obj.dtype = 2;
                obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                obj.intClasstrno_I = 0;
                obj.intdepotrno_I = 0;
                DataSet ds = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(2,'" + Convert.ToString(DdlACYear.SelectedValue) + "',0,0,0)");
                gvPapCalculation.DataSource = ds.Tables[0];
                gvPapCalculation.DataBind();

            }

            else if (mtype == 3)
            {
                obj.dtype = 1;
                obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                obj.intClasstrno_I = 0;
                obj.intdepotrno_I = DdlDepot.SelectedIndex > 0 ? Convert.ToInt32(DdlDepot.SelectedValue) : 0;


                DataSet ds = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(1,'" + Convert.ToString(DdlACYear.SelectedValue) + "',0,0,0)");
                gvProjectMaster.DataSource = ds.Tables[0];
                gvProjectMaster.DataBind();

            }
            else if (mtype == 4)
            {
                //obj.dtype = 1;
                //obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                //obj.intClasstrno_I = DdlClass.SelectedIndex>0 ?  Convert.ToInt32(DdlClass.SelectedValue) : 0;
                //obj.intdepotrno_I = 0;
                DataSet dda = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(1,'" + Convert.ToString(DdlACYear.SelectedValue) + "',0," + DdlClass.SelectedValue + ",0)");
                gvProjectMaster.DataSource = dda.Tables[0];
                gvProjectMaster.DataBind();

            }

            else if (mtype == 5)
            {
                obj.dtype = 1;
                obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                obj.intClasstrno_I = DdlClass.SelectedIndex > 0 ? Convert.ToInt32(DdlClass.SelectedValue) : 0;
                obj.intdepotrno_I = ddlMedum.SelectedIndex > 0 ? Convert.ToInt32(ddlMedum.SelectedValue) : 0;
                DataSet dda = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(1,'" + Convert.ToString(DdlACYear.SelectedValue) + "',0," + DdlClass.SelectedValue + ",0)");
                gvProjectMaster.DataSource = dda.Tables[0];
                gvProjectMaster.DataBind();

            }

            else if (mtype == 6)
            {
                obj.dtype = 1;
                obj.acyear = Convert.ToString(DdlACYear.SelectedValue);
                obj.intClasstrno_I = DdlClass.SelectedIndex > 0 ? Convert.ToInt32(DdlClass.SelectedValue) : 0;
                // obj.intdepotrno_I = DdlDepot.SelectedIndex > 0 ? Convert.ToInt32(DdlDepot.SelectedValue) : 0;
                obj.intdepotrno_I = ddlMedum.SelectedIndex > 0 ? Convert.ToInt32(ddlMedum.SelectedValue) : 0;
                int classtrno = DdlClass.SelectedIndex > 0 ? Convert.ToInt32(DdlClass.SelectedValue) : 0;
                int medeiumtrno = ddlMedum.SelectedIndex > 0 ? Convert.ToInt32(ddlMedum.SelectedValue) : 0;
                DataSet dda = comm.FillDatasetByProc("call USP_PRI009_GetDemandFormDistribution(1,'" + Convert.ToString(DdlACYear.SelectedValue) + "',0" + DdlClass.SelectedValue + "," + medeiumtrno + ")");
                gvProjectMaster.DataSource = dda.Tables[0];
                gvProjectMaster.DataBind();

            }
        }
        catch
        {
            gvProjectMaster.DataSource = null;
            gvProjectMaster.DataBind();
        }
        finally { }

    }


    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();

    }
    protected void gridDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //((Label)e.Row.FindControl("lbl1")).Text = (string)DataBinder.Eval(e.Row.DataItem, "BookName");

            //((HiddenField)e.Row.FindControl("hdnDistrict1")).Value = (string)DataBinder.Eval(e.Row.DataItem, "BookID");

        }
        catch { }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Data Save Successfully');</script>");
    }
    protected void gvProjectMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvProjectMaster.PageIndex = e.NewPageIndex;
        if (ddlMedum.SelectedIndex > 0)
            loadgrid(6);
        else if (DdlClass.SelectedIndex > 0)
            loadgrid(5);
        else
            loadgrid(1);
    }
    protected void gvProjectMaster_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gvProjectMaster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvProjectMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ButPapCal_Click(object sender, EventArgs e)
    {
        loadgrid(2);

    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlClass.SelectedIndex == 0)
        {
            loadgrid(3);
        }
        else
        {
            loadgrid(5);
        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlDepot.SelectedIndex == 0)
        {
            loadgrid(4);
        }
        else
        {
            loadgrid(5);
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        // DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        // DdlACYear.DataValueField = "AcYear";
        //  DdlACYear.DataTextField = "AcYear";
        //   DdlACYear.DataBind();
        // DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        loadgrid(1);
        LblFyYear.Text = DdlACYear.SelectedItem.Text;
    }
    protected void ddlMedum_SelectedIndexChanged(object sender, EventArgs e)
    {

        loadgrid(6);

    }

    public class PRI009n
    {


        private string _acyear;
        private int _dtype, _intTrno_I, _LID, _intUserTrnoNo_I, _intClasstrno_I, _intdepotrno_I;



        public string acyear
        {
            get { return _acyear; }
            set { _acyear = value; }
        }

        public int dtype
        {
            get { return _dtype; }
            set { _dtype = value; }
        }

        public int LID
        {
            get { return _LID; }
            set { _LID = value; }
        }


        public int intUserTrnoNo_I
        {
            get { return _intUserTrnoNo_I; }
            set { _intUserTrnoNo_I = value; }
        }

        public int intdepotrno_I
        {
            get { return _intdepotrno_I; }
            set { _intdepotrno_I = value; }
        }


        public int intClasstrno_I
        {
            get { return _intClasstrno_I; }
            set { _intClasstrno_I = value; }
        }




        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI009_GetDemandFormDistribution", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("dtype", dtype);
                obDBAccess.addParam("macyear", acyear);
                obDBAccess.addParam("mediumtype", intdepotrno_I);
                // _intUserTrnoNo_I for MediumMaster 
                obDBAccess.addParam("classid", intClasstrno_I);
                obDBAccess.addParam("depoid", 0);

            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();
        }


        public int ShowData()
        {
            DBAccess obDBAccess = new DBAccess();
            DataSet DS = new DataSet();
            try
            {
                DS = Select();
                //intTrno_I = Convert.ToInt32(Convert.ToString(DS.Tables[0].Rows[0]["TimeLineCompID_I"]));
                //intOrderNo_I = Convert.ToInt32(Convert.ToString(DS.Tables[0].Rows[0]["OrderNo_I"]));
                //chvComponentname_V = Convert.ToString(Convert.ToString(DS.Tables[0].Rows[0]["TimeLineCompName_V"]));
            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return 0;
        }



        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();

            //try
            //{
            //    LID = 0;
            //    if (intTrno_I != 0)
            //    {
            //        LID = intTrno_I;
            //        obDBAccess.AuditTrailInsert("PRI_projectmanagementcomponentmaster", LID, "TimeLineCompID_I", "U", intUserTrnoNo_I);
            //    }

            //    obDBAccess.execute("USP_PRI002_projectmanagementcomponentmastersave", DBAccess.SQLType.IS_PROC);
            //    obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
            //    obDBAccess.addParam("mTimeLineCompName_V", chvComponentname_V);
            //    obDBAccess.addParam("mOrderNo_I", intOrderNo_I);                 
            //    obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32 ,  LID, DBAccess.SqlDirection.OUT );                   
            //    int result  = obDBAccess.executeMyQuery();
            //    LID= Convert.ToInt32 ( obDBAccess.getParameter(3).ToString());
            //    if (intTrno_I == 0)
            //    {
            //        obDBAccess.AuditTrailInsert("PRI_projectmanagementcomponentmaster", LID, "TimeLineCompID_I", "N", intUserTrnoNo_I);
            //    }

            //    return LID;
            //}

            //catch (Exception feException)
            //{
            //    throw new Exception(feException.Message);
            //}
            //finally
            //{
            //   obDBAccess.releasedCommand();

            //}
            return 0;
        }

        public int Delete(int id)
        {
            //DBAccess obDBAccess = new DBAccess();
            //try
            //{
            //    obDBAccess.execute("USP_PRI002_projectmanagementcomponentmasterDelete", DBAccess.SQLType.IS_PROC);
            //    obDBAccess.addParam("mTimeLineCompID_I", intTrno_I);
            //    int result = obDBAccess.executeMyQuery();
            //    return result;
            //   // throw new NotImplementedException();
            //}
            //catch (Exception feException)
            //{
            //    throw new Exception(feException.Message);
            //}
            //finally
            //{
            //    obDBAccess.releasedCommand();

            //}
            return 0;
        }






    }

}

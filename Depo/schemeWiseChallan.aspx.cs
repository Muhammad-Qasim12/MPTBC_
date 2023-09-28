using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_schemeWiseChallan : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    string classID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["ClassID"] == "1" || Request.QueryString["ClassID"] == "2")
            {
                classID = "1-8";
            }
            else
            {
                classID = "9-12";
            }

            try
            {
                DataSet dd4 = comm.FillDatasetByProc("truncate table BookData");
            }
            catch { }
            DataSet dd3 = comm.FillDatasetByProc("call procedure1q( 0," + Request.QueryString["blockID"] + ",'" + Request.QueryString["Fyyear"] + "',0," + Session["UserID"] + ")");
            // DataSet dd = comm.FillDatasetByProc("SELECT SchemeId," + Request.QueryString["ChallanID"] + " as ChallanNO , SchemeName_Hindi FROM adm_schememaster where classes='" + classID + "' ");
            DataSet dd = comm.FillDatasetByProc("select distinct adm_schememaster.SchemeId,SchemeName_Hindi," + Request.QueryString["ChallanID"] + " as ChallanNO  from adm_schememaster inner join BookData on BookData.SchemeID=adm_schememaster.SchemeId where BlockIDA=" + Request.QueryString["blockID"] + " order by SchemeId asc");
            grdview.DataSource = dd.Tables[0];
            grdview.DataBind();

        }
    }
    protected void grdDailyTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int CountryId;
            GridView gv = (GridView)e.Row.FindControl("grdview1");
            // ((HtmlImage)e.Row.FindControl("imgAddReason")).Visible = false;
            try
            {
                CountryId = Convert.ToInt32(((HiddenField)e.Row.FindControl("HID")).Value);
                DataSet dd1 = comm.FillDatasetByProc(" select * from BookData where Praday<>0 and SchemeID=" + CountryId + " ");
                gv.DataSource = dd1.Tables[0];
                gv.DataBind();
                //sd.Fill_Grid(gv, "select Sno ,OrganizationName ,convert(varchar,DateOfVisti,106) DateOfVisti,convert(varchar,NextVistDate,106)NextVistDate ,RemarkAsOn,NoOfVisitsmade ,CallStatus from EmpDailyReport('" + Convert.ToDateTime(TextBox1.Text, cul).ToString("MM/dd/yyyy") + "','" + Convert.ToDateTime(TextBox2.Text, cul).ToString("MM/dd/yyyy") + "'," + CountryId + ")");
            }
            catch { }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Depo_Format4 : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
         

            DataSet dt = obCommonFuction.FillDatasetByProc("call USP_GetEmployeeDetails(" + Session["UserID"] + ")");
            ddlPEmp.DataSource = dt.Tables[1];
            ddlPEmp.DataValueField = "EmployeeId";
            ddlPEmp.DataTextField = "NAME";
            ddlPEmp.DataBind();
            ddlPEmp.Items.Insert(0, "Select");
            ddlstoreKee.DataSource = dt.Tables[0];
            ddlstoreKee.DataValueField = "EmployeeId";
            ddlstoreKee.DataTextField = "NAME";
            ddlstoreKee.DataBind();
            ddlstoreKee.Items.Insert(0, "Select");

            ddlDepoManager.DataSource = dt.Tables[2];
            ddlDepoManager.DataValueField = "EmployeeId";
            ddlDepoManager.DataTextField = "NAME";
            ddlDepoManager.DataBind();
            ddlDepoManager.Items.Insert(0, "Select");

            
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
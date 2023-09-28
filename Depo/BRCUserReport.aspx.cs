using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Depo_BRCUserReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataSet ds;
    DBAccess db = new DBAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //ddlDepot.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM010_DepomasterLoad(0 )");
            //ddlDepot.DataValueField = "DepoTrno_I";
            //ddlDepot.DataTextField = "DepoName_V";
            //ddlDepot.DataBind();
            //ddlDepot.Items.Insert(0, "--Select--");
            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" +Session["USERID"] + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");
        }
    }
    protected void ddlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {

       
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet dd = new DataSet();
            Panel1.Visible = true;
            if (RadioButtonList1.SelectedValue == "1")
            { 
             dd = obCommonFuction.FillDatasetByProc("call UserReporBlockwise(" + DdlDistrict.SelectedValue + " ,"+Session["UserID"]+")");
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                dd = obCommonFuction.FillDatasetByProc("call USERReportDepowiseBooksellerNew(" + DdlDistrict.SelectedValue + " ,0)");
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                dd = obCommonFuction.FillDatasetByProc("call USERReportDepowiseBooksellerNew(" + Session["UserID"] + ",1)");
            }
            else if (RadioButtonList1.SelectedValue == "4")
            {
                dd = obCommonFuction.FillDatasetByProc("call USERReportDepowiseBooksellerNew(" + Session["UserID"] + " ,2)");
            }
                gvUserMaster.DataSource = dd.Tables[0];
            gvUserMaster.DataBind();
        }
        catch { }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BlockReport.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}
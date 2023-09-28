using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;

public partial class Building_Reports_RPT001_AvasVistrit : System.Web.UI.Page
{
     Building002_AvasVistrit obAvasVistrit = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            LoadDistict();
            AvasTitleDDl();
            LoadAvas();
        }

    }


    public void LoadDistict()
    {
        CommonFuction obCommonFuction = new CommonFuction();
        try
        {

            DDLDistrictTrno_I.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM004_DistrictMasterSelect(0,0)");
            DDLDistrictTrno_I.DataValueField = "DistrictTrno_I";
            DDLDistrictTrno_I.DataTextField = "District_Name_Hindi_V";
            DDLDistrictTrno_I.DataBind();
            DDLDistrictTrno_I.Items.Insert(0, new ListItem("Select", "0"));



        }

        catch (Exception ex) { }
        finally { obCommonFuction = null; }
    }

    public void AvasTitleDDl()
    {
        obAvasVistrit = new Building002_AvasVistrit();
        DataSet ds = new DataSet();

        try
        {
            ddlAvasType.DataTextField = "AvasPrakar";
            ddlAvasType.DataValueField = "AvasMasterTrno_I";

            obAvasVistrit.AvasMasterTrno_I = 0;

            ddlAvasType.DataSource = obAvasVistrit.AvasTitleSelect();
            ddlAvasType.DataBind();

            ddlAvasType.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obAvasVistrit = null; }


    }


    public void LoadAvas()
    {
        obAvasVistrit = new Building002_AvasVistrit();

        try
        {
            obAvasVistrit.Zone_V = Convert.ToString(ddlZone_V.SelectedValue);
            obAvasVistrit.AvasAddress_V = Convert.ToString(ddlType .SelectedValue);
            obAvasVistrit.AvasMasterTrno_I = Convert.ToInt32(ddlAvasType .SelectedValue);
            obAvasVistrit.PayScale_V = Convert.ToString(ddlPayScale_V .SelectedValue);
            obAvasVistrit.DistrictTrno_I = Convert.ToInt32(DDLDistrictTrno_I.SelectedValue);
           
            grdAvasVistrit.DataSource = obAvasVistrit.RPTAvasVistritLoad();
            grdAvasVistrit.DataBind();
        }

        catch (Exception ex)
        { }
        finally { obAvasVistrit = null; }


    }


    protected void btngetReport_Click(object sender, EventArgs e) 
    {
        LoadAvas();
    }


    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

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

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.DistributionB;
using MPTBCBussinessLayer.Store;

public partial class DistributionB_DIB_Reports_Rpt_DIB002_DemandFromOther : System.Web.UI.Page
{
    DemandfromOthers obDemandfromOthers = null;
    STR_VendorMaster obSTR_VendorMaster = null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                DropDownList1.DataSource = comm.FillDatasetByProc("call USP_ADM006_DivisionMasterLoad(0)");
                DropDownList1.DataValueField = "DivisionTrno_I";
                DropDownList1.DataTextField = "Division_Name_Hindi_V";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Select");

                FillDistrict();

            }
        }
        catch
        {
        }
        finally
        { }
    }

    public void FillDistrict()
    {
        try
        {
            obSTR_VendorMaster = new STR_VendorMaster();
            ddlDistrict.DataSource = obSTR_VendorMaster.FillStateCity();
            ddlDistrict.DataValueField = "DistrictTrno_I";
            ddlDistrict.DataTextField = "District_Name_Hindi_V";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, "Select");
        }
        catch { }
        finally { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obDemandfromOthers = new DemandfromOthers();
            if (ddlDistrict.SelectedValue != "0")
            {
                obDemandfromOthers.DistrictID_I = Convert.ToInt32(ddlDistrict.SelectedValue);
                try
                {
                    var data = obDemandfromOthers.FillGrid();
                    GrdViewOtherDemand.DataSource = data.Tables[1];
                    GrdViewOtherDemand.DataBind();
                }
                catch (Exception ex)
                {
                    GrdViewOtherDemand.DataSource = null;
                    GrdViewOtherDemand.DataBind();
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('इस जिले की कोई जानकारी उपलब्ध नहीं है..');</script>");
                }
            }
        }
        catch { }
        finally { obDemandfromOthers = null; }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        //FillGrid();
        if (GrdViewOtherDemand.Rows.Count > 0)
        {
            Class1 cls = new Class1();
            cls.Export("DemandInformation.xls", GrdViewOtherDemand, "अन्य पाठ्य सामग्री की मांग जिला - " + ddlDistrict.SelectedItem.Text);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('इस जिले की कोई जानकारी उपलब्ध नहीं है..');</script>");
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // GetDivisionWiseDistrict
        ddlDistrict.DataSource = comm.FillDatasetByProc("call GetDivisionWiseDistrict(" + DropDownList1.SelectedValue + ")");
        ddlDistrict.DataValueField = "DistrictTrno_I";
        ddlDistrict.DataTextField = "District_Name_Hindi_V";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "Select");
    }
}
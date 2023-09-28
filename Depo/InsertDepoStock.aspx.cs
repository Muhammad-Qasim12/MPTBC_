using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_InsertDepoStock : System.Web.UI.Page
{
    WareHouseMaster obWareHouseMaster = new WareHouseMaster ();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "ClassDesc_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, new ListItem("Select", "0"));
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Fn_CursorStockinsertOpeningStock(1, 1, 1, 10, 100, 100, 2000, 0, 7);
        obCommonFuction.FillDatasetByProc("call Fn_CursorStockinsertOpeningStock(1," + DdlTitle.SelectedValue + "," + RadioButtonList1.SelectedValue+ "," + txtTotlebundle.Text + "," + txtbundleFrom.Text + ","+txtPerBundleBook.Text+","+txtbookNoFrom.Text+",0,"+ddlWarehouse.SelectedValue+")");
        txtbookNoFrom.Text = "";
        txtbundleFrom.Text = "";
        txtPerBundleBook.Text = "";
        txtTotlebundle.Text = "";
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Stock Save Successfully');</script>");
    
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_TitleLoadClassWise(" + Convert.ToInt32(DdlClass.SelectedValue) + ")");
        DdlTitle.DataValueField = "TitleID_I";
        DdlTitle.DataTextField = "TitleHindi_V";
        DdlTitle.DataBind();
        //DdlTitle.Items.Insert(0, "--Select--");
        DdlTitle.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        obWareHouseMaster = new WareHouseMaster();
        obWareHouseMaster.WareHouseID = 0;
        obWareHouseMaster.UserID_I = Convert.ToInt32(DdlDepot.SelectedValue);
        DataSet ds12 = obWareHouseMaster.Select();
        ddlWarehouse.DataTextField = "WareHouseName_V";
        ddlWarehouse.DataValueField = "WareHouseID_I";
        ddlWarehouse.DataSource = ds12.Tables[0];
        ddlWarehouse.DataBind();

    }
}
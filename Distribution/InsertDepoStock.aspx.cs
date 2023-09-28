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
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call Fn_CursorStockinsertOpeningStock(1," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + RadioButtonList1.SelectedValue + "," + ((TextBox)GridView1.Rows[i].FindControl("txtTotlebundle")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txtbundleFrom")).Text + "," + ((Label)GridView1.Rows[i].FindControl("txtPerBundleBook")).Text + "," + ((TextBox)GridView1.Rows[i].FindControl("txtbookNoFrom")).Text + ",0," + ddlWarehouse.SelectedValue + ")");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        //txtbookNoFrom.Text = "";
        //txtbundleFrom.Text = "";
        //txtPerBundleBook.Text = "";
        //txtTotlebundle.Text = "";
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Stock Save Successfully');</script>");
    
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
        DdlMedium.DataValueField = "MediumTrno_I";
        DdlMedium.DataTextField = "MediunNameHindi_V";
        DdlMedium.DataBind();
        //DdlMedium.Items.Insert(0, "--Select--");
        //DdlTitle.Items.Insert(0, "--Select--");
        DdlMedium.Items.Insert(0, new ListItem("Select", "0"));
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
    protected void DdlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
       GridView1.DataSource= obCommonFuction.FillDatasetByProc("call GetMediumwisebookDetails("+DdlMedium.SelectedValue+","+DdlClass.SelectedValue+")");
       GridView1.DataBind();

    }
}
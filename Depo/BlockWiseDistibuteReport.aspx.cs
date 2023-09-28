using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_BlockWiseDistibuteReport : System.Web.UI.Page
{
    Blockmaster obBlockmaster = new Blockmaster();
    public DataSet df; TransportDetails obTransportDetails = null;
    TransportMaster obTransportMaster = null;
    public int i; int id;
    DBAccess db = new DBAccess(); Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obTransportDetails = new TransportDetails();
            obTransportDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            obTransportDetails.TransportID_I = 0;
            DataSet dsdist = obTransportDetails.DistAndBolck();
            ddlDistrict.DataTextField = "District_Name_Hindi_V";
            ddlDistrict.DataValueField = "DistrictTrno_I";
            ddlDistrict.DataSource = dsdist.Tables[0];
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, "Select..");


            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            ddlMadhyam.DataSource = objTentativeDemandHistory.MedumFill();
            ddlMadhyam.DataValueField = "MediumTrno_I";
            ddlMadhyam.DataTextField = "MediunNameHindi_V";
            ddlMadhyam.DataBind();
            ddlMadhyam.Items.Insert(0, "Select");
            //obBlockmaster.BlockTrno_I = 0;

            //DataSet ds = obBlockmaster.Select();
            //ddlBlock.DataTextField = "BlockName_V";
            //ddlBlock.DataValueField = "BlockTrno_I";
            //ddlBlock.DataSource = ds.Tables[0];
            //ddlBlock.DataBind();
          
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();
            if (ddlMadhyam.SelectedValue == "Select")
            {

                id = 0;
            }
            else
            {
                id = Convert.ToInt32(ddlMadhyam.SelectedValue);
            }
            df = obCommonFuction.FillDatasetByProc("call USP_DPT_040GetStockByBlock(" + ddlBlock.SelectedValue + "," + id + "," + ddlChallan.SelectedValue + ")");
            GridView1.DataSource = df.Tables[0];
            GridView1.DataBind();
            if (df.Tables[0].Rows.Count > 0)
            {
                a.Visible = true;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Data Not Found .');</script>");
            }
        }
        catch { }
    }
   
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        db.execute("select BlockTrno_I,  BlockName_V, BlockNameHindi_V from adm_blockmaster where DistrictTrno_I="+ddlDistrict.SelectedValue+"", DBAccess.SQLType.IS_QUERY);
        DataSet ds = db.records();
        ddlBlock.DataSource = ds.Tables[0];
        ddlBlock.DataTextField = "BlockNameHindi_V";
        ddlBlock.DataValueField = "BlockTrno_I";
        ddlBlock.DataBind();
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        db.execute("select   ChallanNo_V, ChallanNo_V from dpt_stockdistributionschemeentry_m where blockid_i=" + ddlBlock.SelectedValue + "", DBAccess.SQLType.IS_QUERY);
        DataSet ds = db.records();
        ddlChallan.DataSource = ds.Tables[0];
        ddlChallan.DataTextField = "ChallanNo_V";
        ddlChallan.DataValueField = "ChallanNo_V";
        ddlChallan.DataBind();
        ddlChallan.Items.Insert (0, "select..");
    }
}
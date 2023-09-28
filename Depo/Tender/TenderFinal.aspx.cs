using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_Tender_TenderFinal : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlDepo.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataBind();
            ddlDepo.Items.Insert(0, "Select");
        }
    }
    protected void ddlDepo_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet ds = comm.FillDatasetByProc("call Depo_TenderDetailsLoad(0," + ddlDepo.SelectedValue + ")");
        ddlTender.DataTextField = "TenderNo_V";
        ddlTender.DataValueField = "TenderId_I";
        try
        {
            //   obTender.TenderID_I = 0;

            ddlTender.DataSource = ds.Tables[0];
            ddlTender.DataBind();
        }
        catch (Exception ex) { }
        finally { }

        ddlTender.Items.Insert(0, new ListItem("Select", "0"));
    }


    protected void ddlTender_SelectedIndexChanged(object sender, EventArgs e)
    {
      DataSet dd=  comm.FillDatasetByProc("call GetFinaldataForDepo("+ddlTender.SelectedValue+")");
      GridView1.DataSource = dd.Tables[0];
      GridView1.DataBind();
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dd = comm.FillDatasetByProc(@"  select  distinct TransportID_I as partyID from DepoFinalRateDistribution
INNER JOIN tenderparticipent_t ON tenderparticipent_t.TenderParID_I=TransportID_I where TenderID="+ddlTender.SelectedValue+"");
        for (int i = 0; i < dd.Tables[0].Rows.Count; i++)
        {
            HiddenField1.Value = dd.Tables[0].Rows[i]["partyID"].ToString();
        DataSet dd1 = comm.FillDatasetByProc("call GetDepotenderRateInsert(" + HiddenField1.Value + ")");
        comm.FillDatasetByProc("call GetDepoRateSave(" + dd1.Tables[0].Rows[0][0].ToString ()+ "," + ddlTender.SelectedValue + ")");
        GridView1.DataSource = null;
        GridView1.DataBind();
        }
        //GetDepotenderRateInsert
        //GetDepoRateSave
     
    }
}
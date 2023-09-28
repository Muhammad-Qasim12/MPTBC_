using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_Tender_ShowTenderDistribution : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    string blockName;
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

        DataSet ds = comm.FillDatasetByProc("call Depo_TenderDetailsLoad(0," + ddlDepo.SelectedValue+ ")");
        ddlTender.DataTextField = "TenderNo_V";
        ddlTender.DataValueField = "TenderId_I";
        try
        {
            //   obTender.TenderID_I = 0;

            ddlTender.DataSource = ds.Tables[0];
            ddlTender.DataBind();
        }
        catch (Exception ex) { }
        finally {  }

        ddlTender.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("District_Name_Hindi_V").ToString();
        if (!string.Equals(lt.Text, blockName))
        {
            blockName = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }

    protected void ddlTender_SelectedIndexChanged(object sender, EventArgs e)
    {
        //obCommonFuction = new CommonFuction();
        DataSet ds1 = comm.FillDatasetByProc("call GelLoneList(" + ddlDepo.SelectedValue + "," + ddlTender.SelectedValue + ")");
        grdblock.DataSource = ds1.Tables[0];
        grdblock.DataBind();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        HiddenField distRictID = (HiddenField)grdrow.FindControl("hdDistrict");
        HiddenField partyID=(HiddenField)grdrow.FindControl("HDTenderParID");
        HiddenField4.Value = distRictID.Value;
        HiddenField5.Value = partyID.Value;
        HiddenField HDTenderParID = (HiddenField)grdrow.FindControl("HDTenderParID");
        DataSet ds = comm.FillDatasetByProc("call Depo_tenderRateFinal(" + distRictID.Value + "," +HDTenderParID.Value+ ")");
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        comm.FillDatasetByProc("call Depo_saveFinalRateList(1," + HiddenField5.Value + "," + HiddenField5.Value + ",'0','0','0',0," + HiddenField4.Value + ",0,1,'0',0,'0','0')");
        HiddenField5.Value = "";
        HiddenField4.Value = "";
        string strfyYaer = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        foreach (GridViewRow grdrow in GridView1.Rows)
        {
            
                try
                {
                    
                    //obTransportDetails = new TransportDetails();
                    HiddenField hdnHeadId = (HiddenField)grdrow.FindControl("hdnHeadId");
                    HiddenField hdnblockTrn = (HiddenField)grdrow.FindControl("hdnblockTrn");
                    HiddenField HiddenField1=(HiddenField)grdrow.FindControl("HiddenField1");
                    HiddenField HdtenderID = (HiddenField)grdrow.FindControl("HiddenField3");
                    //obTransportDetails.FullTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtEstimateAmount")).Text);
                    //obTransportDetails.HalfTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtAvailableAmount")).Text);
                    //obTransportDetails.RatePerBundle_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtrequestAmount")).Text);
                    comm.FillDatasetByProc("call Depo_saveFinalRateList(0," + HiddenField1.Value + "," + hdnblockTrn.Value + "," + Convert.ToDouble(((TextBox)grdrow.FindControl("txtEstimateAmount")).Text) + "," + Convert.ToDouble(((TextBox)grdrow.FindControl("txtAvailableAmount")).Text) + "," + Convert.ToDouble(((TextBox)grdrow.FindControl("txtrequestAmount")).Text) + ",0," + hdnHeadId.Value + ",0,1,'" + strfyYaer + "',0," + HdtenderID.Value+ ","+ddlDepo.SelectedValue+")");
                    //`DTransportDetailsID_I` INT(11), `TransportID_I` INT(11), `BlockID_I` INT(11), `FullTruckRate_N` NUMERIC, `HalfTruckRate_N` NUMERIC, `RatePerBundle_N` NUMERIC, `TransID_I` INT(11), `DistrictID` INT, `DepoID` INT, `DistType` INT, `FyID` varchar(100),depotypea int)
                }
                catch { }
                Messages.Style.Add("display", "none");
                fadeDiv.Style.Add("display", "none");
           
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
}
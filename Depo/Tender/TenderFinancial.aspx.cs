using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_Tender_TenderFinancial : System.Web.UI.Page
{
    string blockName;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = comm.FillDatasetByProc("call GetDepoByBlockName(" + Session["UserID"] + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + ",0)");
            grdblock.DataSource = ds.Tables[0];
            grdblock.DataBind();
            DataSet ds2 = comm.FillDatasetByProc("call GetDepoByBlockName(" + Session["UserID"] + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + ",2)");
            GrdTranportRate.DataSource = ds2.Tables[0];
            GrdTranportRate.DataBind();
        }
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
    protected void btnSaveCheckList_Click(object sender, EventArgs e)
    {
        comm.FillDatasetByProc("call depo_Tendercommercialrate(1," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + ",0,0,0,0,0,0," + Session["UserID"] + ")");
        foreach (GridViewRow grdrow in GrdTranportRate.Rows)
        {
            
                try
                {
                    //obTransportDetails.FullTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtEstimateAmount")).Text);
                    //obTransportDetails.HalfTruckRate_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtAvailableAmount")).Text);
                    //obTransportDetails.RatePerBundle_N = Convert.ToDouble(((TextBox)grdrow.FindControl("txtrequestAmount")).Text);
                    //TenderID_Ia int,TenderParID_Ia int ,BlockIDa int ,DistinctIDa int,DepoIDa int,FullTrucka int,HalftTrucka int,PerBundlea int,UserID_Ia int
                    HiddenField hdnDepoTrn = (HiddenField)grdrow.FindControl("hdnDepoTrn");
                    comm.FillDatasetByProc("call depo_Tendercommercialrate(0," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + ",0,0," + hdnDepoTrn.Value + "," + ((TextBox)grdrow.FindControl("txtEstimateAmount0")).Text + "," + ((TextBox)grdrow.FindControl("txtAvailableAmount0")).Text + "," + ((TextBox)grdrow.FindControl("txtrequestAmount0")).Text + "," + Session["UserID"] + ")");

                }
                catch { }
            
        }
        foreach (GridViewRow grdrow in grdblock.Rows)
        {
           
                try
                {
                    HiddenField hdnDistrictID = (HiddenField)grdrow.FindControl("hdnHeadId");
                    HiddenField hdnblockTrn = (HiddenField)grdrow.FindControl("hdnblockTrn");
                    comm.FillDatasetByProc("call depo_Tendercommercialrate(0," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["TDId"])) + "," + Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["Cid"])) + "," + hdnblockTrn.Value + "," + hdnDistrictID.Value + ",0," + ((TextBox)grdrow.FindControl("txtEstimateAmount")).Text + "," + ((TextBox)grdrow.FindControl("txtAvailableAmount")).Text + "," + ((TextBox)grdrow.FindControl("txtrequestAmount")).Text + "," + Session["UserID"] + ")");

                }
                catch { }
        }
        Response.Redirect("VIEW003_TenderParticipent.aspx");
    }
}
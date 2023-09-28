using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_Tender_TenderReport : System.Web.UI.Page
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
    protected void Button2_Click(object sender, EventArgs e)
    {
     DataSet dd=comm.FillDatasetByProc("call USP_DepoTenderReport("+ddlTender.SelectedValue+")");
     GridView1.DataSource = dd.Tables[0];
     GridView1.DataBind();
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
}
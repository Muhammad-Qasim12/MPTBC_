using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_Tender_GetTenderDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = null;
    string blockName;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTender();
        }

    }
    public void LoadTender()
    {
        // obTender = new Vehicle003_Tender();
        obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc("call Depo_TenderDetailsLoad(0," + Session["UserID"].ToString() + ")");
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataValueField = "TenderId_I";
        try
        {
            //   obTender.TenderID_I = 0;

            ddlTenderID_I.DataSource = ds.Tables[0];
            ddlTenderID_I.DataBind();
        }
        catch (Exception ex) { }
        finally {  }

        ddlTenderID_I.Items.Insert(0, new ListItem("Select", "0"));
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
    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
      DataSet dd=  obCommonFuction.FillDatasetByProc("call GetTenderDetails("+Session["UserID"]+","+ddlTenderID_I.SelectedValue+")");
      grdblock.DataSource = dd.Tables[0];
      grdblock.DataBind();
      Button2.Enabled = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("call depo_SavetenderFinal(2," + ddlTenderID_I.SelectedValue + ",0,0," + Session["UserID"] + ")");
        foreach (GridViewRow grdrow in grdblock.Rows)
        {

            try
            {
                //TenderID, DistrictID, PartyID, UserID
               
                if (((CheckBox)grdrow.FindControl("CheckBox1")).Checked)
                {
                    HiddenField hdnDistrictID = (HiddenField)grdrow.FindControl("hdDistrict");
                    HiddenField HdPartyID = (HiddenField)grdrow.FindControl("HDTenderParID");
                    obCommonFuction.FillDatasetByProc("call depo_SavetenderFinal(0," + ddlTenderID_I.SelectedValue + "," + hdnDistrictID.Value + "," + HdPartyID.Value + "," + Session["UserID"] + ")");
                }
            }
            catch { }

        }
        grdblock.DataSource = null;
        grdblock.DataBind();
        ddlTenderID_I.SelectedIndex = 0;
        lblMess.Text = "Data Saved";
    }
}
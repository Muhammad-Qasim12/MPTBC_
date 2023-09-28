using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;

public partial class Distribution_TentetiveDemand : System.Web.UI.Page
{
    DataSet ds;
    float FirstDtaChk, IteamRowChk;
    CommonFuction objEx = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    string strclasses = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    public void GridFill()
    {
        
        foreach (ListItem item in ddlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + "," + item.Value;
            }

        }
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();

        ds = new DataSet();
        ds = objEx.FillDatasetByProc("Call USP_DISO001_TentativeDemandHistory('" + ddlYear.SelectedItem.Text + "',0," + int.Parse(ddlDistrict.SelectedItem.Value.ToString()) + "," + int.Parse(ddlMedum.SelectedItem.Value.ToString()) + ",'" + strclasses + "',0)");
        DlHsty.RepeatColumns = ds.Tables[0].Rows.Count;
        DlHsty.DataSource = ds.Tables[0];
        DlHsty.DataBind();

        
    }
    protected void DlHsty_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            GridView GvChild = (GridView)e.Item.FindControl("GvChild");
            HtmlControl tdRow = (HtmlControl)e.Item.FindControl("tdRow");

            Label lblBlockID = (Label)e.Item.FindControl("lblBlockID");
            // Label lblTiTleID = (Label)e.Item.FindControl("lblTiTleID");
            Label lblDistrictID = (Label)e.Item.FindControl("lblDistrictID");

            GvChild.DataSource = objEx.FillDatasetByProc("Call USP_DISO001_TentativeDemandHistory('" + ddlYear.SelectedItem.Text + "'," + int.Parse(lblBlockID.Text) + "," + int.Parse(ddlDistrict.SelectedItem.Value.ToString()) + "," + int.Parse(ddlMedum.SelectedItem.Value.ToString()) + ",'" + strclasses + "',1)");
            GvChild.DataBind();

            FirstDtaChk = 1;
            if (IteamRowChk == null || IteamRowChk == 0)
            {
                IteamRowChk = 1;
                tdRow.Attributes.Add("Style", "width:100px;");
                // GvChild.Width = 450;
            }
            else
            {
                //GvChild.Width = 300;
                tdRow.Attributes.Add("Style", "width:0px;padding:0!important; text-align:center!important;");
            }
        }
    }
    protected void GvChild_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTitleHindi_V = (Label)e.Row.FindControl("lblTitleHindi_V");
            Label lblTiTleID = (Label)e.Row.FindControl("lblTiTleID");
            Label lblCurrent3 = (Label)e.Row.FindControl("lblCurrent3");
            Label lblCurrent2 = (Label)e.Row.FindControl("lblCurrent2");
            Label lblCurrent1 = (Label)e.Row.FindControl("lblCurrent1");
            Label lblBlockID = (Label)e.Row.FindControl("lblBlockID");
            Label lblDistrictID = (Label)e.Row.FindControl("lblDistrictID");
            TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
            Label lblAcYear3 = (Label)e.Row.FindControl("lblAcYear3");
            Label lblAcYear2 = (Label)e.Row.FindControl("lblAcYear2");
            Label lblAcYear1 = (Label)e.Row.FindControl("lblAcYear1");



            HtmlControl tdGvRow = (HtmlControl)e.Row.FindControl("tdGvRow");
            HtmlControl TdGvId = (HtmlControl)e.Row.FindControl("TdGvId");



            ds = objTentativeDemandHistory.TentativeHistoryWithYear(int.Parse(lblTiTleID.Text), lblAcYear3.Text, int.Parse(lblBlockID.Text), int.Parse(ddlDistrict.SelectedItem.Value), int.Parse(ddlMedum.SelectedItem.Value), int.Parse(ddlClass.SelectedItem.Value));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCurrent3.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lblCurrent3.Text = "0";
            }
            ds = objTentativeDemandHistory.TentativeHistoryWithYear(int.Parse(lblTiTleID.Text), lblAcYear2.Text, int.Parse(lblBlockID.Text), int.Parse(ddlDistrict.SelectedItem.Value), int.Parse(ddlMedum.SelectedItem.Value), int.Parse(ddlClass.SelectedItem.Value));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCurrent2.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lblCurrent2.Text = "0";
            }
            ds = objTentativeDemandHistory.TentativeHistoryWithYear(int.Parse(lblTiTleID.Text), lblAcYear1.Text, int.Parse(lblBlockID.Text), int.Parse(ddlDistrict.SelectedItem.Value), int.Parse(ddlMedum.SelectedItem.Value), int.Parse(ddlClass.SelectedItem.Value));
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCurrent1.Text = ds.Tables[0].Rows[0][0].ToString();

                ds = objTentativeDemandHistory.TentativeDemandCheckQty(int.Parse(lblTiTleID.Text), ddlYear.SelectedItem.Text, int.Parse(lblBlockID.Text), int.Parse(lblDistrictID.Text));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        txtQty.Text = lblCurrent1.Text;
                    }
                    else
                    {
                        txtQty.Text = ds.Tables[0].Rows[0][0].ToString();
                    }
                }
                else
                {
                    txtQty.Text = lblCurrent1.Text;
                }


            }
            else
            {
                lblCurrent1.Text = "0";
                txtQty.Text = "0";
            }

            if (FirstDtaChk == null || FirstDtaChk == 0)
            {
                TdGvId.Attributes.Add("Style", "font-size: 8pt;width:50px;text-align:left;padding-left:3px;height:35px;");
                tdGvRow.Attributes.Add("Style", "width:100px;");
                lblTitleHindi_V.Visible = true;
            }
            else
            {
                TdGvId.Attributes.Add("Style", "width:50px;text-align:left;height:35px;");
                tdGvRow.Attributes.Add("Style", "width:0px;display:none;padding:0!important; ");
                lblTitleHindi_V.Visible = false;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text == "Select" && ddlDistrict.SelectedItem.Text == "Select" && ddlMedum.SelectedItem.Text == "Select" && ddlYear.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select All Fields.');</script>");
        }
        else
        {

            string SaveSts = "";
            foreach (DataListItem dti in DlHsty.Items)
            {
                Label lblBlockID = (Label)dti.FindControl("lblBlockID");
                Label lblDistrictID = (Label)dti.FindControl("lblDistrictID");
                GridView GvChild = (GridView)dti.FindControl("GvChild");
                foreach (GridViewRow gv in GvChild.Rows)
                {
                    Label lbltTiTleID = (Label)gv.FindControl("lbltTiTleID");
                    TextBox txtQty = (TextBox)gv.FindControl("txtQty");
                    if (txtQty.Text != "" && txtQty.Text != "0")
                    {

                        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
                        objTentativeDemandHistory.DemandId = 0;
                        objTentativeDemandHistory.AcYearId = ddlYear.SelectedItem.Text;
                        objTentativeDemandHistory.TitleId = int.Parse(lbltTiTleID.Text);
                        objTentativeDemandHistory.NoOfBooks = int.Parse(txtQty.Text);
                        objTentativeDemandHistory.UserId = 2001;
                        objTentativeDemandHistory.DistrictID_12 = int.Parse(lblDistrictID.Text);
                        objTentativeDemandHistory.BlockID_12 = int.Parse(lblBlockID.Text);
                        int i = objTentativeDemandHistory.InsertUpdate();
                        if (i > 0)
                        {
                            SaveSts = "Yes";
                        }
                    }
                }
            }
            if (SaveSts == "Yes")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                ddlYear.SelectedIndex = 0;
                ddlMedum.SelectedIndex = 0;
                ddlDistrict.SelectedIndex = 0;
                ddlClass.SelectedIndex = 0;
                DlHsty.DataSource = string.Empty;
                DlHsty.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Not Saved.');</script>");
            }
        }

    }
    protected void ddlMedum_Init(object sender, EventArgs e)
    {
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlMedum.DataSource = objTentativeDemandHistory.MedumFill();
        ddlMedum.DataValueField = "MediumTrno_I";
        ddlMedum.DataTextField = "MediunNameHindi_V";
        ddlMedum.DataBind();
        ddlMedum.Items.Insert(0, "Select");
    }
    protected void ddlClass_Init(object sender, EventArgs e)
    {

        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlClass.DataSource = objTentativeDemandHistory.ClassFill();
        ddlClass.DataValueField = "ClassTrno_I";
        ddlClass.DataTextField = "Classdet_V";
        ddlClass.DataBind();
        //ddlClass.Items.Insert(0, "Select");
    }

    protected void ddlDistrict_Init(object sender, EventArgs e)
    {
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlDistrict.DataSource = objTentativeDemandHistory.DistrictFill();
        ddlDistrict.DataValueField = "DistrictTrno_I";
        ddlDistrict.DataTextField = "District_Name_Hindi_V";
        ddlDistrict.DataBind();
        ddlDistrict.Items.Insert(0, "Select");

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text == "Select" && ddlDistrict.SelectedItem.Text == "Select" && ddlMedum.SelectedItem.Text == "Select" && ddlYear.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select All Fields.');</script>");
        }
        else
        {
            GridFill();
        }

    }
    protected void ddlYear_Init(object sender, EventArgs e)
    {
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlYear.DataSource = objTentativeDemandHistory.TentativeDemandAcadminYearFill();
        ddlYear.DataTextField = "AcYear";
        ddlYear.DataValueField = "AcYear";
        ddlYear.DataBind();
        ddlYear.Items.Insert(0, "Select");
    }
}

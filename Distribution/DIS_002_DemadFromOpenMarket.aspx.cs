using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Distrubution_DIS_002_DemadFromOpenMarket : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    Dis_OpenMarketDemand objOpenMarketDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        if (!IsPostBack)
        {
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
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
        ddlClass.DataTextField = "ClassDesc_V";
        ddlClass.DataBind();
        //ddlClass.Items.Insert(0, "Select");
    }

    protected void ddlDepoMaster_Init(object sender, EventArgs e)
    {

        //objOpenMarketDemand = new Dis_OpenMarketDemand();
        //ddlDepoMaster.DataSource = objOpenMarketDemand.Depofill();
        //ddlDepoMaster.DataValueField = "DepoTrno_I";
        //ddlDepoMaster.DataTextField = "DepoName_V";
        //ddlDepoMaster.DataBind();
        //ddlDepoMaster.Items.Insert(0, "Select");

        ddlDepoMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
        ddlDepoMaster.DataValueField = "DepoTrno_I";
        ddlDepoMaster.DataTextField = "DepoName_V";
        ddlDepoMaster.DataBind();
        ddlDepoMaster.Items.Insert(0, "Select");
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedItem.Text != "Select" && ddlMedum.SelectedItem.Text != "Select")
            {
                string strclasses = "";
                foreach (ListItem item in ddlClass.Items)
                {
                    if (item.Selected)
                    {
                        strclasses = strclasses + "," + item.Value;
                    }

                }

                objOpenMarketDemand = new Dis_OpenMarketDemand();
                //objOpenMarketDemand.ClassTrno_I = int.Parse(ddlClass.SelectedItem.Value);
                objOpenMarketDemand.MediumTrno_I = int.Parse(ddlMedum.SelectedItem.Value);
                objOpenMarketDemand.DepoTrno_I = int.Parse(ddlDepoMaster.SelectedValue);
                objOpenMarketDemand.Session_v = (ddlSessionYear.SelectedValue).ToString();
                GrdBooksMaster.DataSource = objOpenMarketDemand.BooksfillWithClass(strclasses);
                GrdBooksMaster.DataBind();
                if (GrdBooksMaster.Rows.Count > 0)
                {
                    btnSave.Visible = true;
                }
            }
        }
        catch { }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlClass.SelectedItem.Text != "Select" && ddlDepoMaster.SelectedItem.Text != "-Select-" && ddlMedum.SelectedItem.Text != "Select")
        {

            string SaveSts = "No";
            objOpenMarketDemand = new Dis_OpenMarketDemand();
            foreach (GridViewRow gv in GrdBooksMaster.Rows)
            {
                Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                Label lblDepoTrno_I = (Label)gv.FindControl("lblDepoTrno_I");
                Label lblMedium_I = (Label)gv.FindControl("lblMedium_I");
                Label lblClassTrno_I = (Label)gv.FindControl("lblClassTrno_I");
                Label lblSession_v = (Label)gv.FindControl("lblSession_v");
                

                Label lblLastYearSaleBook = (Label)gv.FindControl("lblLastYearSaleBook");
                Label lblCurntYearOpenBook = (Label)gv.FindControl("lblCurntYearOpenBook");
                Label txtOpenTentetiveStock = (Label)gv.FindControl("txtOpenTentetiveStock");
                TextBox txtNetDemand = (TextBox)gv.FindControl("txtNetDemand");
                TextBox txtRemark = (TextBox)gv.FindControl("txtRemark");

                objOpenMarketDemand.ClassTrno_I =int.Parse(lblClassTrno_I.Text);
                objOpenMarketDemand.CurntNetDmnd_I = int.Parse(txtNetDemand.Text);
                objOpenMarketDemand.CurntYearDmndBook_I = int.Parse(txtNetDemand.Text);
                objOpenMarketDemand.DepoTrno_I = int.Parse(lblDepoTrno_I.Text);
                objOpenMarketDemand.LstYearSaleBook_I = int.Parse(lblLastYearSaleBook.Text);
                objOpenMarketDemand.MediumTrno_I = int.Parse(lblMedium_I.Text);
                objOpenMarketDemand.OpenDmndStock_I = int.Parse(txtOpenTentetiveStock.Text);
                objOpenMarketDemand.Remark_v = txtRemark.Text;
                objOpenMarketDemand.Session_v = lblSession_v.Text;
                objOpenMarketDemand.TitleID_I = int.Parse(lblTitleID_I.Text);
                objOpenMarketDemand.UserID_I = Convert.ToInt32(Session["UserID"]);
               


                if (Request.QueryString["ID"] == null)
                {
                    objOpenMarketDemand.OpnMrktId_I = 0;
                }
                else
                {
                    objOpenMarketDemand.OpnMrktId_I = int.Parse(Request.QueryString["ID"].ToString());
                }

                int i = objOpenMarketDemand.InsertUpdate();
                if (i > 0)
                {
                    SaveSts = "Yes";
                }
            }
            if (SaveSts == "Yes")
            {
                if (Request.QueryString["ID"] != null)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    mainDiv.Style.Add("display", "block");
                    mainDiv.CssClass = "response-msg success ui-corner-all";
                    lblmsg.Style.Add("display", "block");
                    lblmsg.Text = "Records updated sucessfully";
                    
                }
                else
                {
                   // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    obCommonFuction.EmptyTextBoxes(this);
                    GrdBooksMaster.DataSource = string.Empty;
                    //GrdBooksMaster.DataBind();
                    mainDiv.Style.Add("display", "block");
                    mainDiv.CssClass = "response-msg success ui-corner-all";
                    lblmsg.Style.Add("display", "block");
                    lblmsg.Text = "Records Saved sucessfully";
                }

            }
        }
        else
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select All Field.');</script>");
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "Please select all fields";
        }
    }
}

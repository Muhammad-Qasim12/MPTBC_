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
using System.Globalization;

public partial class Distribution_dreport4 : System.Web.UI.Page
{
    DataSet ds;
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    InterDepoTransfer ObjInterDepoTransfer = null;
    CommonFuction obCommonFuction = new CommonFuction();
    Random rdm = new Random();
    string ChallanNo;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int ParentDepotId_I = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtOrderNo.Text = System.DateTime.Now.ToString("yyddMMssmm") + RandomNumber();
            GridFillLoad();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    public void GridFillLoad()
    {
        try
        {
            if (ddlReqDepo.SelectedItem.Text != "Select")
            {
                txtOrderNo.Text = System.DateTime.Now.ToString("yyddMMssmm") + RandomNumber();
                //ObjInterDepoTransfer = new InterDepoTransfer();
                //ObjInterDepoTransfer.DemandingDepotID = int.Parse(ddlReqDepo.SelectedValue.ToString());
                GrdDepoQtyMaster.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPO002_InterDepoTransferShowDataNew2(0," + ddlReqDepo.SelectedItem.Value.ToString() + ",'" + ddlOrderNo.SelectedItem.Text + "',0,1,'"+DdlACYear.SelectedItem.Text+"')");//ObjInterDepoTransfer.DemandFill();
                GrdDepoQtyMaster.DataBind();
                if (GrdDepoQtyMaster.Rows.Count > 0)
                {
                    tr1.Visible = true;
                    btnSave.Visible = true;
                    txtChallanDate.Text = "";
                }
                else
                {
                    tr1.Visible = false;
                    btnSave.Visible = false;
                    txtChallanDate.Text = "";
                }
            }
            else
            {
                GrdDepoQtyMaster.DataSource = string.Empty;
                GrdDepoQtyMaster.DataBind();
                tr1.Visible = false;
                btnSave.Visible = false;
                txtChallanDate.Text = "";
            }
        }
        catch { }

    }

    protected void lnkBookDetails_Click(object sender, CommandEventArgs e)
    {
        int Title = Convert.ToInt16(e.CommandArgument);
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        GrdPopUp.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS_GetDepoWiseTitleStock(" + Title + ")");
        GrdPopUp.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void GrdDepoQtyMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DropDownList ddlDepoSupp = (DropDownList)e.Row.FindControl("ddlDepoSupp");
            ObjInterDepoTransfer = new InterDepoTransfer();

            if (RadioButtonList1.SelectedValue == "2" || RadioButtonList1.SelectedValue == "4")
            {
                ddlDepoSupp.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectMainBookDepot1()");
                ddlDepoSupp.DataTextField = "DepoName_V";
                ddlDepoSupp.DataValueField = "DepoTrno_I";
                ddlDepoSupp.DataBind();
                ddlDepoSupp.Items.Insert(0, "Select");

                if (RadioButtonList1.SelectedValue == "4")
                { 
                DataSet dd = obCommonFuction.FillDatasetByProc("call USP_ADm_SatelliteDepo(" + ddlReqDepo.SelectedValue + ")");
                ParentDepotId_I = Convert.ToInt32(dd.Tables[0].Rows[0]["ParentDepotId_I"]);
                if (ParentDepotId_I != 0)
                {
                    ddlDepoSupp.SelectedValue = Convert.ToString(ParentDepotId_I);
                    ddlDepoSupp.Enabled = false;

                }
                else
                {
                    ddlDepoSupp.Enabled = true;
                }
                }
            }
            else
            {

                ddlDepoSupp.DataSource = ObjInterDepoTransfer.DepoFill();
                ddlDepoSupp.DataTextField = "DepoName_V";
                ddlDepoSupp.DataValueField = "DepoTrno_I";
                ddlDepoSupp.DataBind();
                ddlDepoSupp.Items.Insert(0, "Select");
               
            }
          
        }
        DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectMainBookDepot()");
        DropDownList1.DataTextField = "DepoName_V";
        DropDownList1.DataValueField = "DepoTrno_I";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
    }
    protected void ddlDepoSupp_Init(object sender, EventArgs e)
    {


    }

    protected void ddlReqDepo_Init(object sender, EventArgs e)
    {

        ObjInterDepoTransfer = new InterDepoTransfer();
        ds = ObjInterDepoTransfer.RequestedDepoFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlReqDepo.DataSource = ds.Tables[0];
            ddlReqDepo.DataTextField = "DepoName_V";
            ddlReqDepo.DataValueField = "DemandingDepotID";
            ddlReqDepo.DataBind();
            ddlReqDepo.Items.Insert(0, "Select");
        }
        else
        {
            ddlReqDepo.DataSource = string.Empty;
            ddlReqDepo.DataBind();
            ddlReqDepo.Items.Insert(0, "Select");

        }
    }
    protected void ddlOrderNo_Init(object sender, EventArgs e)
    {
        ddlOrderNo.DataSource = string.Empty;
        ddlOrderNo.DataBind();
        ddlOrderNo.Items.Insert(0, "Select");
    }
    protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void ddlReqDepo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        { TextBox1.Visible = false;
        if (ddlReqDepo.SelectedItem.Text != "Select")
        {
            ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPO002_InterDepoTransferShowData(0," + ddlReqDepo.SelectedItem.Value.ToString() + ",'',0,5)");
            ddlOrderNo.DataTextField = "ReqNoFromDpt";
            ddlOrderNo.DataBind();
            ddlOrderNo.Items.Insert(0, "Select");
            ddlOrderNo.Visible = true;
        }
        else
        {
            ddlOrderNo.DataSource = string.Empty;
            ddlOrderNo.DataBind();
            ddlOrderNo.Items.Insert(0, "Select");
        }

        }
        
    }
    private string RandomNumber()
    {
        return (rdm.Next(2, 100)).ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string SaveSts = "No", OrderDate = "";
        ObjInterDepoTransfer = new InterDepoTransfer();
        if (txtChallanDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtChallanDate.Text, cult);
            }
            catch { OrderDate = "NoDate"; }
        }
        if (OrderDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Order Date.');</script>");
        }
        else if (DateTime.Parse(txtChallanDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Order date cannot greater than current date.');</script>");
        }
        else
        {
            string ChkRoleBx = "No";
            foreach (GridViewRow gv in GrdDepoQtyMaster.Rows)
            {
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                if (chkSelect.Checked == true)
                {
                    ChkRoleBx = "Ok";
                }
            }
            if (ChkRoleBx == "No")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select at least on Check Box.');</script>");
            }
            else
            {
                ChallanNo = txtOrderNo.Text;
                foreach (GridViewRow gv in GrdDepoQtyMaster.Rows)
                {
                    Label lblDemandTrNo = (Label)gv.FindControl("lblDemandTrNo");
                    Label lblDemandingDepotID = (Label)gv.FindControl("lblDemandingDepotID");
                    Label lblNetDemand = (Label)gv.FindControl("lblNetDemand");
                    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                    Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                    Label lblReqNo = (Label)gv.FindControl("lblReqNo");
                    DropDownList ddlDepoSupp = (DropDownList)gv.FindControl("ddlDepoSupp");
                    TextBox txtQtySupp = (TextBox)gv.FindControl("txtQtySupp");
                    Label lblDmdStk = (Label)gv.FindControl("lblDmdStk");
                    Label lblIsScheme = (Label)gv.FindControl("lblIsScheme");
                    Label lblTotRemaing = (Label)gv.FindControl("lblTotRemaing");

                    if ((chkSelect.Checked == true) && (txtQtySupp.Text != "" || txtQtySupp.Text != "0") && ddlDepoSupp.SelectedItem.Text != "Select")
                    {
                       
                            ObjInterDepoTransfer.ChallanNo = ddlDepoSupp.SelectedItem.Value.ToString() + ChallanNo;
                            ObjInterDepoTransfer.ReqNo = lblReqNo.Text;
                            ObjInterDepoTransfer.DemandingDepotID = int.Parse(lblDemandingDepotID.Text);
                            ObjInterDepoTransfer.NetDemand = int.Parse(lblNetDemand.Text.ToString());
                            ObjInterDepoTransfer.SupplierDepoID = int.Parse(ddlDepoSupp.SelectedItem.Value.ToString());
                            ObjInterDepoTransfer.NoOfBookTransferd = int.Parse(txtQtySupp.Text);
                            ObjInterDepoTransfer.TitleID_I = int.Parse(lblTitleID_I.Text);
                            ObjInterDepoTransfer.IsScheme = int.Parse(lblIsScheme.Text);
                            ObjInterDepoTransfer.DemandTrNo = int.Parse(lblDemandTrNo.Text);
                            ObjInterDepoTransfer.ChalanDate = DateTime.Parse(txtChallanDate.Text, cult);

                            if (Request.QueryString["ID"] != null)
                            {
                                ObjInterDepoTransfer.DemandChildTrNo = int.Parse(Request.QueryString["ID"].ToString());
                            }
                            else
                            {
                                ObjInterDepoTransfer.DemandChildTrNo = 0;
                            }
                            int i = ObjInterDepoTransfer.InsertUpdate();
                            if (i > 0)
                            {

                            }
                            SaveSts = "Yes";
                        
                    }
                }
                if (SaveSts == "Yes")
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        //Response.Redirect("ViewLabMaster.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                        GridFillLoad();
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Check at least one check box.');</script>");
                }
            }
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "2")
        {
            ddlReqDepo.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM010_DepomasterLoadNew(0)");
            ddlReqDepo.DataTextField = "DepoName_V";
            ddlReqDepo.DataValueField = "DepoTrno_I";
            ddlReqDepo.DataBind();
            ddlReqDepo.Items.Insert(0, "Select");
            TextBox1.Visible = false;
            ddlOrderNo.Visible = false;
        }
        else if (RadioButtonList1.SelectedValue == "4")
        {
            DataSet dd = obCommonFuction.FillDatasetByProc("call USP_ADm_SatelliteDepo(0)");
            //ParentDepotId_I =Convert.ToInt32( dd.Tables[0].Rows[0]["ParentDepotId_I"]);
            ddlReqDepo.DataSource = dd.Tables[0];

            ddlReqDepo.DataTextField = "DepoName_V";
            ddlReqDepo.DataValueField = "DepoTrno_I";
            ddlReqDepo.DataBind();
            ddlReqDepo.Items.Insert(0, "Select");
            TextBox1.Visible = true;
            ddlOrderNo.Visible = false;
        }
        else if (RadioButtonList1.SelectedValue == "1")
        {
            ddlOrderNo.Visible = true;
        }
        else {
            ddlOrderNo.Visible = false;
            TextBox1.Visible = false;
        }
        
     
        GrdDepoQtyMaster.DataSource = null;
        GrdDepoQtyMaster.DataBind();
        
        
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            TextBox1.Visible = false;
            GridFillLoad();


        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            string depoIds = "";
            if (ddlReqDepo.SelectedValue == "9")
                depoIds = "10,19";
            else if (ddlReqDepo.SelectedValue == "7")
                depoIds = "17";
            else if (ddlReqDepo.SelectedValue == "11")
                depoIds = "11";
            else if (ddlReqDepo.SelectedValue == "13")
                depoIds = "16";

            TextBox1.Visible = false;
            ddlOrderNo.Visible = false;
            string IDa;
            if (DdlScheme.SelectedValue  == "1")
            {
                IDa = "1";
            }
            else
            {
                IDa = "2";
            }
            //GrdDepoQtyMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_InsertDepoOrder(1,'" + DdlACYear.SelectedValue + "','" + ddlReqDepo.SelectedValue + "'," + DdlScheme.SelectedValue + ",0)");
            GrdDepoQtyMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_InsertDepoOrder_UAndENew(" + IDa.ToString ()+ ",'" + DdlACYear.SelectedValue + "','" + depoIds + "'," + DdlScheme.SelectedValue + ",0)");
            GrdDepoQtyMaster.DataBind();
            if (GrdDepoQtyMaster.Rows.Count > 0)
            {
                tr1.Visible = true;
                btnSave.Visible = true;
                txtChallanDate.Text = "";
            }
            else
            {
                tr1.Visible = false;
                btnSave.Visible = false;
                txtChallanDate.Text = "";
            }
            //USP_InsertDepoOrder
        }
        else if (RadioButtonList1.SelectedValue == "3")
        {
            TextBox1.Visible = false;
            ddlOrderNo.Visible = false;
            GrdDepoQtyMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_InsertDepoOrder(2,'" + DdlACYear.SelectedValue + "','" + ddlReqDepo.SelectedValue + "'," + DdlScheme.SelectedValue + ",0)");
            GrdDepoQtyMaster.DataBind();
            if (GrdDepoQtyMaster.Rows.Count > 0)
            {
                tr1.Visible = true;
                btnSave.Visible = true;
                txtChallanDate.Text = "";
            }
            else
            {
                tr1.Visible = false;
                btnSave.Visible = false;
                txtChallanDate.Text = "";
            }
            //USP_InsertDepoOrder
        }
        else if (RadioButtonList1.SelectedValue == "4")
        {
            TextBox1.Visible = true;
            ddlOrderNo.Visible = false;
            GrdDepoQtyMaster.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_InsertDepoOrder(3,'" + DdlACYear.SelectedValue + "','" + ddlReqDepo.SelectedValue + "'," + DdlScheme.SelectedValue + "," + TextBox1.Text + ")");
            GrdDepoQtyMaster.DataBind();

            if (GrdDepoQtyMaster.Rows.Count > 0)
            {
                tr1.Visible = true;
                btnSave.Visible = true;
                txtChallanDate.Text = "";
            }
            else
            {
                tr1.Visible = false;
                btnSave.Visible = false;
                txtChallanDate.Text = "";
            }
            //USP_InsertDepoOrder
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GrdDepoQtyMaster.Rows.Count; i++)
        {
            try { 

            ((DropDownList)GrdDepoQtyMaster.Rows[i].FindControl("ddlDepoSupp")).SelectedValue = DropDownList1.SelectedValue;
            }
            catch { }
        }
    }
}

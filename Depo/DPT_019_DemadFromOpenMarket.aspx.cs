using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Distrubution_DIS_002_DemadFromOpenMarket : System.Web.UI.Page
{
    decimal one = 0;
    decimal two = 0;
    decimal Three = 0;
    decimal Four = 0;
    decimal Five = 0;
 
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    Dis_OpenMarketDemand objOpenMarketDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    string id;
    int count; ClassMaster obClass = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
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
             CommonFuction obcommonfun = new CommonFuction();
             grdSendForApproval.DataSource = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',4)");
             grdSendForApproval.DataBind();
             if (grdSendForApproval.Rows.Count > 0)
             {

                 btnsend.Visible = true;
             }
             obClass = new ClassMaster();
             DataSet dtclass = obClass.Select();
             obClass.ClassTrno_I = 0;

             CheckBoxList1.DataTextField = "Classdet_V";
             CheckBoxList1.DataValueField = "ClassTrno_I";
             CheckBoxList1.DataSource = dtclass;
             CheckBoxList1.DataBind();
        }
       

    }
    protected void dddd(object sender, EventArgs e)
    {
        CommonFuction obcommonfun = new CommonFuction();
        grdSendForApproval.DataSource = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',4)");
        grdSendForApproval.DataBind();
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
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
    //protected void ddlClass_Init(object sender, EventArgs e)
    //{

    //    objTentativeDemandHistory = new Dis_TentativeDemandHistory();
    //    ddlClass.DataSource = objTentativeDemandHistory.ClassFill();
    //    ddlClass.DataValueField = "ClassTrno_I";
    //    ddlClass.DataTextField = "Classdet_V";
    //    ddlClass.DataBind();
    //    ddlClass.Items.Insert(0, "Select");
    //}

    protected void ddlDepoMaster_Init(object sender, EventArgs e)
    {

    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
            //if (ddlClass.SelectedItem.Text != "Select" && ddlMedum.SelectedItem.Text != "Select")
            //{
                
            //}
        //}
        //catch { }
    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        foreach (ListItem chk in CheckBoxList1.Items)
        {
            if (chk.Selected == true)
            {
                if (count == 0)
                {
                    count = count + 1;
                    id = chk.Value;
                }
                else
                {
                    id = id + "," + chk.Value;
                }
            }
        }
        try { 
        CommonFuction obcommonfun = new CommonFuction();
        
        //DataTable dt = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(,," + (id) + ",,2)").Tables[0];

        DataSet dt = obcommonfun.FillDatasetByProc(@"select ifnull(dd.IsSendApproval,0)IsSendApproval,  td.TitleHindi_V, OpnMrktId_I, Session_v, dd.DepoTrno_I, td.ClassTrno_I, td.TitleID_I, td.Medium_I, ifnull(LstYearSaleBook_I,0) as LastYearSale, ifnull(CurntYearDmndBook_I,0) as CurntYarNeed, ifnull(OpenDmndStock_I,0) as OpnMrketStk, ifnull(CurntNetDmnd_I,0) as NetDemand, Remark_v, UserID_I, TransId_D
 from    acd_titledetail td  left join dis_openmarketdemad dd    on td.TitleID_I =dd.TitleID_I   and DepoTrno_I =" + Convert.ToInt32(Session["UserID"]) + "   and Session_v ='" + ddlSessionYear.SelectedValue + "'where  td.Medium_I=" + int.Parse(ddlMedum.SelectedItem.Value) + " and td.ClassTrno_I in (" + id + ")  and ifnull(IsSendApproval,0)=0 and IFNULL(bookchangestatus,0)<>5 ");
        if (dt.Tables[0].Rows[0]["IsSendApproval"].ToString() == "0")
        {
            GrdBooksMaster.DataSource = dt;
            GrdBooksMaster.DataBind();
        }
        else
        {
            GrdBooksMaster.DataSource = null;
            GrdBooksMaster.DataBind();
        }
        if (GrdBooksMaster.Rows.Count > 0)
        {
            btnSave.Visible = true;
        }
        }
        catch { }
                

    }
    protected void lblCurntYearOpenBook(object sender, EventArgs e)
    {
        try
        {
            GridViewRow grdrow = (GridViewRow)((TextBox)sender).NamingContainer;
           
            TextBox lblCurntYearOpenBook = (TextBox)grdrow.FindControl("lblCurntYearOpenBook");
            TextBox txtOpenTentetiveStock = (TextBox)grdrow.FindControl("txtOpenTentetiveStock");
            TextBox txtNetDemand = (TextBox)grdrow.FindControl("txtNetDemand");
            if (lblCurntYearOpenBook.Text != "" && txtOpenTentetiveStock.Text != "")
            {
             txtNetDemand.Text =  (  Convert.ToInt32(lblCurntYearOpenBook.Text) - Convert.ToInt32(txtOpenTentetiveStock.Text)).ToString();
            }
        }
        catch { }
        
    }





    protected void send(object sender, EventArgs e)
    {
        CommonFuction obcommonfun = new CommonFuction();
        obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',3)");

        grdSendForApproval.DataSource = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',4)");
        grdSendForApproval.DataBind();
        if (grdSendForApproval.Rows.Count == 0)
        {

            btnsend.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Request  send successfully to distribution section .');</script>");
            MailHelper mail = new MailHelper();

            MailHelper.SendMail("anupam.tripathi@mapit.gov.in", "", "Demand  of class 1-12 for Acedemic year " + ddlSessionYear.SelectedItem.Text + " has been submitted  -" + Session["UserName"] + "");
            mail.sendMessage("9993146080", "Demand  class 1-12 for Acedemic year " + ddlSessionYear.SelectedItem.Text + " has been submitted -" + Session["UserName"] + "");
        
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlMedum.SelectedItem.Text != "Select")
            {

                string SaveSts = "No";
                objOpenMarketDemand = new Dis_OpenMarketDemand();
                foreach (GridViewRow gv in GrdBooksMaster.Rows)
                {

                    try
                    {
                        Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                        TextBox lblLastYearSaleBook = (TextBox)gv.FindControl("lblLastYearSaleBook");
                        TextBox lblCurntYearOpenBook = (TextBox)gv.FindControl("lblCurntYearOpenBook");
                        TextBox txtOpenTentetiveStock = (TextBox)gv.FindControl("txtOpenTentetiveStock");
                        TextBox txtNetDemand = (TextBox)gv.FindControl("txtNetDemand");
                        HiddenField hd = (HiddenField)gv.FindControl("HiddenField1");
                        // TextBox txtRemark = (TextBox)gv.FindControl("txtRemark");
                       
                        objOpenMarketDemand.ClassTrno_I = int.Parse(hd.Value);
                        objOpenMarketDemand.CurntNetDmnd_I = int.Parse(txtNetDemand.Text);
                        objOpenMarketDemand.CurntYearDmndBook_I = int.Parse(lblCurntYearOpenBook.Text);
                        objOpenMarketDemand.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
                        objOpenMarketDemand.LstYearSaleBook_I = int.Parse(lblLastYearSaleBook.Text);
                        objOpenMarketDemand.MediumTrno_I = int.Parse(ddlMedum.SelectedItem.Value);
                        objOpenMarketDemand.OpenDmndStock_I = int.Parse(txtOpenTentetiveStock.Text);
                        objOpenMarketDemand.Remark_v = "";
                        objOpenMarketDemand.Session_v = ddlSessionYear.SelectedItem.Text;
                        objOpenMarketDemand.TitleID_I = int.Parse(lblTitleID_I.Text);
                        objOpenMarketDemand.UserID_I = Convert.ToInt32(Session["UserID"]);

                        if (Request.QueryString["ID"] == null)
                        {
                            objOpenMarketDemand.OpnMrktId_I = 0;
                        }
                        else
                        {
                            objOpenMarketDemand.OpnMrktId_I = int.Parse(HiddenField2.Value);
                        }

                        int i = objOpenMarketDemand.InsertUpdate();
                        if (i > 0)
                        {
                            SaveSts = "Yes";
                        }
                        
                    }
                    catch { }
                }
                if (SaveSts == "Yes")
                {
                    CommonFuction obcommonfun = new CommonFuction();
                   
                    if (Request.QueryString["ID"] != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        grdSendForApproval.DataSource = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',4)");
                        grdSendForApproval.DataBind();
                        if (grdSendForApproval.Rows.Count > 0)
                        {

                            btnsend.Visible = true;
                        }
                    }
                    else
                    {
                        grdSendForApproval.DataSource = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',4)");
                        grdSendForApproval.DataBind();
                       
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                     //   Response.Redirect("View19.aspx");
                       //obCommonFuction.EmptyTextBoxes(this);
                        GrdBooksMaster.DataSource = string.Empty;

                        GrdBooksMaster.DataBind();
                       // ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
                        if (grdSendForApproval.Rows.Count > 0)
                        {

                            btnsend.Visible = true;
                        }
                    }
                   

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select All Field.');</script>");
            }
            Messages.Style.Add("display", "none");
            fadeDiv.Style.Add("display", "none");
        }
        catch { }
    }
    protected void btn1(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void grdSendForApproval_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        comm.FillDatasetByProc("delete from dis_openmarketdemad where OpnMrktId_I="+grdSendForApproval.DataKeys[e.RowIndex].Value+"");
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('डाटा डिलीट हो चूका है .');</script>");
        CommonFuction obcommonfun = new CommonFuction();
        grdSendForApproval.DataSource = obcommonfun.FillDatasetByProc("call USP_DIS001_OpenDemandDataShow(" + Convert.ToInt32(Session["UserID"]) + "," + int.Parse("0") + "," + int.Parse("0") + ",'" + ddlSessionYear.SelectedValue + "',4)");
        grdSendForApproval.DataBind();
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void grdSendForApproval_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction obcommonfun = new CommonFuction();
        DataSet dt = obcommonfun.FillDatasetByProc(@"select ifnull(dd.IsSendApproval,0)IsSendApproval,  td.TitleHindi_V, OpnMrktId_I, Session_v, dd.DepoTrno_I, td.ClassTrno_I, td.TitleID_I, td.Medium_I, ifnull(LstYearSaleBook_I,0) as LastYearSale, ifnull(CurntYearDmndBook_I,0) as CurntYarNeed, ifnull(OpenDmndStock_I,0) as OpnMrketStk, ifnull(CurntNetDmnd_I,0) as NetDemand, Remark_v, UserID_I, TransId_D
 from    acd_titledetail td  left join dis_openmarketdemad dd    on td.TitleID_I =dd.TitleID_I  where OpnMrktId_I="+grdSendForApproval.SelectedDataKey.Value+"");
        //obCommonFuction.EmptyTextBoxes(this);
        GrdBooksMaster.DataSource = dt;

        GrdBooksMaster.DataBind();
        HiddenField2.Value = grdSendForApproval.SelectedDataKey.Value.ToString();
        btnSave.Visible = true;
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void grdSendForApproval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    Label lblFromNo_I = (Label)e.Row.Cells[3].FindControl("lblLastYearSaleBook");
                    one += lblFromNo_I.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblFromNo_I.Text);
                    //one += e.Row.Cells[3].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[3].Text); 
                }
                catch { }
                try
                {
                    Label lblFromNo_I1 = (Label)e.Row.Cells[4].FindControl("lblCurntYearOpenBook");
                    two += lblFromNo_I1.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblFromNo_I1.Text);
                    //two += e.Row.Cells[4].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[4].Text);
                }
                catch { }
                try
                {
                    Label lblFromNo_I12 = (Label)e.Row.Cells[5].FindControl("txtOpenTentetiveStock");
                    Three += lblFromNo_I12.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblFromNo_I12.Text);
                    //Three += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {
                    Label lblFromNo_I123 = (Label)e.Row.Cells[6].FindControl("txtNetDemand");
                    Four += lblFromNo_I123.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblFromNo_I123.Text);
                    //Four += e.Row.Cells[6].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[6].Text);
                }
                catch { }

            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[3].Text = one.ToString();
            e.Row.Cells[4].Text = two.ToString();
            e.Row.Cells[5].Text = Three.ToString();
            e.Row.Cells[6].Text = Four.ToString();
            
            
        }
    }
}

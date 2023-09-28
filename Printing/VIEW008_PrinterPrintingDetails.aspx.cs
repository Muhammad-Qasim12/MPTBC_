using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
public partial class Printing_VIEW008_PrinterPrintingDetails : System.Web.UI.Page
{
    DataSet ds;
    PRIN_PrinterBooksPrintingDetails obj = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction objCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
       // txtDate.Text = System.DateTime.Now.ToShortDateString();
        if (!Page.IsPostBack) {
            DdlACYear.DataSource = objCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            //DdlACYear.SelectedValue = objCommonFuction.GetFinYear();
            //DdlACYear.Enabled = false;
            txtDate.Text = System.DateTime.Now.ToShortDateString();
            
            LoadDetails();
           
        }
    }

    public void LoadDetails()
    {
        obj = new PRIN_PrinterBooksPrintingDetails();
        try
        {
            //obDbAccess.execute("", DBAccess.SQLType.IS_PROC);
            //obDbAccess.addParam("mPrinterRegId", PrinterRegId);
            //obDbAccess.addParam("mTransdate_D", Transdate_D);
            objCommonFuction = new CommonFuction();
            DateTime  aa= txtDate.Text != "" ? Convert.ToDateTime(txtDate.Text, cult) : DateTime.Now.Date;
           ds= objCommonFuction.FillDatasetByProc("call USP_PRI012_PrinterBooksPrintingDetailsLoad(" + Session["UserID"].ToString () + ",'" + aa.ToString ("yyyy/MM/dd") + "','"+DdlACYear.SelectedItem.Text+"')");
           // obj.Transdate_D =;
            //obj.PrinterRegId = Convert.ToInt32(Session["UserID"]);
            //ds = obj.Select();
            grdPrintingDetail.DataSource = ds.Tables[0];
            grdPrintingDetail.DataBind();
            if (ds.Tables[1].Rows.Count > 0)
            {
                gvShowDetails.DataSource = ds.Tables[1];
                gvShowDetails.DataBind();
            }
            else
            {
                gvShowDetails.DataSource = ds.Tables[1];
                gvShowDetails.DataBind();
            }

        }

        catch (Exception ex) { }

        finally { obj = null; }

    }


    public int SaveDetails        (
                int PrinterBookDetailTrno,
                int TitleTrno,
                int ClassTrno,
                int GroupTrno,
                int TitleTotalFormQty,
                int CompQuantity,

                int PenQuantity,
                int PrintingCover,
                int Gathering,
                int Stiching,
                int Finishing,
                int Numbering,
                int PrinterRegId,

                string CompFormFrom,
                string CompFormTo,

                string PenFrmFrom,
                string PenFrmTo,
                DateTime Transdate
        )
    {

        int i = 0;
        obj = new PRIN_PrinterBooksPrintingDetails();
        try
        {
            obj.PrinterBookDetailTrno_I = PrinterBookDetailTrno;
            obj.TitleTrno_I = TitleTrno;
            obj.ClassTrno_I = ClassTrno;
            obj.GroupTrno_I = GroupTrno;
            obj.TitleTotalFormQty_I = TitleTotalFormQty;
            obj.CompQuantity = CompQuantity;
            obj.PenQuantity = PenQuantity;
            obj.PrintingCover = PrintingCover;
            obj.Gathering = Gathering;
            obj.Stiching = Stiching;
            obj.Finishing = Finishing;
            obj.Numbering = Numbering;
            obj.PrinterRegId = PrinterRegId;

            obj.CompFormFrom = CompFormFrom;
            obj.CompFormTo = CompFormTo;

            obj.PenFrmFrom = PenFrmFrom;
            obj.PenFrmTo = PenFrmTo;
            obj.Transdate_D = Transdate;



            if (validation() == 0)
            {

                i = obj.InsertUpdate();
            }
        }


        catch (Exception ex) { }
        finally { obj = null; }
        return i;

    }


    public int validation() 
    {
        int val = 0;

        if (txtDate.Text == "") 
        {
            val++;
            txtDate.BorderColor = System.Drawing.Color.Red;

        }

        for (int i = 0; i < grdPrintingDetail.Rows.Count; i++)
        {
            if (
         Convert.ToDouble(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtComFrmFrom")).Text) >
         Convert.ToDouble(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtComFrmTo")).Text)
            )
            {
                val++;

                ((TextBox)grdPrintingDetail.Rows[i].FindControl("txtComFrmFrom")).BorderColor = System.Drawing.Color.Red;
                ((TextBox)grdPrintingDetail.Rows[i].FindControl("txtComFrmTo")).BorderColor = System.Drawing.Color.Red;
            }

            else if (
        Convert.ToDouble(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenFrmFrom")).Text) >
        Convert.ToDouble(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenFrmTo")).Text)
           )
            {
                val++;

                ((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenFrmFrom")).BorderColor = System.Drawing.Color.Red;
                ((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenFrmTo")).BorderColor = System.Drawing.Color.Red;
            }
        }



        return val;
    }

    public void SaveGrdData() 
    {
        for (int i = 0; i < grdPrintingDetail.Rows.Count; i++)
        {
            if (grdPrintingDetail.Rows.Count > 0)
            {
                if (Session["UserID"] != null && Session["UserID"].ToString() != "0")
                {
                SaveDetails(
                    Convert.ToInt32(((HiddenField)grdPrintingDetail.Rows[i].FindControl("HdnPrinterBookDetailTrno_I")).Value),
                    Convert.ToInt32(((HiddenField)grdPrintingDetail.Rows[i].FindControl("HDNTitleID_I")).Value),
                    Convert.ToInt32(((HiddenField)grdPrintingDetail.Rows[i].FindControl("HDNClassTrno_I")).Value),
                    Convert.ToInt32(((HiddenField)grdPrintingDetail.Rows[i].FindControl("HDNGrpID_I")).Value),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtTitleTotalFormQty_I")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtCompQuantity")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenQuantity")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPrintingCover")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtGathering")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtStiching")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtFinishing")).Text),
                    Convert.ToInt32(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtNumbering")).Text),
                    Convert.ToInt32(((HiddenField)grdPrintingDetail.Rows[i].FindControl("HdnPrinter_RedID_I")).Value),

                    Convert.ToString(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtComFrmFrom")).Text),
                    Convert.ToString(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtComFrmTo")).Text),
                    Convert.ToString(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenFrmFrom")).Text),
                    Convert.ToString(((TextBox)grdPrintingDetail.Rows[i].FindControl("txtPenFrmTo")).Text),

                    txtDate.Text != "" ? Convert.ToDateTime(txtDate.Text, cult) : DateTime.Now.Date
                   );
                }

                else
                {
                    message("यूजर ", "ERROR");
                }
            }

            else 
            {
                message("उचित जानकारी सुरक्षित करे ", "ERROR");
            }
        }
    
    
    }

    protected void lnkSave_Click(object sender, EventArgs e)
    {
        tblShowDetails.Visible = false;
        tblEntry.Visible = true;
        txtDate.Text = "";
        txtDate.Text = System.DateTime.Now.ToShortDateString();
        messDiv.Visible = false;
        txtDate.Enabled = true;
        LoadDetails();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        tblShowDetails.Visible = true;
        tblEntry.Visible = false;
        txtDate.Text = "";
        txtDate.Text = System.DateTime.Now.ToShortDateString();
        txtDate.Enabled = true;
        grdPrintingDetail.DataSource = null;
        grdPrintingDetail.DataBind();
        messDiv.Visible = false;
    }
    protected void lnkSend_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblTranDate=(Label)gv.FindControl("lblTranDate");
       // objCommonFuction.FillDatasetByProc("update  PRI_PrinterBooksPrintingDetails set  SendSts=1  where PrinterRegId="+Session["UserID"]+" and Transdate_D='" + Convert.ToDateTime(lblTranDate.Text, cult).ToString("yyyy-MM-dd") + "'");
        objCommonFuction.FillDatasetByProc("call CheckDailyReportCurrentdate(" + Session["UserID"] + ",'" + Convert.ToDateTime(lblTranDate.Text, cult).ToString("yyyy-MM-dd") + "',1)");
        
        LoadDetails();
        message("Report has been sent successfully.","SUCCESS");
         
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblTranDate = (Label)gv.FindControl("lblTranDate");

        txtDate.Text = lblTranDate.Text;
        txtDate_TextChanged(sender, e);
        tblShowDetails.Visible = false;
        tblEntry.Visible = true;
        txtDate.Enabled = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveGrdData(); 
        LoadDetails();
        message("Report saved successfully.", "SUCCESS");
        tblShowDetails.Visible = true;
        tblEntry.Visible = false;
        txtDate.Text = "";
        txtDate.Text = System.DateTime.Now.ToShortDateString();
        txtDate.Enabled = true;
        grdPrintingDetail.DataSource = null;
        grdPrintingDetail.DataBind();
    }


    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (txtDate.Text != "")
        {
            CommonFuction comm = new CommonFuction();
            DataSet dd = comm.FillDatasetByProc("call CheckDailyReportCurrentdate(" + Session["UserID"] + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "',0)");
           if (dd.Tables[0].Rows.Count>0)
           {LoadDetails();}else {}
            
        }
        else
        {
            grdPrintingDetail.DataSource = null;
            grdPrintingDetail.DataBind();
            message("दिनांक लिखे ", "ERROR");
            txtDate.BorderColor = System.Drawing.Color.Red;
        }
    }
    protected void gvShowDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTranDate = (Label)e.Row.FindControl("lblTranDate");
            Label lblSendSts = (Label)e.Row.FindControl("lblSendSts");
            LinkButton lnkSend = (LinkButton)e.Row.FindControl("lnkSend");
            LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            Label lblSend = (Label)e.Row.FindControl("lblSend");
            try
            {
                lblTranDate.Text = (DateTime.Parse(lblTranDate.Text)).ToString("dd/MM/yyyy");
            }
            catch { }
            if (lblSendSts.Text == "0")
            {
               
                lnkSend.Visible = true;
                lblSend.Visible = false;
                lnkEdit.Visible = true;
            }
            else
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (lblSendSts.Text == "1")
                    {
                        cell.BackColor = System.Drawing.Color.Green;
                        cell.ForeColor = System.Drawing.Color.White;
                    }
                }
                lnkSend.Visible = false;
                lblSend.Visible = true;
                lnkEdit.Visible = false;
                lblSend.Text = "Sent To Head Office";
            }

        }

    }
    protected void gvShowDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShowDetails.PageIndex = e.NewPageIndex;
        LoadDetails();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadDetails();
    }
}
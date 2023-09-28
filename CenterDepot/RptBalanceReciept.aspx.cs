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
using System.Globalization;
using System.IO;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;

public partial class RptBalanceReciept : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails ();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure api = new APIProcedure();
    string CntrDepot_Id = "";

    string leaderName = string.Empty;
    string ChallanNo = string.Empty;
    string NameofPress_V = string.Empty;
    int ltSno = 1;
    DataTable dttPaperMill; DataTable dttTitle;

    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
           
            hdnBalanceRecptNo.Value = "";
            btnSave.Visible = false;           
            Div1.Visible = false;
            BindPrinterDDL();
            BindSuppier();
            BindGSM();
            //FillGrid();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                       

            if (Request.QueryString["frmid"] != null)
            {
                RptForm_GridToField(api.Decrypt(Request.QueryString["frmid"].ToString()));
            }
        }
    }


    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlMil = (e.Row.FindControl("ddlMil") as DropDownList);
                HiddenField hdnPaperMilID = (e.Row.FindControl("hdnPaperMilID") as HiddenField);
                DataSet dd = obCommonFuction.FillDatasetByProc("call ppr_GetPaperVendorbyAcYear('" + obCommonFuction.GetFinYear() + "')");
                ddlMil.DataSource = dd.Tables[0];
                ddlMil.DataTextField = "PaperVendorName_V";
                ddlMil.DataValueField = "PaperVendorTrId_I";
                ddlMil.DataBind();

                //Add Default Item in the DropDownList
                ddlMil.Items.Insert(0, new ListItem("Please select",""));

                ddlMil.ClearSelection();
                ddlMil.Items.FindByValue(hdnPaperMilID.Value).Selected = true;

               
            }
        }
        catch { }

        try
        {
            DropDownList ddlTitle = (e.Row.FindControl("ddlTitle") as DropDownList);
            HiddenField hdnTitleId_I = (e.Row.FindControl("hdnTitleId_I") as HiddenField);
            //DataSet ds31 = obCommonFuction.FillDatasetByProc("call GetPrintertitleAllotmentNew(2,0," + ddlPrinter.SelectedValue + ",'" + ddlAcYear.SelectedItem.Text + "')");
            //ddlTitle.DataSource = ds31;
            //ddlTitle.DataTextField = "TitleHindi_V";
            //ddlTitle.DataValueField = "TitleId";
            //ddlTitle.DataBind();
            //ddlTitle.Items.Insert(0, new ListItem("सलेक्ट करे",""));

            //ddlTitle.ClearSelection();
            //ddlTitle.Items.FindByValue(hdnTitleId_I.Value).Selected = true;
        }
        catch { }
    }

    public void FillGrid()
    {
        int PrinterID = 0;

        if (ddlPrinter.SelectedItem.Text == "Select")
        {
            PrinterID = 0;
        }
        else
        {
            PrinterID = Convert.ToInt32(ddlPrinter.SelectedValue);
        }

        string BalanceRcptFromDt = "1900-01-01";       
        string BalanceRcptToDt = "9999-01-01";
        string txtSearch = txtBalanceRecptNo.Text;        

        CommonFuction obCommonFuction = new CommonFuction();
        DataSet dsr = new DataSet();

        /*dsr = obCommonFuction.FillDatasetByProc("call USP_PRI_LIST_BalanceParchi('" + ddlAcYear.SelectedItem.Text + "'," +
        "'" + PrinterID + "', '" + BalanceRcptFromDt + "','" + BalanceRcptToDt + "','" + txtSearch + "','')");*/

        dsr = obCommonFuction.FillDatasetByProc("call USP_PRI_Show_BalanceParchiByRecptNo('" + ddlAcYear.SelectedItem.Text + "'," +
        "'" + PrinterID + "', '" + BalanceRcptFromDt + "','" + BalanceRcptToDt + "','" + txtSearch + "','" + txtBalanceRecptNo.Text + "')");
        GridView1.DataSource = dsr;
        GridView1.DataBind();
        GridView1.Visible = true;

        if (GridView1.Rows.Count > 0)
        {
            Div1.Visible = true;
           
        }
        else
        {
            Div1.Visible = false; 
        }
                  

    }

    public void RptForm_GridToField(string RptId)
    {
        if (RptId != "")
        {
            DataTable dtt = obCommonFuction.FillTableByProc("call USP_PRI_LIST_BalanceParchi('" + ddlAcYear.SelectedItem.Text + "'," +
            "'0', '','','','" + RptId + "')");

            HiddenField1.Value = dtt.Rows[0]["BRId"].ToString();
            txtBalanceRecptNo.Text = dtt.Rows[0]["BalanceRecieptNo"].ToString();
            txtDate.Text = dtt.Rows[0]["BalanceRecieptDate"].ToString();

            ddlAcYear.SelectedValue = dtt.Rows[0]["Acyear"].ToString();
            ddlPrinter.SelectedValue = dtt.Rows[0]["PrinterId"].ToString();
            if (ddlSupplier.Items.FindByText(dtt.Rows[0]["PrinterId"].ToString()) != null)
                ddlSupplier.Items.FindByText(dtt.Rows[0]["PrinterId"].ToString()).Selected = true;

            string ChallanDate = "1900-01-01";
            if (txtDate.Text != "")
            {
                ChallanDate = FnDtFormat(txtDate.Text);
            }



            DataTable dtAll = obCommonFuction.FillDatasetByProc("call USP_GetBalanceReciept('" + ddlAcYear.SelectedItem.Text + "','" + ddlPrinter.SelectedValue + "','" + ChallanDate + "','','0')").Tables[6];
            GrdLOI.DataSource = dtAll;
            GrdLOI.DataBind();
            dtAll = null;

            if (GrdLOI.Rows.Count > 0)
            {
                btnSave.Visible = true;               
                btnSave.Text = "संपादित करे";
            }
            else
            {
                btnSave.Visible = false;               
            }

            foreach (GridViewRow gv in GrdLOI.Rows)
            {
                Label lblPaperInformation = (Label)gv.FindControl("lblPaperInformation");
                
                foreach (DataRow Dr in dtt.Rows)
                {
                    if (Dr["PaperInformation"].ToString() == lblPaperInformation.Text)
                    {
                        CheckBox chk = (CheckBox)gv.FindControl("chk");
                        TextBox txtRemark = (TextBox)gv.FindControl("txtRemark");
                        HiddenField hdnPId = (HiddenField)gv.FindControl("hdnPId");                        
                        
                        chk.Checked = true;
                        txtRemark.Text = Dr["Remark"].ToString();
                        hdnPId.Value = Dr["BRId"].ToString();
                    }  
                }
            }
            dtt = null;
            btnSearch.Visible = false;
        }
    }

    public void BindPrinterDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
         ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
    }

    public void BindGSM()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl('" + ddlAcYear.SelectedItem.Text + "')");
        ddlGSM.DataSource = ds;
        ddlGSM.DataTextField = "CoverInformation";
        ddlGSM.DataValueField = "PaperMstrTrID_I";
        ddlGSM.DataBind();
        ddlGSM.Items.Insert(0, "All");
    }

    public void GridFillLoad()
    {
        int VenderID = 0;
        //try
        //{
        if (ddlPrinter.SelectedItem.Text == "All")
        {
            VenderID = 0;
        }
        else
        {
            VenderID = Convert.ToInt32(ddlPrinter.SelectedValue);
        }

        string ChallanDate = "1900-01-01";
        if (txtDate.Text != "")
        {
            ChallanDate = FnDtFormat(txtDate.Text);
        }

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr=new DataSet();
            //dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewGSR('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            dsr = obCommonFuction.FillDatasetByProc("call USP_GetBalanceReciept('" + ddlAcYear.SelectedItem.Text + "','" + VenderID + "','" + ChallanDate + "','')");
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();
        //}
        //catch { }

            

    }

    protected void GrdLOI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    GridView HeaderGrid = (GridView)sender;
        //    GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //    TableCell HeaderCell = new TableCell();
        //    HeaderCell.Text = "";
        //    HeaderCell.ColumnSpan = 7;
        //    HeaderCell.BackColor = System.Drawing.Color.Gray;
        //    HeaderCell.ForeColor = System.Drawing.Color.White;
        //    HeaderGridRow.Cells.Add(HeaderCell);
        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = " प्राप्ति का विवरण";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderCell.BackColor = System.Drawing.Color.Gray;
        //    HeaderCell.ForeColor = System.Drawing.Color.White;
        //    HeaderGridRow.Cells.Add(HeaderCell);
            

        //    HeaderCell = new TableCell();
        //    HeaderCell.Text = "";
        //    HeaderCell.ColumnSpan = 4;
        //    HeaderCell.BackColor = System.Drawing.Color.Gray;
        //    HeaderCell.ForeColor = System.Drawing.Color.White;
        //    HeaderGridRow.Cells.Add(HeaderCell);

        //    GrdLOI.Controls[0].Controls.AddAt(0, HeaderGridRow);

           
        //}

        
    }

    

    
   
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    private void BindSuppier()
    {
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetailsnew('CENTRAL STORE  ')");
        ddlSupplier.DataSource = ds.Tables[0];
        ddlSupplier.DataTextField = "Name";
        ddlSupplier.DataValueField = "EmployeeID_I";
        ddlSupplier.DataBind();
        ddlSupplier.Items.Insert(0, new ListItem("Select",""));
        
    }

    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();              
            HeaderCell.Text = "खाता पर्ची का विवरण";
            HeaderCell.ColumnSpan = 9;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderCell.Font.Bold = true;
            HeaderCell.HorizontalAlign = HorizontalAlign.Left;
            HeaderGridRow.Cells.Add(HeaderCell);
            GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);

        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView grid = sender as GridView;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, -1,
                DataControlRowType.Header, DataControlRowState.Normal);

            for (int Index = 1; Index <= GridView1.Columns.Count; Index++)
            {
                TableCell left = new TableHeaderCell();
                left.Text = Index.ToString();
                left.BackColor = System.Drawing.Color.Gray;
                left.ForeColor = System.Drawing.Color.White;
                left.HorizontalAlign = HorizontalAlign.Center;
                left.VerticalAlign = VerticalAlign.Middle;
                row.Cells.Add(left);

                Table t = grid.Controls[0] as Table;
                if (t != null)
                {
                    t.Rows.AddAt(2, row);
                }
            }
        }
    }

    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView grid = sender as GridView;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, -1,
                DataControlRowType.Header, DataControlRowState.Normal);

            for (int Index = 1; Index <= GrdLOI.Columns.Count; Index++)
            {
                TableCell left = new TableHeaderCell();
                left.Text = Index.ToString();
                left.BackColor = System.Drawing.Color.Gray;
                left.ForeColor = System.Drawing.Color.White;
                left.HorizontalAlign = HorizontalAlign.Center;
                left.VerticalAlign = VerticalAlign.Middle;
                row.Cells.Add(left);

                Table t = grid.Controls[0] as Table;
                if (t != null)
                {
                    t.Rows.AddAt(0, row);
                }
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = null;
        GridView1.DataBind();
        GridView1.Visible = false;

            int PrinterID = 0;
            if (ddlPrinter.SelectedItem.Text == "Select")
            {
                PrinterID = 0;
            }
            else
            {
                PrinterID = Convert.ToInt32(ddlPrinter.SelectedValue);
            }

            int GSM = 0;
            if (ddlGSM.SelectedItem.Text == "All")
            {
                GSM = 0;
            }
            else
            {
                GSM = Convert.ToInt32(ddlGSM.SelectedValue);
            }

            if (PrinterID == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Printer.');</script>");
            }
        
            string FromDt = "";
            string ToDt = "";
        if (txtDate.Text != "")
        {
            ToDt = FnDtFormat(txtDate.Text);
        }
            CommonFuction obCommonFuction = new CommonFuction();
            DataTable dsr = new DataTable();

            
            try
            {
                //dsr = obCommonFuction.FillDatasetByProc("call USP_GetBalanceReciept('" + ddlAcYear.SelectedItem.Text + "','" + PrinterID + "','" + FromDt + "','" + ToDt + "','0')").Tables[1];
                dsr = obCommonFuction.FillDatasetByProc("call USP_GetBalanceReciept_New('" + ddlAcYear.SelectedItem.Text + "','" + PrinterID + "','" + FromDt + "','" + ToDt + "','0')").Tables[1];
                dsr = obCommonFuction.FillTableByProc("SELECT GSM,CoverInformation, CASE WHEN GSM=230 THEN CAST(ProgAllotQty AS DECIMAL(18,0)) WHEN GSM=250 THEN CAST(ProgAllotQty AS DECIMAL(18,0)) ELSE ProgAllotQty END AS ProgAllotQty, CASE WHEN PaperType_V='2' THEN CAST(ProgSupplyQty AS DECIMAL(18,0)) ELSE ProgSupplyQty END AS ProgSupplyQty, CASE WHEN GSM=230 THEN CAST(Balance AS DECIMAL(18,0)) WHEN GSM=250 THEN CAST(Balance AS DECIMAL(18,0)) ELSE Balance END AS Balance,Remark,isBalance,  PrinterId,PaperMstrTrID_I,PaperType_V,IFNULL(PaperMilID,0) AS PaperMilID, IFNULL(TitleId_I,0) AS TitleId_I FROM tempBalanceReceipt WHERE PaperMstrTrID_I= CASE WHEN '" + GSM + "'>0 THEN '" + GSM + "' ELSE PaperMstrTrID_I END;");
                GrdLOI.DataSource = dsr;
                GrdLOI.DataBind();

                DataTable dtt = obCommonFuction.FillTableByProc("select count(DISTINCT BalanceRecieptNo) from pri_balanceparchi where PrinterId='" + ddlPrinter.SelectedValue + "'");
                int cnt = 0;
                if (dtt.Rows.Count > 0)
                {
                    cnt = Convert.ToInt32(dtt.Rows[0][0]);
                }
                txtBalanceRecptNo.Text = fnGetReciptNo(cnt.ToString(), ddlPrinter.SelectedValue);
                hdnBalanceRecptNo.Value = txtBalanceRecptNo.Text;
                //btnCancel.Visible = true;
                btnSave.Visible = true;

                //fill Title
                ddlPrinter_SelectedIndexChanged(null, null);
                
            }
            catch
            {
                GrdLOI.DataSource = dsr;
                GrdLOI.DataBind();
                Reset();
            }
    }

    protected void btnRedirect_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewRptBalanceReciept.aspx");
    }

    protected void btnReason_Click(object sender, EventArgs e)
    {
        if (hdnFormId.Value != "")
        {
            if (txtReason.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter reason.');</script>");
            }

            DateTime DteCheck;
            string RptDate = "";
            if (TextBox1.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(TextBox1.Text, cult);
                }
                catch { RptDate = "NoDate"; }
            }

            if (RptDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Date.');</script>");
            }

            try
            {
                obCommonFuction.FillTableByProc("call USP_PRI_BalanceParchiStatus('" + hdnFormId.Value + "'," +
                     "'" + txtReason.Text + "'," +
                   "'" + obCommonFuction.dtFormat(TextBox1.Text) + "','9')");
                FillGrid();
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Status updated successfully.');</script>");
            }
            catch
            {

            }
        }
    }

    protected void ltrChallanNo_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("BalanceRecieptNo").ToString();
        Literal ltrRemark = (Literal)lt.FindControl("ltrRemark");

        if (!string.Equals(lt.Text, ChallanNo))
        {
            ChallanNo = lt.Text;
            ltrRemark.Text = Eval("Remark").ToString();
        }
        else
        {
            lt.Text = string.Empty;
            ltrRemark.Text = "";
        }
    }

    protected void ltrDemandFrom_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("BalanceRecieptDate").ToString();
        Literal ltrSno = (Literal)lt.FindControl("ltrSNo");
        LinkButton lnk = (LinkButton)lt.FindControl("lnk");
        Panel pnl = (Panel)lt.FindControl("pnl");

        if (!string.Equals(lt.Text, NameofPress_V))
        {
            NameofPress_V = lt.Text;
            ltrSno.Text = ltSno.ToString();
            ltSno++;
        }
        else
        {
            lt.Text = string.Empty;
            lnk.Text = "";
            pnl.Visible = false;
        }
    }

    protected void fnFormatGridView()
    {
        
        for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GridView1.Rows[rowIndex];
            GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];           

            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {
                if (cellCount == 0)
                {
                    //  i = i + 1;
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                    {
                        // aj = aj + 1;
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }


                }
                else if (cellCount == 7)
                {
                    //  i = i + 1;
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text) && (gvRow.Cells[2].Text == gvPreviousRow.Cells[2].Text))
                    {
                        // aj = aj + 1;
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }

                }

                
                else if (cellCount == 1)
                {
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                    {

                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }
                }                
            }
        }
    }

    private string fnGetReciptNo(string cnt, string printerid)
    {
        string ret = ""; 
        string currYear = DateTime.Now.Year.ToString().Substring(2);
        //string currYear = ddlAcYear.SelectedItem.Text.Substring(2);
        if (Convert.ToInt32(cnt) > 0 && Convert.ToInt32(cnt) < 10)
            cnt = "00" + (Convert.ToInt32(cnt) + 1).ToString();
        else if (Convert.ToInt32(cnt) >= 10 && Convert.ToInt32(cnt) < 100)
            cnt = "0" + (Convert.ToInt32(cnt) + 1).ToString();
        else if (Convert.ToInt32(cnt) >= 100)
            cnt = (Convert.ToInt32(cnt) + 1).ToString();
        else
            cnt = "001";

        if (printerid.Length == 1)
            printerid = "00" + printerid;
        else if (printerid.Length == 2)
            printerid = "0" + printerid;

        ret = "B" + currYear + printerid + cnt;
        return ret;
    }

    private void Reset()
    {
        txtBalanceRecptNo.Text = "";
       // txtDate.Text = "";
        HiddenField1.Value = "";
        btnSave.Visible = false;
        foreach (GridViewRow gv in GridView1.Rows)
        {
            CheckBox chkbox = (CheckBox)gv.FindControl("chk");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string RptDate = "";
        if (txtDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }

        int VenderID = 0;
        if (ddlPrinter.SelectedItem.Text == "Select")
        {
            VenderID = 0;
        }
        else
        {
            VenderID = Convert.ToInt32(ddlPrinter.SelectedValue);
        }

        if (VenderID == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Printer.');</script>");
        }
        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Date.');</script>");
        }
        if (txtBalanceRecptNo.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Balance receipt no.');</script>");
            return;
        }

        if (cblTitles.SelectedIndex < 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Title.');</script>");
            return;
        }

        if (GrdLOI.Rows.Count == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select atleast one row from gridview');</script>");
            return;
        }

        string chksts11 = ""; string chksts22 = ""; int j = 0;
        foreach (GridViewRow gv in GrdLOI.Rows)
        {
            
            CheckBox chkbox = (CheckBox)gv.FindControl("chk");
            DropDownList ddlMil = (DropDownList)gv.FindControl("ddlMil");
            DropDownList ddlTitle = (DropDownList)gv.FindControl("ddlTitle");
            if (chkbox.Checked == true)
            {
                j++;
                if(ddlMil.SelectedValue != "")
                    chksts11 = "ok";
                else
                    chksts11 = "";

                //if (ddlTitle.SelectedValue != "")
                //    chksts22 = "ok";
                //else
                //    chksts22 = "";
            }
        }

        if (j == 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select from Balance Reciept grid');</script>");
            return;
        }

        if (chksts11 == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Paper Mill.');</script>");
            return;
        }

        string TitleIDs = ""; string TitleName_V = "";
        foreach (ListItem listItem in cblTitles.Items)
        {
            if (listItem.Selected)
            {
                TitleIDs += listItem.Value + ",";
                TitleName_V += listItem.Text + ",";
            }
        }

        if (TitleIDs != "")
        {
            TitleIDs = TitleIDs.TrimEnd(',');
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Title.');</script>");
            return;
        }

        if (TitleName_V != "")
        {
            TitleName_V = TitleName_V.TrimEnd(',');
        }

        //if (chksts22 == "")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select Title.');</script>");
        //    return;
        //}

                 
            try
            {
                DataTable dtt= new DataTable();
                int chk = 0;              

                if(HiddenField1.Value == "")
                {
                    dtt = obCommonFuction.FillTableByProc("call USP_PRI_Save_BalanceParchi('0'," +
                      "'" + txtBalanceRecptNo.Text + "', '" + ddlPrinter.SelectedValue + "'," +
                    "'" + obCommonFuction.dtFormat(txtDate.Text) + "','" + ddlAcYear.SelectedItem.Text + "','0','"+rdOption.SelectedValue+"','"+TitleIDs+"')");
                }
                else
                {
                    dtt = obCommonFuction.FillTableByProc("call USP_PRI_Save_BalanceParchi('" + HiddenField1.Value + "'," +
                      "'" + txtBalanceRecptNo.Text + "', '" + ddlPrinter.SelectedValue + "'," +
                    "'" + obCommonFuction.dtFormat(txtDate.Text) + "','" + ddlAcYear.SelectedItem.Text + "','0','" + rdOption.SelectedValue + "','" + TitleIDs + "')");
                }
                string MID = dtt.Rows[0][0].ToString();
                if (Convert.ToInt32(MID) > 0)
                {
                    foreach (GridViewRow gv in GrdLOI.Rows)
                    {
                        CheckBox chkbox = (CheckBox)gv.FindControl("chk");
                        if (chkbox.Checked == true)
                        {
                            chk++;
                            string issuePErson = ddlSupplier.SelectedItem.Text != "Select" ? ddlSupplier.SelectedItem.Text : "";
                            int status = 0;
                            Label lblPaperInformation = (Label)gv.FindControl("lblPaperInformation");
                            Label lblBalance = (Label)gv.FindControl("lblBalance");
                            HiddenField hdnPaperMstrTrID_I = (HiddenField)gv.FindControl("hdnPaperMstrTrID_I");
                            HiddenField hdnPaperType_V = (HiddenField)gv.FindControl("hdnPaperType_V");
                            TextBox txtRemark = (TextBox)gv.FindControl("txtRemark");
                            HiddenField hdnGSM = (HiddenField)gv.FindControl("hdnGSM");
                            HiddenField hdnPId = (HiddenField)gv.FindControl("hdnPId");

                            Label lblProgAllotQty = (Label)gv.FindControl("lblProgAllotQty");
                            Label lblProgSupplyQty = (Label)gv.FindControl("lblProgSupplyQty");

                            string PID = hdnPId.Value != "" ? hdnPId.Value : "0";

                            DropDownList ddlMil = (DropDownList)gv.FindControl("ddlMil");
                            DropDownList ddlTitle = (DropDownList)gv.FindControl("ddlTitle");

                            string vTitleID = ddlTitle.SelectedValue == "" ? "0" : ddlTitle.SelectedValue;
                            txtRemark.Text = TitleName_V;
                                                     
                            obCommonFuction.FillDatasetByProc("call USP_PRI_BalanceParchi('" + PID + "','" + txtBalanceRecptNo.Text + "'," +
                   "'" + ddlPrinter.SelectedValue + "','" + hdnGSM.Value + "'," +
                   "'" + lblPaperInformation.Text + "','" + obCommonFuction.dtFormat(txtDate.Text) + "', '" + txtRemark.Text + "'," +
                   "'" + issuePErson + "'," +
                   "'" + status + "','" + ddlAcYear.SelectedItem.Text + "','" + hdnPaperMstrTrID_I.Value + "','" + hdnPaperType_V.Value + "','" + lblBalance.Text + "','" + MID + "',"+lblProgAllotQty.Text+","+lblProgSupplyQty.Text+",'"+ddlMil.SelectedValue+"','"+vTitleID+"')");
                           
                        }
                    }

                    if (chk == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select atleast one row from gridview');</script>");
                        return;
                    }
                    

                    if(chk > 0)
                    {
                        FillGrid();
                        Reset();
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully');</script>");
                    }
                   
                }
            }
            catch (Exception ex)
            {
               
            }
       
       
        //FillGrid();
        //Reset();
    }

    public string FnDtFormat(string date)
    {
        if (date.Trim().Length > 0)
        {
            if(date.IndexOf('-') > 0)
            {
                date = date.Split('-')[2] + "-" + date.Split('-')[1] + "-" + date.Split('-')[0];
            }
            else
                date = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        }
        return date;
    }

    protected void lnkChangeSts_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
        obCommonFuction.FillDatasetByProc("call Usp_pprLOISearchDetails('" + lblDisTranId.Text + "','',8)");
        GridFillLoad();
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    ExportToExcell();
    //}
    public void ExportToExcell()
    {
        GrdLOI.AllowPaging = false;
        GridFillLoad();
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GSRPraptiDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }


    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            cblTitles.Visible = true;
            cblTitles.DataSource = null;
            cblTitles.DataBind();
            if (rdOption.SelectedValue == "1")  //get paathpustak title
            {
                DataSet ds31 = obCommonFuction.FillDatasetByProc("call GetPrintertitleAllotmentNew(2,0," + ddlPrinter.SelectedValue + ",'" + ddlAcYear.SelectedItem.Text + "')");
                cblTitles.DataSource = ds31;
                cblTitles.DataTextField = "TitleHindi_V";
                cblTitles.DataValueField = "TitleId";
                cblTitles.DataBind();
            }
            else if(rdOption.SelectedValue == "2")
            {
                DataSet ds33 = obCommonFuction.FillDatasetByProc("call GetTitleBalRcpt_acb(0,'" + ddlPrinter.SelectedValue + "','" + ddlAcYear.SelectedItem.Text + "')");
                cblTitles.DataSource = ds33;
                cblTitles.DataTextField = "Title";
                cblTitles.DataValueField = "SubTitleID_I";
                cblTitles.DataBind();
            }

            
        }
        catch { }
    }
    protected void lnkPrint_Click(object sender, EventArgs e)
    {
        try
        {
 //            <asp:HiddenField ID="hdnPrinterId11" runat="server" Value='<%#Eval("PrinterId")%>' />
 //                                           <asp:HiddenField ID="hdnAcyr" runat="server" Value='<%#Eval("Acyear")%>' />
 //<%--  <a href='PrintBalanceRecieptNew.aspx?PrinterId=<%# new APIProcedure().Encrypt( Eval("PrinterId").ToString())%>&acyr=<%# new APIProcedure().Encrypt( Eval("Acyear").ToString())%>&Ono=<%# new APIProcedure().Encrypt( Eval("BalanceRecieptNo").ToString())%>' target="_blank">प्रिंट करें</a>--%>
 //  <asp:Literal ID="ltr" runat="server" Text='<%#Eval("BalanceRecieptNo")%>' 
 //                                                OnDataBinding="ltrChallanNo_DataBinding"></asp:Literal>

            LinkButton txtPerbundlebook = (LinkButton)sender;
            //txtPerbundlebook
            GridViewRow gv = (GridViewRow)txtPerbundlebook.NamingContainer;
            HiddenField hdnPrinterId11 = (HiddenField)gv.FindControl("hdnPrinterId11");
            HiddenField hdnAcyr = (HiddenField)gv.FindControl("hdnAcyr");
            Literal ltr = (Literal)gv.FindControl("ltr");

            string red = "PrintBalanceRecieptNew.aspx?PrinterId=" + new APIProcedure().Encrypt(hdnPrinterId11.Value) + "&acyr=" + new APIProcedure().Encrypt(hdnAcyr.Value) + "&Ono=" + new APIProcedure().Encrypt(ltr.Text).ToString();
            //Response.Redirect(red);
        }
        catch { }
    }
}
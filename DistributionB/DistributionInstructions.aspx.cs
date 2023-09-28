using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DistributionB_DistributionInstructions : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Random rdm = new Random();
    DataTable dtSelectedTitle;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAddTitle.Visible = false;
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "Id";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DdlGroup.DataSource = obCommonFuction.FillDatasetByProc("call USP_DIB015_GroupDetailsLoad(0)");
            DdlGroup.DataValueField = "GroupID_I";
            DdlGroup.DataTextField = "GroupName";
            DdlGroup.DataBind();
            DdlGroup.SelectedValue = obCommonFuction.GetFinYear();
            TxtOrderNO.Text = System.DateTime.Now.ToString("ddMMssmm") + RandomNumber();
            ddlTitleID.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelectNew('" + DdlACYear.SelectedItem.Text + "')");
            ddlTitleID.DataValueField = "TitleID_I";
            ddlTitleID.DataTextField = "TitleHindi_V";
            ddlTitleID.DataBind();
            ddlTitleID.Items.Insert(0, new ListItem("-Select-", "0"));
            //  CommonFuction obCommonFuction = new CommonFuction();
            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            //fillgrd();
            fnDtSelectedTitle();
        }
    }

    protected void btnAddTitle_Click(object sender, EventArgs e)
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        for (int rowno = 0; rowno < GridView1.Rows.Count; rowno++)
        {
            CheckBox chkIsTitleSelected = (CheckBox)GridView1.Rows[rowno].FindControl("CheckBox1");

            if (chkIsTitleSelected.Checked)
            {
                //dtSelectedTitle.Columns.Add("Acyear", typeof(string));
                //dtSelectedTitle.Columns.Add("OrderNo", typeof(string));
                //dtSelectedTitle.Columns.Add("OrderDate", typeof(string));
                //dtSelectedTitle.Columns.Add("TitleHindi_V", typeof(string));
                //dtSelectedTitle.Columns.Add("SubTitleHindi_V", typeof(string));
                //dtSelectedTitle.Columns.Add("TotalNoOFBooks", typeof(string));
                //dtSelectedTitle.Columns.Add("DepoName_V", typeof(string));
                //dtSelectedTitle.Columns.Add("NameofPress_V", typeof(string));
                //dtSelectedTitle.Columns.Add("VOrderID", typeof(string));

                //dtSelectedTitle.Columns.Add("TitleID", typeof(int));
                //DatakeySet[0] = dtSelectedTitle.Columns.Add("SubTitleID", typeof(string));
                //DatakeySet[1] = dtSelectedTitle.Columns.Add("DepoTrno", typeof(int));
                //dtSelectedTitle.PrimaryKey = DatakeySet;
                //ViewState.Add("dtSelectedTitle", dtSelectedTitle);

                DataRow drNewTitle = dtSelectedTitle.NewRow();
                drNewTitle["Acyear"] = DdlACYear.SelectedItem.Text;
                drNewTitle["OrderNo"] = TxtOrderNO.Text;
                drNewTitle["OrderDate"] = TxtOrderDate.Text;
                drNewTitle["Group"] = DdlGroup.SelectedValue;
                drNewTitle["GroupName"] = DdlGroup.SelectedItem.Text;
                drNewTitle["PrinterID"] = ddlPrinter.SelectedValue;
                drNewTitle["TitleHindi_V"] = GridView1.Rows[rowno].Cells[2].Text;
                drNewTitle["SubTitleHindi_V"] = GridView1.Rows[rowno].Cells[3].Text;

                TextBox lblGridValue = (TextBox)GridView1.Rows[rowno].FindControl("txtTotalSupply");
                drNewTitle["TotalSupply"] = lblGridValue.Text;

                drNewTitle["DepoName_V"] = GridView1.Rows[rowno].Cells[1].Text;
                drNewTitle["NameofPress_V"] = ddlPrinter.SelectedItem.Text;
                drNewTitle["VOrderID"] = ddlOrder.SelectedItem.Text;

                drNewTitle["TitleID"] = ddlTitleID.SelectedValue;
                drNewTitle["SubTitleID"] = ddlSub.SelectedValue;

                HiddenField lblGridValue11 = (HiddenField)GridView1.Rows[rowno].FindControl("HiddenField1");
                drNewTitle["DepoTrno_I"] = lblGridValue11.Value;

                HiddenField lblGridValue22 = (HiddenField)GridView1.Rows[rowno].FindControl("hdnGroupNo");
                drNewTitle["GrpID_I"] = lblGridValue22.Value;

                HiddenField lblGrpName = (HiddenField)GridView1.Rows[rowno].FindControl("hdnGroupName");
                drNewTitle["GroupNo_V"] = lblGrpName.Value;

                try
                {
                    dtSelectedTitle.Rows.Add(drNewTitle);
                    mainDiv.CssClass = "form-message success";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Record added successfully";
                }
                catch
                {
                    mainDiv.CssClass = "form-message error";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Duplicate entry!!";
                }


            }
        }
        ViewState.Add("dtSelectedTitle", dtSelectedTitle);
        FillSelectedTitleGrid();
    }

    private void FillSelectedTitleGrid()
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        GridView2.DataSource = dtSelectedTitle;
        GridView2.DataBind();
    }

    private void fnDtSelectedTitle()
    {
        dtSelectedTitle = new DataTable();
        DataColumn[] DatakeySet = new DataColumn[2];

        //dtSelectedTitle.Columns.Add("Title", typeof(string));
        //dtSelectedTitle.Columns.Add("SubTitle", typeof(string));
        //dtSelectedTitle.Columns.Add("DepoName", typeof(string));
        //dtSelectedTitle.Columns.Add("TotalSupply", typeof(int));   

        dtSelectedTitle.Columns.Add("Acyear", typeof(string));
        dtSelectedTitle.Columns.Add("OrderNo", typeof(string));
        dtSelectedTitle.Columns.Add("OrderDate", typeof(string));
        dtSelectedTitle.Columns.Add("Group", typeof(string));
        dtSelectedTitle.Columns.Add("GroupName", typeof(string));
        dtSelectedTitle.Columns.Add("TitleHindi_V", typeof(string));
        dtSelectedTitle.Columns.Add("SubTitleHindi_V", typeof(string));
        dtSelectedTitle.Columns.Add("TotalSupply", typeof(string));
        dtSelectedTitle.Columns.Add("DepoName_V", typeof(string));
        dtSelectedTitle.Columns.Add("NameofPress_V", typeof(string));
        dtSelectedTitle.Columns.Add("VOrderID", typeof(string));
        dtSelectedTitle.Columns.Add("GrpID_I", typeof(string));
        dtSelectedTitle.Columns.Add("GroupNo_V", typeof(string));

        dtSelectedTitle.Columns.Add("TitleID", typeof(int));
        DatakeySet[0] = dtSelectedTitle.Columns.Add("SubTitleID", typeof(string));
        DatakeySet[1] = dtSelectedTitle.Columns.Add("DepoTrno_I", typeof(int));
        dtSelectedTitle.Columns.Add("PrinterID", typeof(int));
        //dtSelectedTitle.PrimaryKey = DatakeySet;
        ViewState.Add("dtSelectedTitle", dtSelectedTitle);
    }

    private string RandomNumber()
    {
        return (rdm.Next(2, 100)).ToString();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTitleID.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelectNew('" + DdlACYear.SelectedItem.Text + "')");
        ddlTitleID.DataValueField = "TitleID_I";
        ddlTitleID.DataTextField = "TitleHindi_V";
        ddlTitleID.DataBind();
        ddlTitleID.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        //GridView1.DataSource=  obCommonFuction.FillDatasetByProc("call USP_DIB_GetPrintersByTitleNDepot ("+ddlTitleID.SelectedValue+","+DdlGroup.SelectedValue+","+DdlACYear.SelectedValue+",'"+ddlOrder.SelectedItem.Text+"')");
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB_GetPrintersByTitleNDepot (" + ddlTitleID.SelectedValue + "," + DdlGroup.SelectedValue + "," + DdlACYear.SelectedValue + ",'" + ddlOrder.SelectedValue + "','" + ddlSub.SelectedValue + "','" + DDlDemandType.SelectedValue + "')");
        GridView1.DataBind();
        //
        ddlPrinter.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetACBPrintertDetails(" + ddlSub.SelectedValue + ")");
        ddlPrinter.DataValueField = "Printer_regid_i";
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, new ListItem("-Select-", "0"));

        if (GridView1.Rows.Count > 0)
            btnAddTitle.Visible = true;
        else
            btnAddTitle.Visible = false;
    }
    protected void ddlTitleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSub.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(" + ddlTitleID.SelectedValue + ",-2)");
        ddlSub.DataValueField = "SubTitleID_I";
        ddlSub.DataTextField = "SubTitleHindi_V";
        ddlSub.DataBind();
        ddlSub.Items.Insert(0, new ListItem("-Select-", "0"));
        //ddlOrder.DataSource = obCommonFuction.FillDatasetByProc("select distinct LetterNo_V from dib_demand where AcYrID_I=" + DdlACYear.SelectedValue + " and TitleID_I=" + ddlTitleID.SelectedValue + "");
        //ddlOrder.DataSource = obCommonFuction.FillDatasetByProc("SELECT DISTINCT `DemandID_I`,  CASE  WHEN LetterNo_V=638 THEN 1367 ELSE  CONCAT( LetterNo_V,'-' ,IFNULL(DemandType,''))  END  LetterNo_V FROM  `dib_demand` WHERE TitleID_I=" + ddlTitleID.SelectedValue + "");
        ddlOrder.DataSource = obCommonFuction.FillDatasetByProc("SELECT DISTINCT DemandID_I, CASE  WHEN LetterNo_V='638' THEN '1367' ELSE LetterNo_V  END  LetterNo_V FROM dib_demand WHERE TitleID_I=" + ddlTitleID.SelectedValue + "");
        ddlOrder.DataValueField = "DemandID_I";
        ddlOrder.DataTextField = "LetterNo_V";
        ddlOrder.DataBind();
        ddlOrder.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    protected void ddlSubTitleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB_GetPrintersByTitleNDepot (" + ddlTitleID.SelectedValue + "," + DdlGroup.SelectedValue + "," + DdlACYear.SelectedValue + ",'" + ddlOrder.SelectedItem.Text + "','" + ddlSub.SelectedValue + "')");
            GridView1.DataBind();
        }
        catch { }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int cnt = 0;
        int Extra = 0;
        if (CheckBox2.Checked == true)
        {
            Extra = 1;
        }
        else
        {
            Extra = 0;

        }
        if (HiddenField2.Value == "")
        {//(TrIDa INT, OrderNoa VARCHAR(50), OrderDatea VARCHAR(50), Acyeara VARCHAR(20), GroupIDa INT, TitleIDa INT, SubTitleIDa INT	, PrinterIDa INT, TotalNoOFBooksa INT, DepoIDa INT, VOderIDa INT)
            for (int i = 0; i < GridView2.Rows.Count; i++)
            {
                string TxtOrderNO = ((Label)GridView2.Rows[i].FindControl("lblOrderNo")).Text;
                string TxtOrderDate = Convert.ToDateTime(((Label)GridView2.Rows[i].FindControl("lblOrderDate")).Text, cult).ToString("yyyy-MM-dd");
                string txtTotalSupply = ((Label)GridView2.Rows[i].FindControl("lblTotalSupply")).Text;
                int DepoTrno_I = int.Parse(((HiddenField)GridView2.Rows[i].FindControl("HiddenField1")).Value);
                string ddlOrder = ((HiddenField)GridView2.Rows[i].FindControl("hdnVOrderID")).Value;
                string hdnGroupNo = ((HiddenField)GridView2.Rows[i].FindControl("hdnGroupNo")).Value;
                string DdlGroup = ((HiddenField)GridView2.Rows[i].FindControl("hdn_ddlGroup")).Value;
                int ddlTitleID = int.Parse(((HiddenField)GridView2.Rows[i].FindControl("hdnTitleID")).Value);
                int ddlSub = int.Parse(((HiddenField)GridView2.Rows[i].FindControl("hdnSubTitleID")).Value);
                int ddlPrinter = int.Parse(((HiddenField)GridView2.Rows[i].FindControl("hdnPrinterID")).Value);

                //obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh(0,'" + TxtOrderNO + "','" + TxtOrderDate + "','" + DdlACYear.SelectedItem.Text + "'," + DdlGroup.SelectedValue + "," + ddlTitleID.SelectedValue + "," + ddlSub.SelectedValue + "," + ddlPrinter.SelectedValue + "," + txtTotalSupply + "," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + ",'" + ddlOrder.SelectedItem.Text + "','" + ((HiddenField)GridView1.Rows[i].FindControl("hdnGroupNo")).Value + "')");
                obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh01(0,'" + TxtOrderNO + "','" + TxtOrderDate + "','" + DdlACYear.SelectedItem.Text + "'," + DdlGroup + "," + ddlTitleID + "," + ddlSub + "," + ddlPrinter + "," + txtTotalSupply + "," + DepoTrno_I + ",'" + ddlOrder + "','" + hdnGroupNo + "','" + Extra + "')");
                cnt++;
            }
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        obCommonFuction.EmptyTextBoxes(this);
        //fillgrd();
        if (cnt > 0)
        {
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record added successfully";
        }
        else
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Duplicate entry!!";
        }


    }
    public void fillgrd()
    {
        GridView2.DataSource = obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh(-1,0,0,0,0,0,0,0,0,0,0,0)");
        GridView2.DataBind();
    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        fillgrd();
    }
    protected void DdlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlPrinter_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void DdlGroup_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
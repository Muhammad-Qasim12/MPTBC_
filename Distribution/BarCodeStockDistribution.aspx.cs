using System;
using System.Data;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Distribution_BarCodeStockDistribution : System.Web.UI.Page
{
    DIS_VitranNirdesh obVitranNirdesh = new DIS_VitranNirdesh();
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "ClassDesc_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, new ListItem("Select", "0"));

            DdlTitle.DataSource = string.Empty;
            DdlTitle.DataBind();
            DdlTitle.Items.Insert(0, new ListItem("Select", "0"));
        }
    }
    protected void GrdVitranNirdesh_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblDepoTrno_I = (Label)e.Row.FindControl("lblDepoTrno_I");
            TextBox TxtBookNoFrom = (TextBox)e.Row.FindControl("TxtBookNoFrom");
            TextBox txtBookNoTo = (TextBox)e.Row.FindControl("lblBookNoTo"); 
            TextBox TxtBundleNoFrom = (TextBox)e.Row.FindControl("TxtBundleNoFrom");
            TextBox txtBundleNoTo = (TextBox)e.Row.FindControl("lblBundleNoTo");
            TextBox txtQtySupp = (TextBox)e.Row.FindControl("txtQtySupp");
            TextBox TxtRemark = (TextBox)e.Row.FindControl("TxtRemark");
            ds= obCommonFuction.FillDatasetByProc("Call USP_DPO002_BarCodeStockDtlSave(" + DdlBookType.SelectedItem.Value.ToString() + ",'" + DdlClass.SelectedItem.Text + "'," + DdlTitle.SelectedItem.Value.ToString() + ",'','" + lblDepoTrno_I.Text + "','','','','','',1)");
            if (ds.Tables[0].Rows.Count > 0)
            {
                TextBooksPerBundle.Text = ds.Tables[0].Rows[0]["PerBundle"].ToString();
                TxtBookNoFrom.Text = ds.Tables[0].Rows[0]["BookFrom"].ToString();
                txtBookNoTo.Text = ds.Tables[0].Rows[0]["BookTo"].ToString();
                TxtBundleNoFrom.Text = ds.Tables[0].Rows[0]["BundleNoFrom"].ToString();
                txtBundleNoTo.Text = ds.Tables[0].Rows[0]["BundleNoTo"].ToString();
                TxtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            }
         
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string ChkRoleBx = "No", SaveSts = "";
        foreach (GridViewRow gv in GrdVitranNirdesh.Rows)
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
            foreach (GridViewRow gv in GrdVitranNirdesh.Rows)
            {
                Label lblDepoTrno_I = (Label)gv.FindControl("lblDepoTrno_I");
                TextBox TxtBookNoFrom = (TextBox)gv.FindControl("TxtBookNoFrom");
                TextBox txtBookNoTo = (TextBox)gv.FindControl("lblBookNoTo");
                CheckBox ChkSelect = (CheckBox)gv.FindControl("ChkSelect");
                TextBox TxtBundleNoFrom = (TextBox)gv.FindControl("TxtBundleNoFrom");
                TextBox txtBundleNoTo = (TextBox)gv.FindControl("lblBundleNoTo"); 
                TextBox TxtRemark = (TextBox)gv.FindControl("TxtRemark");
                if ((ChkSelect.Checked == true))
                {
                    obCommonFuction.FillDatasetByProc("Call USP_DPO002_BarCodeStockDtlSave(" + DdlBookType.SelectedItem.Value.ToString() + ",'" + DdlClass.SelectedItem.Text + "'," + DdlTitle.SelectedItem.Value.ToString() + ",'" + TextBooksPerBundle.Text + "','" + lblDepoTrno_I.Text + "','" + TxtBookNoFrom.Text + "','" + txtBookNoTo.Text + "','" + TxtBundleNoFrom.Text + "','" + txtBundleNoTo.Text + "','" + TxtRemark.Text + "',0)");
                    SaveSts = "Yes";
                }
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
    public void GridFillLoad()
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet obDataset = obCommonFuction.FillDatasetByProc(@"Call Usp_Dis_DistrStockBarCode(0," + Convert.ToInt32(DdlTitle.SelectedValue)
                                                                                              + "," + Convert.ToInt16(TextBooksPerBundle.Text)
                                                                                              + "," + Convert.ToInt16(DdlBookType.SelectedValue) + ",'" + DdlClass.SelectedItem.Text + "')");
            GrdVitranNirdesh.DataSource = obDataset;
            GrdVitranNirdesh.DataBind();
            mainDiv.Style.Add("display", "none");
            lblmsg.Style.Add("display", "none");
            if (obDataset.Tables[0].Rows.Count > 0)
            {
                btnSave.Visible = true;
            }
            else
            {
                btnSave.Visible = false;
            }

        }
        catch
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");

            if (DdlTitle.SelectedIndex < 0)
                lblmsg.Text = "कृपया पुस्तक का नाम चुने";
            else if (DdlClass.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया कक्षा चुने";
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridFillLoad();
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_TitleLoadClassWise(" + Convert.ToInt32(DdlClass.SelectedValue) + ")");
        DdlTitle.DataValueField = "TitleID_I";
        DdlTitle.DataTextField = "TitleHindi_V";
        DdlTitle.DataBind();
        //DdlTitle.Items.Insert(0, "--Select--");
        DdlTitle.Items.Insert(0, new ListItem("Select", "0"));
    }
}

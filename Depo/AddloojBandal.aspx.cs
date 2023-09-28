using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer;
public partial class Depo_AddloojBandal : System.Web.UI.Page
{
    DataTable dtVisitDetails = new DataTable();
    MediumMaster obMediumMaster = null;
    ClassMaster obClass = null;
    WareHouseMaster obWareHouseMaster = null;
    StockMaster obStockMaster = new StockMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction comm = new CommonFuction();
    int d;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "सलेक्ट करे ..");
            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            obClass.ClassTrno_I = 0;
            ddlCls.DataTextField = "Classdet_V";
            ddlCls.DataValueField = "ClassTrno_I";
            ddlCls.DataSource = dtclass.Tables[0];
            ddlCls.DataBind();
           // ddlCls.Items.Insert(0, "सलेक्ट करे ..");
            ddlfyyear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlfyyear.DataValueField = "AcYear";
            ddlfyyear.DataTextField = "AcYear";
            ddlfyyear.DataBind();
            ddlfyyear.SelectedValue = comm.GetFinYear();
            Button1.Visible = false;
           
            if (Request.QueryString["ChallanID"] != null)
            {
                Button1.Visible = true;
                DataSet dt = comm.FillDatasetByProc("call GetTitelByID(" + Request.QueryString["Hid"] + ")");

                ddlMedium.SelectedValue = dt.Tables[0].Rows[0]["Medium_I"].ToString();
                ddlMedium.Enabled = false;
                ddlCls.Enabled = false;
                ddlCls.SelectedValue = dt.Tables[0].Rows[0]["ClassTrno_I"].ToString();
                ddlCls_SelectedIndexChanged(sender, e);
                ddlsubject.SelectedValue = dt.Tables[0].Rows[0]["TitleID_I"].ToString();
                ddlsubject_SelectedIndexChanged(sender, e);
                ddlfyyear.Enabled = false;
                ddlsubject.Enabled = false;
            }
        }
    }
    public void MakeTable()
    {
       
        dtVisitDetails.Columns.Add("Sno", Type.GetType("System.Int32"));
        dtVisitDetails.Columns.Add("BandalNo", Type.GetType("System.String"));
        ViewState["_dtVisitDetails"] = dtVisitDetails;
    }
    protected void ddlCls_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = comm.FillDatasetByProc(@"select TitleID_I,  TitleHindi_V from acd_titledetail_f where ifnull(BookChangeStatus,'')<>5 and FYear='"+ddlfyyear.SelectedValue+"' and Medium_I=" + ddlMedium.SelectedValue + " and  ClassTrno_I=" + ddlCls.SelectedValue + "");
        ddlsubject.DataSource = ds.Tables[0];
        ddlsubject.DataTextField = "TitleHindi_V";
        ddlsubject.DataValueField="TitleID_I";
        ddlsubject.DataBind();
        ddlsubject.Items.Insert(0, "सलेक्ट करे ..");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        d = 0;
       d = Convert.ToInt32(ViewState["d"]);
        if (d == 0)
        {
           
            MakeTable();
        }
        for (int i = 0; i < Convert.ToInt32(TextBox1.Text);i++ )
        { 
        dtVisitDetails = (DataTable)ViewState["_dtVisitDetails"];
        DataRow tr = dtVisitDetails.NewRow();
        tr[0] = dtVisitDetails.Rows.Count + 1;
        dtVisitDetails.Rows.Add(tr);
        GridView1.DataSource = dtVisitDetails;
        GridView1.DataBind();
        ViewState["_dtVisitDetails"] = dtVisitDetails;
       // ViewState["d"] = d + 1;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            comm.FillDatasetByProc("call  USP_DPT_LoojBandalSave(" + ddlsubject.SelectedValue + "," + ddlCls.SelectedValue + "," + ddlMedium.SelectedValue + "," + TextBox1.Text + "," + ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text + ","+Session["UserID"]+",0,'"+ddlfyyear.SelectedValue+"')");
        }
        GridView1.DataSource = null;
        GridView1.DataBind();
        DataSet dd = comm.FillDatasetByProc("call  USP_DPT_LoojBandalSave(" + ddlsubject.SelectedValue + "," + ddlCls.SelectedValue + "," + ddlMedium.SelectedValue + "," + TextBox1.Text + ",0," + Session["UserID"] + ",1,'" + ddlfyyear.SelectedValue + "')");
       GridView2.DataSource = dd.Tables[0];
       GridView2.DataBind();
     
       ddlsubject.SelectedIndex = 0;
       TextBox1.Text = "";
       Button2.Visible = false;
       ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('आपका का डाटा सुरक्षित हो चूका है .');</script>");
        }
        catch { }
    }
    protected void ddlsubject_SelectedIndexChanged(object sender, EventArgs e)
    {
        //DataSet aa = comm.FillDatasetByProc("call DPTGetTotalLooinDepot("+Session["UserID"]+",'"+ddlfyyear.SelectedValue+"',"+ddlsubject.SelectedValue+","+ddlCls.SelectedValue+","+ddlMedium.SelectedValue+") ");

        //TextBox1.Text = aa.Tables[0].Rows[0]["TotalBundle"].ToString();
        //TextBox1_TextChanged( sender,  e);

        DataSet dd = comm.FillDatasetByProc("call  USP_DPT_LoojBandalSave(" + ddlsubject.SelectedValue + "," + ddlCls.SelectedValue + "," + ddlMedium.SelectedValue + ",0 ,0," + Session["UserID"] + ",1,'" + ddlfyyear.SelectedValue + "')");
        GridView2.DataSource = dd.Tables[0];
        GridView2.DataBind();
        Button2.Visible = true;
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow grdrow = (GridViewRow)txt.NamingContainer;
        TextBox txt1 = (TextBox)grdrow.FindControl("TextBox2");
        DataSet dd1 = comm.FillDatasetByProc(" call USP_DPTCheckBandal(" + ddlsubject.SelectedValue + "," + txt1.Text + ")");
        if (dd1.Tables[0].Rows[0]["Mcheck"].ToString()=="0")
        {
            txt1.Text = "";
            txt1.BackColor = System.Drawing.Color.Red;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('ये बंडल नंबर गलत है अथवा इसे पूर्व में लूज किया गया है कृपया जांचे.');</script>");
        }else
        {
            txt1.BackColor = System.Drawing.Color.White;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("BlockChalanReport.aspx?ChallanID=" + Request.QueryString["ChallanID"] + "");
    }
    protected void B13_Click(object sender, EventArgs e)
    {
        Div8.Style.Add("display", "none");
        Div7.Style.Add("display", "none");
    }
   
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (ddlsubject.SelectedIndex == 0)
        { 
        
        }
        else { 
        DataSet dt = comm.FillDatasetByProc(@"call dptStockDetailsReport(" + Session["USerID"] + "," + ddlsubject.SelectedValue + ",0,0,'"+ddlfyyear.SelectedValue+"')");
        grd15.DataSource = dt.Tables[0];
        grd15.DataBind();
        Div8.Style.Add("display", "block");
        Div7.Style.Add("display", "block");
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
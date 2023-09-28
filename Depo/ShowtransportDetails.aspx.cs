using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
public partial class Depo_ShowtransportDetails : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DepoReport obDepoReport = new DepoReport();
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            TransportMaster obTransportMaster = null;
           //obDPT_DepotMaster.DepoTrno_I = 0;
           //ataSet depo = obDPT_DepotMaster.Select();

            obTransportMaster = new TransportMaster();
            obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet1 = obTransportMaster.Select();
            ddlTrnasportName.DataTextField = "TransportName_V";
            ddlTrnasportName.DataValueField = "TransportID_I";
            ddlTrnasportName.DataSource = obDataSet1.Tables[0];
            ddlTrnasportName.DataBind();
            ddlTrnasportName.Items.Insert(0, "सेलेक्ट..");

            if (Request.QueryString["ID"] != null)
            {
                asa.Visible = true;
                DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
                obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
                DataSet obDataSet = obDPT_DepotMaster.Select();
                lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();

                obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
                obDepoReport.ID = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString()));
                DataSet ds = obDepoReport.TransportReport();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Label1.Text = ds.Tables[0].Rows[0]["TransportName_V"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["TransportOwnerName_V"].ToString();
                    Label3.Text = ds.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
                    Label4.Text = ds.Tables[0].Rows[0]["RegistrationDate_D"].ToString();
                    Label5.Text = ds.Tables[0].Rows[0]["TelephoneNo_V"].ToString();
                    Label6.Text = ds.Tables[0].Rows[0]["MobileNo_N"].ToString();
                    Label8.Text = ds.Tables[0].Rows[0]["Address_V"].ToString();

                    Label9.Text = ds.Tables[0].Rows[0]["City_V"].ToString();
                    Label10.Text = ds.Tables[0].Rows[0]["PinNo"].ToString();
                    Label11.Text = ds.Tables[0].Rows[0]["FaxNumber_V"].ToString();
                    Label12.Text = ds.Tables[0].Rows[0]["EmailID_V"].ToString();
                    Label13.Text = ds.Tables[0].Rows[0]["PanNo_V"].ToString();
                    Label14.Text = ds.Tables[0].Rows[0]["TinNo_V"].ToString();
                    Label15.Text = ds.Tables[0].Rows[0]["ServiceNo_V"].ToString();
                    Label16.Text = ds.Tables[0].Rows[0]["ServicePeriod_V"].ToString();
                    Label17.Text = ds.Tables[0].Rows[0]["RegistrationAmount_N"].ToString();
                    Label18.Text = ds.Tables[0].Rows[0]["DDNo_V"].ToString();
                    Label19.Text = ds.Tables[0].Rows[0]["BankName_V"].ToString();
                    Label20.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
                    Label21.Text = ds.Tables[0].Rows[0]["TenNumber"].ToString();

                }
                obDepoReport.ID = Convert.ToInt32(ddlTrnasportName.SelectedValue );
                DataSet ds1 = obDepoReport.GetTranportRateDetails();

                GridView1.DataSource = ds1.Tables[0];
                GridView1.DataBind();
                btnExport.Visible = true;
                btnExportPDF.Visible = true;
            }
            else
            {
                ra.Visible = true;
               
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("TransportReport.aspx");
    //}
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        asa.Visible = true;
        obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
        obDepoReport.ID = Convert.ToInt32(ddlTrnasportName.SelectedValue);
        DataSet ds = obDepoReport.TransportReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            Label1.Text = ds.Tables[0].Rows[0]["TransportName_V"].ToString();
            Label2.Text = ds.Tables[0].Rows[0]["TransportOwnerName_V"].ToString();
            Label3.Text = ds.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
            Label4.Text = ds.Tables[0].Rows[0]["RegistrationDate_D"].ToString();
            Label5.Text = ds.Tables[0].Rows[0]["TelephoneNo_V"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["MobileNo_N"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["Address_V"].ToString();

            Label9.Text = ds.Tables[0].Rows[0]["City_V"].ToString();
            Label10.Text = ds.Tables[0].Rows[0]["PinNo"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["FaxNumber_V"].ToString();
            Label12.Text = ds.Tables[0].Rows[0]["EmailID_V"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["PanNo_V"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["TinNo_V"].ToString();
            Label15.Text = ds.Tables[0].Rows[0]["ServiceNo_V"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["ServicePeriod_V"].ToString();
            Label17.Text = ds.Tables[0].Rows[0]["RegistrationAmount_N"].ToString();
            Label18.Text = ds.Tables[0].Rows[0]["DDNo_V"].ToString();
            Label19.Text = ds.Tables[0].Rows[0]["BankName_V"].ToString();
            Label20.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
            Label21.Text = ds.Tables[0].Rows[0]["TenNumber"].ToString();

        }
      //  obDepoReport.ID = Convert.ToInt32(ddlTrnasportName.SelectedValue);
        DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPTTranportRateDetailsN(" + ddlTrnasportName.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");

        GridView1.DataSource = ds1.Tables[0];
        GridView1.DataBind();
        btnExport.Visible = true;
        btnExportPDF.Visible = true;
    }
}
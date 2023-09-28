using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
public partial class Depo_ShowWarehouseDetails : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    public DataSet ds;
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblDepoName.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
            CommonFuction comm = new CommonFuction();
            lblFYear.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblCurrentDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
            obDepoReport.DistrictID = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString()));
            obDepoReport.ID = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString()));
            ds = obDepoReport.wareHousereport();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Literal1.Text = ds.Tables[0].Rows[0]["WareHouseName_V"].ToString();
                Literal2.Text = ds.Tables[0].Rows[0]["WarehouseType"].ToString();
                Literal3.Text = ds.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
                Literal4.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
                Literal5.Text = ds.Tables[0].Rows[0]["WareHouseOwnerName_V"].ToString();
                Literal6.Text = ds.Tables[0].Rows[0]["CarpateArea_V"].ToString();
                Literal8.Text = ds.Tables[0].Rows[0]["WareHouseAddress_V"].ToString();
                Literal9.Text = ds.Tables[0].Rows[0]["TelephoneNo_V"].ToString();
                Literal10.Text = ds.Tables[0].Rows[0]["MobileNo_N"].ToString();
                Literal13.Text = ds.Tables[0].Rows[0]["CityName_V"].ToString();
                Literal14.Text = ds.Tables[0].Rows[0]["PinNo"].ToString();
                Literal15.Text = ds.Tables[0].Rows[0]["FaxNumber_V"].ToString();
                Literal16.Text = ds.Tables[0].Rows[0]["EmailID_V"].ToString();
                Literal17.Text = ds.Tables[0].Rows[0]["RegistrationAmount_N"].ToString();
                Literal18.Text = ds.Tables[0].Rows[0]["DDNo_V"].ToString();
                Literal19.Text = ds.Tables[0].Rows[0]["ServicePeriod_V"].ToString();
                Literal20.Text = ds.Tables[0].Rows[0]["DDDate"].ToString();
                Literal21.Text = ds.Tables[0].Rows[0]["BankName_V"].ToString();
                Literal22.Text = ds.Tables[0].Rows[0]["TanNumber"].ToString();
                Literal23.Text = ds.Tables[0].Rows[0]["RentDate_D"].ToString();
                Literal24.Text = ds.Tables[0].Rows[0]["RentAmount_N"].ToString();
                Literal25.Text = Convert.ToString(Convert.ToInt32(ds.Tables[0].Rows[0]["RentAmount_N"]) * Convert.ToInt32(ds.Tables[0].Rows[0]["CarpateArea_V"]));
                btnExport.Enabled = true;
                btnExportPDF.Enabled = true;
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("WareHouseDetailsReport.aspx");
    }
}
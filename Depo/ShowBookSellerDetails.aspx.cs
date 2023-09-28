using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
public partial class Depo_ShowBookSellerDetails : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    public DataSet ds;
   APIProcedure api=new APIProcedure() ;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblDepoName.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
            CommonFuction comm = new CommonFuction();
            lblFYear.Text = comm.FillDatasetByProc("SELECT dbo.GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblCurrentDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

            btnExport.Visible = true;
            btnExportPDF.Visible = true;
            obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
            obDepoReport.DistrictID = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString()));
            obDepoReport.ID = 14;
            ds = obDepoReport.BookSellerReport();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblBookseller.Text = ds.Tables[0].Rows[0]["BooksellerName_V"].ToString();
                lblBooksellerPanNo.Text = ds.Tables[0].Rows[0]["PanNumber"].ToString();
                lblBooksellerRegDate.Text = ds.Tables[0].Rows[0]["RegistrationDate_D"].ToString();
                lblBooksellerRegNo.Text = ds.Tables[0].Rows[0]["RegistrationNo_V"].ToString();
                lblBooksellerTinNO.Text = ds.Tables[0].Rows[0]["TanNumber"].ToString();
                lblddDate.Text = ds.Tables[0].Rows[0]["RegDDNo_V"].ToString();
                lblDDdate1.Text = ds.Tables[0].Rows[0]["Chekcdat"].ToString();
                lblDistNAme.Text = ds.Tables[0].Rows[0]["District_Name_Hindi_V"].ToString();
                lblEmailID.Text = ds.Tables[0].Rows[0]["EmailID_V"].ToString();
                lblFaxNo.Text = ds.Tables[0].Rows[0]["FaxNumber_V"].ToString();
                lblMobile.Text = ds.Tables[0].Rows[0]["MobileNo_N"].ToString();
                lblOwnerName.Text = ds.Tables[0].Rows[0]["BooksellerOwnerName_V"].ToString();
                lblRegAmount.Text = ds.Tables[0].Rows[0]["RegistrationAmount_N"].ToString();
                lblTellephoneNo.Text = ds.Tables[0].Rows[0]["TelephoneNo_V"].ToString();
                lblVailed.Text = ds.Tables[0].Rows[0]["Validity"].ToString();
                lblUserID.Text = ds.Tables[0].Rows[0]["LoginID_V"].ToString();
                lblPasseword.Text = ds.Tables[0].Rows[0]["UserPassowrd"].ToString();
                lblTellephoneNo0.Text = ds.Tables[0].Rows[0]["Address_V"].ToString();
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
        Response.Redirect("bookSellerReport.aspx");
    }
}
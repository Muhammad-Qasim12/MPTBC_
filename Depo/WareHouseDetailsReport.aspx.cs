using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
public partial class Depo_WareHouseDetailsReport : System.Web.UI.Page
{
    WareHouseMaster obWareHouseMaster = null;
    DistrictMaster obDistrictMaster = new DistrictMaster();
    DepoReport obDepoReport = new DepoReport();
   public  APIProcedure api = new APIProcedure();
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

            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            GridView1.DataSource = obWareHouseMaster.Select();
            GridView1.DataBind();
          
        }

    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //DataSet ds;
        //obDepoReport.UserID = Convert.ToInt32(Session["UserID"]);
        //obDepoReport.DistrictID = Convert.ToInt32(ddlDistrict.SelectedValue);
        //obDepoReport.ID = 0;
        //ds = obDepoReport.wareHousereport(); ;
        //GridView1.DataSource = ds.Tables[0];
        //GridView1.DataBind();
      //  Button4.Visible = true; 
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
}
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

public partial class CenterDepot_UploadExcelDataSupply : System.Web.UI.Page
{
    PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure api = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            VendorFill();
            //FillGrid();
        }
    }

   
    public void VendorFill()
    {
        try
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
            ddlVendor.DataTextField = "PaperVendorName_V";
            ddlVendor.DataValueField = "PaperVendorTrId_I";
            ddlVendor.DataBind();
            ddlVendor.Items.Insert(0, new ListItem("Select","0"));
        }
        catch { }
    }

    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            
        }
        catch { }
    }
    
    public void FillGrid()
    {
        try
        {
            string VendorID = ddlVendor.SelectedValue;

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();

            dsr = obCommonFuction.FillDatasetByProc("call USP_PRI_Show_ExcelFileUpload('"+ddlAcYear.SelectedItem.Text+"','" + VendorID + "')");
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();
            GrdLOI.Visible = true;
        }
        catch { }

    }

    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        int VenderID = 0;
        if (ddlVendor.SelectedItem.Text == "Select")
        {
            VenderID = 0;
        }
        else
        {
            VenderID = Convert.ToInt32(ddlVendor.SelectedValue);
        }

        DataSet dsr = new DataSet();
        dsr = obCommonFuction.FillDatasetByProc("call USP_PRI_Show_ExcelFileUpload('" + ddlAcYear.SelectedItem.Text + "','" + VenderID + "')");
        GrdLOI.DataSource = dsr;
        GrdLOI.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (ddlVendor.SelectedItem.Text == "Select" || ddlVendor.SelectedItem.Text == "")
        {
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select Paper Mill name.";
            return;
        }

        string ImgStatus = "", mapFile = "";
        string dirName = "CenterDepot_Upload";
        string filename = "";

        try
        {

            if (FLExcelData.FileName == "")
            {
                ImgStatus = "Ok";
            }
            else
            {
                ImgStatus = api.SingleuploadFileExcel(FLExcelData, dirName, 1024);
                mapFile = api.FullFileName;
                filename = FLExcelData.FileName;
                string mode = "Supply";
                string filePath = "~/" + dirName + "/" + mapFile;

                if (!string.IsNullOrEmpty(mapFile))
                {
                    DataTable dtt = obCommonFuction.FillTableByProc("call USP_PRI_Save_ExcelFileUpload(" +
                          "'" + filename + "', '" + filePath + "'," +
                        "'" + mode + "','0','" + ddlVendor.SelectedValue + "','" + ddlAcYear.SelectedItem.Text + "')");

                    string PId = dtt.Rows[0][0].ToString();
                    if (Convert.ToInt32(PId)>0)
                    {
                        FillGrid();
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('File uploaded successfully');</script>");
                    }
                }
            }
        }
        catch { }
    }
   
}
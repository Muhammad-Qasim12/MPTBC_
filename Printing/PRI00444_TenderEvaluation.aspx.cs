using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using MPTBCBussinessLayer;
public partial class Printing_PRI004_TenderEvaluation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
           // excel code
            if (FileUploadExcel.HasFile)
            {
                string filename = Path.GetFileName(FileUploadExcel.PostedFile.FileName);
                string Extension = Path.GetExtension(FileUploadExcel.PostedFile.FileName);            
                string filePath = Server.MapPath("~/Printing/Reports/" + filename);
                FileUploadExcel.SaveAs(filePath);
                DataTable dtEx = ImportTogrid(filePath, Extension, "Yes");
            }
        }
        catch { }
        finally { }
    }


 

    private DataTable ImportTogrid(string FilePath, string Extension, string IsHDR)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": // Excel 97-03
                conStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties='Excel 8.0;HDR={1}'";

                break;

            case ".xlsx": // Excel 07
                conStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Properties='Excel 8.0;HDR={1}'";
                break;
        }

        conStr = string.Format(conStr, FilePath, IsHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();

        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;
        // get first Sheet

        connExcel.Open();

        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        // read data from first sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";

        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();


        GrdEval.DataSource = dt;
        GrdEval.DataBind();       
        return dt;
    }
   
    class TenderEval
    {
        public string GroupId { get; set; }
        public string CompanyName { get; set; }
        public string Rates { get; set; }
        public string Rank { get; set; }
        public string TenderEvalID { get; set; }
        public string IsRegistered { get; set; }
        public string PrinterId { get; set; }
        public string GrpId { get; set; }


    }
}
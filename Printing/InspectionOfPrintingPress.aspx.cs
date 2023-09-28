using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;

public partial class Printing_InspectionOfPrintingPress : System.Web.UI.Page
{
    PRI_Inspection obInspection = new PRI_Inspection();
    CultureInfo cult = new CultureInfo("gu-IN", true);

    PRI_PrinterRegistration obPRI_PrinterRegistration = null;

    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) 
        {
            loadPrinters();
            if (Request.QueryString["Cid"] != null)
            {
                
                loadInspection();
            }
        }
    }

    public void loadPrinters()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {

            obPRI_PrinterRegistration.Printer_RedID_I = 0;

            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();

            ddlPrinter_RedID_I.DataTextField = "NameofPress_V";
            ddlPrinter_RedID_I.DataValueField = "Printer_RedID_I";

            ddlPrinter_RedID_I.DataSource = ds;

            ddlPrinter_RedID_I.DataBind();

            ddlPrinter_RedID_I.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }


    public int SaveInspection() 
    {
        int i = 0;

        obInspection = new PRI_Inspection();
        string path;
        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obInspection.InspectionTrno_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["Cid"]).ToString() );
            }

            else { obInspection.InspectionTrno_I = 0; }

            obInspection.Inspectiondate_D = Convert.ToDateTime(txtInspectiondate_D.Text, cult);
            obInspection.OfficerName_V = Convert.ToString(txtOfficerName_V.Text);
            obInspection.OfficerTrno_I = 1;
            obInspection.OfficerDesignation_V = Convert.ToString(txtOfficerDesignation_V.Text);
            obInspection.DesignationTrno_I = 1;
            obInspection.Printer_RedID_I = Convert.ToInt32(ddlPrinter_RedID_I.SelectedValue);
            obInspection.InspectionReport_V = Convert.ToString(txtInspectionReport_V.Text);

            
            string ImgStatus = "Ok";
            if (fileInspectionReportFile_V.HasFile)
            {
               
                ImgStatus = objapi.SingleuploadFile(fileInspectionReportFile_V, "Printing/PrintingFile", 1000);
                if (ImgStatus == "Ok")
                {
                    path = "PrintingFile/" + objapi.FullFileName;
                    // path = "PrintingFile/" + ddlPrinter_RedID_I.SelectedItem.Text.Replace(" ", "").ToString() + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(fileInspectionReportFile_V.FileName);
                     lblInspectionReportFile_V.Text = path;
                }


          
                
               
                //obPRI_PrinterRegistration.Profreadpath_v = path;
            }
           // obPRI_PrinterRegistration.Profreadpath_v = lblInspectionReportFile_V.Text;

            if (ImgStatus == "Ok")
            {
                obInspection.InspectionReportFile_V = Convert.ToString(lblInspectionReportFile_V.Text);

                obInspection.UserTrno_I = Convert.ToInt32(Session["UserId"]);

                i = obInspection.InsertUpdate();
            }
            else
            {
                i = 0;
            }


            //if (fileInspectionReportFile_V.HasFile)
            //{
            //    string path = "PrintingFile/" + ddlPrinter_RedID_I.SelectedItem.Text.Replace(" ", "").ToString() + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(fileInspectionReportFile_V.FileName);
            //    fileInspectionReportFile_V.SaveAs(Server.MapPath(path));

            //    lblInspectionReportFile_V.Text = path;

                
            //}


           

        }

        catch (Exception ex) { }

        finally { obInspection = null; }
        return i;
    }


    public void loadInspection()
    {
        DataSet ds = new DataSet();

        obInspection = new PRI_Inspection();

        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obInspection.InspectionTrno_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["Cid"]).ToString() );
            }
            ds = obInspection.Select();

            if (ds.Tables[0].Rows.Count > 0)
            {

                txtInspectiondate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["Inspectiondate_D"]);
                txtOfficerName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OfficerName_V"]);

                txtOfficerDesignation_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OfficerDesignation_V"]);

                ddlPrinter_RedID_I.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                txtInspectionReport_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["InspectionReport_V"]);
                lblInspectionReportFile_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["InspectionReportFile_V"]);

            }


        }

        catch (Exception ex) { }

        finally { obInspection = null; }
        
    }


    protected void btnSave_Click(object sender, EventArgs e) 
    {
        if (SaveInspection() > 0)
        {
            message("Details Saved.", "SUCCESS");
            Response.Redirect("VIEW_PRI007Inspection.aspx");

        }
        else 
        {
            message("ERROR.", "ERROR");
        }
    }



    protected void btnback_Click(object sender, EventArgs e)
    {

    }

    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }

}
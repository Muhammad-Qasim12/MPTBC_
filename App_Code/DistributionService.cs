﻿using System;
using System.Collections.Generic; 
using System.Web;
using System.Web.Services;
using System.Data;
using System.Text;
using System.Globalization;
using MPTBCBussinessLayer;

/// <summary>
/// Summary description for DistributionService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
//[System.Web.Script.Services.ScriptService]
public class DistributionService : System.Web.Services.WebService {

    public DistributionService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    CultureInfo cult = new CultureInfo("gu-IN", true);
    [WebMethod(EnableSession = true)]
    public string SavePrintingProofOtherinfo(string TitleID, string WorkID, string LetterNo, string letterDate, string StatusID, string remark)
    {

        MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();

        obPrinterProof.WorkOrderID_I = int.Parse(WorkID);
        obPrinterProof.TitleID_I = int.Parse(TitleID);
        obPrinterProof.OtherDetailLetterNo_V = LetterNo;
        obPrinterProof.OtherDetailLetterDate_D = DateTime.Parse(letterDate, cult).ToString("yyyy-MM-dd");
        obPrinterProof.StatusTrno_I = int.Parse(StatusID);
        obPrinterProof.Remark_V = remark;
        obPrinterProof.TransID = -1;

       // int retValue = 0;
       // int.TryParse( obPrinterProof.InsertUpdate().ToString() , out retValue);
       //if (retValue == 0)
       //    return "Please first save title information before saving other details";
       //else
       //    return GetPrintingProofOtherinfo(TitleID, WorkID);

        if (obPrinterProof.InsertUpdate().ToString() == "-1")
        {
            throw new NullReferenceException();
            
        }
        else
        {
            return GetPrintingProofOtherinfo(TitleID, WorkID);
        }
    }


    [WebMethod(EnableSession = true)]
    public string DeletePrintingProofOtherinfo(string PrinterProofVerificationOtherDetailsTrno, string TitleID, string WorkID)
    {

        MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();

        obPrinterProof.PrinterProofVerificationOtherDetailsTrno_I = int.Parse(PrinterProofVerificationOtherDetailsTrno);
      
        obPrinterProof.TransID = -2;

        obPrinterProof.InsertUpdate().ToString();
         return GetPrintingProofOtherinfo(TitleID, WorkID);

    }


    [WebMethod(EnableSession = true)]
    public string GetPrintingProofOtherinfo(string TitleID, string WorkID)
    {
        MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();
        obPrinterProof.QueryType = -3;
        obPrinterProof.ParameterValue = int.Parse(TitleID);
        obPrinterProof.ParameterValue2 = int.Parse(WorkID);

        DataSet dsOtherPrintProofDetails = obPrinterProof.Select();
        StringBuilder sbTableText= new StringBuilder();
        sbTableText.Append("<table class=\"tab\" >" );
        sbTableText.Append("<tr> <th> LetterNo </th> <th> Letter Date </th> <th> Status </th> <th> Remark </th> <th> </th> </tr> ");
        if (dsOtherPrintProofDetails.Tables[0] != null && dsOtherPrintProofDetails.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsOtherPrintProofDetails.Tables[0].Rows.Count; i++)
            {
                sbTableText.Append("<tr>");
                sbTableText.Append("<td>" + dsOtherPrintProofDetails.Tables[0].Rows[i]["LetterNo_V"] + "</td>" );
                sbTableText.Append("<td>" + DateTime.Parse( dsOtherPrintProofDetails.Tables[0].Rows[i]["LetterDate_D"].ToString() ).ToString("dd-MMM-yyyy") + "</td>");
                sbTableText.Append("<td>" + dsOtherPrintProofDetails.Tables[0].Rows[i]["Status_V"] + "</td>");
                sbTableText.Append("<td>" + dsOtherPrintProofDetails.Tables[0].Rows[i]["Remark_V"] + "</td>");
                sbTableText.Append("<td> <input type=\"button\" value=\"हटाएं\" class=\"btn\" id=\"btnDeleteOtherDetails*" + 
                                dsOtherPrintProofDetails.Tables[0].Rows[i]["PrinterProofVerificationOtherDetailsTrno_I"]  + 
                                "\" onclick=\"return DeleteOtherDetails(this)\" /> </td>");
                sbTableText.Append("</tr>");
            }
        }

        sbTableText.Append("</table>");

        return sbTableText.ToString();

    }

    #region AcademicB


    [WebMethod(EnableSession = true)]
    public string SavePrintingProofOtherinfo2(string TitleID, string WorkID, string LetterNo, string letterDate, string StatusID, string remark)
    {

        MPTBCBussinessLayer.AcademicB.PrinterProof obPrinterProof = new MPTBCBussinessLayer.AcademicB.PrinterProof();

        obPrinterProof.WorkOrderID_I = int.Parse(WorkID);
        obPrinterProof.TitleID_I = int.Parse(TitleID);
        obPrinterProof.OtherDetailLetterNo_V = LetterNo;
        obPrinterProof.OtherDetailLetterDate_D = DateTime.Parse(letterDate, cult).ToString("yyyy-MM-dd");
        obPrinterProof.StatusTrno_I = int.Parse(StatusID);
        obPrinterProof.Remark_V = remark;
        obPrinterProof.TransID = -1;

        // int retValue = 0;
        // int.TryParse( obPrinterProof.InsertUpdate().ToString() , out retValue);
        //if (retValue == 0)
        //    return "Please first save title information before saving other details";
        //else
        //    return GetPrintingProofOtherinfo(TitleID, WorkID);

        if (obPrinterProof.InsertUpdate().ToString() == "-1")
        {
            throw new NullReferenceException();

        }
        else
        {
            return GetPrintingProofOtherinfo2(TitleID, WorkID);
        }
    }

    [WebMethod(EnableSession = true)]
    public string DeletePrintingProofOtherinfo2(string PrinterProofVerificationOtherDetailsTrno, string TitleID, string WorkID)
    {

        MPTBCBussinessLayer.AcademicB.PrinterProof obPrinterProof = new MPTBCBussinessLayer.AcademicB.PrinterProof();

        obPrinterProof.PrinterProofVerificationOtherDetailsTrno_I = int.Parse(PrinterProofVerificationOtherDetailsTrno);

        obPrinterProof.TransID = -2;

        obPrinterProof.InsertUpdate().ToString();
        return GetPrintingProofOtherinfo2(TitleID, WorkID);

    }


    [WebMethod(EnableSession = true)]
    public string GetPrintingProofOtherinfo2(string TitleID, string WorkID)
    {
        MPTBCBussinessLayer.AcademicB.PrinterProof obPrinterProof = new MPTBCBussinessLayer.AcademicB.PrinterProof();
        obPrinterProof.QueryType = -3;
        obPrinterProof.ParameterValue = int.Parse(TitleID);
        obPrinterProof.ParameterValue2 = int.Parse(WorkID);

        DataSet dsOtherPrintProofDetails = obPrinterProof.Select();
        StringBuilder sbTableText = new StringBuilder();
        sbTableText.Append("<table class=\"tab\" >");
        sbTableText.Append("<tr> <th> LetterNo </th> <th> Letter Date </th> <th> Status </th> <th> Remark </th> <th> </th> </tr> ");
        if (dsOtherPrintProofDetails.Tables[0] != null && dsOtherPrintProofDetails.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < dsOtherPrintProofDetails.Tables[0].Rows.Count; i++)
            {
                sbTableText.Append("<tr>");
                sbTableText.Append("<td>" + dsOtherPrintProofDetails.Tables[0].Rows[i]["LetterNo_V"] + "</td>");
                sbTableText.Append("<td>" + DateTime.Parse(dsOtherPrintProofDetails.Tables[0].Rows[i]["LetterDate_D"].ToString()).ToString("dd-MMM-yyyy") + "</td>");
                sbTableText.Append("<td>" + dsOtherPrintProofDetails.Tables[0].Rows[i]["Status_V"] + "</td>");
                sbTableText.Append("<td>" + dsOtherPrintProofDetails.Tables[0].Rows[i]["Remark_V"] + "</td>");
                sbTableText.Append("<td> <input type=\"button\" value=\"हटाएं\" class=\"btn\" id=\"btnDeleteOtherDetails*" +
                                dsOtherPrintProofDetails.Tables[0].Rows[i]["PrinterProofVerificationOtherDetailsTrno_I"] +
                                "\" onclick=\"return DeleteOtherDetails(this)\" /> </td>");
                sbTableText.Append("</tr>");
            }
        }

        sbTableText.Append("</table>");

        return sbTableText.ToString();

    }

    #endregion

    [WebMethod(EnableSession=true)]

    public string SaveData(string strDemandType ,string strsession ,string strDepo ,string strDistrict ,string strScheme,string strClass, string data)
    {
        string[] strdata = data.Split('#');
        int datacount = 0;
        if (HttpContext.Current.Session["MyData"] != null)
        {
            try
            {
                DataTable dt = (DataTable)Session["MyData"];
                for (int introw = 0; introw <= dt.Rows.Count - 1; introw++)
                {
                    for (int intcol = 2; intcol <= dt.Columns.Count - 1; intcol++)
                    {
                        TextbookDemand obTextbookDemand = new TextbookDemand();
                        obTextbookDemand.blockId = Convert.ToInt32(dt.Columns[intcol].ColumnName.ToString());
                        // int value =strdata.Count()/(introw+1)+(intcol-2);
                        obTextbookDemand.NoOfBooks = Convert.ToInt32(strdata[datacount + 1]);
                        obTextbookDemand.TitleId_I = Convert.ToInt32(dt.Rows[introw][0]);
                        obTextbookDemand.UserId = 0;
                        obTextbookDemand.SchemeID = Convert.ToInt16(strScheme);
                        obTextbookDemand.AcYearId_V = strsession;
                        obTextbookDemand.DepoId = Convert.ToInt32(strDepo);
                        obTextbookDemand.DistrictId = Convert.ToInt32(strDistrict);
                        obTextbookDemand.EntryDate = System.DateTime.Now;
                        obTextbookDemand.DemandTypeId_I = Convert.ToInt32(strDemandType);
                        obTextbookDemand.DemandId_I = 0;
                        obTextbookDemand.InsertUpdate();
                        datacount++;
                    }

                }
            }
            catch { return "Due to some technical reason record not save"; }


            return "Record Save Successfully";
            
            
        }
        return "Hello World";
    }
    
}

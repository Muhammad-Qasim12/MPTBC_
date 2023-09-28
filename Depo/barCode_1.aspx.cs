﻿using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System;

public partial class Distrubution_barCode : System.Web.UI.Page
{
    public string InnerHtmlTag = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["TxtBundleNoFrom"] != "")
            {
                int StartNo = Convert.ToInt32(Request.QueryString["TxtBundleNoFrom"]);
                int EndNo = Convert.ToInt32(Request.QueryString["lblBundleNoTo"]);
                int NoOfBooks = Convert.ToInt32(Request.QueryString["Cnt"]);
                string title = Convert.ToString(Request.QueryString["Title"]);
                string Printer = Convert.ToString(Request.QueryString["Printer"]);
                string BookType = Convert.ToString(Request.QueryString["BookType"]);
                string AcYear = Convert.ToString(Request.QueryString["AcYear"]);
                string deponame = Convert.ToString(Request.QueryString["DepoName"]);
                long Bookstart = Convert.ToInt64(Request.QueryString["Bookstart"]);
                LblTitle.Text = title + " हेतु बंडलो के बारकोड ";
                int D = 1;

                for (int i = StartNo; i <= EndNo; i++)
                {
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
                    System.Web.UI.HtmlControls.HtmlGenericControl DIV = new System.Web.UI.HtmlControls.HtmlGenericControl();
                    // System.Web.UI.HtmlControls.HtmlGenericControl DIv1 = new System.Web.UI.HtmlControls.HtmlGenericControl();
                    //System.Web.UI.HtmlTextWriterTag html = new System.Web.UI.HtmlTextWriterTag(); 
                    string barCode = Convert.ToString(i);

                    //using (Bitmap bitMap = new Bitmap(barCode.Length * 50, 100))
                    //{
                    //using (Graphics graphics = Graphics.FromImage(bitMap))
                    //{
                    //    Font oFont = new Font("IDAutomationHC39M", 24);
                    //    PointF point = new PointF(2f, 2f);
                    //    SolidBrush blackBrush = new SolidBrush(Color.Black);
                    //    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    //    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    //    graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
                    //}

                    //using (MemoryStream ms = new MemoryStream())
                    //{
                    //    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    //    byte[] byteImage = ms.ToArray();
                    //    Convert.ToBase64String(byteImage);
                    //string DivMain = "<div style='width:1654;height:2339'>";
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    if (D == 1)
                    {
                        InnerHtmlTag = InnerHtmlTag + @"<div  style='display: block; page-break-before: always; letter-spacing:4px; padding:150px 10px 0 20px; width:1000px;height:1000px;margin:0px auto; text-align: center; font: normal 16px arial; line-height:30px;'>        
        <br><br><ul style='margin:0;padding:0;'> ";
                    }
                    InnerHtmlTag = InnerHtmlTag + "<li style='float: left; text-align: center; list-style:none;width:100%; height:900px;-webkit-transform-origin: left top;-webkit-transform:rotate(-90deg) translateX(-100%);'><span style='margin:0!important;padding:0 0 0 60px!important;font-size:60px;'> शिक्षा सत्र: " + AcYear + " </span><br><br><br> " +
                     "<span style='margin:0!important;font-size:65px;'> " + title + " (" + BookType + ")</span><br><br><br>" +
                     "<div style='font-family: Free3of9Regular; letter-spacing:4px!important; font-size:300px; padding: 0 0 0 0; line-height: 200px;'>" + "*" + i.ToString() + "*" + "</div><br><br><br>" +
                      "<span style='margin-top:0px;font-size:65px;'> बंडल क्रमांक :" + i + " </span></br></br><br>" +
                    "<span style='margin-top:0px;font-size:50px;'> पुस्तक क्रमांक :" + Bookstart + " से " + (Bookstart + NoOfBooks - 1) + " तक </span><br><br><br>" +
                     "<span style='margin-top:0px;font-size:65px;'> बंडल में कुल पुस्तके : " + NoOfBooks + " </span><br><br><br>" +
                     "<span style='margin-top:0px;font-size:65px;'> डिपो का नाम  : " + deponame + " </span><br><br><br>" +
                   "<span style='margin-top:0px;font-size:65px;line-height:20px;'> " + Printer + " </span></li>  ";
                    // "<span style='margin-top:0px;padding:0px!important'>शीर्षक: " + title + " </span></li> ";
                    if (D == 1)
                    {
                        InnerHtmlTag = InnerHtmlTag + "</ul></div>";
                        D = 0;
                    }
                    //}

                    // plBarCode.Controls.Add(imgBarCode);
                    // DIv.Controls.Add(new System.Web.UI.LiteralControl("</br>"));
                    //DIv.Controls.Add(DIv);
                    //  }
                    D = D + 1;
                    //if (D > 6)
                    //{
                    //    D = 1;
                    //}
                    Bookstart = Bookstart + NoOfBooks + 0;
                }
                if (D != 1)
                {
                    InnerHtmlTag = InnerHtmlTag + "</ul></div>";
                }
                //Ul.Controls.Add(DIV);
            }
        }
    }
    //protected void btnGenerate_Click(object sender, EventArgs e)
    //{

    //   // string barCode = txtCode.Text;


    //    for (int i = 10000; i <= 10020; i++)
    //    {
    //        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
    //        string barCode = Convert.ToString (i);
    //        using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 90))
    //        {
    //            using (Graphics graphics = Graphics.FromImage(bitMap))
    //            {
    //                Font oFont = new Font("IDAutomationHC39M", 12);
    //                PointF point = new PointF(2f, 2f);
    //                SolidBrush blackBrush = new SolidBrush(Color.Black);
    //                SolidBrush whiteBrush = new SolidBrush(Color.White);
    //                graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
    //                graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
    //            }
    //            using (MemoryStream ms = new MemoryStream())
    //            {
    //                bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    //                byte[] byteImage = ms.ToArray();

    //                Convert.ToBase64String(byteImage);
    //                imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
    //            }
    //            plBarCode.Controls.Add(imgBarCode);

    //        }
    //    }
    //}
}
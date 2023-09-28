using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CaptchaHandler1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string s = Request.QueryString.Get("txt"); 
        Response.ContentType = "image/gif";
        CreateImage(s).Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
    }
    private static Bitmap CreateImage(string sImageText)
    {

        Bitmap bmpImage = new Bitmap(1, 1);

        int iWidth = 0;
        int iHeight = 0;

        Font MyFont = new Font("verdhna", 18, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
        Graphics MyGraphics = Graphics.FromImage(bmpImage);
        iWidth = Convert.ToInt32(MyGraphics.MeasureString(sImageText, MyFont).Width) + 20;
        iHeight = Convert.ToInt32(MyGraphics.MeasureString(sImageText, MyFont).Height) + 4;
        bmpImage = new Bitmap(bmpImage, new Size(iWidth, iHeight));
        MyGraphics = Graphics.FromImage(bmpImage);
        MyGraphics.Clear(Color.FromArgb(242, 242, 242));
        MyGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        MyGraphics.DrawString(sImageText, MyFont, new SolidBrush(Color.FromArgb(15, 87, 201)), 10, 4);
        MyGraphics.Flush();
        return (bmpImage);
    }
}
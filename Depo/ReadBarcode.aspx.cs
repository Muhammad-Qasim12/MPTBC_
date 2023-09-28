using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MPTBCBussinessLayer;

public partial class Distrubution_ReadBarcode : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
 
 
    protected void TxtCode_TextChanged(object sender, EventArgs e)
    {
      
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LblCode.Text = "बंडल नंबर : " + TxtCode.Text;

        DataSet DS = new DataSet();
        //TxtCode.Text = "1090010516";

        DS = obCommonFuction.FillDatasetByProc("CALL USP_DISGetBundleInfo(  " + Convert.ToInt64(TxtCode.Text) + ")");
        if (DS.Tables[0].Rows.Count > 0)
        {
            try {
            LblBook.Text = DS.Tables[0].Rows[0]["TitleHindi_V"].ToString();
            lblDepo.Text = DS.Tables[0].Rows[0]["DepoName_V"].ToString();
            lblPrinter.Text = DS.Tables[0].Rows[0]["NameofPress_V"].ToString();
            lblAcyear.Text = DS.Tables[0].Rows[0]["AcYear"].ToString();
            lblbookNo.Text = DS.Tables[0].Rows[0]["mPackBundleBookNumberFrom"].ToString();
            lblbookNoto.Text = DS.Tables[0].Rows[0]["mPackBundleBookNumberto"].ToString();
            lblTotalBook.Text = DS.Tables[0].Rows[0]["BooksPerBundle"].ToString();
            lblBookType.Text = DS.Tables[0].Rows[0]["BookType1"].ToString(); ;

            try
            {
                lbl1.Text = DS.Tables[1].Rows[0]["ChalanNo"].ToString();
                lbl2.Text = DS.Tables[1].Rows[0]["ChalanDate"].ToString();
                lbl3.Text = DS.Tables[1].Rows[0]["DepoName_V"].ToString();
                lbl4.Text = DS.Tables[1].Rows[0]["ReceivedDate"].ToString();

            }
            catch
            {

            }

            try {
                lbl5.Text = DS.Tables[2].Rows[0]["DepoName_V"].ToString() + "-" + DS.Tables[2].Rows[0]["Challan"].ToString();
            }
            catch { }
            }
            catch { }
        }
        else
        {

            LblBook.Text = "";
            lblDepo.Text = "";
            lblPrinter.Text = "";
            lblAcyear.Text ="";
            lblbookNo.Text = "";
            lblbookNoto.Text = "";
            lblTotalBook.Text = "";
            lblBookType.Text = "";
            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
        }
    }
}
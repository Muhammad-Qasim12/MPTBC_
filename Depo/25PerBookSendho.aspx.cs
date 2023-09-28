using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;
public partial class Depo_25PerBookSendho : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CountingDetails obCountingDetails = null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();

            DataSet dd = comm.FillDatasetByProc("call USP_DPT25PerLoad(" + Convert.ToInt32(Session["UserID"]) + ",0,1,'" + DdlACYear.SelectedItem.Text + "')");
            DropDownList1.DataTextField = "NameofPress_V";
            DropDownList1.DataValueField = "Printer_RedID_I";
            DropDownList1.DataSource = dd.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("All", "0"));
            fillgrd();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = comm.FillDatasetByProc(@" SELECT  `ChallanNo_V`, `PriTransID` FROM dpt_stockreceivedtwentyfiveper_m
INNER JOIN  prin_deleverydetails ON   dpt_stockreceivedtwentyfiveper_m.PinterID_I= prin_deleverydetails.PriTransID
         INNER JOIN pri_printerregistration_t ON pri_printerregistration_t.Printer_RedID_I=prin_deleverydetails.User_ID
 WHERE dpt_stockreceivedtwentyfiveper_m.userID=" +Session["UserID"]+" AND `AcYear`='"+DdlACYear.SelectedValue+"' AND pri_printerregistration_t.`Printer_RedID_I`="+DropDownList1.SelectedValue+"");
        DropDownList2.DataTextField = "ChallanNo_V";
        DropDownList2.DataValueField = "PriTransID";
        DropDownList2.DataSource = dd.Tables[0];
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        DataSet dtr = comm.FillDatasetByProc(@" SELECT `BundleNo_I`,ToNo_I,FromNo_I FROM `dpt_stockdetailschild_t` WHERE `PritransID`=" + DropDownList2.SelectedValue + " AND '" + TextBox1.Text + "' BETWEEN `FromNo_I` AND `ToNo_I`");
        if (dtr.Tables[0].Rows.Count > 0)
        {
            Label1.Text = dtr.Tables[0].Rows[0]["BundleNo_I"].ToString();
            HiddenField1.Value = dtr.Tables[0].Rows[0]["FromNo_I"].ToString();
            HiddenField2.Value = dtr.Tables[0].Rows[0]["ToNo_I"].ToString();
        }
        else
        {
            TextBox1.Text="";
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dt = comm.FillDatasetByProc(" INSERT INTO tbl_SendBookHO(DepoID, YEAR ,   printerName,  CHallanID,  BookNo , bundelNo , LetterNo , LetterDate ) VALUES ('" + Session["UserID"].ToString() + "','" + DdlACYear.SelectedValue + "','" + DropDownList1.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + TextBox1.Text + "','" + Label1.Text + "','" + TextBox2.Text + "','" + Convert.ToDateTime(TextBox3.Text, cult).ToString("yyyy-MM-dd") + "')");
        comm.FillDatasetByProc("CALL `CurserLooj`(" + HiddenField1.Value + "," + HiddenField2.Value + ","+Label1.Text+")");
        fillgrd();
        comm.EmptyTextBoxes(this);
    }
    public void fillgrd()
    {
        GridView1.DataSource = comm.FillDatasetByProc(@"SELECT DepoID, YEAR , `NameofPress_V` ,  CHallanID,  BookNo , bundelNo , LetterNo , LetterDate 
 FROM tbl_SendBookHO
 INNER JOIN `pri_printerregistration_t` ON pri_printerregistration_t.`Printer_RedID_I`=printerName where DepoID="+Session["userID"].ToString ()+"");
    }
}
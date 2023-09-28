using System;
using System.Data;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using MPTBCBussinessLayer.Paper;

public partial class Distribution_ReduceVitranNirdesh : System.Web.UI.Page
{
    DIS_VitranNirdesh obVitranNirdesh = new DIS_VitranNirdesh();
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Random rdm = new Random();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            LblFyYear.Text = DdlACYear.SelectedItem.Text;
         //   DdlACYear_SelectedIndexChanged(sender, e);
            DdlGroup.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS002_GroupCreationLoad(0)");
            DdlGroup.DataValueField = "GroupId";
            DdlGroup.DataTextField = "GroupName";
            DdlGroup.DataBind();

            //DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            //DdlTitle.DataValueField = "GroupId";
            //DdlTitle.DataTextField = "GroupName";
            //DdlTitle.DataBind();

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "ClassDesc_V";
            DdlClass.DataBind();
            DdlClass.Items.Insert(0, "--Select--");

           // TxtOrderNO.Text = System.DateTime.Now.ToString("ddMMssmm") + RandomNumber();

        }
    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        CommonFuction obCommonFuction = new CommonFuction();


        DdlTitle.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_TitleLoadClassWiseNew(" + Convert.ToInt32(DdlClass.SelectedValue) + ",'"+DdlACYear.SelectedValue+"')");
        DdlTitle.DataValueField = "TitleID_I";
        DdlTitle.DataTextField = "TitleHindi_V";
        DdlTitle.DataBind();
        //DdlTitle.Items.Insert(0, "--Select--");
        DdlTitle.Items.Insert(0, new ListItem("-Select-", "0"));


        DdlPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS_GetPrintersByTitleNDepot('" + Convert.ToInt32(DdlTitle.SelectedValue) + "','" + Convert.ToInt32(DdlGroup.SelectedValue) + "','" + DdlACYear.SelectedItem.Text + "')");
        DdlPrinter.DataValueField = "Printer_RegID_I";
        DdlPrinter.DataTextField = "NameOfPress_V";
        DdlPrinter.DataBind();

    }
    protected void DdlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {


        DdlPrinter.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS_GetPrintersByTitleNDepot('" + Convert.ToInt32(DdlTitle.SelectedValue) + "','" + Convert.ToInt32(DdlGroup.SelectedValue) + "','" + DdlACYear.SelectedItem.Text + "')");
        DdlPrinter.DataValueField = "Printer_RegID_I";
        DdlPrinter.DataTextField = "NameOfPress_V";
        DdlPrinter.DataBind();
        DdlPrinter.Items.Insert(0, new ListItem("--Select--", "0"));
        DataSet dd = obCommonFuction.FillDatasetByProc("call GettotleBookinBandle(" + DdlTitle.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
        //DataSet dd = obCommonFuction.FillDatasetByProc("call GettotleBookinBandle(" + DdlTitle.SelectedValue + ")");
        TextBooksPerBundle.Text = dd.Tables[0].Rows[0]["BookNumber"].ToString();
        //TxtBooksPerGaddi.Text = Convert.ToString(Convert.ToInt32(TextBooksPerBundle.Text) / 4);

    }
    protected void DdlGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
        DdlClass.DataValueField = "ClassTrno_I";
        DdlClass.DataTextField = "Classdet_V";
        DdlClass.DataBind();
        // DdlClass.Items.Insert(0, "--Select--");
        DdlClass.Items.Insert(0, new ListItem("--Select--", "0"));
        DdlClass_SelectedIndexChanged(sender, e);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
      //  USP_VitranNirdeshReduce
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_VitranNirdeshReduce('"+DdlACYear.SelectedValue+"',"+DdlTitle.SelectedValue+","+DdlBookType.SelectedValue+","+DdlPrinter.SelectedValue+")");
        GridView1.DataBind();
        Button1.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        { 
             if (Convert.ToString(((TextBox)GridView1.Rows[i].FindControl("txtnoofbookReduce")).Text)!="")
            {
                //USP_Updatedis_vitrannirdesh
                if (txtOrderDate.Text == "")
                {
                    txtOrderDate.Text = "01/01/1900";
                }

                obCommonFuction.FillDatasetByProc("call USP_Updatedis_vitrannirdesh('" + txtOrderNo.Text + "','" + Convert.ToDateTime(txtOrderDate.Text, cult).ToString("yyyy-MM-dd") + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtnoofbookReduce")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtReduceBundle")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtReaminBundle")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtBundelNOTo")).Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("txtbookNoTO")).Text + "',"+((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value+")");
            
            }
        
        }
        mainDiv.Style.Add("display", "block");
        lblmsg.Style.Add("display", "block");
        lblmsg.Text = "डिपोवार आवंटन रिपोट सम्बंधित डिपो एवं मुद्रक को प्रेषित किया गया ";
        GridView1.DataSource = null;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtnoofbookReduce_TextChanged(object sender, EventArgs e)
    {
        TextBox chkbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        TextBox txtnoofbookReduce = ((TextBox)grd.FindControl("txtnoofbookReduce"));
       TextBox txtReaminBundle=((TextBox)grd.FindControl ("txtReaminBundle"));
        TextBox txtBundelNOFrom=((TextBox)grd.FindControl ("txtBundelNOFrom"));
        TextBox txtBundelNOTo=((TextBox)grd.FindControl ("txtBundelNOTo"));
         TextBox txtbookNoFrom=((TextBox)grd.FindControl ("txtbookNoFrom"));
        TextBox txtbookNoTO=((TextBox)grd.FindControl ("txtbookNoTO"));
        TextBox txtReduceBundle = ((TextBox)grd.FindControl("txtReduceBundle"));

        txtReduceBundle.Text = txtReaminBundle.Text = Convert.ToString((Convert.ToInt32(txtnoofbookReduce.Text)) / Convert.ToInt32(TextBooksPerBundle.Text));
        txtReaminBundle.Text = Convert.ToString((Convert.ToInt32 (grd.Cells[1].Text)- Convert.ToInt32(txtnoofbookReduce.Text)) / Convert.ToInt32(TextBooksPerBundle.Text));
        txtBundelNOTo.Text = Convert.ToString(Convert.ToInt32(txtBundelNOFrom.Text) + Convert.ToInt32(txtReaminBundle.Text));
        txtbookNoTO.Text = Convert.ToString(Convert.ToInt32(txtbookNoFrom.Text) + (Convert.ToInt32(grd.Cells[1].Text) - Convert.ToInt32(txtnoofbookReduce.Text)));

        
     
    }
}
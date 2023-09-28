using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Depo_DPT010_BookReturnDetails : System.Web.UI.Page
{
    DataTable bookDetails = new DataTable();
    public int d; DPT_DepotMaster obDepoMaster = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BookReturn obBookReturn =null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //obDepoMaster = new DPT_DepotMaster();
            //DataSet dtDepo = obDepoMaster.Select();
            DataSet dtDepo = comm.FillDatasetByProc("Call USP_DPT_DepoNamebyBookseller("+Session["UserID"]+")");
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataSource = dtDepo.Tables[0];
            ddlDepo.DataBind();
            
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtOrderNo.Text = randnum.ToString();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        d = Convert.ToInt32(ViewState["d"]);
        if (txtbookNo.Text == "")
        {
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please Enter Book No";

        }
            else if (ddlReason.SelectedIndex==0)
        {
           lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select Reason ";
        }
        else
        {
            if (d == 0)
            {
                MakeTable();
            }
            bookDetails = (DataTable)ViewState["_bookDetails"];
            DataRow tr = bookDetails.NewRow();
            tr[0] = bookDetails.Rows.Count + 1;
            tr[1] = lblSub.Text;
            tr[2] = txtbookNo.Text;
            tr[3] = ddlReason.SelectedItem.Text;
            tr[4] = HiddenField2.Value;
            tr[5] = HiddenField3.Value;
            tr[6] = lblClass.Text;
            tr[7] = hdbookDate.Value;
            tr[8] = hdOrdeeNo.Value;
            tr[9] = hdmidum.Value;
            bookDetails.Rows.Add(tr);

            grdBook.DataSource = bookDetails;
            grdBook.DataBind();
            if (grdBook.Rows.Count > 0)
            {
                aaaa.Style.Add("display", "block");
            }
            ViewState["_dtVisitDetails"] = bookDetails;
            ViewState["d"] = d + 1;
            lblTotalNo.Text = Convert.ToString(ViewState["d"]);
            Button1.Visible = true;
            txtbookNo.Text = "";
            HiddenField2.Value = "";
            HiddenField3.Value = "";
        }
    }
    public void MakeTable()
    {
        bookDetails.Columns.Add("Sno", Type.GetType("System.Int32"));
        bookDetails.Columns.Add("SubjectName", Type.GetType("System.String"));
        bookDetails.Columns.Add("BookNo", Type.GetType("System.String"));
        bookDetails.Columns.Add("Reason", Type.GetType("System.String"));
        bookDetails.Columns.Add("BandalNO", Type.GetType("System.Int32"));
        bookDetails.Columns.Add("TitaleID", Type.GetType("System.Int32"));
        bookDetails.Columns.Add("ClassName", Type.GetType("System.String"));
        bookDetails.Columns.Add("Date", Type.GetType("System.String"));
        bookDetails.Columns.Add("OrderNO", Type.GetType("System.String"));
        bookDetails.Columns.Add("Medium", Type.GetType("System.String"));
        ViewState["_bookDetails"] = bookDetails;
    }
    protected void grdBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            bookDetails = (DataTable)ViewState["_bookDetails"];
            bookDetails.Rows[e.RowIndex].Delete();
            bookDetails.AcceptChanges();
            if (bookDetails.Rows.Count > 0)
            {
                ViewState["_dtVisitDetails"] = bookDetails;
                grdBook.DataSource = ViewState["_dtVisitDetails"];
                grdBook.DataBind();
                lblTotalNo.Text = bookDetails.Rows.Count.ToString ();
            }
            else
            {
                grdBook.DataSource = new DataTable();
                grdBook.DataBind();
                
            }
        }
        catch (Exception ex)
        {
            

        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {

        obBookReturn = new BookReturn(); CommonFuction comm = new CommonFuction();
        for (int i = 0; i < grdBook.Rows.Count; i++)
        {
            
            comm.FillDatasetByProc("call USP_DPT013_BookReturns_Save(0,'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToString(grdBook.Rows[i].Cells[4].Text) + "','" + Convert.ToString(txtRemark.Text) + "','" + Convert.ToInt32(Session["UserID"]) + "','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToInt32(((HiddenField)grdBook.Rows[i].FindControl("HiddenField1")).Value) + "','" + Convert.ToString(grdBook.Rows[i].Cells[5].Text) + "','" + Convert.ToInt32(ddlDepo.SelectedValue) + "',0,'" + Convert.ToString(txtOrderNo.Text) + "','" + Convert.ToInt32(((HiddenField)grdBook.Rows[i].FindControl("HiddenField4")).Value) + "')");
           
        }
        Response.Redirect("VIEW_DPT010.aspx");


    }
    protected void txtbookNo_TextChanged(object sender, EventArgs e)
    {
        obBookReturn = new BookReturn();
       
            obBookReturn.ID = Convert.ToInt32(txtbookNo.Text);
            DataSet obDataSet = obBookReturn.fillDatabyBandalno();
            if (obDataSet.Tables[0].Rows.Count > 0)
            {
                lblClass.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Classdet_V"]);
                lblSub.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TitleHIndi_V"]);
                HiddenField2.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["BundleNo_I"]);
                HiddenField3.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["SubJectID_I"]);
                hdmidum.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["MediunNameHindi_V"]);
                hdOrdeeNo.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["OrderNo"]);
                hdbookDate.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["DDDate"]);
            }
            else
            {
                txtbookNo.Text = "";
            }
       
    }
}
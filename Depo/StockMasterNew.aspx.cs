using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;


public partial class Depo_StockMasterNew : System.Web.UI.Page
{
    int TotalBandal, count1; int total = 0, count12;

    MediumMaster obMediumMaster = null;
    ClassMaster obClass = null;
    WareHouseMaster obWareHouseMaster = null;
    StockMaster obStockMaster = new StockMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int id = 0;
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "2")
        {
            ddlBookType.Visible = true;
        }
        else
        {
            ddlBookType.Visible = false;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "सलेक्ट करे ..");
            //----------------Class Bind

            //obClass = new ClassMaster();
            //DataSet dtclass = obClass.Select();
            //obClass.ClassTrno_I = 0;
            //ddlCls.DataTextField = "Classdet_V";
            //ddlCls.DataValueField = "ClassTrno_I";
            //ddlCls.DataSource = dtclass.Tables[0];
            //ddlCls.DataBind();
            //ddlCls.Items.Insert(0, "सलेक्ट करे ..");

            //---------------------Warehouse Name
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserId"]);
            DataSet ds = obWareHouseMaster.Select();
            ddlWarehouse.DataTextField = "WareHouseName_V";
            ddlWarehouse.DataValueField = "WareHouseID_I";
            ddlWarehouse.DataSource = ds.Tables[0];
            ddlWarehouse.DataBind();
            ddlWarehouse.Items.Insert(0, "सलेक्ट करे ..");

        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        //Session["OfficeTrNo"] = 1;
        obStockMaster = new StockMaster();
        obStockMaster.Date_D = Convert.ToDateTime(txtDate.Text, cult);
        obStockMaster.WareHouseID_I = Convert.ToInt32(ddlWarehouse.SelectedValue);
        obStockMaster.MediamID_I = Convert.ToInt32(ddlMedium.SelectedValue);
        obStockMaster.BookType_I = Convert.ToInt32(ddlType.SelectedValue);
        obStockMaster.ClassID_I = Convert.ToInt32(ddlCls.SelectedValue);
        obStockMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
        obStockMaster.TypeDetails = Convert.ToInt32(RadioButtonList1.SelectedValue);
        obStockMaster.Trans_I = 0;
        obStockMaster.DepoID_I = Convert.ToInt32(Session["UserID"]);
        obStockMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
        id = obStockMaster.InsertUpdate();
      
        if (id != 0)
        {
            HdnMasterHdnId.Value = id.ToString();

            //  GID.Visible = true;
            //   a.Visible = false;
            string Classes;
            CommonFuction comm = new CommonFuction();
            if (ddlCls.SelectedItem.Text == "1-8")
            { Classes = "1,2,3,4,5,6,7,8"; }
            else
            { Classes = "9,10,11,12"; }

            //DataSet ds12 = obStockMaster.Select1(Convert.ToInt32(Classes), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt32(RadioButtonList1.SelectedValue), Convert.ToInt32(ddlBookType.SelectedValue), Convert.ToInt32(ddlWarehouse.SelectedValue), Convert.ToInt32(ddlWarehouse.SelectedValue), Convert.ToDateTime(txtDate.Text, cult), Convert.ToInt32(HdnMasterHdnId.Value));
            DataSet ds12 = comm.FillDatasetByProc("call USP_DPT011FatchBookData('" + Classes + "'," + Convert.ToInt32(ddlMedium.SelectedValue) + ", " + Convert.ToInt32(RadioButtonList1.SelectedValue) + ", " + Convert.ToInt32(ddlBookType.SelectedValue) + "," + Convert.ToInt32(ddlWarehouse.SelectedValue) + "," + Convert.ToInt32(Session["UserID"]) + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "', " + Convert.ToInt32(HdnMasterHdnId.Value) + ")");
            grBook.DataSource = ds12.Tables[0];
            grBook.DataBind();


        }
    }
    public class GenarteLoosebundle
    {
        public string BookNo { get; set; }

    }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try { 
            Button bt = (Button)sender;
            GridViewRow grd = (GridViewRow)(bt.NamingContainer);
            Label lblbun = (Label)grd.FindControl("lblbun");
        //    lblbun.Text = "बंडल क्रमांक";
            List<GenarteLoosebundle> List = new List<GenarteLoosebundle>();
            TextBox txtf = (TextBox)grd.FindControl("txtFromBookNo");
            TextBox txtf1 = (TextBox)grd.FindControl("txtFromBookNo");
            TextBox txtPer = (TextBox)grd.FindControl("txtPerBundleBook");

            TextBox txtNofBooks = (TextBox)grd.FindControl("txtNofBooks");
            TextBox txtTo = (TextBox)grd.FindControl("txtToBookNo");
            TextBox txtTo1 = (TextBox)grd.FindControl("txtToBookNo");
            TextBox txtBundle = (TextBox)grd.FindControl("txtBundleNo");
            HiddenField HiddenField1=(HiddenField)grd.FindControl ("HiddenField1");
                   
          
            StockDetailsChild obStockDetailsChild = new StockDetailsChild();
            bool checkforUpdate = true;
            

            if (bt.CommandArgument == "")
            {


                StockDetails obStockDetails = new StockDetails();
                if (txtNofBooks.Text != "")
                {
                    obStockDetails.NoOfBooks_I = Convert.ToInt32(txtNofBooks.Text);
                }

                obStockDetails.Stock_ID_I = Convert.ToInt32(HdnMasterHdnId.Value);
                obStockDetails.SubJectID_I = Convert.ToInt32(HiddenField1.Value);
                obStockDetails.Trans_I = 0;
                obStockDetails.BookType_I = Convert.ToInt32(ddlType.SelectedValue);

                HdnTrasactionID.Value = Convert.ToString(obStockDetails.InsertUpdate());
            }
            else
            {
                HdnTrasactionID.Value = bt.CommandArgument;
            }

            
              //  lblbun.Text = "बंडल क्रमांक से";
                int toBundle = (Convert.ToInt32(txtTo1.Text) - Convert.ToInt32(txtf1.Text) + 1) / Convert.ToInt32(txtPer.Text);
                int reminderBundle = (Convert.ToInt32(txtTo1.Text) - Convert.ToInt32(txtf1.Text) + 1) % Convert.ToInt32(txtPer.Text);
                int FrombokkNo = Convert.ToInt32(txtf1.Text);
                for (int i = Convert.ToInt32(txtBundle.Text); i < Convert.ToInt32(txtBundle.Text) + toBundle; i++)
                {
                    obStockDetailsChild.BundleNo_I = i;
                    obStockDetailsChild.FromNo_I = FrombokkNo;
                    obStockDetailsChild.ToNo_I = FrombokkNo + Convert.ToInt32(txtPer.Text) - 1;
                    obStockDetailsChild.Trans_I = 0;

                    obStockDetailsChild.RemaingLoose_V = "";
                    obStockDetailsChild.StockDetailsChildID_I = 0;
                    obStockDetailsChild.StockDetailsID_I = Convert.ToInt32(HdnTrasactionID.Value);
                    obStockDetailsChild.InsertUpdate();
                    FrombokkNo = obStockDetailsChild.ToNo_I + 1;
                }
                
           
          
            txtPer.Text = "";
            //txtNofBooks.Text = "";
            txtBundle.Text = "";
            txtTo.Text = "";
            bt.Enabled = false;
            }
            catch { }
        }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;
public partial class Depo_DPT015_Bookreceived : System.Web.UI.Page
{
    int totalBook = 0;
    WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = new CommonFuction ();
    StockMaster obStockMaster = new StockMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true); string SubQuery;
    BookReceivedDetails obBookReceivedDetails = new BookReceivedDetails();
    int id = 0;
    protected void grdPrinterBundleDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    totalBook += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[5].Text.Replace("&nbsp;", "0"));//Convert.ToInt32(e.Row.Cells[1].Text);
                    // total_BundleNo_IMin += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text);

                }
                catch { }
               



            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[5].Text = totalBook.ToString();
          
            //e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            //e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            //e.Row.Cells[9].Text = total_FromNo_I.ToString();
            //e.Row.Cells[10].Text = total_ToNo_I.ToString();

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCommonFuction = new CommonFuction();

            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            lblDepoChalan.Text = randnum.ToString();
            lblDepoChalan.Enabled = false;
           

            string user = Session["UserName"].ToString().ToLower();
            string userName = user.Replace("depo", "");
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('" + userName + "')");
            ddldepoEmployee.DataSource = ds.Tables[0];
            ddldepoEmployee.DataTextField = "Name";
            ddldepoEmployee.DataValueField = "EmployeeID_I";
             ddldepoEmployee.DataBind();
             lblDepochalanDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
               //   obCommonFuction = new CommonFuction();
            ddlFyYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlFyYear.DataValueField = "AcYear";
            ddlFyYear.DataTextField = "AcYear";
            ddlFyYear.DataBind();
            ddlFyYear.Items.Insert(0,"Select..");
        }
    }
    protected void ChechedChangeWholeBundle(object sender, EventArgs e)
    {
    }

    protected void ChechedChangeLooseBundle(object sender, EventArgs e)
    {
    }

    protected void grdDepoTransfer_RowDataBoundNew(object sender, GridViewRowEventArgs e)
    { 
    }
    protected void grdDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try {
            BookDitribute obBookReceivedDetails = new BookDitribute();

            obBookReceivedDetails.ChallanDate_D = Convert.ToDateTime(lblDepochalanDate.Text, cult);
            obBookReceivedDetails.ChallanNo_V = Convert.ToString(lblDepoChalan.Text);
            obBookReceivedDetails.Ddate_D = Convert.ToDateTime(lblDepochalanDate.Text, cult);
            obBookReceivedDetails.EmployeeName_I = Convert.ToInt32(ddldepoEmployee.SelectedValue);
            obBookReceivedDetails.GRDate_D = Convert.ToDateTime(txtDepoGrnoDate.Text, cult);
            obBookReceivedDetails.GRNo_V = Convert.ToString(txtDepoGrno.Text);
            obBookReceivedDetails.IsStanderd_I = 0;
            obBookReceivedDetails.LordingCharge_N = Convert.ToInt32(txtdepolOading.Text);
            obBookReceivedDetails.OrderDate_D = Convert.ToDateTime(lblDepoOrderdate.Text, cult);
            obBookReceivedDetails.OrderNo_I = Convert.ToString(ddlOrderNo.SelectedValue);
            obBookReceivedDetails.OtherCharges_N = Convert.ToInt32(txtDepoother.Text);
            obBookReceivedDetails.DistributeType_I = Convert.ToInt32(2);
            obBookReceivedDetails.Stock_ID_I = Convert.ToInt32(id);
            obBookReceivedDetails.TransactionDate_N = Convert.ToDateTime(System.DateTime.Now, cult);
            obBookReceivedDetails.TransportationCharge_N = Convert.ToInt32(txtDepoTransport.Text);
            obBookReceivedDetails.TruckNo_V = Convert.ToString(txtDepoTruck.Text);
            obBookReceivedDetails.TwentyfivePerStatus_I = 0;
            obBookReceivedDetails.unLordingCharge_N = Convert.ToInt32(txtDepoUnloading.Text);
            obBookReceivedDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            obBookReceivedDetails.BundleNo = Convert.ToString(txtDepoGrno.Text); ;
            obBookReceivedDetails.LooseBookNo = Convert.ToString(Convert.ToDateTime(txtDepoGrnoDate.Text, cult).ToString("yyyy-MM-dd"));


            obBookReceivedDetails.InsertUpdate();

        //try
        //{
        //    //DataSet ds = new DataSet(); ;
        //    MailHelper objSendSms = new MailHelper();
        //    obCommonFuction = new CommonFuction();
        //    string Msg = "", DepotMoblNo = "";
        //    //Usp_Get_SMS_MobileNo
        //    //ds = 
        //    DataSet ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
        //   Msg = "( Inter Depot Distribution) Receiver Depot & Order No: " + ddlOrderNo.Text + ",Challan No & Date: " + lblDepoChalan.Text + "-" + lblDepochalanDate.Text + ", Sender Depot : " + Session["UserName"];
           
        //    foreach (DataRow Dr in ds.Tables[0].Rows)
        //    {
        //        if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Distribution")
        //        {
        //            try
        //            {
        //                objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
        //            }
        //            catch { }
        //        }
        //        //if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
        //        //{
        //        //    try
        //        //    {
        //        //        objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
        //        //    }
        //        //    catch { }
        //        //}

        //        try
        //        {
        //            // Paper Vendor
                   
        //            DepotMoblNo = obCommonFuction.FillDatasetByProc("CALL GetMobleNumberDeport(" + Session["UserID"] + ",0,0)").ToString();
        //            objSendSms.sendMessage(DepotMoblNo, Msg);
        //        }
        //        catch { }


        //    }
        //}
        //catch { } 

      
             SubQuery="";
            for (int i=0;i<=grdDepoTransfer.Rows.Count-1;i++)
            {
                if (((CheckBox)grdDepoTransfer.Rows[i].FindControl("CheckBox1")).Checked == true)
            
                { 

                    if (SubQuery == "")
                    {
                        SubQuery = SubQuery + "(" + Session["UserID"] + "," + ddlOrderNo.SelectedValue + ",'" + lblDepoChalan.Text + "','" + grdDepoTransfer.Rows[i].Cells[5].Text + "'," + ((TextBox)grdDepoTransfer.Rows[i].FindControl("TextBox1")).Text + "," + ((HiddenField)grdDepoTransfer.Rows[i].FindControl("HiddenField1")).Value + "," + ((HiddenField)grdDepoTransfer.Rows[i].FindControl("booktype")).Value + ")";//booktype
                    }
                    else
                    {
                        SubQuery = SubQuery + ",(" + Session["UserID"] + "," + ddlOrderNo.SelectedValue + ",'" + lblDepoChalan.Text + "','" + grdDepoTransfer.Rows[i].Cells[5].Text + "'," + ((TextBox)grdDepoTransfer.Rows[i].FindControl("TextBox1")).Text + "," + ((HiddenField)grdDepoTransfer.Rows[i].FindControl("HiddenField1")).Value + "," + ((HiddenField)grdDepoTransfer.Rows[i].FindControl("booktype")).Value + ")";
                    }
                }

            }

            try {
                obCommonFuction = new CommonFuction();
            //obCommonFuction.FillDatasetByProc("INSERT INTO dpt_interdepoBookSupply(SupplierDepoID, ReqNo, ChallanNo, NetDemand, Supply,TitleID)VALUES "+SubQuery+"");
                obCommonFuction.FillDatasetByProc(@"insert into dpt_interdepoBookSupply(SupplierDepoID, ReqNo, ChallanNo, NetDemand, Supply,TitleID,BookType) values " + SubQuery + "");
            
            }
            catch { }
            mainDiv.Style.Add("disiplay", "block");
            lblmsg.Style.Add("disiplay", "block");
            lblmsg.Text = "पुस्तक प्रदाय का चालान बन चुका  है ";
            grdDepoTransfer.DataSource = null;
            grdDepoTransfer.DataBind();


            divDepo.Style.Add("display", "none");
            btn2.Visible = false;
        Response.Redirect("Challaninterdepo.aspx?ID=" + ddlOrderNo.SelectedValue + "&challanID=" + lblDepoChalan.Text + "&challanDate=" + lblDepochalanDate.Text + "&LordingCharge=" + txtdepolOading.Text + "&unLordingCharge="+txtDepoUnloading.Text+"&otherCharge="+txtDepoother.Text+"");
        //Response.Redirect("DPT015_Bookreceived.aspx");
        //ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT31_GetOrderFromDistribution(" + Session["UserID"] + ")");
        //ddlOrderNo.DataTextField = "ReqNo";
        //ddlOrderNo.DataValueField = "ReqNo";
        //ddlOrderNo.DataBind();
        //ddlOrderNo.Items.Insert(0, "Select..");

       
        }
        catch { }

    }
    protected void ContinueClick(object sender, EventArgs e)
    {

    }

    protected void SerarchDepoOrdere(object sender, EventArgs e)
    {
        try {
        obCommonFuction = new CommonFuction();
        DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT_GetTransferRequestOfInterDepo(" + Session["UserID"] + ",'"+ddlOrderNo.SelectedValue+"')");
        lblDepoOrderdate.Text = Convert.ToDateTime(Convert.ToString(ds1.Tables[0].Rows[0]["Transferdate"])).ToString("dd/MM/yyyy");
        grdDepoTransfer.DataSource = ds1;
        grdDepoTransfer.DataBind();
        btn2.Visible = true;
        }
        catch { }
    }
    protected void btn2_Click(object sender, EventArgs e)
    {
        divDepo.Style.Add("display", "block");
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        divDepo.Style.Add("display", "block");
    }
    protected void ddlFyYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT31_GetOrderFromDistribution(" + Session["UserID"] + ",'"+ddlFyYear.SelectedItem.Text+"')");
        ddlOrderNo.DataTextField = "ChallanName";
        ddlOrderNo.DataValueField = "ReqNo";
        ddlOrderNo.DataBind();
        ddlOrderNo.Items.Insert(0, "Select..");
    }
}
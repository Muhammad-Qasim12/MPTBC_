using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer.Paper;

public partial class Depo_OtherThankPraday : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    string ClassID;
    string SubQuery;
    string SubQuery1; CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        if (!IsPostBack)
        {
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtChalanNo.Text = randnum.ToString();
            txtChalanNo.Enabled = false;

            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "ID";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
            txtChalanDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtGRNDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            try
            {


                DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
                DdlDistrict.DataValueField = "DistrictTrno_I";
                DdlDistrict.DataTextField = "District_Name_Hindi_V";
                DdlDistrict.DataBind();
                DdlDistrict.Items.Insert(0, "--Select--");
            }
            catch { }
           

        }
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        ddlBlock.DataSource = ds;
        ddlBlock.DataTextField = "BlockNameHindi_V";
        ddlBlock.DataValueField = "BlockTrno_I";
        ddlBlock.DataBind();

    }
    protected void btnSaveMasterData_Click(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2" )
        {
            grBook.DataSource = obCommonFuction.FillDatasetByProc("call USP_OtherThanTextbook(" + Session["UserID"] + "," + ddlBlock.SelectedValue + "," + ddlSessionYear.SelectedValue + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text+ "')");
            grBook.DataBind();
        }
        else
        {
            if (DropDownList1.SelectedValue=="4" )
            {
                grBook.DataSource = obCommonFuction.FillDatasetByProc("call USP_OtherThanTextbook_dist(" + Session["UserID"] + "," + DdlDistrict.SelectedValue + "," + ddlSessionYear.SelectedValue + ",'" + ddlSessionYear.SelectedItem.Text + "','1')");
                grBook.DataBind();
            }
            else
            {
                grBook.DataSource = obCommonFuction.FillDatasetByProc("call USP_OtherThanTextbook(" + Session["UserID"] + "," + DdlDistrict.SelectedValue + "," + ddlSessionYear.SelectedValue + ",'" + ddlSessionYear.SelectedItem.Text + "','" + DropDownList2.SelectedItem.Text + "')");
                grBook.DataBind();
            }
           
        
        }
    }
    protected void calculate(object sender, EventArgs e)
    {
        try
        {
            //txtNofBooks/lblAbook
            //txtNofBooks
            TextBox txtPerbundlebook = (TextBox)sender;
            //txtPerbundlebook
            GridViewRow grdrow = (GridViewRow)txtPerbundlebook.NamingContainer;
            TextBox txtNofBooks = (TextBox)grdrow.FindControl("txtNofBooks");
            TextBox lblnoofbooks = (TextBox)grdrow.FindControl("lblnoofbooks");
            Label lblAbook = (Label)grdrow.FindControl("lblAbook");
            TextBox txtPackbundle = (TextBox)grdrow.FindControl("txtPackbundle");
            TextBox txtloose = (TextBox)grdrow.FindControl("txtloose");
            TextBox txtPerbundlebook1 = (TextBox)grdrow.FindControl("txtPerbundlebook");
            if ((Convert.ToInt32(txtNofBooks.Text) - Convert.ToInt32(lblAbook.Text)) < (Convert.ToInt32(lblnoofbooks.Text)))
            {
                lblnoofbooks.Text = "0";
                txtPackbundle.Text = "0";
                txtloose.Text = "0";
                return;
            }
            else
            {

                var pack = Convert.ToInt32(lblnoofbooks.Text) / Convert.ToInt32(txtPerbundlebook1.Text);
                var loose = Convert.ToInt32(lblnoofbooks.Text) % Convert.ToInt32(txtPerbundlebook1.Text);
                txtPackbundle.Text = pack.ToString();
                txtloose.Text = loose.ToString();
            }

        }
        catch { }



    }
    //Dpt_DistributeOtherThanBooks_M\
    //Dpt_DistributeOtherThanBooks_Details
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SubQuery = ""; SubQuery1 = "";
      DataSet dt= obCommonFuction.FillDatasetByProc("call USP_Dpt_SaveOtherThanPraday('"+ddlSessionYear.SelectedItem.Text+"',"+DdlDistrict.SelectedValue+","+ddlBlock.SelectedValue+",'"+DropDownList1.SelectedItem.Text+"','"+txtChalanNo.Text+"','"+Convert.ToDateTime (txtChalanDate.Text,cult).ToString ("yyyy-MM-dd")+"','"+txtGRNO.Text+"','"+Convert.ToDateTime (txtGRNDate.Text,cult).ToString ("yyyy-MM-dd")+"','"+txtDriverMobileNo.Text+"','"+txtTrucko.Text+"',"+Session["UserID"]+")");
      foreach (DataRow dr in dt.Tables[0].Rows)
      {
          for (int i = 0; i < grBook.Rows.Count; i++)
          {
              if (((CheckBox)grBook.Rows[i].FindControl("CheckBox1")).Checked == true)
              {
                  if (((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text == grBook.Rows[i].Cells[5].Text || Convert.ToInt32(((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text) < Convert.ToInt32(((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text))
                  {

                  }
                  else
                  {
                      if (SubQuery == "")
                      {
                          SubQuery = SubQuery + "(" + Convert.ToString(dr[0]) + ",'" + txtChalanNo.Text + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ")";
                      }
                      else
                      {
                          SubQuery = SubQuery + ",(" + Convert.ToString(dr[0]) + ",'" + txtChalanNo.Text + "'," + ((HiddenField)grBook.Rows[i].FindControl("HiddenField1")).Value + "," + ((TextBox)grBook.Rows[i].FindControl("txtPerbundlebook")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtNofBooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("lblnoofbooks")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtPackbundle")).Text + "," + ((TextBox)grBook.Rows[i].FindControl("txtloose")).Text + ")";
                      }
                  }
              }
          }
      }
      obCommonFuction.FillDatasetByProc(@"insert into Dpt_DistributeOtherThanBooks_Details(MasterID, CHllanNO, TitleID, Perbundlebook, Orderbook, DistributeBook, PaikBundle, Loojbook)
  values " + SubQuery + "");
      if (DropDownList2.SelectedValue == "1")

      {
          try {
          RKSKNew aj = new RKSKNew();
          aj.BookDispatchDetailsByChallan(txtChalanNo.Text);
          }
          catch { }

      }
      Response.Redirect("VIEWOtherThanTextbook.aspx");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    //    if (DropDownList1.SelectedValue == "1" || DropDownList1.SelectedValue == "2")
    //    {
    //        ddlBlock.Visible = true;
    //    }
    //    else
    //    {
    //        ddlBlock.Visible = false;
    //    }
    }
}
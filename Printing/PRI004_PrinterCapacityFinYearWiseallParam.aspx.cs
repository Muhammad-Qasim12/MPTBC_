using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Printing_PRI004_PrinterCapacityFinYearWise : System.Web.UI.Page
{
    PRI_PaperAllotment obPRI_PaperAllotment = null;

    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadACyear();
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.Printer_RedID_I = 0;
            DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            //ddlPrinterName.DataValueField = "NameofPress_V";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "सलेक्ट करे");
        }
    }

    public void LoadACyear()
    {
        try
        {
            
            ddlACYear_I.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlACYear_I.DataValueField = "AcYear";
            ddlACYear_I.DataTextField = "AcYear";
            ddlACYear_I.DataBind();
            ddlACYear_I.SelectedValue = obCommonFuction.GetFinYear();

            ddlACYear_I.Items.Insert(0, new ListItem("All", "0"));
        }
        catch (Exception ex) { }
        finally { }
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        //Prin_tbl_printerMachineCapacity
        try { 
        if (HiddenField1.Value == "")
        {
            obCommonFuction.FillDatasetByProc("call Prin_tbl_printerMachineCapacity(0," + ddlPrinterName.SelectedValue + ",'" + ddlACYear_I.SelectedItem.Text + "','" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "','" + txt8.Text + "','" + txt9.Text + "','" + txt10.Text + "','" + txt11.Text + "','" + txt12.Text + "','" + txt13.Text + "','" + txt14.Text + "','" + txt15.Text + "','" + txt16.Text + "','" + txt17.Text + "','" + txt18.Text + "','" + txt19.Text + "','" + txt20.Text + "','" + txt21.Text +  "') ");
        }
        else
        {
            obCommonFuction.FillDatasetByProc("call Prin_tbl_printerMachineCapacity(" + HiddenField1.Value + "," + ddlPrinterName.SelectedValue + ",'" + ddlACYear_I.SelectedItem.Text + "','" + txt1.Text + "','" + txt2.Text + "','" + txt3.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "','" + txt8.Text + "','" + txt9.Text + "','" + txt10.Text + "','" + txt11.Text + "','" + txt12.Text + "','" + txt13.Text + "','" + txt14.Text + "','" + txt15.Text + "','" + txt16.Text + "','" + txt17.Text + "','" + txt18.Text + "','" + txt19.Text + "','" + txt20.Text + "','" + txt21.Text + "') ");
        }
        HiddenField1.Value = "";
        obCommonFuction.EmptyTextBoxes(this);
        ddlACYear_I.SelectedValue = obCommonFuction.GetFinYear();
            }
        catch (Exception ex) { }
        finally { }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void ddlPrinterName_SelectedIndexChanged(object sender, EventArgs e)
    {
        //
        try {
            double   penper;
            DataSet dspen = obCommonFuction.FillDatasetByProc("call USP_Penaltypercentage('" + ddlACYear_I.SelectedItem.Value + "',"+ ddlPrinterName.SelectedItem.Value + ")");
            Label1.Text = "";
            if (dspen.Tables[0].Rows.Count > 0)
            {
               
                penper = Convert.ToDouble (dspen.Tables[0].Rows[0][0].ToString()) ;
                Label1.Text = Convert.ToString (penper);
            }
            
            DataSet dd=  obCommonFuction.FillDatasetByProc("call getPrin_tbl_printerMachineCapacityData("+ddlPrinterName.SelectedValue+",'"+ddlACYear_I.SelectedItem.Text+"')");
      if (dd.Tables[0].Rows.Count > 0)
      {
          txt1.Text = dd.Tables[0].Rows[0]["two"].ToString();
          txt2.Text = dd.Tables[0].Rows[0]["four"].ToString();
          txt3.Text = dd.Tables[0].Rows[0]["sheet"].ToString();
      txt4.Text = dd.Tables[0].Rows[0]["Capacity4"].ToString();
      txt5.Text = dd.Tables[0].Rows[0]["Capacity5"].ToString();
      txt6.Text = dd.Tables[0].Rows[0]["Capacity6"].ToString();
      txt7.Text = dd.Tables[0].Rows[0]["Capacity7"].ToString();
      txt8.Text = dd.Tables[0].Rows[0]["Capacity8"].ToString();
      txt9.Text = dd.Tables[0].Rows[0]["Capacity9"].ToString();
      txt10.Text = dd.Tables[0].Rows[0]["Capacity10"].ToString();
      txt11.Text = dd.Tables[0].Rows[0]["Capacity11"].ToString();
      txt12.Text = dd.Tables[0].Rows[0]["Capacity12"].ToString();
      txt13.Text = dd.Tables[0].Rows[0]["Capacity13"].ToString();
      txt14.Text = dd.Tables[0].Rows[0]["Capacity14"].ToString();
      txt15.Text = dd.Tables[0].Rows[0]["Capacity15"].ToString();
      txt16.Text = dd.Tables[0].Rows[0]["Capacity16"].ToString();
      txt17.Text = dd.Tables[0].Rows[0]["Capacity17"].ToString();
      txt18.Text = dd.Tables[0].Rows[0]["Capacity18"].ToString();
      txt19.Text = dd.Tables[0].Rows[0]["totalreduce2"].ToString();
      txt20.Text = dd.Tables[0].Rows[0]["totalreduce4"].ToString();
      txt21.Text = dd.Tables[0].Rows[0]["totalreducesheet"].ToString();

      HiddenField1.Value = dd.Tables[0].Rows[0]["IDaaa"].ToString();
      }
      else
      {
          txt1.Text ="0";
          txt2.Text = "0";
          txt3.Text = "0";
          txt4.Text = "0";
          txt5.Text = "0";
          txt6.Text = "0";
          txt7.Text = "0";
          txt8.Text = "0";
          txt9.Text = "0";
          txt13.Text = "0";
          txt14.Text = "0";
          txt15.Text = "0";
          txt16.Text = "0";
          txt17.Text = "0";
          txt18.Text = "0";
      }
      caltwocolorreduse();
      calfourcolorreduse();
      calfourcolorsheetreduse();

/*
     
          string id = "";
          id = Convert.ToString(Convert.ToDouble(txt1.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));

          if ((Convert.ToDouble(txt10.Text) * 2)>0)
          {
              if ((Convert.ToDouble(txt10.Text) * 2) > Convert.ToDouble(id))
              {
                  txt13.Text = Convert.ToString(Convert.ToDouble(txt10.Text) * 2);
              }
              else
              {
                  txt13.Text = id.ToString();
              }
          }
          else
          { txt13.Text = "0";
          }

          id = Convert.ToString(Convert.ToDouble(txt2.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));
          if ((Convert.ToDouble(txt11.Text) * 2) > 0)
          {

              if ((Convert.ToDouble(txt11.Text) * 2) > Convert.ToDouble(id))
              {
                  txt14.Text = Convert.ToString(Convert.ToDouble(txt11.Text) * 2);
              }
              else
              {
                  txt14.Text = id.ToString();
              }
          }
          else
          {
              txt14.Text = "0";
          }

          id = Convert.ToString(Convert.ToDouble(txt3.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));
          if ((Convert.ToDouble(txt12.Text) * 2) > 0)
          {
              if ((Convert.ToDouble(txt12.Text) * 2) > Convert.ToDouble(id))
              {
                  txt15.Text = Convert.ToString(Convert.ToDouble(txt12.Text) * 2);
              }
              else
              {
                  txt15.Text = id.ToString();
              }
          }
          else {
              txt15.Text = "0";
          }*/
        }
        catch { }
    }
    protected void txt10_TextChanged(object sender, EventArgs e)
        {
       /*
        string id = "";
        id = Convert.ToString(Convert.ToDouble(txt1.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));

        if (Convert.ToDouble(txt10.Text) > 0) { 
        if ((Convert.ToDouble(txt10.Text)*2) > Convert.ToDouble(id))
        {
            txt13.Text =Convert.ToString (Convert.ToDouble(txt10.Text) *2 );
        }
        else
        {
            txt13.Text = id.ToString();
        }}
        else
        {  txt13.Text = "0";
        }

        if (txt7.Text != "0")
        {
            txt19.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt13.Text));
        }
        else { 
        txt19.Text =Convert.ToString(Convert.ToDouble(txt13.Text));
        }
       // txt16.Text = Convert.ToString(Convert.ToDouble(txt1.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));
        */
            caltwocolorreduse(); 
    }
    protected void txt11_TextChanged(object sender, EventArgs e)
    {
        /*string id = "";
        id = Convert.ToString(Convert.ToDouble(txt2.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));
        if (Convert.ToDouble(txt11.Text) > 0)
        {
            if ((Convert.ToDouble(txt11.Text) * 2) > Convert.ToDouble(id))
            {
                txt14.Text = Convert.ToString(Convert.ToDouble(txt11.Text) * 2);
            }
            else
            {
                txt14.Text = id.ToString();
            }
        }
        else
        {
            txt14.Text = "0";
        }


        if (txt8.Text != "0")
        {
            txt20.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt14.Text));
        }
        else
        {
            txt20.Text = Convert.ToString(Convert.ToDouble(txt14.Text));
        }*/
        caltwocolorreduse();
        calfourcolorreduse(); 

    }
    protected void txt12_TextChanged(object sender, EventArgs e)
    {
        /*
         string id = "";
        id = Convert.ToString(Convert.ToDouble(txt3.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));
        if (Convert.ToDouble(txt12.Text) > 0)
        {

            if ((Convert.ToDouble(txt12.Text) * 2) > Convert.ToDouble(id))
            {
                txt15.Text = Convert.ToString(Convert.ToDouble(txt12.Text) * 2);
            }
            else
            {
                txt15.Text = id.ToString();
            }
        }
        else
        {
            txt15.Text = "0";
        }

        if (txt9.Text != "0")
        {
            txt21.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt15.Text));
        }
        else
        {
            txt21.Text = Convert.ToString(Convert.ToDouble(txt15.Text));
        }
          */
        calfourcolorsheetreduse(); 

    }
    protected void txt7_TextChanged(object sender, EventArgs e)
    {
        caltwocolorreduse(); 
        // penalty values
        

    }
    protected void txt13_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt19_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txt1_TextChanged(object sender, EventArgs e)
    {
        calfourcolorreduse();
        caltwocolorreduse();
        calfourcolorsheetreduse();
    }
    protected void txt8_TextChanged(object sender, EventArgs e)
    {
        
        // penalty values
        calfourcolorreduse();
        caltwocolorreduse();
        // update 19
       // string id = "";
       // string id = "";

        /*if (txt8.Text == "0" && txt7.Text == "0")
        { id = "0"; }
        else if ( txt8.Text !="0" && txt7.Text == "0")
        {
            id = Convert.ToString((Convert.ToDouble(txt2.Text)) * Convert.ToDouble(20) / Convert.ToDouble(100));
        }
        else if (txt7.Text != "0" && txt8.Text == "0")
        {

            id = Convert.ToString((Convert.ToDouble(txt1.Text) - Convert.ToDouble(txt2.Text)) * Convert.ToDouble(20) / Convert.ToDouble(100));
        }


        else if (Convert.ToDouble(txt7.Text) > Convert.ToDouble(txt8.Text))
        { id = Convert.ToString((Convert.ToDouble(txt1.Text) * Convert.ToDouble(20)) / Convert.ToDouble(100)); }

        
        else
        {
            id = Convert.ToString((Convert.ToDouble(txt2.Text) * Convert.ToDouble(20)) / Convert.ToDouble(100));
        }
        // withdrawal penalty
        if (Convert.ToDouble(txt10.Text) > 0)
        {
            if ((Convert.ToDouble(txt10.Text) * 2) > Convert.ToDouble(id))
            {
                txt13.Text = Convert.ToString(Convert.ToDouble(txt10.Text) * 2);
            }
            else
            {
                txt13.Text = id.ToString();
            }
        }
        else
        {
            txt13.Text = "0";
        }
        

        */

        // PENALTY OF FOUR COLOR NOT AVAILABLE
       // if (txt7.Text != "0")
        //{
          //  txt19.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt13.Text));
        //}

/*
        else
        {
            txt19.Text = Convert.ToString(Convert.ToDouble(txt13.Text));
        }
        */

    }
    protected void txt9_TextChanged(object sender, EventArgs e)
    {
        // penalty values
      /*  string id = "";
        id = Convert.ToString(Convert.ToDouble(txt3.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));

        if (Convert.ToDouble(txt12.Text) > 0)
        {
            if ((Convert.ToDouble(txt12.Text) * 2) > Convert.ToDouble(id))
            {
                txt15.Text = Convert.ToString(Convert.ToDouble(txt12.Text) * 2);
            }
            else
            {
                txt15.Text = id.ToString();
            }
        }
        else
        {
            txt15.Text = "0";
        }

        if (txt9.Text != "0")
        {
            txt21.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt15.Text));
        }
        else
        {
            txt21.Text = Convert.ToString(Convert.ToDouble(txt15.Text));
        }*/
        calfourcolorsheetreduse(); 
    }

    public void caltwocolorreduse()
    {
        string id = "";
        if (txt8.Text == "0" && txt7.Text == "0")
        { id = "0"; }
        else if (txt8.Text != "0" && txt7.Text == "0")
        {
            id = Convert.ToString((Convert.ToDouble(txt2.Text)) * Convert.ToDouble(20) / Convert.ToDouble(100));
        }
        else if (txt7.Text != "0" && txt8.Text == "0")
        {

            id = Convert.ToString((Convert.ToDouble(txt1.Text) - Convert.ToDouble(txt2.Text)) * Convert.ToDouble(20) / Convert.ToDouble(100));
        }


        else if (Convert.ToDouble(txt7.Text) > Convert.ToDouble(txt8.Text))
        { id = Convert.ToString((Convert.ToDouble(txt1.Text) * Convert.ToDouble(20)) / Convert.ToDouble(100)); }


        else
        {
            id = Convert.ToString((Convert.ToDouble(txt2.Text) * Convert.ToDouble(20)) / Convert.ToDouble(100));
        }

        // withdrawal penalty
        if (Convert.ToDouble(txt10.Text) > 0)
        {
            if ((Convert.ToDouble(txt10.Text) * 2) > Convert.ToDouble(id))
            {
                txt13.Text = Convert.ToString(Convert.ToDouble(txt10.Text) * 2);
            }
            else
            {
                txt13.Text = id.ToString();
            }
        }
        else
        {
            txt13.Text = "0";
        }


        txt19.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt13.Text));
        

    }

    public void calfourcolorreduse()
    {
        string id = "";
        id = Convert.ToString(Convert.ToDouble(txt2.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));

        if (Convert.ToDouble(txt11.Text) > 0)
        {
            if ((Convert.ToDouble(txt11.Text) * 2) > Convert.ToDouble(id))
            {
                txt14.Text = Convert.ToString(Convert.ToDouble(txt11.Text) * 2);
            }
            else
            {
                txt14.Text = id.ToString();
            }
        }
        else
        {
            txt14.Text = "0";
        }

        if (txt8.Text != "0")
        {
            txt20.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt14.Text));
        }
        else
        {
            txt20.Text = Convert.ToString(Convert.ToDouble(txt14.Text));
        }

    }


    public void calfourcolorsheetreduse()
    {
        string id = "";
        id = Convert.ToString(Convert.ToDouble(txt3.Text) * Convert.ToDouble(20) / Convert.ToDouble(100));

        if (Convert.ToDouble(txt12.Text) > 0)
        {
            if ((Convert.ToDouble(txt12.Text) * 2) > Convert.ToDouble(id))
            {
                txt15.Text = Convert.ToString(Convert.ToDouble(txt12.Text) * 2);
            }
            else
            {
                txt15.Text = id.ToString();
            }
        }
        else
        {
            txt15.Text = "0";
        }

        if (txt9.Text != "0")
        {
            txt21.Text = Convert.ToString(Convert.ToDouble(id) + Convert.ToDouble(txt15.Text));
        }
        else
        {
            txt21.Text = Convert.ToString(Convert.ToDouble(txt15.Text));
        }

    }
    protected void txt2_TextChanged(object sender, EventArgs e)
    {
        calfourcolorreduse();
        caltwocolorreduse();
        calfourcolorsheetreduse(); 
    }
    protected void txt3_TextChanged(object sender, EventArgs e)
    {
        calfourcolorreduse();
        caltwocolorreduse();
        calfourcolorsheetreduse();
    }
}
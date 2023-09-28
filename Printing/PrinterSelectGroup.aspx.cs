using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Configuration;
public partial class Printing_PrinterSelectGroup : System.Web.UI.Page
{
    PRI_TenderEvaluation obPriEval = null;
    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {

                if (Request.QueryString["TenderId"] != null)
                {
                    
                    // for popup 




                    CommonFuction obCommonFuction = new CommonFuction();
                  //  Button bt = (Button)sender;
                  //  GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
                    Messages.Style.Add("display", "block");
                    fadeDiv.Style.Add("display", "block");
                    CommonFuction comm = new CommonFuction();
                    //HdnPriId

                   // HiddenField1.Value = ((HiddenField)grdrow.FindControl("HdnPriId")).Value;
                    //DataSet dd = comm.FillDatasetByProc("call GetLunListbyCompanynew(" + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + ",'" + bt.CommandArgument + "','" + obCommonFuction.GetFinYear() + "'," + HiddenField1.Value + ")");
                    DataSet dt = comm.FillDatasetByProc("select AcdmicYr_V from pri_tenderDetail where TenderId_I=" + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + " ");

                    DataSet dd = comm.FillDatasetByProc("call GetLunListbyCompanyMulti_L1_ingroup(" + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + ",'" + dt.Tables[0].Rows[0]["AcdmicYr_V"].ToString() + "')");
                    
                    GridView1.DataSource = dd.Tables[0];
                    GridView1.DataBind();

                    Label1.Text = "";

                    // end popup


                  //  ImportTogridbytbl();
                }
                else
                {
                    Response.Redirect("TenderEvaluationDetails.aspx");
                }

            }

            catch { }

            finally { }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        CommonFuction obCommonFuction = new CommonFuction();
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        CommonFuction comm = new CommonFuction();
        //HdnPriId

        HiddenField1.Value = ((HiddenField)grdrow.FindControl("HdnPriId")).Value;
        DataSet dd = comm.FillDatasetByProc("call GetLunListbyCompanynew(" + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + ",'" + bt.CommandArgument + "','" + obCommonFuction.GetFinYear() + "'," + HiddenField1.Value + ")");
        GridView1.DataSource = dd.Tables[2];
        GridView1.DataBind();
        
        Label1.Text = "";
        //call USP_PrinterGroupValidationforLUN ('2016-2017',76,'Four');
    }
    //Button2_Click
    protected void Button2_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        Response.Redirect("VIEW_TenderDetails.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //USP_UpdateLUNpriorityNO` (Companya varchar(150),GroupNOa varchar(50),priorityNoa int)
        CommonFuction obCommonFuction = new CommonFuction();
        for (int j = 0; j < GridView1.Rows.Count; j++)
        {
            obCommonFuction.FillDatasetByProc("call USP_UpdateLUNpriorityNO('" + GridView1.Rows[j].Cells[2].Text + "','" + GridView1.Rows[j].Cells[1].Text + "','" + ((TextBox)GridView1.Rows[j].FindControl("TextBox1")).Text + "') ");
        }
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        Response.Redirect("VIEW_TenderDetails.aspx");
    }
    protected void chkChoose_CheckedChanged(object sender, EventArgs e)
    {

    }
    class TenderEval
    {
        public string GroupId { get; set; }
        public string CompanyName { get; set; }
        public string Rates { get; set; }
        public string Rank { get; set; }
        public string TenderEvalID { get; set; }
        public string IsRegistered { get; set; }
        public string PrinterId { get; set; }
        public string GrpId { get; set; }


    }
    private int ImportTogridbytbl()
    {



        IList<TenderEval> ListTenderEval = new List<TenderEval>();
        TenderEval obTenderEval = null;
        DataSet dr = new DataSet();
        obPriEval = new PRI_TenderEvaluation();

        //obPriEval.Tenderid_i = Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString());
        CommonFuction comm = new CommonFuction();
        //obDbaccess.execute("USP_LUNList", DBAccess.SQLType.IS_PROC);
        //obDbaccess.addParam("mtenderid", Tenderid_i);
       // " + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + "
        dr = comm.FillDatasetByProc("call USP_PrinlunlistSelectPrinter(" + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + ",0)");

        for (int i = 0; i < dr.Tables[0].Rows.Count; i++)
        {


            TenderEval obTenderEvalNew = new TenderEval();

            obTenderEvalNew.CompanyName = Convert.ToString(dr.Tables[0].Rows[i]["Company"]);
          
            obTenderEvalNew.PrinterId = GetPrinterIDByName(Convert.ToString(obTenderEvalNew.CompanyName));

        

          
            ListTenderEval.Add(obTenderEvalNew);





        }
        GrdEval.DataSource = ListTenderEval;
        GrdEval.DataBind();

        return 1;
       
    }
    public string GetPrinterIDByName(string PrinterName)
    {
        DataSet ds = new DataSet();
        string PriID = "0";
        obPriEval = new PRI_TenderEvaluation();
        try
        {
            obPriEval.NameofPress_V = PrinterName;
            ds = obPriEval.GetPriIDAndStatus();

            if (ds.Tables[0].Rows.Count > 0)
            {
                PriID = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);

            }

        }

        catch (Exception ex) { }
        finally { obPriEval = null; }


        return PriID;
    }
}
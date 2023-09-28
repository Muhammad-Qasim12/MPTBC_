using System;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Web.UI;

public partial class Distrubution_DemandEstimation : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();

    CommonFuction objExec = new CommonFuction();
    int TotalNo; string strclasses = ""; string Bookstatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        if (!IsPostBack)
        {

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
            DDlDemandType.Items.Insert(0, "--Select--");

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");

            //DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            //DdlClass.DataValueField = "ClassTrno_I";
            //DdlClass.DataTextField = "ClassDesc_V";
            //DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "--Select--");

            ChkClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            ChkClass.DataValueField = "ClassTrno_I";
            ChkClass.DataTextField = "ClassDesc_V";
            ChkClass.DataBind();




        }
    }

     
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BundelReelDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();

            foreach (ListItem item in ChkClass.Items)
            {
                if (item.Selected)
                {
                    strclasses = strclasses + "," + item.Value;
                }

            }
            if (RadioButtonList1.SelectedValue == "1")
            {
                Bookstatus = "1";
            }
            else if (RadioButtonList1.SelectedValue == "2")
            {
                Bookstatus = "0,2";
            }
            else
            {

                Bookstatus = "0,1,2";
            }
            strclasses = strclasses.Substring(1, strclasses.Length - 1);
            DataSet obDataset = new DataSet();
            //if (DDlDemandType.SelectedValue == "4")
            //{
            //    obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_DemandEstimation_BycheckBoxThirdDemand(" + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + ",'" + strclasses + "','" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt16(DDlDemandType.SelectedValue) + ",'" + Bookstatus + "','" + TextBox2.Text + "',"+RadioButtonList3.SelectedValue +")");
            //}
            //else
            //{
            obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_DemandEstimation_BycheckBoxNew(" + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + ",'" + strclasses + "','" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt16(DDlDemandType.SelectedValue) + ",'" + Bookstatus + "','" + TextBox2.Text + "'," + RadioButtonList3.SelectedValue + "," + RadioButtonList4.SelectedValue + ")");
            //}
           GrdBooksMaster.DataSource = obDataset;
            if (obDataset.Tables[0].Rows.Count > 0)
            {
                btnSave.Visible = true;
            }
            else
                btnSave.Visible = false;

            GrdBooksMaster.DataBind();
            mainDiv.Style.Add("display", "None");
            lblmsg.Style.Add("display", "None");


        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            if (DDlDemandType.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया डिमांड टाइप चुने";
            else if (DdlDepot.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया डिपो चुने";
            else if (DdlMedium.SelectedItem.Text.Contains("Select"))
                lblmsg.Text = "कृपया माध्यम चुने";
            //else if (DdlClass.SelectedItem.Text.Contains("Select"))
            //  lblmsg.Text = "कृपया कक्षा चुने";
            else if (strclasses == "")
                lblmsg.Text = "कृपया कक्षा चुने";
        }
    }

   
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string SubQuery = "", ddlActiona = "";
        string SaveSts = "No", strclasses = "";
        ObjDemandEstimation = new DIS_DemandEstimation();
        if (GrdBooksMaster.Rows.Count > 0)
        {
            foreach (ListItem item in ChkClass.Items)
            {
                if (item.Selected)
                {
                    strclasses = strclasses + "," + item.Value;
                }
            }
            
            objExec.FillDatasetByProc("Call USP_DIS_DemandEstimation_IsFinalUpdate(" + DdlDepot.SelectedItem.Value + "," + DdlMedium.SelectedItem.Value + ",'" + strclasses + "','" + DdlACYear.SelectedItem.Value + "'," + DDlDemandType.SelectedItem.Value + ")");
            foreach (GridViewRow gv in GrdBooksMaster.Rows)
            {
                Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");  Label lblDepoID = (Label)gv.FindControl("lblDepoID");  Label lblAcYearId = (Label)gv.FindControl("lblAcYearId");  Label lblMedium_I = (Label)gv.FindControl("lblMedium_I");  Label lblDemandTypeID = (Label)gv.FindControl("lblDemandTypeID");   TextBox TxtDemandScheme = (TextBox)gv.FindControl("TxtDemandScheme");  TextBox TxtDemandOpnMkt = (TextBox)gv.FindControl("TxtDemandOpnMkt");  TextBox TxtTotDemand = (TextBox)gv.FindControl("TxtTotDemand"); TextBox TxtOpenStock = (TextBox)gv.FindControl("TxtOpenStock"); TextBox TxtYojnaStock = (TextBox)gv.FindControl("TxtYojnaStock");  TextBox txtTotStock = (TextBox)gv.FindControl("txtTotStock");  TextBox txtNetDemandScheme = (TextBox)gv.FindControl("txtNetDemandScheme");  TextBox txtNetDemandOpen = (TextBox)gv.FindControl("txtNetDemandOpen");
                DropDownList ddlAction = (DropDownList)gv.FindControl("ddlAction");
                if (DDlDemandType.SelectedItem.Value == "4" || DDlDemandType.SelectedItem.Value == "5")
                {
                    ddlActiona = ddlAction.SelectedItem.Value.ToString();
                }
                else
                {
                    ddlActiona = "2";
                }
                if (SubQuery == "")
                {
                    SubQuery = SubQuery + "(" + int.Parse(lblTitleID_I.Text) + "," + int.Parse(lblMedium_I.Text) + "," + int.Parse(lblDepoID.Text) + "," + int.Parse(TxtDemandScheme.Text) + "," + int.Parse(TxtDemandOpnMkt.Text) + "," + int.Parse(TxtYojnaStock.Text) + "," + int.Parse(TxtOpenStock.Text) + "," + int.Parse(txtNetDemandScheme.Text) + "," + int.Parse(txtNetDemandOpen.Text) + "," + Convert.ToInt32(Session["UserID"]) + "," + int.Parse(lblDemandTypeID.Text) + "," + int.Parse(ddlActiona) + ")";
                }
                else
                {
                    SubQuery = SubQuery + ",(" + int.Parse(lblTitleID_I.Text) + "," + int.Parse(lblMedium_I.Text) + "," + int.Parse(lblDepoID.Text) + "," + int.Parse(TxtDemandScheme.Text) + "," + int.Parse(TxtDemandOpnMkt.Text) + "," + int.Parse(TxtYojnaStock.Text) + "," + int.Parse(TxtOpenStock.Text) + "," + int.Parse(txtNetDemandScheme.Text) + "," + int.Parse(txtNetDemandOpen.Text) + "," + Convert.ToInt32(Session["UserID"]) + "," + int.Parse(lblDemandTypeID.Text) + "," + int.Parse(ddlActiona) + ")";
                }
                
                //ObjDemandEstimation.AcYear = lblAcYearId.Text.ToString(); 
                //ObjDemandEstimation.DepotID = int.Parse(lblDepoID.Text);
                //ObjDemandEstimation.TitleId = int.Parse(lblTitleID_I.Text); 
                //ObjDemandEstimation.OpnMktDemand = int.Parse(TxtDemandOpnMkt.Text); 
                //ObjDemandEstimation.SchemeDemand = int.Parse(TxtDemandScheme.Text);
                //ObjDemandEstimation.StockOpenMkt = int.Parse(TxtOpenStock.Text); 
                //ObjDemandEstimation.NetOpenMkt = int.Parse(txtNetDemandOpen.Text); 
                //ObjDemandEstimation.NetSchemeDemand = int.Parse(txtNetDemandScheme.Text); 
                //ObjDemandEstimation.StockYojna = int.Parse(TxtYojnaStock.Text); 
                //ObjDemandEstimation.MediumId = int.Parse(lblMedium_I.Text); 
                //ObjDemandEstimation.UserID = Convert.ToInt32(Session["UserID"]); 
                //ObjDemandEstimation.DemandType = int.Parse(lblDemandTypeID.Text);
               
                // int i = ObjDemandEstimation.InsertUpdate();
                //if (i > 0)
                //{
                   SaveSts = "Yes";
                //}
            }
        }
        if (SaveSts == "Yes")
        {
            string strSql = SubQuery;  //(1,1,7,8,1,0,0,8,1,25,1,2),(2,1,7,20,1,0,0,20,1,25,1,2),(3,1,7,20,4,0,0,20,4,25,1,2)

            objExec.FillDatasetByProc("Call USP_DIS_DemandToPrintingWithLoop('" + SubQuery + "','" + DdlACYear.SelectedItem.Text + "')");
            mainDiv.Style.Add("display", "block");
            lblmsg.Style.Add("display", "block");
            mainDiv.Visible = true;
            lblmsg.Visible = true;
            lblmsg.Text = "डाटा प्रिंटिंग शाखा के उपयोग के लिए सुरक्षित कर लिया गया है | ";

        }
    }
    protected void GrdBooksMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //`GetDemandData` (DepoIDa int, MediumIDa int, DemandTypea int,TitleIDa int, Typea int,  FyYeara varchar(50))
            DataSet ds = objExec.FillDatasetByProc("call GetDemandData("+DdlDepot.SelectedValue+","+DdlMedium.SelectedValue+","+DDlDemandType.SelectedValue+","+((Label) e.Row.FindControl("lblTitleID_I")).Text+",0,'"+DdlACYear.SelectedItem.Text+"')");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (((HiddenField)e.Row.FindControl("hdSamany")).Value == "0")
                {
              
              }
              else {
                  e.Row.Cells[14].ForeColor = System.Drawing.Color.Navy;
                e.Row.Cells[14].BackColor = System.Drawing.Color.LightGreen;
               
               
                    }
                if (((HiddenField)e.Row.FindControl("hdYojna")).Value == "0")
              {
              
              }
              else {


                  e.Row.Cells[13].BackColor = System.Drawing.Color.LightGreen;
              }
            }
            else
            {
                if (((HiddenField)e.Row.FindControl("hdSamany")).Value == "0")
                {

                }
                else
                {
                    e.Row.Cells[14].BackColor = System.Drawing.Color.LightPink;
                    
                   

                }
                if (((HiddenField)e.Row.FindControl("hdYojna")).Value == "0")
                {

                }
                else
                {

                    e.Row.Cells[13].BackColor = System.Drawing.Color.LightPink;
                   
                   
                }
            
            }
            
            DropDownList ddlAction = (DropDownList)e.Row.FindControl("ddlAction");
            if (DDlDemandType.SelectedItem.Value == "4" || DDlDemandType.SelectedItem.Value == "5")
            {
                //ddlAction.Visible = true;
            }
            else
            {
                ddlAction.Visible = false;
            }
        }
    }

    protected void LinkButtonOpen(object sender, EventArgs e)
    {
        LinkButton TextBox = (LinkButton)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);

        Label lblTitleID_I = (Label)grd.FindControl("lblTitleID_I");
        Label lblTitleName = (Label)grd.FindControl("lblTitleName");
        
        Label lblDepoID = (Label)grd.FindControl("lblDepoID");
        Label lblDemandTypeID = (Label)grd.FindControl("lblDemandTypeID");
        Label lblMedium_I = (Label)grd.FindControl("lblMedium_I");
        HiddenField hdYojna = (HiddenField)grd.FindControl("hdYojna");
        lblDepoName.Text = DdlDepot.SelectedItem.Text;
        lblType.Text = "योजना";
        lblTitle.Text = lblTitleName.Text;
        lblTotaBook.Text = hdYojna.Value;
        HiddenField1.Value = lblTitleID_I.Text;
        HiddenField2.Value = "1";
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");
        Label1.Text = "";
        Label2.Text = "";
     GridView1.DataSource= objExec.FillDatasetByProc("call GetDepowiseDemand(" + lblTitleID_I.Text+ ",'"+DdlACYear.SelectedItem.Text+"',"+DDlDemandType.SelectedValue+","+DdlDepot.SelectedValue+",1)");
     GridView1.DataBind();
     DataSet dd = objExec.FillDatasetByProc("call Dis_DistributionaExtraDemand(1," + DdlDepot.SelectedValue + "," + DdlMedium.SelectedValue + "," + DDlDemandType.SelectedValue + "," + HiddenField1.Value + ",0,0,0,0,'" + DdlACYear.SelectedItem.Text + "')");
     if (dd.Tables[0].Rows.Count > 0)
     {
         Label1.Text = dd.Tables[0].Rows[0]["Distribute"].ToString();
         Label2.Text = dd.Tables[0].Rows[0]["Remain"].ToString();
         if (Label1.Text != "")
         {
             Label2.Text = Convert.ToString(Convert.ToInt32(lblTotaBook.Text) - Convert.ToInt32(Label1.Text));
         }
     }
    }
    protected void LinkButtonOpen2(object sender, EventArgs e)
    {
        LinkButton TextBox = (LinkButton)sender;

        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);

        Label lblTitleID_I = (Label)grd.FindControl("lblTitleID_I");
        Label lblTitleName = (Label)grd.FindControl("lblTitleName");

        Label lblDepoID = (Label)grd.FindControl("lblDepoID");
        Label lblDemandTypeID = (Label)grd.FindControl("lblDemandTypeID");
        Label lblMedium_I = (Label)grd.FindControl("lblMedium_I");
        HiddenField hdSamany = (HiddenField)grd.FindControl("hdSamany");
        lblDepoName.Text = DdlDepot.SelectedItem.Text;
        HiddenField1.Value = lblTitleID_I.Text;
        lblType.Text = "सामान्य";
        lblTitle.Text = lblTitleName.Text;
        lblTotaBook.Text = hdSamany.Value;
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");
        HiddenField2.Value = "2";
        Label1.Text = "";
        Label2.Text = "";
        GridView1.DataSource = objExec.FillDatasetByProc("call GetDepowiseDemand(" + lblTitleID_I.Text + ",'" + DdlACYear.SelectedItem.Text + "'," + DDlDemandType.SelectedValue + "," + DdlDepot.SelectedValue + ",2)");
        GridView1.DataBind();
        DataSet dd = objExec.FillDatasetByProc("call Dis_DistributionaExtraDemand(1," + DdlDepot.SelectedValue + "," + DdlMedium.SelectedValue + "," + DDlDemandType.SelectedValue + "," + HiddenField1.Value + ",0,0,0,0,'" + DdlACYear.SelectedItem.Text + "')");
        if (dd.Tables[0].Rows.Count > 0)
        { 
        Label1.Text = dd.Tables[0].Rows[0]["Distribute"].ToString ();
        Label2.Text = dd.Tables[0].Rows[0]["Remain"].ToString();
        if (Label1.Text != "")
        {
            Label2.Text = Convert.ToString(Convert.ToInt32(lblTotaBook.Text) - Convert.ToInt32(Label1.Text));
        }
 
        }

    }
    protected void Button1Close(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");
    }
    protected void Button2Save(object sender, EventArgs e)
    {
        CommonFuction obcomm = new CommonFuction();
     DataSet dd=obcomm.FillDatasetByProc("call Dis_DistributionaExtraDemand(0,"+DdlDepot.SelectedValue+","+DdlMedium.SelectedValue+","+DDlDemandType.SelectedValue+","+HiddenField1.Value+","+lblTotaBook.Text+","+HiddenField2.Value+","+Label1.Text+","+Label2.Text+",'"+DdlACYear.SelectedItem.Text+"')");
     for (int i = 0; i < GridView1.Rows.Count; i++)
     {
         TextBox TextBox1 = ((TextBox)GridView1.Rows[i].FindControl("TextBox1"));
         if (TextBox1.Text!="0")
         {
         HiddenField hdDepoID = ((HiddenField)GridView1.Rows[i].FindControl("hdDepoID"));
         HiddenField hdTitleId = ((HiddenField)GridView1.Rows[i].FindControl("hdTitleId"));
         obcomm.FillDatasetByProc("call Dis_DistributionaExtraDemandChield(0," + dd.Tables[0].Rows[0]["aa"] + "," + hdDepoID.Value + "," + TextBox1.Text + "," + DdlMedium.SelectedValue + "," + DDlDemandType.SelectedValue + ",'" + DdlACYear.SelectedItem.Text + "'," + hdTitleId.Value + ","+HiddenField2.Value+")");
         }
         fadeDiv.Style.Add("display", "none");
         Messages.Style.Add("display", "none");
         mainDiv.Style.Add("display", "block");
         lblmsg.Style.Add("display", "block");
         mainDiv.Visible = true;
         lblmsg.Visible = true;
         lblmsg.Text = "डाटा सुरक्षित कर लिया गया है | ";
    }


    
    }
    protected void txtbox1(object sender, EventArgs e)
    {

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            TextBox TextBox1 = ((TextBox)GridView1.Rows[i].FindControl("TextBox1"));
            TotalNo = TotalNo + Convert.ToInt32(TextBox1.Text);
        }
        Label1.Text = TotalNo.ToString();
        Label2.Text = Convert.ToString(Convert.ToInt32(lblTotaBook.Text)- Convert.ToInt32(Label1.Text));
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (ListItem item in ChkClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + "," + item.Value;
            }
        }
        if (RadioButtonList1.SelectedValue == "1")
        {
            Bookstatus = "1";
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            Bookstatus = "0,2";
        }
        else
        {

            Bookstatus = "0,1,2";
        }
        Response.Redirect("DemandReportNew.aspx?MeidumName=" + DdlMedium.SelectedItem.Text + "&DemandName=" + DDlDemandType.SelectedItem.Text + "&DemandType=" + DDlDemandType.SelectedValue + "&Year=" + DdlACYear.SelectedValue + "&Class=" + strclasses + "&DepoName=" + DdlDepot.SelectedItem.Text + "&depoID=" + DdlDepot.SelectedValue + "&meidumID=" + DdlMedium.SelectedValue + "&Bookstatus=" + Bookstatus + "&PerCentage=" + TextBox2.Text + "&WithStock=" + RadioButtonList3.SelectedValue + "&Samayan="+RadioButtonList4.SelectedValue+" ");
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    { 
        CommonFuction obcomm = new CommonFuction();
    obcomm.FillDatasetByProc(" call DeleteDemand("+GridView1.DataKeys[e.RowIndex].Value+")");
    fadeDiv.Style.Add("display", "none");
    Messages.Style.Add("display", "none");
      // 
    }

    protected void DDlDemandType_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}

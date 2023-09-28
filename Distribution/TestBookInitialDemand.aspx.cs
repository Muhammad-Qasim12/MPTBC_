using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using MPTBCBussinessLayer;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Globalization;
public partial class Distribution_TestBookInitialDemand : System.Web.UI.Page
{
    //DBClass objDbClass = new DBClass();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction objExec = new CommonFuction();
    List<Columns> ColumnList = new List<Columns>();
    static int count = 0; string TitleIDa, BlockID;
    static DataTable dtnew = new DataTable();
    decimal TotAmt = 0;
    static string NoofBooks = "";
    static int rowid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            CommonFuction obCommonFuction = new CommonFuction();
            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("USP_ADM004_DistrictMasterSelect 0,0 ");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");

            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("USP_DIS001_DemandTypeMasterLoad 0 ");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();


            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("USP_ADM015_AcadmicYearLoad 0 ");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            LblFyYear.Text = DdlACYear.SelectedItem.Text;


            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("USP_DD_SelectMainBookDepot1");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");


            string Class = RadBtnListAgency.SelectedValue;
            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("USP_ADM015_SchemeLoadClassWise '" + Class + "'");
            DdlScheme.DataValueField = "SchemeId";
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, "--Select--");
            if (Convert.ToString(Session["UserID"]) == "50")
            {
                RadBtnListAgency.SelectedValue = "1-8";
                RadBtnListAgency.Enabled = false;
                RadBtnListAgency_SelectedIndexChanged( sender,  e);
            }
           
            else if (Convert.ToString(Session["UserID"]) == "58")
            {
                RadBtnListAgency.SelectedValue = "9-12";
                RadBtnListAgency.Enabled = false;
                RadBtnListAgency_SelectedIndexChanged(sender, e);
            }
            else
            {
                RadBtnListAgency.Enabled = true;
            }

        }

    }
    public class Columns
    {
        string _ColumnName, _ColumnValue;
        public Columns()
        {

        }

        public Columns(string name, string value)
        {
            _ColumnName = name;
            _ColumnValue = value;
        }

        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }

        public string ColumnValue
        {
            get { return _ColumnValue; }
            set { _ColumnValue = value; }
        }
    }

    public void FillGrid(string strclasses)
    {
        try
        {
            string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
            DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_GEN_GetTilteFromClass('" + strclasses + "'," + DdlScheme.SelectedValue + ",'"+DdlACYear.SelectedItem.Text+"')");
            ViewState["obDataset"] = obDataset;
            rowid = 0;

            gridDetails.DataSource = ds;
            gridDetails.RepeatColumns = ds.Tables[0].Rows.Count;
            gridDetails.DataBind();
            hideFiresrTitle();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Button1.Visible = true;
            }
           // mainDiv.Style.Add("display", "none");
           // lblmsg.Style.Add("display", "none");
            //fillempFields();
        }
        catch (Exception e)
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            if (e.Message.Contains("Select"))
            {
                lblmsg.Text = "Please select all dropdown properly";
            };
        }

    }

    private List<Columns> fillempFields()
    {
        DataTable dt = new DataTable();

        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        ColumnList.Add(new Columns("Book Name", "BookName"));
        dt.Columns.Add("BookID", typeof(string));
        dt.Columns.Add("BookName", typeof(string));
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            try
            {
                dt.Columns.Add(Convert.ToString(dr["BlockTrno_I"]), typeof(string));

                ColumnList.Add(new Columns(Convert.ToString(dr["Blockname_v"]), Convert.ToString(dr["BlockNameHindi_V"])));

            }
            catch { }

        }
        foreach (var item in ColumnList)
        {
            count = 0;
            TemplateField tfs = new TemplateField();
            tfs.HeaderText = item.ColumnValue;
            if (item.ColumnValue == "BookName")
            {
                tfs.ItemTemplate = new CreateTemplate(ListItemType.Item, "lable");

            }
            else
            {

                tfs.ItemTemplate = new CreateTemplate(ListItemType.Item, "Text");
            }
            // gridDetails.Columns.Add(tfs);
        }


        DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_GEN_GetTilteFromClass(" + DdlClass.SelectedValue + "," + DdlScheme.SelectedValue + ")");

        foreach (DataRow dr in obDataset.Tables[0].Rows)
        {
            DataRow dr1 = dt.NewRow();
            dr1[0] = Convert.ToString(dr["TitleID_I"]);
            dr1[1] = Convert.ToString(dr["TitleHindi_V"]);
            dt.Rows.Add(dr1);

        }

        gridDetails.DataSource = dt;
        Session["MyData"] = dt;
        ViewState["MyData"] = dt;
        setBlock();
        gridDetails.DataBind();

        return ColumnList;
    }
    public class CreateTemplate : ITemplate
    {
        ListItemType listItem;
        string control;
        public CreateTemplate()
        {

        }

        public CreateTemplate(ListItemType item)
        {
            listItem = item;
        }

        public CreateTemplate(ListItemType item, string controlType)
        {
            listItem = item;
            control = controlType;
        }

        public void InstantiateIn(System.Web.UI.Control Container)
        {
            if (listItem == ListItemType.Item && control == "Image")
            {
                Image empImage = new Image();
                empImage.Width = 64;
                empImage.Height = 64;
                empImage.Style.Add("vertical-align", "text-top");
                empImage.DataBinding += new EventHandler(empImage_DataBinding);
                Container.Controls.Add(empImage);
            }
            if (listItem == ListItemType.Item && control == "Text")
            {
                count++;
                TextBox txt = new TextBox();
                txt.Width = 70;
                txt.Attributes.Add("onkeypress", "javascript:tbx_fnInteger(event, this);");
                txt.CssClass = "reqirerd";
                string[] st = NoofBooks.Split(',');
                try
                {
                    txt.Text = st[rowid + 1];
                    rowid++;
                }
                catch { }


                // txt.ID = "txt1" + count.ToString();

                //for (int introw = 0; introw <= dt.Rows.Count - 1; introw++)
                //{
                //  //  txt.ID = "blockID_" + dt.Columns[0].ColumnName;

                //}
                HiddenField hdnDistrictID = new HiddenField();
                hdnDistrictID.ID = "hdnDistrict" + count.ToString();
                Container.Controls.Add(hdnDistrictID);
                Container.Controls.Add(txt);

            }
            if (listItem == ListItemType.Item && control == "lable")
            {
                Label txt = new Label();
                txt.ID = "lbl1";
                //txt.Text = DataBinder.Eval(Container, "BookName");
                Container.Controls.Add(txt);


            }

        }

        public void empImage_DataBinding(object sender, EventArgs e)
        {
            Image imageData = (Image)sender;
            GridViewRow container = (GridViewRow)imageData.NamingContainer;
            object dataValue = DataBinder.GetPropertyValue(container.DataItem, "Photo");

            if (dataValue != DBNull.Value)
            {
                imageData.ImageUrl = dataValue.ToString();
            }
        }

        //public void empLabel_DataBinding(object sender, EventArgs e)
        //{
        //    Label lblData = (Label)sender;
        //    GridViewRow container = (GridViewRow)lblData.NamingContainer;
        //    object dataValue = DataBinder.GetPropertyValue(container.DataItem, "Qualification");

        //    if (dataValue != DBNull.Value)
        //    {
        //        lblData.Text = dataValue.ToString();
        //    }
        //}
    }


    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        lblSaveMsg.Text = "";
        if (DdlScheme.SelectedIndex > 0 && DdlClass.SelectedIndex > 0)
        {
            //FillGrid();
        }

    }
    
    public void setBlock()
    {
        string ids = "'";
        string titalids = "'";
        try
        {
            if (HttpContext.Current.Session["MyData"] != null)
            {
                try
                {
                    DataTable dt = (DataTable)Session[""];
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (titalids == "'")
                        {

                            titalids = titalids + Convert.ToString(dr[0]);
                        }

                        else { titalids = titalids + "," + Convert.ToString(dr[0]); }
                    }


                    for (int introw = 0; introw <= 1; introw++)
                    {
                        for (int intcol = 2; intcol <= dt.Columns.Count - 1; intcol++)
                        {
                            if (ids == "'")
                            {
                                ids = ids + Convert.ToInt32(dt.Columns[intcol].ColumnName.ToString());
                            }
                            else { ids = ids + "," + Convert.ToInt32(dt.Columns[intcol].ColumnName.ToString()); }
                        }
                    }
                }
                catch { }
            }
        }
        catch { }
        ids = ids + "'";
        titalids = titalids + "'";
        CommonFuction obCommonF = new CommonFuction();
        string getStock = "call USP_DIS018_SelectTextBookDemand(";
        getStock = getStock + "'" + DdlACYear.SelectedValue + "'";

        getStock = getStock + ",";
        getStock = getStock + DDlDemandType.SelectedValue;
        getStock = getStock + ",";
        getStock = getStock + ids;
        getStock = getStock + ",";
        getStock = getStock + DdlScheme.SelectedValue;
        getStock = getStock + ",";
        getStock = getStock + titalids;
        getStock = getStock + ")";
        DataSet ds = obCommonF.FillDatasetByProc(getStock);

        NoofBooks = "";
        rowid = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            if (NoofBooks == "'")
            {
                NoofBooks = NoofBooks + Convert.ToString(dr["NoOfbooks"]);
            }
            else
            {

                NoofBooks = NoofBooks + "," + Convert.ToString(dr["NoOfbooks"]);
            }
        }

    }
   
    protected void gridDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                HiddenField tilleid = (HiddenField)e.Row.FindControl("tilleid");
                TextBox txtDemand = (TextBox)e.Row.FindControl("txtDemand");
                // Label lblExist = (Label)e.Row.FindControl("lblExist");
                DataSet ds = (DataSet)ViewState["ds"];
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (tilleid.Value == Convert.ToString(dr["TitleId"]))
                    {
                        txtDemand.Text = dr["NoOfBooks"].ToString();
                        //  lblExist.Text = dr["EntryCount"].ToString();
                        //try
                        //{
                        //    TotAmt = TotAmt + decimal.Parse(dr["NoOfBooks"].ToString());
                        //}
                        //catch { }
                    }
                    else
                    {

                        //lblExist.Text = "0";
                    }
                }
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            //Label lblFooterSum = (Label)e.Row.FindControl("txtFooterSum");
            //lblFooterSum.Text = TotAmt.ToString();
        }
    }
    protected void txtDemand_TextChanged(object sender, EventArgs e)
    {
        TextBox txtDemand = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txtDemand.NamingContainer;
        //Label txtFooterSum = (Label)gv.FindControl("txtFooterSum");
        // CalcSum();
    }
    //public void CalcSum()
    //{
    //    foreach (DataListItem dl in gridDetails.Items)
    //    {
    //        GridView gvDtl = (GridView)dl.FindControl("grdTitlegrid");
    //        foreach (GridViewRow gdv in gvDtl.Rows)
    //        {
    //            TextBox txtDd = (TextBox)gdv.FindControl("txtDemand");
    //            TextBox txtDd = (TextBox)gdv.FindControl("txtDemand");
    //            foreach (GridViewRow gdv in gvDtl.Rows)
    //            {
    //                try
    //                {
    //                    TotAmt = TotAmt + decimal.Parse(txtDd.Text);
    //                }
    //                catch { }
    //            }
    //        }
    //    }
    //}
    public void hideFiresrTitle()
    {
        int c = 0;
        foreach (DataListItem obGridViewRow in gridDetails.Items)
        {
            GridView grdTitlegrid = (GridView)obGridViewRow.FindControl("grdTitlegrid");
            if (c > 0)
            {
                grdTitlegrid.Columns[0].Visible = false;
            }
            c++;
        }
    }

    TextbookDemand obTextbookDemand = null;
    protected void Button1_Click(object sender, EventArgs e)
    {
        string SubQuery = "", Sts = "";
        TitleIDa = "";
        BlockID = "";
        try
        {
            //objExec.FillDatasetByProc();
            ArrayList objArray = new ArrayList();

            // objDbClass.ConnectionOpen();
            //string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString; 
            //using (MySqlConnection connection = new MySqlConnection(connectionString))
            //{
            //    connection.Open();
            int Cnt = 0, TotRows = 0, RowCunt = 0,RowComp=230;
            foreach (DataListItem obGridViewRow in gridDetails.Items)
            {
                HiddenField hdnkey = (HiddenField)obGridViewRow.FindControl("hdnkey");
                GridView grdTitlegrid = (GridView)obGridViewRow.FindControl("grdTitlegrid");
                foreach (GridViewRow grd in grdTitlegrid.Rows)
                {
                    TotRows = grdTitlegrid.Rows.Count * gridDetails.Items.Count;
                    RowCunt = TotRows;
                    HiddenField tilleid = (HiddenField)grd.FindControl("tilleid");
                    TextBox txtDemand = (TextBox)grd.FindControl("txtDemand");

                 
                    //if (RowComp >= RowCunt)
                    //{
                    //    RowCunt = RowCunt;
                    //}
                    //else
                    //{
                    //    RowCunt = (RowCunt / RowComp);
                    //}
                    //if (Cnt < TotRows)
                    //{
                        if (SubQuery == "")
                        {
                            //DemandId  ,DemandTypeId ,                                      TitleId ,                             SchemeID ,                                                       NoOfBooks,    UserId ,                DepoId ,                              DistrictId ,IsOpenMktDemand    ,blockId
                          //  SubQuery = SubQuery + "(0," + Convert.ToInt32(DDlDemandType.SelectedValue) + "," + Convert.ToInt32(tilleid.Value) + "," + Convert.ToInt16(DdlScheme.SelectedValue) + "," + Convert.ToInt32(txtDemand.Text) + ",0," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlDistrict.SelectedValue) + ",0," + Convert.ToInt32(hdnkey.Value) + ")";

                            TitleIDa = tilleid.Value;
                            BlockID = hdnkey.Value;
                            SubQuery = SubQuery + "(" + Convert.ToInt32(DDlDemandType.SelectedValue) + ",'" + DdlACYear.SelectedItem.Text + "'," + Convert.ToInt32(tilleid.Value) + "," + Convert.ToInt16(DdlScheme.SelectedValue) + "," + Convert.ToInt32(txtDemand.Text) + ",0,'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlDistrict.SelectedValue) + "," + Convert.ToInt32(hdnkey.Value) + ",0,0,0,'" + TxtLetterNO.Text + "','" + Convert.ToDateTime(TxtLetDate.Text, cult).ToString("yyyy-MM-dd") + "')";
                        }
                        else
                        {
                            TitleIDa = TitleIDa + "," + tilleid.Value;
                            BlockID =BlockID+","+ hdnkey.Value;
                         
                        // SubQuery = SubQuery + ",(0," + Convert.ToInt32(DDlDemandType.SelectedValue) + "," + Convert.ToInt32(tilleid.Value) + "," + Convert.ToInt16(DdlScheme.SelectedValue) + "," + Convert.ToInt32(txtDemand.Text) + ",0," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlDistrict.SelectedValue) + ",0," + Convert.ToInt32(hdnkey.Value) + ")";
                          
                        SubQuery = SubQuery + ",(" + Convert.ToInt32(DDlDemandType.SelectedValue) + ",'" + DdlACYear.SelectedItem.Text + "'," + Convert.ToInt32(tilleid.Value) + "," + Convert.ToInt16(DdlScheme.SelectedValue) + "," + Convert.ToInt32(txtDemand.Text) + ",0,'" + System.DateTime.Now.ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlDistrict.SelectedValue) + "," + Convert.ToInt32(hdnkey.Value) + ",0,0,0,'" + TxtLetterNO.Text + "','" + Convert.ToDateTime(TxtLetDate.Text, cult).ToString("yyyy-MM-dd") + "')";
                        
                        }

                        Sts = "Yes";
                        Cnt++;
                   // }
                    //if (RowComp >= TotRows)
                    //{
                    //    if (1 == (Cnt / RowCunt) && RowCunt >= objArray.Count)
                    //    {
                    //        objArray.Add(SubQuery);
                    //        SubQuery = "";
                    //        Cnt = 0;
                    //    }
                    //}
                    //else
                    //{
                    //    if (1 == (Cnt / RowComp) && RowCunt >= objArray.Count)
                    //    {
                    //        objArray.Add(SubQuery);
                    //        SubQuery = "";
                    //        Cnt = 0;
                    //    }
                    //}                    
                }
                //if (RowCunt == objArray.Count)
                //{
                //    objArray.Add(SubQuery);
                //    SubQuery = "";
                //    Cnt = 0;
                //}
            }
            //}
            //       objDbClass.ConnectionClose();
            if (Sts == "Yes")
            {
                Sts = "";

              objExec.FillDatasetByProc(@"delete from dis_textbookdemand_t
		Where DemandTypeId=" + DDlDemandType.SelectedValue + " And AcYearId='" + DdlACYear.SelectedItem.Text + "' AND blockId in (" + BlockID + ") AND SchemeID=" + DdlScheme.SelectedValue + " AND TitleId in (" + TitleIDa + ")");

                //foreach (string str in objArray)
                //{

                string sqlq = @"INSERT INTO dis_textbookdemand_t
	(
	`DemandTypeId`,	`AcYearId`,	`TitleId`,	`SchemeID`,	`NoOfBooks`,	`UserId`,	`EntryDate`,	`DepoId`,
	`DistrictId`,	`blockId`,	`IsOpenMktDemand`,	`IsFinal`,	`OrderNO` ,	`LetterNo`,	`LetterDate`)value" + SubQuery + "";
                  
                objExec.FillDatasetByProc(@"INSERT INTO dis_textbookdemand_t
	(
	`DemandTypeId`,	`AcYearId`,	`TitleId`,	`SchemeID`,	`NoOfBooks`,	`UserId`,	`EntryDate`,	`DepoId`,
	`DistrictId`,	`blockId`,	`IsOpenMktDemand`,	`IsFinal`,	`OrderNO` ,	`LetterNo`,	`LetterDate`)value" + SubQuery + "");
                   // objExec.FillDatasetByProc("Call USP_DIS018_SaveTextBookDemandWithLoop('" + str + "','" + DdlACYear.SelectedItem.Text + "','" + TxtLetterNO.Text + "','" + TxtLetDate.Text.ToString().Replace("-", "/") + "')");

                  
                    Sts = "Yes";
                    lblSaveMsg.Text = "Please Wait...";
               // }
            }
            if (Sts == "Yes")
            {
                lblSaveMsg.Text = "Record Save successfully";
                //gridDetails.DataSource = null;
                //gridDetails.DataBind();
                //TxtLetDate.Text = "";
                //TxtLetterNO.Text = "";
                //DdlScheme.SelectedIndex = 0;
                //DdlDepot.SelectedIndex = 0;
               
            }
        }
        catch (Exception ex)
        {
            //objDbClass.ConnectionClose();
            mainDiv.CssClass = "response-msg error ui-corner-all";
            mainDiv.Visible = true;
            lblmsg.Visible = true;
            if (ex.Message.Contains("Date"))
            {
                lblmsg.Text = "Please enter valid Date";
            }
            else
            {
                lblmsg.Text = "Error in saving please check all inputs";
            }
        }
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            lblSaveMsg.Text = "";
            CommonFuction obCommonFuction = new CommonFuction();

            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + DdlDepot.SelectedValue + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");
        }
        catch { }

    }
    protected void RadBtnListAgency_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();
            string Class = RadBtnListAgency.SelectedValue;
            //    DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectClass('" + Class + "')");
            //    DdlClass.DataValueField = "ClassTrno_I";
            //    DdlClass.DataTextField = "Classdet_V";
            //    DdlClass.DataBind();
            //    DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //    DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            gridDetails.DataBind();
            mainDiv.Style.Add("display", "none");
            lblmsg.Style.Add("display", "none");


            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + Class + "')");
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, "--Select--");
        }
        catch { }

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LblFyYear.Text = DdlACYear.SelectedItem.Text;
    }
    protected void gridDetails_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            try
            {
               // TxtLetterNO.Text = TxtLetDate.Text = string.Empty;
                CommonFuction obCommonFuction = new CommonFuction();
                hdnblockid.Value = ((HiddenField)e.Item.FindControl("hdnkey")).Value;
                GridView grdTitlegrid = (GridView)e.Item.FindControl("grdTitlegrid");

                DataSet obDataset = (DataSet)ViewState["obDataset"];
                //  string titalids = titalids + "'";
                // string ids = ids + "'";
                CommonFuction obCommonF = new CommonFuction();
                string getStock = "call USP_DIS018_SelectTextBookDemand(";
                getStock = getStock + "'" + DdlACYear.SelectedValue + "'";
                getStock = getStock + ",";
                getStock = getStock + DDlDemandType.SelectedValue;
                getStock = getStock + ",";
                getStock = getStock + hdnblockid.Value;
                getStock = getStock + ",";
                getStock = getStock + DdlScheme.SelectedValue;
                getStock = getStock + ",";
                getStock = getStock + 0;
                getStock = getStock + ")";
                DataSet ds = obCommonF.FillDatasetByProc(getStock);
                ViewState["ds"] = ds;

                grdTitlegrid.DataSource = obDataset;
                grdTitlegrid.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["LetterNo"].ToString() != "")
                    {
                        TxtLetterNO.Text = Convert.ToString(ds.Tables[0].Rows[0]["LetterNo"]);
                    }
                    if (ds.Tables[0].Rows[0]["LetterDate"].ToString() != "")
                    {
                        TxtLetDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["LetterDate"]).ToString("dd/MM/yyyy").Replace("-", "/");
                        //TxtLetDate.Text = TxtLetDate.Text.Substring(0, 9);
                    }
                }
            }
            catch { }
        }
    }
    protected void DdlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlScheme.SelectedIndex > 0)
        {
            CommonFuction obCommonFuction = new CommonFuction();
            string Class = RadBtnListAgency.SelectedValue;
            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectClass('" + Class + "')");


            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "ClassDesc_V";
            DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //DdlClass.Items.Insert(1, new ListItem("-All-", "0"));
        }
        else
        {
            DdlClass.DataSource = string.Empty;
            DdlClass.DataBind();
        }
    }
    protected void BtnViewAll_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        lblSaveMsg.Text = "";
        string strclasses = "";
        foreach (ListItem item in DdlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + item.Value + ",";
            }
        }

        if (DdlDepot.SelectedItem.Value == "0" || DdlDepot.SelectedItem.Text == "--Select--")
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "कृपया डिपो चुने";
        }
        else if (DdlDistrict.SelectedItem.Value == "0" || DdlDistrict.SelectedItem.Text == "--Select--")
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "कृपया जिला चुने";
        }
        else if (DdlScheme.SelectedItem.Value == "0" || DdlScheme.SelectedItem.Text == "--Select--")
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "कृपया योजना चुने";
        }
        else if (strclasses == "")
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "response-msg error ui-corner-all";
            lblmsg.Style.Add("display", "block");
            lblmsg.Text = "कृपया कक्षा चुने";
        }
        else
        {
            FillGrid(strclasses);
        }


    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        string strclasses = "";
        foreach (ListItem item in DdlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + item.Value + ",";
            }
        }
        Response.Redirect("PrintDemand.aspx?DistrictID=" + DdlDistrict.SelectedValue + "&DepoID=" + DdlDepot.SelectedValue + "&Classes=" + strclasses + "&SchemeID="+DdlScheme.SelectedValue +"&Fyyear="+DdlACYear.SelectedItem.Text+"&DemandType="+DDlDemandType.SelectedValue +"");
    }
}

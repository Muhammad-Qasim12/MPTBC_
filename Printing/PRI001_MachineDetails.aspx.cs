using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_PRI001_MachineDetails : System.Web.UI.Page
{

    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["MachineId"] != null)
            {
                if (objapi.Decrypt ( Request.QueryString["MachineId"].ToString()) == "0")
                {
                    btnMachineDesSave.Enabled = false;
                }
                else { btnMachineDesSave.Enabled = true; }
            }
            else { Response.Redirect("PrinterRegDetails.aspx"); }

            Load();
        }
    }


   protected void BtnBack_Click(object sender, EventArgs e)
    { Response.Redirect("PrinterRegDetails.aspx"); }


    public void Load()
    {
        if (Request.QueryString["PriId"] != null)
        {

            FillYear();
            LoadMachineDesDDl();

            LoadMachineDetails();
            LoadMachineDescription();

        }

    }

    // fill dropdown of tab 2

    public void LoadMachineDesDDl()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {

            obPRI_PrinterRegistration.MachineID_I = 0;

            ddlMachineDescription.DataTextField = "MachineDescription";
            ddlMachineDescription.DataValueField = "MachineID_I";
            ddlMachineDescription.DataSource = obPRI_PrinterRegistration.MachineDesLoad();
            ddlMachineDescription.DataBind();

            ddlMachineDescription.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }




    //  for load machine details like mono type ,leno ,other

    public void LoadMachineDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        DataSet ds = new System.Data.DataSet();
        try
        {
           // obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(HdnPriMacDesID_I.Value);
            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString());
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }


            if (Request.QueryString["MachineId"] != null)
            {
                obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(objapi.Decrypt (Request.QueryString["MachineId"].ToString() ));
            }
            else
            {
                obPRI_PrinterRegistration.PriMacID_I = 0;
            }



            ds = obPRI_PrinterRegistration.PrinterMachineDescriptionLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {
                HdnPriMacDesID_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["PriMacID_I"]);

                txtComposing_Monotype_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Composing_Monotype_V"]);
                txtComposing_Linotype_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Composing_Linotype_V"]);
                txtComposAnyOthtype_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposAnyOthtype_V"]);
                lblFoundaryTyAtt_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["FoundaryTyAtt_V"]);
                txtComposingCapL1_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapL1_V"]);
                txtComposingCapP1_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapP1_I"]);
                txtComposingCapL2_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapL2_V"]);
                txtComposingCapP2_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapP2_I"]);
                txtComposingCapL3_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapL3_V"]);
                txtComposingCapP3_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapP3_I"]);
                txtLanguagesTxtSetAttach_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["LanguagesTxtSetAttach_V"]);
                txtMachineNo_I.Text=Convert.ToString(ds.Tables[0].Rows[0]["MachineNo_V"]);
                
            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }




    // function to load Machin list grid tab 2
    public void LoadMachineDescription()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(HdnPriMacID_I.Value);
            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt (Request.QueryString["PriId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            grdMachineDetails.DataSource = obPRI_PrinterRegistration.PrinterMachineListLoad();
            grdMachineDetails.DataBind();
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }





    


    // for save 12- 15 
    public int SaveMachineDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
           // obPRI_PrinterRegistration.PriMacDesID_I = Convert.ToInt32(HdnPriMacDesID_I.Value);

            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt (Request.QueryString["PriId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }


            if (Request.QueryString["MachineId"] != null)
            {
                obPRI_PrinterRegistration.PriMacDesID_I = Convert.ToInt32(objapi.Decrypt (Request.QueryString["MachineId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.PriMacDesID_I = 0;
            }


            obPRI_PrinterRegistration.Composing_Monotype_V = txtComposing_Monotype_V.Text;
            obPRI_PrinterRegistration.Composing_Linotype_V = txtComposing_Linotype_V.Text;
            obPRI_PrinterRegistration.ComposAnyOthtype_V = txtComposAnyOthtype_V.Text;

            string path = "";
            string ImgStatus = "Ok";
            if (FileFoundaryTyAtt_V.HasFile)
            {
                ImgStatus = objapi.SingleuploadFile(FileFoundaryTyAtt_V, "Printing/FoundryTypeInStock", 1000);
                if (ImgStatus == "Ok")
                {
                    path = "PrintingFile/" + objapi.FullFileName;
                }


                //string path = "PrintingFile/" + txtNameofPress_V.Text.Replace(" ", "").ToString() + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(fileProfreadpath_v.FileName);
                //fileProfreadpath_v.SaveAs(Server.MapPath(path));
                lblFoundaryTyAtt_V.Text = path;
              //  obPRI_PrinterRegistration.Profreadpath_v = path;
            }
            obPRI_PrinterRegistration.FoundaryTyAtt_V = lblFoundaryTyAtt_V.Text;

            if (ImgStatus == "Ok")
            {
                i = 1;
            }
            else
            {
                i = 0;
            }
            
            
            
            //if (FileFoundaryTyAtt_V.HasFile)
            //{
            //    FileFoundaryTyAtt_V.SaveAs(Server.MapPath("PrintingFile/" + "FoundryTypeInStock" + FileFoundaryTyAtt_V.FileName));

            //    lblFoundaryTyAtt_V.Text = "PrintingFile/" + "FoundryTypeInStock" + FileFoundaryTyAtt_V.FileName;

            //}
            //obPRI_PrinterRegistration.FoundaryTyAtt_V = lblFoundaryTyAtt_V.Text;



            //obPRI_PrinterRegistration.FoundaryTyAtt_V			=FileFoundaryTyAtt_V

            obPRI_PrinterRegistration.ComposingCapL1_V = txtComposingCapL1_V.Text;
            obPRI_PrinterRegistration.ComposingCapP1_I = txtComposingCapP1_I.Text != "" ? Convert.ToInt32(txtComposingCapP1_I.Text) : 0;
            obPRI_PrinterRegistration.ComposingCapL2_V = txtComposingCapL2_V.Text;
            obPRI_PrinterRegistration.ComposingCapP2_I = txtComposingCapP2_I.Text != "" ? Convert.ToInt32(txtComposingCapP2_I.Text) : 0;
            obPRI_PrinterRegistration.ComposingCapL3_V = txtComposingCapL3_V.Text;


            obPRI_PrinterRegistration.ComposingCapP3_I = txtComposingCapP3_I.Text != "" ? Convert.ToInt32(txtComposingCapP3_I.Text) : 0;

            //if (FileLanguagesTxtSetAttach_V.HasFile)
            //{
            //    FileFoundaryTyAtt_V.SaveAs(Server.MapPath("PrintingFile/" + "LanguagesInWhichTextbook" + FileLanguagesTxtSetAttach_V.FileName));

            //    lblLanguagesTxtSetAttach_V.Text = "PrintingFile/" + "LanguagesInWhichTextbook" + FileLanguagesTxtSetAttach_V.FileName;

            //}

            obPRI_PrinterRegistration.LanguagesTxtSetAttach_V = txtLanguagesTxtSetAttach_V.Text;

            //obPRI_PrinterRegistration.LanguagesTxtSetAttach_V=  = FilemLanguagesTxtSetAttach_V
            //file i=1 ok format
            if (i >= 1)
            {

                if (obPRI_PrinterRegistration.Printer_RedID_I == 0)
                {
                    Response.Redirect("PRI001_PrinterRegistration.aspx");
                }
                else
                {
                    i = obPRI_PrinterRegistration.PrinterMachineDetailsSaveUpdate();
                }
            }

        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;


    }


    // for save 16

    public int SaveMachineDescription()
    {

        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;

        try
        {

            obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(HdnPriMacID_I.Value);
            obPRI_PrinterRegistration.MachineID_I = Convert.ToInt32(ddlMachineDescription.SelectedValue);

            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt (Request.QueryString["PriId"]).ToString());
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }


            obPRI_PrinterRegistration.Make_V = txtMake_V.Text;
            obPRI_PrinterRegistration.Year_I = Convert.ToInt32(ddlYear_I.SelectedValue);

            string path = "";
            string ImgStatus = "Ok";
            if (filemFoundaryTyAtt_V.HasFile)
            {
                ImgStatus = objapi.SingleuploadFile(filemFoundaryTyAtt_V, "Printing/PrintingMachines", 1000);
                if (ImgStatus == "Ok")
                {
                    path = "PrintingFile/" + objapi.FullFileName;
                }


                //string path = "PrintingFile/" + txtNameofPress_V.Text.Replace(" ", "").ToString() + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(fileProfreadpath_v.FileName);
                //fileProfreadpath_v.SaveAs(Server.MapPath(path));
                lblFoundaryTyAtt_V.Text = path;
              //  obPRI_PrinterRegistration.FoundaryTyAtt_V = path;
            }
           // obPRI_PrinterRegistration.FoundaryTyAtt_V = lblFoundaryTyAtt_V.Text;

            if (ImgStatus == "Ok")
            {
             //   i = obPRI_PrinterRegistration.InsertUpdate();
            }
            else
            {
                i = 0;
            }




            //if (filemFoundaryTyAtt_V.HasFile)
            //{
            //    filemFoundaryTyAtt_V.SaveAs(Server.MapPath("PrintingFile/" + "PrintingMachines" + filemFoundaryTyAtt_V.FileName));

            //    lblmFoundaryTyAtt_V.Text = "PrintingFile/" + "PrintingMachines" + filemFoundaryTyAtt_V.FileName;

               
            //}

            obPRI_PrinterRegistration.FoundaryTyAtt_V = lblFoundaryTyAtt_V.Text;

            obPRI_PrinterRegistration.nOOFmACHINE = Convert.ToInt32(txtnOOFmACHINE.Text);
            obPRI_PrinterRegistration.pRINcAPASITY_v = txtpRINcAPASITY_v.Text;
            obPRI_PrinterRegistration.DateOfInstallation_D = Convert.ToDateTime(txtDateOfInstallation_D.Text, cult);
            obPRI_PrinterRegistration.MachineNo_V = txtMachineNo_I.Text;


            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { Response.Redirect("PRI001_PrinterRegistration.aspx"); }
            else
            {

                i = obPRI_PrinterRegistration.PrinterMachineListSaveUpdate();


            }

        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;

    }

    // for select data from gridview
    protected void grdMachineDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            HdnPriMacID_I.Value = ((HiddenField)grdMachineDetails.Rows[e.RowIndex].FindControl("HdnPriMacID_I")).Value;
            //HdnPriMacID_I.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblPriMacID_I")).Text;

            ddlMachineDescription.SelectedValue = ((HiddenField)grdMachineDetails.Rows[e.RowIndex].FindControl("HdnmMachineID_I")).Value;


            txtMake_V.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblMake_V")).Text;
           
            txtDateOfInstallation_D.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblDateOfInstallation_D")).Text;
            txtnOOFmACHINE.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblnOOFmACHINE")).Text;
            txtpRINcAPASITY_v.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblpRINcAPASITY_v")).Text;
            ddlYear_I.SelectedValue = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblYear_I")).Text;

        }
        catch (Exception ex) { }
        finally { }
    }

    //  button of 12-15 save

    protected void btnMachineDesSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = SaveMachineDetails();
        if (i > 0)
        {

            HdnPriMacDesID_I.Value = i.ToString();


           
                LoadMachineDescription();
          
            
            
            btnMachineDesSave.Enabled = true;

            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('fadeDiv').style.display='block'; document.getElementById('SuccessDiv').style.display='block';</script>");

            Response.Redirect("PrinterRegDetails.aspx");
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Check Your Data.');</script>"); }

    }



    // function to validate Machine Details

    public int ValidateMachineDetails()
    {
        int i = 0;

        ddlMachineDescription.BackColor = System.Drawing.Color.White;
        txtMake_V.BackColor = System.Drawing.Color.White;
        ddlYear_I.BackColor = System.Drawing.Color.White;
        txtDateOfInstallation_D.BackColor = System.Drawing.Color.White;
        txtnOOFmACHINE.BackColor = System.Drawing.Color.White;
        txtpRINcAPASITY_v.BackColor = System.Drawing.Color.White;

        if (ddlMachineDescription.SelectedValue == "0")
        {
            i++;
            ddlMachineDescription.BackColor = System.Drawing.Color.Red;
        }

        else
            if (txtMake_V.Text == "")
            {
                i++;
                txtMake_V.BackColor = System.Drawing.Color.Red;
            }
            else
                if (ddlYear_I.SelectedValue == "0")
                {
                    i++;
                    ddlYear_I.BackColor = System.Drawing.Color.Red;
                }
                else
                    if (txtDateOfInstallation_D.Text == "")
                    {
                        i++;
                        txtDateOfInstallation_D.BackColor = System.Drawing.Color.Red;
                    }
                    else
                        if (txtnOOFmACHINE.Text == "")
                        {
                            i++;
                            txtnOOFmACHINE.BackColor = System.Drawing.Color.Red;
                        }
                        else
                            if (txtpRINcAPASITY_v.Text == "")
                            {
                                i++;
                                txtpRINcAPASITY_v.BackColor = System.Drawing.Color.Red;
                            }
        return i;
    }

    // button of 16 save
    protected void btnMachineDetailsave_Click(object sender, EventArgs e)
    {

        int i = 0;
        if (ValidateMachineDetails() == 0)
        {
            i = SaveMachineDescription();
        }
        if (i > 0)
        {
            // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('fadeDiv').style.display='block'; document.getElementById('SuccessDiv').style.display='block';</script>");

            HdnPriMacDesID_I.Value = i.ToString();
            ddlMachineDescription.SelectedValue = "0";
            HdnPriMacID_I.Value = "0";
            txtMake_V.Text = "";
            //txtYear_I.Text = "";
            txtDateOfInstallation_D.Text = "";
            txtnOOFmACHINE.Text = "";
            txtpRINcAPASITY_v.Text = "";

            LoadMachineDescription();

            btnMachineDesSave.Enabled = true ;
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Check Your Data.');</script>"); }
    }



    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRI001_BindingDetails.aspx?PriId=" + Request.QueryString["PriId"] + "");

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterRegDetails.aspx");

    }



    public void FillYear() 
    {
        for (int i = 1950; i < Convert.ToInt32(DateTime.Now.Year); i++)
        {
            ddlYear_I.Items.Add(i.ToString());
       

        }
        ddlYear_I.Items.Insert(0, new ListItem("Select", "0"));
    }

    protected void grdMachineDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try {
        CommonFuction comm = new CommonFuction();
        comm.FillDatasetByProc("call PrinterMachineDelete(" + grdMachineDetails.DataKeys[e.RowIndex].Value + ")");
            }catch {}
        LoadMachineDescription();
    }
    //protected void GrdWarehouse_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "eDelete")
    //    {
    //        obWareHouseMaster = new WareHouseMaster();
    //        obWareHouseMaster.Delete(Convert.ToInt32(e.CommandArgument));
    //        FillData();
    //        Response.Write("<script>alert('Record has deleted');</script>");
    //    }
    //}
    protected void grdMachineDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {

        }
    }
}
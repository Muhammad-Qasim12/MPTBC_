using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MessageC
/// </summary>
public class MessageC
{
    public void Msg(string msg)
    {
        Page pg = HttpContext.Current.Handler as Page;
        string strScript = "javascript: alert('" + msg + "')";
        //pg.ClientScript.RegisterStartupScript(typeof(Page), "key", "<script>alert('" + msg + "')</script>");
        ScriptManager.RegisterStartupScript(pg, this.GetType(), "strScript", strScript, true);
    }
    public void MsgBox(string msg)
    {
        Page pg = HttpContext.Current.Handler as Page;
        string strScript = "javascript: alert('" + msg + "')";
        //pg.ClientScript.RegisterStartupScript(typeof(Page), "key", "<script>alert('" + msg + "')</script>");
        ScriptManager.RegisterStartupScript(pg, this.GetType(), "strScript", strScript, true);
    }

    public void MsgScriptwith(string msgsc, string url)
    {
        Page page = HttpContext.Current.Handler as Page;
        string strScript = "javascript: alert('" + msgsc + "');window.location='" + url + "';";
        //string strScript = "<script>";
        //strScript += "alert('" + msgsc + "');";
        //strScript += "window.location='" + url + "';";
        //strScript += "</script>";
        // page.ClientScript.RegisterStartupScript(this.GetType(), "Startup", strScript);
        ScriptManager.RegisterStartupScript(page, this.GetType(), "strScript", strScript, true);
    }
    public void ShowMessage(string icon)
    {
        Page page = HttpContext.Current.Handler as Page;
        page.ClientScript.RegisterStartupScript(typeof(Page), "key", SweetAlert(icon, ""));
    }
    public void ShowOtherMessage(string icon, string msg)
    {
        Page page = HttpContext.Current.Handler as Page;
        page.ClientScript.RegisterStartupScript(typeof(Page), "key", SweetAlert(icon, msg));
    }
    public string Alert(string icon, string AlertClass, string Heading, string Description)
    {
        return "<div class='box-body'> <div class='alert " + AlertClass + " alert-dismissible'> <button type='button' class='close' data-dismiss='alert' aria-hidden='true'>×</button> <h4><i class='icon fa " + icon + "'></i>" + Heading + "</h4>" + Description + "</div> </div>";

    }
    public string SweetAlert(string icon, string msg)
    {
        string title = "", text = "";
        if (icon == "s")
        {
            icon = "success";
            title = "Thank You!";
            text = "Details saved Successfully";
        }
        else if (icon == "u")
        {
            icon = "success";
            title = "Thank You!";
            text = "Details updated Successfully";
        }
        else if (icon == "d")
        {
            icon = "success";
            title = "Thank You!";
            text = "Details deleted Successfully";
        }
        else if (icon == "e")
        {
            icon = "error";
            title = "Error!";
            if (string.IsNullOrEmpty(msg))
                text = "Unable to process request - Server or Network error...";
            else
                text = msg;
        }
        string script = @"<script>Swal.fire({title: '" + title + "',text: '" + text + "',icon: '" + icon + "'});</script>";
        return script;
    }
    public string SweetAlertDelete()
    {
        string script = @"
        <script type='text/javascript'>
                            Swal.fire({
                    title: 'Confirm Delete',
                    text: 'Are you sure you want to delete this item?',
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, delete it!',
                    cancelButtonText: 'No, cancel'
                }).then((result) => {
                    if (result.isConfirmed) {
                        // User clicked 'Yes, delete it!' in the confirmation dialog
                        // You can proceed with the delete operation or set a flag for deletion
                       
                    }
                });
            
        </script>";
        return script;
    }
}

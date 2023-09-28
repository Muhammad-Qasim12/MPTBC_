<%@ Control Language="VB" AutoEventWireup="false"
    Inherits="WebYojna.UserControls_UCDisplayInfo" Codebehind="UCDisplayInfo.ascx.vb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<table width="100%">
    <tr>
        <td width="30%" align="left">
            &nbsp;<asp:Label ID="lblFromandToDate" runat="server" CssClass="copyright"></asp:Label>
            &nbsp;
            <asp:Label ID="lblFromandFromDate" runat="server" CssClass="copyright"></asp:Label>
        </td>
        <td width="50%" align="right">
            <marquee scrollamount="3">  
            <asp:Label ID="lblUserName" runat="server" CssClass="copyright" ></asp:Label>
            &nbsp; &nbsp;<asp:Label ID="lblBranchName" runat="server" CssClass="copyright" ></asp:Label>
             &nbsp; &nbsp;<asp:Label ID="lblBranchCode" runat="server" CssClass="copyright" ></asp:Label>
            &nbsp; &nbsp;<asp:Label ID="lblFunctionaryName" runat="server" CssClass="copyright" ></asp:Label>   
         </marquee>
        </td>
        <td width="20%" align="right">
         <a id="acomp" runat="server"  href="http://www.PrathamSoft.com" target="_blank" style="text-decoration: None;"
                class="copyright">© Pratham Softcon Pvt. Ltd.</a>
            &nbsp;
        </td>
    </tr>
</table>

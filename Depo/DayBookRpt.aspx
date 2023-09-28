<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DayBookRpt.aspx.cs" Inherits="Depo_DayBookRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table>
        <tr>
            <td colspan="3">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbllbal" Text=" &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :" runat="server" ></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox">

                </asp:TextBox>
                <br />
                <br />
            </td>
            <td style="width: 30%; font-size: medium;" valign="top">
                <asp:Label ID="LblClass" runat="server" Width="100px">&#2325;&#2325;&#2381;&#2359;&#2366;:</asp:Label>
                <asp:DropDownList ID="DdlClass" runat="server"  CssClass="txtbox" >
                </asp:DropDownList>
            </td>
            <td style="width: 30%; font-size: medium;" valign="top">&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 30%; font-size: medium;" valign="top">
                <asp:Label ID="LblScheme" runat="server" Width="100px">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;:</asp:Label>
                <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                </asp:DropDownList>
            </td>
            <td style="width: 30%; font-size: medium;" valign="top">
                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
       
    </table>
    <div class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server">
                    </rsweb:ReportViewer>
                </div>
</asp:Content>


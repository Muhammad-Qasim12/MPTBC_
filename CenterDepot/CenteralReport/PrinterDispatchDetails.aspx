<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterDispatchDetails.aspx.cs" Inherits="CenterDepot_CenteralReport_PrinterDispatchDetails" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-header ui-widget-header">
     &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2325;&#2379; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2366;&#2327;&#2332; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </div>
    <div class="portlet-content">
      
          <div class="table-responsive">  
          <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;<br />Academic Year
                    </td>
                    <td>
                      <asp:DropDownList runat="server" ID="DdlACYear" Width="250px" CssClass="txtbox reqirerd" >
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    </td>
                    <td>
                        &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                    </td>
                    <td><asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                        OnClick="btnSearch_Click"   OnClientClick="return ValidateAllTextForm();"/>
                    </td>
                </tr>
                <tr runat="server" id="trRV">
                    <td colspan="5">
                    <center>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                            Width="100%" Height="657px">
                        </rsweb:ReportViewer></center>
                    </td>
                </tr>
            </table></div>
        </div>
</asp:Content>


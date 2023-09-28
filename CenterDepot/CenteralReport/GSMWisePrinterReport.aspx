<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GSMWisePrinterReport.aspx.cs" Inherits="CenterDepot_CenteralReport_GSMWisePrinterReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-header ui-widget-header">
       प्रिंटर द्वारा आवंटन के विरुध्द कागज का उठाव 

    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                     <td> 
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Academic Year
                    </td>
                    <td>
                           <asp:DropDownList ID="ddlAcYear" runat="server" CssClass="txtbox" AutoPostBack="true" Width="250px"  >
                        </asp:DropDownList>
                    </td>
                    <td>
                        प्रिंटर का नाम<br /> Printer Name
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPrinterName" Width="250px" CssClass="txtbox"
                            OnInit="ddlPrinterName_Init">
                            <asp:ListItem Text="All"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        दिनांक से<br />From Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="txtbox" MaxLength="10" Width="238px"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                         दिनांक तक<br />To Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" MaxLength="10" Width="238px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center" >
                    <center>
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                            InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                            Width="100%" Height="657px">
                        </rsweb:ReportViewer></center>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


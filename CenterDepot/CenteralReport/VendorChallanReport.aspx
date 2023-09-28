<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VendorChallanReport.aspx.cs" Inherits="CenterDepot_CenteralReport_VendorChallanReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-header ui-widget-header">
        पेपर मिलवार चालान प्राप्ति की जानकारी </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;<br />
                                        Academic Year
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlYear" Width="250px" CssClass="txtbox reqirerd" 
                                         
                                            >
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                                        Name Of Paper Mill
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" 
                                            
                                            CssClass="txtbox reqirerd">
                                          
                                        </asp:DropDownList>
                                    </td> 
                                    <td>
                            <asp:DropDownList ID="ddlGSM" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlGSM_SelectedIndexChanged">
                            </asp:DropDownList>


                                    </td>
                                </tr> 
                                <tr>
                                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                                        <cc1:calendarextender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy">
                        </cc1:calendarextender>
                                    </td>
                                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTodate" runat="server"></asp:TextBox>
                                        <cc1:calendarextender ID="Calendarextender1" runat="server" TargetControlID="txtTodate"
                            Format="dd/MM/yyyy">
                        </cc1:calendarextender>
                                    </td> 
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                                    </td>
                                </tr> 
                                <tr>
                                    <td colspan="5">
                                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                                        </rsweb:ReportViewer>
                                    </td>
                                </tr> </table> </td> </tr> </table> 

            </div> </div> </div> 
</asp:Content>


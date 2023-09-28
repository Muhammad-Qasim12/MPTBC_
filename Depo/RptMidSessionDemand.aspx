<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptMidSessionDemand.aspx.cs" Inherits="Depo_RptMidSessionDemand" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">

        <div class="card-header">
            <h2>&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2360;&#2375; &#2350;&#2343;&#2381;&#2351;&#2366;&#2357;&#2343;&#2367; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Demands Of Intermediate Books To Depot&nbsp; Report</h2>
        </div>
        <div style="padding: 0 10px;">


            <table width="100%">
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;&nbsp; / From Date 
                                   <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                        <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                        </cc1:calendarextender>

                      
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                        <cc1:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" Format="dd/MM/yyyy">
                        </cc1:calendarextender>

                        
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                            <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                        </td>
                </tr>
                 </table> </div> 
</asp:Content>


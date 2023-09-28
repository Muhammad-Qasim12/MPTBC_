<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerDemandPraday.aspx.cs" Inherits="Depo_BookSellerDemandPraday" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">

        <div class="card-header">
            <h2>पुस्तक विक्रेता की मांग एवं प्रदाय की जानकारी </h2>
        </div>
        <div style="padding: 0 10px;">


            <table width="100%">
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;&nbsp; / From Date 
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                      
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                    </td>
                </tr>
                <tr>
                    <td>कक्षा 
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox">
                            <asp:ListItem Value="All">All</asp:ListItem>
                            <asp:ListItem Value="1-8">1-8</asp:ListItem>
                            <asp:ListItem Value="9-12">9-12</asp:ListItem>
                            
                           
                        </asp:DropDownList>

                      
                    </td>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="रिपोर्ट देखे " OnClientClick='javascript:return ValidateAllTextForm();' />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                            <rsweb:ReportViewer ID="ReportViewer1" Width="98%" runat="server" DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer> 
                    </td>
                </tr>
                </table> </div> 
</asp:Content>


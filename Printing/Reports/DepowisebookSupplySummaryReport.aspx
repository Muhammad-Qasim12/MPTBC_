<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepowisebookSupplySummaryReport.aspx.cs" Inherits="Printing_Reports_DepowisebookSupplySummaryReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="card-header">
            <h2>
                 
डिपो में मुद्रको से  प्राप्त पुस्तको की जानकारी </h2>
        </div>
     <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: center" class="auto-style1">
                                    <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                                    </td><td class="auto-style1">
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                    </td><td class="auto-style1">
                        &nbsp;</td><td class="auto-style1">
                        &nbsp;</td><td class="auto-style1">
                        &nbsp;</td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1">
                        &#2325;&#2325;&#2381;&#2359;&#2366;</td><td class="auto-style1">
                        <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                            <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                            <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                        </asp:DropDownList>
                    </td><td class="auto-style1">
                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td><td class="auto-style1">
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td><td class="auto-style1">
                        &nbsp;</td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1">
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                       
                        &#2360;&#2375;&nbsp; </td><td class="auto-style1">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox1">
                        </cc1:CalendarExtender>
                    </td><td class="auto-style1">
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
                    </td><td class="auto-style1">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox"></asp:TextBox>
                         <cc1:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox2">
                        </cc1:CalendarExtender>
                    </td><td class="auto-style1">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Show Report" OnClick="Button1_Click" />
                    </td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1" colspan="5">
                        <asp:Panel ID="Panel1" runat="server" Width="1350px" Height="700px" ScrollBars="Both" >
                         <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True">
                            </rsweb:reportviewer></asp:Panel>
                       
                    </td> </tr> 
                </table> </div> 
</asp:Content>


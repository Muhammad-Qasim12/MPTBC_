<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockLedger.aspx.cs" Inherits="Depo_StockLedger" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="a1" runat="server" class="card-header" >
        <h2>&#2348;&#2369;&#2325; &#2360;&#2381;&#2335;&#2377;&#2325; &#2354;&#2375;&#2332;&#2375;&#2352; / Book Stock Ledger</h2>
    </div>
 <table width="100%">
                <tr>
                    <td colspan="3">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">&#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                            <asp:ListItem Value="2">&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                        </asp:RadioButtonList>

                      
                    </td>
                </tr>
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; / From Date 
                    <asp:TextBox ID="TextBox1"  CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                      
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / To Date
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                      
                    </td>
                </tr>
                <tr>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click"
                            OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" />
                    </td>
                </tr>
              
            </table>
     <div style="overflow: auto" class="rdlc">
            <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True">
                            </rsweb:reportviewer>
        </div>
</asp:Content>


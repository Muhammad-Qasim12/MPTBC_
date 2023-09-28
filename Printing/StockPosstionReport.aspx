<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockPosstionReport.aspx.cs" Inherits="Printing_StockPosstionReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="height: 1px">&#2360;&#2381;&#2335;&#2377;&#2325; &#2346;&#2379;&#2332;&#2368;&#2358;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Position Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; / From Date 
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
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
                    <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox ">
                    </asp:DropDownList>

                    </td>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;                             
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>डिपो का नाम  
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlDepo" runat="server" CssClass="txtbox ">
                    </asp:DropDownList>

                    </td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click"
                            OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" />
                    </td>
                </tr>
            </table>
        </div>
        <div style="overflow: auto" class="rdlc">
            <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True">
                            </rsweb:reportviewer>
        </div>

        
    </div>
</asp:Content>


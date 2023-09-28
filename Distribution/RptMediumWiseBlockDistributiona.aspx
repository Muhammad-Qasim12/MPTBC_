<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptMediumWiseBlockDistributiona.aspx.cs" Inherits="Distribution_RptMediumWiseBlockDistributiona" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2><span>
               पाठ्यपुस्तको की डिपो मांग एवं प्रदाय की रिपोर्ट
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class :</asp:Label>
                            <asp:DropDownList ID="DDLClass" runat="server"  CssClass="txtbox" >
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <%--   <asp:Label ID="LblDistrict" runat="server" Width="100px">&#2332;&#2367;&#2354;&#2366;  :</asp:Label>
                        <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox"  Enabled ="false">
                        </asp:DropDownList >--%>
                            <asp:Label ID="LblScheme" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:Label>
                            <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="font-size: medium;" valign="top" colspan="3">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report " />
                        </td>
                    </tr>
                </table>
                <div class="rdlc" style="overflow: auto">
                    
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                        InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                        Width="100%" Height="800px">
                    </rsweb:ReportViewer>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>


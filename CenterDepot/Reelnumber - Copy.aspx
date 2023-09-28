<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reelnumber.aspx.cs" Inherits="CenterDepot_Rellnumber" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2352;&#2368;&#2354; / &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2326;&#2379;&#2332;&#2375;
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                           
                        </td>
                        <td style="text-align: right" width="75%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="Search By Reel/Bundle NO"></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left; width: 25%;" colspan="3">
                           
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table width="100%">
                                                                    <tr>
                                                                        <td width="25%" style="padding-bottom: 10px;">&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; Name Of Paper Mill </td>
                                                                        <td width="25%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("PaperVendorName_V")%></td>
                                                                        <td width="25%" style="padding-bottom: 10px;">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  Challan No. </td>
                                                                        <td width="25%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("ChallanNo")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%">&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;  Paper Type </td>
                                                                        <td width="25%" style="font-weight: bold;"><%#Eval("PaperType")%></td>
                                                                        <td width="25%">&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; Paper Size</td>
                                                                        <td width="25%" style="font-weight: bold;"><%#Eval("CoverInformation")%></td>
                                                                    </tr>
                                                <tr>
                                                    <td width="25%" style="font-weight: bold;">Net Waight</td>
                                                    <td width="25%" style="font-weight: bold;"><%#Eval("Netwt")%></td>
                                                    <td width="25%" style="font-weight: bold;">Received Date</td>
                                                    <td width="25%" style="font-weight: bold;"><%#Eval("ReceivedDT")%></td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" style="font-weight: bold;">Type</td>
                                                    <td  width="25%" style="font-weight: bold;"><%#Eval("DefectedReelSts")%></td>
                                                    <td width="25%">.</td>
                                                    <td width="25%">.</td>
                                                </tr>
                                            </table> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="3">
                            
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View19.aspx.cs" Inherits="Depo_View19" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&nbsp; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Demand In Open Market</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Data"  OnClick="Redirect" 
                            />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <table style="width: 100%">
                            <tr>
                                <td style="font-size: medium;">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year </td>
                                <td>
                                    <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <span style="color: rgb(34, 34, 34); font-family: Arial, Verdan, sans-serif; font-size: medium; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 16px; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(252, 253, 253);">माध्यम /Medium</span></td>
                                <td>
                                    <asp:DropDownList ID="ddlMedum" runat="server" CssClass="txtbox reqirerd"  Width="114px">
                                    </asp:DropDownList>
                                </td>
                                <td style="font-size: medium;">&#2325;&#2325;&#2381;&#2359;&#2366;: / Class </td>
                                <td style="font-size: medium;">
                                    <asp:DropDownList ID="ddlClass" runat="server"  CssClass="txtbox reqirerd"  Width="114px">
                                    </asp:DropDownList>
                                </td>
                                <td style="font-size: medium;">
                        <asp:Button ID="btnSave0" runat="server" CssClass="btn" Text="Search"  OnClick="btnSave0_Click" 
                            />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year">
                                    <ItemTemplate>
                                        <%#Eval("Session_v")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Books Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2367;&#2331;&#2354;&#2375; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2325;&#2368; &#2327;&#2351;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; / Sold Books Last Year">
                                    <ItemTemplate>
                                      <asp:Label ID="lblLastYearSaleBook" runat="server"   onkeypress='javascript:tbx_fnNumeric(event, this);' Text='<%#Eval("LastYearSale") %>' ></asp:Label>
                                     
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2379;&#2332;&#2369;&#2342;&#2366; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Open Market Demand In Current Year">
                                    <ItemTemplate>                                        
                                         <asp:Label ID="lblCurntYearOpenBook" runat="server" onblur="CalulateTotal(this);" onkeypress='javascript:tbx_fnNumeric(event, this);'   OnTextChanged="lblCurntYearOpenBook" Text='<%#Eval("CurntYarNeed") %>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                          <%--      <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPlanStock" runat="server" CssClass="txtbox"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; / To Sell In Open Market's Stock">
                                    <ItemTemplate>
                                        <asp:Label ID="txtOpenTentetiveStock" onblur="CalulateTotal1(this);" onkeypress='javascript:tbx_fnNumeric(event, this);'  OnTextChanged="lblCurntYearOpenBook" runat="server" 
                                        
                                        
                                        
                                        
                                         Text='<%#Eval("OpnMrketStk") %>' MaxLength="10" ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2379;&#2332;&#2369;&#2342;&#2366; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2344;&#2375;&#2335; &#2350;&#2366;&#2306;&#2327; / Net Demand In Current Year">
                                    <ItemTemplate>
                                        <asp:Label ID="txtNetDemand"  runat="server"  Enabled="false" MaxLength="10" Text='<%#Eval("NetDemand") %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; " Visible="false">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox"  MaxLength="200"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>


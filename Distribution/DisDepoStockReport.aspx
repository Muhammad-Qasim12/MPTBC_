<%@ Page Title="&#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Detail" Language="C#"
    EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisDepoStockReport.aspx.cs" Inherits="Depo_DepoStockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">

        <div class="card-header">
            <h2>&#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Details</h2>
        </div>
        <div style="padding: 0 10px;">
            <table>
                <tr>
                    <td>डिपो का नाम (Depo)</td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList></td>
                    <td>&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;</td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox ">
                        </asp:DropDownList></td>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                        </asp:DropDownList></td>

                    <td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                    <td>
                        <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                            <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                            <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                        </asp:DropDownList></td>

                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn"
                            Text="Export to Excel" OnClick="btnExport_Click" />

                    </td>
                </tr>


            </table>

        </div>
        <div class="box table-responsive" runat="server" visible="false" id="a">
            <div id="ExportDiv" runat="server">
                <table width="100%">
                    <tr>
                        <td align="center"><b>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
                            <br />
                            &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                            <br />
                        </b>
                        </td>
                    </tr>

                    <tr>
                        <td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
                        </b>
                            &nbsp;&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Detail (&#2309;&#2343;&#2340;&#2344; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; :
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            )</td>
                    </tr>

                    <tr>
                        <td style="font-weight: bold">डिपो :<asp:Label ID="lblDipo" runat="server" Text=""></asp:Label>
                            , 
                            माध्यम:
                            <asp:Label ID="lblMedium" runat="server" Text=""></asp:Label>
                            , 
                            पुष्तक का नाम:
                            <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label>, 
                            कक्षा:
                            <asp:Label ID="lblClass" runat="server" Text=""></asp:Label>

                        </td>
                    </tr>
                </table>
                <asp:GridView ID="grdstockreport" runat="server" CssClass="tab" AutoGenerateColumns="false" OnSelectedIndexChanged="grdstockreport_SelectedIndexChanged">

                    <Columns>

                        <asp:TemplateField>
                            <HeaderTemplate>

                                <tr>
                                    <th colspan="1" style="border: #ccc 1px solid; background-color: #4d4d4d; color: White;" align="center">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.</th>
                                    <th colspan="1" style="border: #ccc 1px solid; background-color: #4d4d4d; color: White;" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name </th>
                                    <th colspan="5" style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2351;&#2379;&#2332;&#2344;&#2366; / Scheme </th>
                                    <th colspan="5" style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; / General </th>
                                </tr>

                                <tr>

                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; color: White;" align="center"></th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center"></th>

                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; color: White;" align="center">&#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Bundle
                                        <br />
                                    </th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Per Bundle Book No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2354;&#2370;&#2360; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Loose Bundle Book No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total No. Of Book  </th>

                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2348;&#2306;&#2337;&#2354;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Bundle No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Per Bundle No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2354;&#2370;&#2360; &#2348;&#2306;&#2337;&#2354; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Loose Bundle Book No.</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total Book No. </th>
                                </tr>
                                <tr>

                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; color: White;" align="center">1</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">2</th>

                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; color: White;" align="center">3 </th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">4</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">5</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">6</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">7  </th>

                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">8</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">9</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">10</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">11</th>
                                    <th style="border: #ccc 1px solid; background-color: #4d4d4d; padding: 5px; height: 30px; color: White;" align="center">12</th>
                                </tr>
                            </HeaderTemplate>

                            <ItemTemplate>

                                <%# Container.DataItemIndex +1 %>
                                <td><%# Eval("Title") %></td>
                                <td><%# Eval("cnt2") %> </td>
                                <td><%# Eval("booksperbundleY") %></td>
                                <td>
                                    <div style="width: 200px; overflow: auto;"><%# Eval("bundlesSY") %></div>
                                </td>
                                <td>
                                    <div style="width: 200px; overflow: auto;"><%#Eval("RemaingLoose_VY") %></div>
                                </td>
                                <td><%#Eval("noofbooky") %> </td>
                                <td><%# Eval("cnt1") %> </td>
                                <td><%# Eval("booksperbundleS") %></td>
                                <td>
                                    <div style="width: 200px; overflow: auto;"><%# Eval("bundlesS") %> </div>
                                </td>
                                <td>
                                    <div style="width: 200px; overflow: auto;"><%#Eval("RemaingLoose_VS") %></div>
                                </td>
                                <td><%#Eval("NO Of Books") %></td>



                            </ItemTemplate>


                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
            </div>
        </div>
    </div>


</asp:Content>


<%@ Page Title="&#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Detail" Language="C#"
    EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoStockReport.aspx.cs" Inherits="Depo_DepoStockReport" %>

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

            <table width="100%">
                <tr>
                    <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :</td>
                    <td>

                    &nbsp;<asp:DropDownList ID="ddlSessionYear" runat="server">
                        </asp:DropDownList>

                    </td><td>&nbsp;</td><td>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>

                    </td><td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td><td>
                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DDLClass_SelectedIndexChanged">
                        <asp:ListItem Value="0">Select..</asp:ListItem>
                        <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                        <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                    </asp:DropDownList>
                
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;&nbsp;&nbsp;</td>
                    <td>

                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                
                    </td><td colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr>
                </table> 
        </div> 
    <div class="box table-responsive" runat="server" visible="false" ID="a">
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
                    <td>&nbsp;</td>
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
            </table>
            <asp:GridView ID="grdstockreport" runat="server" CssClass="tab" AutoGenerateColumns="false" OnSelectedIndexChanged="grdstockreport_SelectedIndexChanged" OnRowDataBound="grdstockreport_RowDataBound">

                <Columns>

                    <asp:TemplateField>
                        <HeaderTemplate>

                          <tr>
                <th rowspan="2">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </th>
                <th rowspan="2">प्रति बण्डल पुस्तक संख्या </th>
                <th colspan="5" style="text-align: center">&#2351;&#2379;&#2332;&#2344;&#2366; </th>
                <th colspan="5" style="text-align: center">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</th>
                <th rowspan="2">&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; </th>
            </tr>
            <tr>
                <th>&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                <th>&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                <th>&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                <th>&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
                <th>&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; </th>
                <th>&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                <th>&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                <th>&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                <th>&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
                <th>&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; </th>
            </tr>
            <tr>
                <th>1</th>
                <th>2</th>
                <th>3</th>
                <th>4</th>
                <th>5</th>
                <th>6</th>
                <th>7</th>
                <th>8</th>
                <th>9</th>
                <th>10</th>
                <th>11</th>
                <th>12</th>
                <th>13</th>
                <th>14</th>
            </tr>   

                        </HeaderTemplate>

                        <ItemTemplate>
                           <tr>
                           <td> <%# Container.DataItemIndex +1 %></td>
                <td><%# Eval("Title") %></td>
                <td> <%# Eval("booksperbundleY").ToString()=="0"? Eval("booksperbundleS"):Eval("booksperbundleY")  %> </td>
                <td>  <asp:Label Text='<%#Eval("cnt2") %>' ID="lblBandalS" runat="server"></asp:Label>
                    </td>
                <td>
                    <div style="width: 200px; overflow: auto;">
                        <%# Eval("bundlesSY") %>
                    </div>
                </td>
                <td><%# Eval("YojnaL") %> </td>
                <td>
                    <div style="width: 200px; overflow: auto;">
                        <%#Eval("bundlesYLooj") %>
                        </div>
                </td>
                <td><%#Eval("noofbooky") %> </td>
                <td><%# Eval("cnt1") %> </td>
                <td>
                    <div style="width: 200px; overflow: auto;">
                        <%# Eval("bundlesS") %> 
                    </div>
                </td>
                <td><%#Eval("SamanyL") %> </td>
                <td>
                    <div style="width: 200px; overflow: auto;">
                        <%#Eval("bundlesSLooj") %>
                        </div>
                </td>
                <td><%#Eval("NO Of Books") %></td>
                <td> <%# Convert.ToInt32(Eval("NO Of Books") ) + Convert.ToInt32(Eval("noofbooky"))%></td>
            </tr>
            </ItemTemplate>


                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="Gvpaging" />
                <EmptyDataRowStyle CssClass="GvEmptyText" />
            </asp:GridView>
        </div>
    </div>
    <asp:Button ID="btnExport" runat="server" CssClass="btn_gry"
        Text="Export to Excel" OnClick="btnExport_Click" />

</asp:Content>


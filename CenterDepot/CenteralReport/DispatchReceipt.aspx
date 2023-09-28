<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DispatchReceipt.aspx.cs" Inherits="CenterDepot_CenteralReport_DispatchReceipt" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>
    <div class="portlet-header ui-widget-header">
        &#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#23<a href="DispatchReceipt.aspx">DispatchReceipt.aspx</a>68; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
    </div>
    <div class="portlet-content">
      <div class="table-responsive">  <table width="100%" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;
                </td>
                <td>
                 <%--   <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
                <td>
                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                </td>
                <td>
                 <%--   <asp:DropDownList runat="server" ID="ddlChallanNo" Width="250px" CssClass="txtbox reqirerd">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td>
                    <div  style="width: 40px; color: White;">
                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a></div>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                        OnClientClick="return ValidateAllTextForm();"  />
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <div style="width: auto; height: auto;">
                        <center>
                            <div class="MT20">
                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                    <div style="width: 900px;">
                                        <div style="padding: 10px;">
                                            <table width="100%">
                                               <tr>
                                                    <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                       एम. पी. सी. टी. बी. पी. एल :- 1/XXXXIX/1188
                                                    </td>
                                                    <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                        Fax/ डिपो : 2807572
                                                    </td>
                                                </tr>
                                                   <tr>
                                                    <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                        सी. एस. टी. बी. पी एल :- 
                                                    </td>
                                                    <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                        &#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;
                                                        &#2344;&#2367;&#2327;&#2350;
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                        &#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;
                                                        &#2344;&#2367;&#2327;&#2350;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">
                                                        &#2337;&#2367;&#2354;&#2368;&#2357;&#2352;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; ,&#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">
                                                        &#2352;&#2340;&#2344;&#2346;&#2369;&#2352;(&#2349;&#2379;&#2346;&#2366;&#2354;)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;........../&#2346;&#2366;&#2346;&#2369;&#2344;&#2367;/&#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;
                                                    </td>
                                                    <td colspan="2">
                                                        &#2349;&#2379;&#2346;&#2366;&#2354;, &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;..........
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &#2346;&#2381;&#2352;&#2340;&#2367;,
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &#2350;&#2375;&#2360;&#2352;&#2381;&#2360;.......................
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &#2319;&#2337;&#2381;&#2352;&#2375;&#2360;.......................
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &#2357;&#2367;&#2359;&#2351; - &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; / &#2325;&#2357;&#2381;&#2361;&#2352; &#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2375; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2332;&#2366;&#2352;&#2368; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2375; &#2360;&#2306;&#2342;&#2352;&#2381;&#2349; &#2350;&#2375;&#2306; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; / &#2325;&#2357;&#2381;&#2361;&#2352;
                                                        &#2325;&#2366;&#2327;&#2332; &#2310;&#2346;&#2325;&#2375; &#2309;&#2343;&#2367;&#2325;&#2371;&#2340; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2379; &#2344;&#2375;&#2335; &#2357;&#2332;&#2344;........... &#2344;&#2367;&#2350;&#2381;&#2344;&#2366;&#2344;&#2369;&#2360;&#2366;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; &#2361;&#2376;
                                                        :-
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                            Width="100%" EmptyDataText="Record Not Found." >
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex+1 %>.
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <table width="100%">
                                                                            <tr>
                                                                                <td>
                                                                                    &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                                                    <asp:Label ID="lblVouchar_Tr_Id" runat="server" Visible="false" Text='<%#Eval("ChallanNo") %>'></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <%#Eval("PaperVendorName_V")%>
                                                                                </td>
                                                                                <td>
                                                                                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                                                </td>
                                                                                <td>
                                                                                    <%#Eval("ChallanNo")%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                                    <asp:GridView ID="GrdLabInspection" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                                        CssClass="tab" Width="100%" EmptyDataText="Record Not Found." AllowPaging="True">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                                                                <ItemTemplate>
                                                                                                    <%# Container.DataItemIndex+1 %>.
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("PaperType")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("CoverInformation")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="	&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352; ">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("RollNo")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344;">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("NetWt")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344;">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("GrossWt")%>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; ' &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; ' &#2325;&#2368; &#2343;&#2366;&#2352;&#2366;&#2323; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2366;&#2327;&#2332; &#2309;&#2330;&#2381;&#2331;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &#2350;&#2375;&#2306;
                                                        &#2340;&#2341;&#2366; &#2309;&#2306;&#2325;&#2367;&#2340; &#2357;&#2332;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2367;&#2351;&#2366; |
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">

                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="2">

                                                    </td>
                                                    <td colspan="2">
                                                    &#2337;&#2367;&#2346;&#2379; &#2350;&#2376;&#2344;&#2375;&#2332;&#2352;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    &#2309;&#2343;&#2367;&#2325;&#2371;&#2340; / &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; &#2319;&#2357;&#2306; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;

                                                    </td>
                                                    <td colspan="2">
                                                    &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td colspan="2">

                                                    </td>
                                                    <td colspan="2">
                                                   &#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;, &#2352;&#2340;&#2344;&#2346;&#2369;&#2352;
                                                    </td>
                                                </tr>

                                                   <tr>
                                                    <td colspan="2">

                                                    </td>
                                                    <td colspan="2">
                                                &#2349;&#2379;&#2346;&#2366;&#2354;, &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;...........
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td colspan="4">
                                                    </td>
                                                </tr>
                                                
                                                 <tr>
                                                    <td colspan="2">
                                                    &#2360;&#2306;&#2354;&#2327;&#2381;&#2344; :.............................
                                                    </td>
                                                    <td colspan="2">
                                                    &#2337;&#2367;&#2346;&#2379; &#2350;&#2376;&#2344;&#2375;&#2332;&#2352;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                   &#2346;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ............... /&#2346;&#2366;. /&#2346;&#2369;. &#2344;&#2367;. / &#2325;&#2375;. &#2349;. ...........

                                                    </td>
                                                    <td colspan="2">
                                                    &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td colspan="2">
                                                    प्रतिलिपि :
                                                    </td>
                                                    <td colspan="2">
                                                   &#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;, &#2352;&#2340;&#2344;&#2346;&#2369;&#2352;
                                                    </td>
                                                </tr>

                                                   <tr>
                                                    <td colspan="2">
                                                    वरि. प्रबंधक मुद्रण , म. प्र. पाठ्यपुस्तक निगम , भोपाल की ओर सूचनार्थ संप्रेषित |
                                                    </td>
                                                    <td colspan="2">
                                                &#2349;&#2379;&#2346;&#2366;&#2354;, &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;...........
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td colspan="4">
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </center>
                    </div>
                </td>
            </tr>
        </table></div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperCalu.aspx.cs" Inherits="Paper_PaperReport_PaperCalu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Demand Details
    </div>
    <div class="portlet-content">

        <div class="table-responsive">

            <table width="100%">


                <tr>
                    <td colspan="2" align="center">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Value="1">GSM Wise Report</asp:ListItem>
                            <asp:ListItem Value="2">Class Wise Report</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>

                </tr>


                <tr>
                    <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            <asp:ListItem>..Select..</asp:ListItem>

                        </asp:DropDownList>
                    </td>

                    <td>
                        <asp:Label ID="LblClass" runat="server" Visible="false">&#2325;&#2325;&#2381;&#2359;&#2366; / Class:</asp:Label>
                        <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox"
                            AutoPostBack="False" Visible="False">
                        </asp:DropDownList>
                        <br />
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal" Visible="False" AutoPostBack="True">
                            <asp:ListItem Value="1" Selected="True">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; </asp:ListItem>
                            <asp:ListItem Value="2">&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>


                <tr>
                    <td colspan="2">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                            OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>

                </tr>
            </table>

            <table width="100%">

                <tr>
                    <td>
                        <div runat="server" id="ExportDiv" visible="false">



                            <table align="center" width="100%">
                                <tr>
                                    <td style="text-align: center; font-weight: bold; font-family: Verdana; font-size: 18px;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;

                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="text-align: center; font-family: Verdana; font-size: 16px;">
                                        <center>" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344; "</center>

                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="width: 100%; font-weight: bold;">
                                        <div style="text-align: center;">

                                            <h4 class="auto-style1" style="font-size: large">&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2306;&#2325;&#2354;&#2344;
                                            </h4>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="width: 100%; font-weight: bold;">&nbsp;</td>
                                </tr>

                                <tr>

                                    <td> <b runat="server" id="a" style="display:none">   परिवर्तित शीर्षक </b> 
                                        <asp:GridView ID="gvPapCalculation" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="gvPapCalculation_RowDataBound" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / SNo &lt;br&gt;(1)">
                                                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title&lt;br&gt;(2)">
                                                    <ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306; / Total Books  &lt;br&gt; (3)">
                                                    <ItemTemplate> <asp:Label ID="lblNoofpages" runat="server" Text='<%# Eval("TotNoOfBooks")%>'></asp:Label> </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages &lt;br&gt; (4)">

                                                    <ItemTemplate>
                                                        <%# Eval("rate")%>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2342;&#2352; /Rate &lt;br&gt;(5)">
                                                    <ItemTemplate>
                                                       <%# Eval("Noofpages")%>
                                                       
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2350;&#2375;&#2306; .&#2335;&#2344; &#2350;&#2375; ) / Printing Paper (in M.TON) 
                                                        <br />

                                                        (<asp:Label ID="Label1" runat="server" Text=""></asp:Label>)
                                                        <br />
                                                        (6)
                                              
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPriPaper" runat="server" Text='<%# Eval("Qty_PriPaper")%>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField>

                                                    <HeaderTemplate>
                                                        &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2350;&#2375;&#2306; .&#2335;&#2344; &#2350;&#2375; ) / Cover Paper (in M.TON)<br />
                                                        (<asp:Label ID="lbl1" runat="server" Text=""></asp:Label>)<br />
                                                        (7)
                                              
                                                    </HeaderTemplate>

                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCovpaper" runat="server" Text='<%# Eval("Qty_Covpaper")%>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>






                                            </Columns>
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <EditRowStyle CssClass="RowStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                        <br />
                                    <b runat="server" id="a1" style="display:none">   अपरिवर्तित शीर्षक </b> 
                                        <br />
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / SNo &lt;br&gt;(1)">
                                                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title&lt;br&gt;(2)">
                                                    <ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306; / Total Books  &lt;br&gt; (3)">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblNoofpages" runat="server" Text='<%# Eval("TotNoOfBooks")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages &lt;br&gt; (4)">

                                                    <ItemTemplate>
                                                        <%# Eval("rate")%>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2342;&#2352; /Rate &lt;br&gt;(5)">
                                                    <ItemTemplate><%# Eval("Noofpages")%>
                                                       
                                                        
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2350;&#2375;&#2306; .&#2335;&#2344; &#2350;&#2375; ) / Printing Paper (in M.TON) 
                                                        <br />

                                                        (<asp:Label ID="Label1" runat="server" Text=""></asp:Label>)
                                                        <br />
                                                        (6)
                                              
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPriPaper" runat="server" Text='<%# Eval("Qty_PriPaper")%>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField>

                                                    <HeaderTemplate>
                                                        &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2350;&#2375;&#2306; .&#2335;&#2344; &#2350;&#2375; ) / Cover Paper (in M.TON)<br />
                                                        (<asp:Label ID="lbl1" runat="server" Text=""></asp:Label>)<br />
                                                        (7)
                                              
                                                    </HeaderTemplate>

                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCovpaper" runat="server" Text='<%# Eval("Qty_Covpaper")%>'></asp:Label></ItemTemplate>
                                                </asp:TemplateField>






                                            </Columns>
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <EditRowStyle CssClass="RowStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                        <asp:GridView ID="gvPapCalculation0" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="gvPapCalculation0_RowDataBound" ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / SNo &lt;br&gt;(1)">
                                                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2332;&#2368;.&#2319;&#2360;. &#2319;&#2350;. &lt;br&gt; (2)">
                                                    <ItemTemplate><%# Eval("PaperDetailsP")%></ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;br&gt; (3)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPBooks" runat="server" Text=' <%# Eval("TotNoOfBooksP")%>'></asp:Label>
                                                      

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2309;&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &lt;br&gt; (4)">

                                                    <ItemTemplate>
                                                        <asp:Label ID="lblABooks" runat="server" Text=' <%# Eval("TotNoOfBooksA")%>'></asp:Label>
                                                     
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;br&gt; (5)">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblTBooks" runat="server" Text='<%#Convert.ToInt32(Eval("TotNoOfBooksA"))+ Convert.ToInt32(Eval("TotNoOfBooksP"))%>'></asp:Label>
                                                      
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344; &#2350;&#2375;&#2306; )&lt;br&gt; (6)">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblPaperP" runat="server" Text=' <%# Eval("PaperP")%>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>






                                                <asp:TemplateField HeaderText="&#2309;&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344; &#2350;&#2375;&#2306; )&lt;br&gt; (7)">
                                                  <ItemTemplate>
                                                       <asp:Label ID="lblPaperA" runat="server" Text=' <%# Eval("PaperA")%>'></asp:Label>
                                                      </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354;  &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344; &#2350;&#2375;&#2306; )&lt;br&gt; (8)">
                                                   <ItemTemplate>
                                                        <asp:Label ID="lblPaperT" runat="server" Text='<%#Convert.ToInt32(Eval("PaperA"))+Convert.ToInt32(Eval("PaperP"))%>'></asp:Label>
                                                       
                                                   </ItemTemplate>
                                                </asp:TemplateField>






                                            </Columns>
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <EditRowStyle CssClass="RowStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </td>
                </tr>

                <tr>
                    <td>

                        <asp:Button ID="btnExport" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                            CssClass="btn_gry" Visible="false" />
                          <asp:Button ID="btnExport0" runat="server" CssClass="btn_gry" 
                            Text="Export to Excel" OnClick="btnExport_Click1"  />
                    </td>
                </tr>

            </table>


        </div>

    </div>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: left; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>
</asp:Content>


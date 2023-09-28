<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptEstimatedDemandGroup.aspx.cs" Inherits="Distrubution_RptEstimatedDemandGroup" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= DdlClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375;";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375;";
            }
            // alert(document.getElementById('Name').innerHTML);
        }

    </script>
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

    <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2327;&#2381;&#2352;&#2369;&#2346;&#2348;&#2366;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2375; &#2310;&#2306;&#2325;&#2354;&#2344; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;  / Groupwise Report Of Demand Assessment in Textbook
                </span>
            </h2>
        </div>
        <div class="box">

            <table width="100%">

                <tr>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>

                    </td>
                    <td>

                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>

                    <td style="font-size: medium;">
                        <asp:Label ID="LblDepot" runat="server">&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350; <br /> Group Name :</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>

                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblMedium" runat="server" Width="100px">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; <br /> Medium :</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>

                    </td>
                </tr>

                <tr>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblClasses" runat="server" Width="100px">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class  :</asp:Label>

                    </td>
                    <td>

                        <table>
                            <tr>
                                
                                <td style="border: 1px solid  lightgrey" class="auto-style1">

                                    <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>
                                    <input type="checkbox" id="chkSelect" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" />
                                    <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                    <asp:CheckBoxList ID="DdlClass" RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left" runat="server" CssClass="reqirerd">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>

                        </table>

                    </td>

                    <td style="font-size: medium;">
                            &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;
                            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txtbox" >
                            </asp:DropDownList>

                    </td>
                    <td colspan="3">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />

                    </td>
                </tr>

                <tr>
                    <td colspan="6" id="tdPrintContent" runat="server" visible="false">
                        <div style="color: White; float: right;">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print</a>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" runat="server" Height="28px" Text="&#2319;&#2325;&#2381;&#2360;&#2354; &#2350;&#2375;&#2306; &#2342;&#2375;&#2326;&#2375;&#2306; / Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                    </td>

                                </tr>
                            </table>
                        </div>

                        <div class="MT20">
                            <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <div id="ExportDiv" runat="server" width="100%">
                                    <table width="100%" style="font-family: Verdana;">
                                        <tr>
                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 12px; font-weight: 200; text-align: center;">" वितरण (अ) शाखा "
                                            </td>
                                        </tr>

                                        <tr>
                                            <td style="font-size: 13px; font-weight: 200; text-align: left;">शिक्षा सत्र :<asp:Label ID="lblAcYearRpt" runat="server"></asp:Label>
                                            </td>
                                            <td colspan="2" style="font-weight: bold; font-size: 18px; text-align: center;">ग्रुपबार पाठ्यपुस्तक की मांग के आंकलन की रिपोर्ट 

                                            </td>
                                            <td style="font-size: 13px; font-weight: 200; text-align: right;">दिनांक :<asp:Label ID="lblDate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                <asp:Label ID="lblDepoName" runat="server" Font-Bold="true"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true"
                                                    CssClass="tab" EmptyDataText="Record Not Found." Width="100%" OnRowDataBound="GrdBooksMaster_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br /><br /> Sr.No.<div style='padding-top:45px;'>1</div>" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1 %>.
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br /> <br />Book Name <div style='padding-top:45px;'>2</div>" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <%#Eval("TitleHindi_V")%>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                Total :
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; <br /><br />Demand For Scheme</td></tr><tr><td style='padding-top:14px;'>(A)</td></tr><tr><td style='padding-top:7px;'>3</td></tr></table>" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSchemeDemand" runat="server" Text='<%# Eval("SchemeDemand") %>'></asp:Label>

                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFSchemeDemand" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; <br /><br> Demand For General Sell </td></tr><tr><td style='padding-top:14px;'>(B)</td></tr><tr><td  style='padding-top:7px;'>4</td></tr></table> " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOpnMktDemand" runat="server" Text='<%# Eval("OpnMktDemand") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFOpnMktDemand" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2325;&#2369;&#2354; &#2350;&#2366;&#2306;&#2327; <br /><br /> Net Demand </td></tr><tr><td style='padding-top:14px;'>(C=A+B)</td></tr><tr><td  style='padding-top:7px;'>5</td></tr></table> " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalDemand" runat="server" Text='<%# Eval("TotalDemand") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFTotalDemand" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; <br /><br /> Balance Stock For Scheme </td></tr><tr><td style='padding-top:15px;'>(D)</td></tr><tr><td  style='padding-top:7px;'>6</td></tr></table>" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStockYojna" runat="server" Text='<%# Eval("StockYojna") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFStockYojna" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; <br /><br />Balance Stock For Open Sell</td></tr><tr><td style='padding-top:14px;'>(E)</td></tr><tr><td  style='padding-top:7px;'>7</td></tr></table> " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblStockOpenMkt" runat="server" Text='<%# Eval("StockOpenMkt") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFStockOpenMkt" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2325;&#2369;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325;<br /><br /> Total Stock </td></tr><tr><td style='padding-top:14px;'>(F=D+E)</td></tr><tr><td  style='padding-top:7px;'>8</td></tr></table>" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblTotalStock" runat="server" Text='<%# Eval("TotalStock") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFTotalStock" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2344;&#2375;&#2335; &#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;<br /><br /> Net Demand For Scheme</td></tr><tr><td style='padding-top:14px;'>(G=A-D)</td></tr><tr><td  style='padding-top:7px;'>9</td></tr></table>   " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetSchemeDemand" runat="server" Text='<%# Eval("NetSchemeDemand") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFNetSchemeDemand" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2344;&#2375;&#2335; &#2360;&#2366;&#2350;&#2366;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; <br /><br /> Net Demand For Open Sell</td></tr><tr><td style='padding-top:14px;'>(H=B-E)</td></tr><tr><td  style='padding-top:7px;'>10</td></tr></table> " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetOpenMkt" runat="server" Text='<%# Eval("NetOpenMkt") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFNetOpenMkt" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<table><tr><td>&#2325;&#2369;&#2354; &#2344;&#2375;&#2335; &#2350;&#2366;&#2306;&#2327; <br /> Net Demand</td></tr><tr><td style='padding-top:14px;'>(G+H)</td></tr><tr><td  style='padding-top:7px;'>11</td></tr></table> " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNetDemand" runat="server" Text='<%# Eval("NetDemand") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblFNetDemand" runat="server"></asp:Label>
                                                            </FooterTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                    <PagerStyle CssClass="Gvpaging" />
                                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>


                                </div>
                            </asp:Panel>
                        </div>



                    </td>
                </tr>
            </table>
        </div>
        <div style="margin-left: 80px;">
            &nbsp;
        </div>
    </div>

</asp:Content>



<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 184px;
        }
    </style>
</asp:Content>





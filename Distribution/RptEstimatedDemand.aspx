<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptEstimatedDemand.aspx.cs"
    EnableEventValidation="false"
    Inherits="Distrubution_RptEstimatedDemand" %>

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
                <span style="font-size: medium;">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2375; &#2310;&#2306;&#2325;&#2354;&#2344; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Report Of Demand Assessment in Textbook
                </span>
            </h2>
        </div>
        <div class="box">

            <table width="100%">

                <tr>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged1">
                        </asp:DropDownList>
                    </td>

                    <td style="font-size: medium;">
                        <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379;  &#2330;&#2369;&#2344;&#2375;<br />Choose Depot  :</asp:Label>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>
                    </td>
                    <td style="font-size: medium;" valign="top">
                        <asp:Label ID="LblMedium" runat="server">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;<br /> Medium  :</asp:Label>
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td style="font-size: medium;" valign="top">
                        <table>
                            <tr>

                                <td style="border: 1px solid  lightgrey">

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
                    <td style="font-size: medium;" valign="top">
                        &nbsp;</td>
                </tr>

                <tr>



                    <td style="font-size: medium;" valign="top">
                        &nbsp;</td>
                    <td align="right">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search "
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>


                <tr>
                    <td colspan="3" id="tdPrintContent" runat="server" visible="false">
                        <div style="color: White; float: right;">
                            <table>
                                <tr>
                                    <td>
                                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; / Print </a>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnExport" runat="server" Height="28px" Text=" &#2319;&#2325;&#2381;&#2360;&#2354; &#2350;&#2375;&#2306; &#2342;&#2375;&#2326;&#2375; / Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                    </td>

                                </tr>
                            </table>
                        </div>
                        <div style="width: auto; height: auto;">
                            <center>
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <div id="ExportDiv" runat="server">
                                            <div style="width: 100%">
                                                <div style="padding: 10px;">
                                                    <table width="100%">
                                                        <tr>
                                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" वितरण (अ) शाखा "
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td style="font-size: 16px; font-weight: 200; text-align: left;">
                                                                <asp:Label ID="lblAcademicYear" runat="server"></asp:Label>
                                                            </td>
                                                            <td colspan="2" style="font-size: 18px; font-weight: bold; text-align: center; padding-right: 80px;">पाठ्यपुस्तक की मांग के आंकलन की रिपोर्ट
                                                            </td>
                                                            <td style="font-size: 16px; font-weight: 200; text-align: right;">
                                                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                <asp:Label ID="lblTitle" runat="server" Font-Bold="true"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                    CssClass="tab" EmptyDataText="Record Not Found." Width="100%" ShowFooter="true" OnRowDataBound="GrdBooksMaster_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> <br> Sr.No.<br> <br><br> <br><br>1" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex+1 %>.
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br><br> Book Name<br> <br><br> <br><br>2 " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%#Eval("TitleHindi_V")%>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                Total :
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;<br> <br> Demand For Scheme </br> </br>(A)<br> <br>3" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSchemeDemand" runat="server" Text='<%# Eval("SchemeDemand") %>'></asp:Label>

                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFSchemeDemand" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; <br><br> Demand For General Sell </br></br> (B)<br> <br>4" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOpnMktDemand" runat="server" Text='<%# Eval("OpnMktDemand") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFOpnMktDemand" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2350;&#2366;&#2306;&#2327; <br><br> Net Demand </br></br>(C=A+B)<br> <br>5" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTotalDemand" runat="server" Text='<%# Eval("TotalDemand") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFTotalDemand" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325;<br><br> Balance Stock For Scheme </br> </br>(D)<br> <br>6" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStockYojna" runat="server" Text='<%# Eval("StockYojna") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFStockYojna" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; <br><br> Balance Stock For Open Sell </br></br> (E)<br> <br>7" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStockOpenMkt" runat="server" Text='<%# Eval("StockOpenMkt") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFStockOpenMkt" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325;<br> <br> Total Stock </br></br> (F=D+E)<br> <br>8" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTotalStock" runat="server" Text='<%# Eval("TotalStock") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFTotalStock" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;<br><br> Net Demand For Scheme</br></br>(G=A-D)<br> <br>9" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNetSchemeDemand" runat="server" Text='<%# Eval("NetSchemeDemand") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFNetSchemeDemand" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2360;&#2366;&#2350;&#2366;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; <br><br> Net Demand For Open Sell </br> </br>(H=B-E)<br> <br>10" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNetOpenMkt" runat="server" Text='<%# Eval("NetOpenMkt") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblFNetOpenMkt" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2344;&#2375;&#2335; &#2350;&#2366;&#2306;&#2327; <br> Net Demand </br></br> (G+H)<br> <br>11" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
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
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </center>
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


<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="RPTDefectiveReelStsChange.aspx.cs" Inherits="ViewDefectiveReelStsChange"
    Title="कटी हुई बंडल / रील की जानकारी / Information Of Defective Reel / Bundel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
        }

    </script>

    <div class="portlet-header ui-widget-header">
        &#2325;&#2335;&#2368; &#2361;&#2369;&#2312; &#2348;&#2306;&#2337;&#2354; / &#2352;&#2368;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Defective Reel / Bundel
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table>
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
                        <td>
                            <asp:DropDownList ID="ddlAcYear" placeholder="Select" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354;</td>
                        <td>
                            <asp:DropDownList ID="ddlVendorName" placeholder="Select" runat="server" OnInit="ddlVendorName_Init"></asp:DropDownList></td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;</td>
                        <td>
                            <asp:DropDownList ID="ddlPaperType" placeholder="Select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged">
                            </asp:DropDownList></td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;</td>
                        <td>
                            <asp:DropDownList ID="ddlPaperSize" placeholder="Select" runat="server" OnInit="ddlPaperSize_Init1">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;.</td>
                        <td>
                            <asp:TextBox ID="txtChallanNo" placeholder="Enter Challan No." runat="server"></asp:TextBox>

                        </td>
                        <td>&#2352;&#2379;&#2354; &#2344;.</td>
                        <td>
                            <asp:TextBox ID="txtRollNo" placeholder="Enter Roll No." runat="server"></asp:TextBox></td>
                        <td></td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn"   Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />

                        </td>
                        <td></td>
                        <td></td>
                    </tr>

                </table>
                <asp:Panel ID="Panel1" Visible="false" runat="server">
                    <asp:Button ID="btnExport" runat="server" CssClass="btn"   Text="Export to Excel" OnClick="btnExport_Click" />
                    <asp:Button ID="btnPrint" runat="server" CssClass="btn"   Text="Print" OnClientClick="return PrintPanel();" />

                    <div id="ExportDiv" runat="server">

                        <div style="padding: 10px;">
                            <table width="100%">
                                <tr>
                                    <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" &#2325;&#2375;&#2306;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352;"
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">कटी हुई बंडल / रील की जानकारी
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: left">&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;:
                                            <asp:Label ID="lblYr" runat="server" Text="Label"></asp:Label></td>
                                    <td colspan="2" style="float:right;"><asp:Label ID="lblDate" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="False" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." PageSize="20"
                                 AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound" ShowFooter="True" FooterStyle-BackColor="WhiteSmoke">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br>Name Of Paper Mill " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                            <asp:Label ID="lblid" runat="server" Text='<%#Eval("Id")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPaperCategory" runat="server" Text='<%#Eval("PaperCategory")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="इनवॉइस क्रमांक &lt;br&gt;Invoice No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <%#Eval("ChallanNo")%>
                                        </ItemTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Paper Type" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <%#Eval("PaperType")%>
                                        </ItemTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" रील नंबर&lt;br&gt; Reel No." HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblCaption" Text="&#2325;&#2369;&#2354;" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2346;&#2381;&#2352;&#2340;&#2367; &#2352;&#2368;&#2350;/&#2352;&#2368;&#2354; <br> Total Sheets Per Reem / Reel" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                            <asp:TextBox ID="txtTotalSheets" runat="server" Text='<%#Eval("TotalSheets") %>' Visible="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblTtllSheets" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.) <br>Net Weight(K.G.)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreNetWt" runat="server" Text='<%#Eval("PreNetWt") %>'></asp:Label>
                                            <asp:TextBox ID="txtPreNetWt" runat="server" Text='<%#Eval("PreNetWt") %>' Visible="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblTtlPreNet" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br> Gross Weight(K.G.)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPreGrossWt" runat="server" Text='<%#Eval("GrossPreNetwt") %>'></asp:Label>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblTtlPreGrossWt" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText=" &#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2344;&#2375;&#2335; &#2357;&#2375;&#2335; (K.G.) <br>Net Weight(K.G.)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt") %>'></asp:Label>
                                            <asp:TextBox ID="txtNetWt" runat="server" Text='<%#Eval("NetWt") %>' Visible="false" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                         <FooterTemplate>
                                            <asp:Label ID="lblTtlNetWt" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2375;&#2335; (K.G.)<br>Updated Gross Weight(K.G.)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt") %>'></asp:Label>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTtlGrossWt" runat="server"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                        <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    </asp:TemplateField>

                                </Columns>

                                <FooterStyle BackColor="WhiteSmoke" />

                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </div>

                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

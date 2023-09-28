<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="StockDtlWithPprVnd.aspx.cs" Inherits="StockDtlWithPprVnd"
    Title=" पेपर मिल वार स्टॉक की मात्रा / Paper Mill Wise Stock Quantity " %>

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
        }</script>
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                //img.src = "../images/d_arrow.jpg";
            } else {
                div.style.display = "none";
              //  img.src = "../images/d_arrow.jpg";
            }
        }

    </script>
    <div class="portlet-header ui-widget-header">
        पेपर मिल वार स्टॉक की मात्रा / Paper Mill Wise Stock Quantity 
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td>शैक्षणिक सत्र<br />
                                        Academic Year
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlYear" Width="250px" CssClass="txtbox reqirerd" OnInit="ddlYear_Init">
                                            <asp:ListItem Text="Select"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>पेपर मिल का नाम<br />
                                        Name Of Paper Mill
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                                            CssClass="txtbox reqirerd">
                                            <asp:ListItem Text="All"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>पेपर का प्रकार<br />
                                        Paper Type
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlPaperType" Width="250px" CssClass="txtbox" AutoPostBack="true"
                                            OnInit="ddlPaperType_Init" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged">
                                            <asp:ListItem Text="All"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>पेपर का आकार <br /> Paper Size</td>
                                    <td>  <asp:DropDownList runat="server" ID="ddlPaperSize" Width="250px" CssClass="txtbox"
                                            OnInit="ddlPaperSize_Init">
                                            <asp:ListItem Text="All"></asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 40px; color: White;">
                                <table>
                                    <tr>
                                        <td>
                                            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">प्रिंट</a>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </td>

                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <div id="ExportDiv" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" केंद्रीय भण्डार "
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">पेपर मिल वार स्टॉक की मात्रा 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%;">
                                                <div style="float: right; padding-right: 20px;">
                                                    शैक्षणिक सत्र :<asp:Label ID="lblYear" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                            <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: center; width: 50%;"></td>
                                            <td style="font-size: 16px; font-weight: 200; text-align: center; width: 25%;">
                                                <div style="float: right; padding-right: 20px;">
                                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 16px; text-align: center;">
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 12px; text-align: right;">यूनिट मेट्रिक टन में / Unit in Matric Ton
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    Width="100%" EmptyDataText="Record Not Found."
                                                    AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                                    OnRowDataBound="GrdLOI_RowDataBound">
                                                    <Columns>
                                                         
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                                 <table width="100%">
                                                                    <tr>
                                                                         <td width="14.28%" style="padding-bottom: 10px;">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo
                                                                          
                                                                            </td>
                                                                        <td width="14.28%" style="padding-bottom: 10px;">पेपर का प्रकार
                                                                            <br />
                                                                            Paper Type</td>
                                                                        <td width="14.28%" style="padding-bottom: 10px;">पेपर का आकार (प्रकार)
                                                                            <br />
                                                                            Paper Size (Type)</td>
                                                              
                                                                        <td width="14.28%" style="padding-bottom: 10px;">पेपर की कुल मात्रा
                                                                            <br />
                                                                            Total Quantity Of Paper  </td>
                                                                         

                                                                        <td width="14.28%" style="padding-bottom: 10px;">प्रदाय की कुल मात्रा
                                                                            <br />
                                                                            Total Supplied Quantity </td>
                                                                        
                                                                        <td width="14.28%" style="padding-bottom: 10px;">पेपर की शेष मात्रा 
                                                                            <br />
                                                                            Remaining Quatity  Of Paper </td>
                                                                      
                                                                        <td width="14.28%" style="padding-bottom: 10px;"> 
                                                                            
                                                                        
                                                                        </td>
                                                                    </tr>
                                                                     </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                                                <table width="100%">
                                                                    <tr>
                                                                         <td width="14.28%" style="padding-bottom: 10px;"> 
                                                                          
                                                                           <%# Container.DataItemIndex+1 %>.</td>
                                                                          <td width="14.28%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("PaperType")%></td>
                                                                        <td width="14.28%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("CoverInformation")%> </td>
                                                                        
                                                                        <td width="14.28%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("TotQty")%></td>

                                                                         
                                                                        <td width="14.28%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("TotDebitQty")%></td>
                                                                        
                                                                        <td width="14.28%" style="padding-bottom: 10px; font-weight: bold;"><%#Eval("RemainingQty")%></td>
                                                                        <td width="14.28%" style="padding-bottom: 10px;"><a id="imgdiv<%# Eval("PaperMstrTrId_I") %>" href="JavaScript:divexpandcollapse('div<%# Eval("PaperMstrTrId_I") %>');" style="color: red;">View Details
                                                                            
                                                                        </a>
                                                                        </td>
                                                                    </tr>
                        
                                                                    <tr>
                                                                        <td colspan="7" rowspan="2">
                                                                            <div id="div<%# Eval("PaperMstrTrId_I") %>" style="display: none; position: relative; left: 15px; overflow: auto">
                                                                                <asp:GridView ID="GvReelDetails" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                                                    CssClass="tab" Width="100%" EmptyDataText="Record Not Found." OnRowDataBound="GvReelDetails_RowDataBound"
                                                                                    AllowPaging="false" ShowFooter="true">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex+1 %>.
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="पेपर मिल का नाम<br /> Name Of Paper Mill" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblPaperVendorName_V" runat="server" Text='<%#Eval("PaperVendorName_V")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                कुल / Total : 
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="पेपर की कुल मात्रा <br>Total Quantity Of Paper" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTotQty" runat="server" Text='<%#Eval("TotQty")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblFTotQty" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="प्रदाय की कुल मात्रा  <br>Total Supplied Quantity" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTotDebitQty" runat="server" Text='<%#Eval("TotDebitQty") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblFTotDebitQty" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="पेपर की शेष मात्रा  <br> Remaining Quatity  Of Paper" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRemainingQty" runat="server" Text='<%#Eval("RemainingQty") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:Label ID="lblFRemainingQty" runat="server"></asp:Label>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>

                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>

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
                            </asp:Panel>

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

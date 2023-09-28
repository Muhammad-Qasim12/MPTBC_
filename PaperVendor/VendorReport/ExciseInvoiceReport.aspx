<%@ Page Title="Excise Invoice" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ExciseInvoiceReport.aspx.cs" Inherits="Paper_PaperReport_LOIReport" %>
 
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<style> @font-face {src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");font-family: Free3of9Regular;font-weight: normal;font-style: normal;}');
            printWindow.document.write('.BarCode { font-family: Free3of9Regular; font-size: 90px; padding: 10px; line-height: 80px; }</style>');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<link href="style.css" rel="stylesheet" type="text/css" />');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>
     <style>
        @font-face {
            font-family: "Free3of9Regular";
            src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");
            font-weight: normal;
            font-style: normal;
        }

        .BarCode {
            font-family: Free3of9Regular; font-size: 60px; padding: 10px; line-height: 80px;
        }

        @media print {
            .page-break {
                display: block;
                page-break-before: always;
                padding-top: 40px;
                height: 802px;
                margin: 50px auto;
                text-align: center;
                font: normal 12px arial;
                line-height: 16px;
            }
        }

        .floatleft {
            float: left;
            width: 50%;
            text-align: center;
            margin-top: 120px;
        }

        .page-break ul {
            margin: 0;
            padding: 0;
        }

            .page-break ul li {
                float: left;
                width: 50%;
                text-align: center;
                list-style: none;
                height: 300px;
            }

        .cleardiv {
            clear: both;
            margin-top: 120px;
        }
    </style>
    <div class="portlet-header ui-widget-header">
        Excise Invoice</div>
    <div class="portlet-content">
        <div class="portlet-content">
         <div class="table-responsive">   <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        Invoice No
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlChallanNo" Width="250px" CssClass="txtbox reqirerd"
                            OnInit="ddlChallanNo_Init">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                            OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
              
                <tr>
                    <td colspan="3" id="tdPrintContent" runat="server" visible="false">
                          <div  style="width:40px;color:White;">
                <table>
                <tr>
                <td>
                 <a href="#" class="btn" style="color:White;" onclick="return PrintPanel();">प्रिंट</a>
                </td>
                <td>
                 <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                </td>
                
                </tr>
                </table>             
                </div>
                        <div style="width: auto; height: auto;">
                            <center>
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
                                    <div id="ExportDiv" runat="server">
                                        <div style="width: 900px;">
                                            <div style="padding: 10px;">
                                                <table width="100%" >
                                                    <tr>
                                                        <td style="font-size: 18px; font-weight: bold; text-align: center;">
                                                            <asp:Label ID="lblPaperMillName" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; font-weight: 200; text-align: center;">
                                                            EXCISE INVOICE
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; font-weight: 700; text-align: center;">
                                                            Retail Invoice
                                                            <br />
                                                            <span class="BarCode"><%=chalanID%></asp:Label></span> 
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td style="text-align: left;">
                                                            
                                                            <div style="float: left; width: 100%;">
                                                                <table style="font-size: 14px;font-family: arial sans-serif;" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                           Pan No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblPanNo" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            Tin No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblTinNo" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Tan No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblTanNo" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: left;">
                                                            <div style="float: left; width: 100%;">
                                                                <table style="font-size: 14px;font-family:Arial;" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            Invoice No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            Invoice Date :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Challan No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblChallanNo" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            Challan Date :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblChallanDate" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            GR No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrNo" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            GR Date :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrDate" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Vehicle No :
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblVehicleNo" runat="server"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 12px;font-family:Arial; font-weight: 200; text-align: center;">
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="false" CssClass="tab" ShowFooter="true"
                                                                AutoGenerateColumns="false" EmptyDataText="Record Not Found." GridLines="None"
                                                                OnRowDataBound="GridView1_RowDataBound" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="SrNo" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate >
                                                                            <%# Container.DataItemIndex+1 %>.
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description of Goods" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"    ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"   HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate >
                                                                            <%# Eval("CoverInformation")%>
                                                                        </ItemTemplate>
                                                                            <FooterTemplate  >
                                                                            Total :
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No Of Packages" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"   ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"    HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblSndrReel" runat="server" Text='<%# Eval("SndrReel")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblFSndrReel" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total Qty (Kgs)" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"   HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("VdrSendQty")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblFQty" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Rate / MT" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"   HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRate" runat="server" Text='<%# Eval("BidRate_N")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"   HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblAmount" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblFAmount" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="float: right;">
                                                            <div style="float: right;">
                                                                <table  style="font-size: 14px;font-family:Arial;">
                                                                    <tr>
                                                                        <td>
                                                                            Excise Duty @ 6.00 %
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblExciesDuty" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Cess On Paper @ 0.125 %
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCessOnPaper" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Education Cess @ 2.00 %
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblEduc" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            S & H. Edu. Cess @ 1.00 %
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblSHEdu" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            Sub Total
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblSubTotal" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td>
                                                                          CST @ 2 %
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCST" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                        <td>
                                                                            Insurance 0.15 %
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblInsurance" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                      <tr>
                                                                        <td>
                                                                            Grand Total
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div></div>
                                    </asp:Panel>
                                    </div>
                            </center>
                        </div>
                    </td>
                </tr>
            </table></div>
        </div>
</asp:Content>

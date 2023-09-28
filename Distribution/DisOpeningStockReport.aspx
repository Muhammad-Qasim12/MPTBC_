<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisOpeningStockReport.aspx.cs"
     Inherits="Distribution_DisOpeningStockReport" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="card-header">
        <h2>&#2323;&#2346;&#2344;&#2367;&#2306;&#2327; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Opening Stock Report</h2>
    </div>
    <div style="padding: 0 10px;">
        <asp:HiddenField ID="hdnId" runat="server" />

        <table class="auto-style1" width="100%">
            <tr>
                <td>डिपो का नाम (Depo)</td>
                <td>
                    <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox ">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                <td>
                    <asp:DropDownList ID="ddlTital0" runat="server" CssClass="txtbox">
                        <asp:ListItem Value="3">All</asp:ListItem>
                        <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</asp:ListItem>
                        <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366;</asp:ListItem>
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;                             
                </td>
                <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox"></asp:DropDownList>
                </td>


            </tr>
            <tr>
                <td>&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                <td>
                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                        <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                        <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                    </asp:DropDownList>
                </td>


            </tr>
            <tr>
                <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            </td>
                <td>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                </td>


            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " OnClientClick="return ValidateAllTextForm();"  /></td>
                <td>&nbsp;</td>


            </tr>
            <tr>
                <td colspan="2">
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
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
                                    <td colspan="2" style="font-weight: bold; font-size: 18px; text-align: center;">ओपनिंग स्टॉक की रिपोर्ट

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
                                      <asp:GridView ID="GridView1" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                            <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtYojna" runat="server" CssClass="txtbox" Width="100px" Text='<%# Eval("YojanaBook") %>' Enabled='<%# Eval("status").ToString()=="1" ? false  : true %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; ">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitleID_I")%>' />
                                    <asp:TextBox ID="txtSamany" runat="server" CssClass="txtbox" Width="100px" Text='<%# Eval("samanyBook") %>' Enabled='<%# Eval("status").ToString()=="1" ? false  : true %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                                    </td>
                                </tr>
                            </table>


                        </div>
                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                   </td>
            </tr>
        </table>
        <script type="text/javascript">
            function PrintPanel() {
                var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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
        <br />
        <br />

    </div>
</asp:Content>


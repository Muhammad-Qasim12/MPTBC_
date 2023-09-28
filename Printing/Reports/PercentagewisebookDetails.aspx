<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PercentagewisebookDetails.aspx.cs" Inherits="Printing_PercentagewisebookDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="card-header">
        <h2>&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;&#2357;&#2352; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
    </div>
    <div class="box table-responsive">
        <table width="100%">
            <tr>
                <td class="auto-style1" style="text-align: center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td class="auto-style1" style="text-align: center">
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1" style="text-align: center">&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; %</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Width="140px" Text="0"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="5" style="text-align: center">
                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel();" Text="Export to PDF" Visible="false" />
                    <br />
                    <div id="ExportDiv" runat="server">
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                        <br />
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352;.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="mediunnameenglish_v" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;" />
                                <asp:BoundField DataField="Class" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; " />
                                <asp:BoundField DataField="Subject" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="BalCap" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;" />
                            </Columns>
                            <EmptyDataTemplate>
                                Data Not FoundData Not Found
    
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                    <br />
                </td>
            </tr>
        </table>
    </div>
    <script type = "text/javascript">
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

</asp:Content>


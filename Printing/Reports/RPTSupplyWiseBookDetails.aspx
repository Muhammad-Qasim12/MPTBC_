<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPTSupplyWiseBookDetails.aspx.cs" Inherits="Printing_RPTSupplyWiseBookDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="card-header">
        <h2>आवंटन से ज्यादा पुस्तकों की जानकारी </h2>
    </div>
    <div class="box table-responsive">
        <table width="100%">
            <tr>
                <td class="auto-style1" style="text-align: center">माध्यम </td>
                <td class="auto-style1" style="text-align: center">
                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td class="auto-style1" style="text-align: center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                    </asp:DropDownList>
                </td>
                <td>
                        &#2325;&#2325;&#2381;&#2359;&#2366;</td>
                <td>
                        <asp:DropDownList ID="ddlClassName" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="7" style="text-align: center">
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
<asp:BoundField DataField="Deponame" HeaderText="डिपो का नाम "></asp:BoundField>
                                <asp:BoundField DataField="Subject" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="mediunnameenglish_v" HeaderText="माध्यम " />
                                <asp:BoundField DataField="Class" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; " />
                                <asp:BoundField DataField="Allot" HeaderText="आवंटन " />
<asp:BoundField DataField="receipt" HeaderText="प्राप्ति"></asp:BoundField>
                                <asp:BoundField DataField="excess" HeaderText="अतिरिक्त पुस्तको की संख्या " />
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

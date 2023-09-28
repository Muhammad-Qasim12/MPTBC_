<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoWiseTruckDetails.aspx.cs" Inherits="Depo_DepoWiseTruckDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="box">
        <div class="card-header">
            <h2>&#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
        </div>
        <table style="width: 100%">
                <tr>
                    <td style="font-size: medium;">
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" /> <br />
                         <br /> <asp:Button CssClass="btn" runat="server" Text="डाटा एक्सेल में लें |" ID="btnExport" OnClick="btnExport_Click" />
                        <div id="ExportDiv" runat="server">
                           
        </div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                                 <ItemTemplate>
                                              <asp:Literal ID="ltrLeader" runat="server" OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>

       <asp:TemplateField HeaderText="&#2332;&#2367;&#2354;&#2366;  &#2325;&#2366; &#2344;&#2366;&#2350;">
                                                 <ItemTemplate>
                                              <asp:Literal ID="ltrLeader1" runat="server" OnDataBinding="ltrLeader1_DataBinding"></asp:Literal>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                
                               
                                <asp:BoundField HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="BlockNameHindi_V" />
                                <asp:BoundField HeaderText="माध्यम" DataField="MediunNameHindi_V" />
                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344;  &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; " DataField="ChallanNo_V" />
                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="ChallanDate_D" />
                                <asp:BoundField HeaderText="प्राप्तकर्ता का नाम " DataField="ReceiverName_V" />
                                 <asp:BoundField HeaderText="&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; " DataField="TruckNo_V" />
                                <asp:BoundField HeaderText="प्रदाय पुस्तक की संख्या " DataField="DestributeBook" />
                            </Columns>
                        </asp:GridView>
                            </div>
                    </td>
                </tr></table> 

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


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowDetails1.aspx.cs" Inherits="Depo_ShowDetails1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
            <h2>
                <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/ Challan Details </span></h2>
        </div>
   <div id="ExportDiv" runat="server" >
     <table width="100%">
                <tr>
                    <td><asp:Button ID="btnPrint" runat="server" CssClass="btn" OnClientClick="return PrintPanel()" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;" Width="150" />
                   
                              <br />
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CssClass="tab" >
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                 
                                    <asp:BoundField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="District_Name_Hindi_V" />
                                 
                                    <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                 
                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                        <ItemTemplate>

                                             <%#Eval("ChallanNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ChallanDate_D" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                     <asp:BoundField DataField="ReceiverName_V" HeaderText="प्राप्तकर्ता का नाम  " />
                                    <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                   
                                   
                                </Columns>
                                 <PagerStyle CssClass="Gvpaging" />
                                           <EmptyDataRowStyle CssClass="GvEmptyText" />
                                 <EmptyDataTemplate>
                                     Data Not Found ............
                                 </EmptyDataTemplate>
                            </asp:GridView>
                           </td>
                </tr></table> </div>
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
</asp:Content>


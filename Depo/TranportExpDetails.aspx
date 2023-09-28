<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TranportExpDetails.aspx.cs" Inherits="Depo_TranportExpDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
        <div class="card-header">
            <h2>
                &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2375; &#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; (&#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;)</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">

            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            &#2348;&#2367;&#2354;&nbsp; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;


                        </td>

                        <td colspan="3">
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
                                <asp:ListItem Value="1" Selected="True">&#2351;&#2379;&#2332;&#2344;&#2366; </asp:ListItem>
                                <asp:ListItem Value="2">&#2309;&#2306;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; </asp:ListItem>
                                <asp:ListItem Value="3">&#2358;&#2367;&#2347;&#2367;&#2306;&#2327; &#2348;&#2367;&#2354; </asp:ListItem>
                                <asp:ListItem Value="4">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2348;&#2367;&#2354; </asp:ListItem>
                            </asp:RadioButtonList>


                        </td>


                    </tr>
                    <tr id="Ar" runat="server" visible="false"  >
                        <td>
                            &#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;


                            </td>
                         <td> <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>  </td> 
                        <td>
                            &#2348;&#2381;&#2354;&#2366;&#2325; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352;</td>

                        <td style="font-size: medium;" valign="top">
                            <asp:DropDownList ID="ddlBlock" runat="server" CssClass="txtbox">
                            </asp:DropDownList>

                        </td>


                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; </asp:Label>


                        </td>

                        <td>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                        </td>

                        <td>
                            &nbsp;</td>

                        <td style="font-size: medium;" valign="top">
                            <%--   <asp:Label ID="LblDistrict" runat="server" Width="100px">&#2332;&#2367;&#2354;&#2366;  :</asp:Label>
                        <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox"  Enabled ="false">
                        </asp:DropDownList >--%>

                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />

                        </td>


                    </tr>
                    <tr>
                        <td colspan="4">  <asp:Button ID="btnExport" runat="server" CssClass="btn" 
                                OnClick="btnExport_Click" Text="Export to Excel"   />
                            
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print" />
                            <div id="ExportDiv" runat="server" >
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:BoundField DataField="BlockName_V" HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:TemplateField HeaderText="चालान नंबर ">
                                                 <ItemTemplate>
                                                     <a href="TranspoterBill.aspx?ID=<%# Eval("ChallanNo_V") %>" target="_blank" ><%#Eval("ChallanNo_V") %></a>
   </ItemTemplate>
                                             </asp:TemplateField>

                              
                                    <asp:BoundField DataField="ChallanDate_D" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                    <asp:BoundField DataField="GRNO_V" HeaderText="बिल्टी  नंबर " />
                                    <asp:BoundField DataField="TruckNo_V" HeaderText="ट्रक नंबर " />
                                    <asp:BoundField DataField="ReceiverName_V" HeaderText="प्राप्तकर्ता " />
                                    <asp:BoundField DataField="PaikBandal" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; " />
                                    <asp:BoundField DataField="LoojBandal" HeaderText="&#2325;&#2369;&#2354; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; " />
                                    <asp:BoundField DataField="DestributeBook" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; " />
                                    <asp:BoundField DataField="TotalTan" HeaderText="&#2335;&#2344; " />
                                    <asp:BoundField DataField="a" HeaderText="&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367; " />
                                </Columns>
                            </asp:GridView></div>


                        </td>


                    </tr></table> </div> </div> </div> 

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


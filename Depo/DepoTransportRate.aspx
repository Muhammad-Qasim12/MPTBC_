<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoTransportRate.aspx.cs" Inherits="Depo_DepoTransportRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2><span>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transporter Details</span></h2>
        </div>
        <div style="padding:0 10px;">
            <div>
            </div>
            <table  runat="server"  width="100%">
                <tr>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="ddlDepo" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LblAcYear" Width="144px" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/ Year :</asp:Label>
                        <asp:DropDownList ID="DdlACYear" Width="100px" AutoPostBack="true" runat="server" CssClass="txtbox reqirerd" >
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" onclick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                            <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                                OnClientClick="return PrintPanel();" Text="Export to PDF & Print"  />
                    </td>
                </tr>
            </table>
            <div id="ExportDiv" runat="server">
            <table width="100%" id="asa" runat="server" visible="false" >
                                <tr>
                                    <td align="center" >  &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2349;&#2379;&#2346;&#2366;&#2354; <br />
        <br />
                                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;&nbsp; <asp:Label ID="Label1" runat="server"></asp:Label>
&nbsp; &#2325;&#2375; &#2354;&#2367;&#2319; <asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2325;&#2366;&#2352;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2360;&#2381;&#2357;&#2368;&#2325;&#2371;&#2340;&#2367; &#2342;&#2352;&#2375;&#2306; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306; ) &#2361;&#2376;&#2306; !<br /> </td>
                                </tr>
                                <tr>
                                    <td align="center" >  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; :<asp:Label ID="Label3" runat="server"></asp:Label>
&nbsp;&nbsp; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;: <asp:Label ID="Label4" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" >  
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" >
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="&#2332;&#2367;&#2354;&#2375; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                            <ItemTemplate>
                                                <asp:Literal ID="ltrLeader" runat="server" OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NAME" HeaderText="&#2327;&#2306;&#2340;&#2357;&#2381;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                        <asp:BoundField DataField="FullTruckRate_N" HeaderText="&#2342;&#2352;&#2375;&#2306; &#2346;&#2381;&#2352;&#2340;&#2367;&#2335;&#2344; (&#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; 9 &#2335;&#2344; &#2351;&#2366; &#2313;&#2360;&#2360;&#2375; &#2309;&#2343;&#2367;&#2325; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; &#2325;&#2375; &#2335;&#2381;&#2352;&#2325; &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2357;&#2366;&#2361;&#2344; &#2360;&#2375; &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2361;&#2375;&#2340;&#2369; )" />
                        <asp:BoundField DataField="HalfTruckRate_N" HeaderText="&#2342;&#2352;&#2375;&#2306; &#2346;&#2381;&#2352;&#2340;&#2367;&#2335;&#2344; (&#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; 4.50 &#2335;&#2344; &#2351;&#2366; &#2313;&#2360;&#2360;&#2375; &#2309;&#2343;&#2367;&#2325; &#2325;&#2381;&#2359;&#2350;&#2340;&#2366; &#2325;&#2375; &#2335;&#2381;&#2352;&#2325; &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2357;&#2366;&#2361;&#2344; &#2360;&#2375; &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2361;&#2375;&#2340;&#2369; )" />
                        <asp:BoundField DataField="RatePerBundle_N" HeaderText="&#2342;&#2352; &#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2324;&#2360;&#2340; &#2410;&#2406; &#2325;&#2367;. &#2327;&#2381;&#2352;&#2366;. &#2325;&#2375; &#2348;&#2306;&#2337;&#2354; &#2361;&#2375;&#2340;&#2369; " />
                        <asp:BoundField DataField="TransportName_V" HeaderText="&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                    </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>

                                    </td>
                                </tr></table> </div>
        </div>
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


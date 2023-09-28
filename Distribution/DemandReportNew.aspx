<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DemandReportNew.aspx.cs" Inherits="Distribution_DemandReportNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <asp:Button ID="Button3" runat="server" CssClass="btn" Text="Print" OnClientClick="return PrintPanel();"  />
        <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2325;&#2366; &#2310;&#2306;&#2325;&#2354;&#2344; 
                    /Textbook Demand Estimation 
                        </span>
                    </h2>
                </div>
                <div class="portlet-content">
                    <asp:Panel ID="Panel1" runat="server">
                    <div class="table-responsive">
                        
                        <table width="100%">

                            <tr>
                                <td style="font-size: medium;" valign="top" align="center"  colspan="3">
                                    <span style="font-size: medium; text-align: center;">
                                    <asp:Label ID="lblMideum" runat="server"></asp:Label>
                                    &nbsp;&#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2325;&#2366; &#2310;&#2306;&#2325;&#2354;&#2344; (&#2325;&#2325;&#2381;&#2359;&#2366;
                                    <asp:Label ID="lblClass" runat="server"></asp:Label>
                                    ) </span>
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 30%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" Height="23px" Width="81px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; </asp:Label>
                                    <asp:Label ID="lblYear" runat="server"></asp:Label>
                                </td>
                                <td style="width: 40%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblDemandType" runat="server" Width="124px">&#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;</asp:Label>
                                    <asp:Label ID="lblDemand" runat="server"></asp:Label>
                                </td>
                                <td style="font-size: medium;">
                                    <asp:Label ID="LblDepot" runat="server" Width="58px">&#2337;&#2367;&#2346;&#2379;</asp:Label>
                                    <asp:Label ID="lblDepoName" runat="server"></asp:Label>
                                </td>
                            </tr>

                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="3">
                                    &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2325;&#2366;
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                    &nbsp; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; </td>
                            </tr>

                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="3">
                                      <div id="ExportDiv" runat="server">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound" ShowFooter="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                            <ItemTemplate> 
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("TitleHindi_V") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;"> 
                                                <ItemTemplate>
                                                     <asp:Label ID="txt001" runat="server" Text=' <%# Eval("SchemeOrDemand") %>'></asp:Label>
                                                </ItemTemplate></asp:TemplateField>
                                           
                                             <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;"><ItemTemplate>
                                                <asp:Label ID="lbl22" runat="server" Text=' <%# Eval("GernalExtrDemand") %>'></asp:Label>
                                               </ItemTemplate></asp:TemplateField>

                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2325;&#2368; &#2346;&#2370;&#2352;&#2381;&#2340;&#2367; &#2351;&#2379;&#2332;&#2344;&#2366;"> 
                                                <ItemTemplate>
                                                     <asp:Label ID="lbl1" runat="server" Text=' <%# Eval("Demand_Scheme") %>'></asp:Label>
                                                </ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2325;&#2368; &#2346;&#2370;&#2352;&#2381;&#2340;&#2367; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;"><ItemTemplate>
                                                <asp:Label ID="lbl2" runat="server" Text=' <%# Eval("OpenMtkDemand") %>'></asp:Label>
                                               </ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2350;&#2366;&#2306;&#2327;"><ItemTemplate> 
                                                <asp:Label ID="lbl3" runat="server" Text=' <%# Eval("TotalDemand") %>'></asp:Label>
                                               </ItemTemplate> </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; ">
                                                <ItemTemplate> 
                                                    <asp:Label ID="lbl4" runat="server" Text=' <%# Eval("YojnaStock") %>'></asp:Label>
                                                </ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325; "><ItemTemplate>
                                                  <asp:Label ID="lbl5" runat="server" Text=' <%# Eval("OpenMktStock") %>'></asp:Label> </ItemTemplate></asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325; "><ItemTemplate> 
                                                <asp:Label ID="lbl6" runat="server" Text=' <%# Eval("TotalStock") %>'></asp:Label>
                                               </ItemTemplate> </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366;)">
                                                <ItemTemplate>
                                                     <asp:Label ID="lbl7" runat="server" Text='<%#(Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))  : 0 %>'></asp:Label>
                                                   </ItemTemplate>


                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)">
                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lbl8" runat="server" Text='<%#(Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))  : 0 %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;">
                                                <ItemTemplate>
                                                     <asp:Label ID="lbl9" runat="server" Text=' <%#((Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))  : 0)+((Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))  : 0) %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2360;&#2375; &#2309;&#2343;&#2367;&#2325; (&#2351;&#2379;&#2332;&#2344;&#2366;)">
                                                <ItemTemplate>
                                                      <asp:Label ID="lbl10" runat="server" Text=' <%#(Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))< 0 ? (Convert.ToInt32(Eval("YojnaStock"))-Convert.ToInt32(Eval("NetDemandYojna")))  : 0 %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2360;&#2375; &#2309;&#2343;&#2367;&#2325; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;) ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl11" runat="server" Text=' <%#(Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))< 0 ? (Convert.ToInt32(Eval("OpenMktStock"))-Convert.ToInt32(Eval("NetDemandOpnMkt")))  : 0 %>'></asp:Label>
                                                   </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView></div> 
                                </td>
                            </tr></table> </div> </asp:Panel></div>


    </div> 
                     <script type = "text/javascript">
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
</asp:Content>


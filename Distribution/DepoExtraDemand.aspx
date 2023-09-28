<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoExtraDemand.aspx.cs" Inherits="Distribution_DepoExtraDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2310;&#2357;&#2358;&#2381;&#2325;&#2340;&#2366; &#2360;&#2375; &#2309;&#2343;&#2367;&#2325; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2375; &#2309;&#2344;&#2381;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
                </span>
            </h2>
        </div>
        <div class="portlet-content">
            <div class="table-responsive">
              
                <table width="100%">

                    <tr>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 40%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDemandType" runat="server" Width="250px">&#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> Demand Type:</asp:Label>
                            <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td style="font-size: medium;">
                            <asp:Label ID="LblDepot" runat="server" Width="100px">&#2337;&#2367;&#2346;&#2379; <br /> Depot  :</asp:Label>
                            <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox"></asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblMedium" runat="server" Width="180px">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; <br /> Medium :</asp:Label>
                            <asp:DropDownList ID="DdlMedium" runat="server" CssClass="txtbox"></asp:DropDownList>
                        </td>
                        <td style="width: 40%; font-size: medium;" valign="top">
                           
                        </td>
                        <td>
                            <asp:Button Text="&#2342;&#2375;&#2326;&#2375;&#2306; / View" ID="BtnView" runat="server" CssClass="btn" OnClick="DdlClass_SelectedIndexChanged" /></td>
                    </tr>
                    <tr>

                        <td><a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a></td>
                        <td style="text-align:left;">
                            <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" /></td>
                        <td></td>
                        <td style="font-size: medium;"></td>
                    </tr>  <tr>
                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">

                                                    <div id="ExportDiv" runat="server">
                                                    <asp:GridView ID="GridView1" runat="server" CssClass="tab" AutoGenerateColumns="False">
                                                        <Columns>
                                                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>.
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Depo2" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                                            <asp:BoundField DataField="ExtraDemand" HeaderText="&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2325;&#2375; &#2346;&#2358;&#2381;&#2330;&#2366;&#2340; &#2358;&#2375;&#2359; &#2360;&#2381;&#2335;&#2377;&#2325; " />
                                                            <asp:BoundField DataField="DistributeBook" HeaderText="&#2309;&#2344;&#2381;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; &#2325;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                                            <asp:BoundField DataField="Remain" HeaderText="&#2309;&#2344;&#2381;&#2340;&#2352;&#2337;&#2367;&#2346;&#2379; &#2346;&#2358;&#2381;&#2330;&#2366;&#2340; &#2358;&#2375;&#2359; &#2360;&#2381;&#2335;&#2377;&#2325; " />
                                                        </Columns>
                                                    </asp:GridView></div>


                                                    </td> </tr> </table> 



            </div> </div> </div> 
</asp:Content>


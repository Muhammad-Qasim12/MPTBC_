<%@ Page Title="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;/Print Supply Order of Printer" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ReportCentralDepotDispatchToPrinter.aspx.cs" Inherits="CenterDepot_ReportCentralDepotDispatchToPrinter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .pnlDisp {
            display: none;
        }
        .auto-style1 {
            height: 47px;
        }
        .auto-style2 {
            width: 100%;
        }
        .dd {
            page-break-before:always;
        }
        .dd2{
            padding-right:7px;padding-left:7px;
        }
      
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

     <script type="text/javascript">
         function PrintPanel() {
             //alert('');
             var panel = document.getElementById("<%=Panel1.ClientID %>");
            var span1 = document.getElementById("Span1");
            var hf = document.getElementById("<%=hfRowCnt.ClientID%>");
            var v = parseInt(hf.value);
            span1.style.display = 'block';
            //alert(v);

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);

            var od1 = document.getElementById("d1");
            od1.style.display = 'block';
            span1.innerHTML = 'Printer Copy';
            //alert(v);
            if (v > 1) {
                od1.innerHTML = "<br /> <br /><br /> <br /><br /> <br /><br /><br /> <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />" + panel.innerHTML;
            }
            else {
                od1.innerHTML = "<br /> <br /><br /> <br /><br /> <br /><br /><br />" + panel.innerHTML;

            }
            printWindow.document.write(od1.innerHTML);
            //console.log(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();

            od1.innerHTML = '';
            span1.innerHTML = 'HO Copy'
            od1.style.display = 'none';
            od1.style.display = 'none';
            span1.style.display = 'none';

            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
    <script type="text/javascript">
        function PrintPanel1() {
            var panel = document.getElementById("<%=Panel2.ClientID %>");
            var span1 = document.getElementById("spDd");
            var hf = document.getElementById("<%=hfRowCnt.ClientID%>");
            var v = parseInt(hf.value);

            span1.style.display = 'block';
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);

            var od1 = document.getElementById("d1");
            od1.style.display = 'block';
            span1.innerHTML = 'Central Paper Depo Copy';
            if (v > 1) {
                od1.innerHTML = "<br /> <br /><br /> <br /><br /> <br /><br /><br /> <br /><br /><br /><br /><br /><br /><br /><br />" + panel.innerHTML;
            }
            else {
                od1.innerHTML = "<br /> <br /><br /> <br /><br /> <br /><br /><br /> <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />" + panel.innerHTML;
            }

            printWindow.document.write(od1.innerHTML);

            var od2 = document.getElementById("d2");
            od2.style.display = 'block';
            span1.innerHTML = 'Printer Copy';

            if (v > 1) {
                od2.innerHTML = "<br /><br /><br /> <br /><br /><br /><br /><br /><br /><br />" + panel.innerHTML;

            }
            else {
                od2.innerHTML = "<br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br /><br /> <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />" + panel.innerHTML;
            }
            printWindow.document.write(od2.innerHTML);

            printWindow.document.write('</body></html>');
            printWindow.document.close();

            //var od2 = document.getElementById("d2");
            //od2.style.display = 'block';
            //span1.innerHTML = 'Printer Copy';
            //od2.innerHTML = "<br /><br /> <br /><br /> <br /><br /> <br /><br /> <br /><br />" + panel.innerHTML;
            //printWindow.document.write(od2.innerHTML);
            //printWindow.document.write('</body></html>');
            //printWindow.document.close();

            od1.innerHTML = '';
            od2.innerHTML = '';
            span1.innerHTML = 'HO Copy'
            od1.style.display = 'none';
            od1.style.display = 'none';
            span1.style.display = 'none';

            setTimeout(function () {
                printWindow.print();
            }, 500);


            return false;
        }
    </script>

    <div class="portlet-header ui-widget-header" id="divHeadTitle" runat="server">
        &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;/Print Supply Order of Printer
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive" width="100%">
                <table>
                    <tr>
                        <td >&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:HiddenField ID="hfRowCnt" runat="server" />
                        </td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; / Paper Demand 
                            <asp:DropDownList runat="server" ID="ddlDemandType" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlDemandType_SelectedIndexChanged">
                                <asp:ListItem Text="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;"></asp:ListItem>
                                <asp:ListItem Text="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368;"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name
                            <asp:DropDownList runat="server" ID="ddlPrinter" OnInit="ddlPrinter_Init"
                                CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;. / Challan No.
                            <asp:DropDownList runat="server" ID="ddlOrderNo" CssClass="txtbox">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                        <td >
                        </td>
                        <td >
                            
                        </td>
                    </tr>
                    <tr><td colspan="3" id="tdPrint" runat="server" visible="false">
                        <a href="#" class="btn" style="color: White;" onclick="return PrintPanel1();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2330;&#2366;&#2354;&#2366;&#2344; </a> 
                            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2352;&#2368;&#2354; &#2344;&#2306;&#2348;&#2352; </a>
                        <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" Visible="false" />
                        </td><td colspan="3" id="tdExportBtn" runat="server" visible="false"></td></tr>
                </table>
                <table width="95%">
                    <tr>
                        <td style="text-align: center">
                           
                        </td>
                    </tr>
                    <tr> 
                        <td style="text-align: center">
                            
                                     <asp:Panel ID="Panel2" runat="server" Width="95%" CssClass="dd"><span id="spDd" style="font-weight:bold;font-size:12px;text-align:center;display:none;">HO Copy</span>
                                         <table  width="95%" id="A" style="display:none" runat="server" >
                                          <tr><td colspan="6" align="left" style="line-height:1em;">GST No.</td> </tr> 
                                         <tr><td colspan="6" align="center">&#2325;&#2375;&#2306;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352;, &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;,&#2346;&#2368;&#2346;&#2354;&#2344;&#2375;&#2352;(&#2327;&#2366;&#2306;&#2343;&#2368;&#2344;&#2327;&#2352;) &#2349;&#2379;&#2346;&#2366;&#2354; <br />
                                            <span style="text-align:center;">&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; :(0755) 2807572, 2551565, 2551294</span><br />
</td></tr>
                                <tr>
                                    <td>&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ <%=ddlOrderNo.SelectedItem.Text %>/&#2346;&#2366;&#2346;&#2369;&#2344;&#2367;/&#2325;&#2381;&#2352;&#2375;&#2306;&#2342;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;/<%=DdlACYear.SelectedItem.Text.Substring(0,4) %>/<%=ddlDemandType.SelectedItem.Text%></td>
                                    <td>&nbsp;</td>
                                    <td id="tdChallandate">&#2349;&#2379;&#2346;&#2366;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;&nbsp;&nbsp;&nbsp;<%=recievdDt%></td>
                                </tr>
                                <tr>
                                    <td colspan="3">&#2346;&#2381;&#2352;&#2340;&#2367; ,</td>
                                </tr>
                                <tr>
                                    <td colspan="3">&#2350;&#2376;&#2360;&#2352;&#2381;&#2360; :- <%=ddlPrinter.SelectedItem.Text %>, &#2346;&#2340;&#2366; : <%=address%> </td>
                                </tr>
                                <tr>
                                    <td colspan="3">&#2357;&#2367;&#2359;&#2351; :-&nbsp;&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; /&#2325;&#2357;&#2381;&#2361;&#2352; &#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;</td>
                                   
                                </tr>
                                <tr>
                                    <td colspan="3" class="auto-style1">&nbsp;&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;. &#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2375; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2332;&#2366;&#2352;&#2368; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2375; &#2360;&#2344;&#2381;&#2342;&#2352;&#2381;&#2349;&nbsp; &#2350;&#2375;&#2306; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; /&#2325;&#2357;&#2381;&#2361;&#2352; &#2325;&#2366;&#2327;&#2332; &#2310;&#2346;&#2325;&#2375; &#2309;&#2343;&#2367;&#2325;&#2371;&#2340; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2325;&#2379; &#2344;&#2375;&#2335; &#2357;&#2332;&#2344; <%=vales%>MT &#2344;&#2367;&#2350;&#2381;&#2344;&#2366;&#2344;&#2369;&#2360;&#2366;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; &#2361;&#2376;&nbsp; :- &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td colspan="3" class="auto-style1">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; : <%=titlehindi_v%></td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="auto-style1">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GridView1_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &lt;br&gt;1">
                                                     <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; &lt;br&gt;2">
                                                    <ItemTemplate>
                                                       <%# Eval("CoverInformation") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="रील/बंडल/शीट संख्या &lt;br&gt;3">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("TotalReem") %>' ></asp:Label><%#Eval("TotSheets") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               
                                                <asp:TemplateField HeaderText="&#2357;&#2332;&#2344; (&#2350;&#2375;.&#2335;&#2344; &#2350;&#2375;&#2306;)&lt;br&gt;4">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("SendQty") %>'></asp:Label>
                                                       <asp:HiddenField ID="hdnPaperVendorTrId" runat="server"  Value='<%# Eval("PaperVendorTrId_I") %>' />
                                                         <asp:HiddenField ID="hdnPaperType_I" runat="server"  Value='<%# Eval("PaperType_I") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="  &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2325;&#2366; &#2344;&#2366;&#2350; &#2340;&#2341;&#2366; &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; &lt;br&gt;5">
                                                       <ItemTemplate>
                                                           &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2375; &#2309;&#2343;&#2367;&#2325;&#2371;&#2340; &#2346;&#2381;&#2352;&#2340;&#2367;&#2344;&#2367;&#2343;&#2367; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2335;&#2381;&#2352;&#2325; &#2325;&#2381;&#2352;. <asp:Literal ID="Literal1" runat="server" ></asp:Literal>
           : <asp:Literal ID="ltrLeader" runat="server" OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                                         &#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2360;&#2375; &#2325;&#2366;&#2327;&#2332; &#2354;&#2379;&#2337; &#2325;&#2352;&#2366;&#2351;&#2366; &#2327;&#2351;&#2366; |
                                                           <asp:HiddenField ID="hdnLeader" runat="server" Value='<%# Eval("Challanno") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="&#2354;&#2327;&#2349;&#2327; &#2350;&#2370;&#2354;&#2381;&#2351; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2351;&#2375;)&lt;br&gt;6">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAmt" runat="server"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;&lt;br&gt;7">
                                                    <ItemTemplate>
                                                        <%# Eval("PaperVendorName_V") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                        G.S.R. NO <%=GRNo%>, Page No. <%=pageno%>
                                    </td>
                                </tr>
                                                               
                                <tr>
                                    <td colspan="3" class="auto-style1">
                                        <table class="auto-style2">
                                            <tr>
                                                <td colspan="2">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&nbsp; &#2325;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2375; &#2354;&#2367;&#2319; &#2325;&#2367;&#2351;&#2375; &#2327;&#2319; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2343;&#2366;&#2352;&#2366;&#2323;&#2306; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2366;&#2327;&#2332; &#2309;&#2330;&#2381;&#2331;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &#2350;&#2375;&#2306; &#2340;&#2341;&#2366; &#2309;&#2306;&#2325;&#2367;&#2340; &#2357;&#2332;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2335;&#2381;&#2352;&#2325; &#2350;&#2375;&#2306; &#2349;&#2352;&#2357;&#2366;&#2351;&#2366; &#2327;&#2351;&#2366;  </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="white-space:nowrap;">&#2309;&#2343;&#2367;&#2325;&#2371;&#2340; /&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; &#2319;&#2357;&#2306; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;:- <%=recievername%></td>
                                                <td align="left">&#2337;&#2367;&#2346;&#2379; &#2350;&#2376;&#2344;&#2375;&#2332;&#2352;
                                                    <br />
                                                    &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                    <br />
                                                    &#2325;&#2375;&#2306;&#2342;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352; ,&#2346;&#2368;&#2346;&#2354;&#2344;&#2375;&#2352;</td>
                                            </tr>
                                            <tr>
                                                <td align="left"> &#2360;&#2306;&#2354;&#2327;&#2381;&#2344; : &#2352;&#2368;&#2354; &#2360;&#2370;&#2330;&#2368; 
                                                <br />&#2346;&#2371;.&#2325;&#2381;&#2352;............./&#2346;&#2366;.&#2346;&#2369;.&#2344;&#2367;/&#2325;&#2375;.&#2349;..................<br /><br />
                                                   </td>
                                                   
                                                

                                            </tr>
                                              <tr>
                                                <td align="left" colspan="2"> &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367; : &#2350;&#2361;&#2366;&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339;,&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; , &#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2368; &#2323;&#2352; &#2360;&#2370;&#2330;&#2344;&#2366;&#2352;&#2381;&#2341; &#2360;&#2306;&#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340;
                                                     </td>
                                                <%--<td align="left"></td>--%>
                                                  

                                            </tr>
                                            <tr><td></td><td align="left">&#2337;&#2367;&#2346;&#2379; &#2350;&#2376;&#2344;&#2375;&#2332;&#2352;
                                                    <br />
                                                    &#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                    <br /></td></tr>
                                        </table>
                                    </td>
                                </tr>
                                                               
                            </table></asp:Panel> <br />
                            <asp:Panel ID="Panel1" runat="server" Width="95%"><span id="Span1" style="font-weight:bold;font-size:12px;text-align:center;display:none;">HO Copy</span>
                                <div id="ExportDiv" runat="server">
                                    <table width="95%">
                                        <tr>
                                            <td colspan="4" style="font-size:12px; font-weight:bold;text-align: center;" id="tdMpHeading" runat="server" visible="false">&#2325;&#2375;&#2306;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352;, &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;,&#2346;&#2368;&#2346;&#2354;&#2344;&#2375;&#2352;
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td colspan="4" style="font-size: 12px; font-weight: bold; text-align:center;" id="tdInfo" runat="server" visible="false"> 
                                                &#2352;&#2368;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;  
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%;" id="tdYear" runat="server" visible="false">
                                                <div style="float: right; padding-right:20px;font-size:12px;">
                                                    &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<asp:Label ID="lblYear" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                            <td colspan="2" style="font-size:12px; font-weight: 200; text-align:center; width:40%;" id="tdPradaykrta" runat="server" visible="false">प्रदायकर्ता का नाम:<%=suppliername%></td>
                                            <td style="font-size:12px; font-weight: 200; text-align: center; width:30%;" id="tdDate" runat="server" visible="false">
                                                <div style="float: right; padding-right: 20px;">
                                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="font-size:12px;text-align:center;" id="tdTitle" runat="server" visible="false">
                                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td colspan="4" style="font-size:12px;text-align:right;" id="tdUnit" runat="server" visible="false">&#2351;&#2370;&#2344;&#2367;&#2335; &#2350;&#2375;&#2335;&#2381;&#2352;&#2367;&#2325; &#2335;&#2344; &#2350;&#2375;&#2306; / Unit in Matric Ton
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="4" style="font-size:13px;font-weight:200;text-align:center;">
                                                <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                                    Width="100%" EmptyDataText="Record Not Found." DataKeyNames="PrinterDisTranId"
                                                    AllowPaging="false" OnRowDataBound="GrdLOI_RowDataBound">
                                                    <Columns>
                                                       <%-- <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex+1 %>.
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>

                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDemandForm" runat="server" Text='<%#Eval("DemandFrom")%>' Visible="false"></asp:Label>
                                                                <asp:Label ID="lblChallanNo" runat="server" Text='<%#Eval("ChallanNo")%>' Visible="false"></asp:Label>
                                                                <asp:HiddenField ID="hdnPaperType_I" runat="server" Value='<%#Eval("PaperType_I")%>'  />
                                                                <table width="100%">
                                                                    <tr id="trHeader" runat="server">
                                                                        <td width="10%" style="padding-bottom:2px;font-size:12px;">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                                                                        <td width="20%" style="padding-bottom:2px; font-weight:bold;font-size:12px;"><%#Eval("NameofPress_V")%></td>
                                                                        <td width="10%" style="padding-bottom:2px;font-size:12px;">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                                                        <td width="10%" style="padding-bottom:2px;font-weight:bold;font-size:12px;"><%#Eval("ChallanNo")%></td>
                                                                        <td width="10%" style="padding-bottom:2px;font-size:12px;">&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                                                                        <td width="15%" style="padding-bottom:2px; font-weight: bold;font-size:12px;"><%#Eval("ChallanDate")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="10%" style="font-size:12px;">&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;</td>
                                                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperMstrTrId_I")%>'></asp:Label>
                                                                        <td width="25%" style="font-weight: bold;font-size:12px;"><%#Eval("CoverInformation")%></td>
                                                                        <td width="15%" style="font-size:12px;">&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;(&#2350;&#2375;. &#2335;&#2344;)</td>
                                                                        <td width="15%" style="font-weight:bold;font-size:12px;"><%#Eval("ReqQty")%></td>
                                                                        <asp:Label ID="lblPaperQty" runat="server" Visible="false" Text='<%#Eval("ReqQty")%>'></asp:Label>
                                                                        <td width="10%" style="padding-bottom:10px;font-size:12px;">&#2327;&#2379;&#2342;&#2366;&#2350; &#2344;&#2306;&#2348;&#2352;</td>
                                                                        <td width="15%" style="padding-bottom:10px;font-weight: bold;font-size:12px;"><%#Eval("BlockNo")%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="25%" style="font-size:12px;">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)</td>
                                                                        <td width="25%" style="font-weight: bold;font-size:12px;"><%#Eval("SendQty")%></td>
                                                                       <td style="font-size:12px;">&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; : </td> <td style="font-size:12px;"><%#Eval("PaperVendorName_V")%> </td>
                                                                        <td style="font-size:12px;">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; : </td><td><%=titlehindi_v%></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" align="center">
                                                                            <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass="tab" Width="30%" OnRowDataBound="GvReelDetails_RowDataBound" ShowFooter="true" style="font-size:10px;">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo</br>1" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" ItemStyle-Width="5%" HeaderStyle-Width="5%" ControlStyle-Font-Size="12px" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px">
                                                                                        <ItemTemplate>
                                                                                            <%--<div style="width:100%;padding:5px;">    --%>                                                                                            
                                                                                                 <asp:Label ID="lbl01" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                                                                <asp:HiddenField ID="hdnPaperType_I_grdv" runat="server" Value='<%#Eval("PaperType_I")%>' />
                                                                                          <%--  </div>--%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                   
                                                                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; <br> Total Sheets</br>2"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" ItemStyle-Width="5%" HeaderStyle-Width="5%" ControlStyle-Font-Size="12px" ItemStyle-Font-Size="12px" HeaderStyle-Font-Size="12px">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                                                                           <%-- </div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotSheets" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2352;&#2368;&#2354; &#2344;&#2306;&#2348;&#2352; <br>Roll No.</br>3"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%;padding:5px;">--%>
                                                                                                <asp:Label ID="lblRollNo" runat="server" style="padding-right:7px;padding-left:7px;" Text='<%#Eval("RollNo")%>'></asp:Label>
                                                                                         <%--   </div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotBundle" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344;(&#2350;&#2375;. &#2335;&#2344;)<br>Net Weight(M.T.)</br>4"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" ItemStyle-Width="10%" HeaderStyle-Width="10%">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                                                                           <%-- </div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Gross Weight(M.T.)</br>5"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black" ItemStyle-Width="5%" HeaderStyle-Width="5%">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                                                                            <%--</div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerStyle CssClass="Gvpaging" />
                                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                          <td colspan="2" rowspan="2" align="left" style="vertical-align:top;">
                                                                            
                                                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="tab" Width="50%" OnRowDataBound="GvReelDetails_RowDataBound" ShowFooter="true" style="font-size:10px;">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo</br>1" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">  --%>                                                                                              
                                                                                                 <asp:Label ID="lbl01" runat="server" Text='<%# Container.DataItemIndex+31 %>'></asp:Label>
                                                                                                 <asp:HiddenField ID="hdnPaperType_I_grdv" runat="server" Value='<%#Eval("PaperType_I")%>' />
                                                                                           <%-- </div>--%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                  
                                                                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335;  <br> Total Sheets</br>2"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                                                                            <%--</div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotSheets" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2352;&#2368;&#2354; &#2344;&#2306;&#2348;&#2352; <br>Roll No.</br>3"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblRollNo" runat="server" style="padding-left:7px;padding-right:7px;" Text='<%#Eval("RollNo")%>'></asp:Label>
                                                                                            <%--</div>--%>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Net Weight(M.T.)</br>4"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                           <%-- <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                                                                           <%-- </div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Gross Weight(M.T.)</br>5"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black"  ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black"  HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                        <ItemTemplate>
                                                                                          <%--  <div style="width: 100%; padding: 5px;">--%>
                                                                                                <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                                                                            <%--</div>--%>
                                                                                        </ItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>
                                                                                        </FooterTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerStyle CssClass="Gvpaging" />
                                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                            </asp:GridView>
                                                                            </td>
                                                                    </tr>
                                                                    
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerStyle CssClass="Gvpaging" />
                                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                </asp:GridView>

                                            </td>
                                          
                                        </tr>
                                         <tr>
                                                                        <td colspan="6" rowspan="2">
                                                                             <table width="100%" style="display:none;font-size:12px;" runat="server" id="PP">
                                                                                <tr style="line-height:1em;"><td style="padding-right:10px;">&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; : <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
                                                                                    
                                                                                <td style="padding-right:10px;">&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; : <asp:Label ID="Label6" runat="server" Text=""></asp:Label></td>
                                                                                <td style="padding-right:10px;">&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; : <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
                                                                                <td style="padding-right:10px;">&#2327;&#2381;&#2352;&#2366;&#2360; &#2357;&#2332;&#2344; : <asp:Label ID="Label5" runat="server" Text=""></asp:Label> </td></tr>
                                                                                
                                                                            </table>

                                                                            <table width="100%" style="display:none;font-size:12px;" id="PP1" runat="server">
                                                                                <tr><td style="padding-right:50px">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;</td>
                                                                                    <td style="padding-right:50px">&#2332;&#2366;&#2306;&#2330;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;</td>
                                                                                    <td style="padding-left:50px;text-align:right;">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;</td></tr>
                                                                            </table>
                                                                        </td> </tr> 
                                    </table>
                                </div>
                            </asp:Panel>

                            
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
    <div id="d1" style="display:none;"></div>
    <div id="d2" style="display:none;"></div>
</asp:Content>

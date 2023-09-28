<%@ Page Title="&#2342;&#2376;&#2344;&#2367;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" 
    CodeFile="ReportDefReelCD.aspx.cs" Inherits="ReportDefReelCD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
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
        }

        function PrintPanel11() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
             var span1 = document.getElementById("spDd");
            // var hf = document.getElementById("hfRowCnt.ClientID");
            var v = parseInt(0);

            span1.style.display = 'block';
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);

            var od1 = document.getElementById("d1");
            od1.style.display = 'block';
            span1.innerHTML = 'Paper Depo Copy';
            
                od1.innerHTML = panel.innerHTML;
            

            printWindow.document.write(od1.innerHTML);

            var od2 = document.getElementById("d2");
            od2.style.display = 'block';
            span1.innerHTML = 'Paper Section Copy';

            
                od2.innerHTML = panel.innerHTML;
            
            printWindow.document.write(od2.innerHTML);

            printWindow.document.write('</body></html>');
            printWindow.document.close();

             
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
    <div class="portlet-header ui-widget-header">
        &#2342;&#2376;&#2344;&#2367;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342; - &#2360;&#2375;&#2344;&#2381;&#2335;&#2381;&#2352;&#2354; &#2346;&#2375;&#2346;&#2352; &#2337;&#2367;&#2346;&#2379;
    </div>
    <div class="portlet-content">
        <div class="box table-responsive">
            <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                <table width="100%" cellpadding="0" cellspacing="0">

                    <tr>
                      <td width="23%"> <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</asp:Label>
                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" Width="120px" OnInit="ddlAcYear_Init">                  
                </asp:DropDownList>
                    </td>
                     <td> &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;/Name Of Paper Mill
                         <asp:DropDownList runat="server" ID="ddlVendor" Width="210px" OnInit="ddlVendor_Init" AutoPostBack="true" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged"
                            CssClass="txtbox reqirerd">                           
                        </asp:DropDownList>
                </td>

                    <td>
 &#2332;&#2368;&#2319;&#2360;&#2319;&#2350;/GSM
                    <asp:DropDownList runat="server" ID="ddlGSM" Width="210px" CssClass="txtbox reqirerd">
                    </asp:DropDownList>
                    </td>   
           
           
                   <td style="text-align: left;">Date: 
                         <asp:TextBox ID="txtFromDate" runat="server" MaxLength="11" CssClass="txtbox reqirerd" Width="90px"></asp:TextBox>
                         <cc1:calendarextender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate"
                              Enabled="True" >
                         </cc1:calendarextender>
                         <cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtFromDate"
                           ValidChars="0123456789/-"></cc1:filteredtextboxextender>
                    </td>

                         <td>
                            <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClientClick="return ValidateAllTextForm1();" OnClick="Button1_Click" /></td>

                    </tr>
                    
                    <tr>
                        <td colspan="4" align="center" id="tdPrintContent" runat="server" visible="false">
                            <div style="width: 40px; color: White;">
                                <table>
                                    <tr>
                                        <td>
                                            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel11();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" CssClass="btn" OnClick="btnExport_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </div>
                            <div style="width: auto; height: auto;">
                                <center>
                                    <div class="MT20">
                                        <asp:Panel ID="Panel1" runat="server" Width="100%">
                                            <span id="spDd" style="font-weight:bold;font-size:12px;text-align:center;display:none;">HO Copy</span>
                                            <div id="ExportDiv" runat="server">
                                                <div style="width: 900px;height:1332px;">
                                                    <div style="padding: 10px;">
                                                        <table width="100%">
                                                            <tr>
                                                                <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">
                                                                    मध्यप्रदेश पाठ्यपुस्तक निगम                                                             
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">केन्द्रीय भण्डार
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">पीपलनेर (गांधीनगर)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; - 0755-2550727, 2551294,2551565, &#2347;&#2376;&#2325;&#2381;&#2360; - 2551145, &#2312;-&#2350;&#2375;&#2354;- info.mptbc@mp.gov.in &#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; - mptbc.nic.in
                                                            <hr />
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td colspan="2" style="font-size: 16px; font-weight: bold; text-align: left;">
                                                                   &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;	./....../&#2346;&#2366;&#2346;&#2369;&#2344;&#2367; /&#2325;&#2375;.&#2349;/<%=sSetAcYr%><hr /></td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: bold; text-align: right;">पीपलनेर भोपाल,&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;:-<%=dte%><hr /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align:left;">&#2346;&#2381;&#2352;&#2340;&#2367; ,<br />
                                                                    <asp:Label ID="lblVenderName" runat="server" Font-Bold="true"></asp:Label><br />
                                                                    <asp:Label ID="lblVenderAddress" runat="server" Font-Bold="true"></asp:Label><br />
                                                                <hr />
                                                                </td>

                                                            </tr>
                                                            <tr>

                                                                <td colspan="2" runat="server" id="tdGroup" style="font-size: 16px; font-weight: bold; text-align: left;">
                                                                   &#2357;&#2367;&#2359;&#2351;&#2307;&#8212;	&#2346;&#2381;&#2352;&#2350;&#2366;&#2339;&#2368;&#2325;&#2352;&#2339; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2361;&#2375;&#2340;&#2369; &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2352;&#2368;&#2354; &#2325;&#2366;&#2327;&#2332; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2352;&#2360;&#2368;&#2342;&#2404;                                                                   
                                                                </td>
                                                            </tr>
                                                            <tr><td colspan="2"></td></tr>

                                                            <tr><td colspan="2">&#2357;&#2367;&#2359;&#2351;&#2366;&#2306;&#2340;&#2352;&#2381;&#2327;&#2340; &#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; &#2325;&#2379; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; <b><%=dte11%></b> &#2325;&#2379; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2368;&#2354; &#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2350;&#2366;&#2339;&#2368;&#2325;&#2352;&#2339; &#2344;&#2367;&#2350;&#2381;&#2344;&#2366;&#2344;&#2369;&#2360;&#2366;&#2352; &#2361;&#2376;&#2307;&#8212;</td></tr>

                                                            <tr>
                                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" CssClass="tab"
                                                                    Width="100%" EmptyDataText="Record Not Found." ShowFooter="true" OnRowDataBound="GvReelDetails_RowDataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>
                                                                                <%# Container.DataItemIndex+1 %>.
                                                                            </ItemTemplate>
                                                                            <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                            <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                           
                                                                        </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="Paper Information<br>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2366;&#2327;&#2395; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                <itemtemplate>
                                                                                  <%#Eval("CoverInformation")%>
                                                                            </itemtemplate>
                                                                                <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                                <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                           <FooterTemplate>
                                                                                <div style="text-align:center;">
                                                                                    &#2351;&#2379;&#2327;&#2307;&#8212;
                                                                                </div>
                                                                            </FooterTemplate>
                                                                          </asp:TemplateField>

                                                                          <asp:TemplateField HeaderText="&#2352;&#2368;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;<br>No.Of Reels" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                <itemtemplate>
                                                                                    <asp:Label ID="lblNoOfReels" runat="server" Text='<%#Eval("NoOfReels")%>'></asp:Label>
                                                                            </itemtemplate>
                                                                                <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                                <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                              <FooterTemplate>
                                                                                 <asp:Label ID="lblTotReels" runat="server" Font-Bold="true"></asp:Label>
                                                                              </FooterTemplate>
                                                                          </asp:TemplateField>

                                                                         <asp:TemplateField HeaderText="&#2357;&#2395;&#2344; (&#2350;&#2368;. &#2335;&#2344;)<br>Recieved Qty(M.T)">
                                                                            <itemtemplate>
                                                                                 <asp:Label ID="lblRecQty" runat="server" Text='<%#Eval("ReceivedQty")%>'></asp:Label>
                                                                                 
                                                                            </itemtemplate>
                                                                                <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                                <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                               <FooterTemplate>
                                                                                 <asp:Label ID="lblTotRecQty" runat="server" Font-Bold="true"></asp:Label>
                                                                              </FooterTemplate>
                                                                          </asp:TemplateField>

                                                                         <asp:TemplateField HeaderText="&#2311;&#2344;&#2357;&#2366;&#2312;&#2360; &#2344;&#2306;&#2348;&#2352; &#2340;&#2341;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Invoice No.& Date" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                <itemtemplate>   
                                                                                     <%#Eval("InvoiceNo")%>
                                                                                                        </itemtemplate>
                                                                                <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                                <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                            </asp:TemplateField>
                                                                           
                                                                            <asp:TemplateField HeaderText="&#2332;&#2368;.&#2310;&#2352;.&#2344;&#2306;&#2348;&#2352; &#2340;&#2341;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>GrNo.& Date" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                                <itemtemplate>   
                                                                                     <%#Eval("GRNoDate")%>
                                                                                                        </itemtemplate>
                                                                                <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                                <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                                <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                            </asp:TemplateField>                                                                            
                                                                            
                                                                        <asp:TemplateField HeaderText="&#2325;&#2335;&#2368; &#2352;&#2368;&#2354;<br>Defective Reel"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>                                                                                      
                                                                                 <asp:Label ID="lblDefReel" runat="server" Font-Bold="true" Text='<%#Eval("DefReel")%>'></asp:Label>                                                                                 
                                                                            </ItemTemplate>
                                                                            <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                            <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                            <FooterTemplate>
                                                                                 <asp:Label ID="lblTotDefReel" runat="server" Font-Bold="true"></asp:Label>
                                                                              </FooterTemplate>
                                                                        </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Def Weight" Visible="false"  HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                            <ItemTemplate>  
                                                                                 <asp:Label ID="lblDefWt" runat="server" Font-Bold="true" Text='<%#Eval("DefWt")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" />
                                                                            <HeaderStyle BackColor="LightGray" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                            <ItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                        <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                                </asp:GridView>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                        <td colspan="4" style="font-size: 13px; font-weight:200; text-align:left;">
                                                            <span style="font-weight:bold;">&#2344;&#2379;&#2335;&#2307;&#8212;</span> &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2368;&#2354;&#2379; &#2350;&#2375;&#2306; &#2325;&#2369;&#2354; <asp:Label ID="lblTotDefReel11" runat="server" Font-Bold="true"></asp:Label> &#2352;&#2368;&#2354; &#2325;&#2335;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2361;&#2369;&#2312;, &#2332;&#2367;&#2360;&#2350;&#2375;&#2306; &#2325;&#2369;&#2354; <asp:Label ID="lblTotTonMetric" runat="server" Font-Bold="true"></asp:Label> &#2350;&#2368;. &#2335;&#2344; &#2341;&#2348;&#2381;&#2348;&#2366; &#2344;&#2367;&#2325;&#2354;&#2344;&#2375; &#2325;&#2368; &#2360;&#2306;&#2349;&#2366;&#2357;&#2344;&#2366; &#2361;&#2376; &#2404; 
                                                            <br /><br />
                                                        </td>
                                                            </tr>

                                                             <tr>
                                                                <td colspan="2" style="font-size: 16px; font-weight: bold; text-align: center;" id="strkeeper">
                                                                  &#2360;&#2381;&#2335;&#2379;&#2352;&#2325;&#2368;&#2346;&#2352;
                                                                </td>
                                                                 <td colspan="2" style="font-size: 16px; font-weight: bold; text-align: left;" id="Testt">
                                                                   &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;<br />
                                                                &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#8204;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                                                              &#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; &#2346;&#2368;&#2346;&#2354;&#2344;&#2375;&#2352;, &#2349;&#2379;&#2346;&#2366;&#2354;                                                                   
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td colspan="2" style="font-size: 16px; font-weight: bold; text-align: left;">
                                                                    &#2346;&#2371;&#2359;&#2381;&#2336;&#2366;&#2306;&#2325;&#2344; &#2325;&#2381;&#2352;&#2306;./....../&#2346;&#2366;&#2346;&#2369;&#2344;&#2367;/&#2325;&#2375;.&#2349;./&#2325;&#2375;.&#2349;/&#2325;&#2366;&#2327;&#2332;/<asp:Label ID="lblSetAcYr" runat="server" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                <td colspan="2" style="font-size: 16px; font-weight: bold; text-align: left;">
                                                                    &#2349;&#2379;&#2346;&#2366;&#2354;, &#2342;&#2367;&#2344;&#2306;&#2325;&#2307;&#8212; <b><%=dte%></b>
                                                                    </td>
                                                                </tr>

                                                            <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: left;">
                                                                   &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367;&#2307;&#8212; &#2350;&#2361;&#2366;&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;, &#2325;&#2366;&#2327;&#2332; &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#8204;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;, &#2349;&#2379;&#2346;&#2366;&#2354; &#2325;&#2368; &#2323;&#2352; &#2360;&#2370;&#2330;&#2344;&#2366;&#2352;&#2381;&#2341; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340;&#2404;
                                                                    </td>
                                                               
                                                                </tr>

                                                             <tr>
                                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: right;">
                                                                  &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;<br />
                                                               &#2350;. &#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#8204;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                                                            &#2325;&#2375;&#2344;&#2381;&#2342;&#2381;&#2352;&#2368;&#2351; &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; &#2346;&#2368;&#2346;&#2354;&#2344;&#2375;&#2352;, &#2349;&#2379;&#2346;&#2366;&#2354;
                                                                    </td>
                                                               
                                                                </tr>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </center>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td id="tdNoRecord" runat="server" align="center" visible="false">No Record Found..
                        </td>
                    </tr>
                </table>

            </div>

        </div>
    </div>


     <div id="d1" style="display:none;"></div>
    <div id="d2" style="display:none;"></div>
</asp:Content>

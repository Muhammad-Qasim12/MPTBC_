<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GSRReport.aspx.cs" Inherits="Depo_GSRReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-top: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">

        <div class="card-header">
            <h2>&#2332;&#2344;&#2352;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; / General Stock Register 
            </h2>
        </div>
        <div style="padding: 0 10px;">


            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">&#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                            <asp:ListItem Value="2">&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr  runat ="server" id="othea" visible="false">
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                       
                    </td>
                    <td> <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
                        </asp:DropDownList>
                       </td>
                    <td>&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                       <asp:DropDownList ID="DropDownList2" runat="server" >
                        </asp:DropDownList></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;&nbsp; / From Date 
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                      
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                    </td>
                    <td>
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :
                        <asp:DropDownList ID="ddlSessionYear" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="a1a" runat="server" >
                    <td>&nbsp;&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; 
                                       <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" AutoPostBack="true"  OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>

                    </td>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Button ID="Button3" runat="server" CssClass="btn"
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / See Report "
                            OnClick="Button3_Click" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td colspan="5">
                        <div id="ExportDiv" runat="server" visible="false">
                            <table width="100%">
                                <tr>
                                    <td align="center"><b>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
                                        <br />
                                        &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                                        <br />
                                    </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;&#2348;&#2352; : <b>
                                        <asp:Label ID="lblphone" runat="server"></asp:Label>
                                        , &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; :<asp:Label ID="lblmobileNo" runat="server"></asp:Label>
                                        &nbsp;
&nbsp;</b>,&#2312;&#2350;&#2375;&#2354; &#2310;&#2312;&#2337;&#2368; : <b>
    <asp:Label ID="lblemailID" runat="server"></asp:Label>
    &nbsp;,</b>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : http://mptbc.nic.in</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
                                    </b>
                                        &nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
                                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                                        </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2332;&#2344;&#2352;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; / General Stock Register&nbsp; :
          &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;  :  
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; :
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <div style="display: none;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderTemplate>
                                                <table style="width: 100%" border="2" class="tab">
                                                    <tr>
                                                        <th rowspan="2">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                                                        <th rowspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
                                                        <th rowspan="2">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; &#2332;&#2367;&#2360;&#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2361;&#2369;&#2312; &#2361;&#2376; </th>
                                                        <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </th>
                                                        <th>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2349;&#2375;&#2332;&#2344;&#2375; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; </th>
                                                        <th colspan="2">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; &#2340;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
                                                        <th rowspan="2">&#2330;&#2366;&#2354;&#2366;&#2344;&#2325;&#2381;&#2352;. &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                                        </th>
                                                        <th rowspan="2">&#2332;&#2368; &#2310;&#2352; / /&#2310;&#2352; &#2310;&#2352; &#2325;&#2381;&#2352;. &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
                                                        <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; </th>
                                                        <th rowspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; </th>
                                                        <th rowspan="2">25 % &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2311;&#2332; &#2324;&#2360;&#2340;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th rowspan="2">&#2360;&#2381;&#2335;&#2377;&#2325; &#2354;&#2375;&#2332;&#2352; &#2346;&#2371;&#2359;&#2381;&#2335; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                                                        <th colspan="5">&#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2325;&#2367;&#2351;&#2375; &#2327;&#2319; &#2357;&#2381;&#2351;&#2351; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; </th>
                                                        <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; </th>
                                                        <th rowspan="2">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </th>
                                                    </tr>

                                                    <tr>
                                                        <th>&#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>
                                                        <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</th>
                                                        <th>&#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th>&#2313;&#2340;&#2352;&#2366;&#2312; </th>
                                                        <th>&#2330;&#2397;&#2366;&#2312; </th>
                                                        <th>&#2346;&#2352;&#2367;&#2357;&#2366;&#2361;&#2344; </th>
                                                        <th>&#2309;&#2344;&#2381;&#2351; </th>
                                                        <th>&#2351;&#2379;&#2327; </th>
                                                    </tr>
                                                    <tr>
                                                        <td>1</td>
                                                        <td>2</td>
                                                        <td>3</td>
                                                        <td>4</td>
                                                        <td>5</td>
                                                        <td>6</td>
                                                        <td>7</td>
                                                        <td>8</td>
                                                        <td>9</td>
                                                        <td>10</td>
                                                        <td>11</td>
                                                        <td>12</td>
                                                        <td>13</td>
                                                        <td>14</td>
                                                        <td>15</td>
                                                        <td>16</td>
                                                        <td>17</td>
                                                        <td>18</td>
                                                        <td>19</td>
                                                        <td>20</td>
                                                        <td>21</td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>


                                                <tr>
                                                    <td><%#Container.DataItemIndex+1 %></td>
                                                    <td><%# Eval("Receiveddate_D")%></td>
                                                    <td><%# Eval("NameofPress_V")%>
                                                        <br />
                                                        <%#Eval("FullAddress_V")%> 
                                                    </td>
                                                    <td><%#Eval("Title")%>  </td>
                                                    <td><%#Eval("TotalNoOfBundle")%> </td>
                                                    <td><%#Eval("NoOfbookYojana")%> </td>
                                                    <td><%#Eval("NoOfBookSamanya")%></td>
                                                    <td><%#Eval("BooksFrom")%> -<%#Eval("BooksTo")%><br /><%#Eval("Receiveddate_D") %></td>
                                                    <td><%#Eval("ChallanDate")%></td>
                                                    <td><%#Eval("GRNo_V")%><br />
                                                        <%#Eval("GRDate_D")%>  </td>
                                                    <td><%#Eval("TotalNoOfBundle")%></td>
                                                    <td><%#Eval("BooksFrom")%> -<%#Eval("BooksTo")%></td>
                                                    <td><%#Eval("NoOfBookCounted_I")%></td>
                                                    <td><%#Eval("RegisterNo")%></td>
                                                    <td><%#Eval("unLordingCharge_N")%></td>
                                                    <td><%#Eval("LordingCharge_N")%> </td>
                                                    <td><%#Eval("TransportationCharge_N")%> </td>
                                                    <td><%#Eval("OtherCharges_N")%> </td>
                                                    <td><%#Eval("Total")%></td>
                                                    <td><%#Eval("Name")%> </td>
                                                    <td><%#Eval("Remarks_V")%>  </td>
                                                </tr>




                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <div style="overflow:auto" class="rdlc">
                            <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                        </div>
                    </td>
                </tr>
            </table>
            
            <tr>
                <td colspan="4">

                    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
                    </div>
                    <div id="Messages" style="display: none;" class="popupnew" runat="server">

                        <div class="msg MT10">
                            <p>
                            </p>
                        </div>
                        <a id="fancybox-close" style="display: inline;" onclick="javascript:closeMessagesDiv();"></a>
                    </div>
                </td>

            </tr>
        </div>
    </div>
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


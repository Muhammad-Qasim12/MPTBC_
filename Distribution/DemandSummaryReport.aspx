<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DemandSummaryReport.aspx.cs" Inherits="Distribution_DemandSummaryReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
                <div class="card-header">
                    <h2 >&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;&#2357;&#2366;&#2352; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2375; &#2350;&#2366;&#2305;&#2327; &#2325;&#2366; &#2360;&#2306;&#2331;&#2367;&#2346;&#2381;&#2340; &#2357;&#2367;&#2357;&#2352;&#2339;</h2>
                </div>

        <table width="100%">

            <tr>

                <td align="center" >
                   <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                &nbsp;
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Report" CssClass="btn" />
                </td>
            </tr>
</table> <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
          <div style="overflow: auto" class="rdlc" runat="server" visible="false" id="aa" >
    <table width="100%">
                <tr>
                    <td align="center"><b style="text-align: center">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                    </b>
                    </td>
                </tr>
                <tr>
                    <td align="center">&#2352;&#2366;&#2332;&#2381;&#2351; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2325;&#2375;&#2306;&#2342;&#2381;&#2352;, &#2354;&#2379;&#2325; &#2358;&#2367;&#2325;&#2381;&#2359;&#2339; &#2360;&#2306;&#2330;&#2366;&#2354;&#2344;&#2366;&#2354;&#2351; &#2319;&#2357;&#2306; &#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2332;&#2366;&#2352; &#2325;&#2368; &#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2309;&#2344;&#2369;&#2350;&#2366;&#2344;&#2367;&#2340; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; <br /> 
                        <br />
                        ( &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2361;&#2375;&#2340;&#2369;)</td>
                </tr>
                <tr>
                    <td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer" runat="server"></asp:Label>
                    </b>
                        &nbsp;&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
                            <asp:Label ID="lblDate" runat="server"></asp:Label>
                        </b>
                    </td>
                </tr>
                <tr>
                    <td align="center" >&nbsp;</td>
                </tr>
            </table>
                    <table class="tab">
                        <tr>
                            <th rowspan="2">&#2325;&#2381;&#2352;</th>
                            <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</th>
                            <th colspan="2">&#2309;&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306;</th>
                            <th colspan="2">&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306;</th>
                            <th colspan="2">&#2325;&#2369;&#2354; &#2351;&#2379;&#2327;</th>
                        </tr>
                        <tr>
                            <th>&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                            <th>&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                            <th>&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                            <th>&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                            <th>&#2325;&#2366;&#2354;&#2350; &#2325;&#2381;&#2352;(3+5)&#2325;&#2366; &#2351;&#2379;&#2327;</th>
                            <th>&#2325;&#2366;&#2354;&#2350; &#2325;&#2381;&#2352;(4+6)&#2325;&#2366; &#2351;&#2379;&#2327;</th>
                        </tr>
                        <tr>
                            <th>1</th>
                            <th>2</th>
                            <th>3</th>
                            <th>4</th>
                            <th>5</th>
                            <th>6</th>
                            <th>7</th>
                            <th>8</th>
                        </tr>
                        <tr><%
                                for (int j = 0; j < DS.Tables[0].Rows.Count; j++)
                                {
                                    classa = DS.Tables[0].Rows[j]["Class"].ToString();
                                    if (classa == "1-8")
                                    {
                                        a1 = Convert.ToString(Convert.ToInt32(a1) + Convert.ToInt32(DS.Tables[0].Rows[j]["TotalAParivartitDemand"].ToString()));
                                        a2 = Convert.ToString(Convert.ToInt32(a2) + Convert.ToInt32(DS.Tables[0].Rows[j]["NumbeofTitleA"].ToString()));
                                        a3 = Convert.ToString(Convert.ToInt32(a3) + Convert.ToInt32(DS.Tables[0].Rows[j]["TotalParivartitDemand"].ToString()));
                                        a4 = Convert.ToString(Convert.ToInt32(a4) + Convert.ToInt32(DS.Tables[0].Rows[j]["NumbeofTitle"].ToString()));
                                        r = r + 1;
                                          %>
                            <td><%=r%></td>
                            <td><%=DS.Tables[0].Rows[j]["MediunNameHindi_V"].ToString()%> <br /><%=DS.Tables[0].Rows[j]["Class"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[j]["TotalAParivartitDemand"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[j]["NumbeofTitleA"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[j]["TotalParivartitDemand"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[j]["NumbeofTitle"].ToString()%></td>
                            <td><%=Convert.ToInt32(DS.Tables[0].Rows[j]["TotalAParivartitDemand"].ToString())+Convert.ToInt32(DS.Tables[0].Rows[j]["TotalParivartitDemand"].ToString())%></td>
                            <td><%=Convert.ToInt32(DS.Tables[0].Rows[j]["NumbeofTitle"].ToString())+Convert.ToInt32 (DS.Tables[0].Rows[j]["NumbeofTitleA"].ToString())%></td>
                        </tr><%}
                                } %>
                        <tr>
                            <th>Total</th>
                            <th>&nbsp;</th>
                            <th><%=a1%></th>
                            <th><%=a2%></th>
                            <th><%=a3%></th>
                            <th><%=a4%></th>
                            <th><%=Convert.ToInt32(a1)+Convert.ToInt32 (a3) %></th>
                            <th><%=Convert.ToInt32(a2)+Convert.ToInt32 (a4) %></th>
                        </tr>
                        <tr><%for (int h = 0; h < DS.Tables[0].Rows.Count; h++)
                              {
                                  classa = DS.Tables[0].Rows[h]["Class"].ToString();
                                  if (classa == "9-12")
                                  {
                                      a5 = Convert.ToString(Convert.ToInt32(a5) + Convert.ToInt32(DS.Tables[0].Rows[h]["TotalAParivartitDemand"].ToString()));
                                      a6 = Convert.ToString(Convert.ToInt32(a6) + Convert.ToInt32(DS.Tables[0].Rows[h]["NumbeofTitleA"].ToString()));
                                      a7 = Convert.ToString(Convert.ToInt32(a7) + Convert.ToInt32(DS.Tables[0].Rows[h]["TotalParivartitDemand"].ToString()));
                                      a8 = Convert.ToString(Convert.ToInt32(a8) + Convert.ToInt32(DS.Tables[0].Rows[h]["NumbeofTitle"].ToString()));
                                      r = r + 1;
                                      
                                      %>
                            <td><%=r%></td>
                            <td><%=DS.Tables[0].Rows[h]["MediunNameHindi_V"].ToString()%> <br /><%=DS.Tables[0].Rows[h]["Class"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[h]["TotalAParivartitDemand"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[h]["NumbeofTitleA"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[h]["TotalParivartitDemand"].ToString()%></td>
                            <td><%=DS.Tables[0].Rows[h]["NumbeofTitle"].ToString()%></td>
                            <td><%=Convert.ToInt32(DS.Tables[0].Rows[h]["TotalAParivartitDemand"].ToString())+Convert.ToInt32(DS.Tables[0].Rows[h]["TotalParivartitDemand"].ToString())%></td>
                            <td><%=Convert.ToInt32(DS.Tables[0].Rows[h]["NumbeofTitle"].ToString())+Convert.ToInt32 (DS.Tables[0].Rows[h]["NumbeofTitleA"].ToString())%></td>
                        </tr><%}
                              } %>
                        <tr>
                           <th >Total</th>
                            <th >&nbsp;</th>
                            <th ><%=a5%></th>
                            <th><%=a6%></th>
                            <th ><%=a7%></th>
                            <th ><%=a8%></th>
                            <th ><%=Convert.ToInt32(a5)+Convert.ToInt32 (a7) %></th>
                            <th><%=Convert.ToInt32(a6)+Convert.ToInt32 (a8) %></th>
                        </tr>
                        <tr>
                           <th colspan="2" >Grand Total</th>
                            <th ><%=Convert.ToInt32(a1)+Convert.ToInt32(a5) %></th>
                            <th><%=Convert.ToInt32(a2)+Convert.ToInt32(a6)%></th>
                            <th ><%=Convert.ToInt32(a3)+Convert.ToInt32(a7)%></th>
                            <th ><%=Convert.ToInt32(a4)+Convert.ToInt32(a8)%></th>
                            <th ><%=Convert.ToInt32(a5)+Convert.ToInt32 (a7)+Convert.ToInt32(a1)+Convert.ToInt32 (a3)%></th>
                            <th><%=Convert.ToInt32(a6)+Convert.ToInt32 (a8)+Convert.ToInt32(a2)+Convert.ToInt32 (a4) %></th>
                        </tr>
                    </table>
                </div></div> 
     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=aa.ClientID %>");

                      var printWindow = window.open('', '', 'height=400,width=800');
                      printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: left; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
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


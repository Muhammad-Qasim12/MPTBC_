<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptCoverandPrintingPaperDetails.aspx.cs" Inherits="Printing_RptCoverandPrintingPaperDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-weight: bold;
        }
        .auto-style2 {
            text-align: center;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Paper Allotment Detail--%></span>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>
                        <%--Academic Year  --%>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;
                    </td>
                    <td>
                      <asp:DropDownList ID="ddlAcadmicYear" runat="server" CssClass="txtbox reqirerd" AutoPostBack="true" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged"   >
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="ddlTenderID_I" runat="server" CssClass="txtbox reqirerd" >
                              
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Academic Year  --%>
                        &#2350;&#2358;&#2368;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;</td>
                    <td>
                        
                        <asp:DropDownList ID="ddlAcadmicYear2" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True">
                               <asp:ListItem Value="0">&#2360;&#2349;&#2368;</asp:ListItem>
                            <asp:ListItem Value="1">&#2358;&#2368;&#2335; &#2347;&#2375;&#2337;</asp:ListItem>
                            <asp:ListItem Value="2">&#2357;&#2375;&#2348; &#2321;&#2347;&#2360;&#2375;&#2335;</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td>
                        &nbsp;&#2335;&#2344;&#2375;&#2332;</td>
                    <td>
                        <asp:DropDownList ID="ddlAcadmicYear1" runat="server" CssClass="txtbox " AutoPostBack="True">
                          <asp:ListItem Value="0">&#2360;&#2349;&#2368;</asp:ListItem>
                               <asp:ListItem Value="1">1-100</asp:ListItem>
                            <asp:ListItem Value="2">101-200</asp:ListItem>
                            <asp:ListItem Value="3">201-300</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click1" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                <%--    <td>
                        <asp:DropDownList&#2335;&#2344;&#2375;&#2332;</td>--%>
                </tr>
                <tr>
                    <td colspan="4">
                     <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" 
                            OnClientClick="return PrintPanel();" Text=" Print"  />
                        
                         </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="Panel1" runat="server" Width="100%" Height="100%" Visible="false" >
                         <div id="ExportDiv" runat="server" >
                        <table class="tab">
                            <tr>
                                <th colspan="7" align="center"  ><center> &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;- <%=ddlAcadmicYear.SelectedItem.Text   %> &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;<br />
                                    <br />
                        &#2350;&#2358;&#2368;&#2344; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; :- <%=ddlAcadmicYear2.SelectedItem.Text %><br /> </center>
                                </th>
                            </tr>
                            <tr>
                                <th>Group No </th>
                                <th>Class</th>
                                <th>Title</th>
                                <th>Approx No of Pages</th>
                                <th>Approx No of books to be Printing</th>
                                <th>Approx Qty of Printing Paper<br /> (in tons)</th>
                                <th>Required earnest Money<br /> (in Rs.)</th>
                            </tr>
                            <tr>
                                <th class="auto-style2">1</th>
                                <th class="auto-style2">2</th>
                                <th class="auto-style2">3</th>
                                <th class="auto-style2">4</th>
                                <th class="auto-style2">5</th>
                                <th class="auto-style2">6</th>
                                <th class="auto-style2">7</th>
                            </tr>
                            <%
                                if (ddlAcadmicYear1.SelectedValue == "1")
                                {
                                    Froma = 1;
                                    To = 100;
                                }
                                else if (ddlAcadmicYear1.SelectedValue =="2")
                                {
                                    Froma = 101;
                                    To = 200;
                                }
                                else if (ddlAcadmicYear1.SelectedValue == "3")
                                {
                                    Froma = 201;
                                    To = 300;
                                }
                                else if (ddlAcadmicYear1.SelectedValue == "0")
                                {
                                    Froma = 1;
                                    To = 3000;
                                }

                                dd = obCommonFuction.FillDatasetByProc("call Usp_Rpt003Groupdetail1('" + ddlAcadmicYear.SelectedItem.Text + "',0," + Froma + "," + To + "," + ddlAcadmicYear2.SelectedValue  + ","+ddlTenderID_I.SelectedValue+")");
                              for (int i = 0; i < dd.Tables[1].Rows.Count; i++)
                              {
                                  printingPaper = 0;
                                  EmdMoney = 0;
                                  coutn = 0;
                               %>
                            <tr><% dd2 = obCommonFuction.FillDatasetByProc("call Usp_Rpt003Groupdetail1('" + ddlAcadmicYear.SelectedItem.Text + "','" + dd.Tables[1].Rows[i]["groupno_v"] + "',0,0," + ddlAcadmicYear2.SelectedValue + "," + ddlTenderID_I.SelectedValue + ")");
                              for (int j = 0; j < dd2.Tables[0].Rows.Count; j++)
                              {
                                  printingPaper = printingPaper +Convert.ToDouble( dd2.Tables[0].Rows[j]["Qty_PriPaper"]);
                                  EmdMoney = Convert.ToInt32(dd2.Tables[0].Rows[j]["emd"]);
                                 
                                     %>
                                <td><%if (coutn == 0) { %> <%=dd2.Tables[0].Rows[j]["groupno_v"].ToString () %> <%}
                                      else { } %></td>
                                <td><%=dd2.Tables[0].Rows[j]["bankname_v"].ToString () %></td>
                                <td><%=dd2.Tables[0].Rows[j]["TitleHindi_V"].ToString () %></td>
                                <td><%=dd2.Tables[0].Rows[j]["Noofpages"].ToString () %></td>
                                <td><%=dd2.Tables[0].Rows[j]["TotNoOfBooks"].ToString () %></td>
                                <td><%=dd2.Tables[0].Rows[j]["Qty_PriPaper"].ToString () %></td>
                                <td></td>
                            </tr><%  coutn = coutn + 1;
                              } %>
                            <tr>
                                <td colspan="5" class="auto-style1">Total </td>
                                <td class="auto-style1"><%=System.Math.Round ( printingPaper,0)%></td>
                                <td class="auto-style1"><%=EmdMoney%>/-</td>
                            </tr><%} %>
                        </table></div> </asp:Panel>
                    </td>
                </tr></table> </div> 
           <script type = "text/javascript">
               function PrintPanel() {
                   var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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


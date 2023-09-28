<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintData.aspx.cs" Inherits="DistributionB_PrintData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
        }

        .auto-style2 {
        }

        .auto-style4 {
        }

        .auto-style5 {
            width: 146px;
        }

        .auto-style6 {
            width: 198px;
        }

        .auto-style7 {
            width: 112px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                <span>&#2342;&#2375;&#2351;&#2325; &#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339; &#2319;&#2357;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; / Bill Process and Received Payment Information</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">

            <a href="#" class="btn" style="color: White;" onclick="return PrintPanel();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;</a>
            <div id="ExportDiv" runat="server">
                <table width="100%">
                    <tr>
                        <td colspan="3" align="center"><strong>&#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; </strong></td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344; , &#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360; , &#2349;&#2379;&#2346;&#2366;&#2354; (&#2350;.&#2346;&#2381;&#2352;.)</td>
                    </tr>
                    <tr>
                        <td colspan="3" align="center"><b>देयक </b></td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2" colspan="3">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style7">जी.एस.टी.क्र.</td>
                        <td align="left"><%= (dtr1.Tables[0].Rows[0]["GSTNo"]).ToString () %></td>
                        <td align="right"></td>
                    </tr>
                    <tr>
                        <td>&#2342;&#2375;&#2351;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / &#2340;&#2367;थि </td>
                        <td colspan="2" align="left"><%= (dtr1.Tables[0].Rows[0]["LetterNo_V"]).ToString () %> - <%=Convert.ToDateTime (dtr1.Tables[0].Rows[0]["LetterDate_D"]).ToString ("dd/MM/yyyy") %></td>
                    </tr>
                    <tr>
                        <td class="auto-style7">&#2342;&#2375;&#2344;&#2342;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; &#2319;&#2357; &#2346;&#2340;&#2366; </td>
                        <td colspan="2"><%= (dtr1.Tables[0].Rows[0]["DepartmentAddress"]).ToString () %> </td>
                    </tr>
                    <tr>
                        <td>पुस्तक का नाम</td>
                        <td><span id="span_Title" runat="server"></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style1" colspan="3">
                            <br />
                            <table width="100%" border="1">

                                <tr>
                                    <td>&#2325;&#2381;&#2352;.   </td>
                                    <td class="auto-style4">शीर्षक का नाम</td>
                                    <td class="auto-style6">&#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                                    <td class="auto-style5">&#2342;&#2352;</td>
                                    <td>&#2350;&#2370;&#2354;&#2381;&#2351; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)</td>

                                </tr>
                                <%for (int i = 0; i < dtr.Tables[0].Rows.Count; i++)
                                  {
                                      r = r + 1;
                                      TotalAmount = TotalAmount + Convert.ToDouble(dtr.Tables[0].Rows[i]["Trate"]);
                                %>
                                <tr>
                                    <td><%=r %></td>
                                    <td class="auto-style4"><%=dtr.Tables[0].Rows[i]["SubTitle"].ToString () %></td>
                                    <td class="auto-style6"><%=dtr.Tables[0].Rows[i]["TotalBooks"].ToString () %></td>
                                    <td class="auto-style5"><%=dtr.Tables[0].Rows[i]["Rate_N"].ToString () %></td>
                                    <td><%=dtr.Tables[0].Rows[i]["Trate"].ToString () %></td>
                                </tr>
                                <% } %>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td colspan="3" align="right">&#2351;&#2379;&#2327;</td>
                                    <td><%=TotalAmount %></td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="right">&#2342;&#2375;&#2351; &#2352;&#2367;&#2348;&#2375;&#2335; 15 %</td>
                                    <td><%=(TotalAmount*15)/100 %></td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="right">&#2358;&#2369;&#2343;&#2381;&#2351; &#2350;&#2370;&#2354;&#2381;&#2351;  </td>
                                    <td><%=TotalAmount-((TotalAmount*15)/100 ) %></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1" colspan="3">शब्दों में <%
                                                                           double T = TotalAmount - ((TotalAmount * 15) / 100);
                                                                           dtr2 = comm.FillDatasetByProc("SELECT  AmountToWords(" + T + ")"); %>

                            <%=dtr2.Tables[0].Rows[0][0].ToString () %></td>
                    </tr>
                    <tr>
                        <td colspan="3" align="right">

                            <br />
                            &#2357;&#2366;&#2360;&#2381;&#2340;&#2375; : &#2350;.&#2346;&#2381;&#2352;.&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; 


                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherThanTextbookChallan.aspx.cs" Inherits="Depo_OtherThanTextbookChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <style>
        @font-face {
            font-family: "Free3of9Regular";
            src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");
            font-weight: normal;
            font-style: normal;
        }

        .BarCode {
            font-family: Free3of9Regular; font-size: 90px; padding: 10px; line-height: 80px;
        }

        @media print {
            .page-break {
                display: block;
                page-break-before: always;
                padding-top: 40px;
                height: 802px;
                margin: 50px auto;
                text-align: center;
                font: normal 12px arial;
                line-height: 16px;
            }
        }

        .floatleft {
            float: left;
            width: 50%;
            text-align: center;
            margin-top: 120px;
        }

        .page-break ul {
            margin: 0;
            padding: 0;
        }

            .page-break ul li {
                float: left;
                width: 50%;
                text-align: center;
                list-style: none;
                height: 300px;
            }

        .cleardiv {
            clear: both;
            margin-top: 120px;
        }
    </style>
     <div class="card-header">
        <h2>
            &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
    </div>

    <table width="100%" style="align-content: center">
        <tr id="aaaa" runat="server">
            <td>
                <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Challan No</span></td>
            <td>
                <asp:DropDownList ID="ddlChallan" runat="server" OnSelectedIndexChanged="ddlChallan_SelectedIndexChanged">
                </asp:DropDownList>
                <b>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                                </b>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Show " CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
        </table> 
    
    
    <div id="ExportDiv1" runat="server" visible="false" >


                        <table width="100%">
                            <tr>
                                <td align="center"><b>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
                                    <br />
                                    &nbsp;<asp:Label ID="lblAddress1" runat="server"></asp:Label>
                                    <br />
                                </b>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;&#2348;&#2352; : <b>
                                    <asp:Label ID="lblphone1" runat="server"></asp:Label>
                                    , &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; :<asp:Label ID="lblmobileNo1" runat="server"></asp:Label>
                                    &nbsp;
&nbsp;</b>,&#2312;&#2350;&#2375;&#2354; &#2310;&#2312;&#2337;&#2368; : <b>
    <asp:Label ID="lblemailID1" runat="server"></asp:Label>
    &nbsp;,</b>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : http://mptbc.nic.in</td>
                            </tr>
                            <tr>
                                <td>&nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<b><asp:Label ID="lblfyYaer1" runat="server"></asp:Label>
                                </b>
                                    &nbsp;&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
                                        <asp:Label ID="lblDate1" runat="server"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" ><span class="auto-style1">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2330;&#2366;&#2354;&#2366;&#2344;</span><span class="BarCode"><%=ds2.Tables[0].Rows[0]["ChallanNo_V"].ToString()%></span> <asp:Label ID="Label41" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="tab">
                            <tr>
                                <th width="20%"></th>      
                                    <th align="left"><%=ds2.Tables[0].Rows[0]["BlockName"].ToString()%>
                                    </th>
                                    <th width="20%">&#2332;&#2367;&#2354;&#2366; / District:
                                    </th>
                                    <th align="left">
                                        <%=ds2.Tables[0].Rows[0]["DistName"].ToString()%></th>
                            </tr>
                        </table>
                        <table class="tab">
                            <tr>
                                <td align="right" width="21%">
                                   
                                </td>
                                <td>&#2351;&#2379;&#2332;&#2344;&#2366; / Yojna
                                   
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" width="21%">
                                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;   
                                </td>
                                <td><%=ds2.Tables[0].Rows[0]["ChallanNo_V"].ToString()%> , <%=ds2.Tables[0].Rows[0]["ChallanDate_D"].ToString()%> </td>
                                <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  <%=ds2.Tables[0].Rows[0]["GRNO_V"].ToString()%> , <%=ds2.Tables[0].Rows[0]["GRNODate_D"].ToString()%> </td>
                            </tr>
                        </table>

                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" OnRowDataBound="GridView2_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No. &lt;/br&gt;(1)">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;  &lt;/br&gt;(2)">
                                    <ItemTemplate>
                                        <%#Eval("mTitle_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;   &lt;/br&gt;(3)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl11" runat="server" Text='<%#Eval("PradayBooks")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &lt;/br&gt;(4)">
                                    <ItemTemplate>
                                        <%#Eval("PerBundleBook")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354;  &lt;/br&gt;(5)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl12" runat="server" Text='<%#Eval("NoofPaikBandal")%>'></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &lt;br&gt; (6)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl002" runat="server" Text='<%# Eval("NoOfLooj").ToString()=="0" ? 0  : 1 %>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>

                              <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;   &lt;/br&gt;(7)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl13" runat="server" Text='<%#Eval("NoOfLooj")%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; (8)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl003" runat="server" Text='  <%#Convert.ToInt32(Eval("NoofPaikBandal"))+ Convert.ToInt32(Eval("NoOfLooj").ToString()=="0" ? 0  : 1)%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <EmptyDataTemplate>
                                Data Not Found ............
                            </EmptyDataTemplate>
                        </asp:GridView><br />
                         <table border="1" width="60%">
                               <tr>
                                            <td>Pack Bundle :</td>
                                            <td><%=a3%></td>
                                        </tr>
                             <tr>
                                            <td>Lose Bundle :</td>
                                            <td><%=a5%></td>
                                        </tr>
                               <tr>
                                            <td>Total Bundle :</td>
                                            <td><%=a6%></td>
                                        </tr>
                                        <tr>
                                            <td>Truck NO :</td>
                                            <td><%=ds2.Tables[0].Rows[0]["TruckNo_V"].ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Driver Name/Mobile No :</td>
                                            <td><%=ds2.Tables[0].Rows[0]["DriverMobileNo_V"].ToString()%></td>
                                        </tr>
                                       <tr>
                                            <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;  :</td>
                                            <td><%=ds2.Tables[0].Rows[0]["Remark"].ToString()%></td>
                                        </tr>
                               <tr>
                                            <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  :</td>
                                            <td><%=ds2.Tables[0].Rows[0]["Receivedate"].ToString()%></td>
                                        </tr>
                                    </table>
                        <br /><br /><br />
                          <table border="0" width="100%">
                              
                              
                              <tr>
                                            <td> </td>
                                            <td>&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; /&#2360;&#2381;&#2335;&#2379;&#2352; &#2325;&#2368;&#2346;&#2352; </td>
                                        </tr>
                              <tr>
                                            <td> &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; &#2319;&#2357;&#2306; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; &#2360;&#2361;&#2367;&#2340; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352;</td>
                                            <td>&nbsp;</td>
                                        </tr></table> 
                       
                    </div>
      <asp:Button ID="Button2" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel1();" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; /Print" />
              <script type="text/javascript">
                  function PrintPanel1() {
                      var panel = document.getElementById("<%=ExportDiv1.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('<style> @font-face {src: url("BarCodeFont/FREE3OF9.eot?") format("eot"),url("BarCodeFont/FREE3OF9.woff") format("woff"), url("BarCodeFont/FREE3OF9.ttf") format("truetype"), url("BarCodeFont/FREE3OF9.svg#Free3of9") format("svg");font-family: Free3of9Regular;font-weight: normal;font-style: normal;}');
            printWindow.document.write('.BarCode { font-family: Free3of9Regular; font-size: 90px; padding: 10px; line-height: 80px; }</style>');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<link href="style.css" rel="stylesheet" type="text/css" />');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>   
</asp:Content>


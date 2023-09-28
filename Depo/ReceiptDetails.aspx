<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceiptDetails.aspx.cs" Inherits="Depo_ReceiptDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </h2>
    </div>

    <table width="100%" style="align-content: center">
        <tr id="aaaa" runat="server">
            <td>
                <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Challan No</span></td>
            <td>
                <asp:DropDownList ID="ddlChallan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChallan_SelectedIndexChanged">
                </asp:DropDownList>
                <b>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                                </b>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr runat="server">
            <td>&#2360;&#2381;&#2325;&#2368;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
            <td>
                <asp:DropDownList ID="ddlScheme" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Show " CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="a" runat="server" visible="false">
                    <%if (ds != null)
                      { %>
                    <div id="ExportDiv" runat="server">
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
                                    &nbsp;&nbsp;&nbsp;&nbsp; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; : <b>
                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                    </b>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; :<span class="BarCode"><%=ds.Tables[0].Rows[0]["ChallanID"].ToString()%></span>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                        </table>
                         
                        <table class="tab">
                            <tr>
                                <th>&#2348;&#2368;.&#2310;&#2352;.&#2360;&#2368;. / BRC      
                                    <th><%=ds.Tables[0].Rows[0]["BlockName_V"].ToString()%>
                                    </th>
                                    <th>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Challan No.
                                    </th>
                                    <th>
                                        <%=ds.Tables[0].Rows[0]["ChallanID"].ToString()%></th>
                                    <th>&#2330;&#2366;&#2354;&#2366;&#2344;
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Challan Date</th>
                                    <th>
                                        <%=ds.Tables[0].Rows[0]["ChallanDate_D"].ToString()%></th>
                            </tr>
                            <tr>
                                <td>
                                    <%=ds.Tables[0].Rows[0]["SchemeName_Hindi"].ToString()%> 
                                </td>
                                <td></td>
                                <td>&#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Type
                                </td>
                                <td>&#2351;&#2379;&#2332;&#2344;&#2366; / Yojna</td>
                                <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; / Bilti No.
                                </td>
                                <td><%=ds.Tables[0].Rows[0]["GRNO_V"].ToString()%>
                                </td>
                            </tr>
                        </table>

                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name " DataField="TitleHindi_V" />
                                <asp:BoundField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2344; / Allotment" DataField="DestributeBook" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Per Bundle Books Quantity " DataField="PerBandlbook" />
                                <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354;  / Pack Bundle" DataField="PaikBandal" />
                                <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354;/ Loose Bundle" DataField="LoojBandalT" />
                                <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books" DataField="LoojBandal" />
                                <asp:BoundField HeaderText="&#2325;&#2369;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Total Book" DataField="TotalBook" />
                                <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; / Total Bundle" DataField="TotalBnadal" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <EmptyDataTemplate>
                                Data Not Found ............
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <table width="100%">
                            <tr>
                                <td>
                                    <table border="1" width="50%">
                                        <tr>
                                            <td>Pack Bundle  
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Lose Bundle</td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Total Bundle</td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table border="1" width="50%">
                                        <tr>
                                            <td>Truck NO </td>
                                            <td><%=ds.Tables[0].Rows[0]["TruckNo_V"].ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Driver Name/Mobile No</td>
                                            <td><%=ds.Tables[0].Rows[0]["DriverMobileNo_V"].ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; : 
                                    <%=ds.Tables[0].Rows[0]["Remark"].ToString()%> </td>
                            </tr>
                            <tr>
                                <td colspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; 
                                  : <%=ds.Tables[0].Rows[0]["RemarkDate"].ToString()%> </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                        </table>
                    </div>
                    <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel();" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; /Print" />
                    <asp:Button ID="Button3" runat="server" CssClass="btn_gry" OnClick="Button2_Click" Text="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;/Print Bundle No" />
                    <%} %>
                </div>

                <div id="divB" runat="server" visible="false">
                    <%if (ds2 != null)
                      { %>
                    <div id="ExportDiv1" runat="server">


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
                                <th width="20%">BRC:      
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
                                    <%=ds2.Tables[0].Rows[0]["MediunNameHindi"].ToString()%> 
                                </td>
                                <td>&#2351;&#2379;&#2332;&#2344;&#2366; / Yojna
                                    <%=ddlScheme.SelectedItem.Text%>
                                </td>
                                <td>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340;/ Distributed</td>
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
                                 <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  &lt;/br&gt;(3)">
                                    <ItemTemplate>
                                        <%#Eval("PerBundleBook")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  &lt;/br&gt;(4)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl1" runat="server" Text='<%#Eval("oneA")%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2342;&#2352;&#2360;&#2366; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &lt;/br&gt;(5)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl2" runat="server" Text='<%#Eval("TwoA")%>'></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="&#2360;&#2306;&#2360;&#2381;&#2325;&#2371;&#2340; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  &lt;/br&gt;(6)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl3" runat="server" Text='<%#Eval("ThreeA")%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2313;&#2352;&#2381;&#2342;&#2370; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  &lt;/br&gt;(7)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl4" runat="server" Text='<%#Eval("ForA")%>'></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                       
                              <asp:TemplateField HeaderText="&#2313;&#2352;&#2381;&#2342;&#2370; &#2349;&#2366;&#2359;&#2366; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  &lt;/br&gt;(8)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl5" runat="server" Text='<%#Eval("FiveA")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  &lt;/br&gt;(9)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl6" runat="server" Text='<%#Eval("sixA")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2352;&#2366;&#2336;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  &lt;/br&gt;(10)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl7" runat="server" Text='<%#Eval("Sevan")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2361;&#2367;&#2306;&#2342;&#2368; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340;  &lt;/br&gt;(11)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl8" runat="server" Text='<%#Eval("Eight")%>'></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &lt;/br&gt;(12)">
                                    <ItemTemplate>
                                          <asp:Label ID="lbl9" runat="server" Text='<%#Eval("nine")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="&#2351;&#2379;&#2327;  &lt;/br&gt;(13)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl10" runat="server" Text='<%#Eval("TotalBooks")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;   &lt;/br&gt;(14)">
                                    <ItemTemplate>
                                         <asp:Label ID="lbl11" runat="server" Text='<%#Eval("PradayBooks")%>'></asp:Label>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354;  &lt;/br&gt;(15)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl12" runat="server" Text='<%#Eval("NoofPaikBandal")%>'></asp:Label>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="लूज बंडल <br> (16)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl002" runat="server" Text='<%# Eval("NoOfLooj").ToString()=="0" ? 0  : 1 %>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>

                              <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;   &lt;/br&gt;(17)">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl13" runat="server" Text='<%#Eval("NoOfLooj")%>'></asp:Label>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" कुल बंडल (18)">
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
                                            <td>रिमार्क  :</td>
                                            <td><%=ds2.Tables[0].Rows[0]["Remark"].ToString()%></td>
                                        </tr>
                               <tr>
                                            <td>प्राप्ति दिनांक  :</td>
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
                        <%--<table width="100%">
                            <tr>
                                <td>
                                    <table border="1" width="50%">
                                        <tr>
                                            <td>Pack Bundle  
                                                <td>
                                                    <asp:Label ID="Label12" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Lose Bundle</td>
                                            <td>
                                                <asp:Label ID="Label13" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>Total Bundle</td>
                                            <td>
                                                <asp:Label ID="Label14" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table border="1" width="50%">
                                        <tr>
                                            <td>Truck NO </td>
                                            <td><%=ds.Tables[0].Rows[0]["TruckNo_V"].ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Driver Name/Mobile No</td>
                                            <td><%=ds.Tables[0].Rows[0]["DriverMobileNo_V"].ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; : 
                                    <%=ds.Tables[0].Rows[0]["Remark"].ToString()%> </td>
                            </tr>
                            <tr>
                                <td colspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; 
                                  : <%=ds.Tables[0].Rows[0]["RemarkDate"].ToString()%> </td>
                            </tr>
                            <tr>
                                <td colspan="2"></td>
                            </tr>
                        </table>--%>
                    </div>
                    <asp:Button ID="Button2" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel1();" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; /Print" />
                   <%-- <asp:Button ID="Button4" runat="server" CssClass="btn_gry" OnClick="Button2_Click" Text="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;/Print Bundle No" />--%>
                    <%} %>
                </div>
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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


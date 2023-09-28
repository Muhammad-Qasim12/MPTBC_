<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BlockChllan.aspx.cs" Inherits="Depo_BlockChllan" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        // Load the Google Transliterate API
        google.load("elements", "1", {
            packages: "transliteration"
        });

        function onLoad() {
            var options = {
                sourceLanguage:
                google.elements.transliteration.LanguageCode.ENGLISH,
                destinationLanguage:
                [google.elements.transliteration.LanguageCode.HINDI],
                //shortcutKey: 'ctrl+g',
                transliterationEnabled: true
            };

            // Create an instance on TransliterationControl with the required
            // options.
            var control =
            new google.elements.transliteration.TransliterationControl(options);

            // Enable transliteration in the textbox with id
            // 'transliterateTextarea'.
            control.makeTransliteratable(['ctl00_ContentPlaceHolder1_TextBox1']);
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);

            function InitializeRequest(sender, args) {
            }

            // this is called to re-init the google after update panel updates.
            function EndRequest(sender, args) {
                onLoad();
            }
        }
        google.setOnLoadCallback(onLoad);
    </script>
    <div class="card-header">
        <h2>
            <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/ Challan Details </span></h2>
    </div>

    <table width="100%">
        <tr>
            <td>
                <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; /Challan No. </span></td>
            <td>
                <asp:DropDownList ID="ddlChallan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChallan_SelectedIndexChanged">
                </asp:DropDownList>
                <span>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                </span>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&#2360;&#2381;&#2325;&#2368;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350;  </td>
            <td>
                <asp:DropDownList ID="ddlScheme" runat="server" OnSelectedIndexChanged="ddlScheme_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Show " CssClass="btn" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <div id="a" runat="server" visible="false">
                    
                    <%if (ds != null)
                      { %>
                    <div id ="ExportDiv" runat="server" >
                    <table class="tab">
                        <tr>
                            <th>&#2348;&#2368;.&#2310;&#2352;.&#2360;&#2368;. / BRC      
                                <th><%=ds.Tables[0].Rows[0]["BlockName_V"].ToString()%>
                                </th>
                                <th>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Challan No.
                                </th>
                                <th>
                                    <%=ds.Tables[0].Rows[0]["ChallanID"].ToString()%></th>
                                <th>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date</th>
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
                            <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; / Pack Bundle" DataField="PaikBandal" />
                            <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354;/ Loose Bundle" DataField="LoojBandalT" />
                            <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books" DataField="LoojBandal" />
                            <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; / Total Book" DataField="TotalBook" />
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
                                            <td><%=ds1.Tables[0].Rows[0]["PaikBandal"].ToString()%></td>
                                    </tr>
                                    <tr>
                                        <td>Lose Bundle</td>
                                        <td><%=ds1.Tables[0].Rows[0]["LoojBandal"].ToString()%></td>
                                    </tr>
                                    <tr>
                                        <td>Total Bundle</td>
                                        <td><%=ds1.Tables[0].Rows[0]["TotalBandal"].ToString()%></td>
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
                      
                    </table></div>
                    <%} %>
                    <asp:Button ID="Button5" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel();" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; /Print" />
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
                                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; :
            <asp:Label ID="Label41" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="tab">
                            <tr>
                                <th width="20%">&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2339;&#2381;&#2337; &#2325;&#2366; &#2344;&#2366;&#2350; / Block Name:      
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
                        </table>

                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                            CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name " DataField="mTitle_V" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354;  &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Per Bundle Books Quantity " DataField="PerBundleBook" />
                                <asp:BoundField HeaderText="&#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Hindi Medium " DataField="oneA" />
                                <asp:BoundField HeaderText="&#2350;&#2342;&#2352;&#2360;&#2366; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Madrasa Medium " DataField="TwoA" />
                                <asp:BoundField HeaderText="&#2360;&#2306;&#2360;&#2381;&#2325;&#2371;&#2340; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Sanskrit Medium " DataField="ThreeA" />
                                <asp:BoundField HeaderText="&#2313;&#2352;&#2381;&#2342;&#2370; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Urdu Medium " DataField="ForA" />
                                <asp:BoundField HeaderText="&#2313;&#2352;&#2381;&#2342;&#2370; &#2349;&#2366;&#2359;&#2366; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Urdu Language Medium " DataField="FiveA" />
                                <asp:BoundField HeaderText="&#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / English Medium " DataField="sixA" />
                                <asp:BoundField HeaderText="&#2350;&#2352;&#2366;&#2336;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Marathi Medium " DataField="Sevan" />
                                <asp:BoundField HeaderText="&#2361;&#2367;&#2306;&#2342;&#2368; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; / Hindi Additional " DataField="Eight" />
                                <asp:BoundField HeaderText="&#2311;&#2306;&#2327;&#2381;&#2354;&#2367;&#2358; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; / English Additional " DataField="nine" />
                                <asp:BoundField HeaderText="&#2351;&#2379;&#2327; / Total Book" DataField="TotalBooks" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Distributed Book" DataField="PradayBooks" />
                                <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354;  / Pack Bundle" DataField="NoofPaikBandal" />

                                <%--<asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354;/ Loose Bundle" DataField="LoojBandalT" />--%>
                                <%--<asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books" DataField="LoojBandal" />
                                <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; / Total Bundle" DataField="TotalBnadal" />--%>
                                <asp:BoundField DataField="NoOfLooj" HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <EmptyDataTemplate>
                                Data Not Found ............
                            </EmptyDataTemplate>
                        </asp:GridView>
                      
                    </div>
                    <asp:Button ID="Button3" runat="server" CssClass="btn_gry" OnClientClick="return PrintPanel1();" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; /Print" />
                    <asp:Button ID="Button4" runat="server" CssClass="btn_gry" OnClick="Button2_Click" Text="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;/Print Bundle No" Visible="False" />
                    <%} %>
                </div>
            </td>
        </tr>
    </table>
    <table id="MasterChallan" runat="server" visible="false" width="100%" >
        <tr>
                            <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                            <td> <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox" ></asp:TextBox> 
                                 <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="TextBox2" Format="dd/MM/yyyy">
        </cc1:CalendarExtender></td>
                        </tr> <tr>
                            <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Height="63px" TextMode="MultiLine" Width="269px">&#2313;&#2346;&#2352;&#2379;&#2325;&#2381;&#2340;  &#2330;&#2366;&#2354;&#2366;&#2344; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352;  &#2348;&#2306;&#2337;&#2354; &#2360;&#2361;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352; &#2354;&#2367;&#2319; &#2327;&#2319; &#2361;&#2376; </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                            </td>
                        </tr></table>
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

    <script type="text/javascript">
        function PrintPanel1() {
            var panel = document.getElementById("<%=ExportDiv1.ClientID %>");

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


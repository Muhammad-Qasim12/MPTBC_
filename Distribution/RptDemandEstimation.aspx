<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="RptDemandEstimation.aspx.cs" Inherits="Distrubution_RptDemandEstimation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= ChkClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove All";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All";
            }
            // alert(document.getElementById('Name').innerHTML);
        }

    </script>
    <script type="text/javascript">
        function Calculation() {
            var grid = document.getElementById("<%= GrdBooksMaster.ClientID%>");
            for (var i = 0; i < grid.rows.length - 1; i++) {
                var txtAmountReceive = $("input[id*=TxtDemandScheme]")
                if (txtAmountReceive[i].value != '') {
                    alert(txtAmountReceive[i].value);
                }
            }
        }
    </script>
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
        }</script>
    <div class="box table-responsive">

        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2325;&#2366; &#2310;&#2306;&#2325;&#2354;&#2344; 
                    /Textbook Demand Estimation 
                </span>
            </h2>
        </div>
        <div class="portlet-content">
            <div class="table-responsive">
                <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                    <asp:Label ID="lblmsg" class="notification" runat="server" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2344;&#2375; &#2325;&#2368; &#2354;&#2367;&#2319; &#2325;&#2371;&#2346;&#2351;&#2366; &#2360;&#2349;&#2368; &#2310;&#2346;&#2381;&#2358;&#2344; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375; / Please Select All Options To View Data ">
                    </asp:Label>
                </asp:Panel>
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
                            <table>
                                <tr>
                                    <td>&#2325;&#2325;&#2381;&#2359;&#2366;
                                                <br />
                                        Class :
                                    </td>
                                    <td style="border: 1px solid  lightgrey">

                                        <label id="Name">&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All </label>
                                        <input type="checkbox" id="chkSelect" value="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " name="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; " onclick="CheckAll(this);" />
                                        <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                                        <asp:CheckBoxList ID="ChkClass" RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left" runat="server">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>

                            </table>

                            <%--<asp:Label ID="LblClass" runat="server" Width="100px">&#2325;&#2325;&#2381;&#2359;&#2366; :</asp:Label>--%>
                            <%-- <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" 
                            onselectedindexchanged="DdlClass_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>--%>
                            <%--<asp:CheckBoxList ID="ChkClass"  RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left"  runat="server"></asp:CheckBoxList>--%>
                      
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
                    </tr>
                    <tr>

                        <td id="tdPrintContent" runat="server" visible="false" colspan="4" style="text-align: center">
                            <asp:Panel ID="Panel1" runat="server" Width="100%">
                                <div id="ExportDiv" runat="server">

                                    <div style="padding: 10px;">

                                        <table width="100%">
                                            <tr>
                                                <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" &#2357;&#2367;&#2340;&#2352;&#2339; (&#2309;) &#2358;&#2366;&#2326;&#2366; "
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">&#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; &#2325;&#2366; &#2310;&#2306;&#2325;&#2354;&#2344;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%;">
                                                    <div style="float: right; padding-right: 20px;">
                                                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :<asp:Label ID="lblYear" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                                <td colspan="2" style="font-size: 16px; font-weight: 200; text-align: center; width: 50%;"></td>
                                                <td style="font-size: 16px; font-weight: 200; text-align: center; width: 25%;">
                                                    <div style="float: right; padding-right: 20px;">
                                                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">
                                                    <asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                                                    <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true"
                                                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" OnRowDataBound="GrdBooksMaster_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br/><br/>S.No" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>.
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;<br/><br/> Book Title " HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <ItemTemplate>
                                                                  <%--  <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblDepoID" runat="server" Text='<%#Eval("DepoID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblAcYearId" runat="server" Text='<%#Eval("AcYearId") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblMedium_I" runat="server" Text='<%#Eval("Medium_I") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblDemandTypeID" runat="server" Text='<%#Eval("DemandTypeID") %>' Visible="false"></asp:Label>--%>
                                                                    <%#Eval("TitleHindi_V")%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    Total :
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;<br></br>
                                                                                <br></br>
                                                                                Demand for Scheme 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(A)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDemandScheme" runat="server" Text='<%# Eval("SchemeOrDemand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFDemandScheme" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;<br></br>
                                                                                <br></br>
                                                                                Demand for General sell 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(B)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDemandOpnMkt" runat="server" Text='<%# Eval("GernalExtrDemand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFDemandOpnMkt" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2325;&#2369;&#2354; &#2350;&#2366;&#2306;&#2327;<br></br>
                                                                                <br></br>
                                                                                Net Demand 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(C=A + B)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotDemand" runat="server" Text='<%# Eval("TotalDemand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFTotDemand" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">
&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; &#2310;&#2357;&#2358;&#2381;&#2325;&#2340;&#2366; &#2325;&#2368; &#2346;&#2370;&#2352;&#2381;&#2340;&#2367; &#2325;&#2375; &#2348;&#2366;&#2342; <br></br>
                                                                              
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl1" runat="server" Text='<%# Eval("Demand_Scheme") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lbl2" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">
                                                                                
&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; &#2310;&#2357;&#2358;&#2381;&#2325;&#2340;&#2366; &#2325;&#2368; &#2346;&#2370;&#2352;&#2381;&#2340;&#2367; &#2325;&#2375; &#2348;&#2366;&#2342; <br></br>
                                                                                <br></br>
                                                                                Demand for General sell 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl3" runat="server" Text='<%# Eval("OpenMtkDemand") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lbl4" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325;<br></br>
                                                                                <br></br>
                                                                                Balance Stock for Scheme 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(D)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblYojnaStock" runat="server" Text='<%# Eval("YojnaStock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFYojnaStock" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2366; &#2360;&#2381;&#2335;&#2377;&#2325;<br></br>
                                                                                <br></br>
                                                                                Balance Stock for Open Sell  
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(E)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOpenStock" runat="server" Text='<%# Eval("OpenMktStock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFOpenStock" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2325;&#2369;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325;<br></br>
                                                                                <br></br>
                                                                                Total Stock 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(F=D+E)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTotStock" runat="server" Text='<%# Eval("TotalStock") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFTotStock" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2344;&#2375;&#2335; &#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327;<br></br>
                                                                                <br></br>
                                                                                Total Demand for Scheme 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(G=A-D)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <%--<asp:Label ID="lblNetDemandScheme" runat="server" Text='<%# (Convert.ToInt32(Eval("SchemeOrDemand"))-Convert.ToInt32(Eval("YojnaStock")))>0? (Convert.ToInt32(Eval("SchemeOrDemand"))-Convert.ToInt32(Eval("YojnaStock"))):0 %>'></asp:Label>--%>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFNetDemandScheme" runat="server"></asp:Label>
                                                                </FooterTemplate>

                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2344;&#2375;&#2335; &#2360;&#2366;&#2350;&#2366;&#2351; &#2361;&#2375;&#2340;&#2369; &#2350;&#2366;&#2306;&#2327; 
                                                                <br></br>
                                                                                <br></br>
                                                                                Total Demand for Open Sell 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(H=B-E)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNetDemandOpen" runat="server" Text='<%# (Convert.ToInt32(Eval("GernalExtrDemand")) - Convert.ToInt32( Eval("OpenMktStock")))>0?(Convert.ToInt32(Eval("GernalExtrDemand")) - Convert.ToInt32( Eval("OpenMktStock"))):0 %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFNetDemandOpen" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="" HeaderStyle-BackColor="LightGray" FooterStyle-Font-Bold="true" FooterStyle-BorderWidth="1px" FooterStyle-BorderStyle="Solid" FooterStyle-BorderColor="Black" ItemStyle-BorderWidth="1px" ItemStyle-BorderStyle="Solid" ItemStyle-BorderColor="Black" HeaderStyle-BorderWidth="1px" HeaderStyle-BorderStyle="Solid" HeaderStyle-BorderColor="Black">
                                                                <HeaderTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td style="height: 100px;">&#2344;&#2375;&#2335; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;<br></br>
                                                                                <br></br>
                                                                                Net Demand 
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>(I=G+H)
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNetDemand" runat="server" Text='<%# ((Convert.ToInt32(Eval("Demand_Scheme"))-Convert.ToInt32(Eval("YojnaStock")))>0? (Convert.ToInt32(Eval("Demand_Scheme"))-Convert.ToInt32(Eval("YojnaStock"))):0) + ((Convert.ToInt32(Eval("OpenMtkDemand")) - Convert.ToInt32( Eval("OpenMktStock")))>0?(Convert.ToInt32(Eval("OpenMtkDemand")) - Convert.ToInt32( Eval("OpenMktStock"))):0) %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblFNetDemand" runat="server"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <PagerStyle CssClass="Gvpaging" />
                                                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                    </asp:GridView>

                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="margin-left: 80px;">
            &nbsp;
        </div>
    </div>
</asp:Content>



<%@ Page Title=" &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;/&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2361;&#2375;&#2340;&#2369; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Paper Demand Of Textbook/Other Than Textbook" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CentralDepotDispatchToPrinter.aspx.cs" Inherits="CenterDepot_CentralDepotDispatchToPrinter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function ValidMobileNo() {
            var MobileNo = document.getElementById("<%=txtMobileNo.ClientID %>").value;
            var FrtChar = MobileNo.substring(0, 1);
            if (MobileNo.length < 10 || MobileNo.length > 10 || FrtChar == 0) {
                alert("Invalid Mobile No.");
                document.getElementById("<%=txtMobileNo.ClientID %>").value = "";
                return false;
            }
            else {
                return true;

            }
        }
        function ValidAmt(id) {
            var Amount = id.value;

            var FrtChar = Amount.substring(0, 1);
            if (FrtChar == "0" || FrtChar == "-") {
                alert("Invalid Amount.");

                id.value = "";
                return false;
            }
            else {
                return true;

            }
        }

    </script>
    <div class="portlet-header ui-widget-header">
        &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;/&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2361;&#2375;&#2340;&#2369; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Paper Demand Of Textbook/Other Than Textbook
    </div>
    <div class="table-responsive">
        <table width="100%">
            <tr>
                <td width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year : </td>
                <td colspan="3" style="height: 10px;">
                      <asp:DropDownList ID="ddlAcYear" Width="250px" runat="server" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
               
            </tr>
            <tr>
                <td colspan="2">
                    <b style="font-weight: bold;">&#2346;&#2375;&#2346;&#2352; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;/&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368;
                        <br />
                        Paper Demand Of Textbook<br />/Other Than Textbook&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>


                    &nbsp;<asp:DropDownList runat="server" ID="ddlDemandType" Width="250px"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlDemandType_SelectedIndexChanged">
                        <asp:ListItem Text="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;"></asp:ListItem>
                        <asp:ListItem Text="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368;"></asp:ListItem>

                    </asp:DropDownList>

                </td>
                <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Printer Name
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlPrinter" Width="250px" OnInit="ddlPrinter_Init"
                        CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&#2325;&#2366;&#2327;&#2332; &#2313;&#2336;&#2366;&#2344;&#2375; &#2361;&#2375;&#2340;&#2369; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                    Paper Order No.
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlOrderNo" Width="250px"
                        CssClass="txtbox reqirerd"
                        OnSelectedIndexChanged="ddlOrderNo_SelectedIndexChanged"
                        AutoPostBack="True">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&#2325;&#2366;&#2327;&#2332; &#2313;&#2336;&#2366;&#2344;&#2375; &#2361;&#2375;&#2340;&#2369; &#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                    Paper Order Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtOrderDate" onkeypress="tbx_fnAlphaNumeric(event, this);" ReadOnly="true" CssClass="txtbox reqirerd" MaxLength="15"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                    Challan No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtChallanNo" onkeypress="tbx_fnUserName(event, this);" CssClass="txtbox reqirerd" MaxLength="20"
                        Width="238px"></asp:TextBox>
                </td>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                    Challan Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtChallanDate" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366;  &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;.<br />
                    Mobile No Of Driver
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtMobileNo" onblur="return ValidMobileNo();" onkeypress='javascript:tbx_fnInteger(event, this);'
                        CssClass="txtbox" MaxLength="10" Width="238px"></asp:TextBox>
                </td>
                <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Name Of Driver
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDriverName" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' CssClass="txtbox" MaxLength="100"
                        Width="238px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&#2335;&#2381;&#2352;&#2325; &#2344;.<br />
                    Truck No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtTruckNo" onkeypress="tbx_fnAlphaNumeric(event, this);" CssClass="txtbox reqirerd" MaxLength="15"
                        Width="238px"></asp:TextBox>
                </td>
                <td>&#2332;&#2368; &#2310;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                    GR Date
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGrDate" CssClass="txtbox reqirerd" MaxLength="10"
                        Width="238px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtGrDate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>&#2332;&#2368; &#2310;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                    GR No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtGrNo" onkeypress="tbx_fnUserName(event, this);" CssClass="txtbox reqirerd" MaxLength="20"
                        Width="238px"></asp:TextBox>
                </td>
                <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360;<br />
                    Warehouse
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlWareHouse" Width="250px" OnInit="ddlWareHouse_Init"
                        CssClass="txtbox reqirerd">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>&#2348;&#2381;&#2354;&#2366;&#2325; &#2344;&#2306;&#2348;&#2352;<br />
                    Block No.
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtBlockNo" CssClass="txtbox" MaxLength="15" onkeypress="tbx_fnAlphaNumeric(event, this);"
                        Width="238px"></asp:TextBox>
                </td>
                <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
                    <br />
                    Remark</td>
                <td>
                    <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="255px" MaxLength="150"
                        onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>

                </td>
            </tr>
             <tr>
                <td > &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br />
                    Title Name.
                </td>
                <td>
                    
                    <asp:DropDownList ID="ddlTitle" runat="server"  CssClass="txtbox"></asp:DropDownList>
                </td>
                <td> &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; 
                    <br />
                    Supplier Name </td>
                <td>
                     <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="txtbox"></asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                        OnRowDataBound="GrdWorkPlan_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br><br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                     <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br><br>Paper Type">
                                <ItemTemplate>
                                    <%#Eval("PaperType")%>
                                    <asp:Label ID="lblDisDtl_Id" runat="server" Text='<%#Eval("PrinterDisDtl_Id")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblDisTranId" runat="server" Text='<%#Eval("PrinterDisTranId")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPerSheetWt" runat="server" Text='<%#Eval("PerSheetWt")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaperCategory" runat="server" Text='<%#Eval("PaperCategory")%>'></asp:Label>
                                    <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblOrderTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>' Visible="false"></asp:Label>
                                    <asp:Label ID="lblReqTotalSheets" runat="server" Text='<%#Eval("ReqTotSheets")%>' Visible="false"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br><br>Paper Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br><br>Name Of Paper Mill">
                                <ItemTemplate>
                                    <asp:DropDownList runat="server" ID="ddlVenderFill" CssClass="txtbox ">
                                        <asp:ListItem Text="Select"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;(&#2350;&#2375;. &#2335;&#2344;)<br><br>Demand Of Paper(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblPrinterSendQty" runat="server" Text='<%#Eval("PaperQty_N")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2369;&#2354;(&#2350;&#2375;. &#2335;&#2344;)<br><br>Total Supply(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotSend" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2375;&#2359;(&#2350;&#2375;. &#2335;&#2344;)<br><br>Total Remaining(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemainQty" runat="server" Text="0"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2375;&#2359; &#2358;&#2368;&#2335;(&#2350;&#2375;. &#2335;&#2344;) <br> Total Remaining Sheets(Metric Ton)">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotSheets" runat="server" Text='<%#Eval("TotSheets")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354;/&#2352;&#2368;&#2354;<br><br>Total Supply Bundle / Reel">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtNoOfReels" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                        CssClass="txtbox " MaxLength="12" Width="70px" ReadOnly="true" runat="server" Text='<%#Eval("NoOfReels")=="" ? 0 : Eval("NoOfReels")%>' AutoPostBack="true" OnTextChanged="txtNoOfReels_TextChanged"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br><br>Supply Quantity(Metric Ton)">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtSendQty" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                        CssClass="txtbox " MaxLength="12" runat="server" ReadOnly="true" Width="70px" Text='<%#Eval("SendQty")=="" ? 0 : Eval("SendQty")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2332;&#2379;&#2396;&#2375; &#2348;&#2306;&#2337;&#2354;/&#2352;&#2368;&#2354;<br>Add Bundle/Reel">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnAddChallanDetails" Text="&#2332;&#2379;&#2396;&#2375; / Add"
                                        CssClass="btn" OnClick="btnAddChallanDetailse_Click" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>

            <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <cc1:CalendarExtender ID="txtChallanDate_CalendarExtender" runat="server" TargetControlID="txtChallanDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 750px; margin-left: -12%; margin-top: -5%">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
        </div>
        <div style="min-height: 100px; max-height: 500px; overflow: auto;">
            <table width="100%">
                <tr>
                    <th colspan="4" style="font-weight: bold;" class="portlet-header ui-widget-header">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;/&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2361;&#2375;&#2340;&#2369; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Paper Demand Of Textbook/Other Than Textbook
                    </th>
                </tr>

                <tr>
                    <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                        Name Of Paper Mill 
                    </td>
                    <td style="font-weight: bold;">
                        <asp:Label ID="lblPaperMIllName" runat="server"></asp:Label>
                        <asp:Label ID="lblMPaperMIllNameID" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblPprid" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblCheckFlag" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblPaperDemand" runat="server" Visible="false"></asp:Label>

                        <asp:Label ID="lblOrderTotSheet" runat="server" Visible="false"></asp:Label>
                    </td>
                    <td>&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br />
                        Paper Size
                    </td>

                    <td style="font-weight: bold;">
                        <asp:Label ID="lblMPaperSize" runat="server"></asp:Label>

                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="lblPaperlbl" runat="server" Text="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;(&#2350;&#2375;. &#2335;&#2344;)<br /> Demand Of Paper(Metric Ton)"></asp:Label>

                    </td>

                    <td style="font-weight: bold;">
                        <asp:Label ID="lblTotWtQty" runat="server"></asp:Label>

                    </td>
                    <td>&#2352;&#2379;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                        Role No :
                    </td>
                    <td style="font-weight: bold;">
                        <asp:TextBox ID="txtRoleNo" runat="server" Width="100px" MaxLength="30"></asp:TextBox>


                        <asp:Button runat="server" ID="btnShowDtl" Text="View"
                            CssClass="btn" OnClick="btnShowDtl_Click" />
                    </td>

                </tr>

                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvRoleDetails" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblActTotalSheets" runat="server" Text='<%#Eval("ActTotalSheets")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;<br>Role No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2358;&#2375;&#2359;(&#2350;&#2375;. &#2335;&#2344;) <br> Total Sheets">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)<br>Net Weight(K.G.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>' ></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)<br>Gross Weight(K.G.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>

                </tr>

            </table>
            <table width="100%">
                <tr>
                    <td id="tdsheet1" runat="server" visible="false">&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;&#2375;
                    <br />
                        Total Dispatch
                    </td>
                    <td id="tdsheet2" runat="server" visible="false">
                        <asp:TextBox ID="txtTotalSheets" runat="server" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Width="100px" MaxLength="10" Text="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RqtxtTotalSheets" ForeColor="Red" runat="server"
                            ErrorMessage="Please enter sheets." InitialValue="0" ControlToValidate="txtTotalSheets"
                            Text="*" ValidationGroup="sheet"></asp:RequiredFieldValidator>


                    </td>
                    <td style="text-align: center;">
                        <asp:Button runat="server" ID="btnRoleAdd" Visible="false" ValidationGroup="sheet" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                            CssClass="btn" OnClick="btnRoleAdd_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: center;">

                        <asp:GridView ID="GrdChallanReel" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." ShowFooter="true" Width="100%" AllowPaging="false"
                            OnRowDataBound="GrdChallanReel_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%-- <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                <ItemTemplate>
                                    <%#Eval("PaperType")%>
                                   

                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                <ItemTemplate>
                                    <asp:Label ID="lblPaperMillname" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335;  <br> Total Sheets">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;<br>Role No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Net Weight(M.T.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Gross Weight(M.T.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>

                    </td>
                </tr>

            </table>
        </div>
    </div>
    <script type="text/javascript">
        function OpenBill() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDiv').style.display = "block";

        }
    </script>
</asp:Content>


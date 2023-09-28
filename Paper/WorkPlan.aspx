<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="WorkPlan.aspx.cs" Inherits="Paper_WorkPlan" Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2319;&#2357;&#2306; &#2357;&#2352;&#2381;&#2325; &#2346;&#2381;&#2354;&#2366;&#2344;  / Paper Mill Agreement and Work Plan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>
                    <%--Vendor Agreement Work Plan--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2319;&#2357;&#2306; &#2357;&#2352;&#2381;&#2325; &#2346;&#2381;&#2354;&#2366;&#2344;  / Paper Mill Agreement and Work Plan
                </span>
            </h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Academic Year
                    </td>
                    <td>
                        <asp:Label ID="lblAcYear" runat="server" Visible="false"></asp:Label>
                        <asp:DropDownList runat="server" ID="DdlACYear" Width="262px"
                            CssClass="txtbox reqirerd">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>

                <tr>
                    <td>
                        <%--Select Vendor (--%>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                        Name Of Paper Mill
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" OnInit="ddlVendor_Init"
                            CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                        L.O.I No.
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px" AutoPostBack="True"
                            CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlLOINo_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="Panel1" runat="server" BorderColor="gray" BorderStyle="solid" BorderWidth="1px">
                            <table width="100%">
                                <tr>
                                    <td colspan="4" style="height: 10px;"></td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.<br />
                                            Tender No.</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTenderNo" runat="server"></asp:Label>
                                    </td>
                                    <td><b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                                        <br />
                                        Tender Name</b></td>
                                    <td>
                                        <asp:Label ID="lblTenderName" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--LOI To. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2346;&#2381;&#2352;&#2340;&#2367;<br />
                                            L.O.I To</b>
                                    </td>
                                    <td colspan="3">
                                        <asp:Label ID="lblLOITO" runat="server"></asp:Label>
                                    </td>
                                    <%--<td><b>LOI No. (&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2344;&#2306;.)</b></td>
    <td></td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        <b>
                                            <%--LOI Date (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                                            L.O.I Date
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLOIDate" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <b>
                                            <%--Address (--%>&#2346;&#2340;&#2366;
                                            <br />
                                            Address</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="height: 10px; font-weight: bold;">&#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2342;&#2352;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<br />
                                        Rates Per Metric Ton in Rupees
                                    </td>
                                    <td style="height: 10px; font-weight: bold;">
                                        <asp:Label ID="lblRate" runat="server"></asp:Label>
                                    </td>
                                    <td style="font-weight: bold;">&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2381;&#2352;.<br />
                                        Agreement No.</td>
                                    <td>
                                        <asp:Label ID="lblAgreementNo" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td colspan="1" style="height: 10px; font-weight: bold;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2361;&#2375;&#2340;&#2369; &#2330;&#2366;&#2361;&#2368; &#2327;&#2312; &#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366;(&#2350;&#2375;. &#2335;&#2344;)
                                        <br />
                                       </td>
                                    <td colspan="1" style="height: 10px; font-weight: bold;">
                                        <asp:Label ID="lblqty" runat="server" Text=""></asp:Label></td>
                                      <td colspan="1" style="height: 10px; font-weight: bold;">&#2350;&#2367;&#2354; &#2325;&#2379; &#2310;&#2348;&#2306;&#2335;&#2367;&#2340; &#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)
                                        <br />
                                      </td>
                                    <td colspan="2" style="height: 10px; font-weight: bold;">
                                          <asp:Label ID="lblallotedqty" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="tab">
                            <tr>
                                <th>
                                    <%--Paper Category--%>&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br />
                                    Paper Type
                                </th>
                                <th>
                                    <%--Paper Size--%>
                                     	&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br />
                                    Paper Size
                                </th>
                                <th>
                                    <%--Paper Quantity(In Tn.)--%>&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br />
                                    Paper Quantity(Metric Ton)
                                </th>
                                <th>
                                    <%--Target Supply Date--%>&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<br />
                                    Total Amount(Metric Ton in Rupees)
                                </th>
                                <th>
                                    <%--Target Supply Date--%>&#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br />
                                    Order NO.
                                </th>
                                <th>
                                    <%--Target Supply Date--%>&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />
                                    Order Date
                                </th>
                                <th>&#2346;&#2381;&#2352;&#2366;&#2352;&#2306;&#2349;&#2367;&#2325; &#2340;&#2367;&#2341;&#2367;<br />
                                    Start Date
                                </th>
                                <th>&#2309;&#2306;&#2340;&#2367;&#2350; &#2340;&#2367;&#2341;&#2367;<br />
                                    Last Date
                                </th>
                                <th></th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddlPaperType" runat="server" Width="200px" CssClass="txtbox reqirerd"
                                        AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged"
                                        OnInit="ddlPaperType_Init">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" ID="ddlPaperSize" CssClass="txtbox reqirerd" Width="200px">
                                        <asp:ListItem>Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtPaperQty" CssClass="txtbox reqirerd" AutoPostBack="true" OnTextChanged="txtPaperQty_TextChanged" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                        Width="100px" MaxLength="12"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtTotAmt" CssClass="txtbox reqirerd" ReadOnly="true"
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="lblorderNo" CssClass="txtbox reqirerd" ReadOnly="false"
                                        Width="100px"></asp:TextBox>
                                    <%--  <asp:Label  runat="server" ID="lblorderNo" CssClass="txtbox " 
                                        Width="100px" MaxLength="12"></asp:Label>--%>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtDate" CssClass="txtbox reqirerd" MaxLength="10"
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtStartDate" CssClass="txtbox reqirerd" MaxLength="10"
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtSupplyTillDate" CssClass="txtbox reqirerd" MaxLength="10"
                                        Width="100px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                                        OnClientClick="return ValidateAllTextForm();" CssClass="btn" OnClick="btnSave_Click" />
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="WorkPlanTrId_I" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false" OnRowDataBound="GrdWorkPlan_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblWorkPlanTrId_I" runat="server" Text='<%#Eval("WorkPlanTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2350;&#2375;. &#2335;&#2344;)<br>Paper Quantity(Metric Ton)">
                                    <ItemTemplate>

                                        <asp:Label ID="lblPaperQuantity_N" runat="server" Text='<%#Eval("PaperQuantity_N")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2351;&#2375; / &#2350;&#2375;. &#2335;&#2344;)<br>Total Amount(Metric Ton in Rupees)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotAmt" runat="server" Text='<%#Eval("TotAmount")%>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <b> Order NO.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblItmOrderNo" runat="server" Text='<%#Eval("OrderNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br>Order Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupplyDate_D" runat="server" Text='<%#Eval("SupplyDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2352;&#2306;&#2349;&#2367;&#2325; &#2340;&#2367;&#2341;&#2367; <br>Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("StartDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2340;&#2367;&#2341;&#2367; <br>Last Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEndDate_D" runat="server" Text='<%#Eval("SupplyTillDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" Visible='<%# Eval("D").ToString()=="1" ? false  : true %>'  runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;/Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" Visible="false" >
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" Visible='<%# Eval("D").ToString()=="1" ? false  : true %>'  OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                 <tr>
                     <td >
                 <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a> 
                 </td></tr>
            </table>
        </div>
    </div>
    <cc1:CalendarExtender ID="CalendartxtStartDate" runat="server" TargetControlID="txtStartDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSupplyTillDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

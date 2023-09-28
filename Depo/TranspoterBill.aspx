<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TranspoterBill.aspx.cs" Inherits="Depo_TranspoterBill" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 237px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&nbsp;&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;&nbsp; &#2325;&#2375; &#2348;&#2367;&#2354; &#2325;&#2368;&nbsp; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transporter Bill Details</h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; <span>*</span>
                                    </td>
                    <td>
                                        <asp:DropDownList ID="ddlFyYear" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" AutoPostBack="True" OnSelectedIndexChanged="ddlFyYear_SelectedIndexChanged">
                                        </asp:DropDownList>

                    </td>
                    <td>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                        </td>
                </tr>
                <tr>
                    <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; / Bilti No.
                                            </td>
                    <td colspan="3">
                                        <asp:DropDownList ID="ddlBiltiNo" runat="server" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)" AutoPostBack="True" OnSelectedIndexChanged="ddlBiltiNo_SelectedIndexChanged">
                                        </asp:DropDownList>

                                        <asp:HiddenField ID="HiddenField2" runat="server" />

                    </td>
                </tr></table>
            <table width="100%" runat="server" style="display:none"   id="aa">
                <tr>
                    <td colspan="4">&#2360;&#2381;&#2357;&#2368;&#2325;&#2371;&#2340; &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2342;&#2352;
                                            </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; &#2352;&#2375;&#2335; (9 &#2335;&#2344;) : &nbsp;<asp:Label ID="lblFulltruck" runat="server"></asp:Label>
&nbsp; &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; &#2352;&#2375;&#2335; (4.5 &#2335;&#2344;)
                        <asp:Label ID="lblhulftuck" runat="server"></asp:Label>
&nbsp; &#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; :
                        <asp:Label ID="lblPratibadle" runat="server"></asp:Label>
                                            </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td>&#2335;&#2381;&#2352;&#2325; &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                                            </td>
                    <td>
                        <asp:Label ID="lblDriverName" runat="server"></asp:Label>
                    </td>
                    <td>&#2335;&#2381;&#2352;&#2325; &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; </td>
                    <td>
                        <asp:Label ID="lblDriverNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2348;&#2381;&#2354;&#2377;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                                            </td>
                    <td>
                        <asp:Label ID="lblBlockName" runat="server"></asp:Label>
                    </td>
                    <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;</td>
                    <td>
                        <asp:Label ID="lblChallanNo" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2369;&#2354; &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; </td>
                    <td>
                        <asp:Label ID="lblPaikBandal" runat="server"></asp:Label>
                    </td>
                    <td>&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; </td>
                    <td>
                        <asp:Label ID="lblPaikBook" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2369;&#2354; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; </td>
                    <td>
                        <asp:Label ID="lblLoojbandal" runat="server"></asp:Label>
                    </td>
                    <td>&#2325;&#2369;&#2354; &#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; </td>
                    <td>
                        <asp:Label ID="lblLoojbooks" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; (&#2346;&#2376;&#2325;+ &#2354;&#2370;&#2332;)</td>
                    <td>
                        <asp:Label ID="lblbandal" runat="server"></asp:Label>
                    </td>
                    <td>&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; </td>
                    <td>
                        <asp:Label ID="lblTotalBook" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2369;&#2354; &#2335;&#2344; </td>
                    <td>
                        <asp:Label ID="lbltan" runat="server"></asp:Label>
                    </td>
                    <td>&#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2342;&#2352; &#2325;&#2368; &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367;</td>
                    <td>
                        <asp:Label ID="lblAmount" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;&#2325;&#2352;&#2381;&#2340;&#2366; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2369;&#2340; &#2348;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; :</td>
                </tr>
                <tr>
                    <td>&nbsp;&#2348;&#2367;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                    <td>
                        <asp:TextBox ID="txtdate" runat="server"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                    </td>
                    <td>&#2348;&#2367;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                    <td>
                        <asp:TextBox ID="txtbillNo" runat="server"></asp:TextBox>
                         
                    </td>
                </tr>
                <tr>
                    <td>&#2348;&#2367;&#2354; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; </td>
                    <td>
                        <asp:TextBox ID="txtbillAmount" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                    </td>
                    <td>&#2348;&#2367;&#2354; &#2325;&#2368; &#2325;&#2366;&#2346;&#2368; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;&#2306; </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368; </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox" Height="63px" TextMode="MultiLine" Width="445px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" onclick="Button3_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2309;&#2327;&#2354;&#2366; &#2337;&#2366;&#2354;&#2375; / Insert Next" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" >
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="BilltrNo"  OnRowDeleting="GridView1_RowDeleting" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="TransportName_V" HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name" />
                              <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2360;&#2381;&#2341;&#2366;&#2344; / Place" />
                                  <asp:BoundField DataField="BillNo" HeaderText="&#2348;&#2367;&#2354; &#2344;&#2306;&#2348;&#2352; / Bill No." />
                                <asp:BoundField DataField="Bdate" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                                <asp:BoundField DataField="BiltiNo" HeaderText="&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; / Bilti No. " />
                                <asp:BoundField DataField="BiltiD" HeaderText="&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Bilti Date" />
                                <asp:BoundField HeaderText="कुल बंडल  " DataField="NoofBandal" />
                                <asp:BoundField DataField="Amount" HeaderText="&#2327;&#2339;&#2344;&#2366;  &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; " />
                                
                                <asp:BoundField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; " DataField="TranAmount" />
                                
                                <asp:CommandField ShowDeleteButton="True" />
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <EmptyDataTemplate>
                                Data Not Found............
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button4" runat="server" CssClass="btn" OnClick="Button4_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        
                    </td>
                </tr>
            </table>

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="BilltrNo" OnPageIndexChanging="GridView2_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="TransportName_V" HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name" />
                              <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2360;&#2381;&#2341;&#2366;&#2344; / Place" />
                                  <asp:BoundField DataField="BillNo" HeaderText="&#2348;&#2367;&#2354; &#2344;&#2306;&#2348;&#2352; / Bill No." />
                                <asp:BoundField DataField="Bdate" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                                <asp:BoundField DataField="BiltiNo" HeaderText="&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; / Bilti No. " />
                                <asp:BoundField DataField="BiltiD" HeaderText="&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Bilti Date" />
                                <asp:BoundField HeaderText="&#2357;&#2332;&#2344; &#2335;&#2344; &#2350;&#2375;&#2306; " DataField="NoofBandal" />
                                <asp:BoundField DataField="Amount" HeaderText="&#2327;&#2339;&#2344;&#2366;  &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; " />
                                
                                <asp:BoundField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; " DataField="TranAmount" />
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <EmptyDataTemplate>
                                Data Not Found............
                            </EmptyDataTemplate>
                        </asp:GridView>
            <div id="fadeDiv0" runat="server" class="modalBackground" style="display: none;">
            </div>
            <div id="Messages0" runat="server" class="popupnew" style="display: none;">
                <div class="msg MT10">
                    <p>
                    </p>
                </div>
                <a id="fancybox-close0" onclick="javascript:closeMessagesDiv();" style="display: inline;"></a>
            </div>
        </div>
    </div>
</asp:Content>


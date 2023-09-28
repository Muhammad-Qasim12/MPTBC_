<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OtherThenTextbookChallan.aspx.cs" Inherits="Printing_OtherThenTextbookChallan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        input[type="text"]:disabled {
            background-color: rgb(245, 245, 245);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344;
        &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
    </div>
    <div class="portlet-content">
        <div id="messageDiv" runat="server" class="form-message" style="display: none;">
        </div>
        <asp:Panel runat="server" ID="pnlMain">
            <table width="100%">
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem>..Select Academic Year..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <%-- <td class="style1">
                        &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year
                    </td>
                    <td class="style1">
                        <asp:Label ID="LblFyYear" runat="server" Height="16px" Width="85px">2013-2014</asp:Label>
                    </td>--%>
                </tr>

                <tr style="display: none;">
                    <td>
                        <asp:Label ID="LblDepot0" runat="server" Width="85px">&#2337;&#2367;&#2346;&#2379;  &#2330;&#2369;&#2344;&#2375;  :</asp:Label>
                    </td>
                    <td></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>

                <tr style="display: none;">
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title</td>
                    <td>
                        <asp:DropDownList ID="ddlTitleID" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="ddlTitleID_SelectedIndexChanged">
                            <asp:ListItem>Select Title</asp:ListItem>
                        </asp:DropDownList>
                    </td>


                    <td>&nbsp;&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:DropDownList ID="ddlSub" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                            <asp:ListItem>Select Title</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; 
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged">
                        </asp:DropDownList>




                    </td>
                    <td>&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;/ Distribution Order No</td>

                    <td>
                        <asp:DropDownList ID="ddlTDistribution" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="ddlTDistribution_SelectedIndexChanged">
                            <asp:ListItem>Select Distribution Order..</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; (Challan No)&nbsp; &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtChalanNo" runat="server" CssClass="txtbox reqirerd"
                            MaxLength="15" onkeypress="javascript:tbx_fnSignedInteger(event, this);"
                            onpaste="javascript:tbx_fnSignedInteger(event, this);" Enabled="False"></asp:TextBox>
                    </td>
                    <td>&nbsp;&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; (Date)</td>
                    <td>
                        <asp:TextBox ID="txtChalanDate" runat="server" CssClass="txtbox reqirerd" Enabled="false"></asp:TextBox>
                        <cc1:CalendarExtender ID="CaltxtChalanDate" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtChalanDate">
                        </cc1:CalendarExtender>

                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                            TargetControlID="txtChalanDate">
                        </cc1:CalendarExtender>

                    </td>
                </tr>
                <%--   <tr>
        
        <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
        <td colspan="3"><asp:TextBox runat="server" ID="txtReceiptDate" CssClass="txtbox reqirerd" ></asp:TextBox></td>
        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendartxtReceiptDate" TargetControlID="txtReceiptDate"    runat="server"></cc1:CalendarExtender>
        <cc1:MaskedEditExtender ID="MaskedtxtReceiptDate" TargetControlID="txtReceiptDate" Mask="99/99/9999" UserDateFormat="None" CultureName="en-GB"   MaskType="Date" runat="server"></cc1:MaskedEditExtender>
        </tr>--%>
                <%--  <tr>
        <td>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375; </td>
        <td colspan="3">
        
        <asp:RadioButtonList runat="server" ID="radioGroup" RepeatDirection="Horizontal" RepeatColumns="10" AutoPostBack="true" OnSelectedIndexChanged="radioGroup_SelectedIndexChanged" >
        </asp:RadioButtonList>
        
        </td>
        </tr>--%>

                <tr>
                    <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; /&nbsp; Bilti No.</td>
                    <td>
                        <asp:TextBox ID="txtBiltiNO" runat="server" CssClass="txtbox reqirerd"
                            MaxLength="25" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /&nbsp; Bilti Date</td>
                    <td>
                        <asp:TextBox ID="txtUnloadingCharges" runat="server" CssClass="txtbox reqirerd"
                            MaxLength="15"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender10" runat="server"
                            Format="dd/MM/yyyy" TargetControlID="txtUnloadingCharges">
                        </cc1:CalendarExtender>


                    </td>
                </tr>
                <tr>
                    <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; / Truck No.</td>
                    <td>
                        <asp:TextBox ID="txtTruckNo" runat="server" CssClass="txtbox reqirerd"
                            MaxLength="25" onkeypress="tbx_fnAlphaNumericOnly(event, this);"
                            onpaste="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Driver Mobile No.</td>
                    <td>
                        <asp:TextBox ID="txtmobileNo" runat="server" CssClass="txtbox reqirerd"
                            MaxLength="10" onkeypress="javascript:tbx_fnSignedInteger(event, this);"
                            onpaste="javascript:tbx_fnSignedInteger(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="txtbox reqirerd" MaxLength="200" onkeypress="tbx_fnAlphaNumericOnly(event, this);" onpaste="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="Title" />
                                <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="DepoName_V" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2325;&#2369;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="TotalNoOFBooks" />
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; : <%# Eval("Paikbundel") %> &#2354;&#2370;&#2332; :  <%# Eval("looj") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368;  &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="PrdadayBooks" />

                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  " DataField="TotalBundle" />

                                <asp:BoundField DataField="BookNumber" HeaderText="प्रति बंडल संख्या " />
                                <asp:TemplateField HeaderText="कुल बंडल संख्या ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBundle" runat="server" AutoPostBack="True" OnTextChanged="txtBundle_TextChanged" Text="0"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="प्रदाय पुस्तक संख्या ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("TotalBook") %>' Enabled="false"></asp:TextBox>
                                        <asp:HiddenField ID="hdnDepoId" runat="server" Value='<%# Eval("DepoID") %>' />
                                        <asp:HiddenField ID="hdnTitleID" runat="server" Value='<%# Eval("TitleID") %>' />
                                        <asp:HiddenField ID="hdnSubTitleID" runat="server" Value='<%# Eval("SubTitleID") %>' />
                                        <asp:HiddenField ID="hdnGroupID" runat="server" Value='<%# Eval("GroupID") %>' />
                                        <asp:HiddenField ID="hdnPrinterID" runat="server" Value='<%# Eval("PrinterID") %>' />
                                        <asp:HiddenField ID="hdnVGrpID" runat="server" Value='<%# Eval("VGrpID") %>' />
                                        <asp:HiddenField ID="hdnDistributionOrderId" runat="server" Value='<%# Eval("TrID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2351;&#2342;&#2367; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2361;&#2379; &#2340;&#2379; &#2330;&#2375;&#2325;&#2348;&#2377;&#2325;&#2381;&#2360; &#2325;&#2379; &#2335;&#2367;&#2325; &#2325;&#2352;&#2375;&#2306; ">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="लूज पुस्तक संख्या ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtlooj" runat="server" Enabled="false" Text="0"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>


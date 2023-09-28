<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistributionInstructions.aspx.cs"
    Inherits="DistributionB_DistributionInstructions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 30%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2 style="text-align: center;"><span><b>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2325;&#2379; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2366; &#2337;&#2367;&#2346;&#2379;&#2357;&#2366;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344; </b></span></h2>
        </div>
        <div class="portlet-content">
            <asp:Panel class="response-msg success ui-corner-all" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <table width="100%">

                <tr>
                    <td width="10%" style="font-size: medium;" valign="top">
                        <span style="color: Red;">*</span>
                        <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                    </td>
                    <td width="20%">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox"
                            OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                    <td width="10%" style="font-size: medium;" valign="top">
                        <span style="color: Red;">*</span><asp:Label ID="Label2" runat="server">&#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2406;<br /> Order No :</asp:Label>

                    </td>
                    <td width="20%">
                        <asp:TextBox runat="server" ID="TxtOrderNO" CssClass="reqirerd"></asp:TextBox></td>
                    <td width="5%" style="font-size: medium;" valign="top">
                        <span style="color: Red;">*</span><asp:Label ID="Label6" runat="server">&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br />Order Date :</asp:Label>

                    </td>
                    <td width="20%">
                        <asp:TextBox runat="server" ID="TxtOrderDate" CssClass="reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalTxtOrderDate" runat="server" Format="dd/MM/yyyy" TargetControlID="TxtOrderDate">
                        </cc1:CalendarExtender>

                    </td>
                    <td width="5%" style="font-size: medium;" valign="top">
                        <span style="color: Red;">*</span><asp:Label ID="Label1" runat="server">&#2327;&#2381;&#2352;&#2369;&#2346; &#2330;&#2369;&#2344;&#2375; <br /> Group  :</asp:Label>

                    </td>
                    <td width="20%">
                        <asp:DropDownList ID="DdlGroup" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlGroup_SelectedIndexChanged1">
                        </asp:DropDownList></td>

                </tr>

                <tr>
                    <td width="10%" style="font-size: medium;" valign="top">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</td>
                    <td width="20%">
                        <asp:DropDownList ID="ddlTitleID" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlTitleID_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td width="10%" style="font-size: medium;" valign="top">&nbsp;&#2313;&#2346;&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</td>
                    <td width="20%">
                        <asp:DropDownList ID="ddlSub" runat="server" CssClass="txtbox"
                            OnSelectedIndexChanged="ddlSubTitleID_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>

                        <asp:HiddenField ID="HiddenField2" runat="server" />

                    </td>
                    <td width="5%" style="font-size: medium;" valign="top">&#2337;&#2367;&#2350;&#2366;&#2306;&#2337; &#2335;&#2366;&#2311;&#2346; 

                    </td>
                    <td width="20%">
                        <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                        </asp:DropDownList>

                    </td>
                    <td width="5%" style="font-size: medium;" valign="top">&nbsp;&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; </td>
                    <td width="20%">
                        <asp:DropDownList ID="ddlOrder" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="ddlOrder_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>


                </tr>

                <tr>
                    <td width="5%" style="font-size: medium;" valign="top">Printer Name: </td>
                    <td width="20%">

                        <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="txtbox" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged1">
                        </asp:DropDownList>
                    </td>
                    <td width="10%" style="font-size: medium;" valign="top" class="auto-style1" colspan="2">&#2309;&#2327;&#2352; &#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2361;&#2379; &#2340;&#2379; &#2311;&#2360; &#2346;&#2352; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;&#2306;&nbsp;
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                    </td>

                    <td width="5%" style="font-size: medium;" valign="top">&nbsp;</td>
                    <td width="20%">&nbsp;</td>
                    <td width="5%" style="font-size: medium;" valign="top">&nbsp;</td>
                    <td width="20%">&nbsp;</td>

                </tr>

                <tr>
                    <td style="font-size: medium;" valign="top" colspan="8">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval ("DepoTrno_I") %>' />
                                        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval ("TotalSupply") %>' />
                                        <asp:HiddenField ID="hdnGroupNo" runat="server" Value='<%# Eval ("GrpID_I") %>' />
                                        <asp:HiddenField ID="hdnGroupName" runat="server" Value='<%# Eval ("GroupNo_V") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346;&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <%-- <asp:BoundField DataField="TotalSupply" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />--%>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtTotalSupply" runat="server" Width="90px" Text='<%# Eval ("TotalSupply") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375;  ">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />

                        <asp:Button ID="btnAddTitle" OnClick="btnAddTitle_Click" runat="server" CssClass="btn"
                            OnClientClick='javascript:return ValidateAllTextForm();' Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306;/Add Title" />

                    </td>

                </tr>

                <tr>
                    <td style="font-size: medium;" valign="top" colspan="8">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                    </td>

                </tr>

                <tr>
                    <td style="font-size: medium;" valign="top" colspan="8">
                        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="tab" OnPageIndexChanging="GridView2_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval ("DepoTrno_I") %>' />
                                        <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval ("TotalSupply") %>' />
                                        <asp:HiddenField ID="hdnGroupNo" runat="server" Value='<%# Eval ("GrpID_I") %>' />
                                        <asp:HiddenField ID="hdnTitleID" runat="server" Value='<%# Eval ("TitleID") %>' />
                                        <asp:HiddenField ID="hdnSubTitleID" runat="server" Value='<%# Eval ("SubTitleID") %>' />
                                        <asp:HiddenField ID="hdnVOrderID" runat="server" Value='<%# Eval ("VOrderID") %>' />
                                        <asp:HiddenField ID="hdnPrinterID" runat="server" Value='<%# Eval ("PrinterID") %>' />
                                        <asp:HiddenField ID="hdn_ddlGroup" runat="server" Value='<%# Eval ("Group") %>' />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:BoundField DataField="Acyear" HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; " />
                                <asp:BoundField DataField="GroupNo_V" HeaderText="Group No. " />
                                <%--<asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2342;&#2375;&#2358;  &#2325;&#2381;&#2352;." />--%>
                                <asp:TemplateField HeaderText="&#2310;&#2342;&#2375;&#2358;  &#2325;&#2381;&#2352;.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderNo" runat="server" Text='<%#Eval("OrderNo")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:BoundField DataField="OrderDate" HeaderText="&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />--%>
                                <asp:TemplateField HeaderText="&#2310;&#2342;&#2375;&#2358; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOrderDate" runat="server" Text='<%#Eval("OrderDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; " />
                                <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346;&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;" />

                                <%--<asp:BoundField DataField="TotalSupply" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />--%>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSupply" runat="server" Text='<%#Eval("TotalSupply")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />

                                <asp:TemplateField HeaderText="Group">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_ddlGroup" runat="server" Text='<%#Eval("GroupName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>

                </tr>
            </table>
        </div>
    </div>
</asp:Content>


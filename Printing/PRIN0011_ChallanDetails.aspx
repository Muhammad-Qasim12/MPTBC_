<%@ Page Title="Challan Details" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PRIN0011_ChallanDetails.aspx.cs" Inherits="Printing_PRIN001_ChallanDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    &nbsp;<%--  <tr>
        <td>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375; </td>
        <td colspan="3">
        
        <asp:RadioButtonList runat="server" ID="radioGroup" RepeatDirection="Horizontal" RepeatColumns="10" AutoPostBack="true" OnSelectedIndexChanged="radioGroup_SelectedIndexChanged" >
        </asp:RadioButtonList>
        
        </td>
        </tr>--%><div class="portlet-header ui-widget-header">
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
    </div>
    <div class="portlet-content">
        <div id="messageDiv" runat="server" class="form-message" style="display: none;">
        </div>
        <asp:Panel runat="server" ID="pnlMain">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                    </td>
                    <td class="style1">
                        <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="txtbox"
                            OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem>..Select Academic Year..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td class="style1">
                        &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year
                    </td>
                    <td class="style1">
                        <asp:Label ID="LblFyYear" runat="server" Height="16px" Width="85px">2013-2014</asp:Label>
                    </td>
                </tr>
                <tr>

                <td>
                        <asp:Label ID="lblScheme" runat="server" Width="85px" Visible="False">&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2330;&#2369;&#2344;&#2375; :</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server" AutoPostBack="True" 
                            CssClass="txtbox" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged" Visible="false" >
                            <asp:ListItem>select Medium..</asp:ListItem>
                            <asp:ListItem>&#2311;&#2306;&#2342;&#2380;&#2352; </asp:ListItem>
                        
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="LblDepot" runat="server" Width="85px">&#2337;&#2367;&#2346;&#2379;  &#2330;&#2369;&#2344;&#2375;  :</asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot" runat="server" AutoPostBack="True" 
                            CssClass="txtbox" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged">
                            <asp:ListItem>select Depo..</asp:ListItem>
                            <asp:ListItem>&#2311;&#2306;&#2342;&#2380;&#2352; </asp:ListItem>
                            <asp:ListItem>&#2349;&#2379;&#2346;&#2366;&#2354;  </asp:ListItem>
                            <asp:ListItem>&#2357;&#2367;&#2342;&#2367;&#2358;&#2366;  </asp:ListItem>
                            <asp:ListItem>&#2352;&#2368;&#2357;&#2366;  </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 
                <tr>
                    <td>
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type</td>
                    <td>
                        <asp:DropDownList ID="DdlClass2" runat="server" AutoPostBack="True" 
                            CssClass="txtbox" OnSelectedIndexChanged="DdlClass2_SelectedIndexChanged">
                            <asp:ListItem>Select Book Type</asp:ListItem>
                            <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</asp:ListItem>
                            <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366;</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
               
                    <td>
                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title </td>
                    <td>
                        <asp:DropDownList ID="DdlClass1" runat="server" AutoPostBack="True" 
                            CssClass="txtbox" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                            <asp:ListItem>Select Title</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2306; / Priintng Order No.
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox" 
                            OnSelectedIndexChanged="DdlScheme_SelectedIndexChanged">
                            <asp:ListItem>Select PrintOrder..</asp:ListItem>
                              <asp:ListItem>001</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;/ Distribution Order No</td>
                    <td>
                        <asp:DropDownList ID="DdlScheme1" runat="server" AutoPostBack="True" 
                            CssClass="txtbox" OnSelectedIndexChanged="DdlScheme1_SelectedIndexChanged">
                            <asp:ListItem>Select Distribution Order..</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; (Challan No)&nbsp; &nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="txtChalanNo" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="15" onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                            onpaste="javascript:tbx_fnSignedInteger(event, this);"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; (Date)</td>
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
                    <td>
                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; /&nbsp; Bilti No.</td>
                    <td>
                        <asp:TextBox ID="txtTruckCharges" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="25" onkeypress="tbx_fnAlphaNumericOnly(event, this);" 
                             ></asp:TextBox>
                    </td>
                    <td>
                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /&nbsp; Bilti Date</td>
                    <td>
                        <asp:TextBox ID="txtUnloadingCharges" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="15"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender10" runat="server" 
                            Format="dd/MM/yyyy" TargetControlID="txtUnloadingCharges">
                        </cc1:CalendarExtender>

                        
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; / Truck No.</td>
                    <td>
                        <asp:TextBox ID="txtLoadingCharges" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="25" onkeypress="tbx_fnAlphaNumericOnly(event, this);" 
                            onpaste="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td>
                        &#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; / Driver Mobile No.</td>
                    <td>
                        <asp:TextBox ID="txtOtherCharges" runat="server" CssClass="txtbox reqirerd" 
                            MaxLength="10" onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                            onpaste="javascript:tbx_fnSignedInteger(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:TextBox ID="txtDriverName" runat="server" CssClass="txtbox reqirerd" MaxLength="200" onkeypress="tbx_fnAlphaNumericOnly(event, this);" onpaste="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; </td>
                    <td>
                        <asp:DropDownList ID="DdlDepot0" runat="server" CssClass="txtbox" Enabled="false">
                            <asp:ListItem>select Depo..</asp:ListItem>
                            <asp:ListItem>&#2311;&#2306;&#2342;&#2380;&#2352; </asp:ListItem>
                            <asp:ListItem>&#2349;&#2379;&#2346;&#2366;&#2354;  </asp:ListItem>
                            <asp:ListItem>&#2357;&#2367;&#2342;&#2367;&#2358;&#2366;  </asp:ListItem>
                            <asp:ListItem>&#2352;&#2368;&#2357;&#2366;  </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                      <asp:Label ID="lblSendBundal" runat="server" Text="&#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; / Total Bundal Sent"></asp:Label>
                        <asp:GridView ID="GrdTitleBundalSent" runat="server" 
                            AutoGenerateColumns="False" CssClass="tab hastable" 
                            OnRowDataBound="GrdTitle_RowDataBound" 
                            onselectedindexchanged="GrdTitle_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ &lt;br&gt;  SNo.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; / Dist.Order" 
                                    Visible="True">
                                    <ItemTemplate>
                                        <%# Eval("vitranno")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;  / Challan No" 
                                    Visible="True">
                                    <ItemTemplate>
                                        <%# Eval("chalanno")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  / &lt;br&gt; No of Bundals ">
                                    <ItemTemplate>
                                       <%# Eval("PacketsSendAsPerChallan") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; /  &lt;br&gt;   BundalNo From ">
                                    <ItemTemplate>
                                        <%# Eval("BooksfromYoj") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;  /  &lt;br&gt;   BundalNo To ">
                                    <ItemTemplate>
                                       <%# Eval("BooksToYoj") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /  &lt;br&gt; Total No of  Books per Bundal">
                                    <ItemTemplate>
                                        <%# Eval("Totalnoofbooksyoj") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total No of Books">
                                    <ItemTemplate>
                                        <%# Eval("Totalnoofbooks") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;   /  &lt;br&gt;  BookNo  From">
                                    <ItemTemplate>
                                      <%# Eval("BooksFrom") %>                                          
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; / &lt;br&gt;BookNo  To">
                                    <ItemTemplate>
                                       <%# Eval("BooksTo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2357;&#2332;&#2344; (&#2335;&#2344; &#2350;&#2375;&#2306; ) / Total Weight (in Ton)">
                                    <ItemTemplate>
                                       <%# Eval("BooksToyoj") %>
                                    </ItemTemplate>
                                    <ItemTemplate>
                                       <%# Eval("PacketsSendAsPerChallanyoj") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a ID="bundalNo0" runat="server" href="#" onclick="GetPopupBundle(this)" 
                                            style="display:none ">&#2348;&#2306;&#2337;&#2354; &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</a>
                                        <asp:Panel ID="DivR0" runat="server" class="popupnew1" Style="display: none;">
                                            <a ID="fancyboxclose0" runat="server" class="fancyboxclose" href="#" 
                                                onclick="javascript:closeMessagesDiv(this);" style="display: block;"></a>
                                            <asp:Panel ID="mainDiv0" runat="server" class="form-message error" Style="display: none;
                                                    padding-top: 10px; padding-bottom: 10px;">
                                                <asp:Label ID="lblmsg0" runat="server" class="notification">
                
                                                    </asp:Label>
                                            </asp:Panel>
                                            <table cellspacing="5" class="tab" width="100%">
                                                <tr style="display:none">
                                                    <th>
                                                        &#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                                                    </th>
                                                    <th>
                                                        &#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;
                                                    </th>
                                                    <th>
                                                        &#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;
                                                    </th>
                                                    <th>
                                                        &#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                    </th>
                                                    <th>
                                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;
                                                    </th>
                                                    <th>
                                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;
                                                    </th>
                                                </tr>
                                                <tr style="display:none">
                                                    <td>
                                                        <asp:DropDownList ID="ddltype0" runat="server" 
                                                            onkeypress="javascript:tbx_fnInteger(event, this);" Width="70">
                                                            <asp:ListItem Text="&#2351;&#2379;&#2332;&#2344;&#2366;" Value="&#2351;&#2379;&#2332;&#2344;&#2366;"></asp:ListItem>
                                                            <asp:ListItem Text="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" Value="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBundleNo0" runat="server" 
                                                            onkeypress="javascript:tbx_fnInteger(event, this);" Width="40"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToBundle0" runat="server" 
                                                            onkeypress="javascript:tbx_fnInteger(event, this);" Width="100"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPerBundleBook0" runat="server" 
                                                            onkeypress="javascript:tbx_fnInteger(event, this);" Width="100"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFromBookNo0" runat="server" AutoPostBack="true" 
                                                            onkeypress="javascript:tbx_fnInteger(event, this);" 
                                                            OnTextChanged="ClacluteBook" Width="70"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtToBookNo0" runat="server" 
                                                            onkeypress="javascript:tbx_fnInteger(event, this);" Width="70"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="display:none">
                                                        <asp:Button ID="btnSaveAll0" runat="server" class="btn" OnClick="SaveData" 
                                                            Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                                                    </td>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <div style="overflow:auto;min-height:100px;max-height:600px;">
                                                            <asp:GridView ID="grdData0" runat="server" AutoGenerateColumns="false" 
                                                                CssClass="tab">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="BundleNo0" runat="server" CssClass="txtbox reqirerd" 
                                                                                MaxLength="8" onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                onpaste="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                Text='<%# Eval("BundleNo") %>' Width="80px"></asp:TextBox>
                                                                            <asp:HiddenField ID="hdnTitleid0" runat="server" 
                                                                                Value='<%# Eval("TitleID") %>' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="BundleType0" runat="server" 
                                                                                onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                onpaste="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                Text='<%# Eval("BundleType") %>' Width="80px"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="FromBook0" runat="server" CssClass="txtbox reqirerd"  
                                                                                MaxLength="8" onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                onpaste="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                Text='<%# Eval("FromBook") %>' Width="80px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="ToBook0" runat="server" CssClass="txtbox reqirerd" 
                                                                                MaxLength="8" onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                onpaste="javascript:tbx_fnSignedInteger(event, this);" 
                                                                                Text='<%# Eval("ToBook") %>' Width="80px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:DropDownList ID="DdlClass3" runat="server" AutoPostBack="True" 
                            CssClass="txtbox" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged" 
                            Visible="False">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2407; </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2408;  </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2409; </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2410;  </asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                      
                        <asp:Panel runat="server" ID="pnlTitles" 
                            GroupingText="&#2349;&#2375;&#2332;&#2375; &#2332;&#2366; &#2352;&#2361;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Challan Details " Width="1200px"
                            ScrollBars="Auto">
                            <asp:GridView runat="server" ID="GrdTitle" AutoGenerateColumns="False" CssClass="tab hastable"
                                OnRowDataBound="GrdTitle_RowDataBound" 
                                onselectedindexchanged="GrdTitle_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ &lt;br&gt;  SNo.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / &lt;br&gt; Name of the Printer" 
                                        Visible="False">
                                        <ItemTemplate>
                                            <%# Eval("nameofpress_v")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / &lt;br&gt; Group No" 
                                        Visible="False">
                                        <ItemTemplate>
                                            <%# Eval("groupno_v")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / &lt;br&gt; Title" 
                                        Visible="False">
                                        <ItemTemplate>
                                            <%# Eval("TitleHindi_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  / &lt;br&gt; No of Bundals ">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPacketsSendAsPerChallan" Text='<%# Eval("PacketsSendAsPerChallan") %>'
                                                Width="50px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                             AutoPostBack="true" OnTextChanged="txtChangeA"    onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; /  &lt;br&gt;   BundalNo From ">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtBooksTo" Text='<%# Eval("BooksfromYoj") %>'
                                                Width="100px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" Enabled="false"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;  /  &lt;br&gt;   BundalNo To ">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtTotalNoOfBooks" 
                                                Text='<%# Eval("BooksToYoj") %>' Width="80px"
                                                MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /  &lt;br&gt; Total No of  Books per Bundal">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtBooksFrom" Text='<%# Eval("Totalnoofbooksyoj") %>' Width="45px"
                                                MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total No of Books">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtPacketsSendAsPerChallanYoj" Text='<%# Eval("Totalnoofbooks") %>'
                                                Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;   /  &lt;br&gt;  BookNo  From">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtTotalNoOfBooksYoj" Text='<%# Eval("BooksFrom") %>'
                                                Width="80px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; / &lt;br&gt;BookNo  To">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtBooksFromYoj" Text='<%# Eval("BooksTo") %>'
                                                Width="82px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2357;&#2332;&#2344; (&#2335;&#2344; &#2350;&#2375;&#2306; ) / Total Weight (in Ton)">
                                        <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtBooksToYoj" Text='<%# Eval("BooksToyoj") %>' Width="45px"
                                                MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>

                                         <ItemTemplate>
                                            <asp:TextBox runat="server" ID="txtBooksQty" Text='<%# Eval("PacketsSendAsPerChallanyoj") %>' Width="45px"
                                                MaxLength="9" CssClass="txtbox reqirerd" 
                                                onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                            <asp:HiddenField runat="server" ID="HDNTitleID_I" Value='<%# Eval("TitleID_I") %>' />
                                            <asp:HiddenField runat="server" ID="HDNDepoID_I" Value='<%# Eval("DepoID_I") %>' />
                                            <asp:HiddenField runat="server" ID="HDNGRPID_I" Value='<%# Eval("GRPID_I") %>' />
                                            <asp:HiddenField runat="server" ID="HDNChallanTrno_I" Value='<%# Eval("ChallanTrno_I") %>' />
                                            <asp:CheckBox ID="chkGroup" runat="server" Visible="false" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="Button1" runat="server" Text="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2342;&#2375;&#2326;&#2375;" 
                                                OnClick="ShowDetail" />
                                            <a href="#" id="bundalNo" runat="server" onclick="GetPopupBundle(this)" style="display:none ">&#2348;&#2306;&#2337;&#2354;
                                                &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</a>
                                            <asp:Panel Style="display: none;" ID="DivR" class="popupnew1" runat="server">
                                                <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;"
                                                    onclick="javascript:closeMessagesDiv(this);"></a>
                                                <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                                                    padding-top: 10px; padding-bottom: 10px;">
                                                    <asp:Label ID="lblmsg" class="notification" runat="server">
                
                                                    </asp:Label>
                                                </asp:Panel>
                                                <table class="tab" cellspacing="5" width="100%" >
                                                    <tr style="display:none">
                                                        <th>
                                                            &#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                                                        </th>
                                                        <th>
                                                            &#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;
                                                        </th>
                                                        <th>
                                                            &#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;
                                                        </th>
                                                        <th>
                                                            &#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306;
                                                            &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                        </th>
                                                        <th>
                                                            &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                            &#2360;&#2375;
                                                        </th>
                                                        <th>
                                                            &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                            &#2340;&#2325;
                                                        </th>
                                                    </tr>
                                                    <tr style="display:none">
                                                        <td>
                                                            <asp:DropDownList ID="ddltype" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                                Width="70" runat="server">
                                                                <asp:ListItem Text="&#2351;&#2379;&#2332;&#2344;&#2366;" Value="&#2351;&#2379;&#2332;&#2344;&#2366;"></asp:ListItem>
                                                                <asp:ListItem Text="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" Value="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtBundleNo" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                                Width="70" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtToBundle" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                                Width="70" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtPerBundleBook" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                                Width="70" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtFromBookNo" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                                Width="70" AutoPostBack="true" OnTextChanged="ClacluteBook" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtToBookNo" onkeypress='javascript:tbx_fnInteger(event, this);'
                                                                Width="70" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="display:none">
                                                            <asp:Button runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;"
                                                                ID="btnSaveAll" class="btn" OnClick="SaveData" />
                                                        </td>
                                                        <td colspan="2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4">
                                                            <div style="overflow:auto;min-height:100px;max-height:600px;">
                                                                <asp:GridView ID="grdData" runat="server" CssClass="tab" AutoGenerateColumns="false" >
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox runat="server" ID="BundleNo" Text='<%# Eval("BundleNo") %>' Width="80px"
                                                                                    MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                                                    onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                                                <asp:HiddenField ID="hdnTitleid" runat="server" Value='<%# Eval("TitleID") %>' />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                                                            <ItemTemplate>
                                                                                <asp:Label runat="server" ID="BundleType" Text='<%# Eval("BundleType") %>' Width="80px"
                                                                                    onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox runat="server" ID="FromBook" Text='<%# Eval("FromBook") %>' Width="80px"  Enabled="false"
                                                                                    MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                                                    onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox runat="server" ID="ToBook" Text='<%# Eval("ToBook") %>' Width="80px"  Enabled="false"
                                                                                    MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);"
                                                                                    onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <%-- <tr>
        
        <td>&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
        <td>
        <asp:DropDownList runat="server" ID="ddlTitalID" CssClass="txtbox reqirerd">
        
        </asp:DropDownList>
        </td>

        <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
        <td>
        <asp:Label runat="server" ID="lblDepotName" > </asp:Label>
        <asp:HiddenField runat="server" ID="HdnDepo_I" Value="0" />
        </td>

        </tr>--%>
                <%-- <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>

        <tr>
        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2346;&#2376;&#2325;&#2375;&#2335;&#2381;&#2360; </td>
        <td>
        <asp:TextBox runat="server" ID="txtPacketsSendAsPerChallan" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </td>

        <td>&#2327;&#2367;&#2344;&#2340;&#2368; &#2350;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2376;&#2325;&#2375;&#2335;&#2381;&#2360; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td>
        <td>
        <asp:TextBox runat="server" ID="txtPacketsReceiveByCounting" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </td>

        </tr>

         <tr>
        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2369;&#2354; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  </td>
        <td colspan="3">
        <asp:TextBox runat="server" ID="txtTotalNoBook" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </td>
        </tr> 
        
        <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>


        <tr>
        
        <td>&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  </td>
        <td>
        <asp:TextBox runat="server" ID="txtBookFrom" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        &#2360;&#2375;</td>

        <td>&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
        <td>
        <asp:TextBox runat="server" ID="txtBookto" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        &#2340;&#2325;</td>

        </tr>--%>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remarks</td>
                    <td colspan="3">
                        <asp:TextBox runat="server" TextMode="MultiLine" Width="500px" ID="txtRemark" onpaste="MaxLengthCount(this,150);"
                            onkeypress="MaxLengthCount(this,150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button ID="Button2" runat="server" CssClass="btn" onclick="Button2_Click" 
                            onclientclick="return ValidateAllTextForm();" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; / Save" />
                        <asp:Button runat="server" ID="btnsaveChallan" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; / Save"
                            CssClass="btn" OnClientClick="return ValidateAllTextForm();" 
                            OnClick="btnsaveChallan_Click" Visible="False" />
                        <asp:Button ID="btnsaveChallan0" runat="server" CssClass="btn" OnClick=" btnsaveChallan0_Click"
                            Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <script>
        function GetPopupBundle(obj, g) {
            //alert(1);
            // obj = "'" + obj + "'";
            //alert(obj);
            //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))


            //  document.getElementById('"+obj+"').value = obj;
            document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
            document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";


        }
        function ValidateAllTextFormNew() {
            if (document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).value == "") {
                document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).focus();
                return false;

            }
            //   document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).style.display = "block";
            //document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
        }
        function closeMessagesDiv(obj) {
            document.getElementById(obj.id.replace("fancyboxclose", "DivR")).style.display = "none";
            document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "none";
            return false;
        }
                            
    </script>
    <%# Eval("BooksfromYoj") %>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
</asp:Content>


<%@ Page Title="&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2360;&#2375; &#2350;&#2343;&#2381;&#2351;&#2366;&#2357;&#2343;&#2367; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Demands Of Intermediate Books To Depot" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT011_DemandFormat.aspx.cs" Inherits="Depo_DPT011_DemandFormat" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>-
    <div class="box table-responsive">
                    <div class="card-header">
                        <h2>
                            <span>&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; &#2360;&#2375; &#2350;&#2343;&#2381;&#2351;&#2366;&#2357;&#2343;&#2367; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Demands Of Intermediate Books To Depot</span></h2>
                    </div>
                     <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                    <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                        <table width="100%">
                            <tr>
                                <td style="height: 32px">
                                    &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date <span>*</span></td>
                                <td style="height: 32px">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDate" Enabled="True">
                                    </cc1:CalendarExtender>
                                  
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 32px">
                                    &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No. <span>*</span></td>
                                <td style="height: 32px">
                                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txtbox reqirerd" MaxLength="15"></asp:TextBox>
                                    
                                  
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="background-color: #3366CC; color: #FFFFFF; font-size: large;" align="center" >&#2319;&#2325; &#2342;&#2367;&#2357;&#2360; &#2350;&#2375;&#2306; &#2350;&#2343;&#2381;&#2351;&#2366;&#2357;&#2343;&#2367; &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2319;&#2325; &#2361;&#2368; &#2310;&#2352;&#2381;&#2337;&#2352; &#2340;&#2376;&#2351;&#2366;&#2352; &#2325;&#2367;&#2351;&#2366; &#2332;&#2366; &#2360;&#2325;&#2340;&#2366; &#2361;&#2376; &#2346;&#2352;&#2344;&#2381;&#2340;&#2369; &#2313;&#2360;&#2350;&#2375;&#2306; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2309;&#2344;&#2375;&#2325; &#2332;&#2379;&#2396;&#2375; &#2332;&#2366; &#2360;&#2325;&#2340;&#2375; &#2361;&#2376;&#2306; </td>

                            </tr> 
                            <tr style="display:none;">
                                <td style="height: 32px">
                                    &#2350;&#2377;&#2327; / Demand <span>*</span></td>
                                <td style="height: 32px">
                                    <asp:RadioButtonList ID="rdDemandType" runat="server" 
                                        CssClass="txtbox reqirerd" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="2" Selected="True">&#2350;&#2343;&#2381;&#2351;&#2366;&#2357;&#2343;&#2367; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2377;&#2327;</asp:ListItem>
                                    </asp:RadioButtonList>
                                    </td>
                            </tr>
                            <tr>
                                <td style="height: 32px">
                                   &#2348;&#2369;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type <span>*</span></td>
                                <td style="height: 32px">
                                    <asp:RadioButtonList ID="rdBookType" runat="server" CssClass="txtbox reqirerd" 
                                        RepeatDirection="Horizontal" Width="226px">
                                       <asp:ListItem Value="1">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; / Genral</asp:ListItem>
                                        <%--<asp:ListItem Value="2">&#2351;&#2379;&#2332;&#2344;&#2366; / scheme </asp:ListItem>--%>
                                    </asp:RadioButtonList>
                               </td>
                            </tr>
                            <tr>
                                <td style="height: 32px">
                                    &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium <span>*</span></td>
                                <td style="height: 32px">
                                   <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                                    
                                </asp:DropDownList>
                               </td>
                            </tr>
                            <tr>
                                <td style="height: 32px">
                                    &#2325;&#2325;&#2381;&#2359;&#2366; / Class  <span>*</span></td>
                                <td style="height: 32px">
                                 
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" AutoPostBack="True" RepeatColumns="4" 
                                        onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" 
                                        RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 32px" colspan="2">
                                    <asp:GridView ID="grdbookdata" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab" onselectedindexchanged="grdbookdata_SelectedIndexChanged">
                                        <Columns>
                                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="TitalID" 
                                                         runat="server" Value='<%# Eval("TitalID") %>' />
                                                          <asp:HiddenField ID="hdnclassID" 
                                                         runat="server" Value='<%# Eval("classID") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject " DataField="BookName" />
                                            <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class " DataField="Classname"/>
                                            <asp:BoundField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; / Stock Availability " DataField="NoofBook" />
                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Reqierment ">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDemand" MaxLength="6" runat="server"  
                                                        onkeyup='javascript:tbx_fnSignedNumericCheck(this);' CssClass="txtbox reqirerd" 
                                                        AutoPostBack="True" ontextchanged="txtDemand_TextChanged" 
                                                        Text='<%# Eval("Request") %>'></asp:TextBox>
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; / Demand  ">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Label1" runat="server" Text='<%# Eval("Demand_I") %>'></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2332;&#2379;&#2396;&#2375; / Add " 
                                        onclick="Button1_Click" 
                                        OnClientClick='javascript:return ValidateAllTextForm();' />
                                    <asp:HiddenField ID="HiddenField4" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="grdbookdata0" runat="server" AutoGenerateColumns="False" 
                                        CssClass="tab" onselectedindexchanged="grdbookdata0_SelectedIndexChanged" 
                                        DataKeyNames="DemandDetailsID_I" onrowdeleting="grdbookdata0_RowDeleting" OnRowDataBound="grdbookdata0_RowDataBound" ShowFooter="True">
                                        <Columns>
                                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325 ; / No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                                                                           
                                                     <asp:HiddenField ID="HID" runat="server" 
                                                         Value='<%# Eval("DemandDetailsID_I") %>' />
                                                                                                           
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" DataField="TitleHindi_V" />
                                            <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class" DataField="Classdet_V"/>
                                            <asp:TemplateField HeaderText="&#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; / Reqierment ">
                                                <ItemTemplate> <asp:Label ID="Label3" runat="server" Text='<%#Eval("RequesrdQt_I")%>'></asp:Label>
                                                 
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2350;&#2366;&#2306;&#2327; / Demand">
                                                 <ItemTemplate>
                                                     <asp:Label ID="Label2" Text='<%#Eval("Demand_I")%>' runat="server"></asp:Label>
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:CommandField ShowSelectButton="True" />
                                              <asp:CommandField ShowDeleteButton="True"/>
                                        </Columns>
                                        <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button12" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save  " 
                                        onclick="Button12_Click" 
                                        Visible="False"/>
                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
             </ContentTemplate> </asp:UpdatePanel>
</asp:Content>


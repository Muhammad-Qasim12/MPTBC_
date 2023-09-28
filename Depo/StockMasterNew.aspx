<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockMasterNew.aspx.cs" Inherits="Depo_StockMasterNew" %>
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
                            </asp:UpdateProgress>
<asp:HiddenField ID="HdnMasterHdnId" runat="server" />
<asp:HiddenField ID="HdnTrasactionID" runat="server" />
<asp:HiddenField ID="HdnTiltle" runat="server" />
    &nbsp;<div class="box">
                            <div class="card-header">
                                <h2><span>&nbsp;&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Stock Master</span></h2>
                            </div>
                            <div style="padding:0 10px;">
                            
                        
                            
                                <table width="100%">
                                <div id="a" runat="server" >
                                    <tr   >
                                        <td>
                                          
                                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date </td>
                                        <td>
                                            <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd" 
                                                MaxLength="12"></asp:TextBox>
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>    
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium
                                         </td>
                                        <td>
                                            <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                      <tr>
                                        <td>&#2325;&#2325;&#2381;&#2359;&#2366;	/ Class 
                                         </td>
                                        <td>
                                            <asp:DropDownList ID="ddlCls" runat="server" CssClass="txtbox reqirerd">
                                              
                                                <asp:ListItem Value="1">1-8</asp:ListItem>
                                                <asp:ListItem Value="2">9-12</asp:ListItem>
                                              
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2357;&#2375;&#2351;&#2352;&#2361;&#2366;&#2313;&#2360; / &#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; / Ware House / Godown Name 	
                                         </td>
                                        <td>  <asp:DropDownList ID="ddlWarehouse" runat="server" CssClass="txtbox reqirerd">
                                            </asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2348;&#2369;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;&nbsp; / Book Type 	
                                         </td>
                                        <td>  <asp:DropDownList ID="ddlType" runat="server" 
    CssClass="txtbox ">
    <asp:ListItem Value="1">&#2351;&#2379;&#2332;&#2344;&#2366; </asp:ListItem>
    <asp:ListItem Value="2">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </asp:ListItem>
</asp:DropDownList>
                                            </td>
                                    </tr>
                                     <tr>
                                        <td>&#2348;&#2369;&#2325; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; / Book Status </td>
                                        <td>  
                                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                                                RepeatDirection="Horizontal" Width="303px">
                                                <asp:ListItem Selected="True" Value="1">&#2348;&#2367;&#2325;&#2381;&#2352;&#2368; &#2351;&#2379;&#2327;&#2381;&#2351;	</asp:ListItem>
                                                <asp:ListItem Value="2">&#2348;&#2367;&#2325;&#2381;&#2352;&#2368; &#2309;&#2351;&#2379;&#2327;&#2381;&#2351;</asp:ListItem>
                                            </asp:RadioButtonList>
                                         </td>
                                    </tr>
                                     <tr>
                                        <td>&nbsp;</td>
                                        <td>  <asp:DropDownList ID="ddlBookType" runat="server" 
                                                CssClass="txtbox reqirerd" Visible="False">
                                            <asp:ListItem Value="0">Select..</asp:ListItem>
                                            <asp:ListItem Value="1">&#2309;&#2346;&#2381;&#2352;&#2330;&#2354;&#2367;&#2340;</asp:ListItem>
                                            <asp:ListItem Value="2">&#2309;&#2344;&#2369;&#2346;&#2351;&#2379;&#2327;&#2368;</asp:ListItem>
                                            <asp:ListItem Value="3">&#2309;&#2346;&#2354;&#2375;&#2326;&#2367;&#2325;</asp:ListItem>
                                            </asp:DropDownList>
                                         </td>
                                    </tr>
                                     <tr>
                                         <td colspan="2">
                                             <asp:GridView ID="grBook" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                                 <Columns>
                                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / S.No.">
                                                         <ItemTemplate>
                                                             <%#Container.DataItemIndex+1 %>
                                                             <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("TitalID") %>' />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:BoundField DataField="BookName" HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject " />
                                                     <asp:BoundField DataField="Classname" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class " />
                                                     <asp:TemplateField HeaderText="&#2335;&#2379;&#2335;&#2354; &#2348;&#2369;&#2325; / Total Book ">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtNofBooks" runat="server" MaxLength="10" onkeypress="javascript:tbx_fnInteger(event, this);" Text="" Width="106px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; ">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtPerBundleBook" runat="server" Width="64px"  MaxLength="3"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; ">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtBundleNo" runat="server" Width="132px" MaxLength="6"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; ">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtFromBookNo" runat="server" Width="132px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2340;&#2325;">
                                                         <ItemTemplate>
                                                             <asp:TextBox ID="txtToBookNo" runat="server" Width="132px"></asp:TextBox>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375;">
                                                         <ItemTemplate>
                                                             <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="&#2344;&#2306;&#2348;&#2352; &#2332;&#2375;&#2344;&#2352;&#2375;&#2335; &#2325;&#2352;&#2375;&#2306;" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                 </Columns>
                                                 <PagerStyle CssClass="Gvpaging" />
                                                 <EmptyDataRowStyle CssClass="GvEmptyText" />
                                             </asp:GridView>
                                         </td>
                                    </tr>
                                     <tr>
                                        <td colspan="2">
                                            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="&#2310;&#2327;&#2375; &#2348;&#2338;&#2375; / Next "   OnClientClick="return ValidateAllTextForm();"
                                                Width="159px" CssClass="btn" Height="25px"  />
                                         </td>
                                    </tr></table></div>  </ContentTemplate> </asp:UpdatePanel> 
</asp:Content>


<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT003.aspx.cs" Inherits="Depo_VIEW_DPT003" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;  &#2352;&#2375;&#2335; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transport Rate Details</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; /Enter New Data"   
                            onclick="btnSave_Click" />
                        <br />
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="txtbox reqirerd" 
                                            RepeatDirection="Horizontal" Width="257px" AutoPostBack="True" 
                                            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                            <asp:ListItem Value="1">&#2337;&#2367;&#2346;&#2379; / Depot</asp:ListItem>
                                            <asp:ListItem Value="2">&#2332;&#2367;&#2354;&#2366; / District</asp:ListItem>
                                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; :
                                        <asp:DropDownList ID="ddlFyYear" runat="server" CssClass="txtbox reqirerd" 
                                            onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>
                                    &nbsp;&nbsp; &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2344;&#2366;&#2350; :
                                        <asp:DropDownList ID="ddlTrnasportName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>
                                    &nbsp;<asp:Button ID="btnSave0" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"   
                            onclick="btnSave0_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdTransport" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="TransportDetailsID_I" 
                            
                             AllowPaging="True" 
                            onpageindexchanging="GrdTransport_PageIndexChanging" 
                            onrowcommand="GrdTransport_RowCommand">
                            <Columns> 
                                   <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                             <asp:BoundField HeaderText="&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2344;&#2366;&#2350; / Transport Name " DataField="TransportName_V" />
                             
                                <asp:BoundField HeaderText="&#2327;&#2306;&#2340;&#2357;&#2381;&#2351; &#2360;&#2381;&#2341;&#2366;&#2344; &#2325;&#2366; &#2360;&#2381;&#2340;&#2352;" DataField="DistName" />
                             
                                <asp:BoundField HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325;/&#2337;&#2367;&#2346;&#2379;  &#2325;&#2366; &#2344;&#2366;&#2350; / Block/Depot Name " DataField="BlockName" />
                                <asp:BoundField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325;  &nbsp;(9 &#2335;&#2344;) &#2352;&#2375;&#2335; / Full Truck Rate" DataField="FullTruckRate_N" />
                                 <asp:BoundField HeaderText="&#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate" DataField="HalfTruckRate_N" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate" DataField="RatePerBundle_N" />
                                
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit">
                                    <ItemTemplate>
                                        <a href="DPT003_TransportDetails.aspx?ID=<%# api.Encrypt(Eval("TransportDetailsID_I").ToString ())%>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CommandArgument='<%# Eval("TransportDetailsID_I") %>'
                                                    CommandName="eDelete" ImageUrl="" CssClass="btn" AlternateText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                
                            </Columns>
                            <EmptyDataTemplate>
                                Data Not Found
                            </EmptyDataTemplate>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>


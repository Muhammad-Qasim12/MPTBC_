<%@ Page Title="&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;  &#2352;&#2375;&#2335; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transport Rate Detail" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT003_TransportDetails.aspx.cs" Inherits="Depo_DPT003_TransportDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                            <div class="card-header">
                                <h2><span>&#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;  &#2352;&#2375;&#2335; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Transport Rate Detail </span></h2>
                            </div>
                            <div style="padding:0 10px;">
                            
                            <table width="100%">
                                <tr>
                                    <td >
                                        &#2335;&#2381;&#2352;&#2366;&#2344;&#2381;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335; &#2344;&#2366;&#2350; / Transport Name</td>
                                    <td>
                                        <asp:DropDownList ID="ddlTrnasportName" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; </td>
                                    <td>
                                        <asp:DropDownList ID="ddlFyYear" runat="server" CssClass="txtbox reqirerd" 
                                            onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td>
                                        &#2337;&#2375;&#2360;&#2381;&#2335;&#2368;&#2344;&#2375;&#2358;&#2344; / Destination</td>
                                    <td>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="txtbox reqirerd" 
                                            RepeatDirection="Horizontal" Width="257px" AutoPostBack="True" 
                                            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                                            <asp:ListItem Value="1">&#2337;&#2367;&#2346;&#2379; / Depot</asp:ListItem>
                                            <asp:ListItem Value="2">&#2348;&#2381;&#2354;&#2366;&#2325; / Block</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false" id="D">
                                    <td>
                                        &#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / District Name </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="txtbox reqirerd" 
                                            AutoPostBack="True" onselectedindexchanged="ddlBlock0_SelectedIndexChanged">
                                            <asp:ListItem Value="0">&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335;..</asp:ListItem>
                                        </asp:DropDownList></td>
                                </tr>
                            
                                
                                 <tr>
                                    <td colspan="2" style="text-align: left">
                                        <strong style="font-weight:bold;">&#2352;&#2375;&#2335; &#2357;&#2367;&#2357;&#2352;&#2339; / Rate Details</strong>
                                    </td>
                                </tr>
                                
                                <tr>
                                  <asp:GridView ID="GrdTranportRate" runat="server" 
                                        AutoGenerateColumns="False"  CssClass="tab" 
                                         >
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                  <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depot Name">
                                <ItemTemplate>
                                <asp:HiddenField ID="hdnHeadId" runat="server" Value='<%#Eval("TransportDetailsID_I") %>' />
                                 <asp:HiddenField ID="hdnDepoTrn" runat="server" Value='<%#Eval("DepoTrno_I") %>' />
                                     <asp:HiddenField ID="hdMain" runat="server" Value='<%#Eval("maindepo") %>' />
                                <asp:Label ID="lblheadname" Text='<%#Eval("DepoName_V") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335;  (&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2376;) / Full Truck Rate">
                                <ItemTemplate>
                                <asp:TextBox ID="txtEstimateAmount" Text='<%#Eval("FullTruckRate_N") %>' MaxLength="6"  onkeypress='javascript:tbx_fnNumeric(event, this);'  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5&#2335;&#2344;) &#2352;&#2375;&#2335; (&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2376;) / Half Truck Rate">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtAvailableAmount" Text='<%#Eval("HalfTruckRate_N") %>' MaxLength="6" onkeypress='javascript:tbx_fnNumeric(event, this);'   runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; (&#2352;&#2370;&#2346;&#2351;&#2375; &#2350;&#2376;) / Per Bundle Rate">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtrequestAmount" Text='<%#Eval("RatePerBundle_N") %>' MaxLength="6" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                                  <asp:GridView ID="grdblock" runat="server" 
                                        AutoGenerateColumns="False"  CssClass="tab" 
                                         >
                                <Columns>
                                <asp:TemplateField>
                                <ItemTemplate>
                                  <asp:CheckBox ID="chk" runat="server"></asp:CheckBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Block Name">
                                <ItemTemplate>
                                <asp:HiddenField ID="hdnHeadId" runat="server" Value='<%#Eval("TransportDetailsID_I") %>' />
                                 <asp:HiddenField ID="hdnblockTrn" runat="server" Value='<%#Eval("DepoTrno_I") %>' />
                                
                                <asp:Label ID="lblheadname" Text='<%#Eval("BlockName_V") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; (9 &#2335;&#2344;) &nbsp;&#2352;&#2375;&#2335; / Full Truck Rate">
                                <ItemTemplate>
                                <asp:TextBox ID="txtEstimateAmount" Text='<%#Eval("FullTruckRate_N") %>'  onkeypress='javascript:tbx_fnNumeric(event, this);'  runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; (4.5 &#2335;&#2344;) &#2352;&#2375;&#2335; / Half Truck Rate">
                                <ItemTemplate>
                                 <asp:TextBox ID="txtAvailableAmount" Text='<%#Eval("HalfTruckRate_N") %>' onkeypress='javascript:tbx_fnNumeric(event, this);'   runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; / Per Bundle Rate">
                                <ItemTemplate>
                                  <asp:TextBox ID="txtrequestAmount" Text='<%#Eval("RatePerBundle_N") %>' onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                                
                                </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save "   OnClientClick="return ValidateAllTextForm();"
                            onclick="btnSave_Click" /></td>
        </tr>
    </table>
                            
                            </div> </div> 
</asp:Content>


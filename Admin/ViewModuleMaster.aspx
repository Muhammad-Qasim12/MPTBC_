<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ViewModuleMaster.aspx.cs" Inherits="Admin_ViewModuleMaster" 
    Title="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; (निर्माण/सुधार) / Module (Insert/Update)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; (निर्माण/सुधार) / Module (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px 15px;">
         
                <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                    padding-top: 10px; padding-bottom: 10px;">
                    <asp:Label ID="lblmsg" class="notification" runat="server">
                
                    </asp:Label>
                </asp:Panel>
                <asp:Panel ID="pnlModuleMaster" runat="server">
                    <asp:Button ID="btnNewModule" OnClick="btnNewModule_Click" runat="server" Text="&#2344;&#2351;&#2366; &#2350;&#2377;&#2337;&#2351;&#2370;&#2354; &#2332;&#2379;&#2396;&#2375;&#2306; / Add New Module"
                        CssClass="btn"></asp:Button>
                    <asp:GridView ID="gvModuleMaster" CssClass="tab" AutoGenerateColumns="False" PageSize="20"
                        AllowPaging="True" OnPageIndexChanging="gvModuleMaster_PageIndexChanging" DataKeyNames="ModuleTrno_I"
                        OnRowEditing="gvModuleMaster_RowEditing" OnRowDeleting="gvModuleMaster_RowDeleting"
                        runat="server">
                        <Columns>
                            <asp:BoundField DataField="ModuleTrno_I" Visible="false" ReadOnly="true" HeaderText="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2310;&#2312;. &#2337;&#2368;. / Module ID" />
                            <asp:BoundField DataField="ModuleName_V" ReadOnly="true" HeaderText="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name" />
                            <asp:BoundField DataField="ModuleOrderNO_I" ReadOnly="true" HeaderText=" &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Module Order No." />
                            <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit"
                                Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; / Edit" >
                            <ControlStyle CssClass="btn" />
                            </asp:ButtonField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" CssClass="btn" Visible="false" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306; / Remove"
                                        OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
              <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                    <asp:HiddenField ID="hdnModuleId" runat="server" />
                </asp:Panel>
                   <asp:Panel ID="pnlNewModule" Visible="false" runat="server">
                <table>
                    <tr>
                        <td width="15%">
                            &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name</td>
                        <td width="85%">
                            <asp:TextBox ID="txtModuleName" MaxLength="30" runat="server" CssClass="txtbox reqirerd">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Module Order No.
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrderNo" MaxLength="4" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);'
                                CssClass="txtbox reqirerd">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save"
                                OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

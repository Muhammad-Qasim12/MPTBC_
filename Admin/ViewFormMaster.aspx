<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="ViewFormMaster.aspx.cs" Inherits="Admin_ViewFormMaster" Title="&#2347;&#2377;&#2352;&#2381;&#2350; (निर्माण/सुधार) / Form (Insert/Update)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2347;&#2377;&#2352;&#2381;&#2350; (निर्माण/सुधार) / Form (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px 15px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnlFormMaster" runat="server">
                <asp:Button ID="btnNewForm" OnClick="btnNewForm_Click" runat="server" Text="&#2344;&#2351;&#2366; &#2347;&#2377;&#2352;&#2381;&#2350;  &#2332;&#2379;&#2396;&#2375;&#2306; / Add New Form"
                    CssClass="btn"></asp:Button>
                <table>
                    <tr>
                        <td>&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name </td>
                        <td>
                            <asp:DropDownList ID="ddlSelectModule" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlSelectModule_OnSelectedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>

                <asp:GridView ID="gvFormMaster" CssClass="tab" AutoGenerateColumns="False" PageSize="30"
                    DataKeyNames="FormTrno_I" AllowPaging="True" OnPageIndexChanging="gvFormMaster_PageIndexChanging"
                    OnRowEditing="gvFormMaster_RowEditing" OnRowDeleting="gvFormMaster_RowDeleting"
                    runat="server">
                    <Columns>
                        <asp:BoundField DataField="FormTrno_I" Visible="false" ReadOnly="true" HeaderText="&#2347;&#2377;&#2352;&#2381;&#2350; &#2310;&#2312;. &#2337;&#2368;. / Form ID" />
                        <asp:BoundField DataField="ModuleName_V" ReadOnly="true" HeaderText="&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name" />
                        <asp:BoundField DataField="SubModuleName_V" ReadOnly="true" HeaderText="&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; / Sub Module" />
                        <asp:BoundField DataField="Status_V" ReadOnly="true" HeaderText="&#2360;&#2381;&#2335;&#2375;&#2335;&#2360; / Status" />
                        <asp:BoundField DataField="FormDesc_V" ReadOnly="true" HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339; / Detail" />
                        <asp:BoundField DataField="FormPath_V" ReadOnly="true" HeaderText="&#2347;&#2377;&#2352;&#2381;&#2350; &#2346;&#2366;&#2341; / Form Path" />
                        <asp:TemplateField HeaderText="&#2354;&#2367;&#2306;&#2325; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2342;&#2352;&#2381;&#2358;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Show In Link">
                            <ItemTemplate>
                                <asp:CheckBox Enabled="false" ID="gvchkVisibleinLink_B" Checked='<%# Convert.ToBoolean(Eval("VisibleinLink_B")) %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrderNo_I" ReadOnly="true" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No" />
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit"
                            Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; / Edit">
                            <ControlStyle CssClass="btn" />
                        </asp:ButtonField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="gvlblModuleTr" Visible="false" runat="server" Text='<%# Eval("ModuleTrno_I") %>'></asp:Label>
                                <asp:Label ID="gvlblSubModuleTrno" Visible="false" runat="server" Text='<%# Eval("SubModuleTrno_I") %>'></asp:Label>
                                <asp:Button ID="btnDelete" Visible="false" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306; / Remove"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                </asp:GridView>
                <asp:HiddenField ID="hdnFormTrno" runat="server" />
            </asp:Panel>
            <asp:Panel ID="pnlNewForm" Visible="false" runat="server">
                <table>
                    <tr>
                        <td width="15%">&#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Module Name
                        </td>
                        <td width="85%">
                            <asp:DropDownList ID="ddlModule" AutoPostBack="true" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td width="15%">&#2360;&#2348; &#2350;&#2366;&#2305;&#2337;&#2381;&#2351;&#2370;&#2354; &#2344;&#2366;&#2350; / Sub Module Name
                        </td>
                        <td width="85%">
                            <asp:DropDownList ID="ddSublModule" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2360;&#2381;&#2335;&#2375;&#2335;&#2360; / Status
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="txtbox reqirerd" Width="210px">
                                <asp:ListItem Value="">Select..</asp:ListItem>
                                <asp:ListItem Value="Entry">Entry</asp:ListItem>
                                <asp:ListItem Value="View">View</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 133px">&#2357;&#2367;&#2357;&#2352;&#2339; / Details
                        </td>
                        <td>
                            <asp:TextBox ID="txtFormDesc" MaxLength="500" CssClass="txtbox reqirerd" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 133px">&#2347;&#2377;&#2352;&#2381;&#2350; &#2346;&#2366;&#2341; / Form Path
                        </td>
                        <td>
                            <asp:TextBox ID="txtFormPath" MaxLength="500" CssClass="txtbox reqirerd" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtOrder" MaxLength="5" onkeypress='javascript:tbx_fnInteger(event, this);' CssClass="txtbox reqirerd" runat="server">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 133px">&#2354;&#2367;&#2306;&#2325; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2342;&#2352;&#2381;&#2358;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Show In Link
                        </td>
                        <td>
                            <asp:RadioButtonList ID="rblShowInLink" runat="server">
                                <asp:ListItem Value="true" Selected="True" Text="&#2361;&#2366;&#2305; / Yes"></asp:ListItem>
                                <asp:ListItem Value="false" Text="&#2344;&#2361;&#2368;&#2306; / No"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="2">
                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;/ Save"
                                OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn"></asp:Button>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

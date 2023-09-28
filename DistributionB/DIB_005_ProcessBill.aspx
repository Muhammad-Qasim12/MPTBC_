<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DIB_005_ProcessBill.aspx.cs" Inherits="Distribution_FreeTextBooksDemandFromRSK"
    Title="&#2348;&#2367;&#2354; &#2346;&#2381;&#2352;&#2379;&#2360;&#2375;&#2360;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span>&#2342;&#2375;&#2351;&#2325; &#2344;&#2367;&#2352;&#2381;&#2350;&#2366;&#2339; &#2319;&#2357;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2352;&#2366;&#2358;&#2367; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; / Bill Process and Recieved Payment Information </span>
                    </h2>
                </div>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                    <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
                    <table width="100%">
                        <tr>
                            <td colspan="4">
                                <asp:HiddenField ID="hdnProcessBillID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>&#2348;&#2367;&#2354; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Bill Type
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBillType" runat="server" CssClass="txtbox">
                                    <asp:ListItem Value="&#2348;&#2367;&#2354;"> &#2348;&#2367;&#2354; </asp:ListItem>
                                    <asp:ListItem Value="&#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2348;&#2367;&#2354;"> &#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2348;&#2367;&#2354; </asp:ListItem>
                                    <asp:ListItem Value="&#2346;&#2381;&#2352;&#2379;&#2357;&#2367;&#2332;&#2344;&#2354; &#2348;&#2367;&#2354;">&#2346;&#2381;&#2352;&#2379;&#2357;&#2367;&#2332;&#2344;&#2354; &#2348;&#2367;&#2354;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; / Department Name
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" CssClass="txtbox reqirerd" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                            </td>
                            <td>
                                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlAcademicSession_OnSelectedIndexChanged"
                                    runat="server" ID="ddlAcademicSession">
                                </asp:DropDownList>
                            </td>
                            <td></td>
                            <td>
                                <asp:Label ID="lblFinancialYear" runat="server" Text="Label" Visible="false" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2348;&#2367;&#2354; &#2344;&#2306;&#2348;&#2352; / Bill No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterNo" MaxLength="10" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            </td>
                            <td>&#2348;&#2367;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Bill Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterDate" MaxLength="20" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtLetterDate" TargetControlID="txtLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td>&#2352;&#2375;&#2398;&#2352;&#2375;&#2344;&#2381;&#2360; &#2354;&#2376;&#2335;&#2352;
                                &#2344;&#2306;. / Reference Letter No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterNo" MaxLength="40" CssClass="txtbox" runat="server"></asp:TextBox>
                            </td>
                            <td>&#2352;&#2375;&#2398;&#2352;&#2375;&#2344;&#2381;&#2360; &#2354;&#2376;&#2335;&#2352;
                                &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reference Letter Date.
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterDate" MaxLength="12" CssClass="txtbox" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtRefLetterDate" TargetControlID="txtRefLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td>&#2331;&#2370;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340;/ Discount Percentage
                            </td>
                            <td>
                                <asp:TextBox ID="txtDiscountPercentage" MaxLength="5" CssClass="txtbox reqirerd"
                                    onkeypress='javascript:tbx_fnNumeric(event, this);' runat="server" ReadOnly="True">15</asp:TextBox>
                            </td>
                           <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other then TextBook Item
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlTitle" AutoPostBack="true" OnSelectedIndexChanged="ddlTitle_OnSelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title of Other then TextBook Item
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlSubTitle">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total Books
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotalBooks" MaxLength="7" Text="0" CssClass="txtbox reqirerd"
                                    onkeypress='javascript:tbx_fnInteger(event, this);' runat="server"></asp:TextBox>
                            </td>
                            <td>&#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;) / Rate(Rs.)
                            </td>
                            <td>
                                <asp:TextBox ID="txtRate" MaxLength="12" Text="0" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'
                                    runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 10px;"></td>
                            <td>
                                <asp:Button runat="server" ID="btnAddTitle" OnClick="btnAddTitle_Click" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306; "
                                    OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div>
                                    <asp:GridView ID="grdSelectedTitle" runat="server" AutoGenerateColumns="False" CssClass="tab"
                                        OnRowDeleting="grdSelectedTitle_RowDeleting" OnRowEditing="grdSelectedTitle_RowEditing"
                                        OnRowUpdated="grdSelectedTitle_RowUpdated" OnRowCancelingEdit="grdSelectedTitle_RowCancelingEdit"
                                        OnRowUpdating="grdSelectedTitle_RowUpdating" OnRowCommand="grdSelectedTitle_RowCommand" AllowPaging="True">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Title" ReadOnly="true" HeaderText=" &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other then TextBook Item" />
                                            <asp:BoundField DataField="SubTitle" ReadOnly="true" HeaderText="&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title of Other then TextBook Item" />
                                            <%--   <asp:BoundField DataField="Rate" DataFormatString="{0:N}" ReadOnly="true" HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;) / Rate(Rs.)" />--%>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDgRate" runat="server" Text='<%# Eval("Rate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtDgRate" MaxLength="5" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server" Text='<%# Eval("Rate") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TotalBooks" ReadOnly="true" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total Books" />
                                            <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) / Total Amount (Rs.)" />
                                            <asp:BoundField DataField="DiscountPercent" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText="&#2331;&#2370;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; /Discount Percentage" />
                                            <asp:BoundField DataField="Discount" DataFormatString="{0:N}" ReadOnly="true" HeaderText="&#2331;&#2370;&#2335; / Discount" />
                                            <asp:BoundField DataField="NetAmount" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2352;&#2366;&#2358;&#2368; / Total Net Amount(Rs.)" />
                                            <%--    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn" CommandName="Edit" Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306;/ Edit">--%>

                                            <%--    <ControlStyle CssClass="btn" />
                                            </asp:ButtonField>--%>
                                            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn" EditText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; /Edit" ShowEditButton="True" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306;"
                                                        OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                             <td>&#2354;&#2376;&#2335;&#2352; &#2325;&#2368; &#2360;&#2381;&#2325;&#2376;&#2344;
                                &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367; &#2309;&#2346;&#2354;&#2379;&#2337;
                                &#2325;&#2352;&#2375; / Upload Scan Copy of Letter
                            </td>
                            <td>
                                <asp:FileUpload runat="server" ID="fileScanLetter" />
                            </td>
                            <td>&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368; /Total Amount(Rs.)
                            </td>
                            <td>
                                <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                                <asp:HiddenField ID="HiddenField2" runat="server" />
                                <asp:HiddenField ID="hdnDemandID" Value="0" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button runat="server" ID="btnSupply" OnClick="btnSupply_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;"
                                    OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="mapID" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSupply" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

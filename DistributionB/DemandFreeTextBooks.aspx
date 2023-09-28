<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DemandFreeTextBooks.aspx.cs" Inherits="DistributionB_DemandFreeTextBooks"
    Title="&#2352;&#2366;&#2406;&#2358;&#2367;&#2406;&#2325;&#2375; &#2360;&#2375; &#2344;&#2367;:&#2358;&#2369;&#2354;&#2381;&#2325; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327;" %>

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
                        <span>&#2352;&#2366;&#2406;&#2358;&#2367;&#2406;&#2325;&#2375; &#2360;&#2375; &#2344;&#2367;:&#2358;&#2369;&#2354;&#2381;&#2325; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Free Books Demand From RSK
                        </span>
                    </h2>
                </div>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                    <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                        padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
                    <table width="100%" class="tab">
                        <tr>
                            <td colspan="4">
                                <asp:HiddenField ID="hdnFreeBooksDistributionID" runat="server" />
                                <asp:HiddenField ID="hdnTitleRate" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year</td>
                            <td>
                                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlAcademicSession_OnSelectedIndexChanged"
                                    runat="server" ID="ddlAcademicSession">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Finanical Year</td>
                            <td>
                                <asp:Label ID="lblFinancialYear" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &#2346;&#2340;&#2381;&#2352; / &#2344;&#2379;&#2335;&#2358;&#2368;&#2335; &#2325;&#2381;&#2352;. / Letter / Notesheet No.</td>
                            <td>
                                <asp:TextBox ID="txtLetterNo" MaxLength="30" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &#2346;&#2340;&#2381;&#2352;&nbsp; / &#2344;&#2379;&#2335;&#2358;&#2368;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter / Notesheet Date</td>
                            <td>
                                <asp:TextBox ID="txtLetterDate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtLetterDate" TargetControlID="txtLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &#2352;&#2375;&#2398;&#2352;&#2375;&#2344;&#2381;&#2360; &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Reference Letter No.</td>
                            <td>
                                <asp:TextBox ID="txtRefLetterNo" MaxLength="30" CssClass="txtbox" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &#2352;&#2375;&#2398;&#2352;&#2375;&#2344;&#2381;&#2360; &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reference Letter Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterDate" MaxLength="12" CssClass="txtbox" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtRefLetterDate" TargetControlID="txtRefLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButtonList runat="server" ID="rbtnSupplyFrom" CssClass="reqirerd" OnSelectedIndexChanged="rbtnSupplyFrom_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" AutoPostBack="true">
                                    <asp:ListItem Value="0"> &#2337;&#2367;&#2346;&#2379; &#2360;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375; / Supply From Depo</asp:ListItem>
                                    <asp:ListItem Value="1">&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2354;&#2366;&#2311;&#2348;&#2381;&#2352;&#2375;&#2352;&#2368;  &#2360;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375; / Supply From Library </asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" CssClass="txtbox" ID="ddlDepo" Visible="false">
                                </asp:DropDownList>
                            </td>
                          <td></td>
                            <td></td>
                        </tr>
                    </table>
                    <table width="100%" class="tab">
                        <tr>
                            <th colspan="4">
                                &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375;&#2306; / Select Title</th>
                        </tr>
                        <tr>
                            <td>
                                &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium</td>
                            <td colspan="3">
                                <asp:DropDownList runat="server" ID="ddlMedium" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_OnSelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lblDiscountPercentage" Visible="false" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                            <td colspan="3">
                                <asp:CheckBox ID="chkAllClasses" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllClasses_CheckedChanged"
                                    Text="&#2360;&#2349;&#2368; &#2325;&#2325;&#2381;&#2359;&#2366;&#2319;&#2306; &#2330;&#2369;&#2344;&#2375;&#2306; / Select All Class" />
                                <asp:CheckBoxList runat="server" ID="ddlClass" AutoPostBack="false" OnSelectedIndexChanged="ddlClass_OnSelectedIndexChanged"
                                  CssClass="txtbox reqirerd1"  RepeatColumns="12">
                                </asp:CheckBoxList>
                                <asp:Button runat="server" ID="btnSelectClass" OnClick="btnSelectClass_Click" Text="&#2325;&#2325;&#2381;&#2359;&#2366; &#2330;&#2369;&#2344;&#2375;&#2306; / Select Class"
                                  OnClientClick='javascript:return ValidateAllTextForm1();'   CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Name of Other then TextBook Item</td>
                            <td colspan="3">
                                <asp:CheckBox ID="chkAllTitles" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllTitles_CheckedChanged"
                                    Text="&#2360;&#2349;&#2368; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2330;&#2369;&#2344;&#2375;&#2306; / Select All Titles" />
                                <asp:CheckBoxList ID="ddlTitle" runat="server" RepeatColumns="5" RepeatLayout="Table"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               &#2325;&#2369;&#2354; &#2360;&#2375;&#2335;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  / No. Of Total Sets</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtTotalBooks" MaxLength="7" Text="0" onkeypress='javascript:tbx_fnInteger(event, this);'
                                    CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 10px;">
                                &nbsp;
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnAddTitle" OnClick="btnAddTitle_Click" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306; / Add Title"
                                    CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="tab">
                        <tr>
                            <th>
                                &#2330;&#2351;&#2344;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Selected Title</th>
                        </tr>
                    </table>
                    <div>
                        <asp:GridView ID="grdSelectedTitle" runat="server" AutoGenerateColumns="False" CssClass="tab"
                            DataKeyNames="TitleID" OnRowDeleting="grdSelectedTitle_RowDeleting" ShowFooter="True"
                            FooterStyle-BackColor="LightGray" FooterStyle-Font-Bold="true">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="ChkAllTitles" OnCheckedChanged="ChkAllTitles_OnCheckedChanged"
                                            Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2361;&#2335;&#2366;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; &#2330;&#2369;&#2344;&#2375;&#2306; / Select For Remove Title"
                                            AutoPostBack="true" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ChkSelectTitle" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Class" ReadOnly="true" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class" />
                                <asp:BoundField DataField="Medium" ReadOnly="true" 
                                    HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium" />
                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFtTitle" runat="server" Text="&#2325;&#2369;&#2354; &#2351;&#2379;&#2327; / Total"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Rate" ReadOnly="true" 
                                    HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;) / Title Rate (Rs.)" />
                                <asp:TemplateField HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. of Textbooks">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBooks" runat="server" Text='<%# Eval("TotalBooks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalBooks" runat="server" Text="0"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351; (&#2352;&#2369;&#2346;&#2319;) / Amount (Rs.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" ReadOnly="true"
                                    HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &nbsp;&#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)" />--%>
                                <asp:BoundField DataField="DiscountPercent" DataFormatString="{0:N}" ReadOnly="true"
                                    HeaderText="&#2331;&#2370;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; / Discount Percent" />
                                <asp:TemplateField HeaderText="&#2331;&#2370;&#2335; (&#2352;&#2369;&#2346;&#2319;) / Discount (Rs.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalDiscount" runat="server" Text="0"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%-- <asp:BoundField DataField="Discount" DataFormatString="{0:N}" ReadOnly="true" HeaderText="&#2331;&#2370;&#2335;" />--%>
                                <%--<asp:BoundField DataField="NetAmount" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2350;&#2370;&#2354;&#2381;&#2351;" />--%>
                                <asp:TemplateField HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;) / Net Amount (Rs.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetAmount" runat="server" Text='<%# Eval("NetAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalNetAmount" runat="server" Text='0'></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <FooterStyle BackColor="LightGray" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                    <table class="table" width="100%">
                        <tr>
                             <td>
                                &#2346;&#2340;&#2381;&#2352; &#2325;&#2368; &#2360;&#2381;&#2325;&#2376;&#2344; &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; / Upload Letter Scan Copy
                            </td>
                            <td>
                                <asp:FileUpload runat="server" CssClass="txtbox" ID="fileScanLetter" />
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <th>
                                <%-- &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368;--%>
                                <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2361;&#2335;&#2366;&#2319;&#2306; / Remove Title"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');"
                                    OnClick="btnDelete_Click" />
                            </th>
                            <th>
                                <%--<asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>--%>
                            </th>
                            <th>
                            </th>
                            <th>
                                <asp:Button runat="server" ID="btnSupply" OnClick="btnSupply_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; / Save"
                                    OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                                <asp:HiddenField ID="mapID" runat="server" />
                            </th>
                        </tr>
                        <tr>
                            <td colspan="4">
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

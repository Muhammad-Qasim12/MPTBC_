<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SpecialDemand.aspx.cs" Inherits="DistributionB_SpecialDemand"
    Title="&#2346;&#2381;&#2352;&#2348;&#2306;&#2343; &#2360;&#2306;&#2330;&#2366;&#2354;&#2325; &#2319;&#2357;&#2306; &#2309;&#2343;&#2381;&#2351;&#2325;&#2381;&#2359; &#2325;&#2375; &#2357;&#2367;&#2358;&#2375;&#2359;&#2366;&#2343;&#2367;&#2325;&#2366;&#2352; &#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2310;&#2342;&#2375;&#2358;" %>

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
                <div class="headlines">
                    <h2>
                        <span>प्रबंध संचालक एवं अध्यक्ष के विशेषाधिकार से पुस्तक का आदेश / Special Demand from Chairman/M.D.</span>
                    </h2>
                </div>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                    <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
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
                            <td>&#2310;&#2342;&#2375;&#2358;&#2325;&#2352;&#2381;&#2340;&#2366; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; /Officer
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblDemandFrom" runat="server" CssClass="reqirerd"
                                    RepeatDirection="Horizontal" AutoPostBack="True"
                                    OnSelectedIndexChanged="rblDemandFrom_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Chairman" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="M.D."></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>&#2332;&#2367;&#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;
                                &#2325;&#2352;&#2344;&#2366; &#2361;&#2376; / Place of Supply
                            </td>
                            <td>
                                <asp:TextBox ID="txtSupplyTo" MaxLength="70" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
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
                            <td>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year
                            </td>
                            <td>
                                <asp:Label ID="lblFinancialYear" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / &#2344;&#2379;&#2335;&#2358;&#2368;&#2335; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No / Notesheet No
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterNo" MaxLength="30" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                            </td>
                            <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / &#2344;&#2379;&#2335;&#2358;&#2368;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date / Notesheet Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterDate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtLetterDate" TargetControlID="txtLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>&#2352;&#2375;&#2398;&#2352;&#2375;&#2344;&#2381;&#2360; &#2354;&#2376;&#2335;&#2352;
                                &#2344;&#2306;./ Reference Letter No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterNo" MaxLength="30" CssClass="txtbox" runat="server"></asp:TextBox>
                            </td>
                            <td>&#2352;&#2375;&#2398;&#2352;&#2375;&#2344;&#2381;&#2360; &#2354;&#2376;&#2335;&#2352;
                                &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Reference Letter Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterDate" MaxLength="12" CssClass="txtbox" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtRefLetterDate" TargetControlID="txtRefLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                 
                            </td>
                        </tr>
                        <tr>

                            <td>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; &#2325;&#2366; &#2346;&#2370;&#2352;&#2381;&#2357; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Pevious demand in finanical Year </td>
                            <td>
                                <asp:Label ID="lblPrvPayment" runat="server" Text="0"></asp:Label>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <th colspan="4">
                                <asp:Label ID="lblTotalLimit" runat="server" Text="0"></asp:Label>
                            </th>
                        </tr>
                    </table>
                    <table width="100%" class="tab">
                        <tr>
                            <th colspan="4">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375;&#2306;  / Select Title
                            </th>
                        </tr>
                        <tr>
                            <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; /Medium
                            </td>
                            <td colspan="3">
                                <asp:DropDownList runat="server" ID="ddlMedium" AutoPostBack="true" OnSelectedIndexChanged="ddlMedium_OnSelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="lblDiscountPercentage" Visible="false" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&#2325;&#2325;&#2381;&#2359;&#2366; / Class
                            </td>
                            <td colspan="3">
                                <asp:CheckBox ID="chkAllClasses" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllClasses_CheckedChanged"
                                    Text="&#2360;&#2349;&#2368; &#2325;&#2325;&#2381;&#2359;&#2366;&#2319;&#2306; &#2330;&#2369;&#2344;&#2375;&#2306;" />
                                <asp:CheckBoxList runat="server" ID="ddlClass" OnSelectedIndexChanged="ddlClass_OnSelectedIndexChanged"
                                    CssClass="txtbox reqirerd1" RepeatColumns="12">
                                </asp:CheckBoxList>
                                <asp:Button runat="server" ID="btnSelectClass" OnClick="btnSelectClass_Click"
                                    Text="&#2325;&#2325;&#2381;&#2359;&#2366; &#2330;&#2369;&#2344;&#2375;&#2306;"
                                    OnClientClick='javascript:return ValidateAllTextForm1();' CssClass="btn" />
                            </td>
                        </tr>
                        <tr>
                            <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /Title
                            </td>
                            <td colspan="3">
                                <asp:CheckBox ID="chkAllTitles" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllTitles_CheckedChanged"
                                    Text="&#2360;&#2349;&#2368; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2330;&#2369;&#2344;&#2375;&#2306;" />
                                <asp:CheckBoxList ID="ddlTitle" runat="server" RepeatColumns="5"
                                    RepeatLayout="Table" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2360;&#2375;&#2335;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of sets
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtTotalBooks" MaxLength="5" Text="0" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnInteger(event, this);'
                                    runat="server"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="height: 10px;">&nbsp;
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnAddTitle" OnClick="btnAddTitle_Click" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2332;&#2379;&#2337;&#2375;&#2306; "
                                    CssClass="btn" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="tab">
                        <tr>
                            <th>&#2330;&#2351;&#2344;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Selected Titles
                            </th>
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
                                            Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2361;&#2335;&#2366;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; &#2330;&#2369;&#2344;&#2375;&#2306;"
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
                                <asp:BoundField DataField="Medium" ReadOnly="true" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; / Medium" />
                                <%--<asp:BoundField DataField="Title" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />--%>
                                <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblFtTitle" runat="server" Text="&#2325;&#2369;&#2354; &#2351;&#2379;&#2327;"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Rate" ReadOnly="true"
                                    HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;) / Rate (Rs.)" />
                                <%-- <asp:BoundField DataField="TotalBooks" ReadOnly="true" HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />--%>
                                <asp:TemplateField HeaderText="&#2360;&#2375;&#2335;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of sets">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBooks" runat="server" Text='<%# Eval("TotalBooks") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalBooks" runat="server" Text="0"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <%--  <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" ReadOnly="true"
                                    HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &nbsp;&#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351; (&#2352;&#2369;&#2346;&#2351;&#2375;)" />--%>
                                <asp:TemplateField HeaderText="&#2350;&#2370;&#2354;&#2381;&#2351; (&#2352;&#2369;&#2346;&#2319;) / Total Amount ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="DiscountPercent" DataFormatString="{0:N}" ReadOnly="true"
                                    HeaderText="&#2331;&#2370;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; / Discount Percentage" />
                                <%--  <asp:BoundField DataField="Discount" DataFormatString="{0:N}" ReadOnly="true" 
                                    HeaderText="&#2331;&#2370;&#2335;(&#2352;&#2369;&#2346;&#2319;)" />--%>
                                <asp:TemplateField HeaderText="&#2331;&#2370;&#2335; (&#2352;&#2369;&#2346;&#2319;) / Discount (Rs.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalDiscount" runat="server" Text="0"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <%--  <asp:BoundField DataField="NetAmount" DataFormatString="{0:N}" ReadOnly="true" 
                                    HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;)" />--%>
                                <asp:TemplateField HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;) / Net Amount (Rs.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetAmount" runat="server" Text='<%# Eval("NetAmount") %>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotalNetAmount" runat="server" Text='0'></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <FooterStyle BackColor="LightGray" Font-Bold="True" />
                        </asp:GridView>
                    </div>
                    <table class="tab">
                        <tr>
                            <td>&#2354;&#2376;&#2335;&#2352; &#2325;&#2368; &#2360;&#2381;&#2325;&#2376;&#2344;
                                &#2346;&#2381;&#2352;&#2340;&#2367;&#2354;&#2367;&#2346;&#2367; &#2309;&#2346;&#2354;&#2379;&#2337;
                                &#2325;&#2352;&#2375; / Upload Letter Scan Copy
                            </td>
                            <td>
                                <asp:FileUpload runat="server" CssClass="txtbox" ID="fileScanLetter" />
                            </td>
                            <td colspan="6"></td>
                        </tr>
                        <tr>
                            <th>
                                <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2361;&#2335;&#2366;&#2319;&#2306;"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');"
                                    OnClick="btnDelete_Click" />
                            </th>
                            <th>&#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2368;(&#2352;&#2370;&#2346;&#2319;) / Total Amount (Rs.)
                            </th>
                            <th>
                                <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                            </th>
                            <th>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; &#2325;&#2368; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2325;&#2369;&#2354; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;&#2346;&#2319;) / Total Demand in Financial Year (Rs.)</th>
                            <th>
                                <asp:Label ID="lblFinYrTotal" runat="server" Text="0"></asp:Label>
                            </th>
                            <th>&#2358;&#2375;&#2359; &#2352;&#2366;&#2358;&#2368; (&#2352;&#2369;&#2346;&#2319;)/ Remaining Amount (Rs.)</th>
                            <th>
                                <asp:Label ID="lblRemAmount" runat="server" Text="0"></asp:Label>
                            </th>

                            <th>
                                <asp:Button runat="server" ID="btnSupply" OnClick="btnSupply_Click" Text="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375; "
                                    OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                                <asp:HiddenField ID="mapID" runat="server" />
                            </th>
                        </tr>
                        <tr>
                            <td colspan="8"></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">

                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblPopupMsg" runat="server" Text="--"></asp:Label>.</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnClosePopup" runat="server" OnClick="btnClosePopup_OnClick" class="btn" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306;" /></td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSupply" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>

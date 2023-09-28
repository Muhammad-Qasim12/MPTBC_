<%@ Page Title="&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2319;&#2357;&#2306; &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Workorder And Agreement"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WorkOrderToPrinterDetails.aspx.cs"
    Inherits="Printing_WorkOrderToPrinterDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>कार्यादेश एवं अनुबंध की जानकारी</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSaveNew" runat="server" CssClass="btn-add" Text="नया डाटा डाले" OnClick="btnSaveNew_Click" />
                </div>
            </div>

        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" CssClass="form-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"></asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTenderID_I" CssClass="form-select" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged"></asp:DropDownList>
                        <label>टेंडर नंबर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="form-select">
                            <asp:ListItem Value="0" Text="All"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-submit" OnClick="btnAdd_Click" Text="खोजे" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdWorkOrderDetails" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-hover" DataKeyNames="WorkorderID_I" OnRowDeleting="GrdWorkOrderDetails_RowDeleting"
                            AllowPaging="True" OnPageIndexChanging="GrdWorkOrderDetails_PageIndexChanging"
                            OnRowDataBound="GrdWorkOrderDetails_RowDataBound"
                            OnSelectedIndexChanged="GrdWorkOrderDetails_SelectedIndexChanged">
                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="प्रिंटर का नाम" DataField="NameofPress_V" />
                                <asp:BoundField HeaderText="टेंडर नंबर" DataField="LOINo_V" />
                                <asp:BoundField HeaderText="ग्रुप की जानकारी" DataField="LOIDate_D" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="कार्यादेश क्रमांक" DataField="WorkorderNo_V" />
                                <asp:BoundField HeaderText="कार्यादेश दिनांक" DataField="WorkOrderDate_D" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="अनुबंध की स्थिति" DataField="state" />
                                <asp:TemplateField HeaderText="ग्रुप की जानकारी">
                                    <ItemTemplate>
                                        <asp:Label ID="lblViewgroup" runat="server" Text='<%#Eval("WorkorderID_I") %>' Visible="false"></asp:Label>
                                        <asp:LinkButton ID="lnBtnViewGroup" CssClass="btn-grid" runat="server" OnClick="lnBtnViewGroup_Click"
                                            Text="देखें"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <asp:Panel ID="pn1" runat="server" Visible='<%#Eval("isAgreement_I").ToString().Equals("1")?false:true%>'>
                                            <a href="WorkOrderToPrinter.aspx?ID=<%#new APIProcedure().Encrypt(Eval("WorkorderID_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352;
                                                &#2325;&#2352;&#2375;</a>
                                        </asp:Panel>
                                        <asp:Panel ID="pnl2" runat="server" Visible='<%#Eval("isAgreement_I").ToString().Equals("1")?true:false%>'>
                                            &#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352;
                                            &#2325;&#2352;&#2375;
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="कार्यादेश ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblViewWorkOrder" runat="server" Text='<%#Eval("WorkorderID_I") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Panel ID="Panel111" runat="server" Visible='<%#Eval("WorkorderFilePath_VDtl").ToString().Equals("1")?false:true%>'>
                                            <a href='<%#new APIProcedure().Encrypt(Eval("WorkorderFilePath_VDtl").ToString())%>'>&#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;</a>
                                        </asp:Panel>

                                        <%--<asp:LinkButton ID="lnBtnViewWorkOrder" runat="server"  OnClick="lnBtnViewWorkOrder_Click" Text="&#2342;&#2375;&#2326;&#2375;&#2306;"></asp:LinkButton>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Agreement Detail">
                                    <ItemTemplate>
                                        <asp:Label ID="lblisAgreement_I" runat="server" Text='<%#Eval("isAgreement_I") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblViewAcceptance" runat="server" Text='<%#Eval("WorkorderID_I") %>'
                                            Visible="false"></asp:Label>
                                        <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("isAgreement_I").ToString().Equals("1")?false:true%>'>
                                            <asp:LinkButton ID="lnBtnViewAcceptance" runat="server" OnClick="lnBtnViewAcceptance_Click"
                                                Text="&#2349;&#2352;&#2375;"></asp:LinkButton>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel2" runat="server" Visible='<%#Eval("isAgreement_I").ToString().Equals("1")?true:false%>'>
                                            &#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2361;&#2379; &#2330;&#2369;&#2325;&#2366;
                                        </asp:Panel>
                                        <asp:Panel ID="Panel3" runat="server" Visible='<%#Eval("isAgreement_I").ToString().Equals("1")?true:false%>'>
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lnBtnViewAcceptance1_Click"
                                                Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; "></asp:LinkButton>
                                        </asp:Panel>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--  <asp:TemplateField HeaderText="&#2361;&#2335;&#2366;&#2351;&#2375;">
                                    <ItemTemplate>
                                        <asp:Panel ID="pnlDelete" runat="server" Visible='<%#Eval("isAgreement_I").ToString().Equals("1")?false:true%>'>
                                            <asp:LinkButton ID="lnkDelete" runat="server" OnClick="lnkDelete_Click" CausesValidation="false"
                                                Text="&#2361;&#2335;&#2366;&#2351;&#2375;"></asp:LinkButton>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                </div>
            </div>
        </div>
</div>
    <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>
    <div id="MessagesGroup" style="display: none; width: 80%; left: 5%" class="popupnew"
        runat="server">
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("GrpID_I") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Group No.">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("GroupNO_V") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /  Title "
                                DataField="TitleHindi_V" />
                            <asp:BoundField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages"
                                DataField="Noofpages" />
                            <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Books"
                                DataField="TotNoOfBooks" />
                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375;) / Printing Quantity in Ton"
                                DataField="Qty_PriPaper" />
                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name"
                                DataField="NameofPress_V" />
                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2342;&#2352; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;) / Amount (in Rs.)"
                                DataField="rate" />
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
    </div>
    <div id="MessagesAcceptance" style="display: none; width: 80%; left: 5%" class="popupnew"
        runat="server">
        <table width="100%" style="font-size: 14px">
            <tr>
                <td>&#2332;&#2377;&#2348; &#2325;&#2366;&#2352;&#2381;&#2337; &#2344;&#2306;&#2348;&#2352;
                    : :
                </td>
                <td>
                    <asp:TextBox ID="txtJobCardNo" runat="server" MaxLength="12" CssClass="txtbox reqirerd"
                        ReadOnly="true"></asp:TextBox>
                </td>
                <td>&#2309;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2344;&#2306;&#2348;&#2352;
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtAgreeMentNo" runat="server" MaxLength="12" CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
                <td>&#2309;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtAgreeMentDate" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
            </tr>
            <%--start update code 15-03-2016--%>
            <tr>
                <td>&#2309;&#2344;&#2381;&#2340;&#2367;&#2350; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                </td>
                <td>
                    <asp:TextBox ID="txtLastDate" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
                <td>&#2350;&#2366;&#2306;&#2327;&#2368; &#2327;&#2312; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2360;&#2367;&#2325;&#2381;&#2351;&#2369;&#2352;&#2367;&#2335;&#2368; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)
                </td>
                <td>
                    <asp:TextBox ID="txtPrinterSecurityAmount" runat="server" MaxLength="10" CssClass="txtbox reqirerd"
                        onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                </td>
                <td>&#2350;&#2366;&#2306;&#2327;&#2368; &#2327;&#2312; &#2346;&#2375;&#2346;&#2352; &#2360;&#2367;&#2325;&#2381;&#2351;&#2369;&#2352;&#2367;&#2335;&#2368; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;)
                </td>
                <td>
                    <asp:TextBox ID="txtPaperSecurityAmount" runat="server" MaxLength="10" CssClass="txtbox reqirerd"
                        onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                </td>
            </tr>
            <%--end update code--%>
            <tr>
                <td>&#2332;&#2350;&#2366; &#2325;&#2368; &#2327;&#2312; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2360;&#2367;&#2325;&#2381;&#2351;&#2369;&#2352;&#2367;&#2335;&#2368; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;) :
                </td>
                <td>
                    <asp:TextBox ID="txtPrinterSecuAmt" runat="server" MaxLength="10" CssClass="txtbox reqirerd"
                        onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                </td>
                <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2360;&#2367;&#2325;&#2381;&#2351;&#2370;&#2352;&#2367;&#2335;&#2368; &#2357;&#2367;&#2357;&#2352;&#2339; :
                </td>
                <td>
                    <asp:TextBox ID="txtPrinterRemark" runat="server" MaxLength="100" CssClass="txtbox reqirerd"></asp:TextBox>
                </td>
                <td>&#2332;&#2350;&#2366; &#2325;&#2368; &#2327;&#2312; &#2346;&#2375;&#2346;&#2352; &#2360;&#2367;&#2325;&#2381;&#2351;&#2370;&#2352;&#2367;&#2335;&#2368;
                    &#2352;&#2366;&#2358;&#2367; :
                </td>
                <td>
                    <asp:TextBox ID="txtPaperSecAmt" runat="server" MaxLength="10" CssClass="txtbox reqirerd"
                        onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&#2346;&#2375;&#2346;&#2352; &#2360;&#2367;&#2325;&#2381;&#2351;&#2370;&#2352;&#2367;&#2335;&#2368;
                    &#2357;&#2367;&#2357;&#2352;&#2339; :
                </td>
                <td>
                    <asp:TextBox ID="txtPaperRemark" runat="server" MaxLength="100" CssClass="txtbox reqirerd"> </asp:TextBox>
                </td>
                <td></td>
                <td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;"
                        OnClientClick='javascript:return ValidateAllTextForm();' OnClick="btnSave_Click" />
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnBtnBack_Click"> &#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
    </div>
    <div id="MessagesWorkOrder" style="display: none; width: 90%; left: 5%; top: 12%;"
        class="popupnew" runat="server">
        <table width="100%">
            <tr>
                <td colspan="4" style="text-align: center">
                    <iframe id="IframeViewWorkOrder" runat="server" style="height: 600px; width: 800px;"></iframe>
                </td>
            </tr>
        </table>
        </p>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnBtnBack_Click">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
    </div>
    <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtAgreeMentDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

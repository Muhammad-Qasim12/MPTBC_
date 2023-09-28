<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddTenderDetails.aspx.cs" Inherits="Printing_AddTenderDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>टेंडर की जानकारी दर्ज करें</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Label ID="messageDiv" runat="server" CssClass="alert alert-success" Font-Bold="True" ForeColor="Red" Style="display: none"></asp:Label>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlAcdmicYr_V" runat="server" CssClass="form-select reqirerd"
                            OnSelectedIndexChanged="ddlAcdmicYr_V_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem Value="2014-2015">2014-2015</asp:ListItem>
                        </asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTenderType_V" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem Value="Web Offset" Text="Web Offset"></asp:ListItem>
                            <asp:ListItem Value="Sheet Fed" Text="Sheet Fed"></asp:ListItem>
                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                        <label>टेंडर का प्रकार</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTenderNo_V" runat="server" CssClass="form-control reqirerd" MaxLength="30"></asp:TextBox>
                        <label>टेंडर क्रमांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTenderDate_D" runat="server" TextMode="Date" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtTenderDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>टेंडर दिनाँक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtLUNSendNo_V" runat="server" CssClass="form-control reqirerd" MaxLength="30"></asp:TextBox>
                        <label>LUN(एल.यू.एन.) क्रमांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtLUNDate_D" runat="server" TextMode="Date" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLUNDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>टेंडर LUN(एल.यू.एन.) के लिए भेजने की दिनाँक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtNITDate_D" runat="server" TextMode="Date" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtNITDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>NIT निविदा पब्लिशिंग दिनाँक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTenderDocFee_N" runat="server" CssClass="form-control reqirerd" MaxLength="6"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTenderDocFee_N"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>टेंडर डॉक्यूमेंट फीस (Rs.)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTenderSubmissionDate_D" runat="server" TextMode="Date" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender" runat="server" TargetControlID="txtTenderSubmissionDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>टेंडर सबमिशन दिनाँक </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTechBidopeningDate_D" runat="server" TextMode="Date" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTechBidopeningDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>टेक्निकल बिड खुलने की दिनाँक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCommecialBidOpeningdate_D" runat="server" TextMode="Date" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCommecialBidOpeningdate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>कमर्शियल बिड खुलने की दिनाँक </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDays" runat="server" CssClass="form-control reqirerd" MaxLength="3"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtDays"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>कार्य पुर्ण करने के दिन</label>
                    </div>
                </div>
                <div class="inner-box" id="tblbookDtl" runat="server" visible="false">
                    <div class="row">
                        <div class="col-md-12 mb-4">
                            <h5 class=""><b>टेंडर में आने वाले ग्रुप सेलेक्ट करें </b></h5>
                        </div>

                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlMedium" runat="server"
                                    CssClass="form-select" OnInit="DdlMedium_Init">
                                    <asp:ListItem>Select..</asp:ListItem>
                                    <asp:ListItem>&#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:ListItem>
                                    <asp:ListItem>&#2309;&#2306;&#2327;&#2381;&#2352;&#2375;&#2332;&#2368;  &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:ListItem>
                                    <asp:ListItem>&#2360;&#2306;&#2360;&#2381;&#2325;&#2371;&#2340; &#2358;&#2366;&#2354;&#2366; </asp:ListItem>
                                    <asp:ListItem>&#2313;&#2352;&#2381;&#2342;&#2370; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  </asp:ListItem>
                                    <asp:ListItem>&#2313;&#2352;&#2381;&#2342;&#2370; &#2349;&#2366;&#2359;&#2366; </asp:ListItem>
                                    <asp:ListItem>&#2350;&#2342;&#2352;&#2360;&#2366;</asp:ListItem>
                                    <asp:ListItem>&#2350;&#2352;&#2366;&#2336;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:ListItem>
                                </asp:DropDownList>
                                <label>माध्यम </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlClass" runat="server"
                                    CssClass="form-select" OnInit="DdlClass_Init">
                                    <asp:ListItem>All</asp:ListItem>
                                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2407; </asp:ListItem>
                                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2408;  </asp:ListItem>
                                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2409; </asp:ListItem>
                                    <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2410;  </asp:ListItem>
                                </asp:DropDownList>
                                <label>कक्षा </label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button runat="server" ID="btnSearch" Text="खोजे" CssClass="btn btn-submit" OnClick="btnSearch_Click" />
                        </div>
                        <div class="col-md-12">
                            <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False"
                                CssClass="table table-bordered" DataKeyNames="GrpID_I"
                                OnRowDataBound="GrdGroupDetails_RowDataBound"
                                EmptyDataText="Record Not Found" ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("GrpID_I") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; / Group">
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
                                    <%--<asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;" DataField="GroupNO_V" />--%>
                                    <asp:BoundField DataField="TitleHindi_V"
                                        HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title ">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cLASSDET_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Pages_n" HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages ">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="noofBookYojna" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366; / Alloted Scheme">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="noofBookSamana" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; / Alloted General ">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="totnoofbooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344; / Total Allotment">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="qty_pripaper" HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2335;&#2344; &#2350;&#2375; ) / Quantity of Printing Paper (in Ton) ">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="qty_Covpaper" HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2358;&#2368;&#2335; &#2350;&#2375; ) /Quantity of Paper (in Sheet) ">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2325;&#2352;&#2375;&#2306; / Select">



                                        <HeaderTemplate>
                                            <asp:CheckBox ID="CheckBox12" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox12_CheckedChanged" Text="Select All" />
                                        </HeaderTemplate>



                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGroup" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="सेव करे" OnClientClick='javascript:return ValidateAllTextForm();'
                        OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>


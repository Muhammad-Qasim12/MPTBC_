<%@ Page Title="&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Allotment Details"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PaperAllotmentReturn.aspx.cs" Inherits="Printing_PaperAllotmentReturn" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>पेपर आवंटन की जानकारी</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="acd_titledetail" runat="server" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlAcadmicYear_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <label>शैक्षणिक सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinterName_SelectedIndexChanged1" Style="height: 18px">
                        </asp:DropDownList>
                        <label>प्रिंटर का नाम </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="">
                        <label>वर्क आर्डर नंबर</label>
                        <asp:RadioButton ID="rdoCPD" Checked="true" AutoPostBack="true" Text="Central Depot" GroupName="rtype" runat="server" OnCheckedChanged="rdoCPD_CheckedChanged" />
                        <asp:RadioButton ID="rdoPrinter" Text="Printer" AutoPostBack="true" GroupName="rtype" runat="server" OnCheckedChanged="rdoCPD_CheckedChanged" />

                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtSupplydate_D" runat="server" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalSupplydate_D" TargetControlID="txtSupplydate_D"
                            runat="server">
                        </cc1:CalendarExtender>
                        <label>पेपर आर्डर दिनांक </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtOrderNo" runat="server" AutoPostBack="true" CssClass="form-control reqirerd"
                            MaxLength="10" onkeypress="javascript:fnSetPhoneDigits(event, this);" OnTextChanged="txtOrderNo_TextChanged"></asp:TextBox>
                        <%#Eval("PaperType")%>
                        <label>पेपर आर्डर नंबर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinter2" Visible="false" runat="server" CssClass="form-select reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinterName_SelectedIndexChanged1">
                        </asp:DropDownList>
                        <asp:Label ID="lblCPD" Text="Central Depot" CssClass="form-control" Visible="true" runat="server"></asp:Label>
                        <label>Return To  / को वापस</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <label>पेपर सिक्यूरिटी राशि</label>
                    <strong>
                        <asp:Label ID="Label1" runat="server"></asp:Label></strong>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdWorkPlan0" runat="server" AutoGenerateColumns="False" GridLines="None"
                        CssClass="table table-bordered" EmptyDataText="Record Not Found." Width="100%"
                        OnRowDataBound="GrdWorkPlan_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Paper Type">
                                <ItemTemplate>
                                    <%#Eval("PaperType")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                <ItemTemplate>
                                    <%#Eval("CoverInformation")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br>Paper Quantity">
                                <ItemTemplate>
                                    <%#Eval("NoOfReels")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="NetWt" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; " />
                            <asp:TemplateField HeaderText="&#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; &#2335;&#2344;">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" Text="0" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);' Width="50px" Visible='<%# Eval("PaperType_I").ToString()=="2" ? false  : true %>'></asp:TextBox>


                                    <asp:HiddenField ID="hdPaperMstrTrId_I" runat="server" Value='<%#Eval("PaperMstrTrId_I")%>' />
                                    <asp:HiddenField ID="hdPaperType" runat="server" Value='<%#Eval("PaperType_I")%>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; &#2358;&#2368;&#2335; &#2350;&#2375;&#2306; ">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox2" Text="0" runat="server" onkeypress='javascript:tbx_fnNumeric(event, this);' Width="50px" Visible='<%# Eval("PaperType_I").ToString()=="1" ? false  : true %>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375;  ">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />

                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <table width="100%">
                        <tr runat="server" visible="false">
                            <td colspan="4">
                                <asp:TextBox ID="txtPaperQuantity" runat="server" CssClass="form-control reqirerd" MaxLength="12"
                                    onkeypress="javascript:tbx_fnSignedNumeric(event, this);"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFieldPqty" ForeColor="Red" runat="server" ErrorMessage="Please enter quantity."
                                    ControlToValidate="txtPaperQuantity" InitialValue="0" Text="*" ValidationGroup="VV"></asp:RequiredFieldValidator>
                                <asp:Button runat="server" ID="btnADD" CssClass="btn" ValidationGroup="VV" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                                    OnClick="btnADD_Click" />
                                <asp:DropDownList ID="ddlPaperSize" runat="server" CssClass="form-control reqirerd" OnInit="ddlPaperSize_Init">
                                </asp:DropDownList>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged" OnInit="ddlPaperType_Init">
                                </asp:DropDownList>

                                <asp:TextBox runat="server" ID="txtTotalSheets" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                                    MaxLength="15"></asp:TextBox>
                            </td>

                        </tr>
                        <tr runat="server">
                            <td colspan="4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="जानकारी दर्ज करे"
                                    OnClientClick="return ValidateAllTextForm();" OnClick="btnSave_Click" />
                            </td>

                        </tr>
                        <tr runat="server">
                            <td colspan="4">
                                <asp:GridView ID="GrdPaperAllotment" runat="server" AutoGenerateColumns="False" CssClass="tab" ShowFooter="True">
                                    <Columns>
                                        <asp:BoundField DataField="AcYear" HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year" />
                                        <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name" />
                                        <asp:BoundField DataField="CoverInformation" HeaderText="Cover Information" />
                                        <asp:BoundField DataField="PaperType" HeaderText="Paper Type" />
                                        <asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352;  / Order No" />
                                        <asp:BoundField DataField="ReternTo" HeaderText="ReternTo" />
                                        <asp:BoundField DataField="IssueTo" HeaderText="IssueTo" />
                                        <asp:BoundField DataField="NoOfReels" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352;  / Printing Paper(Tons)" />
                                        <asp:BoundField DataField="NetWt" HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352;  / Coverpaper Sheet" />
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdOrderno" runat="server" Value='<%# Eval("OrderNo") %>' />
                                                <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')"
                                                    runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                                    CssClass="tab" EmptyDataText="Record Not Found." Width="100%" AllowPaging="false"
                                    OnRowDataBound="GrdWorkPlan_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex+1 %>.
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br> Paper Type">
                                            <ItemTemplate>
                                                <%#Eval("PaperType")%>
                                                <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                                    Visible="false"></asp:Label>
                                                <asp:Label ID="lblpprAlltChild_id" runat="server" Text='<%#Eval("pprAlltChild_id")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; <br>Paper Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaperQuantity_N" runat="server" Text='<%#Eval("PaperQty_N")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText=" &#2325;&#2369;&#2354; &#2358;&#2368;&#2335; / Total Sheets">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotSheets")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />

                                </asp:GridView>

                            </td>

                        </tr>
                    </table>
                </div>
                <div class="col-md-12">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Button runat="server" ID="btnADD0" CssClass="btn btn-submit" ValidationGroup="VV" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; "
                        OnClick="btnADD0_Click" Visible="False" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

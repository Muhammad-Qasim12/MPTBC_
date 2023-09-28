<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterestOnPaper.aspx.cs" Inherits="Printing_InterestOnPaper" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>Interest on Paper</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel ID="mainDiv" runat="server" class="form-message success" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" runat="server" class="notification">                
                        </asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlAcadmicYear" runat="server" CssClass="form-select reqirerd"></asp:DropDownList>
                        <label>शैक्षणिक सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="form-select reqirerd" AutoPostBack="True">
                        </asp:DropDownList>
                        <label>प्रिंटर का नाम </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtChalanrecDate" runat="server" CssClass="form-select reqirerd" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtChalanrecDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChalanrecDate">
                        </cc1:CalendarExtender>
                        <label>Challan Upto Date</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:LinkButton ID="BtnGetReport"
                        Text="Get Details"
                        runat="server" CssClass="btn btn-submit" OnClick="BtnGetReport_Click"></asp:LinkButton>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdPaperBill" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover" DataKeyNames="PriTransID"
                        OnRowDeleting="GrdPaperBill_RowDeleting" AllowPaging="false"
                        OnPageIndexChanging="GrdPaperBill_PageIndexChanging"
                        OnSelectedIndexChanged="GrdPaperBill_SelectedIndexChanged"
                        OnRowCommand="GrdPaperBill_RowCommand"
                        OnRowUpdating="GrdPaperBill_RowUpdating">
                        <Columns>

                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<br/>Sr.No.">
                                <AlternatingItemTemplate>
                                    &#2348;&#2367;&#2354; &#2350;&#2375;&#2306; &#2332;&#2379;&#2337;&#2375;&#2306; /<br />
                                    Add to Bill
                                </AlternatingItemTemplate>
                                <EditItemTemplate>
                                    &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; /<br />
                                    Academic Year
                                </EditItemTemplate>
                                <FooterTemplate>
                                    &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /<br />
                                    Printer Name
                                </FooterTemplate>
                                <HeaderTemplate>
                                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/<br />
                                    ChalanNumber
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<br />
                                    Sr.No.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2350;&#2375;&#2306; &#2332;&#2379;&#2337;&#2375;&#2306; /<br/>Add to Bill">
                                <ItemTemplate>

                                    <asp:CheckBox ID="ChkIsOk" runat="server" Checked="True" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;  /<br/>Academic Year">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAcYear" Text='<%# Eval("AcYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/<br/>  ChalanNumber">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblChalanNo" Text='<%# Eval("ChalanNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /<br/> Printer Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNameofPress_V" Text='<%# Eval("NameofPress_V") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/<br/> Book Recieved date">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTransactionDate_N" Text='<%# Eval("TransactionDate_N") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2360;&#2346;&#2381;&#2354;&#2366;&#2312; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/<br/> Paper Supply date">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPaperSupplydate"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /<br/>Total No Of Books">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTotalNoOfBooks" Text='<%# Eval("TotalNoOfBooks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2342;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; ) / Paper Quantity (in Ton)">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPaperQty_N" Text='<%# Eval("TotalWaight") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="&#2325;&#2369;&#2354; &#2348;&#2381;&#2351;&#2366;&#2332; /<br/>Intrest On Paper">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIntrestOnPaper"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2346;&#2352; &#2311;&#2306;&#2335;&#2352;&#2375;&#2360;&#2381;&#2335; / Interest on Paper">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnBtnViewSave" runat="server" CommandName="Update" Text="&#2311;&#2306;&#2335;&#2352;&#2375;&#2360;&#2381;&#2335; &#2325;&#2368; &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;"></asp:LinkButton>
                                    <asp:HiddenField ID="HdnPrinterID" runat="server" Value='<%#Eval("PrinterID") %>'></asp:HiddenField>
                                    <asp:HiddenField ID="HdnTitleID_I" runat="server" Value='<%#Eval("TitleID_I") %>'></asp:HiddenField>
                                    <asp:HiddenField ID="HiddenTrtype" runat="server" Value='<%#Eval("TrType") %>'></asp:HiddenField>
                                    <asp:Label ID="LblTrType" runat="server" Text='<%#Eval("TrType") %>'></asp:Label>
                                    <asp:Label ID="HdnPriTransID" runat="server" Text='<%#Eval("PriTransID") %>'></asp:Label>
                                    <asp:HiddenField ID="HdnDepo_I" runat="server" Value='<%#Eval("Depo_I") %>'></asp:HiddenField>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />

                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:LinkButton ID="BtnCalculate"
                        Text="Calculate"
                        runat="server" CssClass="btn btn-submit" OnClick="BtnCalculate_Click"></asp:LinkButton>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdBillIntrast" runat="server" AutoGenerateColumns="False" OnRowDataBound="GrdBillIntrast_RowDataBound"
                        CssClass="table table-bordered table-hover" DataKeyNames="PriTransID" ShowFooter="true" AllowPaging="false">
                        <Columns>

                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/<br/>Sr.No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2348;&#2367;&#2354; &#2350;&#2375;&#2306; &#2332;&#2379;&#2337;&#2375;&#2306; /<br/>Add to Bill">
                                <ItemTemplate>

                                    <asp:CheckBox ID="ChkIsOk" Enabled="false" Checked="true" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;  /<br/>Academic Year">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblAcYear" Text='<%# Eval("AcYear") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText=" &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;/<br/>  ChalanNumber">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblChalanNo" Text='<%# Eval("ChalanNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /<br/> Printer Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblNameofPress_V" Text='<%# Eval("NameofPress_V") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/<br/> Book Recieved date">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTransactionDate_N" Text='<%# Eval("BookRecieveddate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2360;&#2346;&#2381;&#2354;&#2366;&#2312; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/<br/> Paper Supply date">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPaperSupplydate"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /<br/>Total No Of Books">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTotalNoOfBooks" Text='<%# Eval("TotalNoOfBooks") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2342;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; ) /<br/> Paper Quantity (in Ton)">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPaperQty_N" Text='<%# Eval("PaperQuantity") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    Total:
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2381;&#2351;&#2366;&#2332; /<br/>Intrest On Paper(&#8377;)">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblIntrestOnPaper"></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lblTotIntrest" runat="server"></asp:Label>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2348;&#2381;&#2351;&#2366;&#2332; &#2327;&#2339;&#2344;&#2366; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; /<br/>Interest Calculation Details">
                                <ItemTemplate>
                                    <asp:Label runat="server" Width="300px" ID="lblDetailsAll"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="false" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2346;&#2352; &#2311;&#2306;&#2335;&#2352;&#2375;&#2360;&#2381;&#2335;<br/> / Interest on Paper">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnBtnViewSave" runat="server" CommandName="Update" Text="&#2311;&#2306;&#2335;&#2352;&#2375;&#2360;&#2381;&#2335; &#2325;&#2368; &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375;"></asp:LinkButton>
                                    <asp:HiddenField ID="HdnPrinterID" runat="server" Value='<%#Eval("PrinterID") %>'></asp:HiddenField>
                                    <asp:HiddenField ID="HiddenTrtype" runat="server" Value='<%#Eval("TrType") %>'></asp:HiddenField>
                                    <%--  <asp:HiddenField ID="HdnTitleID_I" runat="server" Value='<%#Eval("TitleID_I") %>'></asp:HiddenField>

                                            <asp:HiddenField ID="HdnDepo_I" runat="server" Value='<%#Eval("Depo_I") %>'></asp:HiddenField>--%>
                                    <asp:Label ID="HdnPriTransID" runat="server" Text='<%#Eval("PriTransID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />

                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:LinkButton ID="lbSaveDetails"
                        Text="Save"
                        runat="server" CssClass="btn btn-submit" OnClick="lbSaveDetails_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>

    <div id="Messages" style="display: none; width: 50%; left: 5%" class="popupnew" runat="server">
        <h2>&nbsp;</h2>
        <div style="width: 100%">

            <table class="tab">


                <div align="right">
                    <asp:LinkButton ID="LinkClose"
                        Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375   ;  "
                        OnClick="LinkClose_Click" runat="server" CssClass="btn" ForeColor="White"></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" Text="    &#2360;&#2375;&#2357; &#2325;&#2352;&#2375; "
                        OnClick="btnSave_Click" runat="server" CssClass="btn" ForeColor="White"></asp:LinkButton>

                </div>



                <table class="tab">

                    <tr>
                        <th>
                            <%--Fill Renewal Detail--%>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2325; / Textbook Return Date</th>

                        <th>
                            <%-- Renewal Date--%>&#2342;&#2367;&#2344;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Days
                        </th>

                        <th>
                            <%--Renewal Fee(Rs)--%> &#2311;&#2306;&#2335;&#2352;&#2375;&#2360;&#2381;&#2335; (&#2352;&#2369; / &#2346;&#2381;&#2352;&#2340;&#2367; &#2342;&#2367;&#2344;) / Interest (Rs/ Day)
                        </th>
                        <th>
                            <%--Renewal Fee(Rs)--%>&#2311;&#2306;&#2335;&#2352;&#2375;&#2360;&#2381;&#2335; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; ) / Interest Amount (Rs.)
                        </th>

                        <th></th>
                    </tr>

                    <tr>

                        <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="txtBookReturnDate" runat="server" CssClass="txtbox reqirerd"
                                Width="65px" OnTextChanged="txtBookReturnDate_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalReturnDate_D"
                            TargetControlID="txtBookReturnDate" runat="server">
                        </cc1:CalendarExtender>


                        <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="txtNoDays" runat="server" CssClass="txtbox reqirerd"
                                Width="65px" OnTextChanged="txtNoDays_TextChanged"></asp:TextBox></td>
                        <td style="width: 100px; height: 23px">

                            <asp:TextBox ID="txtIntrestRateonDays" runat="server" Text="6"
                                CssClass="txtbox reqirerd" Width="156px"
                                OnTextChanged="txtIntrestRateonDays_TextChanged" AutoPostBack="true"></asp:TextBox></td>
                        <td style="width: 100px; height: 23px">
                            <asp:TextBox ID="txtIntrestAmount" runat="server" CssClass="txtbox reqirerd" Width="156px"></asp:TextBox></td>
                    </tr>
                </table>




            </table>

            <asp:HiddenField ID="HdnBillInt" runat="server" Value="0" />
            <asp:HiddenField ID="HdnPaperAltID_I" runat="server" Value="0" />
        </div>

        <%--<asp:Button ID="btnCal" runat="server" CssClass="btn" OnClick="btnCal_Click"  Text="&#2325;&#2376;&#2354;&#2325;&#2369;&#2354;&#2375;&#2335; &#2325;&#2352;&#2375;" />--%>
    </div>



</asp:Content>


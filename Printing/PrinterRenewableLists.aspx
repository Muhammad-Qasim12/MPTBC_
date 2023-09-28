<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterRenewableLists.aspx.cs" Inherits="Printing_PrinterRenewableLists" Title="Printer Renewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>प्रिंटर रिन्यूअल</h2>
            </div>
        <div class="card-body">
            
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtSearch" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                        <label>प्रिंटर का नाम खोजे</label>
                    </div>
                </div>
                <div class="col-md-4 pt-4">
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary" OnClick="btnAdd_Click"
                        Text="Search" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdPrinterRenew" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-bordered table-hover" DataKeyNames="Printer_RedID_I" AllowPaging="True" PageSize="10"
                        OnPageIndexChanging="GrdPrinterRenew_PageIndexChanging"
                        OnSelectedIndexChanged="GrdPrinterRenew_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="क्र.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="प्रिंटर रजिस्ट्रेशन क्रमांक" DataField="Regno_I" />
                            <asp:BoundField HeaderText="रजिस्ट्रेशन दिनांक" DataField="RegDate_D" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="प्रिंटर का नाम" DataField="Nameofpress_v" />
                            <asp:BoundField HeaderText="प्रिंटर का पता" DataField="FullAddress_V" />
                            <asp:TemplateField HeaderText="रिन्यूअल की जानकारी के लिये क्लिक करे">
                                <ItemTemplate>
                                    <a href="PrinterRenewable.aspx?ID=<%#new APIProcedure().Encrypt("0").ToString()%>&PrinterID=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString())%>" class="btn btn-success btn-sm"><i class="bi bi-plus-lg"></i></a> &nbsp;

                                    <asp:Label ID="lblPrinter_RedID_I" runat="server" Text='<%#Eval("Printer_RedID_I") %>' Visible="false"></asp:Label>
                                    <asp:LinkButton ID="lnBtnViewRenewal" runat="server" OnClick="lnBtnViewRenewal_Click" CssClass="btn btn-primary btn-sm"><i class="bi bi-pencil-square"></i></asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

    <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>
    <div id="Messages" style="display: none; width: 80%; left: 5%" class="popupnew" runat="server">

        <table width="100%">
            <tr>
                <td style="text-align: center">
                    <asp:GridView ID="GrdViewRenewable" runat="server" AutoGenerateColumns="False"
                        CssClass="tab" OnRowDeleting="GrdViewRenewable_RowDeleting" DataKeyNames="PriRenewalID_I">
                        <Columns>
                            <asp:BoundField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Renewal Date" DataField="Renewaldate_D" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;) / Renewal Amount (in Rs.)" DataField="Amount_I" />
                            <asp:BoundField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; (DD/chq./Cash) / Renewal Details" DataField="AmtDetail_V" />
                            <asp:BoundField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; / Renewal Date From" DataField="RenFrom_D" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / Renewal Date To" DataField="RenTo_D" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="&#2352;&#2367;&#2344;&#2381;&#2351;&#2370;&#2309;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2325;&#2375; &#2354;&#2367;&#2351;&#2375; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375; / Click Here for Renewal Detail">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <a href="PrinterRenewable.aspx?ID=<%#new APIProcedure().Encrypt(Eval("PriRenewalID_I").ToString()) %>&PrinterID=<%#new APIProcedure().Encrypt(Eval("Printer_RedID_I").ToString())%>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                            </td>
                                        </tr>
                                    </table>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>
        </table>

        <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
    </div>
</asp:Content>


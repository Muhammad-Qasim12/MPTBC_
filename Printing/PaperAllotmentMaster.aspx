<%@ Page Title="पेपर आवंटन मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperAllotmentMaster.aspx.cs" Inherits="Printing_PaperAllotmentMaster" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>पेपर आवंटन मास्टर</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="Button1" runat="server" CssClass="btn-add" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;"   
                            onclick="btnSave_Click" />
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
                        <asp:DropDownList runat="server" ID="txtSearch"
                            CssClass="form-select reqirerd">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-12">
                    <p class="text-right">
                        <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" Text="Export to Excel" OnClick="btnExport_Click" />
                    </p>
                    <asp:GridView ID="GrdPaperAllotment" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-bordered table-hover" DataKeyNames="PaperAltID_I"
                        onrowdeleting="GrdPaperAllotment_RowDeleting" AllowPaging="True"
                        onpageindexchanging="GrdPaperAllotment_PageIndexChanging"
                        onselectedindexchanged="GrdPaperAllotment_SelectedIndexChanged"
                        onrowcommand="GrdPaperAllotment_RowCommand" PageSize="50">
                        <columns>
                            <asp:BoundField HeaderText="शैक्षणिक सत्र" DataField="AcadmicYR_V" />
                            <asp:BoundField HeaderText="दिनांक" DataField="Supplydate_D" />
                            <asp:BoundField HeaderText="प्रिंटर का नाम" DataField="NameofPress_V" />
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="शीर्षक का नाम" />
                            <asp:BoundField HeaderText="आर्डर नंबर" DataField="OrderNo" />

                            <asp:BoundField HeaderText="प्रिंटिंग पेपर (Tons)" DataField="PaperQty_N" />
                            <asp:BoundField HeaderText="कवर पेपर" DataField="TotSheets" />

                            <asp:TemplateField HeaderText="प्रिंट करें">
                                <itemtemplate>
                                    <a href='PaperPrintOrder.aspx?OrderNo=<%# Eval("OrderNo") %>' class="btn-grid">प्रिंट करें </a>
                                </itemtemplate>
                            </asp:TemplateField>
                            <%--<asp:CommandField ShowDeleteButton="True"  HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" 
                                    DeleteText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; "/>--%>
                            <asp:TemplateField HeaderText="डाटा हटाये">
                                <itemtemplate>
                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn" Visible='<%#Eval("status").ToString().Equals("0")?true:false%>' Text="मास्टर डाटा हटाये " CommandName="btnDelete" CommandArgument='<%# Eval("PaperAltID_I") %>' OnClientClick="return confirm('Are you sure to Delete this record ?');" />
                                </itemtemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="प्रिंटर एवं सेन्ट्रल डिपो को भेजे">
                                <itemtemplate>
                                    <asp:Button ID="btnSend" runat="server" CssClass="btn" Visible='<%#Eval("status").ToString().Equals("0")?true:false%>' Text="प्रिंटर एवं सेन्ट्रल डिपो को भेजे" CommandName="cmdSend" CommandArgument='<%# Eval("PaperAltID_I") %>' OnClientClick="return confirm('Are you sure to sent this record to Printer and Central Depo ?');" />

                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:Label id="lblmsg" runat="server" CssClass="btn" Text="प्रिंटर एवं सेन्ट्रल डिपो को भेजा जा चूका है" Visible='<%#Eval("status").ToString().Equals("1")?true:false%>'></asp:Label>
                                </itemtemplate>
                            </asp:TemplateField>

                        </columns>
                        <pagerstyle cssclass="Gvpaging" />
                        <emptydatarowstyle cssclass="GvEmptyText" />
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <div id="ExportDiv" runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" DataKeyNames="PaperAltID_I"
                            AllowPaging="false" Visible="false">
                            <columns>
                                <asp:BoundField HeaderText="शैक्षणिक सत्र" DataField="AcadmicYR_V" />
                                <asp:BoundField HeaderText="दिनांक" DataField="Supplydate_D" />
                                <asp:BoundField HeaderText="प्रिंटर का नाम" DataField="NameofPress_V" />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="शीर्षक का नाम	" />
                                <asp:BoundField HeaderText="आर्डर नंबर" DataField="OrderNo" />

                                <asp:BoundField HeaderText="प्रिंटिंग पेपर (Tons)" DataField="PaperQty_N" />
                                <asp:BoundField HeaderText="कवर पेपर" DataField="TotSheets" />
                            </columns>
                            <pagerstyle cssclass="Gvpaging" />
                            <emptydatarowstyle cssclass="GvEmptyText" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


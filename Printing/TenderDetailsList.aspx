<%@ Page Title="टेंडर की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderDetailsList.aspx.cs" Inherits="Printing_TenderDetailsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>टेंडर की जानकारी</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="नया डाटा डाले" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" CssClass="form-select reqirerd" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"></asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="table-responsive-lg">
                        <asp:GridView ID="GrdTenderDetails" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-hover" DataKeyNames="TenderId_I"
                            OnRowDataBound="GrdTenderDetails_RowDataBound"
                            OnRowDeleting="GrdTenderDetails_RowDeleting" AllowPaging="True"
                            OnPageIndexChanging="GrdTenderDetails_PageIndexChanging">

                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक (1)">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("lunlist") %>' />
                                        <asp:HiddenField ID="HDNTenID" runat="server" Value='<%# Eval("TenderId_I") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="शिक्षा सत्र (2)" DataField="AcdmicYr_V" />
                                <asp:BoundField HeaderText="टेंडर का प्रकार (3)" DataField="TenderType_V" />
                                <asp:BoundField HeaderText="टेंडर क्रमांक (4)" DataField="TenderNo_V" />
                                <asp:TemplateField HeaderText="ग्रुप की जानकारी (5)">
                                    <ItemTemplate>
                                        <%#Eval("GroupNO_V") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField HeaderText="LUN(एल.यू.एन.) क्रमांक" DataField="LUNSendNo_V" Visible="false" />
                                <asp:BoundField HeaderText="टेंडर LUN(एल.यू.एन.) के लिए भेजने की दिनाँक" DataField="LUNDate_D" DataFormatString="{0:MMMM d,yyyy}" Visible="false" />
                                <asp:BoundField HeaderText="टेंडर सबमिशन दिनाँक (6)" DataField="TenderSubmissionDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                <asp:BoundField HeaderText="टेक्निकल बिड खुलने की दिनाँक (7)" DataField="TechBidopeningDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                                <asp:BoundField HeaderText="कमर्शियल बिड खुलने की दिनाँक (8)" DataField="CommecialBidOpeningdate_D" DataFormatString="{0:MMMM d,yyyy}" />

                                <asp:TemplateField HeaderText="डाटा में सुधार करे (9)">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="pnlTenderid" PostBackUrl='<%# "TenderDetails.aspx?ID="+ new APIProcedure().Encrypt(Eval("TenderId_I").ToString())   %>' Text="टेंडर में सुधार करे"> </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप में लाटरी नंबर का आवंटन (10)">
                                    <ItemTemplate>
                                        <a href="GroupLottoryOrder.aspx" >लाटरी आवंटन</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="मुद्रक द्वारा भरे गए ग्रुप की जानकारी (11)">
                                    <ItemTemplate>
                                        <a href="PrinterGroupAllotment.aspx" class="btn-grid">मुद्रक के ग्रुप की जानकारी</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="सेलेक्ट एल यू ऐन लिस्ट/ Select LUN List" Visible="false">
                                    <ItemTemplate>
                                        <asp:FileUpload runat="server" ID="flExcel" Width="90px" />
                                            <asp:Button ID="btnUploadFile" runat="server" Text="Upload" CssClass="btn btn-arrow-link" OnClick="btnUpload_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="तकनिकी बिड (12)">
                                    <ItemTemplate>
                                        <asp:Button ID="btnTechinical" runat="server" Text="तकनिकी बिड करें" CssClass="btn-grid" OnClick="btnTechinicalClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="कमर्शियल बिड (13)">
                                    <ItemTemplate>
                                        <asp:Button ID="btnFinancial" runat="server" Text="ग्रुप की दरें भरें" CssClass="btn-grid" OnClick="btnFinancialClick" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ग्रुप का आवंटन करें (14)">
                                    <ItemTemplate>
                                        <a  class="btn-grid" href="TechnicalBid.aspx?TenderId=<%#new APIProcedure().Encrypt(Eval("TenderId_I").ToString())%>">ग्रुप का आवंटन करें</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप की वरीयता सुनिश्चित करें (15)">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HdnTenEval" runat="server" Value='<%# Eval("TenEvalID_I") %>' />
                                        <a class="btn-grid" href="PrinterSelectGroup.aspx?TenderId=<%#new APIProcedure().Encrypt(Eval("TenderId_I").ToString())%>&Yr=<%#new APIProcedure().Encrypt(Eval("AcdmicYr_V").ToString())%> ">ग्रुप की वरीयता</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" Visible="False" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Title="टेंडर की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderDetailsFinance.aspx.cs" Inherits="Printing_TenderDetailsFinance" %>

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
                    <asp:GridView ID="GrdTenderDetails" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-bordered" DataKeyNames="TenderId_I"
                        AllowPaging="True">
                        <Columns>
                            <asp:TemplateField HeaderText="क्रमांक (1)">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
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

                            <asp:BoundField HeaderText="LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;   " DataField="LUNSendNo_V" Visible="false" />
                            <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2375; &#2354;&#2367;&#2319; &#2349;&#2375;&#2332;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; " DataField="LUNDate_D" DataFormatString="{0:MMMM d,yyyy}" Visible="false" />
                            <asp:BoundField HeaderText="टेंडर सबमिशन दिनाँक (6)" DataField="TenderSubmissionDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                            <asp:BoundField HeaderText="टेक्निकल बिड खुलने की दिनाँक (7)" DataField="TechBidopeningDate_D" DataFormatString="{0:MMMM d,yyyy}" />
                            <asp:BoundField HeaderText="कमर्शियल बिड खुलने की दिनाँक (8)" DataField="CommecialBidOpeningdate_D" DataFormatString="{0:MMMM d,yyyy}" />

                            <asp:TemplateField HeaderText="ई एम डी कि जानकारी   (9)">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="pnlTenderid" PostBackUrl='<%# "EMDTransferToFinance.aspx?ID="+ new APIProcedure().Encrypt(Eval("TenderId_I").ToString())   %>' Text="ई एम डी जानकारी में सुधार "> </asp:LinkButton>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ई एम डी का स्टेटस /E.M.D. Status (10) ">
                                <ItemTemplate>
                                    <asp:Panel ID="pn1a" runat="server" Visible='<%# Eval("STATUS").ToString()=="0" ? false  : true %>'>
                                        ई एम डी जानकारी में सुधार</a>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel1a" runat="server" Visible='<%#Eval("STATUS").ToString().Equals("1")?false:true%>'>
                                        <asp:LinkButton ID="lnBtnViewAcceptance" runat="server" OnClick="lnBtnViewAcceptance_Click"
                                            Text="फाइनेंस कों भेजे "></asp:LinkButton>
                                    </asp:Panel>
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
</asp:Content>


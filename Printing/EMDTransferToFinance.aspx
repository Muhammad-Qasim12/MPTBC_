<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EMDTransferToFinance.aspx.cs" Inherits="Printing_EMDTransferToFinance" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>EMD फाइनेंस को भेजे</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel ID="messDiv" runat="server">
                        <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-12">
                    <asp:Panel ID="Panel11" runat="server">
                        <table>
                            <tr>
                                <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :&nbsp;
                     <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="true" CssClass="txtbox reqirerd" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                     </asp:DropDownList>
                                </td>
                                <td>&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2335;&#2375;&#2306;&#2337;&#2352; </td>
                                <td>
                                    <asp:DropDownList ID="ddlTenderID_I" CssClass="txtbox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdEval" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" OnRowDataBound="GrdEval_RowDataBound"
                        ShowFooter="True" OnSelectedIndexChanged="GrdEval_SelectedIndexChanged">
                        <columns>


                            <asp:TemplateField HeaderText="क्रमांक">
                                <itemtemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="<br>Academic Year">
                                <itemtemplate>
                                    <asp:Label runat="server" ID="lblYear" Text='<%# Eval("myear") %>'></asp:Label>

                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="प्रिंटर का नाम">
                                <itemtemplate>
                                    <asp:Label runat="server" ID="lblPrinterName" Text='<%# Eval("PrinterName") %>'></asp:Label>

                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ग्रुप का नाम">
                                <itemtemplate>
                                    <asp:Label runat="server" ID="lblGroupName" Text='<%# Eval("GroupName") %>'></asp:Label>

                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="EMD राशि">
                                <itemtemplate>
                                    <asp:Label runat="server" ID="lblEMDAmount_N" Text='<%# Eval("EMDAmount_N") %>'></asp:Label>

                                </itemtemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="विवरण">
                                <itemtemplate>
                                    <asp:TextBox ID="txtRemark" runat="server" MaxLength="200" Text='<%#Eval("Remark") %>'></asp:TextBox>

                                </itemtemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="एम आर नंबर">
                                <itemtemplate>
                                    <asp:TextBox ID="lblTransferSts" runat="server" Text='<%#Eval("TransferSts") %>'></asp:TextBox>
                                </itemtemplate>
                                <footertemplate>
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary"
                                        Text="सुरक्षित करे"
                                        OnClick="btnSave_Click" />
                                </footertemplate>

                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="एम आर दिनांक">
                                <itemtemplate>
                                    <asp:TextBox ID="lblPrinterSts" runat="server" Text='<%# Eval("PrinterSts") %>'></asp:TextBox>
                                    <asp:Label runat="server" ID="lblPrinterid" Visible="false" Text='<%# Eval("Printerid_i") %>'></asp:Label>
                                </itemtemplate>
                                <footertemplate>
                                    <asp:Button runat="server" ID="btnclose" CssClass="btn btn-dark"
                                        Text="बंद करे"
                                        OnClick="btnclose_Click" />
                                </footertemplate>
                            </asp:TemplateField>
                        </columns>
                        <pagerstyle cssclass="Gvpaging" />
                        <emptydatarowstyle cssclass="GvEmptyText" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="head">
</asp:Content>



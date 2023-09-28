<%@ Page Title="अन्य पाठ्य सामग्री की मांग एवं पेपर का आकलन" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="DemandCreation.aspx.cs" Inherits="AcademicB_DemandCreation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>अन्य पाठ्य सामग्री की मांग एवं पेपर का आकलन / Other then TextBook Items Demand and Paper Estimation</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlBookDes" GroupingText=" शीर्षकों का चयन / Select Titles" Width="1150px"
                ScrollBars="Auto">
                <table>
                    <tr>
                        <td>
                            शीर्षक का नाम /Title
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTitle" AutoPostBack="true" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlTitle_OnSelectedIndexChanged"
                                runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            उप शीर्षक का नाम / Sub-Titles
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSubTitle" AutoPostBack="true" CssClass="txtbox reqirerd"
                                OnSelectedIndexChanged="ddlSubTitle_OnSelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           वितरण शाखा से कुल शीर्षकों का आबंटन / Total Allotment from Distribution
                        </td>
                        <td>
                            <asp:Label ID="lblTotalQuantity" runat="server" Text="0"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         प्रत्येक शीर्षक में पृष्ठ संख्या / Total Pages Per Title
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalPages" runat="server" onkeypress='javascript:tbx_fnInteger(event, this);'
                                MaxLength="4" Text="0"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         एक सेट में कुल शीर्षक / Total Title in one set
                        </td>
                        <td>
                            <asp:TextBox ID="txtTottitleinOneSet" runat="server" onkeypress='javascript:tbx_fnInteger(event, this);'
                                MaxLength="4" Text="0"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlItemDesc" GroupingText=" अन्य पाठ्य सामग्री का विवरण / Details of Other then TextBook Items"
                Width="1150px" ScrollBars="Auto">
                <table>
                    <tr>
                        <td>
                            अन्य पाठ्य सामग्री आकार(चौड़ाईxलम्बाई)(से.मी.x से. मी.) / Other then TextBook Item Size(WxL)(CMxCM)
                        </td>
                        <td>
                            <asp:TextBox ID="txtSize" runat="server" Text="0"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="meeTxtSize" MaskType="Number" TargetControlID="txtSize"
                                Mask="99C99" Filtered="99x99" runat="server">
                            </cc1:MaskedEditExtender>
                            <asp:RegularExpressionValidator ID="reTxtSize" ValidationExpression="\d{2}x\d{2}"
                                runat="server" ErrorMessage="Incorrect data format" ForeColor="Red" ControlToValidate="txtSize"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            बाइंडिंग/ Binding
                        </td>
                        <td>
                            <asp:TextBox ID="txtBinding" MaxLength="30" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            प्रिंटिंग पेपर का प्रकार (GSM) / Type of Printing Paper(GSM)
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlPaperGSM" CssClass="txtbox reqirerd" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            कवर पेपर का प्रकार (GSM) / Type of Cover Paper(GSM)
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCoverGSM" CssClass="txtbox reqirerd" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            टेक्स्ट मैटर कलर योजना /Colour Scheme of Text Matter
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTextColour" CssClass="txtbox reqirerd" runat="server">
                                <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                <asp:ListItem Text="Double" Value="Double"></asp:ListItem>
                                <asp:ListItem Text="Multi" Value="Multi"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            कवर पेपर कलर योजना (1 एवं 4) /Cover Page Colour Scheme 1&4
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCoverColour1n4" CssClass="txtbox reqirerd" runat="server">
                                <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                <asp:ListItem Text="Double" Value="Double"></asp:ListItem>
                                <asp:ListItem Text="Multi" Value="Multi"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            कवर पेपर कलर योजना (2 एवं 3)/Cover Page Colour Scheme 2&3
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCoverColour2n3" CssClass="txtbox reqirerd" runat="server">
                                <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                                <asp:ListItem Text="Double" Value="Double"></asp:ListItem>
                                <asp:ListItem Text="Multi" Value="Multi"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                          रीम फेक्टर/Reem Factor
                        </td>
                        <td>
                              <asp:TextBox ID="txtReemfactor" onkeypress='javascript:tbx_fnInteger(event, this);' runat="server" Text="20000"></asp:TextBox>
                        </td>
                    </tr>

                     <tr>
                        <td>
                           &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="btnAddTitle" OnClick="btnAddTitle_Click" runat="server" CssClass="btn"
                                OnClientClick='javascript:return ValidateAllTextForm();' Text="विवरण जोडें/ Add Details" /> 
                        </td>
                        <td>
                               
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="grdSelectedTitle" CssClass="tab" runat="server" AutoGenerateColumns="false"
                                OnRowDeleting="grdSelectedTitle_OnRowDeleting" >
                                <Columns>
                                    <asp:BoundField DataField="TitleSize" HeaderText="अन्य पाठ्य सामग्री आकार(लम्बाईxचौड़ाई) / Other then TextBook Item Size(WxL)(CMxCM) " />
                                    <asp:BoundField DataField="Binding" HeaderText="बाइंडिंग /Binding " />
                                    <asp:BoundField DataField="PrintingPaperType" HeaderText="प्रिंटिंग पेपर का प्रकार (GSM)/ Type of Printing Paper(GSM)" />
                                    <asp:BoundField DataField="CoverPaperType" HeaderText="कवर पेपर का प्रकार (GSM)/ " />
                                    <asp:BoundField DataField="TextColourScheme" HeaderText="टेक्स्ट मैटर कलर योजना /Colour Scheme of Text Matter" />
                                    <asp:BoundField DataField="CoverColourScheme1n4" HeaderText="कवर पेपर कलर योजना (1 एवं 4) /Cover Page Colour Scheme 1&4  " />
                                    <asp:BoundField DataField="CoverColourScheme2n3" HeaderText="कवर पेपर कलर योजना (2 एवं 3) /Cover Page Colour Scheme 2&3 " />
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrintingPaperID" runat="server" Text='<%# Eval("PrintingPaperID") %>'></asp:Label>
                                             <asp:Label ID="lblPrintingPaperGSM" runat="server" Text='<%# Eval("PrintingPaperGSM") %>'></asp:Label>
                                             <asp:Label ID="lblCoverPaperID" runat="server" Text='<%# Eval("CoverPaperID") %>'></asp:Label>
                                            <asp:Label ID="lblCoverPaperGSM" runat="server" Text='<%# Eval("CoverPaperGSM") %>'></asp:Label>
                                              <asp:Label ID="lblReemFactor" runat="server" Text='<%# Eval("ReemFactor") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TotalTitleInOneSet" HeaderText="एक सेट में कुल शीर्षक / Total Title in one set" />
                                     <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="हटाएं/Delete"
                                                        OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                         <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn" 
                                OnClientClick='javascript:return ValidateAllTextForm();'  Text="सुरक्षित करें" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

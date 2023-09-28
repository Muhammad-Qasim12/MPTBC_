<%@ Page Title="पुस्तक विक्रेता मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerMasterList.aspx.cs" Inherits="Depo_BookSellerMasterList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>पुस्तक विक्रेता मास्टर</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="नया डाटा डाले" onclick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4" style="display: none">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="txtbox "
                            onselectedindexchanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="True">
                            <asp:ListItem Value="0">Select..</asp:ListItem>
                        </asp:DropDownList>
                        <label>जिला</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdBookSeleer" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-hover" DataKeyNames="Booksellerregistration_I"
                            AllowPaging="True"
                            onpageindexchanging="GrdBookSeleer_PageIndexChanging"
                            onrowcommand="GrdBookSeleer_RowCommand">
                            <columns>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <itemtemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="संबंधित व्यक्ति का नाम">
                                    <itemtemplate>
                                        <a href="ShowBookSellerDetails.aspx?ID=<%# api.Encrypt(Eval("Booksellerregistration_I").ToString()) %>" target="_blank"><%#Eval("BooksellerOwnerName_V")%></a>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="पुस्तक विक्रेता का पता" DataField="Address_V" />
                                <asp:BoundField HeaderText="फर्म / दुकान का नाम" DataField="BooksellerName_V" />
                                <asp:BoundField HeaderText="रजिस्ट्रेशन दिनांक" DataField="RegistrationDate_D" />
                                <asp:BoundField HeaderText="मोबाइल नंबर" DataField="MobileNo_N" />

                                <asp:BoundField HeaderText="यूजर आई.डी." DataField="LoginID_V" />
                                <asp:BoundField HeaderText="पासवर्ड" DataField="UserPassowrd" />
                                <asp:TemplateField HeaderText="केटेगरी">
                                    <itemtemplate>
                                        <%#Eval("Category") %>-( <%#Eval("PerCentage") %> %)
                                    </itemtemplate>

                                </asp:TemplateField>
                                <asp:BoundField HeaderText="नवीनीकरण दिनांक " DataField="Renewsaldate" />
                                <asp:BoundField HeaderText="नवीनीकरण राशी" DataField="ReAmount" />
                                <asp:TemplateField HeaderText="पंजीयन नवीनीकरण">
                                    <itemtemplate>
                                        <asp:Button CssClass="btn" runat="server" Text="नवीनीकरण करें" OnClick="btClick" Visible='<%# Eval("ReAmount").ToString()=="0" && Eval ("RegYear").ToString ()!= System.DateTime.Now.Year.ToString ()  ? true   :false  %>' CommandArgument='<%#(Eval("Booksellerregistration_I").ToString ()) %>'></asp:Button>
                                        <asp:Button runat="server" CssClass="btn" Text="नवीनीकरण रसीद प्रिंट करे " OnClick="btClick1" Visible='<%# Eval("ReAmount").ToString()=="0" ? false  :true  %>' CommandArgument='<%#(Eval("Booksellerregistration_I").ToString ()) %>'></asp:Button>

                                        <asp:Button CssClass="btn" runat="server" Text="रसीद प्रिंट करे" OnClick="btClick12" Visible='<%# Eval("ReAmount").ToString()=="0" && Eval ("RegYear").ToString ()== System.DateTime.Now.Year.ToString ()  ? true   :false  %>' CommandArgument='<%#(Eval("Booksellerregistration_I").ToString ()) %>'></asp:Button>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <itemtemplate>
                                        <a href="BookSellerMaster.aspx?ID=<%# api.Encrypt(Eval("Booksellerregistration_I").ToString ()) %>" class="btn btn-sm btn-primary" ><i class="bi bi-pencil"></i></a>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("BooksellerOwnerName_V") %>' />
                                    
                                        <a href="#" ID="ImgbtnDelete" runat="server" CommandArgument='<%# Eval("Booksellerregistration_I") %>'
                                            CommandName="eDelete" ImageUrl=""  class="btn btn-sm btn-danger" OnClick="return confirm('Are you sure you want to delete this record?');" ><i class="bi bi-trash"></i></a>
                                    </itemtemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
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


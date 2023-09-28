<%@ Page Title="पुस्तक विक्रेता मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookSellerMaster.aspx.cs" Inherits="Depo_BookSellerMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>पुस्तक विक्रेता मास्टर</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:Panel class="alert alert-danger" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">                
                        </asp:Label>
                    </asp:Panel>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtbookSellerName" runat="server" placeholder="" onkeypress="javascript:tbx_fnAlphaOnly(event, this)"
                            CssClass="form-control reqirerd" MaxLength="35"></asp:TextBox>
                        <label>फर्म / दुकान का नाम<span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select"
                            OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select..</asp:ListItem>
                            <asp:ListItem Value="1">Urban-A</asp:ListItem>
                            <asp:ListItem Value="2">Rural-A</asp:ListItem>
                            <asp:ListItem Value="3">Urban-B</asp:ListItem>
                            <asp:ListItem Value="4">Rural-B</asp:ListItem>
                        </asp:DropDownList>
                        <label>केटेगरी <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRegNo" runat="server" CssClass="form-control reqirerd" placeholder="" MaxLength="15"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender
                            ID="FilteredTextBoxExtender5" TargetControlID="txtRegNo" ValidChars="ADSFGHGJKLZXCVBNMQWERTYUIOPasdfghjklzxcvbnmqwertyuiop/-1234567890-" runat="server">
                        </cc1:FilteredTextBoxExtender>
                        <label>रजिस्ट्रेशन नंबर <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRegDate" runat="server" TextMode="Date" CssClass="form-control reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>रजिस्ट्रेशन दिनांक <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtOwnerName" runat="server" CssClass="form-control" placeholder="" onkeypress='javascript:tbx_fnAlphaOnly(event, this);' MaxLength="40"></asp:TextBox>
                        <label>पुस्तक विक्रेता का नाम <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtstdCode" CssClass="form-control FL" placeholder="STD" Width="30%" runat="server"
                            onkeypress='javascript:fnSetPhoneDigits(event, this);' MaxLength="5"></asp:TextBox>
                        <asp:TextBox
                            ID="txtTelPhone2" runat="server" CssClass="form-control FR" placeholder="PhoneNo" Width="65%" onkeypress='javascript:fnSetPhoneDigits(event, this);'
                            MaxLength="8"></asp:TextBox>
                        <label>एसटीडी कोड &nbsp;&nbsp;&nbsp; - &nbsp;&nbsp;&nbsp; टेलीफोन नंबर </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtMoblieNo" runat="server" CssClass="form-control reqirerd" placeholder=""
                            onblur='javascript:fnIsValidPhoneFormat(this);' onkeypress='javascript:fnSetPhoneDigits(event, this);'
                            MaxLength="10"></asp:TextBox>
                        <label>मोबाइल नंबर <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control reqirerd" placeholder="" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this)"
                            TextMode="MultiLine" MaxLength="150"></asp:TextBox>
                        <label>फर्म / दुकान का पता <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlDistiID" runat="server" CssClass="form-select reqirerd">
                            <asp:ListItem Value="0">&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335;..</asp:ListItem>
                        </asp:DropDownList>
                        <label>जिला <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCityName" runat="server" placeholder="" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaOnly(event, this)" CssClass="form-control " MaxLength="20"></asp:TextBox>
                        <label>शहर का नाम </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox
                            ID="txtpincode" runat="server" CssClass="form-control" placeholder="" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="6"></asp:TextBox>
                        <label>पिन कोड </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox
                            ID="txtpenNumber" runat="server" CssClass="form-control" placeholder="" onblur="fnValidatePAN(this);"
                            MaxLength="12"></asp:TextBox>
                        <label>पेन नंबर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox
                            ID="txttennumber" runat="server" CssClass="form-control" placeholder=""
                            onkeyup='javascript:tbx_fnSignedNumericCheck(this);' MaxLength="12"></asp:TextBox>
                        <label>टेन नंबर </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtFaxNo" runat="server" CssClass="form-control FL" placeholder="STD" Width="30%" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="5"></asp:TextBox>
                        <asp:TextBox ID="txtFaxStd" runat="server" CssClass="form-control FR" placeholder="PhoneNo" Width="65%" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="8"></asp:TextBox>
                        <label>एसटीडी कोड &nbsp;&nbsp;&nbsp; - &nbsp;&nbsp;&nbsp; फैक्स नंबर </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control" placeholder=""></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                            ErrorMessage="कृपया सही ई-मेल आई.डी. दर्ज करें" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                        </asp:RegularExpressionValidator>
                        <label>ई मेल आई.डी.</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtRegAmount" runat="server" CssClass="form-control reqirerd" placeholder="" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="6"></asp:TextBox>
                        <label>रजिस्ट्रेशन की राशी <span class="red">*</span></label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtSecurityAmount" runat="server" CssClass="form-control reqirerd" placeholder="" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="6"></asp:TextBox>
                        <label>सिक्यूरिटी की राशी </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtCheckNO" runat="server" CssClass="form-control reqirerd" MaxLength="15" placeholder="" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                        <label>डी.डी./चेक नंबर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtValidity" runat="server" CssClass="form-control reqirerd" placeholder="" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'
                            MaxLength="3"></asp:TextBox>
                        <label>पंजीयन की अवधि (माह में)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtddDate" runat="server" TextMode="Date" CssClass="form-control reqirerd"
                            MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtddDate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>डी.डी./चेक दिनांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlBank" CssClass="form-select reqirerd" runat="server">
                        </asp:DropDownList>
                        <label>बैंक का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtUserID" Enabled="false" runat="server" CssClass="form-control reqirerd" MaxLength="12" onkeypress='javascript:tbx_fnAlphaOnly(event, this);'></asp:TextBox>
                        <label>यूजर आई.डी.</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control reqirerd"
                            MaxLength="12">12345</asp:TextBox>
                        <label>पासवर्ड</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="सुरक्षित करे" OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRegDate" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


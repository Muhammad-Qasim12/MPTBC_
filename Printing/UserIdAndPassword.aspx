<%@ Page Title="यूजर लॉगइन एवं यूजर पासवर्ड की जानकारी" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserIdAndPassword.aspx.cs" Inherits="Printing_PRI001_UserIdAndPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>यूजर लॉगइन एवं यूजर पासवर्ड की जानकारी</h2>
            </div>
        <div class="card-body">            
            <div class="row g-3">
                <asp:HiddenField ID="HDNUserID_I" runat="server" Value="0" />
                <div class="col-md-12">
                    <h5>प्रिंटर रजिस्ट्रेशन क्रमांक :<strong>
                        <asp:Label ID="lblRegistration" runat="server"></asp:Label>
                    </strong></h5>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtUserName_V" CssClass="form-control" runat="server"> </asp:TextBox>
                        <label>यूजर लॉगइन</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPassword_V" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                        <label>यूजर पासवर्ड</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtConfirmPassword" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="ComparePass" runat="server" ErrorMessage="Password not match ." ForeColor="Red" ControlToCompare="txtPassword_V" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                        <label>पुन: यूजर पासवर्ड टाइप करे</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="Button1" runat="server" Text="सुरक्षित करे" CssClass="btn btn-submit" OnClick="btnSave_Click" />
                    <asp:Button ID="Button2" runat="server" Text="वापस जाये" CssClass="btn btn-default" OnClick="btnBack_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>


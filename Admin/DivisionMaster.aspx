<%@ Page Title="संभाग (निर्माण/सुधार) / Division (Insert/Update)" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="DivisionMaster.aspx.cs" Inherits="Admin_DivisionMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>संभाग (निर्माण/सुधार) / Division (Insert/Update)</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table >
                <tr>
                    <td>
                        संभाग का नाम (Hindi) / Division Name (Hindi)</td>
                    <td>
                        <asp:TextBox ID="txtdistNameHin" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtdistNameHin" runat="server" ControlToValidate="txtdistNameHin" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        संभाग का नाम (English) / Division Name (English)</td>
                    <td>
                        <asp:TextBox ID="txtdistNameEng" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtdistNameEng" runat="server" ControlToValidate="txtdistNameEng" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="सुरक्षित करे / Save"   OnClientClick="return ValidateAllTextForm();"
                            onclick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        
                    </td>
                </tr>
            </table>
        </div>
        
    </div>

</asp:Content>


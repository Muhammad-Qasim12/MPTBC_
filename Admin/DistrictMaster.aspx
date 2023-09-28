<%@ Page Title="जिला (निर्माण/सुधार) / District (Insert/Update)" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DistrictMaster.aspx.cs" Inherits="Admin_DistrictMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>जिला (निर्माण/सुधार) / District (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table >
                <tr>
                    <td style="height: 32px">
                        डिपो का नाम / Depot Name
                    </td>
                    <td style="height: 32px">
                        <asp:DropDownList ID="ddlDepo" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="1">Select..</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        संभाग का नाम / Division Name
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDivision" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="1">Select..</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>                
                <tr>
                    <td style="height: 32px">
                        जिला का नाम हिंदी में / Division Name In Hindi
                    </td>
                    <td style="height: 32px">
                        <asp:TextBox ID="txtDistrictNameinHindi" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        जिला का नाम अंग्रेज़ी में / Division Name In English
                    </td>
                    <td style="height: 32px">
                        <asp:TextBox ID="txtDistrictNameng" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="सुरक्षित करे / Save" OnClientClick="return ValidateAllTextForm();"
                            OnClick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

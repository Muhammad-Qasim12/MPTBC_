<%@ Page Title="&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; (निर्माण/सुधार) / Block Master (Insert/Update)" Language="C#" 
    MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BlockMaster.aspx.cs" Inherits="Admin_BlockMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2357;&#2367;&#2325;&#2366;&#2360;&#2326;&#2306;&#2337; (निर्माण/सुधार) / Block (Insert/Update)</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table>
                <tr>
                    <td>
                   जिला का नाम
                        / District Name</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="txtbox reqirerd">
                           
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        विकासखंड का नाम इंग्लिश में / Block Name In English
                   </td>
                    <td colspan="2" style="height: 32px">                      
                         <asp:TextBox ID="txtBlockName" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                       
                    </td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        विकासखंड का नाम हिंदी में / Block Name In Hindi
                    </td>
                    <td colspan="2" style="height: 32px">
                         <asp:TextBox ID="txtHindiBlockName" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>                       
                    </td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        स.क्रमांक
                    </td>
                    <td colspan="2" style="height: 32px">
                         <asp:TextBox ID="txtKramank" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>                       
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="सुरक्षित करें / Save" 
                           OnClientClick='javascript:return ValidateAllTextForm();' onclick="btnSave_Click" />
                    </td>
                </tr>
            </table>
            
            </div>
    </div>
    

</asp:Content>


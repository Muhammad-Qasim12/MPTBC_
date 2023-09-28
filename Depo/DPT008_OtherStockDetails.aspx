<%@ Page Title="अन्य पाठ्य सामग्री ओपनिंग स्टॉक / Other Stock Details " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DPT008_OtherStockDetails.aspx.cs" Inherits="Depo_DPT008_OtherStockDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>अन्य पाठ्य सामग्री ओपनिंग स्टॉक / Other Stock Details </span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>
                        गोदाम का नाम / Godown Name <span>*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlWarehouse" runat="server"  CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        अन्य पाठ्य सामग्री का नाम / Others Text Itme Name<span class="required" >*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="txtOtherBookName" runat="server"  CssClass="txtbox reqirerd" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        प्रति बंडल संख्या / Per Bundle No. <span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPerBandal" runat="server" MaxLength="7" CssClass="txtbox reqirerd" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        कुल बंडलो की संख्या / Total Bundle No.<span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txttotalBandal" runat="server" MaxLength="7"  CssClass="txtbox reqirerd" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        लूज बंडलो पाठ्य सामग्री की संख्या / Loose Bundle No. <span>*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtopen" runat="server" CssClass="txtbox" MaxLength="7" 
                            onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="सुरक्षित करे / Save  " OnClientClick='javascript:return ValidateAllTextForm();'
                            OnClick="btnSave_Click" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
            </table>
        
        </div>
</asp:Content>

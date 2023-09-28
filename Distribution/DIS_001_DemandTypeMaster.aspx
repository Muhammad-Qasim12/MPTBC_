<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.master" CodeFile="DIS_001_DemandTypeMaster.aspx.cs" Inherits="Distrubution_DIS_0011_DemandTypeMaster" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>विकासखंड मास्टर / Block Master</span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="50%">
               
                <tr>
                    <td style="height: 32px">
                        मांग का प्रकार (हिंदी) / Demand Type (Hindi)
                    </td>
                    <td colspan="2" style="height: 32px">                      
                         <asp:TextBox ID="txtDemandTypeHindi" runat="server" CssClass="txtbox"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfvtxtDemandTypeHindi" ControlToValidate="txtDemandTypeHindi" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        मांग का प्रकार (इंग्लिश) / Demand Type (English)
                    </td>
                    <td colspan="2" style="height: 32px">
                         <asp:TextBox ID="txtDemandTypeEng" runat="server" CssClass="txtbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfVtxtDemandTypeEng" ControlToValidate="txtDemandTypeEng" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td style="height: 32px">
                        मांग का विवरण / Demand Details
                    </td>
                    <td colspan="2" style="height: 32px">
                         <asp:TextBox ID="txtDemandDisc" runat="server" CssClass="txtbox"  TextMode="MultiLine" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtDemandDisc" ControlToValidate="txtDemandDisc" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSave" CssClass="btn" runat="server" Text="सुरक्षित करें / Save" onclick="btnSave_Click"  />
                    </td>
                </tr>
            </table>
            
            </div>

</asp:Content>

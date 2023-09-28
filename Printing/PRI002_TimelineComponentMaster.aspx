<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI002_TimelineComponentMaster.aspx.cs" Inherits="SPY_SPY004_ComponentMaster" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<link href="../Css/newssm.css" rel="stylesheet" type="text/css" />--%>
 
<asp:Panel ID="panMain" runat="server">
  <div class="box table-responsive">
    <table class="card-header" >
        <tr>
            <td   colspan="5" >
                PRI002- &#2346;&#2381;&#2352;&#2379;&#2332;&#2375;&#2325;&#2381;&#2335; &#2350;&#2376;&#2344;&#2375;&#2332;&#2350;&#2375;&#2306;&#2335; &#2325;&#2377;&#2350;&#2381;&#2346;&#2379;&#2344;&#2375;&#2344;&#2381;&#2335; &#2335;&#2366;&#2311;&#2350; &#2354;&#2366;&#2311;&#2344; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352;&nbsp; / Project Management 
                timeline Component Master</td>
        </tr>
        <tr>
            <td align="left" colspan="5">
                &nbsp;<asp:ValidationSummary ID="Validationummary1" runat="server" />
                <span style="color: #ff3366"><span></span></span></td>
        </tr>
        <tr>
            <td align="left">
                &#2325;&#2377;&#2350;&#2381;&#2346;&#2379;&#2344;&#2375;&#2344;&#2381;&#2335; &#2325;&#2366; &#2344;&#2366;&#2350; / Component Name</td>
            <td align="left" colspan="4">
                <asp:TextBox ID="txtcomponentname" runat="server" Width="288px" CssClass="txtbox reqirerd"></asp:TextBox>
               <%-- <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcomponentname"
                    ErrorMessage="Enter Component Name">*</asp:RequiredFieldValidator></td>--%></td>

        </tr>
        <tr  >
            <td align="left" >
                &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; / Order No</td>
            <td align="left"  colspan="4" >
                <asp:TextBox ID="txtComOrder" runat="server" Style="text-align: right" MaxLength="15" Width="53px" CssClass="txtbox reqirerd"></asp:TextBox></td>
           
          
        </tr>
        <tr>
            <td align="left" style="height: 22px">
                &#2360;&#2381;&#2357;&#2368;&#2325;&#2371;&#2340; /
                <asp:Label ID="lblApprove" runat="server" Text="Approved" Visible="False"></asp:Label></td>
            <td align="left" colspan="4" style="height: 22px">
                <asp:CheckBox ID="chkApproval" runat="server" Text="&#2361;&#2366;&#2305; / Yes" 
                    Visible="False" /></td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" 
                    Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save" Width="128px"  
                    OnClientClick="return ValidateAllTextForm();"/>
                <asp:Button ID="btnClear" runat="server" CausesValidation="False" OnClick="btnClear_Click1"
                    Text="&#2325;&#2381;&#2354;&#2367;&#2351;&#2352; / Clear" Width="124px" /></td>
        </tr>
        <tr>
            <td align="center" colspan="5">
                <cc1:filteredtextboxextender id="FilteredTextBoxExtender1" runat="server" targetcontrolid="txtcomponentname"
                    validchars="asdfghjklzxcvbnmqwertyuiopASDFGHJKLZXCVBNMQWERTYUIOP-   1234567890.(),&/"></cc1:filteredtextboxextender>
                <cc1:filteredtextboxextender id="FilteredTextBoxExtender2" runat="server" targetcontrolid="txtComorder" 
                    validchars="0123456789."></cc1:filteredtextboxextender>
                 
            </td>
        </tr>
    </table>
</div>
 </asp:Panel> 
</asp:Content>


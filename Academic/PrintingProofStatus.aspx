<%@ Page Title="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2381;&#2352;&#2370;&#2347; &#2325;&#2366; &#2360;&#2381;&#2335;&#2375;&#2335;&#2360; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352;" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PrintingProofStatus.aspx.cs" Inherits="Academic_PrintingProofStatus" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2381;&#2352;&#2370;&#2347; &#2325;&#2366; &#2360;&#2381;&#2335;&#2375;&#2335;&#2360; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Printing Proof Status Master </span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>

            <table width="100%">
                <tr>
                    <td style="height: 32px">
                       &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2381;&#2352;&#2370;&#2347; &#2325;&#2366; &#2360;&#2381;&#2335;&#2375;&#2335;&#2360; / Printing Proof Status 
                    </td>
                    <td colspan="2" style="height: 32px">
                        <asp:TextBox ID="txtStatus" runat="server" MaxLength="45" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " OnClientClick="return ValidateAllTextForm();"
                            OnClick="btnSave_Click" />
                        <asp:HiddenField ID="hdnStatusTrno" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

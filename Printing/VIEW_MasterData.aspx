<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_MasterData.aspx.cs" Inherits="PRI_VIEW_PRI002" Title="Printing Timeline" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" class="bggrey" style="width: 100%">
        <tr class="headertext">
            <td class="heading" style="height: 14px; text-align: center">
                <strong>View - Data Master</strong></td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="width: 769px; height: 433px">
                <asp:Panel ID="panMain" runat="server">
                    <table align="center" cellpadding="0" cellspacing="2" class="padr68 padl62 black text12 padt10"
                        style="width: 100%; height: 394px">
                        <tr>
                            <td style="height: 25px">
                                &nbsp;</td>
                            <td align="right" valign="top"   class="padb5 " style="width: 886px; height: 25px">
                                <div >
                                    &nbsp;<asp:TextBox ID="txtSearch" runat="server" Height="285px" Width="636px"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 25px">
                                &nbsp;</td>
                            <td align="left" class="padb5 " style="width: 886px; height: 25px">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="height: 25px">
                                &nbsp;</td>
                            <td align="left" class="padb5 " style="width: 886px; height: 25px">
                                <asp:RadioButton ID="rdNew" runat="server" GroupName="A" 
                                    OnCheckedChanged="rdNew_CheckedChanged" Text="InsertUpdate" />
                                <asp:RadioButton ID="rdApproved" runat="server" 
                                    GroupName="A" OnCheckedChanged="rdApproved_CheckedChanged" 
                                    Text="Select" />
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn" 
                                    onclick="btnSearch_Click" Text="Search" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="width: 886px">
                                &nbsp;
                                <asp:GridView ID="gvProjectMaster" runat="server" Height="180px" Width="679px" 
                                    CssClass="tab" AllowPaging="True" 
                                    onpageindexchanging="gvProjectMaster_PageIndexChanging1" >
                                </asp:GridView>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr class="h22">
                            <td align="left" class="padr10" colspan="2" style="width: 886px">
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>



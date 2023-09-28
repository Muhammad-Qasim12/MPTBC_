<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MidSessionDemaND.aspx.cs" Inherits="Depo_MidSessionDemaND" Title="MPTBC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>डिपो प्रबंधक द्वारा मध्यावधि पुस्तकों की मॉग</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td align="center" colspan="5">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="txtbox" RepeatDirection="Horizontal"
                            Width="226px">
                            <asp:ListItem>सामान्य</asp:ListItem>
                            <asp:ListItem>योजना</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        दिनांक</td>
                    <td colspan="4" style="height: 32px">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        माध्यम</td>
                    <td colspan="4" style="height: 32px">
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox">
                            <asp:ListItem>Select..</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="height: 32px">
                        कक्षा</td>
                    <td colspan="4" style="height: 32px">
                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="txtbox">
                            <asp:ListItem>1-8</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 32px">
                        <table cellpadding="0" cellspacing="0" class="tab">
                            <tr>
                                <th style="width: 100px">
                                    क्रमांक
                                </th>
                                <th style="width: 100px">
                                    कक्षा</th>
                                <th style="width: 100px">
                                    विषय
                                </th>
                                <th style="width: 100px">
                                    स्टॉक में उपलब्ध
                                </th>
                                <th style="width: 100px">
                                    संभावित विक्रय</th>
                                <th style="width: 100px">
                                    मांग
                                </th>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <strong><span style="background-color: #f1f1f1">1</span></strong></td>
                                <td style="width: 100px">
                                    1</td>
                                <td style="width: 100px">
                                    भाषा भारती</td>
                                <td style="width: 100px">
                                    323</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Width="85px">1000</asp:TextBox></td>
                                <td style="width: 100px">
                                    677</td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    2</td>
                                <td style="width: 100px">
                                    1</td>
                                <td style="width: 100px">
                                    गणित</td>
                                <td style="width: 100px">
                                    472</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="txtbox" Width="85px">1000</asp:TextBox></td>
                                <td style="width: 100px">
                                    528</td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    3</td>
                                <td style="width: 100px">
                                    1</td>
                                <td style="width: 100px">
                                    इग्लिश रीडर (जनरल)</td>
                                <td style="width: 100px">
                                    1145</td>
                                <td style="width: 100px">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="txtbox" Width="85px">1000</asp:TextBox></td>
                                <td style="width: 100px">
                                    0</td>
                            </tr>
                            <tr>
                                <td style="width: 100px; height: 35px;">
                                    4</td>
                                <td style="width: 100px; height: 35px;">
                                </td>
                                <td style="width: 100px; height: 35px;">
                                </td>
                                <td style="width: 100px; height: 35px;">
                                </td>
                                <td style="width: 100px; height: 35px;">
                                </td>
                                <td style="width: 100px; height: 35px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    5</td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Save" /></td>
                </tr>
            </table>
        </div>
    </div>

</asp:Content>


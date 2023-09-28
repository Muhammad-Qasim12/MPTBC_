<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReceivedReport.aspx.cs" Inherits="CenterDepot_ReceivedReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
           <table width="100%">
                <tr>
                    <td colspan="4" style="font-size: 18px; font-weight: bold; text-align: center;">मध्य प्रदेश पाठ्यपुस्तक निगम
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">" केन्द्रीय भंडार "
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; font-weight: 200; text-align: center;">अरेरा हिल्स , भोपाल (म.प्र) 462011<br />
                        दूरभाष - 0755-2550727, 2551294, 2551565, फैक्स - 2551145,
                    <br />
                        ई-मेल - infomptbc@mp.gov.in, वेबसाइट- mptbc.nic.in
                    </td>
                </tr>
                <tr>
                    <td width="100%;" colspan="4" style="text-align: left;">शैक्षणिक सत्र :<asp:Label ID="lblYear" runat="server" Font-Bold="true"></asp:Label>
                    </td>

                </tr>
                <tr>
                    <td colspan="4" style="font-size: 16px; font-weight: bold; text-align: center;">
                        <asp:Label ID="lblTitle" runat="server" Text="प्राप्ति रसीद"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 12px; text-align: right;"></td>
                </tr>
                <tr>
                    <td colspan="4" style="font-size: 13px; font-weight: 200; text-align: center;">
                        <table width="100%">


                            <tr>
                                <td width="50%" style="text-align: left">GSR पेज क्रं. :<asp:Label ID="lblGSRPagePrint" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                                <td width="50%" style="text-align: right">दिनांक :<asp:Label ID="lblReceiptPrint" runat="server" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                            <tr>

                                <td colspan="2">वाहन क्रमांक :<asp:Label ID="lblVehicleNoPrint" runat="server" Font-Bold="true"></asp:Label>
                                    के द्वारा प्राप्त कुल रील / बंडल संख्या
                                    <asp:Label ID="lblReceiptReelPrint" runat="server" Font-Bold="true"></asp:Label>
                                    जिसमें डैमेज रील / बंडल संख्या
                                    <asp:Label ID="lblDamajReelPrint" runat="server" Font-Bold="true"></asp:Label>
                                    प्राप्त की गई |
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" style="height: 25px"></td>
                                <td width="50%"></td>
                            </tr>
                            <tr>
                                <td width="50%">स्टोरकीपर
                                </td>
                                <td width="50%" style="text-align: right">डिपो प्रबंधक
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" style="text-align: left;">..................................
                                </td>
                                <td width="50%" style="text-align: right">.................................
                                </td>
                            </tr>
                        </table>

                    </td>
                </tr>
            </table>
</asp:Content>


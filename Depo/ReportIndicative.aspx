<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportIndicative.aspx.cs" Inherits="Depo_ReportIndicative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="box">
        <div class="card-header">
            <h2>
                <span style="height: 1px">अनुमानित मांग पत्र</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            मध्याप्रदेश पाठ्य पुस्तक निगम,भण्डार
            <div>
                <table>
                    <tr>
                        <td>
                            दिनांक से
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" CssClass="txtbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            दिनांक तक
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" CssClass="txtbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                         <table cl&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
                        </td>
                        <td>
                            <asp:TextBox ID="txt11" CssClass="txtbox" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn" 
                            
                                Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                         <table class="tab">
                            <tr>
                                <th rowspan="2">
                                    &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                     </th>
                                <th rowspan="2">
                                    इस वर्ष की अनुमानित मांग
                                </th>
                                <th rowspan="2">
                                    रिमार्क
                                </th>
                            </tr>
                            <tr>
                                <th>
                                    प्रथम वर्ष
                                </th>
                                <th>
                                    द्वितीय वर्ष
                                </th>
                                <th>
                                    तृतीय वर्ष
                                </th>
                                <th>
                                    औसत
                                </th>
                            </tr>
                            <tr>
                                <td>1</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                              <tr>
                                <td>2</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                              <tr>
                                <td>3</td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                         </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MediumWiseSummary.aspx.cs" Inherits="MediumWiseSummary" MasterPageFile="~/MasterPage.master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="box">
        <div class="card-header">
            <h2>
                <span ><asp:Label ID="lblTitleName" runat="server"></asp:Label> </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            मांग का प्रकार<br /> Demand Type :
                              <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                  <asp:ListItem value="1">प्रथम मांग</asp:ListItem>
                                  <asp:ListItem value="2">द्वितीय&nbsp;मांग</asp:ListItem>
                                  <asp:ListItem value="4">तृतीय मांग</asp:ListItem>
                                  <asp:ListItem Value="11">चतुर्थ मांग </asp:ListItem>
                                  <asp:ListItem value="5">अतिरिक्त मांग</asp:ListItem>
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                           
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="300px">
                                        <asp:ListItem Selected="True" Value="3">&#2360;&#2349;&#2368;</asp:ListItem>
                                        <asp:ListItem Value="1">&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; </asp:ListItem>
                                        <asp:ListItem Value="2">&#2309;&#2346;&#2352;&#2367;&#2357;&#2352;&#2381;&#2340;&#2367;&#2340; </asp:ListItem>
                                    </asp:RadioButtonList>
                           
                        </td>


                    </tr>
                    <tr>

                        <td style="width: 30%; font-size: medium;" valign="top">
                           
                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                             
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report" CssClass="btn" OnClick="Button1_Click" />
                        </td>

                    </tr>
                </table>
                <%--<input type="button" id="btnPrint" value="Print" onclick="Print()" />--%>
                <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True" ShowPrintButton="true">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

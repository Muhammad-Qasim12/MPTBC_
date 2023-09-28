<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoWiseTotal.aspx.cs" Inherits="Distribution_DepoWiseTotal" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            &#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br /> Demand Type :
                              <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                  <asp:ListItem value="1">&#2346;&#2381;&#2352;&#2341;&#2350; &#2350;&#2366;&#2306;&#2327;</asp:ListItem>
                                  <asp:ListItem value="2">&#2342;&#2381;&#2357;&#2367;&#2340;&#2368;&#2351;&nbsp;&#2350;&#2366;&#2306;&#2327;</asp:ListItem>
                                  <asp:ListItem value="4">&#2340;&#2371;&#2340;&#2368;&#2351; &#2350;&#2366;&#2306;&#2327;</asp:ListItem>
                                  <asp:ListItem Value="11">&#2330;&#2340;&#2369;&#2352;&#2381;&#2341; &#2350;&#2366;&#2306;&#2327; </asp:ListItem>
                                  <asp:ListItem value="5">&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2350;&#2366;&#2306;&#2327;</asp:ListItem>
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; :
                            <asp:DropDownList ID="DdlDepot" runat="server">
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
                        <td>
                            &nbsp;</td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            &nbsp;</td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            &nbsp;</td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                           
                                    &nbsp;</td>


                    </tr>
                    <tr>

                        <td style="width: 30%; font-size: medium;" valign="top">
                           
                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                             
                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                             
                            &nbsp;</td>
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


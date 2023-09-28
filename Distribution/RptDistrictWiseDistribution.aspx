<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RptDistrictWiseDistribution.aspx.cs" Inherits="Distrubution_RptDistrictWiseDistribution" MasterPageFile="~/MasterPage.master" %>

 
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <asp:Label ID="lblTitleName" runat="server"></asp:Label>
                </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br />Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot  :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td style="font-size: medium;" valign="top">
                            <asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class :</asp:Label>
                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox"
                                OnSelectedIndexChanged="DDLClass_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>



                        <td style="font-size: medium;" valign="top">
                            <asp:Label ID="LblScheme" runat="server">&#2351;&#2379;&#2332;&#2344;&#2366; <br /> Scheme :</asp:Label>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td>मांग का प्रकार<br />
                            Demand Type :
                              <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                  <asp:ListItem Value="1">प्रथम मांग</asp:ListItem>
                                  <asp:ListItem Value="2">द्वितीय&nbsp;मांग</asp:ListItem>
                                  <asp:ListItem Value="2,4">तृतीय मांग</asp:ListItem>
                                  <asp:ListItem Value="2,4,5">अतिरिक्त मांग</asp:ListItem>
                              </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report " CssClass="btn" OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
                <div style="overflow: auto">




                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

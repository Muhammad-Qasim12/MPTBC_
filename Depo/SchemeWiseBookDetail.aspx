<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SchemeWiseBookDetail.aspx.cs" Inherits="Depo_SchemeWiseBookDetail" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 35%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
       
        <div class="card-header">
            <h2>
                <span style="font-size: medium;">&#2344;&#2367;&#2307;&#2358;&#2369;&#2354;&#2381;&#2325; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2367;&#2340;&#2352;&#2339; &#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2375; &#2309;&#2306;&#2340;&#2352;&#2381;&#2327;&#2340; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2350;&#2366;&#2306;&#2327;                   
                </span>
            </h2>
          
        </div>
        <div class="portlet-content">
            <asp:Panel class="response-msg success ui-corner-all" runat="server" ID="mainDiv" Visible="false" Style="padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>

            <div class="table-responsive">
                 <div id="ExportDiv1" runat="server">
                <table width="100%"  >
                    <tr>
                        <td style="width: 35%; font-size: medium;" valign="top">
                            <asp:Label ID="LblAcYear" runat="server" Width="200px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox"
                              >
                            </asp:DropDownList>
                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">


                            &#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class</td>

                        <td style="width: 35%; font-size: medium;" valign="top">
                            <asp:DropDownList ID="ddlCls" runat="server" CssClass="txtbox">
                                <asp:ListItem>1-8</asp:ListItem>
                                <asp:ListItem>9-12</asp:ListItem>
                            </asp:DropDownList>


                        </td>

                        <td style="font-size: medium;" valign="top" class="auto-style1">
                            &nbsp;</td>

                        <td style="width: 35%; font-size: medium;" valign="top">
                            &nbsp;</td>

                    </tr>
                    <tr>
                        <td style="width: 35%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDistrict" runat="server" Width="180px">&#2332;&#2367;&#2354;&#2366; &#2330;&#2369;&#2344;&#2375; <br />District :</asp:Label>
                            <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox"
                                AutoPostBack="True" OnSelectedIndexChanged="DdlDistrict_SelectedIndexChanged">
                            </asp:DropDownList>

                        </td>
                        <td style="width: 30%; font-size: medium;" valign="top">
                            &#2348;&#2381;&#2354;&#2377;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;

                        </td>
                        <td style="width: 35%; font-size: medium;" valign="top">
                            <asp:DropDownList ID="DdlBlock" runat="server" CssClass="txtbox"
                                >
                            </asp:DropDownList>

                        </td>


                        <td style="font-size: medium;" valign="top" class="auto-style1">

                            <table>
                                <tr>
                                    <td>&nbsp;:</td>
                                </tr>

                            </table>



                        </td>


                        <td style="width: 35%; font-size: medium;" valign="top">
                            &nbsp;</td>


                    </tr>
                    <tr>
                        <td style="font-size: medium;" valign="top" colspan="5">
                                <asp:Button ID="BtnViewAll" runat="server" CssClass="btn" Text=" &#2342;&#2375;&#2326;&#2375;&#2306; / View" OnClick="BtnViewAll_Click" />
                        </td>


                    </tr>
                    <tr>
                        <td style="font-size: medium;" valign="top" colspan="5">
                            <%-- <asp:CheckBox ID="chkSelect1" runat="server"   Text="&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; "  onclick="CheckAll(this);" TextAlign="Left"/>--%>
                            <%--  <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox" 
                            onselectedindexchanged="DdlDistrict_SelectedIndexChanged">
                          
                        </asp:DropDownList>--%>

                           


                            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%">
                            </rsweb:ReportViewer>

                           


                        </td>


                    </tr></table> </div> 
</asp:Content>


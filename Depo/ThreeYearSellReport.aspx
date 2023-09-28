<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThreeYearSellReport.aspx.cs" Inherits="Depo_ThreeYearSellReport" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span style="font-size: medium;">&#2326;&#2369;&#2354;&#2375; &#2348;&#2366;&#2395;&#2366;&#2352; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; / Open Market Demand </span>
                    </h2>
                </div>
                <div class="portlet-content">
                   <div class="box table-responsive">
                        <table width="100%">
                            <tr>
                                <td>
                                  
                                    डिपो का नाम : <asp:DropDownList ID="ddldepot" runat="server" CssClass="txtbox"></asp:DropDownList>
                                    
                                                                    </td>
                               
                            </tr>
                           
                            <tr>
                                <td>
                                    <asp:Button ID="BtnShow" runat="server" CssClass="btn" OnClick="BtnShow_Click" Text=" &#2357;&#2367;&#2357;&#2352;&#2339; &#2342;&#2375;&#2326;&#2375; / Details" />
                                </td>
                            </tr>
                           
                           
                        </table>
                       <rsweb:ReportViewer ID="ReportViewer1" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True" width="100%">
                                      </rsweb:ReportViewer>
                    </div>
                </div>
            </div>
</asp:Content>


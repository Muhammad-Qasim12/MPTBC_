<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoAwavtanPraptiDist.aspx.cs" Inherits="Depo_DepoAwavtanPraptiDist" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
        <div class="card-header">
            <h2>&#2310;&#2357;&#2306;&#2335;&#2344; &#2319;&#2357;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">


                
                <table width="100%">
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Report" CssClass="btn" />
                        </td>
                    </tr></table> 
                <div style="overflow: scroll; width="1200px"">
                                    <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%"
                                        height="" sizetoreportcontent="True">
                                     </rsweb:reportviewer>  </div>
            </div> </div></div>
</asp:Content>


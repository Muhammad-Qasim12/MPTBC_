<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportOtherThantextbookReceive.aspx.cs" Inherits="Depo_ReportOtherThantextbookReceive" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
                    <div class="card-header">
                     <h2> &#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2379; &#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; &#2350;&#2375;&#2306; &#2348;&#2342;&#2354;&#2375;</h2>
                          
                    </div>
        <table width="100%">
            <tr><td>&#2360;&#2340;&#2381;&#2352; </td><td>
                <asp:DropDownList ID="DdlACYear" runat="server">
                </asp:DropDownList>
                </td><td>
                    &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                </td><td>
                    <asp:DropDownList ID="ddlTitleID" runat="server">
                    </asp:DropDownList>
                </td><td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Show Report" OnClick="Button1_Click" />
                </td></tr>
            <tr><td colspan="5">
                <div   style="overflow: scroll; width="1200px">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True" width="100%">
                    </rsweb:ReportViewer>
                </div>
                </td></tr>
        </table>
         </div> 

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistWisePradayDepo.aspx.cs" Inherits="Depo_DistWisePradayDepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="box table-responsive">
        <div class="card-header">
            <h2 class="auto-style1">अन्य पाठ्यसामग्री का प्रदाय</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>शैक्षणिक सत्र/Academic Year
                        <asp:DropDownList ID="ddlFyYr" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                        पत्र क्रमांक / Letter No.
                        <asp:DropDownList ID="ddlLetterNo" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                        <br />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" OnClientClick="javascript:return ValidateAllTextForm();" Text="खोजें/ Search" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- <rsweb:ReportViewer Width="100%" ID="RVDistrictSupply" runat="server">
                    </rsweb:ReportViewer>  --%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


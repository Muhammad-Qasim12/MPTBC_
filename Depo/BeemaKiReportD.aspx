<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BeemaKiReportD.aspx.cs" Inherits="Depo_BeemaKiReportD" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box">
        <div class="card-header">
            <h2>
                &#2346;&#2366;&#2357;&#2340;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; </h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                         माह 
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlmonth" CssClass="txtbox reqirerd" runat="server"></asp:DropDownList> 
                        
                    </td>
                    <td>
                शैक्षणिक सत्र 
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlSessionYear" CssClass="txtbox reqirerd" runat="server" ></asp:DropDownList> 
                  
                    </td>
                    </tr> 
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show  Data" />
                    </td>
                    </tr>  
                <tr>
                    <td colspan="4">
                       
            <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True">
                            </rsweb:reportviewer>
                       
                    </td>
                    </tr> </table> </div> 
          </div>
</asp:Content>


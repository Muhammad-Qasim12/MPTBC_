<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinternotSUpplybookdepo.aspx.cs" Inherits="Depo_PrinternotSUpplybookdepo" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
        <div class="card-header">
            <h2>डिपो में अप्राप्त पुस्तक की जानकारी </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">


                
                <table width="100%">
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
                        <td >
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>
                        <td><asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot  :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox">
                            </asp:DropDownList></td>
                        <td>कक्षा</td>
                        <td>&nbsp;<asp:DropDownList ID="DDLClass" runat="server">
                            <asp:ListItem Value="1,2,3,4,5,6,7,8,9,10,11,12">All</asp:ListItem>
                            <asp:ListItem Value="1,2,3,4,5,6,7,8">1-8</asp:ListItem>
                            <asp:ListItem Value="9,10,11,12">9-12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>माध्यम</td>
                        <td>
                            <asp:DropDownList ID="ddlMedium" runat="server">
                        
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Show Report" CssClass="btn" />
                        </td>
                    </tr></table> 
                <div style="overflow: scroll; width="1200px">
                                    <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%"
                                        height="" sizetoreportcontent="True">
                                     </rsweb:reportviewer>  </div>
            </div> </div></div>
</asp:Content>

<%@ Page Title="&#2310;&#2357;&#2306;&#2335;&#2344; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Awantan Pradya" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AwantanPradya.aspx.cs" Inherits="Depo_AwantanPradya" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header" id="a" runat="server" visible="false">
            <h2>योजना के पुस्तकों की  आवंटन एवं प्रदाय की जानकारी </h2>
        </div>
        <div class="card-header" id="a1" runat="server" visible="false">
            <h2>योजना के पुस्तकों की  आवंटन की जानकारी</h2>
        </div>
       <table width="100%">
                <tr>
                  <td colspan="3">
                         &nbsp;</td>
                   
                   
                </tr>
                <tr>
                  <td>
                         <asp:Label ID="LblAcYear" runat="server" Width="100px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Education Year:</asp:Label>
                       <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" >
                        </asp:DropDownList>
                        
                       
                    </td>
                   
                    <td style="width: 30%; font-size: medium;" valign="top">
                        <asp:Label ID="LblDistrict" runat="server" Width="100px">&#2332;&#2367;&#2354;&#2366; / District :</asp:Label>
                        <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox">
                        </asp:DropDownList >
                    </td>
               
               
                    <td style="width: 30%; font-size: medium;" valign="top">
                        &nbsp;</td>
                    
                   
                </tr>
                <tr>
              
                       <td style="width: 30%; font-size: medium;" valign="top">
                        <asp:Label ID="LblClass" runat="server" Width="100px">&#2325;&#2325;&#2381;&#2359;&#2366; / Class:</asp:Label>
                        <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox" 
                               onselectedindexchanged="DDLClass_SelectedIndexChanged" AutoPostBack="true">
                               <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                               <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                        </asp:DropDownList>
                      </td>

                       <td style="width: 30%; font-size: medium;" valign="top">
                        <asp:Label ID="LblScheme" runat="server" Width="100px">&#2351;&#2379;&#2332;&#2344;&#2366; / Scheme:</asp:Label>
                        <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox" >
                            
                        </asp:DropDownList>
                        </td>
                         <td >
                        <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / Report" CssClass="btn" OnClick="Button1_Click" />
                        <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox" 
                            onselectedindexchanged="DDlDepot_SelectedIndexChanged" Visible="False">
                        </asp:DropDownList>
                    </td>
                                  
                </tr>
               
            </table>
            <div style="overflow:auto" class="rdlc">
  <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server" 
        DocumentMapWidth="100%" Height="" SizeToReportContent="True">
    </rsweb:ReportViewer>
    </div>
         </div>
</asp:Content>


﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadBarcode.aspx.cs" Inherits="Distrubution_ReadBarcode" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
  
        <div class="box">
        <div class="card-header" >
            <h2>
                &#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;
            </h2>
        </div>
             <div style="padding: 0 10px;">
    <br /><br />
        <table  style="width: 100%" border="1" class="tab">
        <tr>
                <td colspan="4">
                    &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;&nbsp;
                    &nbsp;&nbsp;<asp:TextBox ID="TxtCode" runat="server" ontextchanged="TxtCode_TextChanged"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2326;&#2379;&#2332;&#2375; " />
                </td>
            </tr>
        <tr>
                <th colspan="4">
    <asp:Label ID="LblCode" runat="server">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; : </asp:Label>
                </th>
            </tr>
        <tr>
                <th colspan="4" align="center" >
                
                 <center>  प्राप्ति की जानकारी </center> </th>
            </tr>
        <tr>
                <td>
                    <asp:Label ID="Label4" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;:</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblAcyear" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :</asp:Label>
                </td>
                <td>
                    <asp:Label ID="LblBook" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server">&#2337;&#2367;&#2346;&#2379; :</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDepo" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; :</asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblPrinter" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;
                </td>
                <td>
                    <asp:Label ID="lblbookNo" runat="server"></asp:Label>
                </td>
                <td>
                    &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;
                </td>
                <td>
                    <asp:Label ID="lblbookNoto" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                </td>
                <td>
                    <asp:Label ID="lblTotalBook" runat="server"></asp:Label>
                </td>
                <td>
                    &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                <td>
                     <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    मुद्रक का चालान नंबर </td>
                <td>
                    <asp:Label ID="lbl1" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                <td>
                       <asp:Label ID="lbl2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="center" >
                    
                </th>
            </tr>
            <tr>
                <td>
                    &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;
                </td>
                <td>
                     <asp:Label ID="lbl3" runat="server" Text=""></asp:Label></td>
                <td>
                    &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                <td>
                     <asp:Label ID="lbl4" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <th colspan="4" align="center" >
                 <center>  प्रदाय की जानकारी</center> 
                </th>
            </tr>
            <tr>
                <td>
                    &#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367;
                </td>
                <td colspan="3">
                     <asp:Label ID="lbl5" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td>
                    चालान नंबर / चालान दिनांक
                </td>
                <td colspan="3">
                     <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
            </tr>
        </table></div> 
    </div>
   
</asp:Content> 
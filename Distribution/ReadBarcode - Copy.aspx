<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadBarcode.aspx.cs" Inherits="Distrubution_ReadBarcode" MasterPageFile="~/MasterPage.master" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
  
        <div class="box">
        <div class="card-header" >
            <h2>
                &#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2375;&#2326;&#2375;
            </h2>
        </div>
             <div style="padding: 0 10px;">
    <br /><br />
        <table  style="width: 100%" border="1">
        <tr>
                <td colspan="4">
                    &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352;&nbsp;
                    &nbsp;&nbsp;<asp:TextBox ID="TxtCode" runat="server" ontextchanged="TxtCode_TextChanged"></asp:TextBox>&nbsp;&nbsp;
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2326;&#2379;&#2332;&#2375; " />
                </td>
            </tr>
        <tr>
                <td colspan="4">
    <asp:Label ID="LblCode" runat="server">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; : </asp:Label>
                </td>
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
                    पुस्तक का प्रकार </td>
                <td>
                     <asp:Label ID="lblBookType" runat="server"></asp:Label></td>
            </tr>
        </table></div> 
    </div>
   
</asp:Content> 
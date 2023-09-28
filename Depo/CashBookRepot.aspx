<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CashBookRepot.aspx.cs" Inherits="Depo_CashBookRepot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span>&#2325;&#2376;&#2358; &#2348;&#2369;&#2325;</span></h2>
        </div>
        <div class="PLR10">
         <table>
                    <tr>
                        <td>
                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" CssClass="txtbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" CssClass="txtbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        <asp:Button ID="Button3" runat="server" CssClass="btn" 
                            
                                Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" />
                        </td>
                    </tr></table> 
    <table style="width: 100%" cellpadding="0" class="tab">
        <tr>
            <th rowspan="2">
                &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</th>
            <th rowspan="2">
                &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</th>
            <th rowspan="2">
                &#2346;&#2366;&#2352;&#2381;&#2335;&#2367;&#2325;&#2369;&#2354;&#2352;</th>
            <th rowspan="2">
                &#2348;&#2366;&#2313;&#2330;&#2352; &#2344;&#2306;&#2348;&#2352;
            </th>
            <th colspan="2">
                &#2352;&#2366;&#2358;&#2368;
            </th>
            <th colspan="2">
                &#2325;&#2369;&#2354;</th>
        </tr>
        <tr>
            <th>
                &#2352;&#2369;&#2346;&#2351;&#2375;</th>
            <th>
                &#2346;&#2376;&#2360;&#2375;</th>
            <th>
                &#2352;&#2369;&#2346;&#2351;&#2375;</th>
            <th>
                &#2346;&#2376;&#2360;&#2375;</th>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PerBundalNo.aspx.cs" 
    Inherits="DistributionB_PerBundalNo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
        <div class="card-header">
            <h2>&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</h2> 
                       </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td>
            <asp:Label ID="LblAcYear" runat="server" Width="204px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
                    </td>
                    <td>

            <asp:DropDownList ID="DdlACYear" runat="server"  
                CssClass="txtbox"   
                   >
                <asp:ListItem>..Select..</asp:ListItem>
                <asp:ListItem>2012-13</asp:ListItem>
                <asp:ListItem>2013-14</asp:ListItem>
                <asp:ListItem>2014-15</asp:ListItem>
            </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                        &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>

                        <asp:DropDownList ID="ddlTitle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged">
                        </asp:DropDownList>

                    </td>
                </tr>
                <tr>
                    <td>
                        &#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>

                         <asp:DropDownList ID="ddlSubTitle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSubTitle_SelectedIndexChanged">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>

                         <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>

                         <asp:Button ID="btnSave" runat="server" CssClass="btn" onclick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">

                         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                             <Columns>
                                  <asp:BoundField DataField="Acyear" HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; " />
                         
                                 <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                 <asp:BoundField DataField="SubTitleHindi_V" HeaderText="&#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                 <asp:BoundField DataField="BookNumber" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                             
                             </Columns>
                         </asp:GridView>
                    </td>
                </tr>
                </table> </div> </div> 
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FixDemandFyyear.aspx.cs" Inherits="Distribution_FixDemandFyyear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
               <div class="box table-responsive">

                <div class="card-header">
                    <h2>
                        &#2348;&#2381;&#2354;&#2377;&#2325; &#2350;&#2375;&#2306;<span style="font-size: medium;"> &#2342;&#2367;&#2326;&#2344;&#2375;&nbsp; &#2357;&#2366;&#2354;&#2368; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337;&nbsp; 
                        </span>
                    </h2>
                </div>
                <div class="portlet-content">
                    <div class="table-responsive">
                        <asp:Panel class="response-msg inf ui-corner-all" runat="server" ID="mainDiv" Style="display: block; padding-top: 10px; padding-bottom: 10px;">
                            <asp:Label ID="lblmsg" class="notification" runat="server" Text="">
                                </asp:Label>
                        </asp:Panel>
                        <table width="100%">

                            <tr>
                                <td style="width: 30%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year:</asp:Label>
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 40%; font-size: medium;" valign="top">
                                    <asp:Label ID="LblDemandType" runat="server" Width="250px">&#2350;&#2366;&#2306;&#2327; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> Demand Type:</asp:Label>
                                    <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox"  >
                                    </asp:DropDownList>
                                </td>
                                <td style="font-size: medium;">
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="3" class="auto-style1">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" />
                                </td>
                            </tr>

                            <tr>
                                <td style="font-size: medium;" valign="top" colspan="3">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                        <Columns>
                                              <asp:TemplateField HeaderText=" S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:BoundField HeaderText="Academic Year"  DataField="Acyear"/>
                                            <asp:BoundField HeaderText="Demand Type"  DataField="DemandType"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr></table> </div> 
</asp:Content>


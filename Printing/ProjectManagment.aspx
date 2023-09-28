<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectManagment.aspx.cs" Inherits="Printing_ProjectManagment" Title="Project Managment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box<div class="box table-responsive">
        <div class="card-header">
            <h2><span><%#Eval("flag")%>&#2346;&#2381;&#2352;&#2379;&#2332;&#2375;&#2325;&#2381;&#2335; &#2350;&#2376;&#2344;&#2375;&#2332;&#2350;&#2375;&#2306;&#2335; </span></h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2358;&#2375;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;  </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlac">
                            <asp:ListItem Text="2016-2017"></asp:ListItem>
                             <asp:ListItem Text="2017-2018"></asp:ListItem>
                             <asp:ListItem Text="2018-2019"></asp:ListItem>
                        </asp:DropDownList></td>
                    <td>&#2325;&#2325;&#2381;&#2359;&#2366;&nbsp; </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClass" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList></td>

                </tr>
               
                <tr>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;  </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTitle" OnSelectedIndexChanged="ddlTitle_SelectedIndexChanged" AutoPostBack="true"  >
                        </asp:DropDownList></td>
                    <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPrinterName" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinterName_SelectedIndexChanged">
                        </asp:DropDownList></td>

                </tr>
               
                <tr>
                    <td><span style="color: rgb(34, 34, 34); font-family: Arial, Verdan, sans-serif; font-size: 15px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; line-height: 15px; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(252, 253, 253);">&#2332;&#2377;&#2348; &#2325;&#2379;&#2337;</span></td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlJobNo" AutoPostBack="True" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td>&nbsp;</td>
                    <td>
                        &nbsp;</td>

                </tr>
               
            </table>

            <div>
                <asp:Panel runat="server" ID="p" ScrollBars="Auto">

                    <asp:GridView ID="GrdProjectMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                        CssClass="tab" Width="100%"
                        EmptyDataText="Record Not Found."
                        OnRowDataBound="GrdProjectMaster_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>.
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339;">
                                <ItemTemplate>

                                    <%#Eval("flag")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2358;&#2375;&#2337;&#2381;&#2351;&#2370;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                    <asp:Label ID="lblSchuDate_D" runat="server" Text='<%#Eval("SchuDate_D")%>'></asp:Label>
                                    <asp:Label ID="lblCurtDate" runat="server" Text='<%#Eval("CurtDate")%>' Visible="false"></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                    <asp:Label ID="lblUniqueDate" runat="server" Text='<%#Eval("UniqueDate")%>'></asp:Label>

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>    <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>



                    <%--==============================================================================--%>


                    <%--
 <table class="tab">
 <tr>
  <th>&#2357;&#2367;&#2357;&#2352;&#2339; </th>
 <th>&#2358;&#2375;&#2337;&#2381;&#2351;&#2370;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
 <th>&#2357;&#2366;&#2360;&#2381;&#2340;&#2357;&#2367;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>


 </tr>
 
   <tr>
 <td>Issue of Work Order (&#2325;&#2366;&#2352;&#2381;&#2351;&#2366;&#2342;&#2375;&#2358; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2344;&#2366;) </td>
 <td>
    </td>
 <td></td>
 </tr>
 
 <tr>
 <td>Execution of Agreement(&#2309;&#2344;&#2369;&#2348;&#2306;&#2343; &#2325;&#2366; &#2344;&#2367;&#2352;&#2381;&#2343;&#2366;&#2352;&#2339; )</td>
 <td>
     </td>
 <td></td>
 </tr>
 
 
 

 
 <tr>
 <td>Lifting of Paper from Godown (&#2327;&#2379;&#2337;&#2366;&#2313;&#2344; &#2360;&#2375; &#2346;&#2375;&#2346;&#2352; &#2313;&#2336;&#2366;&#2344;&#2366; )</td>
 <td>
     </td>
 <td></td>
 </tr>
 
 
  <tr>
 <td>Submission of Proof(&#2346;&#2381;&#2352;&#2370;&#2347; &#2360;&#2348;&#2350;&#2367;&#2335; &#2325;&#2352;&#2344;&#2366; )</td>
 <td>
    </td>
 <td></td>
 </tr>
 
  <tr>
 <td>Print Order(&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; )</td>
 <td>
    </td>
 <td></td>
 </tr>
 
  <tr>
 <td>Delivery  Order(&#2337;&#2375;&#2354;&#2367;&#2357;&#2352;&#2368;  &#2310;&#2352;&#2381;&#2337;&#2352; )</td>
 <td>
    </td>
 <td></td>
 </tr>
 
  <tr>
 <td>Delivery Date of 50% Books(50% &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2337;&#2367;&#2354;&#2357;&#2352;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; )</td>
 <td>
     </td>
 <td></td>
 </tr>
 
 <tr>
 <td>Delivery Date of next 50% Books(&#2309;&#2327;&#2354;&#2368;  50% &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2337;&#2367;&#2354;&#2357;&#2352;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; )</td>
 <td>
     </td>
 <td></td>
 </tr>
 
 <tr>
 <td>Return original CD & Approved Proof (&#2323;&#2352;&#2367;&#2332;&#2367;&#2344;&#2354; CD &#2319;&#2357;&#2306; &#2309;&#2346;&#2381;&#2346;&#2381;&#2352;&#2370;&#2357; &#2346;&#2381;&#2352;&#2370;&#2347; &#2325;&#2379; &#2357;&#2366;&#2346;&#2360; &#2325;&#2352;&#2344;&#2366; )</td>
 <td>
    </td>
 <td></td>
 </tr>
 
 
 </table> --%>
                </asp:Panel>
            </div>

        </div>
    </div>

</asp:Content>


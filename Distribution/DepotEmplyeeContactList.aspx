<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepotEmplyeeContactList.aspx.cs" Inherits="Distrubution_DepotEmplyeeContactList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
<div class="card-header">
 <h2 style="text-align:center;"><span><b>&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2325;&#2366;&#2352;&#2381;&#2351;&#2352;&#2340; &#2325;&#2352;&#2381;&#2350;&#2330;&#2366;&#2352;&#2367;&#2351;&#2379;&#2306; &#2325;&#2368; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Contact Details of Employees Working In Depots </b></span></h2>
</div>
        
         <asp:GridView runat="server" ID="GrdContactList" AutoGenerateColumns="False" CssClass="tab hastable " >
         <Columns>
                   <asp:TemplateField>
                       <HeaderTemplate>
                           <tr>
                               <th style="width: 21px">
                                   &#2325;&#2381;&#2352;./ Sr.No.
                               </th>
                               <th style="width: 70px">
                                   &#2337;&#2367;&#2346;&#2379; / Depot
                               </th>
                               <th style="width: 100px">
                                   &#2312;-&#2350;&#2375;&#2354; / E-Mail
                               </th>
                               <th style="width: 100px">
                                   &#2335;&#2375;&#2354;&#2368;&#2398;&#2379;&#2344; &#2344;&#2406; / Telephone No.
                               </th>
                               <th colspan="2">
                                   &nbsp;&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2357;&#2306;&#2343;&#2325; / &#2346;&#2381;&#2352;&#2349;&#2366;&#2352;&#2368; / &#2325;&#2352;&#2381;&#2350;&#2330;&#2366;&#2352;&#2368; / Depot Manager / Incharge / Employees
                               </th>
                               <th style="width: 100px">
                                   &nbsp;&#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2406; / Mobile No.
                               </th>
                               <th style="width: 100px">
                                   &#2349;&#2339;&#2381;&#2337;&#2366;&#2352; &#2327;&#2371;&#2361; &#2325;&#2366; &#2346;&#2340;&#2366; / Depot Address
                               </th>
                              
                           </tr>
                       </HeaderTemplate>
                       <ItemTemplate>
                        <tr>
                                   

                              <td><%# Container.DataItemIndex+1 %>.</td>
                            <td><asp:Label   ID="lblDepoName_V" runat="server" Text='<%#Eval("DepoName_V")%>' ></asp:Label> </td>
                            <td> <asp:Label  ID="lblNoOfBooks" runat="server" Text='<%#Eval("Emailid_V")%>' ></asp:Label> </td>
                            <td> <asp:Label  ID="lblBookNoFrom" runat="server" Text='<%#Eval("TeleNo_V")%>' ></asp:Label> </td>
                            <td> <asp:Label  ID="lblBookNoTo" runat="server" Text='<%#Eval("DepoManager_Name_V")%>' ></asp:Label> </td>
                            <td> <asp:Label  ID="Label1" runat="server" Text='&#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325;' ></asp:Label> </td>
                            <td> <asp:Label  ID="lblTotalBundles" runat="server" Text='<%#Eval("MobNo_V")%>' ></asp:Label> </td>
                            <td> <asp:Label  ID="lblBundleNoFrom" runat="server" Text='<%#Eval("DepoAddress_V")%>' ></asp:Label> </td>
                           
                            </tr>
                       
                       </ItemTemplate>
                    </asp:TemplateField>
         </Columns>
              <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
         </asp:GridView>

</div>
</asp:Content>


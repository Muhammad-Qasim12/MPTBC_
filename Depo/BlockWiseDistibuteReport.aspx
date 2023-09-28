<%@ Page Title="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2330;&#2366;&#2354;&#2366;&#2344; / Book Praday Chalan" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BlockWiseDistibuteReport.aspx.cs" Inherits="Depo_BlockWiseDistibuteReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2330;&#2366;&#2354;&#2366;&#2344; / Book Praday Chalan</h2>
        </div>
        <div style="padding: 0 10px;" >
           
                <table width="100%">
                    <tr>
                        <td>
                            &#2332;&#2367;&#2354;&#2375; &#2325;&#2366; &#2344;&#2366;&#2350; / Distrcit Name</td>
                        <td>
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp; / Block Name 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBlock" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            माध्यम / Medium
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlMadhyam" runat="server" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            चालान नंबर
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlChallan" runat="server" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="Button3" runat="server" CssClass="btn" 
                                Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" 
                                onclick="Button3_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           
                                             &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        <div id="a" runat="server" visible="false" >
                          
                            <table class="tab" >
                                <tr>
                                    <th>
                                        बी.आर.सी. / BRC</th>
                                    <th> <%=df.Tables[0].Rows[0]["BlockNameHindi_V"].ToString()%>
                                        </th>
                                    <th>
                                        &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Chalan No.
                                    </th>
                                    <th>
                                        <%=df.Tables[0].Rows[0]["ChallanNo_V"].ToString()%></th>
                                    <th>
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date</th>
                                    <th>
                                        <%=df.Tables[0].Rows[0]["ChallanDate_D"].ToString()%></th>
                                </tr>
                                <tr>
                                    <td>
                                        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name
                                    </td>
                                    <td>
                                        <%=df.Tables[0].Rows[0]["Title"].ToString()%></td>
                                    <td>
                                        &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Type
                                    </td>
                                    <td>

                                        योजना / Yojna</td>
                                    <td>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; / Bilti No.
                                    </td>
                                    <td><%=df.Tables[0].Rows[0]["GRNO_V"].ToString()%>
                                        </td>
                                </tr>
                                </table>
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CssClass="tab">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                    <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name " DataField="Title" />
                                    <asp:BoundField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2344; / Distribution" DataField="Alllotedbook" />
                                    <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354; / Per Bundle " DataField="Perbundlebook" />
                                    <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; / Pack Bundle" DataField="BundleCount"/>
                                    <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose " DataField="LooseBundleCount" />
                                    <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; / Total Book" DataField="NOOfBooks" />
                                   <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; / Total Bundle" DataField="NoOfBundal" />
                                    <asp:BoundField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark" />
                                </Columns>
                                 <PagerStyle CssClass="Gvpaging" />
                                           <EmptyDataRowStyle CssClass="GvEmptyText" />
                                 <EmptyDataTemplate>
                                     Data Not Found ............
                                 </EmptyDataTemplate>
                            </asp:GridView>
                           
                            </div>
                          
                        </td>
                    </tr>
                </table>
          
        </div>
    </div>
</asp:Content>


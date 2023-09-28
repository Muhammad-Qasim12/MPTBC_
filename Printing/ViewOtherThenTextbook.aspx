<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewOtherThenTextbook.aspx.cs" Inherits="Printing_ViewOtherThenTextbook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdHead" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="ID" 
                            
                            AllowPaging="True" 
                            onpageindexchanging="GrdHead_PageIndexChanging" OnRowDataBound="GvReelDetails_RowDataBound" PageSize="30">
                            <Columns> 
                                  <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                             <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352; " DataField="ChallanNO" />
                                                               
                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="challandate"  />
                                <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="DepoName_V" />
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="Title" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="PrdadayBooks"  />
                                                              
                                 
                                  <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; " DataField="DepoStatsu" />
                                                              
                                 
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;"  >
                                    <ItemTemplate>
                                        <a href="OtherThenTextbookPrinterChallanRpt.aspx?ID=<%#Eval("ID") %>">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306; </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>


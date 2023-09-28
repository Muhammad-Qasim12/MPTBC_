<%@ Page Title="&#2332;&#2367;&#2354;&#2366; (निर्माण/सुधार)  / District (Insert/Update)" Language="C#" 
    MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewDistrict.aspx.cs" Inherits="Admin_ViewDistrict" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">   
     <div class="headlines">
            <h2>
                <span>&#2332;&#2367;&#2354;&#2366; (निर्माण/सुधार)  / District (Insert/Update)</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none;
                padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdDItrict" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="DistrictTrno_I" 
                            
                            onrowdeleting="GrdDItrict_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdDItrict_PageIndexChanging">
                            <Columns> 
                             <asp:BoundField HeaderText="&#2360;&#2306;&#2349;&#2366;&#2327; &#2325;&#2366; &#2344;&#2366;&#2350; / Division Name " DataField="Division_Name_Hindi_V" />
                              <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depot Name " DataField="DepoName_V" />
                             <asp:BoundField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; &#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2375;&#2306; / District Name In Hindi " DataField="District_Name_Hindi_V" />
                                 <asp:BoundField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; &#2309;&#2306;&#2327;&#2381;&#2352;&#2375;&#2332;&#2368; &#2350;&#2375;&#2306; / District Name In English " DataField="District_Name_Eng_V" />
                               
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit">
                                    <ItemTemplate>
                                        <a href="DistrictMaster.aspx?ID=<%# new APIProcedure().Encrypt(Eval("DistrictTrno_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                   <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:Button ID="btnDelete" CssClass="btn" Visible="false" runat="server" CommandName="Delete" Text="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove"
                                    OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>     
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>

</asp:Content>


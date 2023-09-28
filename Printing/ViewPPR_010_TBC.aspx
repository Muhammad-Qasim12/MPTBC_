<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPPR_010_TBC.aspx.cs" 
Inherits="Paper_ViewInspectionByTBC" Title="Inspection By TBC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box<div class="box table-responsive">">
        <div class="card-header">
            <h2>
                <span>TBC द्वारा निरिक्षण  </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
        <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <table>
                            <tr>
                                <td>
                                    <a class="btn" href="InspectionByTBC.aspx">
                                      
                                            &#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;
                                    </a>
                                </td>
                                
                                <td>
                                    <asp:TextBox ID="txtSearch" runat="server"  MaxLength="200"  placeholder="अधिकारी का नाम खोजे"></asp:TextBox>                                </td>
                                <td>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे" onclick="btnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="InspectionTrId_I"
                            OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" 
                            OnPageIndexChanging="GrdLOI_PageIndexChanging" 
                            onrowdatabound="GrdLOI_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="अधिकारी का नाम ">
                                    <ItemTemplate>
                                       
                                            <%#Eval("Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पद ">
                                    <ItemTemplate>
                                    <asp:Label ID="lblPost" runat="server" Text='<%#Eval("Post")%>'></asp:Label>   
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="एल.ओ.आई. नं.">
                                    <ItemTemplate>
                                        <%#Eval("LOINo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="पेपर का प्रकार ">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="पेपर आकार">
                                    <ItemTemplate>
                                        <%#Eval("CoverInformation")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                   <asp:TemplateField HeaderText="निरिक्षण रिपोर्ट ">
                                    <ItemTemplate>
                                        <%#Eval("InspectionReport_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                      <asp:TemplateField HeaderText="डाउनलोड करे">
                                    <ItemTemplate>
                                    
                                    <asp:Panel ID="pnldownload" runat="server" Visible='<%#Eval("InspectionFile_V").ToString().Equals("#")?false:true%>'>
                                      <a href="<%#"../PaperUploadedFile/"+ Eval("InspectionFile_V")%>">डाउनलोड </a>
                                      </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("InspectionFile_V").ToString().Equals("#")?true:false%>'>
                                            <a href="#">डाउनलोड </a>
                                            </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <a href="InspectionByTBC.aspx?ID=<%#Eval("InspectionTrId_I") %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />--%>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table></div>
        </div>
    </div>
</asp:Content>


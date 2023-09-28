<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPaperMillInfo.aspx.cs"
    Inherits="Paper_ViewPaperMillInfo" Title="पेपर मिल की जानकारी / Information Of Paper Mill" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information Of Paper Mill </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="PaperVendorMaster.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / New Entry</a>

                        </td>
                        <td style="text-align: right" width="75%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px"  ></asp:TextBox>
                             <asp:AutoCompleteExtender  
                     ServiceMethod="GetCompletionList"  
                      MinimumPrefixLength="1"  
                        CompletionInterval="10"  
                         EnableCaching="false"  
                          CompletionSetCount="1"   
                          TargetControlID="txtSearch"  
                        ID="AutoCompleteExtender1"  
                         runat="server"   
                         FirstRowSelected="false"  
                         DelimiterCharacters=","  
                     ShowOnlyCurrentWordInCompletionListItem="true" >  
  </asp:AutoCompleteExtender>  
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="3">
                            <asp:GridView ID="GrdVendorMaster" runat="server" AutoGenerateColumns="false"
                                GridLines="None" DataKeyNames="PaperVendorTrId_I"
                                CssClass="tab" EmptyDataText="Record Not Found." Width="100%"
                                OnRowDeleting="GrdVendorMaster_RowDeleting" AllowPaging="True"
                                OnPageIndexChanging="GrdVendorMaster_PageIndexChanging"
                                OnRowDataBound="GrdVendorMaster_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="नाम <br> Name ">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText=" &#2346;&#2340;&#2366; <br> Address ">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorAddress_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="सम्बंधित व्यक्ति का नाम <br>Contact Person">
                                        <ItemTemplate>
                                            <%#Eval("ContactPerson_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2342;&#2370;&#2352;&#2349;&#2366;&#2359; दूरभाष नं. <br>Contact No.">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorContactNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br> Registration No. ">
                                        <ItemTemplate>
                                            <%#Eval("RegistrationNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2381;&#2352;&#2375;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br> Registration Date ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRegistrationDate" runat="server" Text='<%#Eval("RegistrationDate_D")%>'></asp:Label>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--  <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2312;-&#2350;&#2375;&#2354;">
                                <ItemTemplate>
                                    <%#Eval("PaperVendorEmail_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                                    --%>
                                    <asp:TemplateField HeaderText="&#2351;&#2370;&#2332;&#2352; &#2310;&#2312;.&#2337;&#2368;<br> User Id">
                                        <ItemTemplate>
                                            <%#Eval("LoginId")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2366;&#2360;&#2357;&#2352;&#2381;&#2337;<br> Password">
                                        <ItemTemplate>
                                            <%#Eval("Password_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="कोर आई.डी.  / Core ID">
                                    <ItemTemplate>
                                        <%# Eval("AccHRID")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br> Edit">
                                        <ItemTemplate>
                                            <a href="PaperVendorMaster.aspx?ID=<%# new APIProcedure().Encrypt(Eval("PaperVendorTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="डाटा हटाये <br> Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" CausesValidation="false" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server" OnClick="lnkDelete_Click">डाटा हटाये / Delete</asp:LinkButton>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                     <tr><td>   <a href="javascript:history.go(-1)" style="font-family: Arial; font-size: large; color: #3366CC"><B> Back</B></a></td></tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


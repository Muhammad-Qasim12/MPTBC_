<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPaperMaster.aspx.cs" Inherits="Paper_ViewPaperMaster" Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Paper Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>&#2346;&#2375;&#2346;&#2352; &#2350;&#2366;&#2360;&#2381;&#2335;&#2352; / Paper Master</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="PaperMaster.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                &#2337;&#2366;&#2354;&#2375; / New Entry</a>
                        </td>
                        <td> पेपर का प्रकार(Paper TYPE)/जी एस एम (GSM)/केटेगरी(Category)	/गुणवत्ता(Quality)/आकार(PaperSize)</td>
                        <td style="text-align: right" width="75%">
                            <asp:TextBox ID="txtSearch" MaxLength="200" Width="400px" 
                                  runat="server"></asp:TextBox>
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
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="3">
                            <asp:GridView ID="GrdPaperMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="PaperTrId_I"
                                PageSize="10" OnRowDeleting="GrdPaperMaster_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdPaperMaster_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;<br>Paper Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperTrId_I" runat="server" Text='<%#Eval("PaperTrId_I")%>' Visible="false"></asp:Label>
                                            <%#Eval("PaperType") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="GSM">
                                        <ItemTemplate>
                                            <%#Eval("GSM")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2325;&#2375;&#2335;&#2375;&#2327;&#2352;&#2368; <br> Category Of Paper">
                                        <ItemTemplate>
                                            <%#Eval("PaperCategory")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2327;&#2369;&#2339;&#2357;&#2340;&#2381;&#2340;&#2366;(&#2344;&#2366;&#2350;) <br>Quality Of Paper">
                                        <ItemTemplate>
                                            <%#Eval("QualifyType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352; <br> Paper Size">
                                        <ItemTemplate>
                                            <%#Eval("PaperSize_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="&#2358;&#2368;&#2335;/&#2352;&#2368;&#2354; &#2325;&#2366; &#2357;&#2332;&#2344; (&#2327;&#2381;&#2352;&#2366;&#2350;) <br> Weight Of Sheet/Reel (Gram) ">
                                        <ItemTemplate>
                                            <%#Eval("PerSheetWt")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; <br> Edit">
                                        <ItemTemplate>
                                            <a href="PaperMaster.aspx?ID=<%# new APIProcedure().Encrypt(Eval("PaperTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                                &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; <br> Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" CausesValidation="false" OnClientClick="javascript:return confirm('Are you sure to delete ?')"
                                                runat="server" OnClick="lnkDelete_Click">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
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

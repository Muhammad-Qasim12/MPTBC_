<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TechnicalTermCondition.aspx.cs" 
Inherits="DistributionB_TechnicalTermCondition" Title="बीमा टेंडर की शर्ते"%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Vendor Agreement Work Plan--%>बीमा टेंडर की तकनिकी शर्ते / Technical Condition for Insurance Tender</span>
            </h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                       तकनिकी शर्ते / Technical Condition 
                    </td>
                    
                    <td>
                          <asp:TextBox ID="txtCondition" runat="server"  CssClass="txtbox reqirerd" Width="400"  MaxLength="350"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       शर्ते प्रदर्शित करने का स्तर / Display Status
                    
                    
                </td>
                <td>
                  <asp:DropDownList ID="ddlDisplayStatus" runat="server" CssClass="txtbox reqirerd">
                  <asp:ListItem Text="Yes"></asp:ListItem>
                  <asp:ListItem Text="No"></asp:ListItem>                            
                        </asp:DropDownList>


                </td>
               </tr> <tr>

                <td colspan="2">
                       <asp:Button ID="btnSave" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                        CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                </td>
                
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="Tender_Cond_Id" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false" >
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="तकनिकी शर्ते / Technical Condition">
                                    <ItemTemplate>
                                        
                                            <asp:Label ID="lblTndrCondition" runat="server" Text='<%#Eval("TndrCondition")%>'></asp:Label>                               
                                        <asp:Label ID="lblTender_Cond_Id" runat="server" Text='<%#Eval("Tender_Cond_Id")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="शर्ते प्रदर्शित करने का स्तर / Display Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDisplaySts" runat="server" Text='<%#Eval("DisplaySts")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>


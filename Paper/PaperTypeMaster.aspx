<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="PaperTypeMaster.aspx.cs" Inherits="Paper_PaperTypeMaster" Title="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Paper Type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
         <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
        <div class="headlines">
            <h2>
                <span>
                    <%--Vendor Agreement Work Plan--%>&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Paper Type</span>
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
                        &#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> Paper Type
                    </td>
                    
                    <td>
                        <asp:DropDownList ID="ddlPaperType" runat="server" CssClass="txtbox reqirerd"                                                         
                            oninit="ddlPaperType_Init">
                            
                        </asp:DropDownList>
                    </td>
                     </tr>
                 <tr>
                     <td>  </td>
                      <td colspan="2"><asp:Button ID="btnAdd" runat="server" Text="&#2344;&#2351;&#2366; &#2346;&#2375;&#2346;&#2352; &#2335;&#2366;&#2311;&#2346; &#2332;&#2379;&#2396;&#2375;/Add New Paper Type" CssClass="btn" OnClick="btnAdd_Click"  />
                        </td>
                </tr>
                <tr>
                    <td>
                        &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2327;&#2369;&#2339;&#2357;&#2340;&#2381;&#2340;&#2366;(&#2344;&#2366;&#2350;) <br /> Quality Of Paper(Name) 
                    
                    
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPaperQlty" runat="server"  CssClass="txtbox reqirerd"  onkeypress='javascript:tbx_fnAlphaNumericOnly(event, this);' MaxLength="50"></asp:TextBox>


                </td>
                    
                  
               </tr> <tr>

                <td colspan="4">
                       <asp:Button ID="btnSave" runat="server" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                </td>
                
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="GrdWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                            DataKeyNames="Qualifyid_I" CssClass="tab" EmptyDataText="Record Not Found."
                            Width="100%" AllowPaging="false" >
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br />  SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> Paper Type">
                                    <ItemTemplate>
                                        <%#Eval("PaperType")%>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_Id")%>' Visible="false"></asp:Label>                                       
                                        <asp:Label ID="lblQualifyid_I" runat="server" Text='<%#Eval("Qualifyid_I")%>' Visible="false"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2327;&#2369;&#2339;&#2357;&#2340;&#2381;&#2340;&#2366;(&#2344;&#2366;&#2350;) <br />  Quality Of Paper(Name) ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualifyType" runat="server" Text='<%#Eval("QualifyType")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; <br />  Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; <br />  Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; / Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

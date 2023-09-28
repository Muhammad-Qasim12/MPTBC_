<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperDetilasSearch.aspx.cs" Inherits="CenterDepot_PaperDetilas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box">
        <div class="card-header">
            <h2>&#2346;&#2375;&#2346;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2306;&#2337;&#2354; /&#2352;&#2368;&#2354; &#2348;&#2344;&#2366;&#2351;&#2375; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <table width="100%">
                    <tr>
                        <td class="auto-style1">
                            &#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2335;&#2366;&#2311;&#2346;


                        </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlGSM" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlGSM_SelectedIndexChanged">
                            </asp:DropDownList>


                            <br />


                        </td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; </td>
                        <td>
                            <asp:DropDownList ID="ddlVenderFill" runat="server">
                            </asp:DropDownList>
                        </td>
                        
                        <td>&#2352;&#2379;&#2354; &#2344;&#2379; </td>
                        <td>
                            <asp:TextBox ID="txtRoleNo" runat="server" Width="126px" onkeypress="javascript:tbx_fnInteger(event, this);" CssClass="txtbox reqirerd" ></asp:TextBox>
                        </td>
                        <td>
                             <asp:RadioButton ID="RDall" runat="server" Checked="True" GroupName="SR" Text="Contain" />
                            <asp:RadioButton ID="RDex" runat="server" GroupName="SR" Text="Exact Search" />
                             <asp:RadioButton ID="RDoverall" runat="server" GroupName="SR" Text="All Maching Search" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" OnClientClick="return ValidateAllTextForm();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:GridView ID="gvRoleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" EmptyDataText="Record Not Found." GridLines="None" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                  
                                    
                                    <asp:TemplateField HeaderText="Role No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Paper Mill">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("Papervendor")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mill Invoice No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("Invoiceno")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Invoice Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("mILLcHALANDATE")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Net Wt (Invoice)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("Papermillwet")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Printer Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("printername")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Printer Supply Challan No">
                                        <ItemTemplate>
                                            
                                              <asp:Label ID="txtNetWt" runat="server" Text='<%#Eval("Printerchalanno")%>'></asp:Label>
                                        </ItemTemplate>
                                    
                                    </asp:TemplateField>
                                    

                                    <asp:TemplateField HeaderText="Printer Challan Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReelType" runat="server" Text='<%#Eval("Printerchalandate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Net Wt. (Printer Challan) ">
                                        <ItemTemplate>
                                           <asp:Label ID="lblReelType" runat="server" Text='<%#Eval("Printermillwet")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            &nbsp;</td>
                    </tr></table>  </div></div></div>
</asp:Content>


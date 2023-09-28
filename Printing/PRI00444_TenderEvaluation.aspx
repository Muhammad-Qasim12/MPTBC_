<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI00444_TenderEvaluation.aspx.cs" Inherits="Printing_PRI004_TenderEvaluation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">LUN&nbsp; &#2325;&#2368; &#2354;&#2367;&#2360;&#2381;&#2335; &#2360;&#2375; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; 
     &#2325;&#2352;&#2375; </div>
                     <div class="portlet-content">
                     <div class="table-responsive">
                     
                     <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 


                    
                   <table width="100%">
                   <tr>
                   <td></td>
                   <td>
                   <asp:FileUpload runat="server" ID="FileUploadExcel" />
                   <asp:Button runat="server" ID="btnUpload" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375; " OnClick="btnUpload_Click" 
                           Width="141px" />
                   
                   
                   </td>
                   </tr>

                   <tr>
                   <td>&nbsp;</td>
                   <td>
                  <%-- <asp:RadioButtonList ID="RbHDR" runat="server" RepeatDirection="Horizontal"  >
                   <asp:ListItem Text="Yes" Value="Yes" Selected ="True" ></asp:ListItem>
                   <asp:ListItem Text="No" Value="No"  ></asp:ListItem>
                   </asp:RadioButtonList>--%>
                   </td>

                   </tr>
                   
                   <tr>
                   <td colspan="2" align="center">
                   <asp:GridView ID="GrdEval" runat="server" CssClass="tab hastable" AutoGenerateColumns="false"   >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <asp:CheckBox runat="server" ID="chk" />

                         <asp:HyperLink runat="server" ID="hypPRIReg" Text="Register" Target="_blank" ></asp:HyperLink>

                         <asp:HiddenField runat="server" ID="HdnPriId" Value='<%# Eval("PrinterId") %>' ></asp:HiddenField>

                        <asp:HiddenField runat="server" ID="HDNGroupId" Value='<%# Eval("GroupId") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNCompanyName" Value='<%# Eval("CompanyName") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNRates" Value='<%# Eval("Rates") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNRank" Value='<%# Eval("Rank") %>' ></asp:HiddenField>

                        <asp:HiddenField runat="server" ID="HDNGRPID" Value='<%# Eval("GrpId") %>' ></asp:HiddenField>

                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:BoundField DataField="GroupId" HeaderText="Group Name" />
                         <asp:BoundField DataField="CompanyName" HeaderText="Printer Name" />
                         <asp:BoundField DataField="Rates" HeaderText="Rates" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />


                         <%--<asp:TemplateField HeaderText="Group Name" >
                         <InsertItemTemplate>
                         <asp:Label runat="server" ID="LblGroupName" Text='<%# Eval("GroupId") %>' ></asp:Label>

                         </InsertItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Printer Name" >
                         <InsertItemTemplate>
                         <asp:Label runat="server" ID="LblCompanyName" Text='<%# Eval("CompanyName") %>' ></asp:Label>

                         </InsertItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Rates" >
                         <InsertItemTemplate>
                         <asp:Label runat="server" ID="LblRates" Text='<%# Eval("Rates") %>' ></asp:Label>

                         </InsertItemTemplate>
                         </asp:TemplateField>

                         <asp:TemplateField HeaderText="Status" >
                         <InsertItemTemplate>
                         <asp:Label runat="server" ID="LblRank" Text='<%# Eval("Rank") %>' ></asp:Label>

                         </InsertItemTemplate>
                         </asp:TemplateField>
--%>

                        

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                       
                  
                       
                   </asp:GridView> 
                   
                   </td>
                   </tr>
                   <tr>
                   <td>
                   <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; " 
                            />
                   </td>
                   
                   </tr>


                   </table>


                     </div> </div> 
</asp:Content>


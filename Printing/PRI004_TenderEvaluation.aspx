<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI004_TenderEvaluation.aspx.cs" Inherits="Printing_PRI004_TenderEvaluation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">LUN&nbsp; &#2325;&#2368; &#2354;&#2367;&#2360;&#2381;&#2335; &#2360;&#2375; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; 
     &#2325;&#2352;&#2375; / Select Printer from LUN List </div>
                     <div class="portlet-content">
                     <div class="table-responsive">
                     
                     <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 


                    
                   <table width="100%">
                   <tr>
                   <td></td>
                   <td>
                   <asp:FileUpload runat="server" ID="FileUploadExcel" Visible="False" />
                   <asp:Button runat="server" ID="btnUpload" 
                           Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375; / Select Printer" OnClick="btnUpload_Click" 
                           Width="200px" Visible="False" />
                   
                   
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

                        <asp:HiddenField runat="server" ID="HdnGroupName" Value='<%# Eval("GroupId") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNGRPID" Value='<%# Eval("GrpId") %>' ></asp:HiddenField>

                         </ItemTemplate>
                         </asp:TemplateField>
                           <asp:BoundField DataField="GroupId" HeaderText="Group Name" />
                         <asp:TemplateField HeaderText="Printer Name" >
                         <ItemTemplate>
                             <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text='<%#Eval("CompanyName") %>' CommandArgument='<%#Eval("CompanyName") %>' />
                              </ItemTemplate>
                         </asp:TemplateField>
                         
                         
                         <asp:BoundField DataField="Rates" HeaderText="Rates" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />


                        

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView> 
                    <asp:Button ID="Button3" OnClick="Button3_Click" CssClass="btn" runat="server" Text="Close" />
                                   
                   </td>
                   </tr>
                   <tr>
                   <td>
                       <asp:HiddenField ID="HiddenField1" runat="server" />
                   </td>
                   
                   </tr>


                   </table>


                     </div> </div> 
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
   
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">
                <asp:Label ID="Label1" runat="server" Text="" ></asp:Label><br /><br />
               Group Capacity : <asp:TextBox ID="TextBox1" runat="server" Width="70px" ></asp:TextBox> 

                  Printer Capacity :   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>   
                  Total EMD(Rs) :   <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>   
                <asp:GridView ID="GridView1" runat="server" CssClass="tab hastable" AutoGenerateColumns="false"   >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <asp:CheckBox runat="server" ID="chk" AutoPostBack="true" OnCheckedChanged="chkChoose_CheckedChanged" />

                             <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("qty") %>' />
                              <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("color") %>' />
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:BoundField DataField="GroupNO" HeaderText="Group Name" />
                         <asp:BoundField DataField="Company" HeaderText="Printer Name" />
                         <asp:BoundField DataField="Rates" HeaderText="Rates(Rs.)" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />

                            <asp:BoundField DataField="qty" HeaderText="Quantity(Tonnes)" />
                            <asp:BoundField DataField="Tanage" HeaderText="EMD(Rs)" />
                             <asp:BoundField DataField="PrintingSec" HeaderText="10% Printing Security(Rs)" />
                             <asp:BoundField DataField="PaperSec" HeaderText="100% Paper Security(Rs)" />

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView>
                <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="btn" runat="server" Text="Close" />
                                  <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;/Save " 
                           OnClick="btnSave_Click" />
                       
                  </div> 
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Technical_GroupAllotment.aspx.cs" Inherits="Printing_TechnicalBidAllot" MaintainScrollPositionOnPostback="true"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2340;&#2325;&#2344;&#2367;&#2325;&#2368; &#2346;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339; &#2325;&#2352;  &#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2310;&#2357;&#2306;&#2335;&#2344; &#2325;&#2352;&#2375; / Technical Assessment of Printer and Allotement of Group    </div>
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
                   
                   
                       <asp:HiddenField ID="hdPrinterName" runat="server" />
                   
                   
                   </td>
                   
                   <tr>
                   <td></td>
                   <td>
                       &nbsp;</td>
                   
                   </tr>

                   <tr>
                   <td colspan="2">
                       <%--<asp:CheckBox runat="server" ID="chk" />

                         <asp:HyperLink runat="server" ID="hypPRIReg" Text="Register" Target="_blank" ></asp:HyperLink>

                         <asp:HiddenField runat="server" ID="HdnPriId" Value='<%# Eval("PrinterId") %>' ></asp:HiddenField>

                        <asp:HiddenField runat="server" ID="HDNGroupId" Value='<%# Eval("GroupId") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNCompanyName" Value='<%# Eval("CompanyName") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNRates" Value='<%# Eval("Rates") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNRank" Value='<%# Eval("Rank") %>' ></asp:HiddenField>

                        <asp:HiddenField runat="server" ID="HdnGroupName" Value='<%# Eval("GroupId") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNGRPID" Value='<%# Eval("GrpId") %>' ></asp:HiddenField>--%>
                   <asp:Button ID="Btn_TechAssmt" OnClick="Btn_TechAssmt_Click" runat="server" CssClass="btn"  Text='Click for Printer Wise Technical Assessment '  Width="335px" Visible="False" />
                   
                   <asp:Button ID="Btn_TechAssmt0" OnClick="Btn_TechAssmt_Click1" runat="server" CssClass="btn"  Text='Click for Group Allotment'  Width="233px" Visible="False" />
                   
                       </td>

                   </tr>
                   
                   <tr>

                   <td colspan="2" align="center">

                   <asp:GridView ID="GrdEval" runat="server" CssClass="tab hastable" AutoGenerateColumns="false" OnSelectedIndexChanged="GrdEval_SelectedIndexChanged"   >
                       <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                         <%--<asp:TemplateField>
                         <ItemTemplate>--%>
                         <%--<asp:CheckBox runat="server" ID="chk" />

                         <asp:HyperLink runat="server" ID="hypPRIReg" Text="Register" Target="_blank" ></asp:HyperLink>

                         <asp:HiddenField runat="server" ID="HdnPriId" Value='<%# Eval("PrinterId") %>' ></asp:HiddenField>

                        <asp:HiddenField runat="server" ID="HDNGroupId" Value='<%# Eval("GroupId") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNCompanyName" Value='<%# Eval("CompanyName") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNRates" Value='<%# Eval("Rates") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNRank" Value='<%# Eval("Rank") %>' ></asp:HiddenField>

                        <asp:HiddenField runat="server" ID="HdnGroupName" Value='<%# Eval("GroupId") %>' ></asp:HiddenField>
                        <asp:HiddenField runat="server" ID="HDNGRPID" Value='<%# Eval("GrpId") %>' ></asp:HiddenField>--%>

                        <%-- </ItemTemplate>
                         </asp:TemplateField>--%>
                          <asp:BoundField DataField="CompanyName" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Printer Name" />

                          
                         
                         
                         
                             
                           
                            <asp:TemplateField >
                            
                             <ItemTemplate>

                            
                             <asp:HiddenField runat="server" ID="HdnPriId" Value='<%# Eval("PrinterId") %>' ></asp:HiddenField>
                             <asp:Button ID="Button4" CssClass="btn"   runat="server" Text='<%# Eval("CompanyName") %>'  Width="250PX" Visible="false"   />
                                
                                 <asp:Button ID="Button1" OnClick="Button1_Click" CssClass="btn" runat="server" Visible ="false" Text='Click for Technical Evaluation' CommandArgument='<%#Eval("CompanyName") %>' Width="250PX"  />
                            <asp:Button ID="Button5" OnClick="Button5_Click" runat="server" CssClass="btn"  Text='Click for Group Allotment' CommandArgument='<%#Eval("CompanyName") %>' Width="250PX" />
                              </ItemTemplate>
                         </asp:TemplateField>

                         
                         
                        <%-- <asp:BoundField DataField="Rates" HeaderText="Rates" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />--%>


                        

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView> 
                   
                       &nbsp;</td>
                   </tr>
                   <tr>
                   <td>
                       <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:Button ID="Button3" OnClick="Button3_Click" CssClass="btn" runat="server" Text="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2346;&#2375;&#2332; &#2346;&#2352; &#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " Width="289px" /> 
                   </td>
                   
                   </tr>


                   </table>


                     </div> </div> 
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
   
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">
                <asp:Label ID="Label1" runat="server" Text=" " ></asp:Label>
                     Printer Capacity : <asp:Label ID="Label2" runat="server" Text=" " ></asp:Label>
                 Printer Capacity*(1.5) :  <asp:Label ID="Label3" runat="server" Text=" " ></asp:Label>
                 Allotted Capacity :   <asp:Label ID="Label4" runat="server" Text=" " ></asp:Label>   
             
             


                <asp:GridView ID="GridView1" runat="server" CssClass="tab hastable" AutoGenerateColumns="false" RowStyle-BackColor="YellowGreen"  ForeColor="Black" Font-Bold="true"    >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <asp:CheckBox runat="server" ID="chk"  OnCheckedChanged="chkChoose_CheckedChanged" Checked="true" Visible="false"  />
                             <asp:HiddenField ID="HiddenField4" runat="server" Value='<%#Eval("PrinterCapecity") %>' />
                             <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("qty") %>' />
                              <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("color") %>' />
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:BoundField DataField="GroupNO" HeaderText="Group Name" />
                      <%--   <asp:BoundField DataField="Company" HeaderText="Printer Name" />--%>
                        
                           
                           <%-- <asp:BoundField DataField="Rates" HeaderText="Rates" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />--%>

                            <asp:BoundField DataField="qty" HeaderText="Group Quantity(Tonnage)" />
                        

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView>
                  <asp:GridView ID="GridView2" runat="server" CssClass="tab hastable" AutoGenerateColumns="false"  RowStyle-BackColor="Red" FooterStyle-BackColor="White"      >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <asp:CheckBox runat="server" ID="chk" Visible="false" />
                             <asp:HiddenField ID="HiddenField4" runat="server" Value='<%#Eval("PrinterCapecity") %>' />
                             <asp:HiddenField ID="HiddenField2" runat="server" Value='<%#Eval("qty") %>' />
                              <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("color") %>' />
                         </ItemTemplate>
                         </asp:TemplateField>
                         
                         <asp:BoundField DataField="GroupNO" HeaderText="Group Name" />
                        <%-- <asp:BoundField DataField="Company" HeaderText="Printer Name" />--%>
                       <%--  <asp:BoundField DataField="Rates" HeaderText="Rates" />
                         <asp:BoundField DataField="Rank" HeaderText="Status" />--%>

                            <asp:BoundField DataField="qty" HeaderText="Group Quantity(Tonnage)" />
                        

                       </Columns>
                       <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                       
                  
                       
                   </asp:GridView>
                <asp:Button ID="Button2" OnClick="Button2_Click" CssClass="btn" runat="server" Text="Close" />
                                  <%--<asp:Button runat="server" ID="btnSave" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;/Save " 
                           OnClick="btnSave_Click" />--%>
                       
                  </div> 


    <div id="Div1" class="modalBackground" style="display: none;" runat="server">
            </div>
   
            <div id="Div2" style="display: none;" class="popupnew1" runat="server">

                <asp:Label ID="Label6" runat="server" Text="" ></asp:Label><br /><br />
               <br />
                Group Allotment to Printer
                <br />
                Group Capacity : <asp:TextBox ID="TextBox1" runat="server" Width="70px" ></asp:TextBox> 

                  Printer Capacity :   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>   
                  Total EMD(Rs) :   <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>   
                <asp:Panel ID="Panel1" runat="server" Width="800px" Height="400px" ScrollBars="Both" >
                <asp:GridView ID="GridView3" runat="server" CssClass="tab hastable" AutoGenerateColumns="false"   >
                       <Columns>
                         <asp:TemplateField>
                         <ItemTemplate>
                         <asp:CheckBox runat="server" ID="chk1" AutoPostBack="true" OnCheckedChanged="chkChoose1_CheckedChanged" />

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
                <asp:Button ID="Button6" OnClick="Button6_Click" CssClass="btn" runat="server" Text="Close" />
                                  <asp:Button runat="server" ID="Button7" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;/Save " 
                           OnClick="Button7_Click" />
                </asp:Panel>
                       
                  </div> 





</asp:Content>


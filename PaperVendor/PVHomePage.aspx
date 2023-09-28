<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PVHomePage.aspx.cs" Inherits="PaperVendor_PVHomePage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="table-responsive">
        <div class="portlet-header ui-widget-header">
        <%--View Demand Grouping From Printing--%>मुख्य पृष्ठ / Home
    </div>
      <center>
<table width="99%">
    <tr>
        <td width="50%" class="box" style="border:1px solid #000000; ">    
            <div >
        <div class="card-header" >
            <h2>
                <span style="font-size:12px;">पेपर मिल का वर्क प्लान <br /> Work Plan Of Paper Mill</span>
                 <div style="float:right;font-size:12px;">             
                         यूनिट मेट्रिक टन में / Unit in Matric Ton
            </div>

            </h2>
        </div>
        <div style="padding-right:5px; padding-left:5px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
             <asp:GridView ID="GvWorkPlan" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." Font-Size="11px" 
                               AllowPaging="True" >
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर मिल का नाम<br>Name Of Paper Mill ">
                                        <ItemTemplate>                                            
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर का प्रकार<br>Paper Type">
                                        <ItemTemplate>                                            
                                            <%#Eval("PaperType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="आदेश दिनांक<br>Order Date">
                                        <ItemTemplate>
                                            <%#Eval("SupplyDate_D")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रारंभिक तिथि<br>Start Date">
                                        <ItemTemplate>
                                            <%#Eval("StartDate")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रदाय की अंतिम तिथि<br>Last Date of Supply">
                                        <ItemTemplate>
                                             <%#Eval("SupplyTillDate_D")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
            </div>
        </div>
    </div>
              
            
        </td>
        <td style="width:1px;"></td>
        <td width="50%" class="box" style="border:1px solid #000000;">
                <div >
        <div class="card-header">
            <h2>
                <span  style="font-size:12px;">मिलबार मुद्रण एवं कव्हर कागज आवंटन व प्राप्ति <br /> Mill Wise Printing & Cover Paper Allotment</span>
               <div style="float:right;font-size:12px;">             
                         यूनिट मेट्रिक टन में / Unit in Matric Ton
            </div>
            </h2>
        </div>
        <div style="padding-right: 5px; padding-left: 5px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
               <asp:GridView ID="GvPaperMillDispch" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found."   Font-Size="11px"
                               AllowPaging="True" >
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="मिल का नाम<br>Paper Mill Name">
                                        <ItemTemplate>                                            
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  <%--  <asp:TemplateField HeaderText="पेपर का प्रकार<br>Paper Type">
                                        <ItemTemplate>                                            
                                            <%#Eval("PaperType")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                        <ItemTemplate>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर का आवंटन<br>Allotment Of Paper">
                                        <ItemTemplate>
                                            <%#Eval("ReqQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रदाय की कुल मात्रा <br>Total Supplied Quantity">
                                        <ItemTemplate>
                                            <%#Eval("TotalRecv")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर की शेष मात्रा <br>Remaining Quatity  Of Paper">
                                        <ItemTemplate>
                                             <%#Eval("RemainingQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
            </div>
        </div>
    </div>

        </td>
    </tr>

</table></center>
      </div>
</asp:Content>


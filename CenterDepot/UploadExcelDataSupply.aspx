<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="UploadExcelDataSupply.aspx.cs" Inherits="CenterDepot_UploadExcelDataSupply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
       <link href="../css/printrcpt.css" rel="stylesheet" media="all" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-header ui-widget-header">
        &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2379; &#2346;&#2375;&#2346;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375;&#2306; &#2319;&#2325;&#2381;&#2360;&#2375;&#2354; &#2347;&#2377;&#2352;&#2381;&#2350;&#2375;&#2335; &#2350;&#2375;&#2306; / Upload data in excel format to issue paper to printer
    </div>
     <asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
    <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
    <div>

            <table>
                 <%--<tr>--%>
                    <%--<td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" Width="100px" OnInit="ddlAcYear_Init"></asp:DropDownList></td>--%>
                     
                     <%--<td>Download:</td>
                <td>
                    <a href="CenterDepot_Upload/mptbc_excelformat_Issue.xlsx">Excel Format for Issue Paper to Printer</a>
                            </td>--%>
                    <%-- </tr>--%>
                <tr>
                    <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" Width="100px" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
                     <td>
                   पेपर मिल का नाम/ Name Of Paper Mill</td>
                      <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="160px" CssClass="txtbox reqirerd"   >
                       </asp:DropDownList>
                            </td>
                    <td>Upload Excel for Issue Paper to Printer:</td>
                    <td><asp:FileUpload ID="FLExcelData" runat="server" /></td>
                    <td>
                         <asp:Button ID="btnExportPDF" runat="server" CssClass="btn" Text="Upload" OnClick="btnSave_Click" />
                     </td>
                </tr>
                <tr>
                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                </tr>
            </table>
        </div>
        
    <div style="width: auto; height: auto;">                            
                                <div class="MT20">
                                    <asp:Panel ID="Panel1" runat="server" Width="100%">
                                        <div id="ExportDiv" runat="server">
                                            <div style="width: 900px;">
                                                <div style="padding: 10px;">
                                                    <asp:HiddenField ID="hdRepeater" runat="server" />
                                                    <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." 
                                AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                >
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="FileName">
                                        <ItemTemplate>
                                            <%#Eval("FileName")%>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Paper Mill">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                     <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <%#Eval("Transaction_D")%>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <a href='<%#Eval("FilePath").ToString().Replace("~/","../")%>'>Download</a>                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>  
                                                                                       
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                
                            </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                    </asp:Panel>
                                </div>    
        
         <div style="float:left;vertical-align:bottom;padding-top:190px;padding-left:5px;padding-bottom:10px;">
          <a href="../CenterDepot/mptbc_excelformat_Issue.xlsx" style="color:#0000FF;text-decoration:underline;">Download Excel Format for Issue Paper to Printer</a></div>         
        </div>

    </ContentTemplate>
         <Triggers  > 
                <asp:PostBackTrigger ControlID="btnExportPDF" />
            </Triggers>
  </asp:UpdatePanel>     
   
     
 
</asp:Content>


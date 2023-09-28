<%@ Page  Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewQualityCheckReport.aspx.cs"
 Inherits="Paper_ViewQualityCheckReport"  Title="&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2330;&#2375;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;/ Quality Check Report"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="headlines">
            <h2>
                <span>&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2330;&#2375;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; / Quality Check Report </span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px"><div class="table-responsive">
            <table width="100%">
                <tr>
                     <td style="text-align: left" >
                                    <a class="btn" href="QualityCheckReport.aspx">
                                       
                                             New Entry
                                    </a>
                                </td>
                           <td style="text-align: right" width="30%">&nbsp;</td>
                    <td style="text-align: left" width="15%">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Acadmic Year :
                        <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"  Width="245px"></asp:DropDownList>
                    </td>
                                 <td style="text-align: right" width="25%">
                                    <asp:TextBox ID="txtSearch" runat="server"  MaxLength="200" Width="85px"  placeholder="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; &#2326;&#2379;&#2332;&#2375; / Search By Paper Mill Name"></asp:TextBox>                                </td>
                             <td style="text-align: left" width="5%">
                                    <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search" onclick="btnSearch_Click" />
                                </td>
                </tr>
                <tr>
                    <td style="text-align: center" colspan="5">
                        <asp:GridView ID="GrdLabInspection" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="LabInspectionTrId_I"
                            AllowPaging="True"   OnRowDeleting="GrdLabInspection_RowDeleting" OnPageIndexChanging="GrdLabInspection_PageIndexChanging" 
                            OnRowDataBound="GrdLabInspection_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="&#2360;&#2376;&#2306;&#2346;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>Sample No.">
                                    <ItemTemplate>
                                        <%#Eval("SampleNo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; <br> L.O.I. No.">
                                    <ItemTemplate>
                                        <%#Eval("LOINo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2354;&#2376;&#2348; &#2325;&#2366; &#2344;&#2366;&#2350; <br> Lab Name">
                                    <ItemTemplate>
                                        <%#Eval("LabName")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; <br> Paper Mill Name">
                                    <ItemTemplate>
                                    <%#Eval("PaperVendorName_V")%>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2376;&#2306;&#2346;&#2354; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;<br> Sample Received Date">
                                    <ItemTemplate>
                                           <asp:Label ID="lblSampleReceiveDate_D" runat="server" Text='<%#Eval("SampleReceiveDate_D")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; <br>Inspection Report">
                                    <ItemTemplate>
                                        <%#Eval("LabInspectionReport_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="लैब से प्राप्त रिपोर्ट की जानकारी डाले  ">
                                    <ItemTemplate>
                                          <a href="LabSampleReport.aspx?ID=<%# (Eval("LabInspChild_Id_I").ToString()) %>&LabName=<%#Eval("LabName")%>&PaperMil=<%#Eval("PaperVendorName_V")%>">&#2337;&#2366;&#2335;&#2366;
                                            &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2337;&#2366;&#2354;&#2375;</a>
                             
                                        </ItemTemplate> 

                                 </asp:TemplateField> 
                               <asp:TemplateField HeaderText="&#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;<br>Download Quality Report">
                                    <ItemTemplate>
                                    
                                    <asp:Panel ID="pnldownload" runat="server" Visible='<%#Eval("LabInspectionFile_V").ToString().Equals("#")?false:true%>'>
                                      <a href="<%#"../PaperUploadedFile/"+ Eval("LabInspectionFile_V")%>">&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; </a>
                                      </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("LabInspectionFile_V").ToString().Equals("#")?true:false%>'>
                                            <a href="#">&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2337;&#2366;&#2313;&#2344;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375; </a>
                                            </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;<br>Edit">
                                    <ItemTemplate>
                                        <a href="QualityCheckReport.aspx?ID=<%# new APIProcedure().Encrypt(Eval("LabInspectionTrId_I").ToString()) %>">&#2337;&#2366;&#2335;&#2366;
                                            &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</a>
                                    </ItemTemplate>
                                      
                                </asp:TemplateField>
         
                               <%-- <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;" />--%>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div></div>
    </div>
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 65%;
        }
    </style>
</asp:Content>



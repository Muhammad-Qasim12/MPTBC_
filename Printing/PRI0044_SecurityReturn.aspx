<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI0044_SecurityReturn.aspx.cs" Inherits="Printing_PRI0044_EMDTransfer" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">EMD &#2347;&#2366;&#2311;&#2344;&#2375;&#2306;&#2360; &#2325;&#2379; &#2349;&#2375;&#2332;&#2375; / EMD Transfer To Finance</div>
    <div class="portlet-content">
        <div class="table-responsive">

            <asp:Panel ID="messDiv" runat="server">
                <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td colspan="2" class="auto-style1">
                        <asp:Panel ID="Panel11" runat="server">
                 <table> <tr> <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :&nbsp;
                     <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="true" CssClass="txtbox reqirerd" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                     </asp:DropDownList>
                    </td>
                    <td>&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2335;&#2375;&#2306;&#2337;&#2352; </td>
                    <td>
             <asp:DropDownList ID="ddlTenderID_I" CssClass="txtbox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged"></asp:DropDownList></td> </tr></table>  
            </asp:Panel>  </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="GrdEval" runat="server" CssClass="tab hastable" AutoGenerateColumns="False" OnRowDataBound="GrdEval_RowDataBound"
                            ShowFooter="True" OnSelectedIndexChanged="GrdEval_SelectedIndexChanged">
                            <Columns>


                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="<br>Academic Year" >
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblYear" Text='<%# Eval("myear") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; <br>Printer Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblPrinterName" Text='<%# Eval("PrinterName") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350;<br> GroupName">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblGroupName" Text='<%# Eval("GroupName") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="EMD &#2352;&#2366;&#2358;&#2367; <br>EMD Amount">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblEMDAmount_N" Text='<%# Eval("EMDAmount_N") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339;<br>Description">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtRemark" runat="server" MaxLength="200" Text='<%#Eval("Remark") %>'></asp:TextBox>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                

                                <asp:TemplateField HeaderText="&#2319;&#2350; &#2310;&#2352; &#2344;&#2306;&#2348;&#2352;  &lt;br&gt;MRno">
                                    <ItemTemplate>

                                        
                                        <asp:TextBox ID="lblTransferSts" runat="server"  Text='<%#Eval("TransferSts") %>'></asp:TextBox>

                                    
                                      

                                    </ItemTemplate>
                                      <FooterTemplate>

                                        <asp:Button runat="server" ID="btnSave" CssClass="btn"
                                            Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;/Save "
                                            OnClick="btnSave_Click" />

                                        
                                    </FooterTemplate>
                                      
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2319;&#2350; &#2310;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;  &lt;Br&gt; MR Date">
                                    <ItemTemplate>
                                        <asp:TextBox ID="lblPrinterSts" runat="server"  Text='<%# Eval("PrinterSts") %>'></asp:TextBox>
                                        
                                        <asp:Label runat="server" ID="lblPrinterid" Visible="false" Text='<%# Eval("Printerid_i") %>'></asp:Label>

                                    </ItemTemplate>
                                    <FooterTemplate>

                                      
                                        <asp:Button runat="server" ID="btnclose" CssClass="btn"
                                            Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; / Close "
                                            OnClick="btnclose_Click" />

                                    </FooterTemplate>
                                </asp:TemplateField>


                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />



                        </asp:GridView>

                    </td>
                </tr>
                <tr>
                    <td></td>

                    <td>&nbsp;</td>

                </tr>


            </table>


        </div>
    </div>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 54px;
        }
    </style>
</asp:Content>



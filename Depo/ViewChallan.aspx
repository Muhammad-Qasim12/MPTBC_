<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewChallan.aspx.cs" Inherits="Depo_ViewChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
        <h2>
            <span>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  </span></h2>
    </div>

    <asp:Button ID="Button1" runat="server"  Text="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2344;&#2375; &#2325;&#2375; &#2354;&#2367;&#2319; &#2351;&#2361;&#2366;&#2305; &#2325;&#2381;&#2354;&#2367;&#2325; &#2325;&#2352;&#2375; " CssClass="btn" OnClick="Button1_Click" />
    <br /><br />
    <table width="100%">
                <tr>
                    <td style="text-align: left">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; :
                        <asp:DropDownList ID="ddlprinterName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlprinterName_SelectedIndexChanged">
                        </asp:DropDownList>
&nbsp;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
&nbsp;<asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2326;&#2379;&#2332;&#2375; " />
                    </td> </tr> 
                <tr>
                    <td style="text-align: left"> 
    <asp:GridView ID="grdDetails" runat="server" AutoGenerateColumns="False" 
                                            CssClass="tab" DataKeyNames="PriTransID" AllowPaging="True" OnPageIndexChanging="grdDetails_PageIndexChanging" OnRowDeleting="grdDetails_RowDeleting" PageSize="20" 
                                            >
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                    

                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /Printer Name"><ItemTemplate><%# Eval("NameofPress_V")%></ItemTemplate></asp:TemplateField>
               
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Challan No."><ItemTemplate><%# Eval("ChallanNo_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Challan Date"><ItemTemplate><%# Eval("ChallanDate_D")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Book Name"><ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  " Visible="true" >
            <ItemTemplate><%# Eval("NoOfbookYojana").ToString ()=="0" ? Eval("NoOfBookSamanya") : Eval("NoOfbookYojana") %>
                <br />
                 (<%#Eval("booktype") %>)
           <%--     <%#Eval("NoOfBookSamanya") %>--%>

                                                                                                                                                                                          </ItemTemplate></asp:TemplateField>
                                                
                <asp:BoundField DataField="TotalNoOfBundle" HeaderText="&#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; " />                        
       <asp:BoundField DataField="unLordingCharge_N" HeaderText="&#2313;&#2340;&#2352;&#2366;&#2312; " />
                                                
                                         
                                                <asp:TemplateField HeaderText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; ">
                                                    <ItemTemplate>
                                                      <a href="UpdateChallan.aspx?ID=<%# Eval("StockReceiveEntryID_I") %>">&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                         
                                                <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; " />
                                                
                                         
                                            </Columns>
                                        </asp:GridView>
                    </td> </tr> </table> 
    </asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT013.aspx.cs" Inherits="Depo_VIEW_DPT013" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2 style="margin: 0px; padding: 0px; border: 0px; outline: 0px; font-weight: inherit; font-style: normal; font-size: 15px; font-family: Arial, Verdan, sans-serif; vertical-align: baseline; color: rgb(255, 255, 255); font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-style: initial; text-decoration-color: initial;"><span style="margin: 0px; padding: 0px; border: 0px; outline: 0px; font-weight: inherit; font-style: inherit; font-size: 15px; font-family: inherit; vertical-align: baseline;">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 100 % &#2332;&#2366;&#2352;&#2368; &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342;</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
           
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
             <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2358;&#2375;&#2359; &#2348;&#2330;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379;  &#2325;&#2368;  100 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375; "   
                            onclick="btnSave_Click" />
                    &nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2357;&#2352;&#2381;&#2359; :
                        <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                       <asp:GridView ID="grnMain" runat="server" AutoGenerateColumns="False" 
                    CssClass="tab" AllowPaging="True" onpageindexchanging="grnMain_PageIndexChanging">
                    <Columns>
                       <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Printer_RedID_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                        <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                        <asp:BoundField DataField="FromDate_D" HeaderText=" &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;" />
                        <asp:BoundField DataField="Totaldate_D" HeaderText=" &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; " />
                                             
                           <asp:TemplateField HeaderText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; ">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306;" CssClass="btn " Visible='<%# Eval("SendStatus").ToString()=="1" ? false  : true %>'  onclick="btnSave1_Click" />
                    <%--<asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Eval("PradayBookChalan").ToString()=="0" ? false  : true %>' onclick = "Check_Click(this)"/>--%>
                </ItemTemplate>
            </asp:TemplateField>
                        

                      <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2344;&#2367;&#2325;&#2366;&#2354;&#2375; ">
                                    <ItemTemplate>
                                        <a href="FinalDetailsreport.aspx?ID=<%#(Eval("Printer_RedID_I").ToString ()) %>&Fromdate=<%# Eval("FromDate_D") %>&Todate=<%# Eval ("Totaldate_D") %>&fyear=<%# Eval ("AcYear") %>&DepoName=<%# Eval("DepoName_V") %>" target="_blank" >&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2344;&#2367;&#2325;&#2366;&#2354;&#2375; </a>
                                    </ItemTemplate>
                                </asp:TemplateField>   
                                             

                        <asp:TemplateField Visible="false" >
                             <ItemTemplate>
<asp:Button ID="Button2" runat="server" Text="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2349;&#2375;&#2332;&#2375; " CssClass="btn " Visible='<%# Eval("SendStatus").ToString()=="1" ? false  : true %>'  onclick="btnSave2_Click" />
                                 </ItemTemplate>
                        </asp:TemplateField>
                                             

                    </Columns>
                </asp:GridView>
                        <br />
                        <asp:Button ID="Button3" runat="server" CssClass="btn " onclick="btnSave2_Click" Text="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2349;&#2375;&#2332;&#2375; "  />
                    
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>


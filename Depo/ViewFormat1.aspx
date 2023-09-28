﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewFormat1.aspx.cs" Inherits="Depo_ViewFormat1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                &#2346;&#2381;&#2352;&#2346;&#2340;&#2381;&#2352; -1 </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; / Enter New Data"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                 <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2367;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; " DataField="Acyear" />
                                <asp:BoundField HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; " DataField="MediunNameHindi_V" />
                                <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; " DataField="ClassID" />
                                <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;">
                                                 <ItemTemplate>
                                                       <a href="Format-1.aspx?Year=<%#Eval("Acyear")%>&MediumIDa=<%#Eval("MediumID") %>&Classtra=<%# Eval ("ClassID") %>" > <%#Eval("ClassID")%></a>
                                            
                                         
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        </td>
                </tr></table> </div> </div> 
</asp:Content>


﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReportInterdepo.aspx.cs" Inherits="Depo_ReportInterdepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span style="height: 1px">&#2309;&#2344;&#2381;&#2340;&#2337;&#2367;&#2346;&#2379; &#2361;&#2360;&#2381;&#2340;&#2366;&#2306;&#2340;&#2352;&#2339;</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            &#2350;&#2343;&#2381;&#2351;&#2366;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;,&#2349;&#2339;&#2381;&#2337;&#2366;&#2352;
            <div >
                <table>
                    <tr>
                        <td>
                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" CssClass="txtbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" CssClass="txtbox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                          &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379;
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList10" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            
                        </td>
                        <td>
                           
  &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325; &#2337;&#2367;&#2346;&#2379;
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            
                        <asp:Button ID="Button3" runat="server" CssClass="btn" 
                            
                                Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" />
                            
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <table class="tab">
                                <tr>
                                    <th rowspan="2">
                                        &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                     <th colspan="2">
                                        &#2309;&#2344;&#2381;&#2340;&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                    </th>
                                    <th colspan="3">
                                        &#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2325;&#2367;&#2360; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2325;&#2379; &#2319;&#2357;&#2306; &#2325;&#2367;&#2340;&#2344;&#2368; 
                                        &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375;&#2306; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2361;&#2369;&#2312;
                                    </th>
                                    <th colspan="2">
                                        &#2325;&#2350; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                    </th>
                                    <th colspan="2">
                                        &#2325;&#2350; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                    </th>
                                </tr>
                                <tr>
                                    <th>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                    </th>
                                    <th>
                                        &#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                    </th>
                                    <th>
                                        &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;
                                    </th>
                                    <th>
                                        &#2351;&#2379;&#2332;&#2344;&#2366;
                                    </th>
                                    <th>
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2325;&#2379; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;
                                    </th>
                                    <th>
                                        &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                    </th>
                                    <th>
                                        &#2351;&#2379;&#2332;&#2344;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                    </th>
                                    <th>
                                        &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;
                                    </th>
                                    <th>
                                        &#2351;&#2379;&#2332;&#2344;&#2366;
                                    </th>
                                    <th>
                                        &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;
                                    </th>
                                    <th>
                                        &#2351;&#2379;&#2332;&#2344;&#2366;
                                    </th>
                                </tr>
                                <tr>
                                    <td>1</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>                                        
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>2</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>                                        
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>3</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>                                        
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
</asp:Content>


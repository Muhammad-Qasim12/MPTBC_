﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhysicalVerification.aspx.cs" Inherits="Depo_PhysicalVerification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 260px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
                            <div class="card-header" align="center">
                                <h2><span>
                                <P>&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;,&#2361;&#2379;&#2358;&#2306;&#2327;&#2366;&#2348;&#2366;&#2342; <br />&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; - &#2360;&#2350;&#2381;&#2346;&#2340;&#2381;&#2340;&#2367; (&#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368;) &#2325;&#2366; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2360;&#2340;&#2381;&#2352; &#2408;&#2406;&#2407;&#2409;-&#2408;&#2406;&#2407;&#2410;</P></span></h2>
                                
                            </div>
                            <div style="padding:0 10px;">
                            <br />
                            <table >                    
        <tr>
            <Td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;
            </Td>
             <Td><asp:TextBox ID="txt" runat="server" CssClass="txtbox"></asp:TextBox>
            </Td>
            <Td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;
            </Td>
             <Td class="style1"><asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"></asp:TextBox>
            </Td>
             <Td class="style1">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" 
                            
                     Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" />
            </Td>
        </tr>
        </table><br /><br /><br />
                            
    <table width="100%" class="tab">
        <tr>
        
            <Th rowspan="2" >&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
            </Th>
            <Th rowspan="2" >&#2360;&#2350;&#2381;&#2346;&#2340;&#2381;&#2340;&#2367; &#2325;&#2366; &#2344;&#2366;&#2350;
            </Th>
            <Th rowspan="2">&#2360;&#2381;&#2335;&#2377;&#2325; &#2346;&#2306;&#2332;&#2368; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
            </Th>
            <Th colspan="2" >&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
            </Th>
            <Th rowspan="2" >&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;
        </tr>
        <tr>
            <Th>
                &#2313;&#2346;&#2351;&#2379;&#2327;&#2368;
            </Th>
            <Th>
                &#2309;&#2344;&#2369;&#2346;&#2351;&#2379;&#2327;&#2368; 
            </Th>
        </tr>
        <tr>
            <td>1.
            </td>
            <td>&#2325;&#2350;&#2381;&#2346;&#2381;&#2351;&#2370;&#2335;&#2352; 
            </td>
            <td>1
            </td>
            <td >1
            </td>
            <td>
                0</td>
                <td>
                </td>
        </tr>
        <tr>
            <td>2
            </td>
            <td>&#2346;&#2381;&#2354;&#2366;&#2360;&#2381;&#2335;&#2367;&#2325; &#2325;&#2369;&#2352;&#2381;&#2360;&#2368;
            </td>
            <td>5
            </td>
            <td>3
            </td>
            <td>2
            </td>
            <td>
            </td>
        </tr>
    </table>
</div></div>
</asp:Content>


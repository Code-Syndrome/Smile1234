﻿<%@  Page Title="" Language="C#" MasterPageFile="~/idx.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@  Register Src="~/control/nav.ascx" TagPrefix="uc1" TagName="nav" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="js/index.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="block clearfix">
  
        <uc1:nav runat="server" ID="nav" />
  
  
  <div class="AreaR">
  
  <table cellspacing="0" cellpadding="0" width="953" align="center" border="0">
  <tbody>
  <tr>
   
    <td height="28" width="100%">
      </td>
  </tr></tbody></table>
 
   
   
      
<div style="float:left">
  <script type="text/javascript">
  var swf_width=545;
  var swf_height=245;
  </script>
  <script type="text/javascript" src="data/flashdata/pinkfocus/cycle_image.js"></script>
    <div id="flash_cycle_image"><object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="545" height="245">
        <param name="allowScriptAccess" value="sameDomain"><param name="movie" value="data/flashdata/pinkfocus/pinkfocus.swf"><param name="quality" value="high">
        <param name="bgcolor" value="#F0F0F0">
        <param name="menu" value="false">
        <param name="wmode" value="opaque">
        <param name="FlashVars" value="pics=images/7.jpg|images/8.jpg|images/9.jpg|images/4.jpg&links=#|#|#|#|&borderwidth=545&borderheight=245&textheight=0">
        <embed src="data/flashdata/pinkfocus/pinkfocus.swf" flashvars="pics=images/7.jpg|images/8.jpg|images/9.jpg|images/4.jpg&links=#|#|#|#|&borderwidth=545&borderheight=245&textheight=0" quality="high" width="545" height="245" allowscriptaccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="transparent"></object>

    </div>
</div>        <div class="f_r">   
	   <div id="mallNews" class="f_r box_1">
    <h3><span>新闻资讯</span></h3>
    <div class="NewsList tc  " style="border-top:none">
        <ul>

<asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
                <li>
      <a href="newsView.aspx?id=<%# Eval("nid") %>" title="<%# Eval("title") %>"><%# Eval("title") %></a>
        </li>
   </ItemTemplate>
</asp:Repeater>
    
                </ul>
    </div>
</div>       </div>
       
       <div class="blank"></div>
     
       

<div class="box  ">
  <div class="itemTit" id="itemHot">
   <div class="tit">
       <div class="f_l">
  狗狗种类
</div>
    <div class="f_r"><a href="gg.aspx">更多&gt;&gt;</a></div>
      <div class="ss_class"> 
             </div>
      </div>
  </div>
  
  
  <div class="blank"></div>
  <div id="show_hot_area" class="clearfix">

<asp:Repeater ID="Repeater2" runat="server"  >
  <ItemTemplate>
      <div class="goodsItem" style="height:205px; text-align:center;">
 
           <a href="ggView.aspx?id=<%# Eval("did") %>"><img src="uploads/<%# Eval("photo") %>" alt="<%# Eval("dname") %>" class="goodsimg"></a><br>
            <p class="f1"><a href="ggView.aspx?id=<%# Eval("did") %>" title="<%# Eval("dname") %>"><%# Eval("dname") %></a></p>
 
           </div>
 </ItemTemplate>
</asp:Repeater>
  
    </div>
</div>
<div class="blank"></div>

  

      
<div class="box  ">
  <div class="itemTit" id="itemHot">
   <div class="tit">
       <div class="f_l">
  新品上架
</div>
    <div class="f_r"><a href="pro.aspx">更多&gt;&gt;</a></div>
      <div class="ss_class"> 
             </div>
      </div>
  </div>
  
  
   <div class="blank"></div> 
  <div id="show_hot_area" class="clearfix">

<asp:Repeater ID="Repeater4" runat="server"  >
  <ItemTemplate>
      <div class="goodsItem" style="height:205px; text-align:center;">
 
           <a href="proView.aspx?id=<%# Eval("pid") %>"><img src="uploads/<%# Eval("pic") %>" alt="<%# Eval("pname") %>" class="goodsimg"></a><br>
            <p class="f1"><a href="proView.aspx?id=<%# Eval("pid") %>" title="<%# Eval("pname") %>"><%# Eval("pname") %></a></p>
 
           <font class="f1">
                     <b>¥</b><%# Eval("price") %></font></div>
 </ItemTemplate>
</asp:Repeater>
  
    </div>
</div>
<div class="blank"></div>

    
    
   
  </div>
  
  <div class="blank"></div>
   
  
  
  
<div style="clear:both"></div> 
  
</div>

</asp:Content>
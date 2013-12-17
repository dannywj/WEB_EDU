//<![CDATA[
function Show_Menu(id_num,num){
for(var i=0;i<11;i++){document.getElementById("content_"+id_num+i).style.display="none";}
for(var i=0;i<11;i++){document.getElementById("menu_"+id_num+i).className="";}
document.getElementById("menu_"+id_num+num).className="Channel_on";
document.getElementById("content_"+id_num+num).style.display="block";
}
//]]>
//<![CDATA[
function Show_Menu1(id_num,num){
for(var i=0;i<4;i++){document.getElementById("content1_"+id_num+i).style.display="none";}
for(var i=0;i<4;i++){document.getElementById("menu1_"+id_num+i).className="";}
document.getElementById("menu1_"+id_num+num).className="Change_on";
document.getElementById("content1_"+id_num+num).style.display="block";
}
//]]>
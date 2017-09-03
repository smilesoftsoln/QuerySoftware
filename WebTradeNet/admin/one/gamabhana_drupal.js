function switchmode(internal,obj)
{
if(obj != null)
{
 try {
  GphMasterSwapLang();
 } catch (e) {}
}
else if(internal)
{
 try {
  GphMasterSwapLang();
 } catch (e) {}

 try
 {	
   if(document.getElementById('gamabhana_def').checked) 
   { document.getElementById('gamabhana_def').checked=false;
     document.getElementById('gamabhana_sec').checked = true;
   }
   else if(document.getElementById('gamabhana_sec').checked) 
   { document.getElementById('gamabhana_sec').checked=false;
     document.getElementById('gamabhana_def').checked = true;
   }
  }
  catch (e)
  {}
}
}

function SetPriLanguage(ilang)
{
try
{
 GphMasterPriLangUpdate(ilang);
 document.getElementById('gamabhana_def').value = ilang;
}
catch (e)
{}
return;
}
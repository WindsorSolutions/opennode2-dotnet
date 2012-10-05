 
    function findPosX(obj)
    {
      var curleft = 0;
      if (obj.offsetParent)
      {
       while (obj.offsetParent)
       {
        curleft += obj.offsetLeft
        obj = obj.offsetParent;
       }
      }
      else if (obj.x)
       curleft += obj.x;
      return curleft;
    }

    function findPosY(obj)
    {
       var curtop = 0;
       if (obj.offsetParent)
       {
        while (obj.offsetParent)
        {
         curtop += obj.offsetTop
         obj = obj.offsetParent;
        }
       }
       else if (obj.y)
        curtop += obj.y;
       return curtop;
    }



    function getDateTimeSettings(cal){
    
       var winWidth = 250;
       var winHeight = 200;
    
       var imgLeft = findPosX(cal);
       var imgTop = findPosY(cal) + (winWidth / 2);
       
       //alert("loc: " + imgLeft + "; " + imgTop);
       
	    return 'width=' + winWidth + ',height=' + winHeight
		    + ',top=' + imgTop + ',left=' + imgLeft
		    + ',scrollbars=no,location=no,directories=no,status=no,menubar=no,toolbar=no,resizable=yes';
    }
        

    
    

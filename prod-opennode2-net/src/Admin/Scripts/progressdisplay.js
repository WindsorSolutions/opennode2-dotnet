function applicationLoadHandler() {
    /// <summary>Raised after all scripts have been loaded and the objects in the application have been created and initialized.</summary>
};
function applicationUnloadHandler() {
    mainForm.CleanUp();
    mainForm = null;
    Sys.Application.dispose();
};
function beginRequestHandler() {
    /// <summary>Raised after an asynchronous postback is finished and control has been returned to the browser.</summary>
    mainForm.StartUpdating();
};
function endRequestHandler() {
    /// <summary>Raised before processing of an asynchronous postback starts and the postback request is sent to the server.</summary>
    // Set status bar text if any was passed through the hidden field on the form
    mainForm.EndUpdating()
};
var mainForm = 
{
    pnlPopup : "on2PnlPopup",
    innerPopup: "on2PnlPopupInner",
    updating : false
};
mainForm.StartUpdating = function() {
    mainForm.updating = true;
    mainForm.AttachPopup();
    mainForm.onUpdating();
};
mainForm.EndUpdating = function() {
    mainForm.updating = false;
    mainForm.DetachPopup();
    mainForm.onUpdated();
};
mainForm.onUpdating = function() {
    if (mainForm.updating) {
        var pnlPopup = $get(this.pnlPopup);
        pnlPopup.style.display = '';
        var docBounds = mainForm.GetClientBounds();
        var pnlPopupBounds = Sys.UI.DomElement.getBounds(pnlPopup);
        var x = docBounds.x + Math.round(docBounds.width / 2) - Math.round(pnlPopupBounds.width / 2);
        var y = docBounds.y + Math.round(docBounds.height / 2) - Math.round(pnlPopupBounds.height / 2);
        Sys.UI.DomElement.setLocation(pnlPopup, x, y);
        //if(Sys.Browser.agent == Sys.Browser.InternetExplorer) {
        if (!pnlPopup.iFrame) {
            var iFrame = document.createElement("IFRAME");
            iFrame.scrolling = "no";
            //iFrame.src = "nothing.txt";
            iFrame.src = "";
            iFrame.frameBorder = 0;
            iFrame.style.display = "none";
            iFrame.style.position = "absolute";
            iFrame.style.filter = "alpha(opacity=40)";
            iFrame.style.opacity = 0.4;
            iFrame.style.zIndex = 1;
            iFrame.style.backgroundColor = "gray";

            pnlPopup.parentNode.insertBefore(iFrame, pnlPopup);
            pnlPopup.iFrame = iFrame;
        }
        pnlPopup.iFrame.style.width = docBounds.width + "px";
        pnlPopup.iFrame.style.height = docBounds.height + "px";
        pnlPopup.iFrame.style.left = docBounds.x + "px";
        pnlPopup.iFrame.style.top = docBounds.y + "px";
        pnlPopup.iFrame.style.display = "block";
        //}  
    }
}
mainForm.onUpdated = function() {
    // get the update progress div
    var pnlPopup = $get(this.pnlPopup);
    // make it invisible
    pnlPopup.style.display = 'none';
    if(pnlPopup.iFrame) {
        pnlPopup.iFrame.style.display = "none";
    }
}; 
mainForm.AttachPopup = function() {
    /// <summary>
    /// Attach the event handlers for the popup
    /// </summary>
    this._scrollHandler = Function.createDelegate(this, this.onUpdating);
    this._resizeHandler = Function.createDelegate(this, this.onUpdating);    
    $addHandler(window, 'resize', this._resizeHandler);
    $addHandler(window, 'scroll', this._scrollHandler);
    this._windowHandlersAttached = true;
};
mainForm.DetachPopup = function() {
    /// <summary>
    /// Detach the event handlers for the popup
    /// </summary>
    if (this._windowHandlersAttached) {
        if (this._scrollHandler) {
            $removeHandler(window, 'scroll', this._scrollHandler);
        }
        if (this._resizeHandler) {
            $removeHandler(window, 'resize', this._resizeHandler);
        }
        this._scrollHandler = null;
        this._resizeHandler = null;
        this._windowHandlersAttached = false;
    }
};
mainForm.CleanUp = function() {
    /// <summary>
    /// CleanUp all resources held by mainForm object
    /// </summary>
    this.DetachPopup();
    var pnlPopup = $get(this.pnlPopup);
    if(pnlPopup && pnlPopup.iFrame) {
       pnlPopup.parentNode.removeChild(pnlPopup.iFrame);
       pnlPopup.iFrame = null;
    }
    this._scrollHandler = null;
    this._resizeHandler = null;
    this.pnlPopup = null;
    this.innerPopup = null;
    this.updating = null;
};
mainForm.GetClientBounds = function() {
    /// <summary>
    /// Gets the width and height of the browser client window (excluding scrollbars)
    /// </summary>
    /// <returns type="Sys.UI.Bounds">
    /// Browser's client width and height
    /// </returns>
    var clientWidth;
    var clientHeight;
    switch(Sys.Browser.agent) {
        case Sys.Browser.InternetExplorer:
            clientWidth = document.documentElement.clientWidth;
            clientHeight = document.documentElement.clientHeight;
            break;
        case Sys.Browser.Safari:
            clientWidth = window.innerWidth;
            clientHeight = window.innerHeight;
            break;
        case Sys.Browser.Opera:
            clientWidth = Math.min(window.innerWidth, document.body.clientWidth);
            clientHeight = Math.min(window.innerHeight, document.body.clientHeight);
            break;
        default:  // Sys.Browser.Firefox, etc.
            clientWidth = Math.min(window.innerWidth, document.documentElement.clientWidth);
            clientHeight = Math.min(window.innerHeight, document.documentElement.clientHeight);
            break;
    }
    var scrollLeft = (document.documentElement.scrollLeft ? document.documentElement.scrollLeft : document.body.scrollLeft);
    var scrollTop = (document.documentElement.scrollTop ? document.documentElement.scrollTop : document.body.scrollTop);
    return new Sys.UI.Bounds(scrollLeft, scrollTop, clientWidth, clientHeight);
}; 
if(typeof(Sys) !== "undefined")Sys.Application.notifyScriptLoaded();
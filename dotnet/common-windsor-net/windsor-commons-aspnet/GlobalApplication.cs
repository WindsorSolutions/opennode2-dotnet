#define DATA_PROVIDER_IN_SESSION
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using Windsor.Commons.Core;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Reflection;

namespace Windsor.Commons.AspNet
{
    public abstract class GlobalApplicationBase : System.Web.HttpApplication
    {
        public GlobalApplicationBase()
        {
            s_Application = this;
            Error += new EventHandler(OnGlobalError);
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            OnApplicationStart();
        }
        protected void Application_ReleaseRequestState(object sender, EventArgs e)
        {
            OnRequestEnd();
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            OnSessionStart();
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            OnRequestStart();
        }

        protected virtual void OnGlobalError(object sender, EventArgs e)
        {
        }
        protected virtual void OnApplicationStart()
        {
            s_ApplicationVersion = DetermineApplicationVersion();
        }
        protected virtual void OnSessionStart()
        {
        }
        protected virtual void OnRequestStart()
        {
        }
        protected virtual void OnRequestEnd()
        {
        }
        protected virtual Version DetermineApplicationVersion()
        {
            Version version = new Version();
            try
            {
                Type type = this.GetType();
                type = type.BaseType; // The main global implementation is wrapped by ASP.global_asax
                Assembly assembly = Assembly.GetAssembly(type);
                FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                version = new Version(versionInfo.FileMajorPart, versionInfo.FileMinorPart, versionInfo.FileBuildPart,
                                      versionInfo.FilePrivatePart);
            }
            catch (Exception)
            {
            }
            return version;
        }
        protected virtual string ConfigFolderRelativePath
        {
            get
            {
                return "~/Config";
            }
        }
        public static string GetImageUrl(string imageName)
        {
            return string.Format("~/{0}/{1}", IMAGES_FOLDER_NAME, imageName);
        }
        public static string ValidationImageFormatText
        {
            get
            {
                if (s_Validation_Image_Format_Text == null)
                {
                    s_Validation_Image_Format_Text = GetValidationImageFormatText("validationError_16.png");
                }
                return s_Validation_Image_Format_Text;
            }
        }
        public static T MakeValidationImage<T>(T validator) where T : BaseValidator
        {
            validator.ErrorMessage = string.Format(ValidationImageFormatText, validator.ErrorMessage);
            return validator;
        }
        public static string GetValidationImageFormatText(string errorImageName)
        {
            string validationErrorUrl = AspNetUtils.GetFullyQualifiedApplicationRootUrl(GetImageUrl(errorImageName));
            return string.Format("<img src=\"{0}\" title=\"{{0}}\" alt=\"Error\" style=\"vertical-align:middle\">",
                                 validationErrorUrl);
        }
        public static void ForceNoIE9CompatibilityMode(Page page)
        {
            if (IsBrowserIE)
            {
                //Meta tag to force IE9 out of compatability mode
                HtmlMeta metaDescription = new HtmlMeta()
                {
                    HttpEquiv = "X-UA-Compatible",
                    Content = "IE=9"
                };
                page.Header.Controls.Add(metaDescription);
            }
        }
        public static Version ApplicationVersion
        {
            get
            {
                return s_ApplicationVersion;
            }
        }
        public static bool IsBrowserIE
        {
            get
            {
                return HttpContext.Current.Request.Browser.Browser.Equals("IE", StringComparison.OrdinalIgnoreCase);
            }
        }
        public static bool IsBrowserFirefox
        {
            get
            {
                return HttpContext.Current.Request.Browser.Browser.Equals("Firefox", StringComparison.OrdinalIgnoreCase);
            }
        }
        public static bool IsBrowserChrome
        {
            get
            {
                return HttpContext.Current.Request.Browser.Browser.Equals("AppleMAC-Safari", StringComparison.OrdinalIgnoreCase);
            }
        }
        public static void GetPostbackParams(out string eventTarget, out string eventArgument)
        {
            HttpRequest request = HttpContext.Current.Request;
            if (request != null)
            {
                eventTarget = request.Params.Get("__EVENTTARGET");
                eventArgument = request.Params.Get("__EVENTARGUMENT");
            }
            else
            {
                eventTarget = eventArgument = null;
            }
        }
        public static CaseInsensitiveDictionary<string> ParseConfigFile(string configFileName)
        {
            string filePath = GetPhysicalApplicationPathThrow(Path.Combine(GetApplicationBase().ConfigFolderRelativePath, configFileName));

            return SimpleConfigFileParser.ParseConfigFile(filePath);
        }
        public static string GetPhysicalApplicationPath(string relativePath)
        {
            if (relativePath.StartsWith("~\\") || relativePath.StartsWith("~/"))
            {
                relativePath = (relativePath.Length == 2) ? string.Empty : relativePath.Substring(2);
            }
            string path = Path.Combine(PhysicalApplicationPath, relativePath);
            path = Path.GetFullPath(path);
            return path;
        }
        public static string GetPhysicalApplicationPathThrow(string relativePath)
        {
            string filePath = GetPhysicalApplicationPath(relativePath);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("The application relative path \"{0}\" resolved to \"{1},\" but the file is missing",
                                                              relativePath, filePath));
            }
            return filePath;
        }
        public static string PhysicalApplicationPath
        {
            get
            {
                return HttpRuntime.AppDomainAppPath;
            }
        }
        public static string BaseSiteUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;
                string baseUrl = context.Request.Url.Scheme + "://" + context.Request.Url.Authority + context.Request.ApplicationPath.TrimEnd('/');
                return baseUrl;
            }
        }
        public static void ReturnResponseFileContentBytes(string filePath, string contentName, string contentType)
        {
            byte[] content = File.ReadAllBytes(filePath);
            ReturnResponseFileContentBytes(content, contentName, contentType);
        }
        public static void ReturnResponseFileContentBytes(byte[] content, string contentName, string contentType)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.ClearHeaders();
            response.ClearContent();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", contentName));
            response.AddHeader("Content-Length", content.Length.ToString());
            response.ContentType = contentType;
            response.BinaryWrite(content);
            response.Flush();
            response.End();
            //HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        public virtual bool IsPostbackRequest
        {
            get
            {
                return (Request.HttpMethod == "POST");
            }
        }
        public virtual bool IsCallbackRequest
        {
            get
            {
                return (HttpContext.Current.Request != null) && (HttpContext.Current.Request["__CALLBACKID"] != null);
            }
        }
        public virtual Page GetRequestPage
        {
            get
            {
                // Not sure if this works
                Page page = Context.Handler as Page;
                return page;
            }
        }
        public static GlobalApplicationBase GetApplicationBase()
        {
            if ((HttpContext.Current != null) && (HttpContext.Current.ApplicationInstance != null))
            {
                return (GlobalApplicationBase)HttpContext.Current.ApplicationInstance;
            }
            return s_Application;
        }
        public static GlobalApplicationBaseType GetApplication<GlobalApplicationBaseType>() where GlobalApplicationBaseType : GlobalApplicationBase
        {
            return (GlobalApplicationBaseType)GetApplicationBase();
        }

        private static GlobalApplicationBase s_Application;
        private static Version s_ApplicationVersion;
        private static string s_Validation_Image_Format_Text;
        private static object s_RequestLockObject = new object();
        private static object s_SessionLockObject = new object();
        private static object s_ApplicationLockObject = new object();
        private const string REQUEST_VARS_NAME = "Request.Vars";
        private const string SESSION_VARS_NAME = "Session.Vars";
        private const string APP_VARS_NAME = "Application.Vars";
        protected static string IMAGES_FOLDER_NAME = "Images";
    }

    public abstract class GlobalApplication<RequestVarsStorageType, SessionVarsStorageType, AppVarsStorageType> : GlobalApplicationBase
        where RequestVarsStorageType : class, new()
        where SessionVarsStorageType : class, new()
        where AppVarsStorageType : class, new()
    {
        public GlobalApplication()
        {
        }
        protected override void OnApplicationStart()
        {
            base.OnApplicationStart();

            ValidateAppVars();
        }
        protected override void OnSessionStart()
        {
            base.OnSessionStart();

            ValidateAppVars();
            bool isPostbackRequest = IsPostbackRequest;

            try
            {
                ValidateSessionVars(isPostbackRequest);
            }
            catch (UnauthorizedAccessException)
            {
                throw new HttpException(401, "Unauthorized Access Exception");
            }
        }
        protected override void OnRequestStart()
        {
            base.OnRequestStart();

            ValidateAppVars();
            if (HttpContext.Current.Session != null)    // Work around ASP.NET bug
            {
                bool isPostbackRequest = IsPostbackRequest;
                bool isCallbackRequest = IsCallbackRequest;
                ValidateSessionVars(isPostbackRequest);
                ValidateRequestVars(isPostbackRequest);
            }
        }
        protected override void OnRequestEnd()
        {
            base.OnRequestEnd();

            DisposeRequestVars();
        }
        protected virtual void ValidateRequestVars(bool isPostbackRequest)
        {
            lock (s_RequestLockObject)
            {
                RequestVarsStorageType requestVars = (RequestVarsStorageType)HttpContext.Current.Items[REQUEST_VARS_NAME];
                bool anyChanged = false;

                if (requestVars == null)
                {
                    requestVars = new RequestVarsStorageType();
                    anyChanged = true;
                }

                anyChanged |= ValidateRequestVars(requestVars, isPostbackRequest);

                if (anyChanged)
                {
                    RequestVars = requestVars;
                }
            }
        }
        protected virtual bool ValidateRequestVars(RequestVarsStorageType requestVars, bool isPostbackRequest)
        {
            return false;
        }
        protected virtual void DisposeRequestVars()
        {
            lock (s_RequestLockObject)
            {
                RequestVarsStorageType requestVars = (RequestVarsStorageType)HttpContext.Current.Items[REQUEST_VARS_NAME];

                if (requestVars != null)
                {
                    DisposeRequestVars(requestVars);
                    RequestVars = null;
                }
            }
        }
        protected virtual void DisposeRequestVars(RequestVarsStorageType requestVars)
        {
        }
        public virtual void ValidateSessionVars(bool isPostbackRequest)
        {
            lock (s_SessionLockObject)
            {
                SessionVarsStorageType sessionVars = (SessionVarsStorageType)HttpContext.Current.Session[SESSION_VARS_NAME];
                bool anyChanged = false;

                if (sessionVars == null)
                {
                    sessionVars = new SessionVarsStorageType();
                    anyChanged = true;
                }

                anyChanged |= ValidateSessionVars(sessionVars, isPostbackRequest);

                if (anyChanged)
                {
                    SessionVars = sessionVars;
                }
            }
        }
        protected virtual bool ValidateSessionVars(SessionVarsStorageType sessionVars, bool isPostbackRequest)
        {
            return false;
        }
        public virtual void ValidateAppVars()
        {
            lock (s_ApplicationLockObject)
            {
                AppVarsStorageType appVars = (AppVarsStorageType)HttpContext.Current.Application[APP_VARS_NAME];
                bool anyChanged = false;

                if (appVars == null)
                {
                    appVars = new AppVarsStorageType();
                    anyChanged = true;
                }

                anyChanged |= ValidateAppVars(appVars);

                if (anyChanged)
                {
                    AppVars = appVars;
                }
            }
        }
        protected virtual bool ValidateAppVars(AppVarsStorageType appVars)
        {
            return false;
        }

        protected static RequestVarsStorageType RequestVars
        {
            get
            {
                lock (s_RequestLockObject)
                {
                    RequestVarsStorageType requestVars = (RequestVarsStorageType)HttpContext.Current.Items[REQUEST_VARS_NAME];
                    if (requestVars == null)
                    {
                        DebugUtils.CheckDebuggerBreak();
                        throw new InvalidOperationException("Could not retrieve RequestVarsStorage object, this accessor is being called from the wrong code location!");
                    }
                    return requestVars;
                }
            }
            set
            {
                lock (s_RequestLockObject)
                {
                    HttpContext.Current.Items[REQUEST_VARS_NAME] = value;
                }
            }
        }
        protected static SessionVarsStorageType SessionVars
        {
            get
            {
                lock (s_SessionLockObject)
                {
                    SessionVarsStorageType sessionVars = (SessionVarsStorageType)HttpContext.Current.Session[SESSION_VARS_NAME];
                    if (sessionVars == null)
                    {
                        DebugUtils.CheckDebuggerBreak();
                        throw new InvalidOperationException("Could not retrieve SessionVarsStorage object, this accessor is being called from the wrong code location!");
                    }
                    return sessionVars;
                }
            }
            set
            {
                lock (s_SessionLockObject)
                {
                    HttpContext.Current.Session[SESSION_VARS_NAME] = value;
                }
            }
        }
        protected static AppVarsStorageType AppVars
        {
            get
            {
                lock (s_ApplicationLockObject)
                {
                    AppVarsStorageType applicationVars = (AppVarsStorageType)HttpContext.Current.Application[APP_VARS_NAME];
                    if (applicationVars == null)
                    {
                        DebugUtils.CheckDebuggerBreak();
                        throw new InvalidOperationException("Could not retrieve ApplicationVarsStorage object, this accessor is being called from the wrong code location!");
                    }
                    return applicationVars;
                }
            }
            set
            {
                lock (s_ApplicationLockObject)
                {
                    HttpContext.Current.Application[APP_VARS_NAME] = value;
                }
            }
        }

        private static object s_RequestLockObject = new object();
        private static object s_SessionLockObject = new object();
        private static object s_ApplicationLockObject = new object();
        private const string REQUEST_VARS_NAME = "Request.Vars";
        private const string SESSION_VARS_NAME = "Session.Vars";
        private const string APP_VARS_NAME = "Application.Vars";
    }
}
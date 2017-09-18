using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

using Windsor.Commons.Core;
using Windsor.Commons.Logging;

using Spring.Web.Support;
using Spring.Context;
using Spring.Objects.Factory;
using Windsor.Commons.AspNet;

namespace Windsor.Commons.Spring.AspNet
{
    public class BaseSpringPage : global::Spring.Web.UI.Page, ISupportsWebDependencyInjection, IInitializingObject
    {
        public BaseSpringPage()
        {
            _logger = LogManagerEx.GetLogger(this.GetType().Name);
        }
        public virtual void AfterPropertiesSet()
        {
            // do some initialization work
        }

        public virtual void ReloadPage()
        {
            GlobalUtils.ReloadPage(this);
        }
        public virtual void RegisterScriptFile(string scriptFilePageRelativePath)
        {
            AspNetUtils.RegisterScriptFile(this, scriptFilePageRelativePath);
        }
        public virtual void RegisterCssFile(string cssFilePageRelativePath)
        {
            AspNetUtils.RegisterCssFile(this, cssFilePageRelativePath);
        }
        public virtual void RegisterScriptBlock(string clientScript)
        {
            AspNetUtils.RegisterScriptBlock(this, clientScript);
        }
        protected override void OnLoad(EventArgs e)
        {
            CheckIfSessionStateExpired();
            CheckDataModel();

            base.OnLoad(e);
        }

        protected virtual void CheckIfSessionStateExpired()
        {
            if (!IsPostBack)
            {
                SessionStateUtils.InitPageSessionState();
            }
            else
            {
                if (!SessionStateUtils.PageSessionStateIsValid)
                {
                    OnSessionStateExpired();
                }
            }
        }
        protected virtual void OnSessionStateExpired()
        {
            if (ThrowExceptionIfSessionStateExpires)
            {
                SessionStateUtils.ThrowSessionStateExpiredException();
            }
        }
        protected override object LoadModelFromPersistenceMedium()
        {
            string name = GetModelPersistenceName();
            object model = SessionStateUtils.Get<object>(name);
            return model;
        }
        protected override void SaveModelToPersistenceMedium(object modelToSave)
        {
            string name = GetModelPersistenceName();
            SessionStateUtils.Set(name, modelToSave);
        }
        protected virtual string GetModelPersistenceName()
        {
            return this.GetType().FullName + ".Model";
        }

        // Subclasses use CreateDataModel() instead of InitializeModel()
        protected sealed override void InitializeModel()
        {
        }
        // Subclasses use CreateDataModel() instead of InitializeModel()
        protected virtual void CreateDataModel()
        {
        }
        // Subclasses use LoadDataModel() instead of LoadModel()
        protected sealed override void LoadModel(object savedModel)
        {
        }
        // Subclasses use LoadDataModel() instead of LoadModel()
        protected virtual void LoadDataModel(object savedModel)
        {
        }
        // Subclasses use SaveDataModel() instead of SaveModel()
        protected sealed override object SaveModel()
        {
            return SaveDataModel();
        }
        // Subclasses use SaveDataModel() instead of SaveModel()
        protected virtual object SaveDataModel()
        {
            return null;
        }

        protected virtual void CheckDataModel()
        {
            if (!IsPostBack)
            {
                if (PersistModelForEntireSession)
                {
                    object model = LoadModelFromPersistenceMedium();
                    if (model == null)
                    {
                        CreateDataModel();
                    }
                    else
                    {
                        LoadDataModel(model);
                    }
                }
                else
                {
                    CreateDataModel();
                }
            }
            else
            {
                object model = LoadModelFromPersistenceMedium();
                LoadDataModel(model);
            }
        }
        override protected void AddedControl(Control control, int index)
        {
            if (EnableDependencyInjection)
            {
                control = WebDependencyInjectionUtils.InjectDependenciesRecursive(_defaultApplicationContext, control);
            }
            base.AddedControl(control, index);
        }

        private bool _persistModelForEntireSession;

        public bool PersistModelForEntireSession
        {
            get
            {
                return _persistModelForEntireSession;
            }
            set
            {
                _persistModelForEntireSession = value;
            }
        }

        private bool _enableDependencyInjection;

        public bool EnableDependencyInjection
        {
            get
            {
                return _enableDependencyInjection;
            }
            set
            {
                _enableDependencyInjection = value;
            }
        }

        private ILogEx _logger;

        public ILogEx Logger
        {
            get
            {
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }

        private IApplicationContext _defaultApplicationContext;

        public IApplicationContext DefaultApplicationContext
        {
            get
            {
                return _defaultApplicationContext;
            }
            set
            {
                _defaultApplicationContext = value;
            }
        }

        private bool _throwExceptionIfSessionStateExpires;

        public bool ThrowExceptionIfSessionStateExpires
        {
            get
            {
                return _throwExceptionIfSessionStateExpires;
            }
            set
            {
                _throwExceptionIfSessionStateExpires = value;
            }
        }

    }
}

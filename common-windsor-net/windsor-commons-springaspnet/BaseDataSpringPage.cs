using System;
using System.Collections.Generic;
using System.Web;

using Windsor.Commons.Core;
using Windsor.Commons.Logging;

using Spring.Web.Support;
using Spring.Context;


namespace Windsor.Commons.Spring.AspNet
{
    public class BaseDataSpringPage<T> : BaseSpringPage where T : class, new()
    {
        public BaseDataSpringPage()
        {
        }
        public override void AfterPropertiesSet()
        {
            base.AfterPropertiesSet();
        }

        protected override void CreateDataModel()
        {
            _data = new T();
        }

        protected override void LoadDataModel(object savedModel)
        {
            _data = savedModel as T;
            if (_data == null)
            {
                // Session state may have timed out
                CreateDataModel();
            }
        }

        protected override object SaveDataModel()
        {
            return _data;
        }

        private T _data;

        public T Data
        {
            get
            {
                if (_data == null)
                {
                    CheckIfSessionStateExpired();
                    CheckDataModel();
                }
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}

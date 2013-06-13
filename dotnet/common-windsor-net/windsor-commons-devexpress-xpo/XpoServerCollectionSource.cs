
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Windsor.Commons.Core;

namespace Windsor.Commons.DeveloperExpress.Xpo
{
    public class XpoServerCollectionSource : XPServerCollectionSource
    {
        public XpoServerCollectionSource(DbConnection connection, XPClassInfo classInfo, ReflectionDictionary reflectionDictionary,
                                         IList<string> displayColumnNames)
            : base()
        {
            IDataLayer dataLayer = null;
            Session session = null;
            ConnectionState origConnectionState = connection.State;
            try
            {
                dataLayer = XpoDefault.GetDataLayer(connection, reflectionDictionary, AutoCreateOption.None);
                session = new Session(dataLayer);

                // The code below matches what the public XPServerCollectionSource(Session session, XPClassInfo objectClassInfo) custructor does:
                ReflectionUtils.SetFieldOrProperty(this, "_Session", session);
                ReflectionUtils.SetFieldOrProperty(this, "_ClassInfo", classInfo);
                ReflectionUtils.SetFieldOrProperty(this, "_FixedFilter", null);

                this.Session.CaseSensitive = false;
                this.Session.LockingOption = LockingOption.None;
                this.Session.OptimisticLockingReadBehavior = OptimisticLockingReadBehavior.Ignore;
                this.Session.TrackPropertiesModifications = false;
                this.TrackChanges = false;
                this.AllowEdit = false;
                this.AllowNew = false;
                this.AllowRemove = false;

                if (!CollectionUtils.IsNullOrEmpty(displayColumnNames))
                {
                    DisplayableProperties = StringUtils.Join(";", displayColumnNames);
                }
            }
            catch (Exception)
            {
                if (origConnectionState != ConnectionState.Open)
                {
                    connection.Close();
                }
                DisposableBase.SafeDispose(dataLayer);
                DisposableBase.SafeDispose(session);
            }
        }
        public int GetTotalRowCount()
        {
            return this.GetList().Count;
        }
        public IList GetList()
        {
            return (this as IListSource).GetList();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (this.Session.DataLayer.Connection != null)
                {
                    this.Session.DataLayer.Connection.Close();
                }
                DisposableBase.SafeDispose(this.Session.DataLayer);
                DisposableBase.SafeDispose(this.Session);
            }
        }
    }
}
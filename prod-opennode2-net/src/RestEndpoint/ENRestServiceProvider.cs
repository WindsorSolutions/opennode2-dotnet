using System;
using Windsor.Node2008.WNOSConnector.Service;
using Windsor.Node2008.WNOSConnector.Provider;

namespace Windsor.OpenNode2.RestEndpoint
{
    public interface IENRestServiceProvider
    {
        IVisitProvider VisitProvider
        {
            get;
            set;
        }

        IContentService ContentService
        {
            get;
            set;
        }

        ISecurityService SecurityService
        {
            get;
            set;
        }

        ITransactionService TransactionService
        {
            get;
            set;
        }
    }
    public class ENRestServiceProvider : IENRestServiceProvider
    {

        #region Members
        private IContentService _contentService;
        private ISecurityService _securityService;
        private ITransactionService _transactionService;
        private IVisitProvider _visitProvider;
        #endregion


        #region Init

        public virtual void Init()
        {

            if (_contentService == null)
            {
                throw new ArgumentException("ContentService property not set");
            }

            if (_securityService == null)
            {
                throw new ArgumentException("SecurityService property not set");
            }

            if (_transactionService == null)
            {
                throw new ArgumentException("TransactionService property not set");
            }

            if (_visitProvider == null)
            {
                throw new ArgumentException("VisitProvider property not set");
            }
        }

        #endregion


        #region Properties


        public virtual IVisitProvider VisitProvider
        {
            get
            {
                return _visitProvider;
            }
            set
            {
                _visitProvider = value;
            }
        }

        public virtual IContentService ContentService
        {
            get
            {
                return _contentService;
            }
            set
            {
                _contentService = value;
            }
        }

        public virtual ISecurityService SecurityService
        {
            get
            {
                return _securityService;
            }
            set
            {
                _securityService = value;
            }
        }

        public virtual ITransactionService TransactionService
        {
            get
            {
                return _transactionService;
            }
            set
            {
                _transactionService = value;
            }
        }
        #endregion
    }
}

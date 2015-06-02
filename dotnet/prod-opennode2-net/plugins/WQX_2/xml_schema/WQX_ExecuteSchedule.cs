using Windsor.Commons.NodeDomain;
namespace Windsor.Node2008.WNOSPlugin.WQX2XsdOrm
{
    public partial class WQXExecuteScheduleQueryParameters
    {
        public const string PARAM_ORGANIZATION_IDENTIFIER_KEY = "OrganizationIdentifier";
    }
        
    /// <remarks/>
    [System.SerializableAttribute()]
    public partial class WQXExecuteScheduleResult
    {
        public string LocalTransactionId;

        public string NetworkTransactionId;

        public string NodeEndpointUrl;

        public EndpointVersionType NodeEndpointVersion;

        public string ActivityDetails;
    }
}

using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Windsor.Commons.AspNet.WebApi.Filters;
using Windsor.Commons.AspNet.WebApi.Helpers;
using Windsor.Commons.Core;
using Windsor.Commons.NodeDomain;
using Windsor.Node2008.WNOSDomain;
using Windsor.OpenNode2.RestEndpoint.Filters;
using Windsor.OpenNode2.RestEndpoint.Models;

namespace Windsor.OpenNode2.RestEndpoint.Controllers
{
    public class QueryController : NodeEndpointMethodController
    {
        public virtual HttpResponseMessage Get([FromUri] QueryParameters parameters)
        {
            NamedOrAuthEndpointVisit visit = GetNamedOrAuthEndpointVisit(parameters);

            FormattedPaginatedContentRequest request = new FormattedPaginatedContentRequest();
            request.FlowName = parameters.Dataflow;
            request.OperationName = parameters.Request;
            request.Paging = new PaginationIndicator();
            request.Paging.Start = parameters.RowId.HasValue ? parameters.RowId.Value : 0;
            request.Paging.Count = parameters.MaxRows.HasValue ? parameters.MaxRows.Value : -1;
            request.Parameters = parameters.ParseParams();
            request.ZipResults = parameters.ZipResults;

            PaginatedContentResult resultSet = ServiceProvider.TransactionService.QueryEx(request, visit);

            if ((resultSet == null) || !resultSet.HasContent)
            {
                return this.Request.CreateBadRequestResponse("No data was returned from the query.");
            }

            HttpResponseMessage responseMessage = new HttpResponseMessage();

            switch (resultSet.Content.Type)
            {
                case CommonContentType.XML:
                case CommonContentType.Flat:
                case CommonContentType.HTML:
                    responseMessage.Content = new StringContent(resultSet.ConvertContentBytesToString());
                    break;
                default:
                    responseMessage.Content = new ByteArrayContent(resultSet.Content.Content);
                    break;
            }

            responseMessage.Content.Headers.ContentType =
                new MediaTypeHeaderValue(CommonContentAndFormatProvider.ConvertToMimeType(resultSet.Content.Type));

            return responseMessage;
        }
    }
}
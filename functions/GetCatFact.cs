using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ThmsRynr.CatFact
{
    public class GetCatFact
    {
        private readonly ICatFactService _catFactService;
        public GetCatFact(ICatFactService catFactService)
        {
            this._catFactService = catFactService;
        }

        [Function("GetCatFact")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GetCatFact");
            bool hasAgent = req.Headers.TryGetValues("User-Agent", out IEnumerable<string> agent);
            string agentString = hasAgent ? string.Join(' ', agent) : "No agent";
            logger.LogInformation($"GetCatFact API triggered. User Agent: {agentString}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(_catFactService.GetFact());

            return response;
        }
    }
}

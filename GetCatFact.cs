using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace ThmsRynr.CatFact
{
    public static class GetCatFact
    {
        public static CatFacts Facts { get; set; }
        static GetCatFact()
        {
            Facts = new CatFacts();
        }

        [Function("GetCatFact")]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("GetCatFact");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString(Facts.GetFact());

            return response;
        }
    }
}

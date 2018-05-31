using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace IoT.Parking.Function
{
    public static class Reserve
    {
        [FunctionName("Reserve")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequestMessage req, TraceWriter log)
        {
            log.Info("Reserve request starts.");

            string jsonContent = req.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ReserveRequest>(jsonContent);

            //Store in the repository

            return req.CreateResponse(HttpStatusCode.OK, $"Reserved for space `{data.Id}` for `{data.License}`.");
        }
    }
}

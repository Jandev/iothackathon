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
    public static class Parked
    {
        [FunctionName("Parked")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"get", "post", Route = "parked")]HttpRequestMessage req,
            Binder binder,
            TraceWriter log)
        {
            log.Info($"Park request starts.");

            string jsonContent = req.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<ParkRequest>(jsonContent);

            //Store in the repository

            return req.CreateResponse(HttpStatusCode.OK, $"Welcome {data.Id}");
        }
    }
}

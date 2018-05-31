using System.Collections.Generic;
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
    public static partial class List
    {
        [FunctionName("List")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            log.Info("Retrieving parking spaces.");


            //Retrieve data from repository
            var result = SingletonRepository.ParkingSpaces;
            
            return req.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(result));
        }
    }
}

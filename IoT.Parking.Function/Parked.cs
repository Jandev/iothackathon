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
    public static class Parked
    {
        [FunctionName("Parked")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Anonymous,"get", "post", Route = "parked")]HttpRequestMessage req,
            Binder binder,
            TraceWriter log)
        {
            log.Info($"Park request starts.");
            log.Info("Body: " + req.Content.ReadAsStringAsync().Result);
            log.Info("Header: " + req.Headers.ToString());

            string jsonContent = req.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Rootobject>(jsonContent);

            var payload = data?.DevEUI_uplink?.payload_hex;
            bool status = false;
            if (payload == null || payload == "0")
            {
                status = false;
            }
            else
            {
                status = true;
            }

            var myObject = new ParkRequest
            {
                Id = data?.DevEUI_uplink?.DevEUI ?? "99999",
                Status = status
            };

            //Store in the repository
            var parkingSpace = SingletonRepository.ParkingSpaces.FirstOrDefault(p => p.ParkingSpaceIdentifier == myObject.Id);
            if (parkingSpace == null)
            {
                SingletonRepository.ParkingSpaces.Add(new ParkingSpaces
                {
                    Status = myObject.Status,
                    ParkingSpaceIdentifier = myObject.Id
                });
            }
            else
            {
                parkingSpace.Status = myObject.Status;
            }

            return req.CreateResponse(HttpStatusCode.OK, $"Welcome {myObject.Id}");
        }
    }

    public static class SingletonRepository
    {
        static SingletonRepository()
        {
            SingletonRepository.ParkingSpaces = new List<ParkingSpaces>();
        }
        public static List<ParkingSpaces> ParkingSpaces { get; private set; }
    }
}

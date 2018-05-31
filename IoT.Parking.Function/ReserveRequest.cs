using System;

namespace IoT.Parking.Function
{
    public class ReserveRequest
    {
        public string Id { get; set; }
        public string License { get; set; }
        public DateTime When { get; set; }
    }
}
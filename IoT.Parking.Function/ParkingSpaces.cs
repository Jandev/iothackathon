using System;

namespace IoT.Parking.Function
{
    public class ParkingSpaces
    {
        public string ParkingSpaceIdentifier { get; set; }
        public bool Status { get; set; }
        public DateTime LastReservationTime { get; set; }
        public string Location { get; set; }
        public string LicensePlate { get; set; }
    }
}
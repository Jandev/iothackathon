using Microsoft.WindowsAzure.Storage.Table;

namespace IoT.Parking.Function
{
    public static partial class List
    {
        public class ListResponse : TableEntity
        {
            public string Id { get; set; }
            public bool Status { get; set; }
            public string Location { get; set; }
        }
    }
}

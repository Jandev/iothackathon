using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Parking.Function
{
    public class Repository : DbContext
    {
        public DbSet<ParkingSpaces> ParkingSpaces { get; set; }
    }
}

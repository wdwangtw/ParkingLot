using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class CommonParkingLotProvider : IParkingLotProvider
    {
        public ParkingLot GetParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.FirstOrDefault(parkingLot => parkingLot.EmptyParkingSpace() != 0);
        }
    }
}
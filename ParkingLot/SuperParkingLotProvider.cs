using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkingLotProvider : IParkingLotProvider
    {
        public ParkingLot GetParkingLot(List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpaceRatio()).FirstOrDefault();
        }
    }
}
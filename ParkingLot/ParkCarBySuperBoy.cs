using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkCarBySuperBoy
    {
        public ParkCarResult ParkCar(Car car, List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpaceRatio()).ToList()[0].Park(car);
        }
    }
}
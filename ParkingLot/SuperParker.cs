using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParker : IParker
    {
        public ParkCarResult ParkCar(List<ParkingLot> parkingLots, Car car)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpaceRatio()).ToList()[0].Park(car);
        }
    }
}
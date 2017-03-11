using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParker : IParker
    {
        public ParkCarResult ParkCar(List<ParkingLot> parkingLots, Car car)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).ToList()[0].Park(car);
        }
    }
}
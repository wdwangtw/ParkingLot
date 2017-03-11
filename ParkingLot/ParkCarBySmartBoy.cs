using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkCarBySmartBoy
    {
        public ParkCarResult ParkCar(Car car, List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).ToList()[0].Park(car);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public ParkCarResult Park(Car car)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).ToList()[0].Park(car);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public ParkCarResult Park(Car car)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpaceRatio()).ToList()[0].Park(car);
        }
    }
}
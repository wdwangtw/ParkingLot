using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots)
        {
        }

        public ParkCarResult Park(Car car)
        {
            return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }
    }
}
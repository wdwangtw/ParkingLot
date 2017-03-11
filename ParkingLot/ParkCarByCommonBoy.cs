using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkCarByCommonBoy
    {
        public ParkCarResult ParkCar(Car car, List<ParkingLot> parkingLots)
        {
            return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class CommonParker : IParker
    {
        public ParkCarResult ParkCar(List<ParkingLot> parkingLots, Car car)
        {
            return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkable : IParkable
    {
        public ParkCarResult ParkCar(List<IPickerParker> parkingLots, Car car)
        {
            IPickerParker parkingLot = parkingLots.OrderByDescending(p => ((ParkingLot)p).EmptyParkingSpaceRatio()).FirstOrDefault();
            return parkingLot == null ? ParkCarResult.NoParkingSpace : parkingLot.Park(car);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParkable : IParkable
    {
        public ParkCarResult ParkCar(List<IPickerParker> parkingLots, Car car)
        {
            IPickerParker parkingLot = parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).FirstOrDefault();
            return parkingLot == null ? ParkCarResult.NoParkingSpace : parkingLot.Park(car);
        }
    }
}
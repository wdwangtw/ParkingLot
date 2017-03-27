using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class CommonParkable : IParkable
    {
        public ParkCarResult ParkCar(List<IPickerParker> parkingLots, Car car)
        {
            IPickerParker parkingLot = parkingLots.FirstOrDefault(p => p.EmptyParkingSpace() != 0);
            return parkingLot == null ? ParkCarResult.NoParkingSpace : parkingLot.Park(car);
        }
    }
}
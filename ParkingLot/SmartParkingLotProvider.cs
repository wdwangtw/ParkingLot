using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParkingLotProvider : IParkingLotProvider
    {
        public PickerParker GetParkingLot(List<PickerParker> parkingLots)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).FirstOrDefault();
        }
    }
}
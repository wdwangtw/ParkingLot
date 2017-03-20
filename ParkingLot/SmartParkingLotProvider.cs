using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParkingLotProvider : IParkingLotProvider
    {
        public IPickerParker GetParkingLot(List<IPickerParker> parkingLots)
        {
            return parkingLots.OrderByDescending(p => (p as ParkingLot).EmptyParkingSpace()).FirstOrDefault();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkingLotProvider : IParkingLotProvider
    {
        public IPickerParker GetParkingLot(List<IPickerParker> parkingLots)
        {
            return parkingLots.OrderByDescending(p => (p as ParkingLot).EmptyParkingSpaceRatio()).FirstOrDefault();
        }
    }
}
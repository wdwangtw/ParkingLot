using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class CommonParkingLotProvider : IParkingLotProvider
    {
        public IPickerParker GetParkingLot(List<IPickerParker> parkingLots)
        {
            return parkingLots.FirstOrDefault(p => (p as ParkingLot).EmptyParkingSpace() != 0);
        }
    }
}
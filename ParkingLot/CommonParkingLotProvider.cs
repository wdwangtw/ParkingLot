using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class CommonParkingLotProvider : IParkingLotProvider
    {
        public PickerParker GetParkingLot(List<PickerParker> parkingLots)
        {
            return parkingLots.FirstOrDefault(parkingLot => parkingLot.EmptyParkingSpace() != 0);
        }
    }
}
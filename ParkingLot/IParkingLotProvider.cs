using System.Collections.Generic;

namespace ParkingLots
{
    public interface IParkingLotProvider
    {
        PickerParker GetParkingLot(List<PickerParker> parkingLots);
    }
}
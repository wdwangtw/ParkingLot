using System.Collections.Generic;

namespace ParkingLots
{
    public interface IParkingLotProvider
    {
        IPickerParker GetParkingLot(List<IPickerParker> parkingLots);
    }
}
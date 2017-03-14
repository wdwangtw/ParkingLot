using System.Collections.Generic;

namespace ParkingLots
{
    public interface IParkingLotProvider
    {
        ParkingLot GetParkingLot(List<ParkingLot> parkingLots);
    }
}
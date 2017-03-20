using System.Collections.Generic;

namespace ParkingLots
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots, ParkingLotProviderType.Commen)
        {
        }
    }
}
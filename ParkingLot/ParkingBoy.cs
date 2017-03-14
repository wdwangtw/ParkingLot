using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots, ParkingLotProviderType.Commen)
        {
        }
    }
}
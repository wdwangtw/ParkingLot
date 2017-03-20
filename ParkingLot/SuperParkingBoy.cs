using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots, ParkingLotProviderType.Super)
        {
        }
    }
}
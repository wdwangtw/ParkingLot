using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(List<PickerParker> parkingLots) : base(parkingLots, ParkingLotProviderType.Super)
        {
        }
    }
}
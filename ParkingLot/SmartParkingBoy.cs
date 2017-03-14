using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(List<PickerParker> parkingLots) : base(parkingLots, ParkingLotProviderType.Smart)
        {
        }
    }
}
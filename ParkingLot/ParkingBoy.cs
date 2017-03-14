using System.Collections.Generic;

namespace ParkingLots
{
    public class ParkingBoy : ParkingBoyBase
    {
        public ParkingBoy(List<PickerParker> parkingLots) : base(parkingLots, ParkingLotProviderType.Commen)
        {
        }
    }
}
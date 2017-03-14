using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase : PickerParker
    {
        protected List<PickerParker> parkingLots;
        readonly IParkingLotProvider parkingLotProvider;

        protected ParkingBoyBase(List<PickerParker> parkingLots, ParkingLotProviderType type)
        {
            this.parkingLots = new List<PickerParker>();
            this.parkingLots.AddRange(parkingLots);
            parkingLotProvider = ParkingLotProviderFactory.CreateParkingLotProvider(type);
        }

        public override ParkCarResult Park(Car car)
        {
            if (parkingLotProvider != null)
            {
                var parkingLot = parkingLotProvider.GetParkingLot(parkingLots);
                return parkingLot != null ? parkingLot.Park(car) : ParkCarResult.NoParkingSpace;
            }

            return ParkCarResult.NoParkingLotProviderType;
        }

        public override Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}
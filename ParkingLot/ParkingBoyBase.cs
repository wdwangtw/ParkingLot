using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase : IPickerParker
    {
        protected List<IPickerParker> parkingLots;
        readonly IParkingLotProvider parkingLotProvider;

        protected ParkingBoyBase(List<ParkingLot> parkingLots, ParkingLotProviderType type)
        {
            this.parkingLots = new List<IPickerParker>();
            this.parkingLots.AddRange(parkingLots);
            parkingLotProvider = ParkingLotProviderFactory.CreateParkingLotProvider(type);
        }

        public virtual ParkCarResult Park(Car car)
        {
            if (parkingLotProvider != null)
            {
                var parkingLot = parkingLotProvider.GetParkingLot(parkingLots);
                return parkingLot != null ? parkingLot.Park(car) : ParkCarResult.NoParkingSpace;
            }

            return ParkCarResult.NoParkingLotProviderType;
        }

        public virtual Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}
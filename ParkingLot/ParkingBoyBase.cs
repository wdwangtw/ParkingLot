using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> parkingLots;
        readonly IParkingLotProvider parkingLotProvider;

        protected ParkingBoyBase(List<ParkingLot> parkingLots, ParkingLotProviderType type)
        {
            this.parkingLots = new List<ParkingLot>();
            this.parkingLots.AddRange(parkingLots);
            parkingLotProvider = ParkingLotProviderFactory.CreateParkingLotProvider(type);
        }

        public ParkCarResult Park(Car car)
        {
            if (parkingLotProvider != null)
            {
                ParkingLot parkingLot = parkingLotProvider.GetParkingLot(parkingLots);
                return parkingLot != null ? parkingLot.Park(car) : ParkCarResult.NoParkingSpace;
            }

            return ParkCarResult.NoParkingLotProviderType;
        }

        public Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}